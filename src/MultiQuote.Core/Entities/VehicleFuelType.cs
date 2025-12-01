using MultiQuoteApi.Core.Entities.Interfaces;

namespace MultiQuoteApi.Core.Entities
{
    public  class VehicleFuelType : IIdentityEntity
    {
        public int VehicleFuelTypeId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
