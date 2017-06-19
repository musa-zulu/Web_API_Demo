using System;
using System.Collections.Generic;
using Web_API_Demo.Core.Domain;

namespace Web_API_Demo.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(Guid? id);
        void Add(Product product);
        void Remove(Guid? id);
        bool Update(Product product);
    }
}
