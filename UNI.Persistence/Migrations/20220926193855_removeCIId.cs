using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI.Persistence.Migrations
{
    public partial class removeCIId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Id",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactsInfo",
                table: "ContactsInfo");

            migrationBuilder.DropIndex(
                name: "IX_ContactsInfo_StudentId",
                table: "ContactsInfo");

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 42);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContactsInfo");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactsInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactsInfo",
                table: "ContactsInfo",
                column: "StudentId");

            migrationBuilder.InsertData(
                table: "ContactsInfo",
                columns: new[] { "StudentId", "Address", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Copenhagen, Denmark", "hejlsberg@gmail.com", "101010101010" },
                    { 2, "USA", "allen@gmail.com", "101010101010" },
                    { 3, "adress", "email", "101010101010" },
                    { 4, "adress", "email", "101010101010" },
                    { 5, "adress", "email", "101010101010" },
                    { 6, "adress", "email", "101010101010" },
                    { 7, "adress", "email", "101010101010" },
                    { 8, "adress", "email", "101010101010" },
                    { 9, "adress", "email", "101010101010" },
                    { 10, "adress", "email", "101010101010" },
                    { 11, "adress", "email", "101010101010" },
                    { 12, "adress", "email", "101010101010" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactsInfo",
                table: "ContactsInfo");

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ContactsInfo",
                keyColumn: "StudentId",
                keyValue: 12);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ContactsInfo",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContactsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactsInfo",
                table: "ContactsInfo",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ContactsInfo",
                columns: new[] { "Id", "Address", "Email", "PhoneNumber", "StudentId" },
                values: new object[,]
                {
                    { 1, "Copenhagen, Denmark", "hejlsberg@gmail.com", "101010101010", 1 },
                    { 2, "USA", "allen@gmail.com", "101010101010", 2 },
                    { 3, "adress", "email", "101010101010", 3 },
                    { 4, "adress", "email", "101010101010", 4 },
                    { 5, "adress", "email", "101010101010", 5 },
                    { 6, "adress", "email", "101010101010", 6 },
                    { 7, "adress", "email", "101010101010", 7 },
                    { 8, "adress", "email", "101010101010", 8 },
                    { 9, "adress", "email", "101010101010", 9 },
                    { 10, "adress", "email", "101010101010", 10 },
                    { 11, "adress", "email", "101010101010", 11 },
                    { 12, "adress", "email", "101010101010", 12 },
                    { 13, "adress", "email", "101010101010", 13 },
                    { 14, "adress", "email", "101010101010", 14 },
                    { 15, "adress", "email", "101010101010", 15 },
                    { 16, "adress", "email", "101010101010", 16 },
                    { 17, "adress", "email", "101010101010", 17 },
                    { 18, "adress", "email", "101010101010", 18 },
                    { 19, "adress", "email", "101010101010", 19 },
                    { 20, "adress", "email", "101010101010", 20 },
                    { 21, "adress", "email", "101010101010", 21 },
                    { 22, "adress", "email", "101010101010", 22 },
                    { 23, "adress", "email", "101010101010", 23 },
                    { 24, "adress", "email", "101010101010", 24 },
                    { 25, "adress", "email", "101010101010", 25 },
                    { 26, "adress", "email", "101010101010", 26 },
                    { 27, "adress", "email", "101010101010", 27 },
                    { 28, "adress", "email", "101010101010", 28 },
                    { 29, "adress", "email", "101010101010", 29 },
                    { 30, "adress", "email", "101010101010", 30 },
                    { 31, "adress", "email", "101010101010", 31 },
                    { 32, "adress", "email", "101010101010", 32 },
                    { 33, "adress", "email", "101010101010", 33 },
                    { 34, "adress", "email", "101010101010", 34 },
                    { 35, "adress", "email", "101010101010", 35 },
                    { 36, "adress", "email", "101010101010", 36 },
                    { 37, "adress", "email", "101010101010", 37 },
                    { 38, "adress", "email", "101010101010", 38 },
                    { 39, "adress", "email", "101010101010", 39 },
                    { 40, "adress", "email", "101010101010", 40 },
                    { 41, "adress", "email", "101010101010", 41 },
                    { 42, "adress", "email", "101010101010", 42 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactsInfo_StudentId",
                table: "ContactsInfo",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
