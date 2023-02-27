using Microsoft.AspNetCore.Authorization;
using Store.Domain.Enums;
using System.Linq;

namespace Store.API.Auth
{
    public class BaererAuthorizeAttribute : AuthorizeAttribute
    {
        public BaererAuthorizeAttribute() : base("Bearer")
        {
        }

        public BaererAuthorizeAttribute(params UserProfile[] profiles) : base("Bearer") => Roles = string.Join(",", profiles.Select(e => e.ToString()).ToArray());
    }
}
