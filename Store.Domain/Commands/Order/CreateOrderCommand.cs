using Store.Domain.Commands.Common;
using System;

namespace Store.Domain.Commands.Order
{
    public class CreateOrderCommand : RequestCommand<Models.Order>
    {
        public Guid UserId { get; set; }
    }
}
