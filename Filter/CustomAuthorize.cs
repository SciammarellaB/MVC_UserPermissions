using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Controllers.Shared;
using MVC_UserPermissions.Enumerados;

namespace MVC_UserPermissions.Filter;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class CustomAuthorize : ActionFilterAttribute
{
    new List<int> _permissoes = new List<int>();

    public CustomAuthorize(params Permissoes[] permission)
    {
        permission.ToList().ForEach(x => _permissoes.Add((int)x));
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var permissoesStr = new LocalStorage().Get("permissoes").ToString();
        var permissoes = new List<long>();

        if (permissoesStr.Length > 0)
            permissoes = permissoesStr.Split(",").Select(x => long.Parse(x)).ToList();

        if (!_permissoes.Any(x => permissoes.Contains(x)))
        {
            var controller = filterContext.RouteData.Values["Controller"];

            filterContext.HttpContext.Response.StatusCode = 403;
            filterContext.Result = new RedirectResult("/Unauthrized/Index");
        }
        base.OnActionExecuting(filterContext);
    }
}
