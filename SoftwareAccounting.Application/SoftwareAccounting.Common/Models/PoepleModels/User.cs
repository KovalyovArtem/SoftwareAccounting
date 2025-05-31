namespace SoftwareAccounting.Common.Models.PoepleModels
{
    public class User
    {
        public required Guid Id { get; set; }

        public required string Login { get; set; }

        public string? Email { get; set; }
    }
}
