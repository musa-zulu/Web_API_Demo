using Web_API_Demo.Core.Domain;
using System.Data.Entity.ModelConfiguration;
using ProductTable = Web_API_Demo.DB.DBConstants.Tables.ProductTable;
namespace Web_API_Demo.Core.DB.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(p => p.Id);

            ToTable(ProductTable.TableName);
            Property(p => p.Id).HasColumnName(ProductTable.Columns.Id);
            Property(p => p.Name).HasColumnName(ProductTable.Columns.Name);
            Property(p => p.Type).HasColumnName(ProductTable.Columns.Type);
            Property(p => p.Description).HasColumnName(ProductTable.Columns.Description);
            Property(p => p.Price).HasColumnName(ProductTable.Columns.Price);            
        }
    }
}
