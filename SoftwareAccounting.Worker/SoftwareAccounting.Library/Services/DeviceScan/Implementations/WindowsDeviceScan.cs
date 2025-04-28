using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.DeviceInfo;
using SoftwareAccounting.Library.Services.DeviceScan.Interfaces;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace SoftwareAccounting.Library.Services.DeviceScan.Implementations
{
    public class WindowsDeviceScan : IDeviceScan
    {
        private readonly ILogger<WindowsDeviceScan> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public WindowsDeviceScan(ILogger<WindowsDeviceScan> logger,
                                 IOptions<AppSettings> appSettings)
        {
            logger = _logger;
            _appSettings = appSettings;
        }

        ///<inheritdoc/>
        public List<SoftwareInfoModel> DoScanSoftwareDevice()
        {
            string[] registryKeys = {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall" // Для 32-bit ПО на 64-bit Windows
            };

            List<SoftwareInfoModel> model = new List<SoftwareInfoModel>();

            foreach (var keyPath in registryKeys)
            {
                using var key = Registry.LocalMachine.OpenSubKey(keyPath);

                if (key == null) continue;

                foreach (string subKeyName in key.GetSubKeyNames())
                {
                    using var subKey = key.OpenSubKey(subKeyName);

                    if (subKey == null) continue;

                    string name = subKey.GetValue("DisplayName")?.ToString();
                    if (string.IsNullOrEmpty(name)) continue;

                    var realDate = DateTime.TryParseExact(subKey?.GetValue("InstallDate")?.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime installDate);

                    var programm = new SoftwareInfoModel()
                    {
                        ProgrammName = name,
                        ProgrammDeveloper = GetDeveloper(subKey) ?? "N/A",
                        ProgrammLicense = GetLicense(subKey),
                        ProgrammVersion = subKey?.GetValue("DisplayVersion")?.ToString() ?? "N/A",
                        ProgrammInstalledDate = realDate ? installDate.ToString("dd.mm.yyyy") : "N/A",
                        ProgrammSize = GetInstallSize(subKey),
                        ProgrammInstallLocation = subKey?.GetValue("InstallLocation")?.ToString() ?? "N/A",
                        ProgrammPublisher = subKey?.GetValue("Publisher")?.ToString() ?? "N/A"
                    };

                    model.Add(programm);
                }
            }

            return model;
        }

        private string GetInstallSize(RegistryKey key)
        {
            // Размер в байтах (может быть в EstimatedSize или InstallSize)
            object sizeValue = key.GetValue("EstimatedSize") ?? key.GetValue("InstallSize");
            if (sizeValue == null) return "N/A";

            long sizeBytes = Convert.ToInt64(sizeValue);
            return $"{sizeBytes / 1024 / 1024} MB";
        }

        private string GetLicense(RegistryKey subKey)
        {
            string[] possibleLicenseKeys = {
                "ProductID",
                "RegOwner",
                "SerialNumber",
                "LicenseProduct",
                "UninstallString" // Иногда содержит ключ
            };

            foreach (var key in possibleLicenseKeys)
            {
                string value = subKey?.GetValue(key)?.ToString();
                if (!string.IsNullOrEmpty(value))
                    return value;
            }

            return "N/A";
        }

        private string GetDeveloper(RegistryKey subKey)
        {
            try
            {
                string exePath = subKey?.GetValue("InstallLocation")?.ToString() + "\\" + subKey?.GetValue("DisplayIcon")?.ToString().Split(',')[0];

                if (string.IsNullOrEmpty(exePath))
                    return "N/A";

                var info = FileVersionInfo.GetVersionInfo(exePath);
                return info.CompanyName ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        ///<inheritdoc/>
        public List<HarwareInfoModel> DoScanHarwareDevice()
        {
            return new List<HarwareInfoModel>();
        }

        public DeviceSettingsModel DoScanSettingsDevice()
        {
            var model = new DeviceSettingsModel();

            model.DeviceName = Environment.MachineName;
            model.DeviceOS = RuntimeInformation.OSDescription?.ToString();
            model.DeviceOSArchitecture = RuntimeInformation.OSArchitecture.ToString();
            model.DevicLicense = GetWindowsProductKey();

            var localIP = GetLocalIPAddress();
            var nic = GetNetworkInterfaceByLocalIP(localIP);
            if (nic != null)
            {
                model.DeviceMacAddress = string.Join(":", nic.GetPhysicalAddress().GetAddressBytes().Select(b => b.ToString("X2")));
                model.DeviceDNS = string.Join(", ", nic.GetIPProperties().DnsAddresses);
            }
            
            return model;
        }

        string GetWindowsProductKey()
        {
            const string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            using var key = Registry.LocalMachine.OpenSubKey(keyPath);

            // DigitalProductId — зашифрованный ключ (24 байта)
            byte[] digitalProductId = key?.GetValue("DigitalProductId") as byte[];
            if (digitalProductId == null || digitalProductId.Length < 24)
                return "N/A";

            return DecodeProductKey(digitalProductId);
        }

        // Алгоритм расшифровки (источник: Microsoft docs)
        string DecodeProductKey(byte[] digitalProductId)
        {
            const string keyChars = "BCDFGHJKMPQRTVWXY2346789";
            char[] productKey = new char[29];

            for (int i = 0; i < 25; i++)
            {
                int current = 0;
                for (int j = 14; j >= 0; j--)
                {
                    current = (current << 8) | digitalProductId[j];
                    digitalProductId[j] = (byte)(current / 24);
                    current %= 24;
                }
                productKey[i] = keyChars[current];
            }

            return new string(productKey).Insert(5, "-").Insert(11, "-").Insert(17, "-").Insert(23, "-");
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
