using System.ComponentModel.DataAnnotations;
using UNI.Domain.Entities;

namespace UNI.Domain
{
    public class ContactInfo// : Entity
    {
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int? StudentId { get; set; } 

        public Student? Student { get; set; }

    }
}
