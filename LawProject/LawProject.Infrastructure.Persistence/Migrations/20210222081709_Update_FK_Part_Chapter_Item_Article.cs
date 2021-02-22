using Microsoft.EntityFrameworkCore.Migrations;

namespace LawProject.Infrastructure.Persistence.Migrations
{
    public partial class Update_FK_Part_Chapter_Item_Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Chapters_ChapterChapID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_LegalDocuments_LegalDocumentLegalID",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_LegalDocumentLegalID",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Items_ChapterChapID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LegalDocumentLegalID",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ChapterChapID",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LegalID",
                table: "Parts",
                column: "LegalID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChapID",
                table: "Items",
                column: "ChapID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Chapters_ChapID",
                table: "Items",
                column: "ChapID",
                principalTable: "Chapters",
                principalColumn: "ChapID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_LegalDocuments_LegalID",
                table: "Parts",
                column: "LegalID",
                principalTable: "LegalDocuments",
                principalColumn: "LegalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Chapters_ChapID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_LegalDocuments_LegalID",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_LegalID",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Items_ChapID",
                table: "Items");

            migrationBuilder.AddColumn<long>(
                name: "LegalDocumentLegalID",
                table: "Parts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ChapterChapID",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LegalDocumentLegalID",
                table: "Parts",
                column: "LegalDocumentLegalID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChapterChapID",
                table: "Items",
                column: "ChapterChapID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Chapters_ChapterChapID",
                table: "Items",
                column: "ChapterChapID",
                principalTable: "Chapters",
                principalColumn: "ChapID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_LegalDocuments_LegalDocumentLegalID",
                table: "Parts",
                column: "LegalDocumentLegalID",
                principalTable: "LegalDocuments",
                principalColumn: "LegalID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
