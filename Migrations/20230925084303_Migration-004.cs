using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeChallenge02.Migrations
{
    /// <inheritdoc />
    public partial class Migration004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CNPJ",
                table: "Usuarios",
                column: "CNPJ",
                unique: true,
                filter: "[isPessoaFisica] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CPF",
                table: "Usuarios",
                column: "CPF",
                unique: true,
                filter: "[isPessoaFisica] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CNPJ",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CPF",
                table: "Usuarios");
        }
    }
}
