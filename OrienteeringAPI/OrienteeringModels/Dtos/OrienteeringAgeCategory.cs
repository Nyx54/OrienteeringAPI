using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringAgeCategory : IEntity
    {
        [Required]
        public long Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(12)]
        public string ShortName { get; set; }
        public bool Sex { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
    }
}
