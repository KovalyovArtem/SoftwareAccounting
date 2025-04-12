using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Library.SoftwareScan.Interfaces
{
    public interface ISoftwareScan
    {
        /// <summary>
        /// Сканирование устройства на установленное ПО
        /// </summary>
        /// <returns>Модель данных установленного ПО</returns>
        Task<string> DoScanSoftwareDevice();

        /// <summary>
        /// Сканирование устройства на железо и подключённую переферию
        /// </summary>
        /// <returns>Возвращает модель железа на устройстве и подключённую переферию</returns>
        Task<string> DoScanHarwareDevice();
    }
}
