using System;
using System.ComponentModel.DataAnnotations;

namespace CoursatyApp.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime  Creation_Date { get; set; }



    }
}
