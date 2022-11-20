using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class ItemMap : BaseDomainMap<Item>
    {
        public ItemMap() : base("Items")
        {
        }

        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .HasDefaultValue("")
                .IsRequired(false);

            builder.Property(x => x.ImgURL)
                .HasColumnName("img_url")
                .HasDefaultValue("")
                .IsRequired(false);
        }
    }
}
