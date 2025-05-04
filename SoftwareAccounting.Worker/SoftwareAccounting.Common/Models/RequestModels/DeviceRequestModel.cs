using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models.RequestModels
{
    public class DeviceRequestModel
    {
        public string? DeviceName { get; set; }

        public string? DeviceMacAddress { get; set; }

        public string? DeviceOS { get; set; }

        public string? DeviceOSArchitecture { get; set; }

        public string? DeviceDNS { get; set; }

        public string? DevicLicense { get; set; }

        public string? DeviceIpAddress { get; set; }

        public string? DeviceSynonym { get; set; }
    }
}
