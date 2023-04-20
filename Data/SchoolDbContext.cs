using AvanceradDotNet_Labb2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb2.Data
{
    internal class SchoolDbContext : DbContext
    {
        public SchoolDbContext(): base()
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LAPTOP-PCBVJLD6;Initial Catalog=AvanceradDotNetLabbb2;Integrated Security = True;TrustServerCertificate = True;");
        }

    }
}
