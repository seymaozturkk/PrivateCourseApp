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
                name: "LessonLikes",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLikes", x => new { x.LessonId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LessonLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonLikes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
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
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ZoomLink = table.Column<string>(type: "TEXT", nullable: true)
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
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b907df6a-1458-4823-a11e-ec7bf2d7f33e", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", null, "Kullanıcılar", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDate", "Url", "UserName", "UserType" },
                values: new object[,]
                {
                    { "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd", 0, new DateTime(1994, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "1a01f52f-8e8a-40e3-9646-ace129bacad1", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(185), "s.kocak@gmail.com", true, "Selin", 1, "Koçak", false, null, "S.KOCAK@GMAIL.COM", "SELINKOCAK", "SELINKOCAK", "AQAAAAIAAYagAAAAEPgBNECCVnyYLM/iXDBvwcEKnKryrVeXir/O3FbToJkGTT2g4UJN5DNpENed3Rlbgg==", null, false, "e403a652-59e0-4519-82a7-3f665463062f", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(186), "selin-kocak", "selinkocak", 2 },
                    { "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d", 0, new DateTime(1995, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "3689a073-42c3-49cb-9049-7deed03e9895", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(213), "beyzakaraca@gmail.com", true, "Beyza", 1, "Karaca", false, null, "BEYZAKARACA@GMAIL.COM", "BEYZAKARACA", "BEYZAKARACA", "AQAAAAIAAYagAAAAEKa2pOG8kpC3JyVHukb9qja6SYyoqO6w/pnBz+3PaohOCcsZj1yWujATyvKnV8fgiQ==", null, false, "504b30a2-110e-4d5a-b670-3170cfb0b01c", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(214), "beyza-karaca", "beyza.karaca", 2 },
                    { "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5", 0, new DateTime(1996, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ff98beaa-0a70-485d-b8b8-1656231b9049", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(118), "g.aksoy@hotmail.com", true, "Gizem", 1, "Aksoy", false, null, "G.AKSOY@HOTMAIL.COM", "GIZEMAKSOY", "GIZEMAKSOY", "AQAAAAIAAYagAAAAEBMYGwmMQfowtQEXWv2+b+1UKWulac2UKmOV7TrTqKqwXjNSFEokKdKGj80Bh3b9Yw==", null, false, "615e67fe-95db-4432-98f3-fe1d58847658", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(119), "gizem-aksoy", "gizem.aksoy", 2 },
                    { "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10", 0, new DateTime(1997, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "2cbd3fe2-76db-4306-8e8d-8eb81c2e950f", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(55), "ayse.demir@gmail.com", true, "Ayşe", 1, "Demir", false, null, "AYSE.DEMIR@GMAIL.COM", "AYSEDEMIR", "AYSEDEMIR", "AQAAAAIAAYagAAAAEAYV/3wqgs1YdIPkLtVa4E6I7XOgsVaSt9Ijf//jT1/Rk+d2R+GFNGdtPKLYsztnZg==", null, false, "b865491e-76d5-4356-a113-8b9f937f7dc4", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(56), "ayse-demir", "ayse.demir", 2 },
                    { "715d80fc-4fff-4509-8f89-ea1d4c0b03de", 0, new DateTime(1999, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "93788a16-5f15-4276-93ee-5b8d7e5d7f67", new DateTime(2023, 5, 12, 23, 27, 47, 311, DateTimeKind.Local).AddTicks(9995), "cankusseyma@gmail.com", true, "Şeyma", 1, "Cankuş", false, null, "CANKUSSEYMA@GMAIL.COM", "SEYMACANKUS", "SEYMACANKUS", "AQAAAAIAAYagAAAAEFCwWS6ZGo/ojEA3TbHIDRagFEGhPnFCU7LR8KG2imXAZCjHNHYSRnP9RqpZ9moTug==", null, false, "f6b6bd9c-421e-4f48-9b66-32f9b7846e48", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(15), "seyma-cankus", "seymacankus", 0 },
                    { "8a55c638-baff-413a-bdb9-b9b41f768b71", 0, new DateTime(1996, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "d3100ccb-ae6c-4bb0-9616-f2d98a1eade9", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(250), "z.yilmaz@gmail.com", true, "Zeynep", 1, "Yılmaz", false, null, "Z.YILMAZ@GMAIL.COM", "ZEYNEPYILMAZ", "ZEYNEPYILMAZ", "AQAAAAIAAYagAAAAEFJsVwLxHNrf6edZ2cG91fDykt+IOUA2Bf90Qo99pqL5nB8ZwWx0yRkBDhbTYuAzfg==", null, false, "35596488-173c-4562-8ade-ece20d9d388f", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(250), "zeynep-yilmaz", "zeynep.yilmaz", 2 },
                    { "a0d9c91b-3e6c-4528-a31e-58a47be27108", 0, new DateTime(1997, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "5340fb64-b5b3-47c3-9324-20d5508b647f", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(172), "e.ozturk@hotmail.com", true, "Emre", 0, "Öztürk", false, null, "E.OZTURK@HOTMAIL.COM", "EMREOZTURK", "EMREOZTURK", "AQAAAAIAAYagAAAAEG8JHR6O0xGGCngRqeX5MBf/U478hGQeA9jrrfBVmPOi8sTTAqdOpobyYXRsgxzrzQ==", null, false, "c1a6fa6e-5403-4490-be41-c93c3621baf5", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(173), "emre-ozturk", "emre_ozturk", 2 },
                    { "a176cd80-4d75-47a8-b51a-6d059790bfe7", 0, new DateTime(2001, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ad6da4ad-eac6-4443-b777-607cdf67b675", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(370), "sefaozturk@gmail.com", true, "Sefa", 0, "Öztürk", false, null, "SEFAOZTURK@GMAIL.COM", "SEFAOZTURK", "SEFAOZTURK", "AQAAAAIAAYagAAAAEElFj8ElL2Bf+8tYDRil5h/3Hkkdnu/2c0jgt93bMGxkjDrlsP9T00FvDOf7+jDdhQ==", null, false, "4939e3b2-7bb5-48bb-99b0-0a5120b6ffa5", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(371), "sefa-ozturk", "sefaozturk", 1 },
                    { "a17a2a35-1b72-42af-8d68-0b55faa60f22", 0, new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "16c4b7a1-fdd3-499f-a49d-2e5d5423d81e", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(85), "elifsahin@gmail.com", true, "Elif", 1, "Şahin", false, null, "ELIFSAHIN@GMAIL.COM", "ELIFSAHIN", "ELIFSAHIN", "AQAAAAIAAYagAAAAEL3B0wfB9NPK4sSuEkKc/1w93F43vntnaXfZnLDNY2uuW3qvfli30fhXwotbY/jGxw==", null, false, "26c30ce5-d325-48d8-a28f-d0f52497a58f", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(86), "elif-sahin", "elif.sahin", 2 },
                    { "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad", 0, new DateTime(1994, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "7daa9b53-76fa-43e8-a7de-df56c0270ab0", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(263), "serdar.kara@yahoo.com", true, "Serdar", 0, "Kara", false, null, "SERDAR.KARA@YAHOO.COM", "SERDARKARA", "SERDARKARA", "AQAAAAIAAYagAAAAEPplUVqqNyOwmQEANA9HeCXlG6gFHIiR85v5c+UHhbFxAHw2uYY1lqwVtj8jOrBBzA==", null, false, "5643a28c-ab5d-4292-a152-b7d842d335a9", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(263), "serdar-kara", "serdarkara", 2 },
                    { "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f", 0, new DateTime(1998, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "6710f121-25b4-4281-8c1d-1beb185215be", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(201), "deniz.sahin@yahoo.com", true, "Deniz", 0, "Şahin", false, null, "DENIZ.SAHIN@YAHOO.COM", "DENIZSAHIN", "DENIZSAHIN", "AQAAAAIAAYagAAAAEP2w2QnXaf8XkC5s/6FEJsWZO+mha5H7lyio9F3ikMv8WyR/yCo5kA3r15FrUfRjjQ==", null, false, "e112a58d-fa06-4da0-9983-a5c35f7aea35", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(201), "deniz-sahin", "deniz.sahin", 2 },
                    { "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7", 0, new DateTime(1995, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "d299fc6f-a9f8-4415-a354-066ea972406a", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(40), "aliyilmaz@hotmail.com", true, "Ali", 0, "Yılmaz", false, null, "ALIYILMAZ@HOTMAIL.COM", "ALIYILMAZ", "ALIYILMAZ", "AQAAAAIAAYagAAAAEJYg7VJrwZSZwrF7sZGgUrQpPBuZDTlReSve7AY14tqPV3/GRJ5wllAjy4zdNAllug==", null, false, "c8e7e343-af91-44e6-a678-c1f71590ff32", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(41), "ali-yilmaz", "aliyilmaz", 2 },
                    { "cc95335c-9a83-4a22-8f8e-b083dd6fc663", 0, new DateTime(1997, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca96a0df-3181-427d-ad25-f7d75cd09c29", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(355), "ayseaydin@gmail.com", true, "Ayşe", 1, "Aydın", false, null, "AYSEAYDIN@GMAIL.COM", "AYSEAYDIN", "AYSEAYDIN", "AQAAAAIAAYagAAAAEA5oNttGgg9P5ZGC311O8e6/E5aPlJm5/7gbre5ZhioFEfWDko28zQdkIgqn45eJrA==", null, false, "46ad3115-bf3e-40fb-8025-b65ebab9d80f", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(356), "ayse-aydin", "ayseaydin", 2 },
                    { "d10e29b9-9f64-444d-8d0c-7a69e00e13b7", 0, new DateTime(1999, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "d9552831-6103-4b0d-88e6-43caf52f638b", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(145), "esra.gultekin@gmail.com", true, "Esra", 1, "Gültekin", false, null, "ESRA.GULTEKIN@GMAIL.COM", "ESRAGULTEKIN", "ESRAGULTEKIN", "AQAAAAIAAYagAAAAEEegIZDuwfAGX9e4ky8PPAUEFAYfjcFOYYv7jIWlS/Q2jC+cXiwRbcL9tvlRjSn5dw==", null, false, "863b5788-be13-4304-bf40-73c324621bf0", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(146), "esra-gultekin", "esra_gultekin", 2 },
                    { "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2", 0, new DateTime(1992, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "95e9ae71-5f0b-4486-9a73-3c4471abe378", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(105), "mustafa.arslan@gmail.com", true, "Mustafa", 0, "Arslan", false, null, "MUSTAFA.ARSLAN@GMAIL.COM", "MUSTAFAARSLAN", "MARSLAN", "AQAAAAIAAYagAAAAENZMx6zPe3LpClzsH4psX/m8DMaR+qcJMx/fvtDpPLTzAGEsvSGV7f9S3R5iNqK3+A==", null, false, "b102c7d1-37a0-4b91-b902-351229a68b08", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(106), "mustafa-arslan", "m.arslan", 2 },
                    { "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd", 0, new DateTime(1992, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "43989792-9f55-46cb-814e-f768bbac7745", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(229), "yasin.kilic@hotmail.com", true, "Yasin", 0, "Kılıç", false, null, "YASIN.KILIC@HOTMAIL.COM", "YASINKILIC", "YASINKILIC", "AQAAAAIAAYagAAAAEAYjVGy59FzHGR1F1UcDNVl3wK9vx3j9P1fjRNOQLqXCarAuBI8nUEeInQnGoaXm3w==", null, false, "b8d0d8ba-e08a-4dda-9cc5-0a4c34f83093", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(230), "yasin-kilic", "yasin.kilic", 2 },
                    { "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4", 0, new DateTime(1994, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1acb529e-4acc-4629-8ba1-ae708b9eb632", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(72), "m.kaya@hotmail.com", true, "Mehmet", 0, "Kaya", false, null, "M.KAYA@HOTMAIL.COM", "MEHMETKAYA", "MEHMETKAYA", "AQAAAAIAAYagAAAAEPByutHK+J/4GxnoKJKfotzGaH4GLI4dVPDXKBggFUUgtu+5qUiNMl1xNCnDxHhHgA==", null, false, "1649bdbc-0f74-493b-a59c-b74802267274", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(73), "mehmet-kaya", "mehmet.kaya", 2 },
                    { "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1", 0, new DateTime(1993, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "91883c53-9c69-4deb-8990-3d355b518d4b", new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(130), "bgunes@outlook.com", true, "Burak", 0, "Güneş", false, null, "BGUNES@OUTLOOK.COM", "BURAKGUNES", "BURAKGUNES", "AQAAAAIAAYagAAAAEKRkADw3jmt3BzhbEEVCRghWpIpgh0AnMOv/8/pt0jzOeDZhS0DPjZb7IKAfgTvvFQ==", null, false, "3c31cc69-8654-4693-9fd3-4ca882af0169", false, new DateTime(2023, 5, 12, 23, 27, 47, 312, DateTimeKind.Local).AddTicks(131), "burak-gunes", "burakgunes", 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9684), "Edebiyat", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9688), "edebiyat" },
                    { 2, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9689), "Matematik", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9690), "matematik" },
                    { 3, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9692), "Almanca", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9692), "almanca" },
                    { 4, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9693), "Müzik", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9694), "muzik" },
                    { 5, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9695), "Türkçe", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9695), "turkce" },
                    { 6, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9696), "Kimya", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9697), "kimya" },
                    { 7, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9698), "Biyoloji", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9698), "biyoloji" },
                    { 8, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9700), "Fizik", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9700), "fizik" },
                    { 9, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9701), "İngilizce", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9702), "ingilizce" },
                    { 10, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9703), "Fen Bilimleri", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9703), "fen-bilimleri" },
                    { 11, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9704), "Sosyal Bilimler", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9705), "sosyal-bilimler" },
                    { 12, new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9706), "Psikoloji", new DateTime(2023, 5, 12, 23, 27, 49, 120, DateTimeKind.Local).AddTicks(9706), "psikoloji" }
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
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "06f2d882-d67e-4b4f-89c7-4df4a4f7d0fd" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "0ef0b47d-8c8a-4fa2-b01e-4630e6e21c9d" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "2313b70e-6e75-4c1d-b8b5-5c5a5be9a5c5" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "2c2d40d8-2a3a-4833-9d9f-d5f1ecbb1c10" },
                    { "b907df6a-1458-4823-a11e-ec7bf2d7f33e", "715d80fc-4fff-4509-8f89-ea1d4c0b03de" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "8a55c638-baff-413a-bdb9-b9b41f768b71" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "a0d9c91b-3e6c-4528-a31e-58a47be27108" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "a176cd80-4d75-47a8-b51a-6d059790bfe7" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "a17a2a35-1b72-42af-8d68-0b55faa60f22" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "a3c3e3aa-9218-45a3-b4ec-9e4b4e17f1ad" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "a8f85b97-3a70-4a62-8d8c-d9f9994f4c4f" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "c4b4a4a2-9ed4-4c48-aa35-53e9012021e7" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "cc95335c-9a83-4a22-8f8e-b083dd6fc663" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "d10e29b9-9f64-444d-8d0c-7a69e00e13b7" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "d3506b7c-d1b2-4ebc-9b45-60f8fc1f9cb2" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "e85c4f9d-4f4c-4a19-96e5-39dc262bebbd" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "e8b7c309-0f80-4df1-aec8-92fb0d4ce4f4" },
                    { "cd5e6012-05fa-4cc8-87b2-1d27986f4031", "fd8cf1e6-316a-43dc-98c7-20b599f0b9c1" }
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
                    { 1, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(640), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Matematik", 400m, 1, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(642), "matematik" },
                    { 2, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(649), "Lise ve üniversite öğrencileri için edebiyat dersleri", "Edebiyat", 400m, 2, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(650), "edebiyat" },
                    { 3, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(652), "İngilizce öğrenmek isteyenler için dersler", "İngilizce", 500m, 3, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(653), "ingilizce" },
                    { 4, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(655), "Lise öğrencileri için temel matematik dersi", "Matematik", 400m, 4, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(655), "matematik-2" },
                    { 5, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(657), "Lise ve üniversite öğrencileri için Türkçe dersleri", "Türkçe", 350m, 5, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(658), "turkce" },
                    { 6, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(659), "Klasik müzik üzerine temel bir ders", "Müzik (Klasik)", 300m, 6, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(661), "muzik-klasik" },
                    { 7, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(663), "Modern edebiyatın önemli eserlerine yönelik bir ders", "Edebiyat (Modern)", 250m, 7, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(663), "edebiyat-modern" },
                    { 8, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(665), "Konuşma pratiği üzerine odaklanan İngilizce dersi", "İngilizce (Konuşma Pratiği)", 300m, 8, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(666), "ingilizce-konusma-pratigi" },
                    { 9, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(668), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Fen Bilimleri", 400m, 9, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(668), "fen-bilimleri" },
                    { 10, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(670), "Lise ve üniversite öğrencileri için sosyal bilimler dersi", "Sosyal Bilimler", 450m, 10, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(671), "sosyal-bilimler" },
                    { 11, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(672), "Lise ve üniversite öğrencileri için psikoloji dersi", "Psikoloji", 500m, 11, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(673), "psikoloji" },
                    { 12, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(675), "Piyano çalmayı öğrenmek isteyenler için temel bir ders", "Piyano Dersi", 400m, 12, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(675), "piyano-dersi" },
                    { 13, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(677), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Biyoloji", 400m, 13, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(678), "biyoloji" },
                    { 14, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(680), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Kimya", 450m, 14, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(680), "kimya" },
                    { 15, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(685), "11. ve 12. Sınıf üniversiteye hazırlık çalışması", "Fizik", 450m, 15, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(686), "fizik" },
                    { 16, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(688), "Organik kimya konularına yönelik bir ders", "Organik Kimya", 350m, 16, new DateTime(2023, 5, 12, 23, 27, 49, 122, DateTimeKind.Local).AddTicks(688), "organik-kimya" }
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
                    { 1, 7 },
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
                name: "IX_LessonLikes_UserId",
                table: "LessonLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LessonId",
                table: "Reservations",
                column: "LessonId");

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
                name: "LessonLikes");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeacherAvailabilities");

            migrationBuilder.DropTable(
                name: "UniversityEducations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lessons");

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
