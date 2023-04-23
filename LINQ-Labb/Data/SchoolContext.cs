using LINQ_Labb.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Labb.Data {
      
    internal class SchoolContext : DbContext {

        //Representing "sessions from the database"
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        //public SchoolContext(): base() {



        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer("Data Source = LAPTOP-2JBKEDH4; Initial Catalog = LINQLabb; Integrated Security = True;");

        }

    }

}
