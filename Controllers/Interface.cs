using AvanceradDotNet_Labb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDotNet_Labb2.Controllers
{
    internal class Interface
    {
        public static void Run()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("1. Hämta alla lärare i ett specifikt ämne\n" +
                    "2. Visa alla elever med respektive lärare.\n" +
                    "3. Kolla om ett ämne finns i databasen.\n" +
                    "4. Ändra namn på ett ämne.\n" +
                    "5. Ändra lärare på en klass.\n" +
                    "Q. Avsluta.");
                string userInput = Console.ReadLine();
                if (userInput != null)
                {
                    switch (userInput.ToLower())
                    {
                        case "1":
                            GetTeacherInput();
                            break;
                        case "2":
                            DBMethods.PrintStudentsWithTeachers();
                            AnyKeyContinue();
                            break;
                        case "3":
                            DBMethods.CheckIfSubjectExists(GetSubjectInput());
                            AnyKeyContinue();
                            break;
                        case "4":
                            ChangeSubjectName();
                            AnyKeyContinue();
                            break;
                        case "5":
                            ChangeTeacher();
                            AnyKeyContinue();
                            break;
                        case "q":
                            run = false;
                            break;
                        default:
                            Console.WriteLine("Felaktig inmatning.");
                            AnyKeyContinue();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning.");
                    AnyKeyContinue();
                }
            }
        }

        public static void GetTeacherInput()
        {
            DBMethods.PrintSubjects();
            Console.WriteLine("Skriv det ämne du vill hämta data ifrån:");
            string subjectInput = Console.ReadLine();
            PrintTeachers(DBMethods.GetTeachersBySubject(subjectInput));
        }

        public static void PrintTeachers(List<Teacher> teachers)
        {
            foreach (var item in teachers)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            AnyKeyContinue();
        }

        public static void AnyKeyContinue()
        {
            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
            Console.Clear();
        }

        public static string GetSubjectInput()
        {
            Console.WriteLine("Skriv ämnet:");
            return Console.ReadLine();
        }

        public static void ChangeSubjectName()
        {
            Console.WriteLine("Vilket ämne vill du ändra namn på?");
            string courseToChange = GetSubjectInput();
            Console.WriteLine("Vilket ämne vill du ändra till?");
            string newName = GetSubjectInput();
            DBMethods.ChangeSubject(courseToChange, newName);
        }

        public static void ChangeTeacher()
        {
            DBMethods.PrintCourses();
            Console.WriteLine("Vilken klass vill du byta lärare på?");
            string courseToChange = Console.ReadLine();
            Console.WriteLine("Vad heter läraren du vill byta till? (förnamn)");
            string newTeacher = Console.ReadLine();
            DBMethods.ChangeTeacher( newTeacher, courseToChange);
        }
    }
}
