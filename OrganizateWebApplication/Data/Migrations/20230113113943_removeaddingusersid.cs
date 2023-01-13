using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizateWebApplication.Data.Migrations
{
    public partial class removeaddingusersid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Assignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
