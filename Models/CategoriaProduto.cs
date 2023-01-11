using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_UserPermissions.Models;

[Table("CategoriaProduto")]
public class CategoriaProduto
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public CategoriaProduto()
    {

    }

    public CategoriaProduto(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
