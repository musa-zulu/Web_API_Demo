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

        public Product Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _productDbContext.Products.ToList();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
