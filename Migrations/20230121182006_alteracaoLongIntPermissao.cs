using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_UserPermissions.Migrations
{
    public partial class alteracaoLongIntPermissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PermissaoId",
                table: "Permissao_Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PermissaoId",
                table: "Permissao_Usuario",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
