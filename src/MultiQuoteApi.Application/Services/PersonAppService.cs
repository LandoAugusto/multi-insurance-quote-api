using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Application.Services
{

    internal class PersonAppService(IMapper mapper, IPersonRepository personRepository)
        : IPersonAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPersonRepository _personRepository = personRepository;
        public async Task<PersonModel?> GetByDocumentAsync(int personTypeId, string document)
        {
            var entity = await _personRepository.GetByDocumentAsync(personTypeId, document.Trim());
            if (entity == null) return null;
            var response = _mapper.Map<PersonModel>(entity);

            return response;
        }


        public async Task<(int BrokerId, int PersonId)> CreateBrokerAsync(int userId, BrokerModel model)
        {
            var isExistingBroker = await _personRepository.GetByDocumentAsync(model.PersonTypeId, model.Document);
            if (isExistingBroker is not null)
            {
                throw new InvalidOperationException("Corretora já está cadastrada no sistema.");
            }

            var person = BuildPerson(userId, model);
            person.Broker =
            [
                new Broker
                {
                    SusepCode = model.Susep,
                    InclusionUserId = userId,
                    Status = (int)RecordStatusEnum.Active
                }
            ];
            var created = await _personRepository.AddAsync(person);
            return (created.Broker.First().BrokerId, created.PersonId);
        }

        public async Task<int> CreatePersonAsync(int userId, BasePersonModel model)
        {
            var isExistingBroker = await _personRepository.GetByDocumentAsync(model.PersonTypeId, model.Document);
            if (isExistingBroker is not null)
            {
                return isExistingBroker.PersonId;
            }
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

        private static Address BuildAddress(int userId, AddressModel address)
        {
            return new Address
            {
                StreetName = address.StreetName,
                Number = address.Number,
                City = address.City,
                ZipCode = address.ZipCode,
                District = address.District,
                StateId = address.StateId,
                Complement = address.Complement,
                Status = (int)RecordStatusEnum.Active,
                AddressTypeId = address.AddressTypeId,
                IsMainAddress = true,
                InclusionUserId = userId

            };
        }

        private static Contact BuildContact(int userId, ContactModel contact)
        {
            return new Contact
            {
                ContactTypeId = contact.ContactTypeId,
                ContactCategoryId = contact.ContactCategoryId,
                Value = contact.Value,
                Status = (int)RecordStatusEnum.Active,
                InclusionUserId = userId
            };
        }
    }
}
