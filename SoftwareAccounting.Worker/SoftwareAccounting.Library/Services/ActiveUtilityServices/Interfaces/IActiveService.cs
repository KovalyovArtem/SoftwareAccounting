using SoftwareAccounting.Common.Models.DeviceInfo;

namespace SoftwareAccounting.Library.Services.ActiveUtilityServices.Interfaces
{
    public interface IActiveService
    {
        /// <summary>
        /// Отправляет запрос в главный API-сервис, что компьютер в данный момент запустился
        /// </summary>
        /// <returns>Возвращает true, если запрос был успешно отправлен, иначе false</returns>
        Task<bool> SendInfoAboutDeviceIsActive(DeviceSettingsModel model);
    }
}
