using System.ComponentModel.DataAnnotations;

namespace MVC_UserPermissions.Enumerados;

public enum Permissoes
{
    #region CATEGORIA_PRODUTO
    [Display(GroupName = "Categoria Produto", Name = "Listar", Description = "Concede acesso")]
    Listar_Categoria_Produto = 100001,
    [Display(GroupName = "Categoria Produto", Name = "Cadastrar", Description = "Concede acesso")]
    Cadastrar_Categoria_Produto = 100002,
    [Display(GroupName = "Categoria Produto", Name = "Editar", Description = "Concede acesso")]
    Editar_Categoria_Produto = 100003,
    [Display(GroupName = "Categoria Produto", Name = "Excluir", Description = "Concede acesso")]
    Excluir_Categoria_Produto = 100004,
    #endregion
    #region PRODUTO
    [Display(GroupName = "Produto", Name = "Listar", Description = "Concede acesso")]
    Listar_Produto = 200001,
    [Display(GroupName = "Produto", Name = "Cadastrar", Description = "Concede acesso")]
    Cadastrar_Produto = 200002,
    [Display(GroupName = "Produto", Name = "Editar", Description = "Concede acesso")]
    Editar_Produto = 200003,
    [Display(GroupName = "Produto", Name = "Excluir", Description = "Concede acesso")]
    Excluir_Produto = 200004,
    #endregion
}
