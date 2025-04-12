using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models
{
    public class AppSettings
    {
        public required string ApiServiceUrl { get; set; }

        public required string SoftwareUrl { get; set; }
    }
}
