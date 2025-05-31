namespace SoftwareAccounting.Common.Models.PoepleModels
{
    public class Employer
    {
        public required Guid Id { get; set; }

        public required string Surname { get; set; }

        public required string Name { get; set; }

        public string? Patronymic { get; set; }

        public string? Email { get; set; }

        public string? Telephone { get; set; }

        public required string Birthdate { get; set; }
    }
}
