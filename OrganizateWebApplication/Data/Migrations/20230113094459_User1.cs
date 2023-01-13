using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizateWebApplication.Data.Migrations
{
    public partial class User1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
