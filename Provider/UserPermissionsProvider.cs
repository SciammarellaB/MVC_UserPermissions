using Microsoft.AspNetCore.Authorization;
using MVC_UserPermissions.Enumerados;
using System.Web.Mvc;

namespace MVC_UserPermissions.Provider;

public class UserPermissionsProvider
{
    public UserPermissionsProvider(IHttpContextAccessor acessor)
    {

    }

    public class CustomAuthorize : FilterAttribute, IAuthorizationFilter
    {
        new List<int> _teste = new List<int>();

        public CustomAuthorize(params Permissoes[] permission)
        {
            permission.ToList().ForEach(x => _teste.Add((int)x));
        }


        public void OnAuthorization(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}
