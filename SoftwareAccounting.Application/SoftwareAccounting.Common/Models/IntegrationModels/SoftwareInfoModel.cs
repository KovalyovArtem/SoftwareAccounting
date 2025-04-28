using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models.IntegrationModels
{
    public class SoftwareInfoModel
    {
        public string? ProgrammName { get; set; }

        public string? ProgrammVersion { get; set; }

        public string? ProgrammDeveloper { get; set; }

        public string? ProgrammLicense { get; set; }

        public string? ProgrammInstalledDate { get; set; }

        public string? ProgrammSize { get; set; }

        public string? ProgrammInstallLocation { get; set; }

        public string? ProgrammPublisher { get; set; }
    }
}
