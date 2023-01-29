using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_UserPermissions.Models;

[Table("Permissao_Usuario")]
public class PermissaoUsuario
{
    public long Id { get; set; }
    //usuario
    public long PermissaoId { get; set; }

    public PermissaoUsuario()
    {

    }

    public PermissaoUsuario(long permissaoId)
    {
        PermissaoId = permissaoId;
    }
}
