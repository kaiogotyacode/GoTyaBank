using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeChallenge02.Migrations
{
    /// <inheritdoc />
    public partial class _011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");
        }
    }
}
