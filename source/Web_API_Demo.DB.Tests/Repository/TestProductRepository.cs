using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Web_API_Demo.Core.DB;
using Web_API_Demo.Core.Domain;
using Web_API_Demo.DB.Repository;
using Web_API_Demo.Tests.Common.Domain;
using System.Data.Entity;
using System.Linq;
using Web_API_Demo.Tests.Common.Helpers;

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
        public void GetAll_GivenNoProductsSaved_ShouldReturnAnEmptyList()
        {
            //---------------Set up test pack-------------------
            var dbContext = CreateProductRepositoryDbContext();
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = repository.GetAll();
            //---------------Test Result -----------------------
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void GetAll_GivenProductExistInRepo_ShouldReturnListOfProducts()
        {
            //---------------Set up test pack-------------------
            var products = new List<Product>();
            var dbSet = CreateDbSetWithAddRemoveSupport(products);
            var dbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(dbContext);

            var product = ProductBuilder.BuildRandom();
            products.Add(product);
            dbSet.GetEnumerator().Returns(info => products.GetEnumerator());
            dbContext.Products.Returns(info => dbSet);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = repository.GetAll();
            //---------------Test Result -----------------------
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void Add_GivenProductIsNull_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var dbContext = CreateProductRepositoryDbContext();
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = Assert.Throws<ArgumentNullException>(() => repository.Add(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("product", result.ParamName);
        }

        [Test]
        public void Add_GivenProduct_ShouldSaveProductToDB()
        {
            //---------------Set up test pack-------------------
            var product = ProductBuilder.BuildRandom();
            var products = new List<Product>();

            var dbSet = CreateDbSetWithAddRemoveSupport(products);
            var productDbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(productDbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            repository.Add(product);
            //---------------Test Result -----------------------
            var productsFromRepo = repository.GetAll();
            Assert.AreEqual(1, productsFromRepo.Count);
            Assert.AreEqual(product.Id, productsFromRepo.First().Id);
            CollectionAssert.Contains(productsFromRepo, product);
        }

        [Test]
        public void Add_GivenValidProduct_ShouldCallSaveChanged()
        {
            //---------------Set up test pack-------------------
            var product = ProductBuilder.BuildRandom();
            var products = new List<Product>();
            var dbSet = CreateDbSetWithAddRemoveSupport(products);
            var dbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            repository.Add(product);
            //---------------Test Result -----------------------
            dbContext.Received().SaveChanges();
        }

        [Test]
        public void Get_GivenIdIsNull_ShouldThrowAnEsception()
        {
            //---------------Set up test pack-------------------
            var dbContext = CreateProductRepositoryDbContext();
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => repository.Get(Guid.Empty));
            //---------------Test Result -----------------------
            Assert.AreEqual("id", ex.ParamName);
        }

        [Test]
        public void Get_GivenAValidId_ShouldReturnProduct()
        {
            //---------------Set up test pack-------------------
            var product = new ProductBuilder().WithRandomProps().Build();
            var dbSet = new FakeDbSet<Product> { product };
            var dbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = repository.Get(product.Id);
            //---------------Test Result -----------------------
            Assert.AreEqual(product, result);
        }

        [Test]
        public void Remove_GivenIdIsNull_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var dbContext = CreateProductRepositoryDbContext();
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => repository.Remove(Guid.Empty));
            //---------------Test Result -----------------------
            Assert.AreEqual("id", ex.ParamName);
        }

        [Test]
        public void Remove_GivenIdIsValid_ShouldRemoveProduct()
        {
            //---------------Set up test pack-------------------
            var product = new ProductBuilder().WithRandomProps().Build();
            var dbSet = new FakeDbSet<Product> { product };
            var dbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(dbContext);        
            //---------------Assert Precondition----------------
            
            //---------------Execute Test ----------------------
            repository.Remove(product.Id);
            //---------------Test Result -----------------------
            var productFromRepo = repository.GetAll();
            CollectionAssert.DoesNotContain(productFromRepo, product);
        }

        [Test]
        public void Update_GivenInvalidProduct_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var dbContext = CreateProductRepositoryDbContext();
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => repository.Update(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("product", ex.ParamName);
        }

        [Test]
        public void Update_GivenValidProduct_ShouldReturnIndex()
        {
            //---------------Set up test pack-------------------
            var product = new ProductBuilder().WithRandomProps().Build();
            var dbSet = new FakeDbSet<Product> { product };
            var dbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = repository.Update(product);
            //---------------Test Result -----------------------
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Update_GivenValidProduct_ShouldCallSaveChanged()
        {
            //---------------Set up test pack-------------------
            var product = new ProductBuilder().WithRandomProps().Build();
            var dbSet = new FakeDbSet<Product> { product };
            var dbContext = CreateProductRepositoryDbContext(dbSet);
            var repository = CreateProductRepository(dbContext);
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var result = repository.Update(product);
            //---------------Test Result -----------------------
            dbContext.Received().SaveChanges();
        }

        public ProductRepository CreateProductRepository(IProductDbContext productDbContext)
        {
            return new ProductRepository(productDbContext);
        }

        private static IDbSet<Product> CreateDbSetWithAddRemoveSupport(List<Product> products)
        {
            var dbSet = Substitute.For<IDbSet<Product>>();

            dbSet.Add(Arg.Any<Product>()).Returns(info =>
            {
                products.Add(info.ArgAt<Product>(0));
                return info.ArgAt<Product>(0);
            });

            dbSet.Remove(Arg.Any<Product>()).Returns(info =>
            {
                products.Remove(info.ArgAt<Product>(0));
                return info.ArgAt<Product>(0);
            });

            dbSet.GetEnumerator().Returns(info => products.GetEnumerator());
            return dbSet;
        }

        private static IProductDbContext CreateProductRepositoryDbContext(IDbSet<Product> dbSet = null)
        {
            if (dbSet == null) dbSet = CreateDbSetWithAddRemoveSupport(new List<Product>());
            var productDbContext = Substitute.For<IProductDbContext>();
            productDbContext.Products.Returns(info => dbSet);
            return productDbContext;
        }
    }
}
