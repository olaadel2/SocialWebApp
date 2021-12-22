using Microsoft.EntityFrameworkCore.Migrations;

namespace Day2core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_blog_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Groups_group_id",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "group_id",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "blog_id",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_blog_id",
                table: "Posts",
                column: "blog_id",
                principalTable: "Blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Groups_group_id",
                table: "Posts",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_blog_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Groups_group_id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "group_id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "blog_id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_blog_id",
                table: "Posts",
                column: "blog_id",
                principalTable: "Blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Groups_group_id",
                table: "Posts",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
