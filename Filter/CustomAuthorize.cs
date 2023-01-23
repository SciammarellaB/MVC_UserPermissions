using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Controllers.Shared;
using MVC_UserPermissions.Enumerados;

namespace MVC_UserPermissions.Filter;

public class CustomAuthorize : ActionFilterAttribute
{
    protected readonly UserPermissionsContext _context;
    new List<int> _permissoes = new List<int>();

    public CustomAuthorize(params Permissoes[] permission)
    {
        permission.ToList().ForEach(x => _permissoes.Add((int)x));
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {

        var permissoes = new List<int>
        {
            //LISTAR CATEGORIA PRODUTO
            100001,
            //EXCLUIR CATEGORIA PRODUTO
            100004,
            //LISTAR PRODUTO
            200001,
            //CADASTRAR PRODUTO
            200002

        };

        if (!_permissoes.Any(x => permissoes.Contains(x)))
        {
            var controller = filterContext.RouteData.Values["Controller"];

            filterContext.HttpContext.Response.StatusCode = 403;
            filterContext.Result = new RedirectToActionResult("Index", "Unauthrized", new { Values = controller });

            //filterContext.Result = new UnauthorizedObjectResult("Você não tem permissão para essa função!");
        }
        base.OnActionExecuting(filterContext);
    }
}
