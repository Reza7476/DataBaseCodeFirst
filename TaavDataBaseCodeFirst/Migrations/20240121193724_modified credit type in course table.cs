using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaavDataBaseCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class modifiedcredittypeincoursetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CreditType",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditType",
                table: "Courses");

            migrationBuilder.AddColumn<bool>(
                name: "Type",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
