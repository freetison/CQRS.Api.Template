using System.Threading.Tasks;
using Domain.Entities.Tables;

namespace Domain.Interfaces
{
    public interface IOrderStatus
    {
        Task<string> DoSomeThing(Orders orders);
    }
}