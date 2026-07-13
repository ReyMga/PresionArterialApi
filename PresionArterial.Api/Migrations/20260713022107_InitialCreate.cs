using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresionArterial.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mediciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PresionSistolica = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresionDiastolica = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Temperatura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Humedad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValsartanMg = table.Column<int>(type: "int", nullable: false),
                    AtenololMg = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mediciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mediciones");
        }
    }
}
