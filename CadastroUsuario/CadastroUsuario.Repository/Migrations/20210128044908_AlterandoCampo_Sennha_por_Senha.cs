using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroUsuario.Repository.Migrations
{
    public partial class AlterandoCampo_Sennha_por_Senha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sennha",
                table: "Usuario",
                newName: "Senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "Sennha");
        }
    }
}
