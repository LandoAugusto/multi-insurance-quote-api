using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Extensions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;
using MultiQuoteApi.Service.Client.Interfaces;

namespace MultiQuoteApi.Application.Services
{
    internal class CommonAppService(IMapper mapper, IInsuredTypeRepository insuredTypeRepository,
       IAddressTypeRepository addressTypeRepository, IStateRepository stateRepository, IRecordStatusRepository recordStatusRepository,
       IInsuranceTypeRepository insuranceTypeRepository, IInsurerRepository insurerRepository,
       IPersonTypeRepository personTypeRepository, IQuotationStatusRepository quotationStatusRepository,
       IGenderRepository genderRepository, IProfessionRepository professionRepository, IMaritalStatusRepository maritalStatusRepository,
       IZipCodeService zipCodeService, IDriverTypeRepository driverTypeRepository)
     : ICommonAppService
    {

        private readonly IMapper _mapper = mapper;
        private readonly IZipCodeService _zipCodeService = zipCodeService;
        private readonly IGenderRepository _genderRepository = genderRepository;
        private readonly IStateRepository _stateRepository = stateRepository;
        private readonly IAddressTypeRepository _addressTypeRepository = addressTypeRepository;        
        private readonly IInsuredTypeRepository _insuredTypeRepository = insuredTypeRepository;
        private readonly IRecordStatusRepository _recordStatusRepository = recordStatusRepository;
        private readonly IInsuranceTypeRepository _insuranceTypeRepository = insuranceTypeRepository;
        private readonly IInsurerRepository _insurerRepository = insurerRepository;
        private readonly IPersonTypeRepository _personTypeRepository = personTypeRepository;
        private readonly IQuotationStatusRepository _quotationStatusRepository = quotationStatusRepository;
        private readonly IProfessionRepository _professionRepository = professionRepository;
        private readonly IMaritalStatusRepository _maritalStatusRepository = maritalStatusRepository;
        private readonly IDriverTypeRepository _driverTypeRepository = driverTypeRepository;

        public Task<IEnumerable<ActiveModel>> GetActiveAsync()
        {
            var response = new List<ActiveModel>() {

                new()
                {
                    ActiveId= 1,
                    Name = "SIM",
                },
                new()
                {
                    ActiveId= 0,
                    Name = "NÂO",
                }
            };

            return Task.FromResult<IEnumerable<ActiveModel>>(response);
        }
        public async Task<ZipCodeModel?> GetZipCodeAsync(string zipCode)
        {
            var response = await _zipCodeService.GetAsync(zipCode);
            if (response == null) return null;

            var state = await GetStateAsync(RecordStatusEnum.Active, response.StateUf);
            if (!state.Any())
            {
                return new ZipCodeModel();
            }

            return new ZipCodeModel()
            {
                ZipCode = response.ZipCode,
                City = response.City,
                Complement = response.Complement,
                District = response.District,
                State = response.State,                
                StreetName = response.StreetName,
                StateId = state.First().StateId
            };
        }

        public async Task<IEnumerable<DriverTypeOptionModel>?> GetDriverTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var entity = await _driverTypeRepository.ListAsync(recordStatusEnum);
            if (!entity.IsAny<DriverType>()) return null;

            return _mapper.Map<IEnumerable<DriverTypeOptionModel>>(entity);
        }
        public async Task<IEnumerable<AddressTypeModel>?> GetAddressTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var entity = await _addressTypeRepository.ListAsync(recordStatusEnum);
            if (!entity.IsAny<AddressType>()) return null;

            return _mapper.Map<IEnumerable<AddressTypeModel>>(entity);
        }
       
        public async Task<IEnumerable<InsuredTypeModel>?> GetInsuredTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var entity = await _insuredTypeRepository.ListAsync(recordStatusEnum);
            if (!entity.IsAny<InsuredType>()) return null;

            return _mapper.Map<IEnumerable<InsuredTypeModel>>(entity);
        }

        public async Task<IEnumerable<StateModel>?> GetStateAsync(RecordStatusEnum recordStatusEnum, string? stateId = null)
        {
            var entity = await _stateRepository.ListAsync(recordStatusEnum, stateId);
            if (!entity.IsAny<State>()) return null;

            return _mapper.Map<IEnumerable<StateModel>>(entity);
        }

        public async Task<IEnumerable<RecordStatusModel>?> GetRecordStatusAsync()
        {
            var entity = await _recordStatusRepository.GetAllAsync();
            if (!entity.IsAny<RecordStatus>()) return null;

            return _mapper.Map<IEnumerable<RecordStatusModel>>(entity);
        }


        public async Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _insuranceTypeRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<InsuranceType>()) return null;

            return _mapper.Map<IEnumerable<InsuranceTypeModel>>(entity);
        }
        public async Task<IEnumerable<InsurerModel>?> GetInsurerAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _insurerRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<Insurer>()) return null;

            return _mapper.Map<IEnumerable<InsurerModel>>(entity);
        }

        public async Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _personTypeRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<PersonType>()) return null;

            return _mapper.Map<IEnumerable<PersonTypeModel>>(entity);
        }
        public async Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _quotationStatusRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<QuotationStatus>()) return null;

            return _mapper.Map<IEnumerable<QuotationStatusModel>>(entity);
        }

        public async Task<IEnumerable<GenderOptionModel>?> GetGenderAsync(RecordStatusEnum recordStatus)
        {
            var entities = await _genderRepository.ListAsync(recordStatus);
            if (entities is null || !entities.Any())
                return null;

            return _mapper.Map<IEnumerable<GenderOptionModel>>(entities);
        }
        public async Task<IEnumerable<ProfessionModel>?> GetProfessionAsync(string? name, RecordStatusEnum recordStatus)
        {
            var entity = await _professionRepository.ListAsync(name, recordStatus);
            if (!entity.IsAny<Profession>()) return null;

            return _mapper.Map<IEnumerable<ProfessionModel>>(entity);
        }

        public async Task<IEnumerable<MaritalStatusModel>?> GetMartialStatusAsync(RecordStatusEnum recordStatus)
        {
            var entity = await _maritalStatusRepository.GetAllAsync(recordStatus);
            if (!entity.IsAny<MaritalStatus>()) return null;

            return _mapper.Map<IEnumerable<MaritalStatusModel>>(entity);
        }
    }
}
