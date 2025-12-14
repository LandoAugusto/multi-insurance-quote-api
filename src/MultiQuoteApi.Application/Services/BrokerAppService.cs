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
        IPersonAppService personAppService,
        IUserAppService userAppService) : IBrokerAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBrokerRepository _brokerRepository = brokerRepository;
        private readonly IPersonAppService _personAppService = personAppService;
        private readonly IUserAppService _userAppService = userAppService;


        public async Task<BrokerDetailsModel?> GetDetailsByIdAsync(int brokerId, RecordStatusEnum recordStatus)
        {
            var entity = await _brokerRepository.GetDetailsByIdAsync(brokerId, recordStatus);

            if (entity?.Person is null)
                return null;

            return new BrokerDetailsModel
            {
                BrokerId = entity.BrokerId,
                SusepCode = entity.SusepCode,
                PersonId = entity.PersonId,
                Name = entity.Person.Name,
                PersonTypeId = entity.Person.PersonTypeId,
                Document = entity.Person.Document,

                Address = entity.Person.Address is null
                    ? Enumerable.Empty<AddressModel>()
                    : _mapper.Map<IEnumerable<AddressModel>>(entity.Person.Address),

                Contact = entity.Person.Contact is null
                    ? Enumerable.Empty<ContactModel>()
                    : _mapper.Map<IEnumerable<ContactModel>>(entity.Person.Contact)
            };
        }

        public async Task<BrokerOptionModel?> GetByIdAsync(int brokerId, RecordStatusEnum recordStatus)
        {
            var entity = await _brokerRepository.GetByIdAsync(brokerId, recordStatus);
            return entity is null ? null : _mapper.Map<BrokerOptionModel>(entity);
        }
        public async Task CreateAsync(BrokerModel request)
        {
            const int systemUserId = 99;
            await _userAppService.ValidateUserAsync(request.Credencial.Login);

            var (brokerId, personId) = await _personAppService.CreateBrokerAsync(systemUserId, request);

            await _userAppService.CreateUserAsync(new UserPersonModel
            {
                BrokerId = brokerId,
                PersonId = personId,
                ProfileId = (int)ProfileEnum.Gestor,
                RoleId = (int)ProfileEnum.Gestor,
                IsDefault = true,
                InclusionUserId = systemUserId,
                Credencial = request.Credencial
            });
        }
        public async Task CreateUserAsync(int userId, int brokerId, BrokerUserModel request)
        {
            await _userAppService.ValidateUserAsync(request.Credencial.Login);

            var personId = await _personAppService.CreatePersonAsync(userId, request);

            await _userAppService.CreateUserAsync(new UserPersonModel
            {
                BrokerId = brokerId,
                PersonId = personId,
                ProfileId = request.ProfileId,
                RoleId = request.ProfileId,
                IsDefault = false,
                InclusionUserId = userId,
                Credencial = request.Credencial
            });
        }       
    }
}
