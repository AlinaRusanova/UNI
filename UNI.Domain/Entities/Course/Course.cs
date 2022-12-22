
namespace UNI.Domain.Entities
{
    public class Course:Entity
    {
        public string UrlCoursLogo { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public IEnumerable<Course_Group>? Course_Groups { get; set; }
    }
}
