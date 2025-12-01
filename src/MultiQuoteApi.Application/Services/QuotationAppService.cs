using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Infrastructure.Exceptions;
using MultiQuoteApi.Core.Models;

namespace MultiQuoteApi.Application.Services
{
    internal class QuotationAppService(IProductAppService productAppService) : IQuotationAppService
    {
        private readonly IProductAppService _productAppService = productAppService;
        public async Task<CalculateValidityModel> CalculateValidityAsync(int profileId, CalculateValidityFilterModel request)
        {
            //var calculationTypeAcceptance = await _productVersionAppService.GetCalculationTypeAcceptanceAsync(request.ProductVersionId, request.ProfileId, request.CalculationTypeId)
            //    ?? throw new NotFoundException("Não foi possivel localizar o tipo de calculo.");

            var productAcceptance = await _productAppService.GetAcceptanceAsync(request.ProductId, profileId, RecordStatusEnum.Active)
                ?? throw new NotFoundException("Não foi possivel localizar a versão alçada do produto.");

            var startCoverage = request.StartCoverage ?? DateTime.Now;
            if (startCoverage.Date < DateTime.Now.Date)
            {
                var differenceInDays = (DateTime.Now.Date - startCoverage.Date).TotalDays;
                if (differenceInDays > productAcceptance.RetroactiveEffectiveDateStartDays)
                {
                    throw new BusinessException($"A quantidade maxima de dias para vigência retroativa é de {productAcceptance.RetroactiveEffectiveDateStartDays}");
                }
            }

            if (startCoverage.Date > DateTime.Now.Date)
            {
                var differenceInDays = (startCoverage.Date - DateTime.Now.Date).TotalDays;
                if (differenceInDays > productAcceptance.LaterEffectiveDateStartDays)
                {
                    throw new BusinessException($"A quantidade maxima de dias para vigência futuro é de {productAcceptance.LaterEffectiveDateStartDays}");
                }
            }

            var response = new CalculateValidityModel()
            {
                StartCoverage = startCoverage,
                //CountDaysEnable = calculationTypeAcceptance.IsCountDays
            };

            if (request.CountDays != null)
            {
                //var isValido = (request.CountDays >= calculationTypeAcceptance.CountDayMin && request.CountDays <= calculationTypeAcceptance.CountDayMax);
                //if (!isValido)
                //{
                //    throw new BusinessException($"Quantidade de dias para o Tipo de Cálculo  escolhido não pode ser menor que {calculationTypeAcceptance.CountDayMin} dias e nem maior que {calculationTypeAcceptance.CountDayMax}.");
                //}
                //response.CountDays = request.CountDays.Value;
                //response.EndCoverage = response.StartCoverage.AddDays(request.CountDays.Value);
            }
            else
            {
                //response.CountDays = calculationTypeAcceptance.CountDayMax;
                //response.EndCoverage = response.StartCoverage.AddDays(calculationTypeAcceptance.CountDayMax);

                response.CountDays = 365;
                response.EndCoverage = response.StartCoverage.AddDays(365);

            }

            return response;
        }
    }
}
