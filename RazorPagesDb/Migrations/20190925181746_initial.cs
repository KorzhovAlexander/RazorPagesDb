using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RazorPagesDb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VIPOLZOVStudents",
                columns: table => new
                {
                    VIPId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VIPLastName = table.Column<string>(nullable: true),
                    VIPFirstName = table.Column<string>(maxLength: 250, nullable: true),
                    VIPEnrollmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPOLZOVStudents", x => x.VIPId);
                });

            migrationBuilder.CreateTable(
                name: "VIPOLZOVHomework",
                columns: table => new
                {
                    VIPId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VIPNameHomework = table.Column<string>(nullable: false),
                    VIPstdIDWORKALALAL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPOLZOVHomework", x => x.VIPId);
                    table.ForeignKey(
                        name: "FK_VIPOLZOVHomework_VIPOLZOVStudents_VIPstdIDWORKALALAL",
                        column: x => x.VIPstdIDWORKALALAL,
                        principalTable: "VIPOLZOVStudents",
                        principalColumn: "VIPId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VIPOLZOVHomework_VIPstdIDWORKALALAL",
                table: "VIPOLZOVHomework",
                column: "VIPstdIDWORKALALAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIPOLZOVHomework");

            migrationBuilder.DropTable(
                name: "VIPOLZOVStudents");
        }
    }
}
