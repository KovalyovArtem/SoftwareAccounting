using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models.RequestModels
{
    public class DeviceDeactivateModel
    {
        public string? Synonym { get; set; }

        public string? MacAdress { get; set; }

        public string? DeviceName { get; set; }
    }
}
