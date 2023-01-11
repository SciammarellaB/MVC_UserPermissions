using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Models;
using static MVC_UserPermissions.Provider.UserPermissionsProvider;

namespace MVC_UserPermissions.Controllers;

public class ProdutoController : Controller
{
    protected readonly UserPermissionsContext _context;
    protected IQueryable<Produto> _query;

    public ProdutoController(UserPermissionsContext context)
    {
        _context = context;
        _query = _context.Set<Produto>();
    }

    [CustomAuthorize("10001000")]
    public IActionResult List()
    {
        var query = _query.Include(x => x.Categoria);

        return View(query);
    }

    [CustomAuthorize("10002000")]
    public IActionResult Create()
    {
        var produto = new Produto();

        return View(produto);
    }

    public IActionResult Edit(long id)
    {
        var produto = _query.SingleOrDefault(x => x.Id == id);

        return RedirectToAction("Create", "Create", produto);
    }

    public ActionResult Save(Produto model)
    {
        if (model.Id > 0)
        {
            var local = _query.SingleOrDefault(x => x.Id == model.Id);

            if (local == null)
                ModelState.AddModelError("", "Erro ao alterar o registro");

            local.Nome = model.Nome;
            local.CategoriaId = model.CategoriaId;                

            _context.SaveChanges();
        }
        else
        {
            _context.Produtos.Add(model);

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
