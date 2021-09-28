using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Sp;
using Domain.Entities.Tables;

namespace Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetOrderBy(Expression<Func<Orders, bool>> predicate = null);
        Task<List<SpComplexDataFromDb>> GetActiveOrdersById(int orderId);

        Task<bool> CreateOrder(Orders order);
    }
}