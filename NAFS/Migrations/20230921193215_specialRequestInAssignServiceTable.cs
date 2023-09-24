using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAFS.Migrations
{
    /// <inheritdoc />
    public partial class specialRequestInAssignServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialRequest",
                table: "AssignServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialRequest",
                table: "AssignServices");
        }
    }
}
