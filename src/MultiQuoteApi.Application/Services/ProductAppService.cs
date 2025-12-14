using AutoMapper;
using MultiQuoteApi.Application.Interfaces;
using MultiQuoteApi.Core.Entities;
using MultiQuoteApi.Core.Entities.Enumerators;
using MultiQuoteApi.Core.Extensions;
using MultiQuoteApi.Core.Models;
using MultiQuoteApi.Infra.Data.Interfaces;

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
            IProductInsurancePlanCoverageLimitRepository productInsurancePlanCoverageLimitRepository,
            IProductCoverageTypeServiceRepository productCoverageTypeServiceRepository)
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
        private readonly IProductCoverageTypeServiceRepository _productCoverageTypeServiceRepository = productCoverageTypeServiceRepository;

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
        public async Task<IEnumerable<GroupModel>?> GetInsurancePlanCoverageLimitsAsync(
                int productId, int insurancePlanId, int profileId, RecordStatusEnum recordStatus)
        {
            var entity = await _productInsurancePlanRepository
                .GetPlanAsync(productId, insurancePlanId, recordStatus);

            if (entity is null)
                return null;

            var coverages = await _productInsurancePlanCoverageRepository
                .ListAsync(entity.ProductInsurancePlanId, recordStatus);

            if (coverages is null || !coverages.Any())
                return null;

            // Agrupa apenas uma vez
            var groupedCoverages = coverages
                .GroupBy(c => c.ProductCoverage.Coverage.CoverageGroupId);

            var response = new List<GroupModel>();

            foreach (var group in groupedCoverages)
            {
                var groupName = group
                    .Select(g => g.ProductCoverage.Coverage.CoverageGroup.Name)
                    .FirstOrDefault() ?? string.Empty;

                var groupModel = new GroupModel
                {
                    CoveragaGroupId = group.Key,
                    Name = groupName
                };

                // Para cada cobertura do grupo
                foreach (var coverage in group)
                {
                    var coverageModel = new CoverageGroupModel
                    {
                        CoverageId = coverage.ProductCoverage.CoverageId,
                        Name = coverage.ProductCoverage.Coverage.Name,
                        Description = coverage.ProductCoverage.Coverage.Description
                    };

                    // Buscar limites da cobertura
                    var limit = await _productInsurancePlanCoverageLimitRepository
                        .GetAsync(coverage.ProductInsurancePlanCoverageId, profileId, recordStatus);

                    if (limit is not null)
                    {
                        coverageModel.Limit = new CoverageLimitModel
                        {
                            Amount = limit.Amount,
                            InsuredAmountValueMin = limit.InsuredAmountValueMin,
                            InsuredAmountValueMax = limit.InsuredAmountValueMax
                        };

                        // Preencher lista de valores de forma correta e elegante
                        decimal id = 1;
                        for (decimal value = limit.InsuredAmountValueMin;
                             value <= limit.InsuredAmountValueMax;
                             value += limit.Amount)
                        {
                            coverageModel.Limit.Values.Add(new ValorItem
                            {
                                Id = (int)id++,
                                Valor = value
                            });
                        }
                    }

                    groupModel.Coverages.Add(coverageModel);
                }

                response.Add(groupModel);
            }

            return response;
        }


        public async Task<IEnumerable<ServiceTypeModel>?> GetCoveraTypeServicesAsync(
             int productId, int coverageTypeId, RecordStatusEnum recordStatus)
        {
            var entity = await productCoverageTypeServiceRepository.ListAsync(productId, coverageTypeId, recordStatus);
            if (entity is null)
                return null;

            // Agrupa apenas uma vez
            var groupedServices = entity
                .GroupBy(c => c.ServiceOption.ServiceTypeId);

            var response = new List<ServiceTypeModel>();
            // Para cada tipo de serviço do grupo
            foreach (var group in groupedServices)
            {
                var groupName = group
                    .Select(g => g.ServiceOption.ServiceType.Name).Distinct()
                    .FirstOrDefault() ?? string.Empty;

                var groupModel = new ServiceTypeModel
                {
                    ServiceTypeId = group.Key,
                    Name = groupName
                };

                // Agrupa apenas uma vez
                var option = entity
                     .Where(x => x.ServiceOption.ServiceTypeId == group.Key)
                     .Select(x => new
                     {
                         x.ServiceOptionId,
                         x.ServiceOption.Name
                     })
                     .Distinct()
                     .ToList();
                // Para cada cobertura do grupo
                foreach (var service in option)
                {
                    var serviceOptionModel = new ServiceOptionModel
                    {
                        ServiceOptionId = service.ServiceOptionId,
                        Name = service.Name,
                    };

                    var plan = entity
                            .Where(x => x.ServiceOptionId == service.ServiceOptionId)
                            .Select(x => x.ServiceOptionPlan).ToList();

                    serviceOptionModel.Options = plan
                      .Select(item => new ServiceOptionPlanModel
                      {
                          ServiceOptionPlanId = item.ServiceOptionPlanId,
                          Name = item.Name
                      }).ToList();

                    groupModel.Services.Add(serviceOptionModel);

                }

                response.Add(groupModel);
            }

            return response;
        }
    }
}
