using Store.Domain.Events.Common;
using System;

namespace Store.Domain.Events.User
{
    public class DeleteUserEvent : Event
    {
        public DeleteUserEvent(Guid id)
        {
            Id = id;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
    }
}
