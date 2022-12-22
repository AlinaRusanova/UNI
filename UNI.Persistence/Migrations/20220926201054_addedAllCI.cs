using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI.Persistence.Migrations
{
    public partial class addedAllCI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactsInfo",
                columns: new[] { "StudentId", "Address", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 13, "adress", "email", "101010101010" },
                    { 14, "adress", "email", "101010101010" },
                    { 15, "adress", "email", "101010101010" },
                    { 16, "adress", "email", "101010101010" },
                    { 17, "adress", "email", "101010101010" },
                    { 18, "adress", "email", "101010101010" },
                    { 19, "adress", "email", "101010101010" },
                    { 20, "adress", "email", "101010101010" },
                    { 21, "adress", "email", "101010101010" },
                    { 22, "adress", "email", "101010101010" },
                    { 23, "adress", "email", "101010101010" },
                    { 24, "adress", "email", "101010101010" },
                    { 25, "adress", "email", "101010101010" },
                    { 26, "adress", "email", "101010101010" },
                    { 27, "adress", "email", "101010101010" },
                    { 28, "adress", "email", "101010101010" },
                    { 29, "adress", "email", "101010101010" },
                    { 30, "adress", "email", "101010101010" },
                    { 31, "adress", "email", "101010101010" },
                    { 32, "adress", "email", "101010101010" },
                    { 33, "adress", "email", "101010101010" },
                    { 34, "adress", "email", "101010101010" },
                    { 35, "adress", "email", "101010101010" },
                    { 36, "adress", "email", "101010101010" },
                    { 37, "adress", "email", "101010101010" },
                    { 38, "adress", "email", "101010101010" },
                    { 39, "adress", "email", "101010101010" },
                    { 40, "adress", "email", "101010101010" },
                    { 41, "adress", "email", "101010101010" },
                    { 42, "adress", "email", "101010101010" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 42);
        }
    }
}
