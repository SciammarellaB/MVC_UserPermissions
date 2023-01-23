using Microsoft.AspNetCore.Mvc;

namespace MVC_UserPermissions.Controllers.Shared
{
    public class UnauthrizedController : Controller
    {
        public IActionResult Index(string values)
        {
            ViewBag.Rota = values;
            return View();
        }
    }
}
