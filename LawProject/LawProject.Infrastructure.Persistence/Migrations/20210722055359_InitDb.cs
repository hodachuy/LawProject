using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawProject.Infrastructure.Persistence.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Data = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityID);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    AgencyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PAgencyID = table.Column<long>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.AgencyID);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Alias = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PAreaID = table.Column<long>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsTypes",
                columns: table => new
                {
                    DocID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PDocID = table.Column<long>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsTypes", x => x.DocID);
                });

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    EditorID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PEditorID = table.Column<long>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.EditorID);
                });

            migrationBuilder.CreateTable(
                name: "LawOffices",
                columns: table => new
                {
                    LawOfficeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    Website = table.Column<string>(unicode: false, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    LegalRepresentativeName = table.Column<string>(nullable: true),
                    DistrictID = table.Column<int>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawOffices", x => x.LawOfficeID);
                });

            migrationBuilder.CreateTable(
                name: "Lawyers",
                columns: table => new
                {
                    LawyerID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Areas = table.Column<string>(nullable: true),
                    AreaTitles = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    ExperienceYear = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Website = table.Column<string>(unicode: false, nullable: true),
                    SocialNetwork = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    AccountID = table.Column<string>(nullable: false),
                    LawOfficeID = table.Column<long>(nullable: true),
                    DistrictID = table.Column<int>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyers", x => x.LawyerID);
                });

            migrationBuilder.CreateTable(
                name: "LegalDocumentGroups",
                columns: table => new
                {
                    LegalGroupID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Alias = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<long>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocumentGroups", x => x.LegalGroupID);
                });

            migrationBuilder.CreateTable(
                name: "LegalDocumentRelates",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalSourceID = table.Column<long>(nullable: false),
                    LegalRelateID = table.Column<long>(nullable: false),
                    LegalTypeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocumentRelates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LegalDocumentTypes",
                columns: table => new
                {
                    LegalTypeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Alias = table.Column<string>(maxLength: 350, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocumentTypes", x => x.LegalTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: false),
                    SenderID = table.Column<int>(nullable: true),
                    RecipientID = table.Column<int>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    EntityID = table.Column<string>(nullable: true),
                    StatusValue = table.Column<int>(nullable: false, defaultValue: 1),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Content = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    Alias = table.Column<string>(maxLength: 350, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageID);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostCategoryID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
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
                name: "Provinces",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Type = table.Column<string>(nullable: true),
                    TelephoneCode = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UploadFiles",
                columns: table => new
                {
                    FileID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    QuesID = table.Column<long>(nullable: true),
                    CommentID = table.Column<long>(nullable: true),
                    AnswerID = table.Column<long>(nullable: true),
                    AccountID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFiles", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    QuesCode = table.Column<string>(nullable: false),
                    QuesContent = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AccountID = table.Column<string>(nullable: false),
                    AreaID = table.Column<long>(nullable: true),
                    QuesContentText = table.Column<string>(nullable: true),
                    StatusValue = table.Column<int>(nullable: false, defaultValue: 1),
                    IsTrained = table.Column<bool>(nullable: false, defaultValue: false),
                    ViewCount = table.Column<long>(nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuesID);
                    table.ForeignKey(
                        name: "FK_Questions_Areas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    Alias = table.Column<string>(type: "varchar", maxLength: 350, nullable: false),
                    PostCategoryID = table.Column<long>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 550, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    ViewCount = table.Column<int>(nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_PostCategoryID",
                        column: x => x.PostCategoryID,
                        principalTable: "PostCategories",
                        principalColumn: "PostCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Type = table.Column<string>(nullable: true),
                    LatiLongTude = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AnswerContent = table.Column<string>(nullable: true),
                    AccountID = table.Column<string>(nullable: true),
                    QuesID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuesID",
                        column: x => x.QuesID,
                        principalTable: "Questions",
                        principalColumn: "QuesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionComments",
                columns: table => new
                {
                    CommentID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    ContentText = table.Column<string>(nullable: true),
                    IsSolution = table.Column<bool>(nullable: false, defaultValue: false),
                    FlaggedAsSpam = table.Column<bool>(nullable: false, defaultValue: false),
                    IpAddress = table.Column<string>(nullable: true),
                    Pending = table.Column<bool>(nullable: false, defaultValue: false),
                    AccountID = table.Column<string>(nullable: false),
                    QuesID = table.Column<long>(nullable: false),
                    VoteLike = table.Column<long>(nullable: false, defaultValue: 0L),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_QuestionComments_Questions_QuesID",
                        column: x => x.QuesID,
                        principalTable: "Questions",
                        principalColumn: "QuesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTags",
                columns: table => new
                {
                    QuesID = table.Column<long>(nullable: false),
                    TagID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTags", x => new { x.QuesID, x.TagID });
                    table.ForeignKey(
                        name: "FK_QuestionTags_Questions_QuesID",
                        column: x => x.QuesID,
                        principalTable: "Questions",
                        principalColumn: "QuesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTags_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostID = table.Column<long>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "LegalDocuments",
                columns: table => new
                {
                    LegalID = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    IssuedDate = table.Column<DateTime>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    PublishNo = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    DocTypeID = table.Column<long>(nullable: true),
                    AgencyID = table.Column<long>(nullable: true),
                    AreaID = table.Column<long>(nullable: true),
                    LegalCode = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SigningTitle = table.Column<string>(nullable: true),
                    SignerName = table.Column<string>(nullable: true),
                    ViewCount = table.Column<long>(nullable: false, defaultValue: 0L),
                    EditorID = table.Column<long>(nullable: true),
                    LegalTypeID = table.Column<long>(nullable: true),
                    LegalRefID = table.Column<long>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    TableOfContents = table.Column<string>(nullable: true),
                    LegalGroupID = table.Column<long>(nullable: false),
                    StatusValue = table.Column<int>(nullable: false),
                    EnglishContent = table.Column<string>(nullable: true),
                    BookAuthor = table.Column<string>(nullable: true),
                    CombineAgencyIDs = table.Column<string>(nullable: true),
                    FTS_FullContent = table.Column<string>(nullable: true),
                    DistrictID = table.Column<int>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: true),
                    FTS_FullTitle = table.Column<string>(nullable: true),
                    FooterRecipients = table.Column<string>(nullable: true),
                    FooterSigner = table.Column<string>(nullable: true),
                    FooterAppendix = table.Column<string>(nullable: true),
                    IsTraining = table.Column<bool>(nullable: false, defaultValue: false),
                    IsHasAppendix = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalDocuments", x => x.LegalID);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_Agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "Agencies",
                        principalColumn: "AgencyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_Areas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_DocumentsTypes_DocTypeID",
                        column: x => x.DocTypeID,
                        principalTable: "DocumentsTypes",
                        principalColumn: "DocID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_Editors_EditorID",
                        column: x => x.EditorID,
                        principalTable: "Editors",
                        principalColumn: "EditorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_LegalDocumentGroups_LegalID",
                        column: x => x.LegalID,
                        principalTable: "LegalDocumentGroups",
                        principalColumn: "LegalGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_LegalDocumentTypes_LegalTypeID",
                        column: x => x.LegalTypeID,
                        principalTable: "LegalDocumentTypes",
                        principalColumn: "LegalTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalDocuments_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Type = table.Column<string>(nullable: true),
                    LatiLongTude = table.Column<string>(nullable: true),
                    DistrictID = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0),
                    IsPublished = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalDocumentFiles",
                columns: table => new
                {
                    FileID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true),
                    Idx = table.Column<int>(nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    LegalID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartID);
                    table.ForeignKey(
                        name: "FK_Parts_LegalDocuments_LegalID",
                        column: x => x.LegalID,
                        principalTable: "LegalDocuments",
                        principalColumn: "LegalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    ChapID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartID = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Contents = table.Column<string>(nullable: true),
                    Idx = table.Column<int>(nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LegalID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.ChapID);
                    table.ForeignKey(
                        name: "FK_Chapters_Parts_PartID",
                        column: x => x.PartID,
                        principalTable: "Parts",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapID = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true),
                    Idx = table.Column<int>(nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_Chapters_ChapID",
                        column: x => x.ChapID,
                        principalTable: "Chapters",
                        principalColumn: "ChapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Contents = table.Column<string>(nullable: true),
                    Idx = table.Column<int>(nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LegalID = table.Column<long>(nullable: false),
                    DocAttach = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuesID",
                table: "Answers",
                column: "QuesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ItemID",
                table: "Articles",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_PartID",
                table: "Chapters",
                column: "PartID");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceID",
                table: "Districts",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChapID",
                table: "Items",
                column: "ChapID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocumentFiles_LegalID",
                table: "LegalDocumentFiles",
                column: "LegalID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_AgencyID",
                table: "LegalDocuments",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_AreaID",
                table: "LegalDocuments",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_DistrictID",
                table: "LegalDocuments",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_DocTypeID",
                table: "LegalDocuments",
                column: "DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_EditorID",
                table: "LegalDocuments",
                column: "EditorID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_LegalTypeID",
                table: "LegalDocuments",
                column: "LegalTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalDocuments_ProvinceID",
                table: "LegalDocuments",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LegalID",
                table: "Parts",
                column: "LegalID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryID",
                table: "Posts",
                column: "PostCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagID",
                table: "PostTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionComments_QuesID",
                table: "QuestionComments",
                column: "QuesID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AreaID",
                table: "Questions",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTags_TagID",
                table: "QuestionTags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DistrictID",
                table: "Wards",
                column: "DistrictID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "LawOffices");

            migrationBuilder.DropTable(
                name: "Lawyers");

            migrationBuilder.DropTable(
                name: "LegalDocumentFiles");

            migrationBuilder.DropTable(
                name: "LegalDocumentRelates");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "QuestionComments");

            migrationBuilder.DropTable(
                name: "QuestionTags");

            migrationBuilder.DropTable(
                name: "UploadFiles");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "LegalDocuments");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "DocumentsTypes");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropTable(
                name: "LegalDocumentGroups");

            migrationBuilder.DropTable(
                name: "LegalDocumentTypes");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
