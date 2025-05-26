using Moq;
using Xunit;
using Microsoft.AspNetCore.Identity;
using SoftwareAccounting.Common.Models.RegisterModels;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.UnitTesting
{
    public class AccountServiceTests
    {
        private readonly Mock<IAccountRepository> _mockAccountRepository;
        private readonly Mock<IJwtService> _mockJwtService;
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            _mockAccountRepository = new Mock<IAccountRepository>();
            _mockJwtService = new Mock<IJwtService>();
            _accountService = new AccountService(_mockAccountRepository.Object, _mockJwtService.Object);
        }

        [Fact]
        public async Task Register_WithExistingAdminUser_ReturnsErrorMessage()
        {
            // Arrange
            var userName = "admin";
            var password = "password123";

            // Act
            var result = await _accountService.Register(userName, password);

            // Assert
            Assert.Equal("Пользователь с таким логином уже существует", result);
        }

        [Fact]
        public async Task Register_WithNewUser_ReturnsSuccessMessage()
        {
            // Arrange
            var userName = "newuser";
            var password = "password123";

            var result = await _accountService.Register(userName, password);

            Assert.Equal("Регистрация прошла успешно", result);
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var userName = "validuser";
            var password = "correctpassword";
            var expectedToken = "generated.jwt.token";

            var account = new AccountModel
            {
                UserName = userName,
                HashPassword = "hashedpassword"
            };

            _mockAccountRepository.Setup(x => x.GetAccountByUserName(userName))
                .ReturnsAsync(account);

            _mockJwtService.Setup(x => x.GenerateToken(account))
                .ReturnsAsync(expectedToken);

            var result = await _accountService.Login(userName, password);

            Assert.Equal(expectedToken, result);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ThrowsException()
        {
            // Arrange
            var userName = "invaliduser";
            var password = "wrongpassword";

            var account = new AccountModel
            {
                UserName = userName,
                HashPassword = "hashedpassword"
            };

            await Assert.ThrowsAsync<Exception>(() => _accountService.Login(userName, password));
        }

        [Fact]
        public async Task Login_WithNonExistingUser_ThrowsException()
        {
            var userName = "nonexistinguser";
            var password = "anypassword";

            _mockAccountRepository.Setup(x => x.GetAccountByUserName(userName))
                .ReturnsAsync((AccountModel)null);

            await Assert.ThrowsAsync<Exception>(() => _accountService.Login(userName, password));
        }

    }
}
