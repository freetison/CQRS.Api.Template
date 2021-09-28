using System.Threading.Tasks;
using Domain.Entities.Tables;
using Domain.Interfaces;

namespace Application.Models.OrderStatusFactory
{
    public class Completed : IOrderStatus
    {
        public Task<string> DoSomeThing(Orders orders)
        {
            return Task.FromResult("Ok");
        }
    }
}