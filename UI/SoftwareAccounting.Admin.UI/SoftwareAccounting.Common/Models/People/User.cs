using System.ComponentModel;

namespace SoftwareAccounting.Common.Models.Poeple
{
    public class User
    {
        public required Guid Id { get; set; }

        [DisplayName("Логин")]
        public required string Login { get; set; }

        [DisplayName("Почта")]
        public string? Email { get; set; }
    }
}
