﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyNET7Learn.Migrations
{
    /// <inheritdoc />
    public partial class KitapResimUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimUrl",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimUrl",
                table: "Kitaplar");
        }
    }
}
