using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_UserPermissions.Models;

//  LISTA DE TODAS AS PERMISSOES QUE EXISTEM NO SISTEMA

[Table("Permissao")]
public class Permissao
{
    [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }
    [Required] public string Nome { get; set; }
    [Required] public string Key { get; set; }

    public Permissao(long id, string nome, string key)
    {
        Id = id;
        Nome = nome;
        Key = key;
    }

    public static Permissao[] ObterDados()
    {
        return new Permissao[]
        {
            //PRODUTO
            new Permissao(1,   "Listar Produto",   "10001000"),
            new Permissao(2,   "Criar Produto",    "10002000"),
            new Permissao(3,   "Editar Produto",   "10003000"),
            new Permissao(4,   "Deletar Produto",  "10004000"),
            //CATEGORIA PRODUTO
            new Permissao(5,   "Listar Categoria Produto",   "20001000"),
            new Permissao(6,   "Criar Categoria Produto",    "20002000"),
            new Permissao(7,   "Editar Categoria Produto",   "20003000"),
            new Permissao(8,   "Deletar Categoria Produto",  "20004000"),
        };
    }
}
