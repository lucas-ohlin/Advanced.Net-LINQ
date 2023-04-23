using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Modules {

    internal class Student {

        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Incase the student don't want to have a gender
        public Teacher Teacher { get; set; }
        //The CourseId (classId) is to tie the sutdent to a class
        public Course Course { get; set; }

    }

}
