using SoftwareAccounting.Library.Services.SoftwareScan.Interfaces;

namespace SoftwareAccounting.Library.Services.SoftwareScan.Implementations
{
    public class WindowsSoftwareScan : ISoftwareScan
    {
        public Task<string> DoScanHarwareDevice()
        {
            throw new NotImplementedException();
        }

        public Task<string> DoScanSoftwareDevice()
        {
            throw new NotImplementedException();
        }
    }
}
