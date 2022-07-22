﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SchoolProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => new { x.ClassId, x.SchoolId });
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "YearGroup",
                columns: table => new
                {
                    YearGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearGroup", x => x.YearGroupId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    YearGroupId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_YearGroup_YearGroupId",
                        column: x => x.YearGroupId,
                        principalTable: "YearGroup",
                        principalColumn: "YearGroupId");
                });

            migrationBuilder.CreateTable(
                name: "UserClass",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClass", x => new { x.UserId, x.ClassId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_UserClass_Class_ClassId_SchoolId",
                        columns: x => new { x.ClassId, x.SchoolId },
                        principalTable: "Class",
                        principalColumns: new[] { "ClassId", "SchoolId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClass_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSchool",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchool", x => new { x.UserId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_UserSchool_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSchool_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "SchoolId" },
                values: new object[,]
                {
                    { "A1", 1 },
                    { "A2", 1 },
                    { "A3", 1 },
                    { "A4", 1 },
                    { "B1", 2 },
                    { "B2", 2 },
                    { "B3", 2 },
                    { "B4", 2 },
                    { "C1", 3 },
                    { "C2", 3 },
                    { "C3", 3 },
                    { "C4", 3 }
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "SchoolId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Address", "Test name" },
                    { 2, "Address", "Test name 2" },
                    { 3, "Address 3", "Test name 3" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Teacher" },
                    { 2, "Pupil" }
                });

            migrationBuilder.InsertData(
                table: "YearGroup",
                columns: new[] { "YearGroupId", "Name" },
                values: new object[,]
                {
                    { 1, "Year 1" },
                    { 2, "Year 2" },
                    { 3, "Year 3" },
                    { 4, "Year 4" },
                    { 5, "Year 5" },
                    { 6, "Year 6" },
                    { 7, "Year 7" },
                    { 8, "Year 8" },
                    { 9, "Year 9" },
                    { 10, "Year 10" },
                    { 11, "Year 11" },
                    { 12, "Year 12" },
                    { 13, "Year 13" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "LastName", "UserTypeId", "YearGroupId" },
                values: new object[,]
                {
                    { new Guid("39b79056-d79a-4672-a068-104cc3d77116"), "Jamie", "Buckley", 2, 5 },
                    { new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f"), "Maddie", "Williams", 2, 3 },
                    { new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1"), "Luke", "Dallimore", 2, 1 },
                    { new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20"), "Ben", "Sztucki", 1, null },
                    { new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b"), "Sarah", "Williams", 2, 4 },
                    { new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53"), "Mike", "Prosser", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserClass",
                columns: new[] { "ClassId", "SchoolId", "UserId" },
                values: new object[,]
                {
                    { "C1", 3, new Guid("39b79056-d79a-4672-a068-104cc3d77116") },
                    { "C2", 3, new Guid("39b79056-d79a-4672-a068-104cc3d77116") },
                    { "B1", 2, new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f") },
                    { "B2", 2, new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f") },
                    { "A1", 1, new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1") },
                    { "A2", 1, new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1") },
                    { "A1", 1, new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20") },
                    { "A2", 1, new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20") },
                    { "A3", 1, new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20") },
                    { "C1", 3, new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b") },
                    { "C2", 3, new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b") },
                    { "B1", 2, new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53") },
                    { "B2", 2, new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53") }
                });

            migrationBuilder.InsertData(
                table: "UserSchool",
                columns: new[] { "SchoolId", "UserId" },
                values: new object[,]
                {
                    { 3, new Guid("39b79056-d79a-4672-a068-104cc3d77116") },
                    { 2, new Guid("42481486-17f2-4cd3-bda2-04d3b46c8e0f") },
                    { 1, new Guid("630958ef-30c8-4c43-a822-f5b3b5192bd1") },
                    { 1, new Guid("d818a056-1d33-4276-bc80-c8dcf128fe20") },
                    { 3, new Guid("ef258c81-b08e-4b73-9173-956db34a6e7b") },
                    { 2, new Guid("ff96657b-00c1-4c68-a6d6-4bd213777f53") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_YearGroupId",
                table: "User",
                column: "YearGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClass_ClassId_SchoolId",
                table: "UserClass",
                columns: new[] { "ClassId", "SchoolId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSchool_SchoolId",
                table: "UserSchool",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClass");

            migrationBuilder.DropTable(
                name: "UserSchool");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "YearGroup");
        }
    }
}
