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
    /// <param name="vehicleAppService"></param>
    public class VehiclesController(IUser user, IVehicleAppService vehicleAppService)
        : BaseController(user)
    {
        private readonly IVehicleAppService _vehicleAppService = vehicleAppService;

        /// <summary>         
        [HttpGet]
        [Route("brand/{name}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleBrandModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBrandAsync(string name)
        {
            var response = await _vehicleAppService.GetBrandAsync(name, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleBranchId"></param>
        /// <param name="name"></param>
        /// <returns></returns>         
        [HttpGet]
        [Route("model/{vehicleBranchId}/{name}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleModelModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModelAsync(int vehicleBranchId, string? name)
        {
            var response = await _vehicleAppService.GetModelAsync(vehicleBranchId, name, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleModelId"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("version/{vehicleModelId}/{name}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleVersionModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVersionAsync(int vehicleModelId, string? name)
        {
            var response = await _vehicleAppService.GetVersionAsync(vehicleModelId, name, RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>                
        /// <returns></returns>        
        [HttpGet]
        [Route("year")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleYearModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetYearAsync()
        {
            var response = await _vehicleAppService.GetYearAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        // <summary>
        /// 
        /// </summary>                
        /// <returns></returns>         
        [HttpGet]
        [Route("fuel-types")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleFuelTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFuelTypeAsync()
        {
            var response = await _vehicleAppService.GetFuelTypeAsync(RecordStatusEnum.Active);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
