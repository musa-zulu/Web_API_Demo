using System;
using System.Collections.Generic;
using System.Web.Http;
using Web_API_Demo.Core.Domain;
using Web_API_Demo.Core.Interfaces.Repositories;

namespace Web_API_Demo.Web.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            if (productRepository == null) throw new ArgumentNullException(nameof(productRepository));
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }
    }
}
