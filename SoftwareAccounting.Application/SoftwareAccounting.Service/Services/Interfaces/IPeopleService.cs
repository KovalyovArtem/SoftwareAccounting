using SoftwareAccounting.Common.Models.PoepleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IPeopleService
    {
        Task<List<User>> GetUsers();

        Task<List<Employer>> GetEmployers();
    }
}
