using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities.Tables;
using MediatR;

namespace Application.UseCases.GetOrder
{
    public class GetOrderQuery : IRequest<IEnumerable<GetOrderResponse>>
    {

        public readonly Expression<Func<Orders, bool>> Predicate;

        public GetOrderQuery(Expression<Func<Orders, bool>> predicate) => Predicate = predicate;
    }
}
