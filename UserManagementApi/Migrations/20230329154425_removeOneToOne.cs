using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    public partial class removeOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_Users_UserID",
                table: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_UserID",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "UserImageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserImageId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "UserImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserID",
                table: "UserImages",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_Users_UserID",
                table: "UserImages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
