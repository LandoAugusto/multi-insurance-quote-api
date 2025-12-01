using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        IUserAppService userAppService)
        : IBrokerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPersonRepository _personRepository = personRepository;
        private readonly IBrokerRepository _brokerRepository = brokerRepository;

        private readonly IUserAppService _userAppService = userAppService;

        public async Task<BrokerOptionModel?> GetByIdAsync(int brokerId, RecordStatusEnum recordStatus)
        {
            var entity = await _brokerRepository.GetByIdAsync(brokerId, recordStatus);
            if (entity == null) return null;

            return _mapper.Map<BrokerOptionModel>(entity);
        }

        public async Task CreateAsync(int userId, BrokerModel request)
        {
            await _userAppService.ValidateUserAsync(request.Credencial.Login);
            var person = await CreateBrokerAsync(userId, request);

            await _userAppService.CreateUserAsync(
                person.Broker.First().BrokerId,
                person.Broker.First().PersonId,
                (int)ProfileEnum.Gestor,
                request.Credencial);
        }

        private async Task<Person> CreateBrokerAsync(int userId, BrokerModel request)
        {
            var entity = new Person
            {
                Name = request.Name,
                Document = request.Document,
                PersonTypeId = request.PersonTypeId,
                Status = (int)RecordStatusEnum.Active,
                InclusionUserId = userId,
                Broker =
                [
                 new Broker
                {
                    SusepCode = request.Susep,
                    InclusionUserId = userId,
                    Status = (int)RecordStatusEnum.Active,
                }
                ],

                Address = request.Address?.Select(a => new Address
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
                }).ToList() ?? [],
                Contact = request.Contact?.Select(c => new Contact
                {
                    ContactTypeId = c.ContactTypeId,
                    ContactCategoryId = c.ContactCategoryId,
                    Value = c.Value,
                    Status = (int)RecordStatusEnum.Active,
                    InclusionUserId = userId
                }).ToList() ?? []
            };

            return await _personRepository.AddAsync(entity);
        }
    }
}
