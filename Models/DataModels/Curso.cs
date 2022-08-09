using System.ComponentModel.DataAnnotations;

namespace universityApiBackend.Models.DataModels
{
    public enum Levels { basic, intermediate, advanced }

    public class Curso : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string LongDescription { get; set; } = string.Empty;

        [Required]
        public string TargetPublic { get; set; } = string.Empty;

        [Required]
        public string Targets { get; set; } = string.Empty;

        [Required]
        public string Requirements { get; set; } = string.Empty;

        [Required, EnumDataType(typeof(Levels))]
        public Levels Levels { get; set; } = Levels.basic;
    }
}