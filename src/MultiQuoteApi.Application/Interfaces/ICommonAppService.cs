using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Interfaces
{
    public interface ICommonAppService
    {
        Task<IEnumerable<DriverTypeOptionModel>?> GetDriverTypeAsync(RecordStatusEnum recordStatusEnum);
        Task<IEnumerable<ActiveModel>> GetActiveAsync();
        Task<ZipCodeModel?> GetZipCodeAsync(string zipCode);
        Task<IEnumerable<RecordStatusModel>?> GetRecordStatusAsync();
        Task<IEnumerable<StateModel>?> GetStateAsync(RecordStatusEnum recordStatusEnum, string? stateId = null);
        Task<IEnumerable<AddressTypeModel>?> GetAddressTypeAsync(RecordStatusEnum recordStatusEnum);        
        Task<IEnumerable<InsuredTypeModel>?> GetInsuredTypeAsync(RecordStatusEnum recordStatusEnum);
        Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<InsurerModel>?> GetInsurerAsync(RecordStatusEnum recordStatus);                    
        Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<GenderOptionModel>?> GetGenderAsync(RecordStatusEnum recordStatus);
        Task<IEnumerable<ProfessionModel>?> GetProfessionAsync(string? name, RecordStatusEnum recordStatus);
        Task<IEnumerable<MaritalStatusModel>?> GetMartialStatusAsync(RecordStatusEnum recordStatus);
    }
}
