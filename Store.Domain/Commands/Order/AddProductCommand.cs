using Store.Domain.Commands.Common;
using System;

namespace Store.Domain.Commands.Order
{
    public class AddProductCommand : Command
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
