using Store.Domain.Events.Common;
using System;

namespace Store.Domain.Events.Order
{
    public class RemoveProductEvent : Event
    {
        public RemoveProductEvent(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;

            AggregateId = orderId;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
    }
}
