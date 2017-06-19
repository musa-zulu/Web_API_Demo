using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Web_API_Demo.Core.Domain;
using Web_API_Demo.Core.Interfaces.Repositories;
using Web_API_Demo.Tests.Common.Builders.Controllers;
using Web_API_Demo.Web.Controllers;

namespace Web_API_Demo.Web.Tests.Controllers
{
    [TestFixture]
    class TestProductController
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new ProductController(Substitute.For<IProductRepository>()));
            //---------------Test Result -----------------------
        }

        [Test]
        public void Construct_GivenIProductRepositoryIsNull_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => new ProductController(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("productRepository", ex.ParamName);
        }

        [Test]
        public void GetAllProducts_ShouldHaveHttpGetAttribute()
        {
            //---------------Set up test pack-------------------
            var methodInfo = typeof(ProductController).GetMethod("GetAllProducts");
            //---------------Assert Precondition----------------
            Assert.IsNotNull(methodInfo);
            //---------------Execute Test ----------------------
            var httpGettAttribute = methodInfo.GetCustomAttribute<HttpGetAttribute>();
            //---------------Test Result -----------------------
            Assert.NotNull(httpGettAttribute);
        }

        [Test]
        public void GetAllProducts_GivenNoProductInRepo_ShouldReturnAnEmptyList()
        {
            //---------------Set up test pack-------------------
            var productRepo = Substitute.For<IProductRepository>();
            productRepo.GetAll().Returns(new List<Product>());
            var controller = new ProductController(productRepo);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = controller.GetAllProducts();
            //---------------Test Result -----------------------
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void GetAllProducts_ShouldCallGetAllFromRepo()
        {
            //---------------Set up test pack-------------------
            var productRepo = Substitute.For<IProductRepository>();
            var controller = new ProductController(productRepo);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = controller.GetAllProducts();
            //---------------Test Result -----------------------
            productRepo.Received().GetAll();
        }
        private static ProductControllerBuilder CreateProductControllerBuilder()
        {
            return new ProductControllerBuilder();
        }
    }
}
