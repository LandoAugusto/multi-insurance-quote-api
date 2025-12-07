using Microsoft.EntityFrameworkCore;
using MultiQuoteApi.Core.Entities;

namespace MultiQuoteApi.Infra.Data.Contexts
{
    internal class MultiQuoteDbContext(DbContextOptions<MultiQuoteDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<MenuComponent> MenuComponent { get; set; }
        public virtual DbSet<MenuProduct> MenuProduct { get; set; }
        public virtual DbSet<MenuScreen> MenuScreen { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<InsuranceBranch> InsuranceBranch { get; set; }
        public virtual DbSet<BranchType> BranchType { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Coverage> Coverage { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonType> PersonType { get; set; }        
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<DriverType> DriverType { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<ContactCategory> ContactCategory { get; set; }
        public virtual DbSet<Broker> Broker { get; set; }
        public virtual DbSet<InsuredType> InsuredType { get; set; }
        public virtual DbSet<RecordStatus> RecordStatus { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<InsuranceType> InsuranceType { get; set; }
        public virtual DbSet<Insurer> Insurer { get; set; }
        public virtual DbSet<QuotationStatus> QuotationStatus { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAcceptance> ProductAcceptance { get; set; }
        public virtual DbSet<ProductCalculationType> ProductCalculationType { get; set; }
        public virtual DbSet<ProductQuestionnaire> ProductQuestionnaire { get; set; }  
        public virtual DbSet<ProductAccessory> ProductAccessory { get; set; }
        public virtual DbSet<ProductInsurancePlanCoverageLimit> ProductInsurancePlanCoverageLimit { get; set; }
        public virtual DbSet<ProductCoverage> ProductCoverage { get; set; }
        public virtual DbSet<ProductInsurancePlan> ProductInsurancePlan { get; set; }
        public virtual DbSet<ProductInsurancePlanCoverage> ProductInsurancePlanCoverage { get; set; }
        public virtual DbSet<InsurancePlanType> InsurancePlanType { get; set; }
        public virtual DbSet<InsurancePlan> InsurancePlan { get; set; }
        public virtual DbSet<Accessory> Accessory { get; set; }
        public virtual DbSet<ComponentType> ComponentType { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Response> Response { get; set; }
        public virtual DbSet<QuestionResponse> QuestionResponse { get; set; }       
        public virtual DbSet<VehicleBrand> VehicleBrand { get; set; }
        public virtual DbSet<VehicleFuelType> VehicleFuelType { get; set; }
        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<VehicleVersion> VehicleVersion { get; set; }
        public virtual DbSet<Tracker> Tracker { get; set; }
        public virtual DbSet<AntiTheftDevice> AntiTheftDevice { get; set; }
        public virtual DbSet<VehicleYear> VehicleYear { get; set; }
       
    }
}
