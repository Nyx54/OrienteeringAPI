using OrienteeringModels.Data;
using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringRace : IEntity
    {
        [Required]
        public long Id { get; set; }
        public RaceFormat RaceFormat { get; set; }
        public long TeamOrganizer { get; set; }
        public long Tracer { get; set; }
    }
}
