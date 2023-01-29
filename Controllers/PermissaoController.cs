using Microsoft.AspNetCore.Mvc;
using MVC_UserPermissions.Attributes;
using MVC_UserPermissions.Context;
using MVC_UserPermissions.Enumerados;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions.Controllers
{
    public class PermissaoController : Controller
    {
        readonly UserPermissionsContext _context;
        protected IQueryable<PermissaoUsuario> _query;

        public PermissaoController(UserPermissionsContext context)
        {
            _context = context;
            _query = _context.Set<PermissaoUsuario>();
        }

        public class Funcionalidade_Model
        {
            public long FuncionalidadeId { get; set; }
            public string Nome { get; set; }
            public bool Ativo { get; set; }

            public IList<Funcionalidade_Model> Children { get; set; }

            public Funcionalidade_Model()
            {
                Children = new List<Funcionalidade_Model>();
            }

            public Funcionalidade_Model(long funcionalidadeId, string nome, bool ativo)
            {
                FuncionalidadeId = funcionalidadeId;
                Nome = nome;
                Ativo = ativo;                
            }
        }

        public IActionResult Index()
        {
            var permissoes = Enum.GetValues(typeof(Permissoes))
                .Cast<Permissoes>()
                .Select(FuncionalidadeAttribute.Read)
                .ToArray();

            var permissoes_atribuidas = _query.ToList();

            var retorno = new List<Funcionalidade_Model>();

            foreach(var permissao in permissoes.Where(x => x.IsGrupo))
            {
                retorno.Add(new Funcionalidade_Model((int)permissao.Valor, permissao.DisplayName, permissoes_atribuidas.Any(x => x.PermissaoId == (int) permissao.Valor)));
            }

            foreach (var permissao in permissoes.Where(x => !x.IsGrupo))
            {
                var parent = retorno.FirstOrDefault(x => x.FuncionalidadeId == (int) permissao.Parent);
                
                if(parent.Children == null)
                    parent.Children = new List<Funcionalidade_Model>();

                parent.Children.Add(new Funcionalidade_Model((int)permissao.Valor, permissao.DisplayName, permissoes_atribuidas.Any(x => x.PermissaoId == (int)permissao.Valor)));
            }

            return View(retorno);
        }

        public ActionResult Atribuir(string funcionalidadeId)
        {
            if(_query.Any(x => x.PermissaoId == long.Parse(funcionalidadeId)))
            {
                var permissao = _query.FirstOrDefault(x => x.PermissaoId == long.Parse(funcionalidadeId));
                _context.Set<PermissaoUsuario>().Remove(permissao);
            }
            else
            {
                _context.Set<PermissaoUsuario>().Add(new PermissaoUsuario(long.Parse(funcionalidadeId)));
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
