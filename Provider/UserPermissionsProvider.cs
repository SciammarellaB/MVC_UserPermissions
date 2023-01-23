using Microsoft.AspNetCore.Authorization;
using MVC_UserPermissions.Enumerados;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVC_UserPermissions.Provider;

public class UserPermissionsProvider
{
    public UserPermissionsProvider(IHttpContextAccessor acessor)
    {

    }
}
