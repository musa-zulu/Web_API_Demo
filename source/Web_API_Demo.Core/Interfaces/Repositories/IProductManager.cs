using System.Collections.Generic;
using Web_API_Demo.Core.Domain;

namespace Web_API_Demo.Core.Interfaces.Repositories
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product product);
        void Remove(int id);
        bool Update(Product product);
    }
}
