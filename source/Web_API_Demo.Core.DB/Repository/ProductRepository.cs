using System;
using System.Collections.Generic;
using System.Linq;
using Web_API_Demo.Core.DB;
using Web_API_Demo.Core.Domain;
using Web_API_Demo.Core.Interfaces.Repositories;

namespace Web_API_Demo.DB.Repository
{
    public class ProductRepository : IProductManager
    {
        private readonly IProductDbContext _productDbContext;

        public ProductRepository(IProductDbContext productDbContext)
        {
            if (productDbContext == null)
                throw new ArgumentNullException("productDbContext");
            this._productDbContext = productDbContext;
        }

        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
        }

        public Product Get(Guid? id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
            return _productDbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            return _productDbContext.Products.ToList();
        }

        public void Remove(Guid? id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
            var product = _productDbContext.Products.FirstOrDefault(x => x.Id == id);
            _productDbContext.Products.Remove(product);
        }

        public bool Update(Product product)
        {
            var isUpdated = false;
            if (product == null) throw new ArgumentNullException(nameof(product));
            var originalProduct = _productDbContext.Products.FirstOrDefault(x => x.Id == product.Id);
            if (originalProduct != null)
            {
                originalProduct.Description = product.Description;
                originalProduct.Name = product.Name;
                originalProduct.Price = product.Price;
                originalProduct.Type = product.Type;               
                _productDbContext.SaveChanges();
                isUpdated = true;
            }
            return isUpdated;
        }
    }
}
