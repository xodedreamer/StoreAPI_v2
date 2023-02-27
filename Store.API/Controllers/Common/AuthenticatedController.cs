using MediatR;
using Store.API.Auth;
using Store.Domain.Bus;
using Store.Domain.Enums;
using Store.Domain.Notifications;
using System;
using System.Security.Claims;

namespace Store.API.Controllers.Common
{
    [BaererAuthorize]
    public abstract class AuthenticatedController : BaseController
    {
        protected AuthenticatedController(IMediatorHandler mediator, IMediatorHandler bus) : base(mediator, bus)
        {
        }

        protected Guid UserId
        {
            get => Guid.Parse(GetClaim(ClaimTypes.NameIdentifier));
        }

        protected bool IsAdmin
        {
            get => GetClaim(ClaimTypes.Role) == UserProfile.Admin.ToString();
        }
    }
}
