using System.Data.Entity;
using Web_API_Demo.Core.DB.Mapping;
using Web_API_Demo.Core.Domain;

namespace Web_API_Demo.Core.DB
{
    public interface IProductDbContext
    {
        IDbSet<Product> Products { get; set; }
        int SaveChanges();
    }
    public class ProductDbContext : DbContext, IProductDbContext
    {
        static ProductDbContext()
        {
            Database.SetInitializer<ProductDbContext>(null);
        }

        public ProductDbContext(string nameOrConnectionString = null)
            : base(nameOrConnectionString ?? "Name=ProductDbContext")
        {
            // Data Source=MUSA;Initial Catalog=Web_API_Demo;User ID=sa
        }

        public IDbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Configurations;
            config.Add(new ProductMap());            
        }
    }
}
