using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cloudiness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lon = table.Column<double>(nullable: false),
                    lat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internal_parameter = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    message = table.Column<double>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    sunrise = table.Column<int>(nullable: false),
                    sunset = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_Id = table.Column<int>(nullable: false),
                    cloudsId = table.Column<int>(nullable: true),
                    coordinatesId = table.Column<int>(nullable: true),
                    mainId = table.Column<int>(nullable: true),
                    visibility = table.Column<int>(nullable: false),
                    windId = table.Column<int>(nullable: true),
                    update_time = table.Column<int>(nullable: false),
                    systemId = table.Column<int>(nullable: true),
                    timezone = table.Column<int>(nullable: false),
                    cityname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roots_Clouds_cloudsId",
                        column: x => x.cloudsId,
                        principalTable: "Clouds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Coordinates_coordinatesId",
                        column: x => x.coordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Mains_mainId",
                        column: x => x.mainId,
                        principalTable: "Mains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
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
                    request_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    RootId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.weather_Id);
                    table.ForeignKey(
                        name: "FK_Weathers_Roots_RootId",
                        column: x => x.RootId,
                        principalTable: "Roots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roots_cloudsId",
                table: "Roots",
                column: "cloudsId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_coordinatesId",
                table: "Roots",
                column: "coordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_mainId",
                table: "Roots",
                column: "mainId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_systemId",
                table: "Roots",
                column: "systemId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_windId",
                table: "Roots",
                column: "windId");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_RootId",
                table: "Weathers",
                column: "RootId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Roots");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Mains");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Winds");
        }
    }
}
