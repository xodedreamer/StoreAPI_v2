using Store.Domain.Commands.Common;
using Store.Domain.Enums;
using System;

namespace Store.Domain.Commands.User
{
    public class UpdateUserCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserProfile Profile { get; set; }
    }
}
