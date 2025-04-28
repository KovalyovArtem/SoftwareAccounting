using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Common.Models.DeviceInfo
{
    public class DeviceInfoModel
    {
        public List<SoftwareInfoModel> SoftwareInfoList { get; set; } = new List<SoftwareInfoModel>();

        public List<HarwareInfoModel> HarwareInfoList { get; set; } = new List<HarwareInfoModel>();

        public string? ErrorMessage { get; set; }
    }
}