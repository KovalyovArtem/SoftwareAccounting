using SoftwareAccounting.Library.SoftwareScan.Interfaces;

namespace SoftwareAccounting.Library.SoftwareScan.Implementations
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
