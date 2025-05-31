using SoftwareAccounting.Common.Models.PoepleModels;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        Task<List<User>> GetUsers();

        Task<List<Employer>> GetEmployers();
    }
}
