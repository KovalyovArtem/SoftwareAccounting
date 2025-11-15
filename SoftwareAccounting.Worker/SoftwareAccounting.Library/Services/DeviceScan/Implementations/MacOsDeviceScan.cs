using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.DeviceInfo;
using SoftwareAccounting.Library.Services.DeviceScan.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftwareAccounting.Library.Services.DeviceScan.Implementations
{
    public class MacOsDeviceScan : IDeviceScan
    {
        private readonly ILogger<MacOsDeviceScan> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public MacOsDeviceScan(
            ILogger<MacOsDeviceScan> logger,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public List<SoftwareInfoModel> DoScanSoftwareDevice()
        {
            var softwareList = new List<SoftwareInfoModel>();

            try
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "system_profiler",
                    Arguments = "SPApplicationsDataType -xml",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                var output = process?.StandardOutput.ReadToEnd();
                process?.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    // Простой парсинг можно сделать на основе обычного `system_profiler SPApplicationsDataType`
                    // Здесь используем строковый разбор как упрощение
                    var textProcess = Process.Start(new ProcessStartInfo
                    {
                        FileName = "system_profiler",
                        Arguments = "SPApplicationsDataType",
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    });

                    var textOutput = textProcess?.StandardOutput.ReadToEnd();
                    textProcess?.WaitForExit();

                    if (!string.IsNullOrEmpty(textOutput))
                    {
                        var appBlocks = textOutput.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var block in appBlocks)
                        {
                            var lines = block.Split('\n');

                            string? name = null, version = null, path = null, developer = null;

                            foreach (var line in lines)
                            {
                                if (line.Trim().StartsWith("Name:"))
                                    name = line.Split(':', 2)[1].Trim();
                                else if (line.Trim().StartsWith("Version:"))
                                    version = line.Split(':', 2)[1].Trim();
                                else if (line.Trim().StartsWith("Last Modified:"))
                                    continue;
                                else if (line.Trim().StartsWith("Obtained from:"))
                                    developer = line.Split(':', 2)[1].Trim();
                                else if (line.Trim().StartsWith("Location:"))
                                    path = line.Split(':', 2)[1].Trim();
                            }

                            if (!string.IsNullOrEmpty(name))
                            {
                                softwareList.Add(new SoftwareInfoModel
                                {
                                    ProgrammName = name,
                                    ProgrammVersion = version ?? "N/A",
                                    ProgrammPublisher = developer ?? "Apple / Unknown",
                                    ProgrammDeveloper = developer ?? "Apple / Unknown",
                                    ProgrammInstallLocation = path ?? "N/A",
                                    ProgrammLicense = "N/A",
                                    ProgrammInstalledDate = "N/A",
                                    ProgrammSize = "N/A"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при сканировании ПО на MacOS.");
            }

            return softwareList;
        }

        public DeviceSettingsModel DoScanSettingsDevice()
        {
            var model = new DeviceSettingsModel
            {
                DeviceName = Environment.MachineName,
                DeviceOS = RuntimeInformation.OSDescription,
                DeviceOSArchitecture = RuntimeInformation.OSArchitecture.ToString(),
                DevicLicense = "N/A"
            };

            var localIP = GetLocalIPAddress();
            var nic = GetNetworkInterfaceByLocalIP(localIP);
            if (nic != null)
            {
                model.DeviceMacAddress = string.Join(":", nic.GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")));
                model.DeviceDNS = string.Join(", ", nic.GetIPProperties().DnsAddresses);
            }

            model.DeviceIpAddress = localIP;

            return model;
        }

        public List<HarwareInfoModel> DoScanHarwareDevice()
        {
            return new List<HarwareInfoModel>
            {
                new HarwareInfoModel
                {
                    Name = "CPU",
                    Value = GetCpuModel()
                },
                new HarwareInfoModel
                {
                    Name = "GPU",
                    Value = GetGpuModel()
                }
            };
        }

        private string GetCpuModel()
        {
            try
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "sysctl",
                    Arguments = "-n machdep.cpu.brand_string",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                });

                string output = process?.StandardOutput.ReadToEnd()?.Trim() ?? "Unknown CPU";
                process?.WaitForExit();

                return output;
            }
            catch
            {
                return "Unknown CPU";
            }
        }

        private string GetGpuModel()
        {
            try
            {
                var process = Process.Start(new ProcessStartInfo
                {
                    FileName = "system_profiler",
                    Arguments = "SPDisplaysDataType",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                });

                var output = process?.StandardOutput.ReadToEnd();
                process?.WaitForExit();

                var match = Regex.Match(output ?? "", @"Chipset Model:\s*(.+)");
                return match.Success ? match.Groups[1].Value.Trim() : "Unknown GPU";
            }
            catch
            {
                return "Unknown GPU";
            }
        }

        static string GetLocalIPAddress()
        {
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
            socket.Connect("8.8.8.8", 65530);
            var endPoint = socket.LocalEndPoint as IPEndPoint;
            return endPoint?.Address.ToString() ?? throw new Exception("Не удалось определить локальный IP.");
        }

        NetworkInterface? GetNetworkInterfaceByLocalIP(string localIP)
        {
            var targetIP = IPAddress.Parse(localIP);

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                var ipProps = nic.GetIPProperties();
                foreach (var ua in ipProps.UnicastAddresses)
                {
                    if (ua.Address.AddressFamily == AddressFamily.InterNetwork && ua.Address.Equals(targetIP))
                    {
                        return nic;
                    }
                }
            }

            return null;
        }
    }
}
