using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Common.Models.PoepleModels;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAccounting.Service.Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly ILogger<PeopleService> _logger;
        private readonly IOptions<AppSettings> _settings;

        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(
            ILogger<PeopleService> logger,
            IOptions<AppSettings> settings,
            IPeopleRepository peopleRepository)
        {
            _logger = logger;
            _settings = settings;

            _peopleRepository = peopleRepository;
        }

        public async Task<List<Employer>> GetEmployers()
        {
            var employers = await _peopleRepository.GetEmployers();
            return employers;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _peopleRepository.GetUsers();
            return users;
        }
    }
}
