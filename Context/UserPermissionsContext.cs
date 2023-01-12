using Microsoft.EntityFrameworkCore;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions.Context;

public class UserPermissionsContext : DbContext
{
    public UserPermissionsContext(DbContextOptions<UserPermissionsContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
    
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }    
    public DbSet<PermissaoUsuario> PermissaoUsuarios { get; set; }
}
