using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Modules {

    //The course is basically the "class" 
    internal class Course {

        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        //The teacher in charge of the course(class)
        //public Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        //A course(class) can have multiple subjects at the same time
        //Ex: Programming, Webbdevelopment & Math
        public virtual ICollection<Subject> Subjects { get; set; }

        //"hashset" is to help avoid NullReferenceExceptions
        //when no records are fetched or exist in the many side of the relationship
        //public Course() {
        //    this.Students = new HashSet<Student>();
        //    this.Subjects = new HashSet<Subject>();
        //}

    }

}
