using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using $safeprojectname$.Entities.Sp;
using $safeprojectname$.Entities.Tables;

namespace $safeprojectname$.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetOrderBy(Expression<Func<Orders, bool>> predicate = null);
        Task<List<SpComplexDataFromDb>> GetActiveOrdersById(int orderId);

        Task<bool> CreateOrder(Orders order);
    }
}