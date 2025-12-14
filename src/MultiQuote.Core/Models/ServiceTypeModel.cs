namespace MultiQuoteApi.Core.Models
{
    public class ServiceTypeModel
    {
        public required int ServiceTypeId { get; set; }
        public required string Name { get; set; }
        public List<ServiceOptionModel> Services { get; set; } = new();
    }

    public class ServiceOptionModel
    {
        public required int ServiceOptionId { get; set; }
        public required string Name { get; set; }
        public List<ServiceOptionPlanModel> Options { get; set; } = new();
    }

    public class ServiceOptionPlanModel
    {
        public required int ServiceOptionPlanId { get; set; }
        public required string Name { get; set; }

    }
}
