using Store.Domain.Events.Common;
using Store.Domain.Models;

namespace Store.Domain.Events.Order
{
    public class AddProductEvent : Event
    {
        public AddProductEvent(OrderItem item)
        {
            Item = item;

            AggregateId = item.Id;
        }

        public OrderItem Item { get; private set; }
    }
}
