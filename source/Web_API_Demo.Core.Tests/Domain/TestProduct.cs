using NUnit.Framework;
using Web_API_Demo.Core.Domain;
using PeanutButter.TestUtils.Generic;
using System;

namespace Web_API_Demo.Core.Tests.Domain
{
    [TestFixture]
    public class TestProduct
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new Product());
            //---------------Test Result -----------------------
        }

        [TestCase("Id", typeof(int))]
        [TestCase("Name", typeof(string))]
        [TestCase("Type", typeof(string))]
        [TestCase("Description", typeof(string))]
        [TestCase("Price", typeof(decimal))]
        public void Type_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(Product);

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);

            //---------------Test Result -----------------------
        }
    }
}
