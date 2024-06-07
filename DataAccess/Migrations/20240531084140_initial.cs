using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    AppRegisterToken = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonModel_UserModel_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LabModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabModel_LessonModel_LessonModelId",
                        column: x => x.LessonModelId,
                        principalTable: "LessonModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LabModelId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentModel_LabModel_LabModelId",
                        column: x => x.LabModelId,
                        principalTable: "LabModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentToExperiment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExperimentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExperimentModelId = table.Column<int>(type: "integer", nullable: true),
                    QrCodeText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentToExperiment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentToExperiment_ExperimentModel_ExperimentModelId",
                        column: x => x.ExperimentModelId,
                        principalTable: "ExperimentModel",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "LessonModel",
                columns: new[] { "Id", "Description", "Name", "UserId", "UserModelId" },
                values: new object[] { 1, "Description", "Name", 1, null });

            migrationBuilder.InsertData(
                table: "StudentToExperiment",
                columns: new[] { "Id", "ExperimentId", "ExperimentModelId", "QrCodeText", "UserId" },
                values: new object[] { 1, 1, null, "", 1 });

            migrationBuilder.InsertData(
                table: "UserModel",
                columns: new[] { "Id", "AppRegisterToken", "Email", "Name", "Number", "Password", "Phone", "Surname", "UserType" },
                values: new object[] { 1, " ", "S", "Name", "055", "S", " ", "S", 0 });

            migrationBuilder.InsertData(
                table: "LabModel",
                columns: new[] { "Id", "Description", "LessonModelId", "Name" },
                values: new object[] { 1, "Description", 1, "Name" });

            migrationBuilder.InsertData(
                table: "ExperimentModel",
                columns: new[] { "Id", "Description", "LabModelId", "Name", "StartDate" },
                values: new object[] { 1, "Description", 1, "Name", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentModel_LabModelId",
                table: "ExperimentModel",
                column: "LabModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LabModel_LessonModelId",
                table: "LabModel",
                column: "LessonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_UserModelId",
                table: "LessonModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentToExperiment_ExperimentModelId",
                table: "StudentToExperiment",
                column: "ExperimentModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentToExperiment");

            migrationBuilder.DropTable(
                name: "ExperimentModel");

            migrationBuilder.DropTable(
                name: "LabModel");

            migrationBuilder.DropTable(
                name: "LessonModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
