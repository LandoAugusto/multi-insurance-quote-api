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
    public class BrokersController(IUser user, IBrokerAppService brokerAppService) : BaseController(user)
    {
        private readonly IBrokerAppService _brokerAppService = brokerAppService;

        [HttpPost]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync(BrokerModel request)
        {
            await _brokerAppService.CreateAsync(this.UserId, request);            
            return Created();
        }

        [HttpPost]
        [Route("users")]
        [ProducesResponseType(typeof(BaseDataResponseModel<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUserAsync(BrokerUserModel request)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{brokerId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BrokerOptionModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int brokerId)
        {
            var response = await _brokerAppService.GetByIdAsync(brokerId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
