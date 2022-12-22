using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI.Persistence.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlCoursLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses_Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Groups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlStudentPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactsInfo_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseDescription", "CourseName", "UrlCoursLogo" },
                values: new object[,]
                {
                    { 1, "Learn how to write high performance and scalable .NET Core and ASP.NET Core applications in C#", ".Net Developer", "https://dotnetfoundation.org/img/dot_bot.png" },
                    { 2, "Become a confident industry ready core Java developer and get certified as a Java professional!", "Java Developer", "https://www.whatap.io/ko/blog/12/img/java_history.webp" },
                    { 3, "Practical course for QA testers", "Automation QA", "https://brainup.space/wp-content/uploads/2021/09/qa-engineer-300x300.jpg" },
                    { 4, "Learn Python like a Professional Start from the basics and go all the way to creating your own applications", "Python Developer", "https://contentstatic.techgig.com/photo/88317143/how-and-why-to-become-a-certified-python-programmer-in-2022.jpg?116970" },
                    { 5, "From Complete Beginner To Professional Game Developer. Learn To Code In C# And Create Stunning Games With Unity", "Unity Developer", "https://gagadget.com/media/post_big/unity-best-tools-january-2022-800x449.jpg" },
                    { 6, "Everything you need to transition from hobbyist to professional iOS developer", "iOS Developer", "https://media-exp2.licdn.com/dms/image/C510BAQEeZG6Lx64row/company-logo_200_200/0/1543775201739?e=2147483647&v=beta&t=oJqpcDJZIr5ypO0gV9fN3O0M224JdKCTDQUFwgpHHEE" },
                    { 7, "Get advanced with Node.Js! Learn caching with Redis, speed up through clustering, and add image upload with S3 and Node!", "Node js", "https://cdn.iconscout.com/icon/free/png-256/node-js-3550841-2970426.png" },
                    { 8, "Launch a career as a web designer by learning HTML5, CSS3, responsive design, Sass and more!", "WEB Designer", "https://www.varnitec.com/sites/default/files/2020-06/2.jpg" },
                    { 9, "Build a real e-commerce app with Angular, Firebase and Bootstrap 4", "Angular", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZoqNQ3pxtbGCECwyUcKbiHK9lbeW86ZBmqJ9HOBBsBBrjq9OmSfxppeT6_O5CCJKnk50&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupName", "Speciality" },
                values: new object[,]
                {
                    { 1, ".Net Developer+Node.js", "FullStack Developer" },
                    { 2, ".Net Developer+Angular", "FullStack Developer" },
                    { 3, "Java Developer+Node.js", "FullStack Developer" },
                    { 4, "Java Developer+Angular", "FullStack Developer" },
                    { 5, "Python Developer+Node.js", "FullStack Developer" },
                    { 6, "Python Developer+Angular", "FullStack Developer" },
                    { 7, ".Net Developer", ".Net Developer" },
                    { 8, "Java Developer", "Java Developer" },
                    { 9, "Python Developer", "Python Developer" },
                    { 10, "Unity Developer + C#", "Unity Developer" },
                    { 11, "Unity Developer", "Unity Developer" },
                    { 12, "Python Developer + Automation QA", "Python Developer" },
                    { 13, "Java Developer+Automation QA", "Java Developer" },
                    { 14, "Automation QA", "Automation QA" },
                    { 15, "WEB Designer", "WEB Designer" },
                    { 16, "Node js", "Node js" },
                    { 17, "Angular", "Angular" },
                    { 18, "iOS Developer", "iOS Developer" }
                });

            migrationBuilder.InsertData(
                table: "Courses_Groups",
                columns: new[] { "Id", "CourseId", "GroupId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 7, 1 },
                    { 3, 1, 2 },
                    { 4, 9, 2 },
                    { 5, 2, 3 },
                    { 6, 7, 3 },
                    { 7, 2, 4 },
                    { 8, 9, 4 },
                    { 9, 7, 5 },
                    { 10, 4, 5 },
                    { 11, 9, 6 },
                    { 12, 4, 6 },
                    { 13, 1, 7 },
                    { 14, 2, 8 },
                    { 15, 4, 9 },
                    { 16, 1, 10 },
                    { 17, 5, 10 },
                    { 18, 5, 11 },
                    { 19, 4, 12 },
                    { 20, 3, 12 },
                    { 21, 3, 13 },
                    { 22, 2, 13 },
                    { 23, 3, 14 },
                    { 24, 8, 15 },
                    { 25, 7, 16 },
                    { 26, 9, 17 },
                    { 27, 6, 18 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "UrlStudentPhoto" },
                values: new object[,]
                {
                    { 1, "Anders", 1, "Hejlsberg", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Anders_Hejlsberg.jpg/274px-Anders_Hejlsberg.jpg" },
                    { 2, "Scott", 1, "Allen", "https://odetocode.com/Images/scott_allen_7.jpg" },
                    { 3, "Iris", 1, "Classon", "https://www.irisclasson.com/promo/irisclasson.jpg.webp" },
                    { 4, "David", 1, "Ebbo", "http://www.gravatar.com/avatar/3c4e7f8b11f8b8c1d77ebb70678097b4?s=128?s=160" },
                    { 5, "Damian", 2, "Edwards", "https://0.gravatar.com/avatar/069d9cb18fdf2956b0dcee852627fb08?s=96&d=https%3A%2F%2F0.gravatar.com%2Favatar%2Fad516503a11cd5ca435acc9bb6523536%3Fs%3D96" },
                    { 6, "David", 2, "Fowler", "https://pbs.twimg.com/profile_images/1320061631339126786/gHKfzYft_400x400.jpg" },
                    { 7, "Jon", 2, "Galloway", "https://w2nxbg.dm.files.1drv.com/y4mvd6G94DdTBVbUzRoqINo7FzA9RdXOFwI8vti_JD1lLw5klF3xHr4YRQTCYdgmpN6uz4DH6kjre4vcifzLJiHCbraAzlXyT7KCzXczoGidr3d5wH5K-p8wccuOUzkeU4_gcr_GnIciHN1KX2qgdBCDZMcXDUwKlGMLse3cjUO4pFcJ5bZY9JtpmV35mmCSd8Y?width=1400&height=1668&cropmode=none" },
                    { 8, "Scott", 7, "Guthrie", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/MIX_Keynote-Scott_Guthrie_09_MS_05_2007.jpg/250px-MIX_Keynote-Scott_Guthrie_09_MS_05_2007.jpg" },
                    { 9, "", 7, "", "https://2.gravatar.com/avatar/cdf546b601bf29a7eb4ca777544d11cd?s=160" },
                    { 10, "Phil", 7, "Haack", "https://user-images.githubusercontent.com/19977/108404639-f3124b80-71d4-11eb-925e-1de429de32e4.jpg" },
                    { 11, "Corey", 10, "Haines", "http://1.bp.blogspot.com/-TdAHPTfmQzs/US_PBudX1GI/AAAAAAAAEbY/riZfOb5Zi2U/s200/fullheadmullet.jpg" },
                    { 12, "Drew", 10, "Marsh", "https://hackedbrain.blob.core.windows.net/wp-blog-content/2021/10/Annotation-2019-08-23-164228-300x269.jpg" },
                    { 13, "John", 1, "Papa", "https://res.cloudinary.com/practicaldev/image/fetch/s--Xf3zlwar--/c_fill,f_auto,fl_progressive,h_320,q_auto,w_320/https://dev-to-uploads.s3.amazonaws.com/uploads/user/profile_image/138665/cee5c68d-3bd2-4042-af64-5214952d6c30.jpg" },
                    { 14, "Rick", 10, "Strahl", "http://weblog.west-wind.com/images/rick175x175.jpg" },
                    { 15, "Arun", 3, "Gupta", "https://pbs.twimg.com/profile_images/1129247222925746178/lWdezfZX_400x400.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "UrlStudentPhoto" },
                values: new object[,]
                {
                    { 16, "Markus", 3, "Eisele", "https://pbs.twimg.com/profile_images/1543194332320206853/yTEVsjGz_400x400.jpg" },
                    { 17, "Mark", 3, "Reinhold", "https://pbs.twimg.com/profile_images/1012167014612267010/tpIWebKt_400x400.jpg" },
                    { 18, "Adam", 4, "Bien", "https://pbs.twimg.com/profile_images/82608077/abien_icon_400x400.jpg" },
                    { 19, "Simon", 4, "Maple", "https://pbs.twimg.com/profile_images/618367538016178176/AoS8svVQ_400x400.jpg" },
                    { 20, "David", 4, "Blevins", "https://pbs.twimg.com/profile_images/860618035521912832/bS8OJGpX_400x400.jpg" },
                    { 21, "Reza", 8, "Rahman", "https://pbs.twimg.com/profile_images/1324902443923206152/C7cYJaIy_400x400.jpg" },
                    { 22, "Josh", 8, "Juneau", "https://pbs.twimg.com/profile_images/1646931434/jj-smaller_400x400.jpg" },
                    { 23, "Ken", 8, "Fogel", "https://pbs.twimg.com/profile_images/1181905040736436224/1ypGgL71_400x400.jpg" },
                    { 24, "Tim", 18, "Cook", "https://pbs.twimg.com/profile_images/1535420431766671360/Pwq-1eJc_400x400.jpg" },
                    { 25, "Chris", 18, "Lattner", "https://pbs.twimg.com/profile_images/1484209565788897285/1n6Viahb_400x400.jpg" },
                    { 26, "Ash", 18, "Furrow", "https://pbs.twimg.com/profile_images/1264707114179723275/c9U307g7_400x400.jpg" },
                    { 27, "Ole", 18, "Begemann", "https://pbs.twimg.com/profile_images/1414976054398267396/icGRwR9__400x400.jpg" },
                    { 28, "Chris", 18, "Eidhof", "https://pbs.twimg.com/profile_images/496291231690137600/TmQRrofs_400x400.jpeg" },
                    { 29, "Mattt", 18, "Thompson", "https://pbs.twimg.com/profile_images/969321564050112513/fbdJZmEh_400x400.jpg" },
                    { 30, "Ray", 18, "Wenderlich", "https://pbs.twimg.com/profile_images/1380194129645297665/2OEX5bun_400x400.jpg" },
                    { 31, "Guido", 5, "Rossum", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Guido-van-Rossum.jpg" },
                    { 32, "Ewa", 5, "Jodlowska", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Ewa-Jodlowska.jpg" },
                    { 33, "Kevin", 5, "Goldsmith", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Kevin-Goldsmith.jpg" },
                    { 34, "Jen", 6, "Walraven", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Jen-Walraven.jpeg" },
                    { 35, "Audrey", 6, "Greenfield", "https://newrelic.com/sites/default/files/wp_blog_inline_files/audrey_roy_greenfield.jpeg" },
                    { 36, "Daniel", 6, "Greenfield", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Daniel-Roy-Greenfeld.jpeg" },
                    { 37, "Reshama", 9, "Shaikh", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Reshama-Shaikh.jpg" },
                    { 38, "Tomaz", 9, "Muraus", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Tomaz-Muraus.jpg" },
                    { 39, "Tom", 9, "Christie", "https://newrelic.com/sites/default/files/wp_blog_inline_files/tom_christie.jpg" },
                    { 40, "Yury", 12, "Selivanov", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Yury-Selivanov.jpg" },
                    { 41, "Raymond", 12, "Hettinger", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Raymond-Hettinger.jpg" },
                    { 42, "Łukasz", 12, "Langa", "https://newrelic.com/sites/default/files/wp_blog_inline_files/Lukasz-Langa.png" }
                });

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
                name: "IX_ContactsInfo_StudentId",
                table: "ContactsInfo",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Groups_CourseId",
                table: "Courses_Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Groups_GroupId",
                table: "Courses_Groups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactsInfo");

            migrationBuilder.DropTable(
                name: "Courses_Groups");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
