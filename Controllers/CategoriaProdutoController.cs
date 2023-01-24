using Microsoft.AspNetCore.Mvc;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Enumerados;
using MVC_UserPermissions.Filter;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions.Controllers;

public class CategoriaProdutoController : Controller
{
    readonly UserPermissionsContext _context;
    protected IQueryable<CategoriaProduto> _query;

    public CategoriaProdutoController(UserPermissionsContext context)
    {
        _context = context;
        _query = _context.Set<CategoriaProduto>();
    }

    [CustomAuthorize(Permissoes.Listar_Categoria_Produto)]
    public IActionResult List()
    {
        ViewBag.Permissions = new
        {
            Criar = _context._permissoes.Any(x => x == (int)Permissoes.Cadastrar_Categoria_Produto),
            Editar = _context._permissoes.Any(x => x == (int)Permissoes.Editar_Categoria_Produto),
            Excluir = _context._permissoes.Any(x => x == (int)Permissoes.Excluir_Categoria_Produto)
        };

        var query = _query;

        return View(query);
    }

    [CustomAuthorize(Permissoes.Cadastrar_Categoria_Produto)]
    public IActionResult Create()
    {
        var produto = new CategoriaProduto();

        return View(produto);
    }

    [CustomAuthorize(Permissoes.Editar_Categoria_Produto)]
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

    [CustomAuthorize(Permissoes.Excluir_Categoria_Produto)]
    public ActionResult Delete(long id)
    {
        var item = _query.SingleOrDefault(x => x.Id == id);

        _context.Remove(item);

        _context.SaveChanges();

        return RedirectToAction("List");
    }
}
