using System.Threading.Tasks;
using Infrastructure.DbContext;
using MediatR;

namespace Infrastructure.Mediator
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, AppDbContext ctx)
        {
            //var domainEntities = ctx.ChangeTracker.Entries<Entity>().Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            //var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();
            //domainEntities.ToList().ForEach(entity => entity.Entity.DomainEvents.Clear());

            //var tasks = domainEvents
            //    .Select(async (domainEvent) => {
            //        await mediator.PublishAsync(domainEvent);
            //    });

            //await Task.WhenAll(tasks);
        }
    }
}