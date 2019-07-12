using Microsoft.EntityFrameworkCore.Migrations;

namespace SisifoNotes.Web.Migrations
{
    public partial class A41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "body",
                table: "Notes",
                newName: "Body");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Notes",
                newName: "body");
        }
    }
}
