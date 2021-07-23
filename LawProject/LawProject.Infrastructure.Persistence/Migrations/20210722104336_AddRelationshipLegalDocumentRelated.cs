using Microsoft.EntityFrameworkCore.Migrations;

namespace LawProject.Infrastructure.Persistence.Migrations
{
    public partial class AddRelationshipLegalDocumentRelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTraining",
                table: "LegalDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrained",
                table: "LegalDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocumentRelates_LegalSourceID",
                table: "LegalDocumentRelates",
                column: "LegalSourceID");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalDocumentRelates_LegalDocuments_LegalSourceID",
                table: "LegalDocumentRelates",
                column: "LegalSourceID",
                principalTable: "LegalDocuments",
                principalColumn: "LegalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalDocumentRelates_LegalDocuments_LegalSourceID",
                table: "LegalDocumentRelates");

            migrationBuilder.DropIndex(
                name: "IX_LegalDocumentRelates_LegalSourceID",
                table: "LegalDocumentRelates");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "LegalDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "IsTraining",
                table: "LegalDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
