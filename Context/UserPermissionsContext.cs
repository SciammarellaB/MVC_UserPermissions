using Hanssens.Net;
using Microsoft.EntityFrameworkCore;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions.Context;

public class UserPermissionsContext : DbContext
{
    public List<long> _permissoes;
    
    public UserPermissionsContext(DbContextOptions<UserPermissionsContext> options) : base(options)
    {
        _permissoes = PermissaoUsuarios.Select(x => x.PermissaoId).ToList();

        var localStorage = new LocalStorage();
        localStorage.Clear();        
        localStorage.Store("permissoes", String.Join(", ", _permissoes));
        localStorage.Persist();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();        
    }
    
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }    
    public DbSet<PermissaoUsuario> PermissaoUsuarios { get; set; }
}
