using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Modules {

    internal class Teacher {

        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public virtual ICollection<Course> Students { get; set; }
        //One teacher can teach multiple subjects
        public virtual ICollection<Subject> Subjects { get; set; }

        //"hashset" is to help avoid NullReferenceExceptions
        //when no records are fetched or exist in the many side of the relationship
        //public Teacher() {
        //    this.Courses = new HashSet<Course>();
        //    this.Subjects = new HashSet<Subject>();
        //}

    }

}
