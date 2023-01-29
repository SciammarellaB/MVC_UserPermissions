using MVC_UserPermissions.Attributes;

namespace MVC_UserPermissions.Enumerados;

public enum Permissoes
{
    #region CATEGORIA_PRODUTO
    [Funcionalidade("Categoria Produto", IsGrupo = true, Descricao ="Categoria Produto")]
    Categoria_Produto = 100000,
    [Funcionalidade("Listar", Parent = Categoria_Produto, Descricao = "Listar")]
    Categoria_Produto_Listar = 100001,
    [Funcionalidade("Cadastrar", Parent = Categoria_Produto, Descricao = "Cadastrar")]
    Categoria_Produto_Cadastrar = 100002,
    [Funcionalidade("Editar", Parent = Categoria_Produto, Descricao = "Editar")]
    Categoria_Produto_Editar = 100003,
    [Funcionalidade("Excluir", Parent = Categoria_Produto, Descricao = "Excluir")]
    Categoria_Produto_Excluir = 100004,
    //[Funcionalidade("AAAAA", Parent = Categoria_Produto, Descricao = "A")]
    //Categoria_Produto_A = 100005,
    //[Funcionalidade("BBBBB", Parent = Categoria_Produto, Descricao = "B")]
    //Categoria_Produto_B = 100006,
    //[Funcionalidade("CCCCC", Parent = Categoria_Produto, Descricao = "C")]
    //Categoria_Produto_C = 100007,
    //[Funcionalidade("DDDDD", Parent = Categoria_Produto, Descricao = "D")]
    //Categoria_Produto_D = 100008,
    //[Funcionalidade("EEEEE", Parent = Categoria_Produto, Descricao = "E")]
    //Categoria_Produto_E = 100009,
    //[Funcionalidade("FFFFF", Parent = Categoria_Produto, Descricao = "F")]
    //Categoria_Produto_F = 100010,
    #endregion

    #region PRODUTO
    [Funcionalidade("Produto", IsGrupo = true, Descricao = "Produto")]
    Produto = 200000,
    [Funcionalidade("Listar", Parent = Produto, Descricao = "Listar")]
    Produto_Listar = 200001,
    [Funcionalidade("Cadastrar", Parent = Produto, Descricao = "Cadastrar")]
    Produto_Cadastrar = 200002,
    [Funcionalidade("Editar", Parent = Produto, Descricao = "Editar")]
    Produto_Editar = 200003,
    [Funcionalidade("Excluir", Parent = Produto, Descricao = "Excluir")]
    Produto_Excluir = 200004,
    #endregion
}
