using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.DeviceInfo;
using SoftwareAccounting.Library.Services.DeviceScan.Interfaces;
using System.Globalization;
using System.Management;

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
                        ProgrammAuthor = subKey?.GetValue("Publisher")?.ToString(),
                        ProgrammLicense = subKey?.GetValue("ProductID")?.ToString() ?? subKey?.GetValue("LicenseProduct")?.ToString(),
                        ProgrammVersion = subKey?.GetValue("Publisher")?.ToString(),
                        ProgrammInstalledDate = realDate ? installDate.ToString("dd.mm.yyyy") : "N/A",
                        ProgrammSize = subKey?.GetValue("Publisher")?.ToString(),
                        ProgrammInstallLocation = GetInstallSize(subKey)
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

        ///<inheritdoc/>
        public List<HarwareInfoModel> DoScanHarwareDevice()
        {
            throw new NotImplementedException();
        }
    }
}
