using SoftwareAccounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Domain.Repositories.Interfaces
{
    public interface IDevicesRepository
    {
        Task<List<DeviceInfoModel>> GetDevicesAsync();

        Task<DeviceExtensionInfoModel> GetDeviceInfoAsync(Guid id);
    }
}
