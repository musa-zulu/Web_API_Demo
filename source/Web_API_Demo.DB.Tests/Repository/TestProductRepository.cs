using NSubstitute;
using NUnit.Framework;
using System;
using Web_API_Demo.Core.DB;
using Web_API_Demo.Core.Domain;
using Web_API_Demo.DB.Repository;
using Web_API_Demo.Tests.Common.Domain;

namespace Web_API_Demo.DB.Tests.Repository
{
    [TestFixture]
    public class TestProductRepository
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => CreateProductRepository(Substitute.For<IProductDbContext>()));
            //---------------Test Result -----------------------
        }

        [Test]
        public void Contruct_GivenIProductDbContextIsNull_ShouldThrowException()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => CreateProductRepository(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("productDbContext", ex.ParamName);
        }

        [Test]
        public void Add_GivenProductIsNull_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var dbContext = Substitute.For<IProductDbContext>();
            var repository = new ProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = Assert.Throws<ArgumentNullException>(()=>repository.Add(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("product",result.ParamName);
        }

       

        public ProductRepository CreateProductRepository(IProductDbContext productDbContext)
        {
            return new ProductRepository(productDbContext);
        }
    }
}
