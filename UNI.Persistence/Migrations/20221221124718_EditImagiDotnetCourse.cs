using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI.Persistence.Migrations
{
    public partial class EditImagiDotnetCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlCoursLogo",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRJIAVHooYcPB2Nm3n_TmAwq4FcO8-Vl5i4g&usqp=CAU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlCoursLogo",
                value: "https://dotnetfoundation.org/img/dot_bot.png");
        }
    }
}
