using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class booknoteupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookNotes_Books_BookId1",
                table: "BookNotes");

            migrationBuilder.DropIndex(
                name: "IX_BookNotes_BookId1",
                table: "BookNotes");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "BookNotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "BookNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookNotes_BookId1",
                table: "BookNotes",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookNotes_Books_BookId1",
                table: "BookNotes",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
