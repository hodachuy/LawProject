using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LawProject.Infrastructure.Persistence.Migrations
{
    public partial class ChangeNamePropertyOffEntityTableAndAddLegalDocumentFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategories_PostID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LegalID",
                table: "UploadFiles");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsTraining",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "QuestionComments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "LawOffices");

            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "LawOffices");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LegalGroupID",
                table: "DocumentsTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Answers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrained",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Pending",
                table: "QuestionComments",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuestionComments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "PostID",
                table: "PostTags",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "PostCategoryID",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "PostID",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "PostCategoryID",
                table: "PostCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Parts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LegalDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "LegalDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lawyers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Lawyers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LawOffices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "LawOffices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "PEditorID",
                table: "Editors",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Chapters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Answers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LegalDocumentFiles",
                columns: table => new
                {
                    FileID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LegalID = table.Column<long>(nullable: false),
                    AccountID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocumentFiles", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_LegalDocumentFiles_LegalDocuments_LegalID",
                        column: x => x.LegalID,
                        principalTable: "LegalDocuments",
                        principalColumn: "LegalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryID",
                table: "Posts",
                column: "PostCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocumentFiles_LegalID",
                table: "LegalDocumentFiles",
                column: "LegalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCategories_PostCategoryID",
                table: "Posts",
                column: "PostCategoryID",
                principalTable: "PostCategories",
                principalColumn: "PostCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategories_PostCategoryID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "LegalDocumentFiles");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostCategoryID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsTrained",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuestionComments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "LegalDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Lawyers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LawOffices");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "LawOffices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Answers");

            migrationBuilder.AddColumn<long>(
                name: "LegalID",
                table: "UploadFiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTraining",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Pending",
                table: "QuestionComments",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "QuestionComments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "PostTags",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "PostCategoryID",
                table: "Posts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Posts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PostCategoryID",
                table: "PostCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PostCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Parts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Pages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "LegalDocuments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "LegalDocuments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Lawyers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Lawyers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "LawOffices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "LawOffices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "PEditorID",
                table: "Editors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LegalGroupID",
                table: "DocumentsTypes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Chapters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Articles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Answers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCategories_PostID",
                table: "Posts",
                column: "PostID",
                principalTable: "PostCategories",
                principalColumn: "PostCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
