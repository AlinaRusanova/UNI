using Microsoft.EntityFrameworkCore;
using UNI.Domain.Entities;

namespace UNI.Domain
{
    public class UniDbContext : DbContext
    {
        public UniDbContext(DbContextOptions<UniDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInfo> ContactsInfo { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Group> Courses_Groups { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(UniDbContext).Assembly);

            builder.Entity<Course_Group>()
                .HasOne(c => c.Course)
                .WithMany(cg => cg.Course_Groups)
                .HasForeignKey(ci => ci.CourseId);

            builder.Entity<Course_Group>()
                .HasOne(g => g.Group)
                .WithMany(cg => cg.Course_Groups)
                .HasForeignKey(gi => gi.GroupId);

            builder.Entity<Student>()
                   .HasOne<ContactInfo>(s => s.ContactInfo)
                   .WithOne(ci => ci.Student)
                   .HasForeignKey<ContactInfo>(ci => ci.StudentId);

            builder.Entity<ContactInfo>()
                .HasKey(c => c.StudentId);

            builder.Entity<Student>().HasData(
                  new Student { Id = 1, UrlStudentPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Anders_Hejlsberg.jpg/274px-Anders_Hejlsberg.jpg", FirstName = "Anders", LastName = "Hejlsberg", GroupId = 1 },
                  new Student { Id = 2, UrlStudentPhoto = "https://odetocode.com/Images/scott_allen_7.jpg", FirstName = "Scott", LastName = "Allen", GroupId = 1 },
                  new Student { Id = 3, UrlStudentPhoto = "https://www.irisclasson.com/promo/irisclasson.jpg.webp", FirstName = "Iris", LastName = "Classon", GroupId = 1 },
                  new Student { Id = 4, UrlStudentPhoto = "http://www.gravatar.com/avatar/3c4e7f8b11f8b8c1d77ebb70678097b4?s=128?s=160", FirstName = "David", LastName = "Ebbo", GroupId = 1 },
                  new Student { Id = 5, UrlStudentPhoto = "https://0.gravatar.com/avatar/069d9cb18fdf2956b0dcee852627fb08?s=96&d=https%3A%2F%2F0.gravatar.com%2Favatar%2Fad516503a11cd5ca435acc9bb6523536%3Fs%3D96", FirstName = "Damian", LastName = "Edwards", GroupId = 2 },
                  new Student { Id = 6, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1320061631339126786/gHKfzYft_400x400.jpg", FirstName = "David", LastName = "Fowler", GroupId = 2 },
                  new Student { Id = 7, UrlStudentPhoto = "https://w2nxbg.dm.files.1drv.com/y4mvd6G94DdTBVbUzRoqINo7FzA9RdXOFwI8vti_JD1lLw5klF3xHr4YRQTCYdgmpN6uz4DH6kjre4vcifzLJiHCbraAzlXyT7KCzXczoGidr3d5wH5K-p8wccuOUzkeU4_gcr_GnIciHN1KX2qgdBCDZMcXDUwKlGMLse3cjUO4pFcJ5bZY9JtpmV35mmCSd8Y?width=1400&height=1668&cropmode=none", FirstName = "Jon", LastName = "Galloway", GroupId = 2 },
                  new Student { Id = 8, UrlStudentPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/MIX_Keynote-Scott_Guthrie_09_MS_05_2007.jpg/250px-MIX_Keynote-Scott_Guthrie_09_MS_05_2007.jpg", FirstName = "Scott", LastName = "Guthrie", GroupId = 7 },
                  new Student { Id = 9, UrlStudentPhoto = "https://2.gravatar.com/avatar/cdf546b601bf29a7eb4ca777544d11cd?s=160", FirstName = "", LastName = "", GroupId = 7 },
                  new Student { Id = 10, UrlStudentPhoto = "https://user-images.githubusercontent.com/19977/108404639-f3124b80-71d4-11eb-925e-1de429de32e4.jpg", FirstName = "Phil", LastName = "Haack", GroupId = 7 },
                  new Student { Id = 11, UrlStudentPhoto = "http://1.bp.blogspot.com/-TdAHPTfmQzs/US_PBudX1GI/AAAAAAAAEbY/riZfOb5Zi2U/s200/fullheadmullet.jpg", FirstName = "Corey", LastName = "Haines", GroupId = 10 },
                  new Student { Id = 12, UrlStudentPhoto = "https://hackedbrain.blob.core.windows.net/wp-blog-content/2021/10/Annotation-2019-08-23-164228-300x269.jpg", FirstName = "Drew", LastName = "Marsh", GroupId = 10 },
                  new Student { Id = 13, UrlStudentPhoto = "https://res.cloudinary.com/practicaldev/image/fetch/s--Xf3zlwar--/c_fill,f_auto,fl_progressive,h_320,q_auto,w_320/https://dev-to-uploads.s3.amazonaws.com/uploads/user/profile_image/138665/cee5c68d-3bd2-4042-af64-5214952d6c30.jpg", FirstName = "John", LastName = "Papa", GroupId = 1 },
                  new Student { Id = 14, UrlStudentPhoto = "http://weblog.west-wind.com/images/rick175x175.jpg", FirstName = "Rick", LastName = "Strahl", GroupId = 10 },
                  new Student { Id = 15, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1129247222925746178/lWdezfZX_400x400.jpg", FirstName = "Arun", LastName = "Gupta", GroupId = 3 },
                  new Student { Id = 16, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1543194332320206853/yTEVsjGz_400x400.jpg", FirstName = "Markus", LastName = "Eisele", GroupId = 3 },
                  new Student { Id = 17, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1012167014612267010/tpIWebKt_400x400.jpg", FirstName = "Mark", LastName = "Reinhold", GroupId = 3 },
                  new Student { Id = 18, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/82608077/abien_icon_400x400.jpg", FirstName = "Adam", LastName = "Bien", GroupId = 4 },
                  new Student { Id = 19, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/618367538016178176/AoS8svVQ_400x400.jpg", FirstName = "Simon", LastName = "Maple", GroupId = 4 },
                  new Student { Id = 20, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/860618035521912832/bS8OJGpX_400x400.jpg", FirstName = "David", LastName = "Blevins", GroupId = 4 },
                  new Student { Id = 21, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1324902443923206152/C7cYJaIy_400x400.jpg", FirstName = "Reza", LastName = "Rahman", GroupId = 8 },
                  new Student { Id = 22, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1646931434/jj-smaller_400x400.jpg", FirstName = "Josh", LastName = "Juneau", GroupId = 8 },
                  new Student { Id = 23, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1181905040736436224/1ypGgL71_400x400.jpg", FirstName = "Ken", LastName = "Fogel", GroupId = 8 },
                  new Student { Id = 24, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1535420431766671360/Pwq-1eJc_400x400.jpg", FirstName = "Tim", LastName = "Cook", GroupId = 18 },
                  new Student { Id = 25, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1484209565788897285/1n6Viahb_400x400.jpg", FirstName = "Chris", LastName = "Lattner", GroupId = 18 },
                  new Student { Id = 26, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1264707114179723275/c9U307g7_400x400.jpg", FirstName = "Ash", LastName = "Furrow", GroupId = 18 },
                  new Student { Id = 27, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1414976054398267396/icGRwR9__400x400.jpg", FirstName = "Ole", LastName = "Begemann", GroupId = 18 },
                  new Student { Id = 28, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/496291231690137600/TmQRrofs_400x400.jpeg", FirstName = "Chris", LastName = "Eidhof", GroupId = 18 },
                  new Student { Id = 29, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/969321564050112513/fbdJZmEh_400x400.jpg", FirstName = "Mattt", LastName = "Thompson", GroupId = 18 },
                  new Student { Id = 30, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1380194129645297665/2OEX5bun_400x400.jpg", FirstName = "Ray", LastName = "Wenderlich", GroupId = 18 },
                  new Student { Id = 31, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Guido-van-Rossum.jpg", FirstName = "Guido", LastName = "Rossum", GroupId = 5 },
                  new Student { Id = 32, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Ewa-Jodlowska.jpg", FirstName = "Ewa", LastName = "Jodlowska", GroupId = 5 },
                  new Student { Id = 33, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Kevin-Goldsmith.jpg", FirstName = "Kevin", LastName = "Goldsmith", GroupId = 5 },
                  new Student { Id = 34, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Jen-Walraven.jpeg", FirstName = "Jen", LastName = "Walraven", GroupId = 6 },
                  new Student { Id = 35, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/audrey_roy_greenfield.jpeg", FirstName = "Audrey", LastName = "Greenfield", GroupId = 6 },
                  new Student { Id = 36, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Daniel-Roy-Greenfeld.jpeg", FirstName = "Daniel", LastName = "Greenfield", GroupId = 6 },
                  new Student { Id = 37, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Reshama-Shaikh.jpg", FirstName = "Reshama", LastName = "Shaikh", GroupId = 9 },
                  new Student { Id = 38, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Tomaz-Muraus.jpg", FirstName = "Tomaz", LastName = "Muraus", GroupId = 9 },
                  new Student { Id = 39, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/tom_christie.jpg", FirstName = "Tom", LastName = "Christie", GroupId = 9 },
                  new Student { Id = 40, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Yury-Selivanov.jpg", FirstName = "Yury", LastName = "Selivanov", GroupId = 12 },
                  new Student { Id = 41, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Raymond-Hettinger.jpg", FirstName = "Raymond", LastName = "Hettinger", GroupId = 12 },
                  new Student { Id = 42, UrlStudentPhoto = "https://newrelic.com/sites/default/files/wp_blog_inline_files/Lukasz-Langa.png", FirstName = "Łukasz", LastName = "Langa", GroupId = 12 }
                  );

            builder.Entity<ContactInfo>().HasData(
                  new ContactInfo { Email = "hejlsberg@gmail.com", Address = "Copenhagen, Denmark", PhoneNumber = "101010101010", StudentId = 1},
                  new ContactInfo { Email = "allen@gmail.com", Address = "USA", PhoneNumber = "101010101010", StudentId = 2 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 3 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 4 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 5 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 6 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 7 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 8 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 9 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 10 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010"  , StudentId = 11 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 12 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 13 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 14 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010" , StudentId = 15 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 16 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 17 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 18 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 19 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 20 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 21 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 22 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 23 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 24 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 25 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 26 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 27 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 28 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 29 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 30 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 31 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 32 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 33 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 34 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 35 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 36 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 37 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 38 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 39 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 40 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 41 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 42 }
                  );


            builder.Entity<Group>().HasData(
                new Group { Id = 1, GroupName = ".Net Developer+Node.js", Speciality = "FullStack Developer" },
                new Group { Id = 2, GroupName = ".Net Developer+Angular", Speciality = "FullStack Developer" },
                new Group { Id = 3, GroupName = "Java Developer+Node.js", Speciality = "FullStack Developer" },
                new Group { Id = 4, GroupName = "Java Developer+Angular", Speciality = "FullStack Developer" },
                new Group { Id = 5, GroupName = "Python Developer+Node.js", Speciality = "FullStack Developer" },
                new Group { Id = 6, GroupName = "Python Developer+Angular", Speciality = "FullStack Developer" },
                new Group { Id = 7, GroupName = ".Net Developer", Speciality = ".Net Developer" },
                new Group { Id = 8, GroupName = "Java Developer", Speciality = "Java Developer" },
                new Group { Id = 9, GroupName = "Python Developer", Speciality = "Python Developer" },
                new Group { Id = 10, GroupName = "Unity Developer + C#", Speciality = "Unity Developer" },
                new Group { Id = 11, GroupName = "Unity Developer", Speciality = "Unity Developer" },
                new Group { Id = 12, GroupName = "Python Developer + Automation QA", Speciality = "Python Developer" },
                new Group { Id = 13, GroupName = "Java Developer+Automation QA", Speciality = "Java Developer" },
                new Group { Id = 14, GroupName = "Automation QA", Speciality = "Automation QA" },
                new Group { Id = 15, GroupName = "WEB Designer", Speciality = "WEB Designer" },
                new Group { Id = 16, GroupName = "Node js", Speciality = "Node js" },
                new Group { Id = 17, GroupName = "Angular", Speciality = "Angular" },
                new Group { Id = 18, GroupName = "iOS Developer", Speciality = "iOS Developer" }

            );


            builder.Entity<Course>().HasData(new Course { Id = 1, UrlCoursLogo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRJIAVHooYcPB2Nm3n_TmAwq4FcO8-Vl5i4g&usqp=CAU", CourseName = ".Net Developer", CourseDescription = "Learn how to write high performance and scalable .NET Core and ASP.NET Core applications in C#" },
                  new Course { Id = 2, UrlCoursLogo = "https://www.whatap.io/ko/blog/12/img/java_history.webp", CourseName = "Java Developer", CourseDescription = "Become a confident industry ready core Java developer and get certified as a Java professional!" },
                  new Course { Id = 3, UrlCoursLogo = "https://brainup.space/wp-content/uploads/2021/09/qa-engineer-300x300.jpg", CourseName = "Automation QA", CourseDescription = "Practical course for QA testers" },
                  new Course { Id = 4, UrlCoursLogo = "https://contentstatic.techgig.com/photo/88317143/how-and-why-to-become-a-certified-python-programmer-in-2022.jpg?116970", CourseName = "Python Developer", CourseDescription = "Learn Python like a Professional Start from the basics and go all the way to creating your own applications" },
                  new Course { Id = 5, UrlCoursLogo = "https://gagadget.com/media/post_big/unity-best-tools-january-2022-800x449.jpg", CourseName = "Unity Developer", CourseDescription = "From Complete Beginner To Professional Game Developer. Learn To Code In C# And Create Stunning Games With Unity" },
                  new Course { Id = 6, UrlCoursLogo = "https://media-exp2.licdn.com/dms/image/C510BAQEeZG6Lx64row/company-logo_200_200/0/1543775201739?e=2147483647&v=beta&t=oJqpcDJZIr5ypO0gV9fN3O0M224JdKCTDQUFwgpHHEE", CourseName = "iOS Developer", CourseDescription = "Everything you need to transition from hobbyist to professional iOS developer" },
                  new Course { Id = 7, UrlCoursLogo = "https://cdn.iconscout.com/icon/free/png-256/node-js-3550841-2970426.png", CourseName = "Node js", CourseDescription = "Get advanced with Node.Js! Learn caching with Redis, speed up through clustering, and add image upload with S3 and Node!" },
                  new Course { Id = 8, UrlCoursLogo = "https://www.varnitec.com/sites/default/files/2020-06/2.jpg", CourseName = "WEB Designer", CourseDescription = "Launch a career as a web designer by learning HTML5, CSS3, responsive design, Sass and more!" },
                  new Course { Id = 9, UrlCoursLogo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZoqNQ3pxtbGCECwyUcKbiHK9lbeW86ZBmqJ9HOBBsBBrjq9OmSfxppeT6_O5CCJKnk50&usqp=CAU", CourseName = "Angular", CourseDescription = "Build a real e-commerce app with Angular, Firebase and Bootstrap 4" }

            );
            builder.Entity<Course_Group>().HasData(
                new Course_Group { Id = 1, CourseId = 1, GroupId = 1 },
                new Course_Group { Id = 2, CourseId = 7, GroupId = 1 },
                new Course_Group { Id = 3, CourseId = 1, GroupId = 2 },
                new Course_Group { Id = 4, CourseId = 9, GroupId = 2 },
                new Course_Group { Id = 5, CourseId = 2, GroupId = 3 },
                new Course_Group { Id = 6, CourseId = 7, GroupId = 3 },
                new Course_Group { Id = 7, CourseId = 2, GroupId = 4 },
                new Course_Group { Id = 8, CourseId = 9, GroupId = 4 },
                new Course_Group { Id = 9, CourseId = 7, GroupId = 5 },
                new Course_Group { Id = 10, CourseId = 4, GroupId = 5 },
                new Course_Group { Id = 11, CourseId = 9, GroupId = 6 },
                new Course_Group { Id = 12, CourseId = 4, GroupId = 6 },
                new Course_Group { Id = 13, CourseId = 1, GroupId = 7 },
                new Course_Group { Id = 14, CourseId = 2, GroupId = 8 },
                new Course_Group { Id = 15, CourseId = 4, GroupId = 9 },
                new Course_Group { Id = 16, CourseId = 1, GroupId = 10 },
                new Course_Group { Id = 17, CourseId = 5, GroupId = 10 },
                new Course_Group { Id = 18, CourseId = 5, GroupId = 11 },
                new Course_Group { Id = 19, CourseId = 4, GroupId = 12 },
                new Course_Group { Id = 20, CourseId = 3, GroupId = 12 },
                new Course_Group { Id = 21, CourseId = 3, GroupId = 13 },
                new Course_Group { Id = 22, CourseId = 2, GroupId = 13 },
                new Course_Group { Id = 23, CourseId = 3, GroupId = 14 },
                new Course_Group { Id = 24, CourseId = 8, GroupId = 15 },
                new Course_Group { Id = 25, CourseId = 7, GroupId = 16 },
                new Course_Group { Id = 26, CourseId = 9, GroupId = 17 },
                new Course_Group { Id = 27, CourseId = 6, GroupId = 18 }
                );


        }
    }
}
