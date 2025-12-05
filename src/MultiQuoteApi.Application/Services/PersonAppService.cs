using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

namespace MultiQuoteApi.Application.Services
{

    internal class PersonAppService(IMapper mapper, IPersonRepository personRepository) : IPersonAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPersonRepository _personRepository = personRepository;
        public async Task<PersonModel?> GetByDocumentAsync(int personTypeId, string document)
        {
            var entity = await _personRepository.GetByDocumentAsync(personTypeId, document.Trim());
            if (entity == null) return null;
            var response = _mapper.Map<PersonModel>(entity);

            return response;
        }
    }
}
