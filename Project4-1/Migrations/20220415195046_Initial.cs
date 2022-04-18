using Microsoft.EntityFrameworkCore.Migrations;

namespace Project4_1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "categoryID", "email", "firstName", "lastName", "organization", "phone" },
                values: new object[] { 1, 3, "mark.smith@yahoo.com", "Mark", "Smith", null, "440-505-3513" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "categoryID", "email", "firstName", "lastName", "organization", "phone" },
                values: new object[] { 2, 5, "lj1989@gmail.com", "Linda", "Jones", null, "638-424-2940" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "categoryID", "email", "firstName", "lastName", "organization", "phone" },
                values: new object[] { 3, 2, "bailey.stewart@aol.com", "Bailey", "Stewart", "Apple", "034-514-5462" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
