using System;
using System.Collections.Generic;
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

        public Product Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            return null;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
