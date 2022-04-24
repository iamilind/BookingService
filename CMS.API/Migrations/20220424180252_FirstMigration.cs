using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastTripEndedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabEntities_CityEntities_CityId",
                        column: x => x.CityId,
                        principalTable: "CityEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabEntities_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CabId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingEntities_CabEntities_CabId",
                        column: x => x.CabId,
                        principalTable: "CabEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingEntities_CityEntities_CityId",
                        column: x => x.CityId,
                        principalTable: "CityEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingEntities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CabId = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripEntities_CabEntities_CabId",
                        column: x => x.CabId,
                        principalTable: "CabEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_CabId",
                table: "BookingEntities",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_CityId",
                table: "BookingEntities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntities_UserId",
                table: "BookingEntities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CabEntities_CityId",
                table: "CabEntities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CabEntities_DriverId",
                table: "CabEntities",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TripEntities_CabId",
                table: "TripEntities",
                column: "CabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEntities");

            migrationBuilder.DropTable(
                name: "TripEntities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CabEntities");

            migrationBuilder.DropTable(
                name: "CityEntities");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
