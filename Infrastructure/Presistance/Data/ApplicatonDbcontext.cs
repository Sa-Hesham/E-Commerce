



namespace Presistance.Data;
public  class ApplicatonDbcontext : DbContext
{
    public ApplicatonDbcontext(DbContextOptions<ApplicatonDbcontext>options):base(options) { }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReferance).Assembly);
    }


    public DbSet<Product> products { get; set; }
    public DbSet<ProductType> productTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
}
