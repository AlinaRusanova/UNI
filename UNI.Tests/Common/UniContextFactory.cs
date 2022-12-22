using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNI.Domain;
using UNI.Domain.Entities;

namespace UNI.Tests.Common
{
    public class UniContextFactory
    {
        public async Task<UniDbContext> GetDatabaseContext()
        { 
         var options = new DbContextOptionsBuilder<UniDbContext>()
                .UseInMemoryDatabase("UniTest")
                .Options;

            var context = new UniDbContext(options);
            
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();

            context.Courses.AddRange(
                  new Course { Id = 1, UrlCoursLogo = "https://dotnetfoundation.org/img/dot_bot.png", CourseName = ".Net Developer", CourseDescription = "Learn how to write high performance and scalable .NET Core and ASP.NET Core applications in C#" },
                  new Course { Id = 2, UrlCoursLogo = "https://www.whatap.io/ko/blog/12/img/java_history.webp", CourseName = "Java Developer", CourseDescription = "Become a confident industry ready core Java developer and get certified as a Java professional!" },
                  new Course { Id = 3, UrlCoursLogo = "https://brainup.space/wp-content/uploads/2021/09/qa-engineer-300x300.jpg", CourseName = "Automation QA", CourseDescription = "Practical course for QA testers" },
                  new Course { Id = 4, UrlCoursLogo = "https://contentstatic.techgig.com/photo/88317143/how-and-why-to-become-a-certified-python-programmer-in-2022.jpg?116970", CourseName = "Python Developer", CourseDescription = "Learn Python like a Professional Start from the basics and go all the way to creating your own applications" }                
                );

            context.Groups.AddRange(
                new Group { Id = 1, GroupName = ".Net Developer+Node.js", Speciality = "FullStack Developer" },
                new Group { Id = 2, GroupName = ".Net Developer+Angular", Speciality = "FullStack Developer" },
                new Group { Id = 3, GroupName = "Java Developer+Node.js", Speciality = "FullStack Developer" },
                new Group { Id = 4, GroupName = "Java Developer+Angular", Speciality = "FullStack Developer" },
                new Group { Id = 5, GroupName = "Python Developer+Node.js", Speciality = "FullStack Developer" }
                );

            context.Courses_Groups.AddRange(
                new Course_Group { Id = 1, CourseId = 1, GroupId = 1 },
                new Course_Group { Id = 2, CourseId = 7, GroupId = 1 },
                new Course_Group { Id = 3, CourseId = 1, GroupId = 2 },
                new Course_Group { Id = 4, CourseId = 9, GroupId = 2 },
                new Course_Group { Id = 5, CourseId = 2, GroupId = 3 },
                new Course_Group { Id = 6, CourseId = 7, GroupId = 3 },
                new Course_Group { Id = 7, CourseId = 2, GroupId = 4 },
                new Course_Group { Id = 8, CourseId = 9, GroupId = 4 },
                new Course_Group { Id = 9, CourseId = 7, GroupId = 5 },
                new Course_Group { Id = 10, CourseId = 4, GroupId = 5 }
                );


            context.Students.AddRange(
                  new Student { Id = 1, UrlStudentPhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Anders_Hejlsberg.jpg/274px-Anders_Hejlsberg.jpg", FirstName = "Anders", LastName = "Hejlsberg", GroupId = 1 },
                  new Student { Id = 2, UrlStudentPhoto = "https://odetocode.com/Images/scott_allen_7.jpg", FirstName = "Scott", LastName = "Allen", GroupId = 1 },
                  new Student { Id = 3, UrlStudentPhoto = "https://www.irisclasson.com/promo/irisclasson.jpg.webp", FirstName = "Iris", LastName = "Classon", GroupId = 1 },
                  new Student { Id = 4, UrlStudentPhoto = "http://www.gravatar.com/avatar/3c4e7f8b11f8b8c1d77ebb70678097b4?s=128?s=160", FirstName = "David", LastName = "Ebbo", GroupId = 1 },
                  new Student { Id = 5, UrlStudentPhoto = "https://0.gravatar.com/avatar/069d9cb18fdf2956b0dcee852627fb08?s=96&d=https%3A%2F%2F0.gravatar.com%2Favatar%2Fad516503a11cd5ca435acc9bb6523536%3Fs%3D96", FirstName = "Damian", LastName = "Edwards", GroupId = 2 }
                );

            context.ContactsInfo.AddRange(
                  new ContactInfo { Email = "hejlsberg@gmail.com", Address = "Copenhagen, Denmark", PhoneNumber = "101010101010", StudentId = 1 },
                  new ContactInfo { Email = "allen@gmail.com", Address = "USA", PhoneNumber = "101010101010", StudentId = 2 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 3 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 4 },
                  new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 5 }
                );

            context.SaveChanges();
            return context;
        }


    }
}
