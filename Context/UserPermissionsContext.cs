using Microsoft.EntityFrameworkCore;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions.Context;

public class UserPermissionsContext : DbContext
{
    public List<int> _permissoes = new List<int>
    {
        //LISTAR CATEGORIA PRODUTO
        100001,
        //CADASTRAR CATEGORIA PRODUTO
        100002,
        //EXCLUIR CATEGORIA PRODUTO
        100004,
        //LISTAR PRODUTO
        200001,
        //CADASTRAR PRODUTO
        200002
    };

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
