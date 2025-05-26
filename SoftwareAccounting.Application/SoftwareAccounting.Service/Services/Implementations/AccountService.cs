using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.RegisterModels;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IAccountRepository _accountRepository;

        private readonly IJwtService _jwtService;

        public AccountService(ILogger<AccountService> logger,
                              IOptions<AppSettings> settings,
                              IAccountRepository accountRepository,
                              IJwtService jwtService)
        {
            _logger = logger;
            _settings = settings;
            _accountRepository = accountRepository;
            _jwtService = jwtService;
        }

        public AccountService(
            IAccountRepository accountRepository,
            IJwtService jwtService)
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
        }


        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<string> Register(string userName, string password)
        {
            // Надо сделать проверку на существование пользователя с таким же именем
            if (userName == "admin")
                return "Пользователь с таким логином уже существует";

            var model = new AccountModel
            {
                UserName = userName,
                Password = password
            };

            var hashPassword = new PasswordHasher<AccountModel>().HashPassword(model, password);
            model.HashPassword = hashPassword;

            var p = await _accountRepository.RegisterUser(model);

            return "Регистрация прошла успешно";
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userName">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> Login(string userName, string password)
        {
            var account = await _accountRepository.GetAccountByUserName(userName);
            var result = new PasswordHasher<AccountModel>().VerifyHashedPassword(account, account.HashPassword, password);

            if(result == PasswordVerificationResult.Success)
            {
                var token = await _jwtService.GenerateToken(account);
                return token.ToString();
            }
            else
            {
                throw new Exception("Unauthorized");
            }

        }
    }
}
