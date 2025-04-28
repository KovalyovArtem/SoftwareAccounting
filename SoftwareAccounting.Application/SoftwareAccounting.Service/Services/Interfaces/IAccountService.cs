namespace SoftwareAccounting.Service.Services.Interfaces
{
    public interface IAccountService
    {
        public Task Register(string userName, string password);

        public Task<string> Login(string userName, string password);
    }
}
