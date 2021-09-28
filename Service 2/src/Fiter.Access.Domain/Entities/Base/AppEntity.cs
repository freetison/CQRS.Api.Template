using System.Collections.Generic;
using MediatR;

namespace Domain.Entities.Base
{
    public abstract class AppEntity : EntityBase<int>
    {
        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);

        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }
    }
}
