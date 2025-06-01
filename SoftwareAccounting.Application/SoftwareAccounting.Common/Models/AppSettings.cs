using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models
{
    public class AppSettings
    {
        public required string DbConnection { get; set; }

        public required bool IsLog { get; set; }

        public required int MaxScanningPool { get; set; }
        public required string WebUIHostUrl { get; set; }

        public required AuthSettings AuthSettings { get; set; }
    }
}
