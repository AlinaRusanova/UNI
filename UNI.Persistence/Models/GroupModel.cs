using System.ComponentModel.DataAnnotations;
using UNI.Domain.Entities;

namespace UNI.Persistence.Models
{
    public class GroupModel:BaseTraceModel
    {
        [Display(Name = "Group's Name")]
        [Required(ErrorMessage = "Group's Name is required")]
        public string GroupName { get; set; }

        [Display(Name = "Speciality")]
        [Required(ErrorMessage = "Group's Name is required")]
        public string Speciality { get; set; }

        public IEnumerable<Student>? ListOfStudents { get; set; }
        public IEnumerable<Course>? ListOfCourses { get; set; }
    }
}
