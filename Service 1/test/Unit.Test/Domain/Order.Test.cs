using Domain.Entities.Tables;
using Domain.Exceptions;
using Domain.Model;
using Unit.Test.TestData;
using Xunit;

namespace Unit.Test.Domain
{
    public class OrderTest:IClassFixture<OrderFixture>
    {
        private readonly OrderFixture _orderFixture;

        public OrderTest(OrderFixture orderFixture)
        {
            this._orderFixture = orderFixture;
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void OrderId_MustBeNotNull()
        {
            //Arrange

            //Act
            var fakeOrder = _orderFixture.Order;

            //Assert
            Assert.NotNull(fakeOrder.OrderId);
        }


        [Fact]
        [Trait("Category", "UnitTest")]
        public void ProductId_MustBeNotNull()
        {
            //Arrange

            //Act
            var fakeOrder = _orderFixture.Order;

            //Assert
            Assert.NotNull(fakeOrder.Product.ProductId);
        }

        [Trait("Category", "UnitTest")]
        [Theory]
        //[InlineData(30, true)]
        //[InlineData(-30, false)]
        //[MemberData(nameof(OrderTestData.QuantityTestData), MemberType = typeof(OrderTestData))]
        //[MemberData(nameof(OrderTestData.QuantityTestExternalData), MemberType = typeof(OrderTestData))]
        [OrderTestDataAttribute]
        public void Is_Positive_or_Negative_Quantity(decimal quantity, bool expected)
        {
            //Arrange
            var fakeOrder = _orderFixture.Order;
            fakeOrder.Quantity = quantity;


            //Act - Assert
            Assert.Equal(expected, fakeOrder.Quantity > 0);
        }
    }
}
