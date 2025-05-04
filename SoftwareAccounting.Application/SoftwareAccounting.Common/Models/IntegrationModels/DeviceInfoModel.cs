namespace SoftwareAccounting.Common.Models.IntegrationModels
{
    public class DeviceInfoModel
    {
        public List<SoftwareInfoModel> SoftwareInfoList { get; set; } = new List<SoftwareInfoModel>();

        public List<HarwareInfoModel> HarwareInfoList { get; set; } = new List<HarwareInfoModel>();
    }
}
