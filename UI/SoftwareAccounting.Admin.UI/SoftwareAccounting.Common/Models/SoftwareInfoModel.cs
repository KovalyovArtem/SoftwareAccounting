using System.ComponentModel;

namespace SoftwareAccounting.Common.Models
{
    public class SoftwareInfoModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Название")]
        public string? ProgrammName { get; set; }

        [DisplayName("Версия")]
        public string? ProgrammVersion { get; set; }

        [DisplayName("Разработчик")]
        public string? ProgrammDeveloper { get; set; }

        [DisplayName("Лицензия")]
        public string? ProgrammLicense { get; set; }

        [DisplayName("Дата установки")]
        public string? ProgrammInstalledDate { get; set; }

        [DisplayName("Размер")]
        public string? ProgrammSize { get; set; }

        [DisplayName("Расположение")]
        public string? ProgrammInstallLocation { get; set; }

        [DisplayName("Издатель")]
        public string? ProgrammPublisher { get; set; }
    }
}
