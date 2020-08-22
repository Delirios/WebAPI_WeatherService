using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temp = table.Column<double>(nullable: false),
                    feels_like = table.Column<double>(nullable: false),
                    temp_min = table.Column<double>(nullable: false),
                    temp_max = table.Column<double>(nullable: false),
                    pressure = table.Column<int>(nullable: false),
                    humidity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(nullable: false),
                    message = table.Column<double>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    sunrise = table.Column<int>(nullable: false),
                    sunset = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speed = table.Column<double>(nullable: false),
                    deg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mainId = table.Column<int>(nullable: true),
                    visibility = table.Column<int>(nullable: false),
                    windId = table.Column<int>(nullable: true),
                    datetime = table.Column<int>(nullable: false),
                    sysid = table.Column<int>(nullable: true),
                    timezone = table.Column<int>(nullable: false),
                    cityname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.id);
                    table.ForeignKey(
                        name: "FK_Roots_Mains_mainId",
                        column: x => x.mainId,
                        principalTable: "Mains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Systems_sysid",
                        column: x => x.sysid,
                        principalTable: "Systems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Winds_windId",
                        column: x => x.windId,
                        principalTable: "Winds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    weather_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    condition = table.Column<int>(nullable: false),
                    main = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Rootid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.weather_Id);
                    table.ForeignKey(
                        name: "FK_Weathers_Roots_Rootid",
                        column: x => x.Rootid,
                        principalTable: "Roots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roots_mainId",
                table: "Roots",
                column: "mainId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_sysid",
                table: "Roots",
                column: "sysid");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_windId",
                table: "Roots",
                column: "windId");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_Rootid",
                table: "Weathers",
                column: "Rootid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Roots");

            migrationBuilder.DropTable(
                name: "Mains");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Winds");
        }
    }
}
