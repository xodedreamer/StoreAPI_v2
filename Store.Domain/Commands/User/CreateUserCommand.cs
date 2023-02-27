using Store.Domain.Commands.Common;
using Store.Domain.Enums;

namespace Store.Domain.Commands.User
{
    public class CreateUserCommand : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public UserProfile Profile { get; set; }
    }
}
