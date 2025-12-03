using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MultiQuote.Api.Controllers.V1.Base;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Identity.Interfaces;

namespace MultiQuote.Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="commonAppService"></param>
    public class CommonsController(IUser user, ICommonAppService commonAppService) : BaseController(user)
    {

        private readonly ICommonAppService _commonAppService = commonAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("active")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ActiveModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicBodyAsync()
        {
            var response = await _commonAppService.GetActiveAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("zipCode/{zipCode}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ZipCodeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetZipCodelAsync(string zipCode)
        {
            var response = await _commonAppService.GetZipCodeAsync(zipCode);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("state")]
        [ProducesResponseType(typeof(BaseDataResponseModel<StateModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStateAllAsync(string? stateId = null)
        {
            var response = await _commonAppService.GetStateAsync(RecordStatusEnum.Active, stateId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("address-types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<AddressTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddressTypeAsync()
        {
            var response = await _commonAppService.GetAddressTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("driver-types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<DriverTypeOptionModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDriveTypeAsync()
        {
            var response = await _commonAppService.GetDriverTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insured-types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<InsuredTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuredTypeModelAsync()
        {
            var response = await _commonAppService.GetInsuredTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("record-status")]
        [ProducesResponseType(typeof(BaseDataResponseModel<RecordStatusModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRecordStatusAsync()
        {
            var response = await _commonAppService.GetRecordStatusAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insurance-types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<InsuranceTypeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuranceTypeAsync()
        {
            var response = await _commonAppService.GetInsuranceTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("insurer")]
        [ProducesResponseType(typeof(BaseDataResponseModel<InsurerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsurerAsync()
        {
            var response = await _commonAppService.GetInsurerAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("person-types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PersonTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonTypeAsync()
        {
            var response = await _commonAppService.GetPersonTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("quotation-status")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<QuotationStatusModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuotationStatusAsync()
        {
            var response = await _commonAppService.GetQuotationStatusAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("gender")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<GenderOptionModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGenderAsync()
        {
            var response = await _commonAppService.GetGenderAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("profession-by-name")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ProfessionModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProfessionAsync(string? name)
        {
            var response = await _commonAppService.GetProfessionAsync(name, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <returns></returns>
        [HttpGet]
        [Route("martial-status")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<MaritalStatusModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMartialStatusAsync()
        {
            var response = await _commonAppService.GetMartialStatusAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
