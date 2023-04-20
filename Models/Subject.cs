using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb2.Models
{
    internal class Subject
    {
        public Subject() 
        { 
            this.Courses = new HashSet<Course>();
            this.Teachers = new HashSet<Teacher>();
        }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
