using System.ComponentModel.DataAnnotations;

namespace CoursatyApp.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
