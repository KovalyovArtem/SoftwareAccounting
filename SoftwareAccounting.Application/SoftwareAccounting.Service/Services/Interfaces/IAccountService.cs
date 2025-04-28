using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IAccountService
    {
        public Task Register(string userName, string password);

        public Task<string> Login(string userName, string password);
    }
}
