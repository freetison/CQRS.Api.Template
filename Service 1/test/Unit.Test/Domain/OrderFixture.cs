using System;
using Domain.Entities.Tables;
using Domain.Model;

namespace Unit.Test.Domain
{
    public class OrderFixture: IDisposable
    {
        string orderId = "1";
        private readonly Product product = new Product("1", "FakeProductName");
        decimal quantity = 30M;

        public Orders Order => new Orders(orderId, product, quantity);

        public void Dispose()
        {
        }

    }
}