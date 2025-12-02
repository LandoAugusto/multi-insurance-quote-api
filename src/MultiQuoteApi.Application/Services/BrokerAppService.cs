using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Application.Services
{
    internal class BrokerAppService(
        IMapper mapper,
        IBrokerRepository brokerRepository,
        IPersonRepository personRepository,
        IUserAppService userAppService) : IBrokerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBrokerRepository _brokerRepository = brokerRepository;
        private readonly IPersonRepository _personRepository = personRepository;
        private readonly IUserAppService _userAppService = userAppService;

        public async Task<BrokerOptionModel?> GetByIdAsync(int brokerId, RecordStatusEnum recordStatus)
        {
            var entity = await _brokerRepository.GetByIdAsync(brokerId, recordStatus);
            return entity is null ? null : _mapper.Map<BrokerOptionModel>(entity);
        }

        public async Task CreateAsync(BrokerModel request)
        {
            const int systemUserId = 99;

            await _userAppService.ValidateUserAsync(request.Credencial.Login);

            var (brokerId, personId) = await CreateBrokerAsync(systemUserId, request);

            await _userAppService.CreateUserAsync(new UserPersonModel
            {
                BrokerId = brokerId,
                PersonId = personId,
                ProfileId = (int)ProfileEnum.Gestor,
                Credencial = request.Credencial
            });
        }


        public async Task CreateUserAsync(int userId, int brokerId, BrokerUserModel request)
        {
            await _userAppService.ValidateUserAsync(request.Credencial.Login);

            var personId = await CreatePersonAsync(userId, request);

            await _userAppService.CreateUserAsync(new UserPersonModel
            {
                BrokerId = brokerId,
                PersonId = personId,
                ProfileId = request.ProfileId,
                Credencial = request.Credencial
            });
        }


        private async Task<(int BrokerId, int PersonId)> CreateBrokerAsync(int userId, BrokerModel model)
        {
            var person = BuildPerson(userId, model);

            person.Broker = new []
            {
                new Broker
                {
                    SusepCode = model.Susep,
                    InclusionUserId = userId,
                    Status = (int)RecordStatusEnum.Active
                }
            };

            var created = await _personRepository.AddAsync(person);
            return (created.Broker.First().BrokerId, created.PersonId);
        }

        private async Task<int> CreatePersonAsync(int userId, BrokerUserModel model)
        {
            var person = BuildPerson(userId, model);

            var created = await _personRepository.AddAsync(person);
            return created.PersonId;
        }

        private static Person BuildPerson(int userId, BasePersonModel model)
        {
            return new Person
            {
                Name = model.Name,
                Document = model.Document,
                PersonTypeId = model.PersonTypeId,
                Status = (int)RecordStatusEnum.Active,
                InclusionUserId = userId,
                Address = model.Address?.Select(a => BuildAddress(userId, a)).ToList() ?? new(),
                Contact = model.Contact?.Select(c => BuildContact(userId, c)).ToList() ?? new()
            };
        }

        private static Address BuildAddress(int userId, AddressModel a)
        {
            return new Address
            {
                StreetName = a.StreetName,
                Number = a.Number,
                City = a.City,
                ZipCode = a.ZipCode,
                District = a.District,
                Complement = a.Complement,
                Status = (int)RecordStatusEnum.Active,
                AddressTypeId = a.AddressTypeId,
                IsMainAddress = true,
                InclusionUserId = userId
            };
        }

        private static Contact BuildContact(int userId, ContactModel c)
        {
            return new Contact
            {
                ContactTypeId = c.ContactTypeId,
                ContactCategoryId = c.ContactCategoryId,
                Value = c.Value,
                Status = (int)RecordStatusEnum.Active,
                InclusionUserId = userId
            };
        }
    }
}
