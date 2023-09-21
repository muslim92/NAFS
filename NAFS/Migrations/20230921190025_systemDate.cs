using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAFS.Migrations
{
    /// <inheritdoc />
    public partial class systemDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SysDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysDate",
                table: "SoleTraders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysDate",
                table: "LtdCompanies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysDate",
                table: "AssignServices",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SysDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SysDate",
                table: "SoleTraders");

            migrationBuilder.DropColumn(
                name: "SysDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SysDate",
                table: "LtdCompanies");

            migrationBuilder.DropColumn(
                name: "SysDate",
                table: "AssignServices");
        }
    }
}
