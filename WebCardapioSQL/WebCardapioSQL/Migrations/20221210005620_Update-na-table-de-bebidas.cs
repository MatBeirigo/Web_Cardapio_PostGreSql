﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCardapioSQL.Migrations
{
    /// <inheritdoc />
    public partial class Updatenatabledebebidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ingredientes",
                table: "Lanche",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredientes",
                table: "Lanche");
        }
    }
}
