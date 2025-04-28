using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SoftwareAccounting.Common.Models.RegisterModels
{
    public class AccountModel
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? HashPassword { get; set; }
        public string? Email { get; set; }
    }
}
