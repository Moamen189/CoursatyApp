using System.ComponentModel.DataAnnotations;
using System;

namespace CoursatyApp.DTOs
{
    public class CourseDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Creation { get; set; }


        public string Image { get; set; }

        public int? Category { get; set; }
    }
}
