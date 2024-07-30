using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentModel_LabModel_LabModelId",
                table: "ExperimentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LabModel_LessonModel_LessonModelId",
                table: "LabModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonModel_UserModel_UserModelId",
                table: "LessonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentToExperiment_ExperimentModel_ExperimentModelId",
                table: "StudentToExperiment");

            migrationBuilder.DropIndex(
                name: "IX_StudentToExperiment_ExperimentModelId",
                table: "StudentToExperiment");

            migrationBuilder.DropIndex(
                name: "IX_LessonModel_UserModelId",
                table: "LessonModel");

            migrationBuilder.DropIndex(
                name: "IX_LabModel_LessonModelId",
                table: "LabModel");

            migrationBuilder.DeleteData(
                table: "ExperimentModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentToExperiment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LabModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LessonModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ExperimentModelId",
                table: "StudentToExperiment");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "LessonModel");

            migrationBuilder.DropColumn(
                name: "LessonModelId",
                table: "LabModel");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LessonModel",
                newName: "LabModelId");

            migrationBuilder.RenameColumn(
                name: "LabModelId",
                table: "ExperimentModel",
                newName: "LessonModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperimentModel_LabModelId",
                table: "ExperimentModel",
                newName: "IX_ExperimentModel_LessonModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_LabModelId",
                table: "LessonModel",
                column: "LabModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentModel_LessonModel_LessonModelId",
                table: "ExperimentModel",
                column: "LessonModelId",
                principalTable: "LessonModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonModel_LabModel_LabModelId",
                table: "LessonModel",
                column: "LabModelId",
                principalTable: "LabModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentModel_LessonModel_LessonModelId",
                table: "ExperimentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonModel_LabModel_LabModelId",
                table: "LessonModel");

            migrationBuilder.DropIndex(
                name: "IX_LessonModel_LabModelId",
                table: "LessonModel");

            migrationBuilder.RenameColumn(
                name: "LabModelId",
                table: "LessonModel",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LessonModelId",
                table: "ExperimentModel",
                newName: "LabModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ExperimentModel_LessonModelId",
                table: "ExperimentModel",
                newName: "IX_ExperimentModel_LabModelId");

            migrationBuilder.AddColumn<int>(
                name: "ExperimentModelId",
                table: "StudentToExperiment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "LessonModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonModelId",
                table: "LabModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_StudentToExperiment_ExperimentModelId",
                table: "StudentToExperiment",
                column: "ExperimentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonModel_UserModelId",
                table: "LessonModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LabModel_LessonModelId",
                table: "LabModel",
                column: "LessonModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentModel_LabModel_LabModelId",
                table: "ExperimentModel",
                column: "LabModelId",
                principalTable: "LabModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabModel_LessonModel_LessonModelId",
                table: "LabModel",
                column: "LessonModelId",
                principalTable: "LessonModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonModel_UserModel_UserModelId",
                table: "LessonModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentToExperiment_ExperimentModel_ExperimentModelId",
                table: "StudentToExperiment",
                column: "ExperimentModelId",
                principalTable: "ExperimentModel",
                principalColumn: "Id");
        }
    }
}
