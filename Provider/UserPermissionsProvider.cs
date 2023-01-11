using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_UserPermissions.Provider;

public class UserPermissionsProvider
{
    public UserPermissionsProvider(IHttpContextAccessor acessor)
    {

    }

    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly string _key;


        public CustomAuthorize(string key)
        {
            _key = key;
        }
    }
}
