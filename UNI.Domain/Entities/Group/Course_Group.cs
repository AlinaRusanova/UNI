using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNI.Domain.Entities
{
    public class Course_Group:Entity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
