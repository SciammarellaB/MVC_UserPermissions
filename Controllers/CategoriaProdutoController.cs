using Hanssens.Net;
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

    public List<long> _permissoes;

    public CategoriaProdutoController(UserPermissionsContext context)
    {
        _context = context;
        _query = _context.Set<CategoriaProduto>();

        var permissoesStr = new LocalStorage().Get("permissoes").ToString();
        if (permissoesStr.Length > 0)
            _permissoes = permissoesStr.Split(",").Select(x => long.Parse(x)).ToList();
    }

    [CustomAuthorize(Permissoes.Categoria_Produto_Listar)]
    public IActionResult List()
    {
        ViewBag.Permissions = new
        {
            Criar = _permissoes.Any(x => x == (int)Permissoes.Categoria_Produto_Cadastrar),
            Editar = _permissoes.Any(x => x == (int)Permissoes.Categoria_Produto_Editar),
            Excluir = _permissoes.Any(x => x == (int)Permissoes.Categoria_Produto_Excluir)
        };

        var query = _query;

        return View(query);
    }

    [CustomAuthorize(Permissoes.Categoria_Produto_Cadastrar)]
    public IActionResult Create(CategoriaProduto? categoriaProduto)
    {
        if(categoriaProduto.Id == 0)
        {
            categoriaProduto = new CategoriaProduto();
        }

        return View(categoriaProduto);
    }

    [CustomAuthorize(Permissoes.Categoria_Produto_Editar)]
    public IActionResult Edit(long id)
    {
        var categoria = _query.SingleOrDefault(x => x.Id == id);

        return RedirectToAction("Create", "CategoriaProduto", categoria);
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

    [CustomAuthorize(Permissoes.Categoria_Produto_Excluir)]
    public ActionResult Delete(long id)
    {
        var item = _query.SingleOrDefault(x => x.Id == id);

        _context.Remove(item);

        _context.SaveChanges();

        return RedirectToAction("List");
    }
}
