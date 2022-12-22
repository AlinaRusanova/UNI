
namespace UNI.Domain.Entities
{
    public class Student: Entity
    {
        public string UrlStudentPhoto { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
