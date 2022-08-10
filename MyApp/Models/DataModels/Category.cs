using System.ComponentModel.DataAnnotations;

namespace universityApiBackend.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        //Relaciones
        public ICollection<Curso> Cursos {get;set;} = new List<Curso>();
    }
}