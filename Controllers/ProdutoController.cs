using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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

    public List<long> _permissoes;

    public ProdutoController(UserPermissionsContext context)
    {
        _context = context;
        _query = _context.Set<Produto>();

        var permissoesStr = new LocalStorage().Get("permissoes").ToString();
        if(permissoesStr.Length > 0)
            _permissoes = permissoesStr.Split(",").Select(x => long.Parse(x)).ToList();
    }

    [CustomAuthorize(Permissoes.Produto_Listar)]
    public IActionResult List()
    {
        ViewBag.Permissions = new
        {
            Criar = _permissoes.Any(x => x == (long) Permissoes.Produto_Cadastrar),
            Editar = _permissoes.Any(x => x == (int) Permissoes.Produto_Editar),
            Excluir = _permissoes.Any(x => x == (int) Permissoes.Produto_Excluir)
        };

        var query = _query.Include(x => x.Categoria);

        return View(query);
    }

    [CustomAuthorize(Permissoes.Produto_Cadastrar)]
    public IActionResult Create(Produto? produto)
    {
        if (produto.Id == 0)
        {
            produto = new Produto();
        }

        return View(produto);
    }

    [CustomAuthorize(Permissoes.Produto_Editar)]
    public IActionResult Edit(long id)
    {
        var produto = _query.SingleOrDefault(x => x.Id == id);

        return RedirectToAction("Create", "Produto", produto);
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

    [CustomAuthorize(Permissoes.Produto_Excluir)]
    public ActionResult Delete(long id)
    {
        var item = _query.SingleOrDefault(x => x.Id == id);

        _context.Remove(item);

        _context.SaveChanges();

        return RedirectToAction("List");
    }
}
