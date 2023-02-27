using Store.Domain.Events.Common;
using System;

namespace Store.Domain.Events.User
{
    public class ChangeUserPasswordEvent : Event
    {
        public ChangeUserPasswordEvent(Guid id, string password)
        {
            Id = id;
            Password = password;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
        public string Password { get; private set; }
    }
}
