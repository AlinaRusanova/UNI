
namespace UNI.Domain.Entities
{
    public class Group:Entity
    {
        public string GroupName { get; set; }

        public string Speciality { get; set; }

        public IEnumerable<Student>? ListOfStudents { get; set; }
        public IEnumerable<Course_Group>? Course_Groups{ get; set; }
    }
}
