using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:citext", ",,");

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "citext", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weather_histories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: true),
                    city_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weather_histories", x => x.id);
                    table.ForeignKey(
                        name: "fk_weather_histories_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "weathers",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    temperature = table.Column<double>(type: "double precision", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    wind = table.Column<double>(type: "double precision", nullable: false),
                    water = table.Column<double>(type: "double precision", nullable: false),
                    humidity = table.Column<double>(type: "double precision", nullable: false),
                    pressure = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weathers", x => x.city_id);
                    table.ForeignKey(
                        name: "fk_weathers_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_cities_name",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_weather_histories_city_id",
                table: "weather_histories",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weather_histories");

            migrationBuilder.DropTable(
                name: "weathers");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
