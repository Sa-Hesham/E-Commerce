


namespace Presistance.ModelsConfigurations;


internal class ProductConfigurations : IEntityTypeConfiguration<Product>

{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(p => p.productType)
            .WithMany(x => x.products)
            .HasForeignKey(p => p.TypeId);


        builder.HasOne(p => p.productBrand)
            .WithMany(x => x.products)
            .HasForeignKey(p => p.BrandId);


        builder.Property(p => p.Name)

             .IsRequired()
             .HasColumnType("varchar")
             .HasMaxLength(100);

        builder.HasIndex(p => p.Name)
            .IsUnique();



        builder.Property(p => p.Price)
            .HasPrecision(18, 2);
            
    }
}
