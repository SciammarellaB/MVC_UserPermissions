using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Enumerados;
using MVC_UserPermissions.Filter;
using MVC_UserPermissions.Models;

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

    [CustomAuthorize(Permissoes.Listar_Produto)]
    public IActionResult List()
    {
        var query = _query.Include(x => x.Categoria);

        return View(query);
    }

    [CustomAuthorize(Permissoes.Cadastrar_Produto)]
    public IActionResult Create()
    {
        var produto = new Produto();

        return View(produto);
    }

    [CustomAuthorize(Permissoes.Editar_Produto)]
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

    [CustomAuthorize(Permissoes.Excluir_Produto)]
    public ActionResult Delete(long id)
    {
        var item = _query.SingleOrDefault(x => x.Id == id);

        _context.Remove(item);

        _context.SaveChanges();

        return RedirectToAction("List");
    }
}
