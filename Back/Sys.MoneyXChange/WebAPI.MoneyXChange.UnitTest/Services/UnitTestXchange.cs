using NUnit.Framework;
using WebAPI.MoneyXChange.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.MoneyXChange.Models;

namespace WebAPI.MoneyXChange.Services.Tests
{
    [TestFixture()]
    public class UnitTestXchange
    {
        [Test()]
        public void ExchangeCurrencyTest()
        {
            // Arrange
            var dbContext = NSubstitute.Substitute.For<StoreDBContext>();
            var obj = NSubstitute.Substitute.For<OperationService>(dbContext);

            // Act
            var result  = obj.ExchangeCurrency(DateTime.Now, 1, 2, 50);

            // Assert
            Assert.AreEqual(result,0);
        }
    }
}