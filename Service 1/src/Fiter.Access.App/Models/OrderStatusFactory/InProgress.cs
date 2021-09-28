using Domain.Entities.Tables;
using Domain.Interfaces;

namespace Application.Models.OrderStatusFactory
{
    using System.Threading.Tasks;

    public class InProgress : IOrderStatus
    {
        public Task<string> DoSomeThing(Orders orders)
        {
            return Task.FromResult("Ok");
        }
    }
}
