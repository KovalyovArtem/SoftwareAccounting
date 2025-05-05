namespace SoftwareAccounting.Domain.Models
{
    public class DeviceSettingsInfoModel
    {
        public Guid Id { get; set; }
        public Guid? Sotr { get; set; }

        public string? Synonym { get; set; }

        public string? MacAddress { get; set; }

        public string? IpAddress { get; set; }

        public bool IsActive { get; set; }

        public string OsName { get; set; }

        public string? OsArchitecture { get; set; }
    }
}
