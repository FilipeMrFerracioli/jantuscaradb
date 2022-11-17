using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class RequestMap : BaseDomainMap<Request>
    {
        public RequestMap() : base("Requests")
        {
        }

        public override void Configure(EntityTypeBuilder<Request> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Tip)
                .HasColumnName("tip")
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasColumnName("discount")
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("amount")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            /* Relationship mapping between X and Y */
            builder.Property(x => x.IdCustomer)
                .HasColumnName("id_customer")
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.IdCustomer);
            /* ------------------------------------ */
        }
    }
}
