using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiQuote.Api.Controllers.V1.Base;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Identity.Interfaces;

namespace MultiQuote.Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="quotationAppService"></param>
    public class QuotationsController(IUser user, IQuotationAppService quotationAppService) : BaseController(user)
    {

        private readonly IQuotationAppService _quotationAppService = quotationAppService;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("auto")]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatedAsync(QuotationModel request)
        {
            await _quotationAppService.CreatedAsync(this.UserId, request);
            return Created();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("calculates-validity")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CalculateValidityModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CalculateValidityAsync(CalculateValidityFilterModel request)
        {
            var response = await _quotationAppService.CalculateValidityAsync(base.ProfileId, request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("quotes")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CalculateValidityModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuotesAsync(CalculateValidityFilterModel request)
        {
            var response = await _quotationAppService.CalculateValidityAsync(base.ProfileId, request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
