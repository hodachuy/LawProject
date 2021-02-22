using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LawProject.Infrastructure.Persistence.Migrations
{
    public partial class AddPost_PostCategory_PostTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LegalDocumentLegalID",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ChapterChapID",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostCategoryID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Alias = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 550, nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.PostCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    Alias = table.Column<string>(type: "varchar", maxLength: 350, nullable: false),
                    PostCategoryID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 550, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false, defaultValue: false),
                    ViewCount = table.Column<int>(nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_PostID",
                        column: x => x.PostID,
                        principalTable: "PostCategories",
                        principalColumn: "PostCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false),
                    TagID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostID, x.TagID });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LegalDocumentLegalID",
                table: "Parts",
                column: "LegalDocumentLegalID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChapterChapID",
                table: "Items",
                column: "ChapterChapID");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_PartID",
                table: "Chapters",
                column: "PartID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ItemID",
                table: "Articles",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagID",
                table: "PostTags",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Items_ItemID",
                table: "Articles",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Parts_PartID",
                table: "Chapters",
                column: "PartID",
                principalTable: "Parts",
                principalColumn: "PartID",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Items_ItemID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Parts_PartID",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Chapters_ChapterChapID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_LegalDocuments_LegalDocumentLegalID",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropIndex(
                name: "IX_Parts_LegalDocumentLegalID",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Items_ChapterChapID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_PartID",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ItemID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "LegalDocumentLegalID",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ChapterChapID",
                table: "Items");
        }
    }
}
