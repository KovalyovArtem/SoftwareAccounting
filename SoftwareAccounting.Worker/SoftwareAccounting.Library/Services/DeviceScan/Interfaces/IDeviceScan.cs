using SoftwareAccounting.Common.Models.DeviceInfo;

namespace SoftwareAccounting.Library.Services.DeviceScan.Interfaces
{
    public interface IDeviceScan
    {
        /// <summary>
        /// Сканирование устройства на установленное ПО
        /// </summary>
        /// <returns>Модель данных установленного ПО</returns>
        List<SoftwareInfoModel> DoScanSoftwareDevice();

        /// <summary>
        /// Сканирование устройства на железо и подключённую переферию
        /// </summary>
        /// <returns>Возвращает модель железа на устройстве и подключённую переферию</returns>
        List<HarwareInfoModel> DoScanHarwareDevice();
    }
}
