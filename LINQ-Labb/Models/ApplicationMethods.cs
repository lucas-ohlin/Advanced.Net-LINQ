using LINQ_Labb.Data;
using LINQ_Labb.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Models {

    //Methods the "ApplicationUI" or the application uses
    internal class ApplicationMethods {

        public static SchoolContext context = new SchoolContext();

        public static void GetTeachers() {

            var teachers = context.Subjects.Where(t => t.Name == "Math")
                                           .SelectMany(t => t.Teachers).ToList();

            Console.WriteLine("\n\tMath Teacher's:");
            foreach (var teacher in teachers)
                Console.WriteLine($"ID : {teacher.TeacherId} | Name : {teacher.FirstName} {teacher.LastName}.");

        }

        public static void GetStudents() {

            var students = context.Students.Include(t => t.Teacher);

            Console.WriteLine("\n\tStudent's & their teacher:");
            foreach (var student in students)
                Console.WriteLine($"ID : {student.StudentId} | Name : {student.FirstName} {student.LastName} | Teacher : {student.Teacher.FirstName} {student.Teacher.LastName}");

        }

        public static void ContainsSubject() {

            var contains = context.Subjects.Where(t => t.Name == "Programming 1").FirstOrDefault();

            //This will always run since it's not a user input
            if (contains != null)
                Console.WriteLine($"Subject : {contains.Name} does exist");
            else
                Console.WriteLine("That subject does not exist");

        }

        public static void EditSubject() {

            var subject = context.Subjects.Where(s => s.Name == "Programming 2").FirstOrDefault();

            if (subject != null) {
                //Change the subject name to OOP
                subject.Name = "OOP";
                context.SaveChanges();

                Console.WriteLine($"Changed name of 'Programming 2' to {subject.Name}.");
            } 
            else
                Console.WriteLine("No such subject doesn't exist.");

        }

        public static void ChangeTeacher() {

            //var originalTeacher = context.Teachers.Where(t => t.FirstName == "Anas" ).SelectMany(s => s.Students).First();
            var test = context.Students.Where(x => x.Teacher.FirstName == "Anas").First();
            var newTeacher = context.Teachers.Where(t => t.FirstName == "Reidar" ).First();

            if (test != null) {

                test.Teacher = newTeacher;
                context.SaveChanges();

                Console.WriteLine($"Changed student's teacher : {test.FirstName} to {newTeacher.FirstName}.");
            }
            else
                Console.WriteLine("No student has such a teacher.");

        }

        public static void AddData() {

            //TONOTE: Just want to highlight this could all easily be done with Lists
            //But ran into migration troubles earlier and wamted to make sure it wasn't anything
            //To do with any information provided here so that's why everything is split 

            //Create the courses
            var course1 = new Course() { Name = "SUT22" };
            var course2 = new Course() { Name = "SUT21" };

            //List of classes
            ICollection<Course> courseList = new List<Course> { course1, course2 };
            ICollection<Course> courseList2 = new List<Course> { course1 };

            //Creation of the teachers
            var teacher1 = new Teacher() { FirstName = "Anas", LastName = "Anasson" };
            var teacher2 = new Teacher() { FirstName = "Reidar", LastName = "Reidarsson" };
            var teacher3 = new Teacher() { FirstName = "Tobias", LastName = "Tobiasson" };

            //List of teachers 
            ICollection<Teacher> teacherList = new List<Teacher> { teacher1, teacher2, teacher3 };
            ICollection<Teacher> teacherList2 = new List<Teacher> { teacher1, teacher3 };

            //Subjects with teacher's that teach out said subject and what courses have them
            var subject1 = new Subject() { Name = "Programming 1", Teachers = teacherList, Courses = courseList2 };
            var subject2 = new Subject() { Name = "Programming 2", Teachers = teacherList2, Courses = courseList };
            var subject3 = new Subject() { Name = "Math", Teachers = teacherList, Courses = courseList };

            //The students
            var student1 = new Student() { FirstName = "Lucas", LastName = "Öhlin", Teacher = teacher2, Course = course1 };
            var student2 = new Student() { FirstName = "Kalle", LastName = "Johansson", Teacher = teacher2, Course = course1 };
            var student3 = new Student() { FirstName = "Mackan", LastName = "Petersson", Teacher = teacher3, Course = course1 };
            var student4 = new Student() { FirstName = "Johan", LastName = "Kallesson", Teacher = teacher1, Course = course2 };
            var student5 = new Student() { FirstName = "Eddan", LastName = "Edvon", Teacher = teacher1, Course = course2 };
            var student6 = new Student() { FirstName = "Emil", LastName = "Emillson", Teacher = teacher1, Course = course2 };

            //Using our Context to our database from Data/SchoolContext.cs
            using (var context = new SchoolContext()) {
                //Save data to the tables
                context.Courses.AddRange(course1, course2);
                context.Teachers.AddRange(teacher1, teacher2, teacher3);
                context.Subjects.AddRange(subject1, subject2, subject3);
                context.Students.AddRange(student1, student2, student3, student4, student5, student6);

                //Save everything to the databse
                context.SaveChanges();
            }

            Console.WriteLine("Adding the Data was a success...");
        }
        
        public static void Enter() {

            Console.WriteLine("\nPress Enter to continue");

            //Gets the key that's pressed
            ConsoleKeyInfo e;
            do {
                e = Console.ReadKey();
            } while (e.Key != ConsoleKey.Enter);
            Console.Clear();

        }

    }

}
