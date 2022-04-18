using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project4_1.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "Contacts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "categoryID1",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_categoryID1",
                table: "Contacts",
                column: "categoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_categoryID1",
                table: "Contacts",
                column: "categoryID1",
                principalTable: "Categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_categoryID1",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_categoryID1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "categoryID1",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ID",
                keyValue: 1,
                column: "categoryID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ID",
                keyValue: 2,
                column: "categoryID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ID",
                keyValue: 3,
                column: "categoryID",
                value: 2);
        }
    }
}
