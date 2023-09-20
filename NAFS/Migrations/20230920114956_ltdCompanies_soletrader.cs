using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAFS.Migrations
{
    /// <inheritdoc />
    public partial class ltdCompanies_soletrader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignServices_Clients_ClientID",
                table: "AssignServices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_AssignServices_ClientID",
                table: "AssignServices");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "AssignServices");

            migrationBuilder.AddColumn<int>(
                name: "LtdCompaniesID",
                table: "AssignServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoleTradersID",
                table: "AssignServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "AssignServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LtdCompanies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DirectorName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CompanyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LtdCompanies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SoleTraders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UTR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoleTraders", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LtdCompanies");

            migrationBuilder.DropTable(
                name: "SoleTraders");

            migrationBuilder.DropColumn(
                name: "LtdCompaniesID",
                table: "AssignServices");

            migrationBuilder.DropColumn(
                name: "SoleTradersID",
                table: "AssignServices");

            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "AssignServices");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "AssignServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DirectorName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UTR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isLTDCompany = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignServices_ClientID",
                table: "AssignServices",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignServices_Clients_ClientID",
                table: "AssignServices",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
