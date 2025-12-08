using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    /// <param name="coverageAppService"></param>
    public class CoveragesController(IUser user, ICoverageAppService coverageAppService) : BaseController(user)
    {
        private readonly ICoverageAppService _coverageAppService = coverageAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>       
        [HttpGet]
        [Route("types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<CoverageTypeOption>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTypes()
        {
            var response = await _coverageAppService.GetTypesAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="coverageTypeId"></param>
        /// <returns></returns>        
        [HttpGet]
        [Route("franchise-types/{coverageTypeId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<FranchiseTypeOption>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFranchiseTypeAsync(int coverageTypeId)
        {
            var response = await _coverageAppService.GetFranchiseTypeAsync(coverageTypeId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coverageTypeId"></param>
        /// <param name="franchiseTypeId"></param>
        /// <returns></returns>        
        [HttpGet]
        [Route("franchise-percentage/{coverageTypeId}/{franchiseTypeId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<FranchiseTypePercentageOption>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFranchisePercentageAsync(int coverageTypeId, int franchiseTypeId)
        {
            var response = await _coverageAppService.GetFranchisePercentageAsync(coverageTypeId, franchiseTypeId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
