using AvanceradDotNet_Labb2.Controllers;
using AvanceradDotNet_Labb2.Data;
using AvanceradDotNet_Labb2.Models;
using Microsoft.EntityFrameworkCore;

namespace AvanceradDotNet_Labb2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interface.Run();
            //var teachers = GetTeachersBySubject("Matte");

            //foreach (var item in teachers)
            //{
            //    Console.WriteLine(item.FirstName);
            //}

            // PrintStudentsWithTeachers();

            //CheckIfSubjectExists("Programmering 1");

            //ChangeSubject( "Programmering 2","OOP");

            //ChangeTeacher("Erik", "Maria", "SUT22");
        }
    }
}