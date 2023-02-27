using Store.Domain.Commands.Common;
using System;

namespace Store.Domain.Commands.User
{
    public class ChangeUserPasswordCommand : Command
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
