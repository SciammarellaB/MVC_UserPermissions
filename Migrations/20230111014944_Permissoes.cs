using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_UserPermissions.Migrations
{
    public partial class Permissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao_Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissaoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissao_Usuario_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissao",
                columns: new[] { "Id", "Key", "Nome" },
                values: new object[,]
                {
                    { 1L, "10001000", "Listar Produto" },
                    { 2L, "10002000", "Criar Produto" },
                    { 3L, "10003000", "Editar Produto" },
                    { 4L, "10004000", "Deletar Produto" },
                    { 5L, "20001000", "Listar Categoria Produto" },
                    { 6L, "20002000", "Criar Categoria Produto" },
                    { 7L, "20003000", "Editar Categoria Produto" },
                    { 8L, "20004000", "Deletar Categoria Produto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissao_Usuario_PermissaoId",
                table: "Permissao_Usuario",
                column: "PermissaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissao_Usuario");

            migrationBuilder.DropTable(
                name: "Permissao");
        }
    }
}
