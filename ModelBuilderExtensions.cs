using Microsoft.EntityFrameworkCore;
using MVC_UserPermissions.Models;

namespace MVC_UserPermissions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permissao>().HasData(Permissao.ObterDados());
    }
}

