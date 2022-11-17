using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class RequestItemMap : BaseDomainMap<RequestItem>
    {
        public RequestItemMap() : base("RequestItems")
        {
        }

        public override void Configure(EntityTypeBuilder<RequestItem> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Note)
                .HasColumnName("note")
                .HasMaxLength(500)
                .IsRequired(false);

            /* Relationship mapping between X and Y */
            builder.Property(x => x.IdRequest)
                .HasColumnName("id_request")
                .IsRequired();

            builder.Property(x => x.IdItem)
                .HasColumnName("id_item")
                .IsRequired();

            builder.HasOne(x => x.Request)
                .WithMany(x => x.RequestItems)
                .HasForeignKey(x => x.IdRequest);

            builder.HasOne(x => x.Item)
                .WithMany(x => x.RequestItems)
                .HasForeignKey(x => x.IdItem);
            /* ------------------------------------ */
        }
    }
}
