using Store.Domain.Commands.Common;
using System;

namespace Store.Domain.Commands.User
{
    public class DeleteUserCommand : Command
    {
        public DeleteUserCommand(Guid id) => Id = id;

        public Guid Id { get; set; }
    }
}
