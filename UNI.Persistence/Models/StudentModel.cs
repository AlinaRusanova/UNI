using System.ComponentModel.DataAnnotations;


namespace UNI.Persistence.Models
{
    public class StudentModel:BaseTraceModel
    {
        [Display(Name = "Url for student's picture")]
        [Required(ErrorMessage = "Student's picture is required")]
        public string UrlStudentPhoto { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 25 chars")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Surname is required")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Address can not be more than 50 characters long")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MinLength(10)]
        [Required(ErrorMessage = "The phone number is at least 10 characters long")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The entered value does not match the email format")]
        public string Email { get; set; }

        [Display(Name = "Group")]
        [Required(ErrorMessage = "GroupId is required")]
        public int? GroupId { get; set; }

        public int? ContactInfoId { get; set; }

        //     public string? GroupName { get; set; }


        //public Group? Group { get; set; }
    }
}
