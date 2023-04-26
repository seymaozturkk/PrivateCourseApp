using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrivateClassApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OtherEducations = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortInfo = table.Column<string>(type: "TEXT", nullable: true),
                    EducationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abouts_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityEducations",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    EducationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityEducations", x => new { x.UniversityId, x.EducationId });
                    table.ForeignKey(
                        name: "FK_UniversityEducations_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityEducations_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AboutId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    DayOfWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAvailabilities_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonCategories",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCategories", x => new { x.LessonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_LessonCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonCategories_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    LikeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedItems_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedItems_Likes_LikeId",
                        column: x => x.LikeId,
                        principalTable: "Likes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ZoomLink = table.Column<string>(type: "TEXT", nullable: true),
                    ReservationState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a1efb35-d256-4487-9c32-d4e81fbb4467", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", null, "Kullanıcılar", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "Url", "UserName", "UserType" },
                values: new object[,]
                {
                    { "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd", 0, new DateTime(1994, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "bcf6dc42-3be3-449d-8785-89513d5e21d1", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2070), "s.kocak@gmail.com", true, "Selin", 1, "Koçak", false, null, "S.KOCAK@GMAIL.COM", "SELINKOCAK", "SELINKOCAK", "AQAAAAIAAYagAAAAEG2MQJgnacAKlHyid+Azn2b+ngswWXY0VvAPKjci00a3xYUDnTxBOxpSfFa6maQFPg==", null, false, "3b9f4be4-588e-4d6d-aa89-a6948981f1ea", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2071), "selin-kocak", "selinkocak", 2 },
                    { "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d", 0, new DateTime(1995, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "581b8b54-7599-4077-8122-0ebbd3b290fb", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2110), "beyzakaraca@gmail.com", true, "Beyza", 1, "Karaca", false, null, "BEYZAKARACA@GMAIL.COM", "BEYZAKARACA", "BEYZAKARACA", "AQAAAAIAAYagAAAAEB7hJuSxFfJcxjpXzFe9TjezriEvK3cDogUmHS3Alq09jGWJXMZCJmvrtVx8YoW4HQ==", null, false, "23168237-4ffd-4ee0-9a23-7b3d7158b1cd", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2111), "beyza-karaca", "beyza.karaca", 2 },
                    { "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5", 0, new DateTime(1996, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "757987df-07bf-4eee-96cd-d949f5afc6a4", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1948), "g.aksoy@hotmail.com", true, "Gizem", 1, "Aksoy", false, null, "G.AKSOY@HOTMAIL.COM", "GIZEMAKSOY", "GIZEMAKSOY", "AQAAAAIAAYagAAAAEDZx6w9w7Y+RnxSRaZXDJeMp+6ccnTEBRGknGIgzpQPXCzZaj1H9sNA8UWJC8yrgVg==", null, false, "41a8ba1b-e0f8-4e94-b2a5-829284d8f8bd", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1949), "gizem-aksoy", "gizem.aksoy", 2 },
                    { "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10", 0, new DateTime(1997, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "826a6511-6309-497a-8cda-0806dba2244c", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1796), "ayse.demir@gmail.com", true, "Ayşe", 1, "Demir", false, null, "AYSE.DEMIR@GMAIL.COM", "AYSEDEMIR", "AYSEDEMIR", "AQAAAAIAAYagAAAAEKCVj87CORkq+E0OUAg60n92iTNNYseReVmdyCPEtwqA8uafjzwJT6nQTFFvelM6Kg==", null, false, "1584668d-0445-4e36-b9e8-cb3d8ac58230", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1798), "ayse-demir", "ayse.demir", 2 },
                    { "715d80fc-4fff-4509-8f89-ea1d4c0b03de", 0, new DateTime(1999, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "e6278dc7-3988-4a11-872b-14ff2046e89e", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1693), "cankusseyma@gmail.com", true, "Şeyma", 1, "Cankuş", false, null, "CANKUSSEYMA@GMAIL.COM", "SEYMACANKUS", "SEYMACANKUS", "AQAAAAIAAYagAAAAEBEdD2MOsjrXdGurwWkVIYG0gzMgbnM6TcIVDBu/SxayAIY7vA2UaHByiYpIUYz41A==", null, false, "aadc6914-0515-4535-be09-c689f1698196", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1713), "seyma-cankus", "seymacankus", 0 },
                    { "8a55c638-baff-413a-bdb9-b9b41f768b71", 0, new DateTime(1996, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "9ef2ddfb-7067-4cad-b421-eb158a76bd2b", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2165), "z.yilmaz@gmail.com", true, "Zeynep", 1, "Yılmaz", false, null, "Z.YILMAZ@GMAIL.COM", "ZEYNEPYILMAZ", "ZEYNEPYILMAZ", "AQAAAAIAAYagAAAAEGXXY7wSBohcc6yxhXn9+lo2qSN0hKVzXsno9HjZ/6kbyy5llakWV3yPT73TrutjeQ==", null, false, "15a77fe1-29fa-4217-98fe-ec831cf34a90", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2166), "zeynep-yilmaz", "zeynep.yilmaz", 2 },
                    { "a0d9c91b-3e6c-4528-a31e-58a47be27108", 0, new DateTime(1997, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "faa83efc-e512-4fc9-a9a8-e7ed5cd0145b", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2039), "e.ozturk@hotmail.com", true, "Emre", 0, "Öztürk", false, null, "E.OZTURK@HOTMAIL.COM", "EMREOZTURK", "EMREOZTURK", "AQAAAAIAAYagAAAAEKdZg+rJcv94wc+C2BQWWlcXz1mKY0spbKVEpu5qW6YVOMv7jl/8z4PxJ8Smyr78gg==", null, false, "2c376785-06e1-40df-a2cc-f05c6e53b078", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2043), "emre-ozturk", "emre_ozturk", 2 },
                    { "a176cd80-4d75-47a8-b51a-6d059790bfe7", 0, new DateTime(2001, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "cbff110a-696b-4ab4-b891-69d5d29005a3", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2433), "sefaozturk@gmail.com", true, "Sefa", 0, "Öztürk", false, null, "SEFAOZTURK@GMAIL.COM", "SEFAOZTURK", "SEFAOZTURK", "AQAAAAIAAYagAAAAELxx7e3HoqqsP33Ifz5Z+UMuR7LBFGWtvzQ5xaDAxXKJ6jRjdjsfLmVlOcnAuNg7tA==", null, false, "ef2bf7d5-e06f-4bee-9dc2-6ffdcfc1e1a5", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2435), "sefa-ozturk", "sefaozturk", 1 },
                    { "a17a2a35-1b72-42af-8d68-0b55faa60f22", 0, new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "b269a199-a8cc-4013-87e6-5a4c37f0d93a", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1839), "elifsahin@gmail.com", true, "Elif", 1, "Şahin", false, null, "ELIFSAHIN@GMAIL.COM", "ELIFSAHIN", "ELIFSAHIN", "AQAAAAIAAYagAAAAEKnhlQRlONvRG1hEvedUFpBoHQdAwGqVgtQgW8n+PS1OEvp3WDkIpfby48l0tx/Cdg==", null, false, "3cc8fa6b-a768-4b66-a0ac-3f71c0ef2194", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1840), "elif-sahin", "elif.sahin", 2 },
                    { "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad", 0, new DateTime(1994, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "10dd647a-69af-42eb-a279-f2e3975c6501", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2193), "serdar.kara@yahoo.com", true, "Serdar", 0, "Kara", false, null, "SERDAR.KARA@YAHOO.COM", "SERDARKARA", "SERDARKARA", "AQAAAAIAAYagAAAAEPQLbPXufu3CLeCsmyaKAXxRkBpPX0R9nEgHkdWPZyycvYIgQdQvL6edW42qWSeQ5A==", null, false, "9b216a08-85af-42b2-a38f-736047ed0d97", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2195), "serdar-kara", "serdarkara", 2 },
                    { "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f", 0, new DateTime(1998, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "a0793a8a-feb2-4d38-8cef-89cd6d0654a6", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2090), "deniz.sahin@yahoo.com", true, "Deniz", 0, "Şahin", false, null, "DENIZ.SAHIN@YAHOO.COM", "DENIZSAHIN", "DENIZSAHIN", "AQAAAAIAAYagAAAAEAMlVT8T3z61znJD1Q8TEouzoiUxjilfYgXZlTWlSv0KC7cepB4CUEKeIUVuAtQmIg==", null, false, "0741102e-ec86-4dd8-b844-0a2b718841ca", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2092), "deniz-sahin", "deniz.sahin", 2 },
                    { "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7", 0, new DateTime(1995, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ce17b608-e9ec-4ec5-a1e2-22fb82e09d1e", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1757), "aliyilmaz@hotmail.com", true, "Ali", 0, "Yılmaz", false, null, "ALIYILMAZ@HOTMAIL.COM", "ALIYILMAZ", "ALIYILMAZ", "AQAAAAIAAYagAAAAEJXH9DX5avm9FLJ+B6ZfddAa4pJPp0lFyjiheujav69Zz5FlOCeTY7HCQ08XUkXmkg==", null, false, "8a8c0ee7-5d9e-4152-b633-8623747d9e84", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1759), "ali-yilmaz", "aliyilmaz", 2 },
                    { "cc95335c-9a83-4a22-8f8e-b083dd6fc663", 0, new DateTime(1997, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "8dbfec7e-2da2-4368-9104-a5374b43df3e", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2214), "ayseaydin@gmail.com", true, "Ayşe", 1, "Aydın", false, null, "AYSEAYDIN@GMAIL.COM", "AYSEAYDIN", "AYSEAYDIN", "AQAAAAIAAYagAAAAEA3ceCfEymwzXIIlxnLaoNEUd+616HL0SjqLyTfJvl8cu9aWXNMgHTZn2Xzy0lsLRw==", null, false, "b8bc244c-3a34-43ed-b865-1937f3b6f25f", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2216), "ayse-aydin", "ayseaydin", 2 },
                    { "d10e29b9-9f64-444d-8d0c-7a69e00e13b7", 0, new DateTime(1999, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "83f868a9-4d95-44b9-b3de-229be233cb2b", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1989), "esra.gultekin@gmail.com", true, "Esra", 1, "Gültekin", false, null, "ESRA.GULTEKIN@GMAIL.COM", "ESRAGULTEKIN", "ESRAGULTEKIN", "AQAAAAIAAYagAAAAEKp0e0fciyunnim5hG4WT1+uax6CRM/yQygna6L2bbXk1BN9KeeVK8tSHpJ99KWsnA==", null, false, "278d2520-6f79-4c88-b035-1ee82a5fe7fc", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1991), "esra-gultekin", "esra_gultekin", 2 },
                    { "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2", 0, new DateTime(1992, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "49b649cd-538c-44fb-a984-b1956cfedfc2", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1924), "mustafa.arslan@gmail.com", true, "Mustafa", 0, "Arslan", false, null, "MUSTAFA.ARSLAN@GMAIL.COM", "MUSTAFAARSLAN", "MARSLAN", "AQAAAAIAAYagAAAAELuR/ymwsYNifge9lUggq80TehoBZcf31rRiVr9ly0spcNMZhkjV6pGDiBJqXMwyGg==", null, false, "ecb9aae1-6a92-4593-8f25-5ca7977fe00c", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1927), "mustafa-arslan", "m.arslan", 2 },
                    { "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd", 0, new DateTime(1992, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "8aeea674-d8e7-4e0a-93ab-3c6efdafb15b", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2134), "yasin.kilic@hotmail.com", true, "Yasin", 0, "Kılıç", false, null, "YASIN.KILIC@HOTMAIL.COM", "YASINKILIC", "YASINKILIC", "AQAAAAIAAYagAAAAECREdSALE8yMsBiQUsaryhxrAMpj/HmmGmVlA04aCVFo4rdxupqUKHkLa5YVskGCvg==", null, false, "e09f19a6-d1e2-4bd7-a641-4a3995b7a96f", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(2135), "yasin-kilic", "yasin.kilic", 2 },
                    { "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4", 0, new DateTime(1994, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "e0572e01-1ca7-4bde-a5af-7d16365f64b7", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1818), "m.kaya@hotmail.com", true, "Mehmet", 0, "Kaya", false, null, "M.KAYA@HOTMAIL.COM", "MEHMETKAYA", "MEHMETKAYA", "AQAAAAIAAYagAAAAEOczBo8Z16x8PnjHd1LHYoF+AUSY61ZaiLSku2h8+A07Gqgkv8HzDoxIdRTVyrc+Yg==", null, false, "da689736-5586-4842-9ec9-01d48688da91", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1819), "mehmet-kaya", "mehmet.kaya", 2 },
                    { "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1", 0, new DateTime(1993, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5614fa0-54e0-45e0-9cf8-e651f971c574", new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1970), "bgunes@outlook.com", true, "Burak", 0, "Güneş", false, null, "BGUNES@OUTLOOK.COM", "BURAKGUNES", "BURAKGUNES", "AQAAAAIAAYagAAAAEPHY3ap1Rms4uJ1k2dPGgFEZ01c1s+ZqMIfn2YZ6rEw1cwGA/gJUZQJPBUfOISFTvg==", null, false, "3fa8a0cd-d9e6-4798-a8f6-d3026dd2daaf", false, new DateTime(2023, 4, 25, 18, 8, 20, 414, DateTimeKind.Local).AddTicks(1971), "burak-gunes", "burakgunes", 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5497), "Edebiyat", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5502), "edebiyat" },
                    { 2, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5504), "Matematik", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5505), "matematik" },
                    { 3, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5506), "Edebiyat", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5507), "edebiyat" },
                    { 4, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5508), "Müzik", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5509), "muzik" },
                    { 5, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5510), "Türkçe", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5511), "turkce" },
                    { 6, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5512), "Kimya", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5513), "kimya" },
                    { 7, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5514), "Biyoloji", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5515), "biyoloji" },
                    { 8, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5516), "Fizik", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5517), "fizik" },
                    { 9, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5519), "İngilizce", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5519), "ingilizce" },
                    { 10, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5521), "Fen Bilimleri", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5521), "fen-bilimleri" },
                    { 11, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5523), "Sosyal Bilimler", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5523), "sosyal-bilimler" },
                    { 12, new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5525), "Psikoloji", new DateTime(2023, 4, 25, 18, 8, 23, 275, DateTimeKind.Local).AddTicks(5525), "psikoloji" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "OtherEducations" },
                values: new object[,]
                {
                    { 1, "Hafıza Teknikleri Eğitimi, Akıl ve Zeka Oyunları Eğitimi" },
                    { 2, "Anlayarak Hızlı Okuma Eğitimi" },
                    { 3, "Eğiticinin Eğitimi" },
                    { 4, "Hafıza Teknikleri Eğitimi, Satranç Eğitimi" },
                    { 5, "Yaratıcı Yazarlık Eğitimi" },
                    { 6, "Çan Eğitimi" },
                    { 7, "Osmanlı Türkçesi Eğitimi" },
                    { 8, null },
                    { 9, "Hafıza Teknikleri Eğitimi" },
                    { 10, "Eğiticinin Eğitimi" },
                    { 11, "Öğrenci Koçluğu Eğitimi, Oyun Terapisi Eğitimi" },
                    { 12, null },
                    { 13, "Bitki Bilimleri Eğitimi" },
                    { 14, "Organik Kimya Eğitimi" },
                    { 15, null },
                    { 16, "Organik Kimya Eğitimi" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "İstanbul Üniversitesi" },
                    { 2, "Boğaziçi Üniversitesi" },
                    { 3, "Orta Doğu Teknik Üniversitesi" },
                    { 4, "Bilkent Üniversitesi" },
                    { 5, "Ankara Üniversitesi" },
                    { 6, "Ege Üniversitesi" },
                    { 7, "İzmir Yüksek Teknoloji Enstitüsü" },
                    { 8, "Sabancı Üniversitesi" },
                    { 9, "Koç Üniversitesi" },
                    { 10, "Yıldız Teknik Üniversitesi" },
                    { 11, "Hacettepe Üniversitesi" },
                    { 12, "İstanbul Teknik Üniversitesi" },
                    { 13, "Ondokuz Mayıs Üniversitesi" },
                    { 14, "Dokuz Eylül Üniversitesi" },
                    { 15, "Akdeniz Üniversitesi" },
                    { 16, "Selçuk Üniversitesi" },
                    { 17, "Adnan Menderes Üniversitesi" },
                    { 18, "Çanakkale Onsekiz Mart Üniversitesi" },
                    { 19, "Anadolu Üniversitesi" },
                    { 20, "Erciyes Üniversitesi" },
                    { 21, "Pamukkale Üniversitesi" },
                    { 29, "Kadir Has Üniversitesi" },
                    { 31, "İstanbul Medeniyet Üniversitesi" },
                    { 32, "İstanbul Ticaret Üniversitesi" },
                    { 33, "Kocaeli Üniversitesi" },
                    { 34, "Atılım Üniversitesi" },
                    { 35, "Bahçeşehir Üniversitesi" },
                    { 36, "Beykent Üniversitesi" },
                    { 37, "Bursa Teknik Üniversitesi" },
                    { 38, "Çankaya Üniversitesi" },
                    { 39, "Düzce Üniversitesi" },
                    { 40, "Fırat Üniversitesi" },
                    { 41, "Galatasaray Üniversitesi" },
                    { 42, "Gazi Üniversitesi" },
                    { 43, "Gebze Teknik Üniversitesi" },
                    { 44, "Gediz Üniversitesi" },
                    { 45, "İzmir Ekonomi Üniversitesi" },
                    { 46, "İzmir Kâtip Çelebi Üniversitesi" },
                    { 47, "Işık Üniversitesi" },
                    { 48, "İzmir Bakırçay Üniversitesi" },
                    { 49, "Maltepe Üniversitesi" },
                    { 50, "Marmara Üniversitesi" },
                    { 51, "Muğla Sıtkı Koçman Üniversitesi" },
                    { 52, "Niğde Ömer Halisdemir Üniversitesi" },
                    { 53, "Ordu Üniversitesi" },
                    { 54, "Özyeğin Üniversitesi" },
                    { 55, "Piri Reis Üniversitesi" },
                    { 56, "Recep Tayyip Erdoğan Üniversitesi" },
                    { 57, "Sakarya Üniversitesi" },
                    { 58, "Sivas Cumhuriyet Üniversitesi" },
                    { 59, "Trakya Üniversitesi" },
                    { 60, "Üsküdar Üniversitesi" },
                    { 61, "Yeditepe Üniversitesi" },
                    { 62, "Yeni Yüzyıl Üniversitesi" },
                    { 63, "Yıldızeli Üniversitesi" },
                    { 64, "Yüzüncü Yıl Üniversitesi" },
                    { 65, "Zirve Üniversitesi" },
                    { 66, "İzmir Ekonomi Üniversitesi" },
                    { 67, "İstanbul Bilgi Üniversitesi" },
                    { 68, "Uludağ Üniversitesi" },
                    { 69, "Harran Üniversitesi" },
                    { 70, "İzmir Demokrasi Üniversitesi" },
                    { 71, "Karadeniz Teknik Üniversitesi" },
                    { 72, "Maltepe Üniversitesi" },
                    { 73, "Mimar Sinan Güzel Sanatlar Üniversitesi" },
                    { 74, "Abdullah Gül Üniversitesi" },
                    { 75, "Ağrı İbrahim Çeçen Üniversitesi" },
                    { 76, "Ahi Evran Üniversitesi" },
                    { 77, "Akdeniz Karpaz Üniversitesi" },
                    { 78, "Aksaray Üniversitesi" },
                    { 79, "Alanya Alaaddin Keykubat Üniversitesi" },
                    { 80, "Alanya Hamdullah Emin Paşa Üniversitesi" },
                    { 81, "Alparslan Türkeş Bilim ve Teknoloji Üniversitesi" },
                    { 82, "Altınbaş Üniversitesi" },
                    { 83, "Amasya Üniversitesi" },
                    { 84, "Anka Teknoloji Üniversitesi" },
                    { 85, "Ankara Hacı Bayram Veli Üniversitesi" },
                    { 86, "Ankara Medipol Üniversitesi" },
                    { 87, "Ankara Sosyal Bilimler Üniversitesi" },
                    { 88, "Antalya Akev Üniversitesi" },
                    { 89, "Ardahan Üniversitesi" },
                    { 90, "Artvin Çoruh Üniversitesi" },
                    { 91, "Atatürk Üniversitesi" },
                    { 92, "Atılım Üniversitesi" },
                    { 93, "Avrasya Üniversitesi" },
                    { 94, "Balıkesir Üniversitesi" },
                    { 95, "Bandırma Onyedi Eylül Üniversitesi" },
                    { 96, "Bartın Üniversitesi" },
                    { 97, "Batman Üniversitesi" },
                    { 98, "Bayburt Üniversitesi" },
                    { 99, "Beykent Üniversitesi" },
                    { 100, "Bezmiâlem Vakıf Üniversitesi" },
                    { 101, "Bilecik Şeyh Edebali Üniversitesi" },
                    { 102, "Bingöl Üniversitesi" },
                    { 103, "Biruni Üniversitesi" },
                    { 104, "Bolu Abant İzzet Baysal Üniversitesi" }
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "EducationId", "Experience", "ShortInfo" },
                values: new object[,]
                {
                    { 1, 1, "İlk matematik öğretmenliği deneyimim, 2 yıl boyunca İstanbul'da ücretli matematik öğretmeni olarak hizmet ettiğim Zihnipaşa İlkokulu oldu. Ayrıca, birkaç yaz boyunca üniversiteye hazırlanan öğrencilere özel dersler vererek çalıştım, referanslarım da belirttiğim öğrencilerin matematik sorularında başarıyı yakalamalarını sağladım.", "İstanbul Üniversitesinden mezun olan bir matematik öğretmeni olarak, öğretmenlik kariyerine devam etmek konusunda çok güçlü bir ilgim var.Hem ortaokul hem de lise seviyelerinde ve ayrıca geleneksel sınıf dışındaki etkinliklerde çalışma deneyimim sayesinde, sunabileceğim çok çeşitli bir geçmişe sahibim." },
                    { 2, 2, "5 yıldan fazla bir süredir Türk Dili ve Edebiyatı öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin dil ve yazma becerilerini geliştirmelerine yardımcı olmak için çeşitli etkinlikler ve projeler tasarladım.", "Lisans ve yüksek lisans eğitimimi Marmara Üniversitesinde tamamladım ve şu anda bir Türk Dili ve Edebiyatı öğretmeniyim. Öğrencilerimi etkileşimli ve eğlenceli derslerle öğrenmeye teşvik ediyorum." },
                    { 3, 3, "10 yıldan fazla bir süredir İngilizce öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin dil becerilerini geliştirmek için öğretim materyalleri oluşturmak ve onların ilgi alanlarına uygun dersler tasarlamak gibi birçok farklı deneyim yaşadım.", "Üniversite eğitimimi Boğaziçi Üniversitesi'nde aldım ve İngilizce öğretmenliği kariyerine yüksek lisans yaparak başladım. Öğrencilerimi sınavlara hazırlarken, iletişim becerilerini geliştirirken ve okuma-yazma becerilerini güçlendirirken destekleyen bir öğretmenim." },
                    { 4, 4, "6 yıldan fazla bir süredir matematik öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin matematik konularını daha iyi anlamalarını sağlamak için özel dersler vermekten, matematik yarışmalarına hazırlamaktan ve matematik kulüpleri oluşturmak gibi farklı deneyimler yaşadım.", "Boğaziçi Üniversitesinde Matematik bölümünden mezun oldum ve matematik öğretmenliği kariyerime devam ediyorum. Öğrencilerime matematiği anlaşılır ve keyifli hale getirmek için çeşitli öğretim materyalleri kullanıyorum." },
                    { 5, 5, "4 yıldan fazla bir süredir Türkçe öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin öğrenme stillerine uygun ders planları hazırlayarak onların Türkçe dilini daha iyi anlamalarına yardımcı oldum. Ayrıca, drama ve hikaye anlatımı gibi farklı etkinliklerle de öğrencilerimin dil becerilerini geliştirmek için çaba harcadım.", "Lisans eğitimimi Ankara Üniversitesinde tamamladım ve Türkçe öğretmenliği yapmaya başladım. Öğrencilerimle etkileşimli dersler yapıyor, onların iletişim becerilerini geliştiriyor ve okuma-yazma becerilerini arttırıyorum." },
                    { 6, 6, "8 yıldan fazla bir süredir Ankara'da müzik öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin müzikal yeteneklerini geliştirmek için onları farklı enstrümanlarla tanıştırdım ve müzik etkinlikleri organize ettim. Ayrıca, müzik kulüpleri oluşturarak öğrencilerimin müzikle ilgili tutkularını desteklemeye çalıştım.", "Müzik eğitimimi Hacettepe Üniversitesinde tamamladım ve şu anda müzik öğretmenliği yapıyorum. Öğrencilerimin müzikal becerilerini geliştirirken, aynı zamanda onların özgüvenlerini arttırmaya çalışıyorum." },
                    { 7, 7, "9 yıldan fazla bir süredir Türk Dili ve Edebiyatı öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin dil becerilerini geliştirmek için çeşitli ders materyalleri oluşturdum ve öğrencilerimin ilgi alanlarına uygun kitaplar seçmelerine yardımcı oldum. Ayrıca, tiyatro ve edebiyat kulüpleri oluşturarak öğrencilerimin Türk edebiyatına olan ilgisini arttırmaya çalıştım.", "Lisans ve yüksek lisans eğitimimi Ankara Üniversitesinde tamamladım ve Türk Dili ve Edebiyatı öğretmenliği yapıyorum. Öğrencilerimin okuma ve yazma becerilerini geliştirirken, Türk edebiyatını sevdirmek için çaba harcıyorum." },
                    { 8, 8, "7 yıldan fazla bir süredir İngilizce öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin sınavlara hazırlanmalarına ve konuşma becerilerini geliştirmelerine yardımcı oldum. Ayrıca, dil öğrenme teknikleri konusunda kendimi sürekli geliştirerek öğrencilerime farklı öğrenme stillerine uygun dersler sunmaya çalışıyorum. Ayrıca, uluslararası öğrencilerle çalışarak, kültürlerarası iletişim becerilerini de geliştirmelerine yardımcı oldum.", "İngilizce öğretmenliği kariyerime lisans eğitimimden sonra başladım ve şu anda ortaokul ve lise öğrencilerine İngilizce dersleri veriyorum. Öğrencilerimle interaktif dersler yaparak, onların dil becerilerini geliştirmeye çalışıyorum." },
                    { 9, 9, "10 yıldan fazla bir süredir fen bilimleri öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin laboratuvar deneyleri yapmalarına ve araştırmalar yapmalarına olanak sağladım. Ayrıca, bilim kulüpleri oluşturarak öğrencilerimin bilimle ilgili tutkularını desteklemeye çalıştım.", "Fen bilimleri öğretmenliği yapmaktayım ve öğrencilerimin bilimsel düşünme becerilerini geliştirmeye odaklanıyorum. Derslerimde öğrencilerimin aktif katılımını teşvik ediyorum ve onları problem çözme ve araştırma yapmaya teşvik ediyorum." },
                    { 10, 10, "5 yıldan fazla bir süredir sosyal bilimler öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin tarih, coğrafya ve sosyal bilimler konularında ilerlemelerini sağladım. Ayrıca, öğrencilerimin araştırma yapma ve sunum yapma becerilerini geliştirmelerine yardımcı oldum.", "Sosyal bilimler öğretmeni olarak öğrencilerimi tarihin önemini anlamaları ve dünya olayları hakkında daha bilinçli olmaları için teşvik ediyorum. Sınıfta tartışma ve analiz yapmayı teşvik ederek, öğrencilerimin eleştirel düşünme becerilerini geliştirmeye çalışıyorum." },
                    { 11, 11, "3 yıldan fazla bir süredir psikoloji öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin duygusal ve sosyal ihtiyaçlarını karşılamak için terapi oturumları düzenledim. Ayrıca, öğrencilerimin stres yönetimi ve özgüvenlerini arttırmalarına yardımcı oldum.", "Psikoloji öğretmeni olarak öğrencilerime akademik ve kişisel gelişimlerinde yardımcı olmaya çalışıyorum. Öğrencilerimle bireysel ve grup terapileri yaparak, onların duygusal ihtiyaçlarını karşılamaya çalışıyorum." },
                    { 12, 12, "8 yıldan fazla bir süredir müzik öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin müzikal yeteneklerini geliştirmelerine yardımcı olmak için özel dersler verdim ve müzik gruplarına liderlik ettim. Ayrıca, okul orkestrası ve korosu gibi gruplarla birlikte çalışarak, öğrencilerimin işbirliği ve takım çalışması becerilerini geliştirmelerine yardımcı oldum.", "Müzik öğretmeni olarak, öğrencilerimin müzikal yeteneklerini keşfetmelerine ve geliştirmelerine yardımcı oluyorum. Farklı enstrümanlar ve müzik türleri hakkında bilgi sahibi olduğum için öğrencilerime geniş bir perspektif sunabiliyorum." },
                    { 13, 13, "10 yıldan fazla bir süredir biyoloji öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin biyoloji konularında başarılı olmaları için özel dersler verdim ve biyoloji kulüpleri kurarak öğrencilerimin ilgisini arttırdım. Ayrıca, biyolojik araştırmalar yaptırdığım öğrenciler yetiştirerek bilimsel yöntemler ve araştırma becerilerini geliştirdim.", "Biyoloji öğretmeni olarak, öğrencilerimin doğal dünya hakkında meraklarını ve ilgilerini uyandırmaya çalışıyorum. Biyolojik süreçleri anlamalarına ve yaşamlarının bir parçası olan canlıların çeşitliliği hakkında bilgi sahibi olmalarına yardımcı oluyorum." },
                    { 14, 14, "7 yıldan fazla bir süredir kimya öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin kimya konularını anlamalarına yardımcı olmak için özel dersler verdim ve kimya kulüpleri kurarak öğrencilerimin ilgisini arttırdım. Ayrıca, okul laboratuvarlarında araştırmalar yaptırdığım öğrenciler yetiştirerek bilimsel yöntemler ve araştırma becerilerini geliştirdim.", "Kimya öğretmeni olarak, öğrencilerimin kimyayı anlamalarına ve uygulamalarını görmelerine yardımcı oluyorum. Farklı kimya konuları hakkında bilgi sahibi olduğum için öğrencilerime geniş bir perspektif sunabiliyorum." },
                    { 15, 15, "5 yıldan fazla bir süredir fizik öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin fizik konularını anlamalarına yardımcı olmak için özel dersler verdim ve fizik kulüpleri kurarak öğrencilerimin ilgisini arttırdım. Ayrıca, okul laboratuvarlarında araştırmalar yaptırdığım öğrenciler yetiştirerek bilimsel yöntemler ve araştırma becerilerini geliştirdim. Ayrıca, öğrencilerimin ilgisini çekmek için farklı fizik deneyleri yaparak, fiziksel fenomenleri uygulamalı olarak göstermeye çalışıyorum.", "Fizik öğretmeni olarak, öğrencilerimin fiziksel dünyayı anlamalarına ve uygulamalarını görmelerine yardımcı oluyorum. Farklı fizik konuları hakkında bilgi sahibi olduğum için öğrencilerime geniş bir perspektif sunabiliyorum." },
                    { 16, 16, "8 yıldan fazla bir süredir organik kimya öğretmenliği yapıyorum. Bu süre zarfında, öğrencilerimin organik kimya konularını anlamalarına yardımcı olmak için özel dersler verdim ve organik kimya kulüpleri kurarak öğrencilerimin ilgisini arttırdım. Ayrıca, okul laboratuvarlarında araştırmalar yaptırdığım öğrenciler yetiştirerek bilimsel yöntemler ve araştırma becerilerini geliştirdim.", "Organik kimya öğretmeni olarak, öğrencilerimin organik bileşikleri anlamalarına ve uygulamalarını görmelerine yardımcı oluyorum. Organik kimya konularında derin bir bilgiye sahibim ve öğrencilerime bu alanda geniş bir perspektif sunuyorum." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10" },
                    { "3a1efb35-d256-4487-9c32-d4e81fbb4467", "715d80fc-4fff-4509-8f89-ea1d4c0b03de" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "8a55c638-baff-413a-bdb9-b9b41f768b71" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "a0d9c91b-3e6c-4528-a31e-58a47be27108" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "a176cd80-4d75-47a8-b51a-6d059790bfe7" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "a17a2a35-1b72-42af-8d68-0b55faa60f22" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "cc95335c-9a83-4a22-8f8e-b083dd6fc663" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "d10e29b9-9f64-444d-8d0c-7a69e00e13b7" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4" },
                    { "831be41c-cb14-4c15-b43d-05570fb2aa01", "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "715d80fc-4fff-4509-8f89-ea1d4c0b03de" },
                    { 2, "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7" },
                    { 3, "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10" },
                    { 4, "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4" },
                    { 5, "a17a2a35-1b72-42af-8d68-0b55faa60f22" },
                    { 6, "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2" },
                    { 7, "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5" },
                    { 8, "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1" },
                    { 9, "d10e29b9-9f64-444d-8d0c-7a69e00e13b7" },
                    { 10, "a0d9c91b-3e6c-4528-a31e-58a47be27108" },
                    { 11, "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd" },
                    { 12, "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f" },
                    { 13, "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d" },
                    { 14, "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd" },
                    { 15, "8a55c638-baff-413a-bdb9-b9b41f768b71" },
                    { 16, "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad" },
                    { 17, "cc95335c-9a83-4a22-8f8e-b083dd6fc663" },
                    { 18, "a176cd80-4d75-47a8-b51a-6d059790bfe7" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ImageUrl", "UserId" },
                values: new object[] { 1, "sefa-ozturk.jpg", "a176cd80-4d75-47a8-b51a-6d059790bfe7" });

            migrationBuilder.InsertData(
                table: "UniversityEducations",
                columns: new[] { "EducationId", "UniversityId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Lisans Eğitimi" },
                    { 3, 2, "Lisans Eğitimi" },
                    { 4, 2, "Lisans Eğitimi" },
                    { 5, 5, "Lisans Eğitimi" },
                    { 7, 5, "Lisans Eğitimi" },
                    { 6, 11, "Lisans Eğitimi" },
                    { 11, 14, "Lisans Eğitimi" },
                    { 8, 33, "Lisans Eğitimi" },
                    { 15, 34, "Lisans Eğitimi" },
                    { 14, 35, "Lisans Eğitimi" },
                    { 13, 38, "Lisans Eğitimi" },
                    { 16, 40, "Lisans Eğitimi" },
                    { 2, 50, "Lisans Eğitimi" },
                    { 10, 61, "Lisans Eğitimi" },
                    { 12, 63, "Lisans Eğitimi" },
                    { 9, 75, "Lisans Eğitimi" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AboutId", "ImageUrl", "IsApproved", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "ali-yilmaz.jpg", true, "Matematik Öğretmeni", "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7" },
                    { 2, 2, "ayse-demir.jpg", true, "Edebiyat Öğretmeni", "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10" },
                    { 3, 3, "mehmet-kaya.jpg", true, "İngilizce Öğretmeni", "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4" },
                    { 4, 4, "elif-sahin.jpg", true, "Matematik Öğretmeni", "a17a2a35-1b72-42af-8d68-0b55faa60f22" },
                    { 5, 5, "mustafa-arslan.jpg", true, "Türkçe Öğretmeni", "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2" },
                    { 6, 6, "gizem-aksoy.jpg", true, "Müzik Öğretmeni", "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5" },
                    { 7, 7, "burak-gunes.jpg", true, "Edebiyat Öğretmeni", "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1" },
                    { 8, 8, "esra-gultekin.jpg", true, "İngilizce Öğretmeni", "d10e29b9-9f64-444d-8d0c-7a69e00e13b7" },
                    { 9, 9, "emre-ozturk.jpg", true, "Fen Bilimleri Öğretmeni", "a0d9c91b-3e6c-4528-a31e-58a47be27108" },
                    { 10, 10, "selin-kocak.jpg", true, "Sosyal Bilimler Öğretmeni", "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd" },
                    { 11, 11, "deniz-sahin.jpg", true, "Psikoloji Öğretmeni", "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f" },
                    { 12, 12, "beyza-karaca.jpg", true, "Müzik Öğretmeni", "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d" },
                    { 13, 13, "yasin-kilic.jpg", true, "Biyoloji Öğretmeni", "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd" },
                    { 14, 14, "zeynep-yilmaz.jpg", true, "Kimya Öğretmeni", "8a55c638-baff-413a-bdb9-b9b41f768b71" },
                    { 15, 15, "serdar-kara.jpg", true, "Fizik Öğretmeni", "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad" },
                    { 16, 16, "ayse-aydin.jpg", true, "Kimya Öğretmeni", "cc95335c-9a83-4a22-8f8e-b083dd6fc663" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9737), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Matematik", 400m, 1, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9741), "matematik" },
                    { 2, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9747), "Lise ve üniversite öğrencileri için edebiyat dersleri", "Edebiyat", 400m, 2, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9747), "edebiyat" },
                    { 3, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9750), "İngilizce öğrenmek isteyenler için dersler", "İngilizce", 500m, 3, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9751), "ingilizce" },
                    { 4, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9753), "Lise öğrencileri için temel matematik dersi", "Matematik", 400m, 4, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9754), "matematik-2" },
                    { 5, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9758), "Lise ve üniversite öğrencileri için Türkçe dersleri", "Türkçe", 350m, 5, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9759), "turkce" },
                    { 6, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9761), "Klasik müzik üzerine temel bir ders", "Müzik (Klasik)", 300m, 6, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9762), "muzik-klasik" },
                    { 7, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9764), "Modern edebiyatın önemli eserlerine yönelik bir ders", "Edebiyat (Modern)", 250m, 7, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9764), "edebiyat-modern" },
                    { 8, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9767), "Konuşma pratiği üzerine odaklanan İngilizce dersi", "İngilizce (Konuşma Pratiği)", 300m, 8, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9767), "ingilizce-konusma-pratigi" },
                    { 9, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9770), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Fen Bilimleri", 400m, 9, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9770), "fen-bilimleri" },
                    { 10, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9772), "Lise ve üniversite öğrencileri için sosyal bilimler dersi", "Sosyal Bilimler", 450m, 10, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9773), "sosyal-bilimler" },
                    { 11, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9775), "Lise ve üniversite öğrencileri için psikoloji dersi", "Psikoloji", 500m, 11, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9776), "psikoloji" },
                    { 12, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9779), "Piyano çalmayı öğrenmek isteyenler için temel bir ders", "Piyano Dersi", 400m, 12, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9779), "piyano-dersi" },
                    { 13, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9782), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Biyoloji", 400m, 13, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9782), "biyoloji" },
                    { 14, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9784), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Kimya", 450m, 14, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9785), "kimya" },
                    { 15, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9787), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Fizik", 450m, 15, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9788), "fizik" },
                    { 16, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9790), "Organik kimya konularına yönelik bir ders", "Organik Kimya", 350m, 16, new DateTime(2023, 4, 25, 18, 8, 23, 276, DateTimeKind.Local).AddTicks(9791), "organik-kimya" }
                });

            migrationBuilder.InsertData(
                table: "LessonCategories",
                columns: new[] { "CategoryId", "LessonId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 9, 3 },
                    { 2, 4 },
                    { 5, 5 },
                    { 4, 6 },
                    { 3, 7 },
                    { 9, 8 },
                    { 10, 9 },
                    { 11, 10 },
                    { 12, 11 },
                    { 4, 12 },
                    { 7, 13 },
                    { 6, 14 },
                    { 8, 15 },
                    { 6, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_EducationId",
                table: "Abouts",
                column: "EducationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonCategories_CategoryId",
                table: "LessonCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedItems_LessonId",
                table: "LikedItems",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedItems_LikeId",
                table: "LikedItems",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LessonId",
                table: "Reservations",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StudentId",
                table: "Reservations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TeacherId",
                table: "Reservations",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAvailabilities_TeacherId",
                table: "TeacherAvailabilities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AboutId",
                table: "Teachers",
                column: "AboutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityEducations_EducationId",
                table: "UniversityEducations",
                column: "EducationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LessonCategories");

            migrationBuilder.DropTable(
                name: "LikedItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "TeacherAvailabilities");

            migrationBuilder.DropTable(
                name: "UniversityEducations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Educations");
        }
    }
}
