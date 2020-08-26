using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringLeague : IEntity
    {
        [Required]
        public long Id { get; set; }
        [MaxLength(6)]
        public string ShortName { get; set; }
        public string Name { get; set; }
    }
}
