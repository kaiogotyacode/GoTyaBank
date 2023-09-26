using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeChallenge02.Migrations
{
    /// <inheritdoc />
    public partial class Migration010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Usuarios",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Usuarios",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);
        }
    }
}
