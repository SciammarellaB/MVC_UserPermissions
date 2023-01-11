using Microsoft.AspNetCore.Mvc;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions.Controllers;

public class CategoriaProdutoController : Controller
{
    protected readonly UserPermissionsContext _context;
    protected IQueryable<CategoriaProduto> _query;

    public CategoriaProdutoController(UserPermissionsContext context)
    {
        _context = context;
        _query = _context.Set<CategoriaProduto>();
    }

    public IActionResult List()
    {
        var query = _query;

        return View(query);
    }

    public IActionResult Create()
    {
        var produto = new CategoriaProduto();

        return View(produto);
    }

    public IActionResult Edit(long id)
    {
        var categoria = _query.SingleOrDefault(x => x.Id == id);

        return RedirectToAction("Create", "CategoriaProduto", new CategoriaProduto(categoria.Id, categoria.Nome));
    }

    public ActionResult Save(CategoriaProduto model)
    {
        if (model.Id > 0)
        {
            var local = _query.SingleOrDefault(x => x.Id == model.Id);

            if (local == null)
                ModelState.AddModelError("", "Erro ao alterar o registro");

            local.Nome = model.Nome;            

            _context.SaveChanges();
        }
        else
        {
            _context.CategoriaProdutos.Add(model);

            _context.SaveChanges();

        }

        return RedirectToAction("List");
    }

    public ActionResult Delete(long id)
    {
        var item = _query.SingleOrDefault(x => x.Id == id);

        _context.Remove(item);

        _context.SaveChanges();

        return RedirectToAction("List");
    }
}
