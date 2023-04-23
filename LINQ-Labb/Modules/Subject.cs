using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Modules {

    internal class Subject {

        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        //Multiple teachers can teach the same subject
        public ICollection<Teacher> Teachers { get; set; }
        //Multiple Course's(classe's) can have the same subject
        public ICollection<Course> Courses { get; set; }

        //"hashset" is to help avoid NullReferenceExceptions
        //when no records are fetched or exist in the many side of the relationship
        //public Subject() {
        //    this.Teachers = new HashSet<Teacher>();
        //    this.Courses = new HashSet<Course>();
        //}

    }

}
