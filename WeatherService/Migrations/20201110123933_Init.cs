using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    CloudId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cloudiness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.CloudId);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    CoordinateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lon = table.Column<double>(nullable: false),
                    lat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.CoordinateId);
                });

            migrationBuilder.CreateTable(
                name: "Mains",
                columns: table => new
                {
                    MainId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Mains", x => x.MainId);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    SystemId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Systems", x => x.SystemId);
                });

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    WindId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speed = table.Column<double>(nullable: false),
                    deg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.WindId);
                });

            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    RootId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_Id = table.Column<int>(nullable: false),
                    coordinatesCoordinateId = table.Column<int>(nullable: true),
                    cloudsCloudId = table.Column<int>(nullable: true),
                    MainId = table.Column<int>(nullable: true),
                    visibility = table.Column<int>(nullable: false),
                    WindId = table.Column<int>(nullable: true),
                    update_time = table.Column<int>(nullable: false),
                    SystemId = table.Column<int>(nullable: true),
                    timezone = table.Column<int>(nullable: false),
                    cityname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.RootId);
                    table.ForeignKey(
                        name: "FK_Roots_Mains_MainId",
                        column: x => x.MainId,
                        principalTable: "Mains",
                        principalColumn: "MainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Systems_SystemId",
                        column: x => x.SystemId,
                        principalTable: "Systems",
                        principalColumn: "SystemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Winds_WindId",
                        column: x => x.WindId,
                        principalTable: "Winds",
                        principalColumn: "WindId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Clouds_cloudsCloudId",
                        column: x => x.cloudsCloudId,
                        principalTable: "Clouds",
                        principalColumn: "CloudId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roots_Coordinates_coordinatesCoordinateId",
                        column: x => x.coordinatesCoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "CoordinateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_Weathers_Roots_RootId",
                        column: x => x.RootId,
                        principalTable: "Roots",
                        principalColumn: "RootId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roots_MainId",
                table: "Roots",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_SystemId",
                table: "Roots",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_WindId",
                table: "Roots",
                column: "WindId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_cloudsCloudId",
                table: "Roots",
                column: "cloudsCloudId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_coordinatesCoordinateId",
                table: "Roots",
                column: "coordinatesCoordinateId");

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
                name: "Mains");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "Winds");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
