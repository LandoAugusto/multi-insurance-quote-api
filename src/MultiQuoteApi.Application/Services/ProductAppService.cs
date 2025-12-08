using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Extensions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;
using Nest;
using System.Drawing;
using static MongoDB.Driver.WriteConcern;

namespace MultiQuoteApi.Application.Services
{
    internal class ProductAppService(
            IMapper mapper,
            IProductAcceptanceRepository productAcceptanceRepository,
            IProductCalculationTypeRepository productCalculationTypeRepository,
            IProductQuestionnaireRepository productQuestionnaireRepository,
            IQuestionResponseRepository questionResponseRepository,
            IProductInsurancePlanRepository productInsurancePlanRepository,
            IProductInsurancePlanCoverageRepository productInsurancePlanCoverageRepository,
            IProductInsurancePlanCoverageLimitRepository productInsurancePlanCoverageLimitRepository)
        : IProductAppService
    {

        private readonly IMapper _mapper = mapper;
        private readonly IProductAcceptanceRepository _productAcceptanceRepository = productAcceptanceRepository;
        private readonly IProductCalculationTypeRepository _productCalculationTypeRepository = productCalculationTypeRepository;
        private readonly IProductQuestionnaireRepository _productQuestionnaireRepository = productQuestionnaireRepository;
        private readonly IQuestionResponseRepository _questionResponseRepository = questionResponseRepository;
        private readonly IProductInsurancePlanRepository _productInsurancePlanRepository = productInsurancePlanRepository;
        private readonly IProductInsurancePlanCoverageRepository _productInsurancePlanCoverageRepository = productInsurancePlanCoverageRepository;
        private readonly IProductInsurancePlanCoverageLimitRepository _productInsurancePlanCoverageLimitRepository = productInsurancePlanCoverageLimitRepository;

        public async Task<ProductAcceptanceModel?> GetAcceptanceAsync(int productVersionId, int profileId, RecordStatusEnum recordStatus)
        {
            var productVersionAcceptance = await _productAcceptanceRepository.GetAsync(productVersionId, profileId, recordStatus);
            if (productVersionAcceptance == null) return null;

            var response = _mapper.Map<ProductAcceptanceModel>(productVersionAcceptance);
            response.Name = productVersionAcceptance.Product?.Name ?? string.Empty;
            response.InsuranceBranch = productVersionAcceptance.Product?.InsuranceBranch.Name ?? string.Empty;

            return response;
        }


        public async Task<IEnumerable<CalculationTypeModel>?> GetCalculationTypeAsync(int productId, int profileId, RecordStatusEnum recordStatus)
        {
            var entity = await _productCalculationTypeRepository.ListAsync(productId, profileId, recordStatus);
            if (!entity.IsAny<ProductCalculationType>()) return null;

            return [.. entity.ToList().Select(item =>
            {
                return _mapper.Map<CalculationTypeModel>(item.CalculationType);
            })];
        }

        public async Task<IEnumerable<InsurancePlanOptionModel>?> GetInsurancePlanAsync(int productId, RecordStatusEnum recordStatus)
        {
            var entity = await _productInsurancePlanRepository.GetAsync(productId, recordStatus);
            if (!entity.IsAny<ProductInsurancePlan>()) return null;

            return [.. entity.ToList().Select(item =>
            {
                return _mapper.Map<InsurancePlanOptionModel>(item.InsurancePlan);
            })];
        }

        public async Task<IEnumerable<QuestionnaireModel>?> GetQuestionnaireAsync(int producId, RecordStatusEnum recordStatus)
        {
            var entity = await _productQuestionnaireRepository.GetAsync(producId, recordStatus);
            if (entity is null) return null;

            var questionnaire = entity.ToList().Select(item =>
            {
                return _mapper.Map<QuestionnaireModel>(item?.Question);
            }).ToList();

            foreach (var item in questionnaire)
            {
                if (item is null) continue;
                var questionResponse = await _questionResponseRepository.GetAsync(item.QuestionId, recordStatus);
                if (questionResponse is not null)
                {
                    var response = questionResponse.ToList().Select(item =>
                    {
                        return _mapper.Map<ResponseModel>(item?.Response);
                    }).ToList();

                    item?.Response?.AddRange(response);
                }
            }

            return questionnaire;
        }
        public async Task<IEnumerable<InsurancePlanCoverageModel>?> GetInsurancePlanCoverageLimitsAsync(int productId, int insurancePlanId, int profileId, RecordStatusEnum recordStatus)
        {
            var entity = await _productInsurancePlanRepository.GetPlanAsync(productId, insurancePlanId, recordStatus);
            if (entity == null) return null;

            var insurancePlanCoverage = await _productInsurancePlanCoverageRepository.ListAsync(entity.ProductInsurancePlanId, recordStatus);

            if (!insurancePlanCoverage.IsAny<ProductInsurancePlanCoverage>()) return null;

            var response = new List<InsurancePlanCoverageModel>();

            foreach (var item in insurancePlanCoverage)
            {
                var newInsurancePlanCoverageModel = new InsurancePlanCoverageModel()
                {
                    CoverageId = item.ProductCoverage.CoverageId,
                    Description = item.ProductCoverage.Coverage.Description,
                    Name = item.ProductCoverage.Coverage.Name,
                    CoveragaGroupId = item.ProductCoverage.Coverage.CoverageGroupId   
                };

                var limits = await _productInsurancePlanCoverageLimitRepository.GetAsync(item.ProductInsurancePlanCoverageId, profileId, recordStatus);

                newInsurancePlanCoverageModel.Limit = new CoverageLimitModel
                {
                    Amount = limits.Amount,
                    InsuredAmountValueMax = limits.InsuredAmountValueMax,
                    InsuredAmountValueMin = limits.InsuredAmountValueMin
                };

                decimal incremento = limits.Amount;
                int id = 1;

                for (decimal valor = limits.InsuredAmountValueMin;
                     valor <= limits.InsuredAmountValueMax;
                     valor += incremento)
                {
                    newInsurancePlanCoverageModel.Limit.Values. Add(new ValorItem
                    {
                        Id = id++,
                        Valor = valor
                    });
                }
                response.Add(newInsurancePlanCoverageModel);
            }
            return response;
        }
    }
}
