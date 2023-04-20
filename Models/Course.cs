using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb2.Models
{
    internal class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Subjects = new HashSet<Subject>();
        }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
