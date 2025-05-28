using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models.AuthModel
{
    public class AuthState
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
