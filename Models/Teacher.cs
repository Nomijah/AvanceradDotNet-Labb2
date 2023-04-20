using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb2.Models
{
    internal class Teacher
    {
        public Teacher() 
        {
            this.Courses = new HashSet<Course>();
            this.Subjects = new HashSet<Subject>();
        }
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
