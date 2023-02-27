using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.API.Controllers.Common;
using Store.Domain.Bus;
using Store.Domain.Commands.User;
using Store.Domain.Interfaces.Repositories;
using Store.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController(IMediatorHandler mediator, IMediatorHandler bus, IUserRepository userRepository) : base(mediator, bus)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(userRepository.Query());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Response(await userRepository.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bus.SendAsync(new DeleteUserCommand(id));
            return Response();
        }
    }
}
