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
    /// <param name="branchAppService"></param>
    public class BranchController(IUser user, IBranchAppService branchAppService) : BaseController(user)
    {

        private readonly IBranchAppService _branchAppService = branchAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [Route("types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BranchTypeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBranchTypeAsync()
        {
            var response = await _branchAppService.ListBranchTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [Route("branchs")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BranchModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBranchAsync(int? brachTypeId)
        {
            var response = await _branchAppService.ListBranchAsync(brachTypeId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insurance-branchs")]
        [ProducesResponseType(typeof(BaseDataResponseModel<InsuranceBranchModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListInsuranceBranchAsync(int? brachId)
        {
            var response = await _branchAppService.ListInsuranceBranchAsync(brachId, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
