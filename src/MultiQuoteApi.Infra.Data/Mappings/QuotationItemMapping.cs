using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiQuoteApi.Core.Entities;

namespace MultiQuoteApi.Infra.Data.Mappings
{
    internal class QuotationItemMapping : IEntityTypeConfiguration<QuotationItem>
    {
        public void Configure(EntityTypeBuilder<QuotationItem> builder)
        {
            builder
                .HasOne(i => i.Auto)
                .WithOne(a => a.QuotationItem)
                .HasForeignKey<QuotationItemAuto>(a => a.QuotationItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(i => i.Driver)
               .WithOne(a => a.QuotationItem)
               .HasForeignKey<QuotationDriver>(a => a.QuotationItemId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
