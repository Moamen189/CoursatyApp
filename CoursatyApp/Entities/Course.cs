using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursatyApp.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime  Creation_Date { get; set; }

        public string Image_Id { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }




    }
}
