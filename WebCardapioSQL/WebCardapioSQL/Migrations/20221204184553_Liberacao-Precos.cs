using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCardapioSQL.Migrations
{
    /// <inheritdoc />
    public partial class LiberacaoPrecos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Preco",
                table: "Porcao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preco",
                table: "Lanche",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preco",
                table: "Bebida",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Porcao");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Lanche");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Bebida");
        }
    }
}
