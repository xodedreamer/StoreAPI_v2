using Store.Domain.Commands.Common;
using System;

namespace Store.Domain.Commands.Order
{
    public class CancelOrderCommand : Command
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
    }
}
