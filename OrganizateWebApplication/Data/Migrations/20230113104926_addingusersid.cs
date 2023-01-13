using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizateWebApplication.Data.Migrations
{
    public partial class addingusersid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_ApplicationUserId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_ApplicationUserId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Assignment");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Assignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Assignment");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Assignment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ApplicationUserId",
                table: "Assignment",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_ApplicationUserId",
                table: "Assignment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
