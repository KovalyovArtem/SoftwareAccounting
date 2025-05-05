namespace SoftwareAccounting.Common.Models
{
    public class SoftwareInfoModel
    {
        public Guid? Id { get; set; }

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
