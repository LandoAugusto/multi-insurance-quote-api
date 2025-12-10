using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiQuote.Api.Controllers.V1.Base;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Identity.Interfaces;

namespace MultiQuote.Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="productAppService"></param>
    public class ProductsController(IUser user, IProductAppService productAppService) : BaseController(user)
    {
        private readonly IProductAppService _productAppService = productAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>                
        /// <returns></returns>
        [HttpGet]
        [Route("acceptance/{productId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductAcceptanceModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAcceptanceAsync(int productId)
        {
            var response = await _productAppService.GetAcceptanceAsync(productId, base.ProfileId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>        
        /// <returns></returns>
        [HttpGet]
        [Route("calculation-type/{productId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<CalculationTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductVersionCalculationTypeAsync(int productId)
        {
            var response = await _productAppService.GetCalculationTypeAsync(productId, base.ProfileId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>        
        /// <returns></returns>        
        [HttpGet]
        [Route("questionnaire/{productId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<QuestionnaireModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuestionnaireAsync(int productId)
        {
            var response = await _productAppService.GetQuestionnaireAsync(productId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>        
        /// <returns></returns>        
        [HttpGet]
        [Route("plans/{productId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<QuestionnaireModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsurancePlanAsync(int productId)
        {
            var response = await _productAppService.GetInsurancePlanAsync(productId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>

        /// </summary>
        /// <param name="productId"></param>
        /// <param name="insurancePlanId"></param>
        /// <returns></returns>                  
        [HttpGet]
        [Route("plan-coverage-limits/{productId}/{insurancePlanId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<GroupModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsurancePlanCoverageLimitsAsync(int productId, int insurancePlanId)
        {
            var response = await _productAppService.GetInsurancePlanCoverageLimitsAsync(productId, insurancePlanId, this.ProfileId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="coverageTypeId"></param>
        /// <returns></returns>        
        [HttpGet]
        [Route("services/{productId}/{coverageTypeId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ServiceTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCoveraTypeServicesAsync(int productId, int coverageTypeId)
        {
            var response = await _productAppService.GetCoveraTypeServicesAsync(productId, coverageTypeId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
