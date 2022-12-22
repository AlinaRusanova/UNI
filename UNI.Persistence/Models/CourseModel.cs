using System.ComponentModel.DataAnnotations;
using UNI.Domain.Entities;

namespace UNI.Persistence.Models
{
    public class CourseModel : BaseTraceModel
    {
        [Display(Name = "Url course's logo")]
        [Required(ErrorMessage = "Course's logo is required")]
        public string UrlCoursLogo { get; set; }

        [Required(ErrorMessage = "Course's name is required")]
        [Display(Name = "Course's Name")]
        public string CourseName { get; set; }

        [Display(Name = "Course's Description")]
        public string? CourseDescription { get; set; }
        public IEnumerable<Course_Group>? Course_Groups { get; set; }
    }
}
