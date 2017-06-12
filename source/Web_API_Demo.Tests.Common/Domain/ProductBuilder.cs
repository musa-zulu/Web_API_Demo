using PeanutButter.RandomGenerators;
using System;
using Web_API_Demo.Core.Domain;

namespace Web_API_Demo.Tests.Common.Domain
{
    public class ProductBuilder : GenericBuilder<ProductBuilder, Product>
    {
        public ProductBuilder WithId(Guid id)
        {
            return WithProp(p => p.Id = id);
        }
    }
}
