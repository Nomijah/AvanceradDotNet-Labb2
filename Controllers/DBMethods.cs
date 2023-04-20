using AvanceradDotNet_Labb2.Data;
using AvanceradDotNet_Labb2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb2.Controllers
{
    internal class DBMethods
    {
        public static List<Teacher> GetTeachersBySubject(string subject)
        {
            List<Teacher> teachers = new List<Teacher>();

            using (var context = new SchoolDbContext())
            {
                teachers = context.Subjects
                    .Where(s => s.Name == subject)
                    .SelectMany(s => s.Teachers).ToList();
            }
            return teachers;
        }

        public static List<Teacher> GetTeachersBySubject(int subjectId)
        {
            List<Teacher> teachers = new List<Teacher>();

            using (var context = new SchoolDbContext())
            {
                teachers = context.Subjects
                    .Where(s => s.SubjectId == subjectId)
                    .SelectMany(s => s.Teachers).ToList();
            }
            return teachers;
        }

        public static void PrintStudentsWithTeachers()
        {
            using (var context = new SchoolDbContext())
            {
                var CourseTeacherList = context.Courses
                    .Join(context.Teachers,
                    c => c.Teacher.TeacherId,
                    t => t.TeacherId,
                    (c, t) => new
                    {
                        tName = t.FirstName + " " + t.LastName,
                        courseId = c.CourseId
                    })
                    .Join(context.Students,
                    t => t.courseId,
                    s => s.CourseId,
                    (t, s) => new
                    {
                        studentName = s.FirstName + " " + s.LastName,
                        teacherName = t.tName
                    }
                    );

                int counter = 0;
                Console.WriteLine("Nr.\tElev\t\t\tLärare");
                foreach (var item in CourseTeacherList)
                {
                    counter++;
                    Console.WriteLine(counter + ". \t" + item.studentName + "     \t" + item.teacherName);
                }
            }
        }

        public static void RemoveStudent(int studentId)
        {
            using (var context = new SchoolDbContext())
            {
                var studentToRemove = context.Students.FirstOrDefault(s => s.StudentId == studentId);
                context.Students.Remove(studentToRemove);
                context.SaveChanges();
            }
        }

        public static void CheckIfSubjectExists(string courseName)
        {
            using (var context = new SchoolDbContext())
            {
                if (context.Subjects.Contains(context.Subjects.FirstOrDefault(s => s.Name == courseName)))
                {
                    Console.WriteLine($"Ämnet {courseName} finns i databasen.");
                }
                else
                {
                    Console.WriteLine($"Ämnet {courseName} kunde inte hittas.");
                }
            }
        }

        public static void ChangeSubject(string fromCourseName, string toCourseName)
        {
            using (var context = new SchoolDbContext())
            {
                if (context.Subjects.Contains(context.Subjects.FirstOrDefault(s => s.Name == fromCourseName)))
                {
                    context.Subjects.FirstOrDefault(s => s.Name == fromCourseName).Name = toCourseName;
                    context.SaveChanges();
                    Console.WriteLine($"Kursen {fromCourseName} har nu ändrats till {toCourseName}.");
                }
                else
                {
                    Console.WriteLine("Kursen som skulle ändras existerar inte.");
                }

            }
        }

        public static void ChangeTeacher(string prevFirstName, string newFirstName, string courseName)
        {
            using (var context = new SchoolDbContext())
            {
                var newTeacher = context.Teachers
                    .FirstOrDefault(t => t.FirstName == newFirstName);
                var courseToChange = context.Courses
                    .Include(t => t.Teacher)
                    .FirstOrDefault(c => c.Name == courseName);

                if (newTeacher != null
                    && courseToChange != null
                    && courseToChange.Teacher.FirstName == prevFirstName)
                {
                    courseToChange.Teacher = newTeacher;
                    context.SaveChanges();
                    Console.WriteLine($"Kursen {courseToChange.Name} har nu " +
                        $"bytt lärare från {prevFirstName} till {newFirstName}.");
                }
                else if (courseToChange == null)
                {
                    Console.WriteLine("Kursen du angivit finns inte i databasen.");
                }
                else if (newTeacher != null)
                {
                    Console.WriteLine("Läraren du vill byta till finns inte " +
                        "i databasen.");
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning.");
                }
            }
        }

        public static void ChangeTeacher(string newFirstName, string courseName)
        {
            using (var context = new SchoolDbContext())
            {
                string prevFirstName = context.Courses
                    .Include(t => t.Teacher)
                    .FirstOrDefault(c => c.Name == courseName).Teacher.FirstName;
                var newTeacher = context.Teachers
                    .FirstOrDefault(t => t.FirstName == newFirstName);
                var courseToChange = context.Courses
                    .Include(t => t.Teacher)
                    .FirstOrDefault(c => c.Name == courseName);

                if (newTeacher != null
                    && courseToChange != null)
                {
                    courseToChange.Teacher = newTeacher;
                    context.SaveChanges();
                    Console.WriteLine($"Kursen {courseToChange.Name} har nu " +
                        $"bytt lärare från {prevFirstName} till {newFirstName}.");
                }
                else if (courseToChange == null)
                {
                    Console.WriteLine("Kursen du angivit finns inte i databasen.");
                }
                else if (newTeacher != null)
                {
                    Console.WriteLine("Läraren du vill byta till finns inte " +
                        "i databasen.");
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning.");
                }
            }
        }

        public static void PrintSubjects()
        {
            using (var context = new SchoolDbContext())
            {
                var subjects = context.Subjects.ToList();
                Console.WriteLine("Dessa ämnen finns i systemet:");
                foreach (var subject in subjects)
                {
                    Console.WriteLine(subject.Name);
                }
                Console.WriteLine();
            }
        }

        public static void PrintCourses()
        {
            using (var context = new SchoolDbContext())
            {
                var courses = context.Courses.ToList();
                Console.WriteLine("Dessa klasser finns i systemet:");
                foreach (var course in courses)
                {
                    Console.WriteLine(course.Name);
                }
                Console.WriteLine();
            }
        }
    }
}
