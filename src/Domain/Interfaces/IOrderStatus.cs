using System.Threading.Tasks;
using $safeprojectname$.Entities.Tables;

namespace $safeprojectname$.Interfaces
{
    public interface IOrderStatus
    {
        Task<string> DoSomeThing(Orders orders);
    }
}