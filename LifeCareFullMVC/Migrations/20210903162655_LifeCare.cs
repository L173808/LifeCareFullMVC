using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeCareFullMVC.Migrations
{
    public partial class LifeCare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorModule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LiginModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiginModule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PatientModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doctorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientModule", x => x.id);
                    table.ForeignKey(
                        name: "FK_PatientModule_DoctorModule_doctorid",
                        column: x => x.doctorid,
                        principalTable: "DoctorModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    patientid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModule", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestModule_PatientModule_patientid",
                        column: x => x.patientid,
                        principalTable: "PatientModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientModule_doctorid",
                table: "PatientModule",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_TestModule_patientid",
                table: "TestModule",
                column: "patientid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiginModule");

            migrationBuilder.DropTable(
                name: "TestModule");

            migrationBuilder.DropTable(
                name: "PatientModule");

            migrationBuilder.DropTable(
                name: "DoctorModule");
        }
    }
}
