using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_UserPermissions.Models;

[Table("Produto")]
public class Produto
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public long CategoriaId { get; set; }
    public CategoriaProduto Categoria { get; set; }

    public Produto()
    {

    }

    public Produto(long id, string nome, long categoriaId)
    {
        Id = id;
        Nome = nome;
        CategoriaId = categoriaId;        
    }
}
