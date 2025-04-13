using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IAccountService
    {
        public void Register(string userName, string password, string firstName);
    }
}
