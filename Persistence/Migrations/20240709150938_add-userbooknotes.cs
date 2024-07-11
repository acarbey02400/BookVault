using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class adduserbooknotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BookNotes_BookNoteId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BookNoteId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookNoteId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserBookNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookNoteId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBookNote_BookNotes_BookNoteId",
                        column: x => x.BookNoteId,
                        principalTable: "BookNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookNote_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBookNote_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBookNote_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBookNote_BookNoteId",
                table: "UserBookNote",
                column: "BookNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookNote_CreatedById",
                table: "UserBookNote",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookNote_UpdatedById",
                table: "UserBookNote",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookNote_UserId",
                table: "UserBookNote",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBookNote");

            migrationBuilder.AddColumn<int>(
                name: "BookNoteId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BookNoteId",
                table: "Users",
                column: "BookNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BookNotes_BookNoteId",
                table: "Users",
                column: "BookNoteId",
                principalTable: "BookNotes",
                principalColumn: "Id");
        }
    }
}
