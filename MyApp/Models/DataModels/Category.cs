using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        //Relaciones
        public ICollection<Course> Courses {get;set;} = new List<Course>();
    }
}