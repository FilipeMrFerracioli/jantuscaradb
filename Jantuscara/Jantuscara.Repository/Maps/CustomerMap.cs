using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class CustomerMap : BaseDomainMap<Customer>
    {
        public CustomerMap() : base("Customers")
        {
        }

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Document)
                .HasColumnName("document")
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}
