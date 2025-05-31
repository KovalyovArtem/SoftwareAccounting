using System.ComponentModel;

namespace SoftwareAccounting.Common.Models
{
    public class DeviceInfoModel
    {
        public Guid Id { get; set; }
        public Guid? Sotr { get; set; }

        [DisplayName("Синоним устройства")]
        public string? Synonym { get; set; }

        [DisplayName("Мак адрес")]
        public string? MacAddress { get; set; }

        [DisplayName("IP-адрес")]
        public string? IpAddress { get; set; }

        [DisplayName("Статус устройства")]
        public bool IsActive { get; set; }

        [DisplayName("Название ОС")]
        public string OsName { get; set; }

        [DisplayName("Архитектура ОС")]
        public string? OsArchitecture { get; set; }
    }
}
