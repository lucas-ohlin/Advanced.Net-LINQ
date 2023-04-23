using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Models {

    internal class ApplicationUI {

        public static void Run() {

            bool run = true;
            while (run) {

                Console.WriteLine("\n" +
                    "1. Get all teachers that teaches math.\r\n" +    
                    "2. Get all students with their teacher.\r\n" +   
                    "3. Check if certain subject exists.\r\n" +   
                    "4. Edit a subject's name.\r\n" +   
                    "5. Edit a course's teacher.\r\n"+
                    "0. Quit application.\r\n"
                );

                byte choice;
                if (!byte.TryParse(Console.ReadLine(), out choice))
                    Console.WriteLine("\nNumber 1-5 only.");

                switch (choice) {

                    default: //If not a valid choice in this case
                        Console.WriteLine("Not a valid choice.");
                        ApplicationMethods.Enter();
                        break;
                    case 1:
                        ApplicationMethods.GetTeachers();
                        ApplicationMethods.Enter();
                        break;
                    case 2:
                        ApplicationMethods.GetStudents();
                        ApplicationMethods.Enter();
                        break;
                    case 3:
                        ApplicationMethods.ContainsSubject();
                        ApplicationMethods.Enter();
                        break;
                    case 4:
                        ApplicationMethods.EditSubject();
                        ApplicationMethods.Enter();
                        break;
                    case 5:
                        ApplicationMethods.ChangeTeacher();
                        ApplicationMethods.Enter();
                        break;
                    case 0:
                        run = false;
                        Console.WriteLine("Quitting...");
                        break;

                }

            }

        }

    }

}
