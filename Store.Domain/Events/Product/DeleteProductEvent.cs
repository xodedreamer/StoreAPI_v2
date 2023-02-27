using Store.Domain.Events.Common;
using System;

namespace Store.Domain.Events.Product
{
    public class DeleteProductEvent : Event
    {
        public DeleteProductEvent(Guid id)
        {
            Id = id;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
    }
}
