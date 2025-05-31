using System.ComponentModel;

namespace SoftwareAccounting.Common.Models.Poeple
{
    public class Employer
    {
        public required Guid Id { get; set; }

        [DisplayName("Фамилия")]
        public required string Surname { get; set; }

        [DisplayName("Имя")]
        public required string Name { get; set; }

        [DisplayName("Отчество")]
        public string? Patronymic { get; set; }

        [DisplayName("Почта")]
        public string? Email { get; set; }

        [DisplayName("Телефон")]
        public string? Telephone { get; set; }

        [DisplayName("Дата рождения")]
        public required string Birthdate { get; set; }
    }
}
