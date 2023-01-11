using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_UserPermissions.Models;

[Table("Permissao_Usuario")]
public class PermissaoUsuario
{
    public long Id { get; set; }
    //usuarioId
    public long PermissaoId { get; set; }
    public Permissao? Permissao { get; private set; }
}
