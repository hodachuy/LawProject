using Microsoft.EntityFrameworkCore.Migrations;

namespace LawProject.Infrastructure.Persistence.Migrations
{
    public partial class EditPropertyQuestionLegal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsHasAppendix",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "LegalDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "HasTrained",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAppendix",
                table: "LegalDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTrained",
                table: "LegalDocuments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTrained",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "HasAppendix",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "HasTrained",
                table: "LegalDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrained",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHasAppendix",
                table: "LegalDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrained",
                table: "LegalDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
