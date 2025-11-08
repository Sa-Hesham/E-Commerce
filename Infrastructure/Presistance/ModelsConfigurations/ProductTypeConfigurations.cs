using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.ModelsConfigurations;
internal class ProductTypeConfigurations : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(p => p.Name)
             .IsRequired()
             .HasColumnType("varchar")
            .HasMaxLength(100);
    }
}
