using AutoMapper;
using NSubstitute;
using Web_API_Demo.Core.Interfaces.Repositories;
using Web_API_Demo.Web.Controllers;

namespace Web_API_Demo.Tests.Common.Builders.Controllers
{
    public class ProductControllerBuilder
    {
        public ProductControllerBuilder()
        {
            ProductRepository = Substitute.For<IProductRepository>();
            MappingEngine = Substitute.For<IMappingEngine>();
        }        
            
        public IProductRepository ProductRepository { get; private set; }
        public IMappingEngine MappingEngine { get; private set; }

        public ProductControllerBuilder WithProductRepository(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
            return this;
        }

        public ProductControllerBuilder WithMappingMappingEngine(IMappingEngine mappingEngine)
        {
            MappingEngine = mappingEngine;
            return this;
        }

        public ProductController Build()
        {
            return new ProductController(ProductRepository);
        }
    }
}
