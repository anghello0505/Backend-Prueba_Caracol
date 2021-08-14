using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba_Tecnica.Migrations
{
    public partial class ActulzarPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAprobacion",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdVendedorAprobado",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAprobacion",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdVendedorAprobado",
                table: "Pedidos");
        }
    }
}
