

namespace Presistance.ModelsConfigurations;
internal class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.Property(p => p.Name)
             .IsRequired()
             .HasColumnType("varchar")
            .HasMaxLength(100);
    }
}
