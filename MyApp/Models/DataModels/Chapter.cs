using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }

        [Required]
        public string List = string.Empty;
    }
}