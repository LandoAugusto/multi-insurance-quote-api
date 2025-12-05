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
    /// <param name="personAppService"></param>
    public class PersonsController(IUser user, IPersonAppService personAppService) : BaseController(user)
    {
        private readonly IPersonAppService _personAppService = personAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personTypeId"></param>
        /// <param name="document"></param>
        /// <returns></returns>        
        [HttpGet]
        [Route("person/{personTypeId}/{document}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<PersonModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByDocumentAsync(int personTypeId, string document)
        {
            var response = await _personAppService.GetByDocumentAsync(personTypeId, document);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
