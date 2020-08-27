using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringCourse : IEntity
    {
        [Required]
        public long Id { get; set; }
        public long RaceId { get; set; }
        public long? CategoryAge { get; set; }
        public long? CategoryColor { get; set; }
        public bool Free { get; set; }
    }
}
