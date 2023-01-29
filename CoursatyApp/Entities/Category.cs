using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoursatyApp.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public virtual ICollection<Course> courses { get; set; } = new HashSet<Course>();
    }
}
