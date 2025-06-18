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
using System.Threading.Tasks;

namespace SoftwareAccounting.Library.Services.DeviceScan.Implementations
{
    public class LinuxDeviceScan : IDeviceScan
    {
        private readonly ILogger<LinuxDeviceScan> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public LinuxDeviceScan(
            ILogger<LinuxDeviceScan> logger,
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
                // Используем dpkg-query для получения установленных пакетов (только для Debian/Ubuntu)
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "dpkg-query",
                        Arguments = "-W -f='${Package}|${Version}|${Maintainer}\\n'",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Trim('\'').Split('|');
                    if (parts.Length < 3) continue;

                    softwareList.Add(new SoftwareInfoModel
                    {
                        ProgrammName = parts[0],
                        ProgrammVersion = parts[1],
                        ProgrammDeveloper = parts[2],
                        ProgrammPublisher = parts[2],
                        ProgrammLicense = "N/A",
                        ProgrammInstalledDate = "N/A",
                        ProgrammSize = "N/A",
                        ProgrammInstallLocation = "/usr/bin"
                    });
                }

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при сканировании ПО в Linux.");
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
                var lines = File.ReadAllLines("/proc/cpuinfo");
                var modelLine = lines.FirstOrDefault(x => x.StartsWith("model name"));
                return modelLine?.Split(':')[1].Trim() ?? "Unknown CPU";
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
                    FileName = "lshw",
                    Arguments = "-C display",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                });

                var output = process?.StandardOutput.ReadToEnd();
                process?.WaitForExit();

                var line = output?.Split('\n').FirstOrDefault(x => x.Trim().StartsWith("product:"));
                return line?.Split(':')[1].Trim() ?? "Unknown GPU";
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
