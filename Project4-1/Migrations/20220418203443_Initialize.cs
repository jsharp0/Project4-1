using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project4_1.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_categoryID1",
                        column: x => x.categoryID1,
                        principalTable: "Categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryID", "name" },
                values: new object[,]
                {
                    { "1", "Work" },
                    { "2", "Family" },
                    { "3", "Friend" },
                    { "4", "Personal" },
                    { "5", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "CreatedDate", "categoryID1", "email", "firstName", "lastName", "organization", "phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mark.smith@yahoo.com", "Mark", "Smith", null, "440-505-3513" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lj1989@gmail.com", "Linda", "Jones", null, "638-424-2940" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bailey.stewart@aol.com", "Bailey", "Stewart", "Apple", "034-514-5462" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_categoryID1",
                table: "Contacts",
                column: "categoryID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
