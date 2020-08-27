using OrienteeringModels.Dtos.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringRace : IEntity
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public long FormatId { get; set; }
        public bool CN { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        [MaxLength(256)]
        public string City { get; set; }
        public int? CodePostal { get; set; }
        public long TeamOrganizer { get; set; }
        public long Tracer { get; set; }
        public DateTime? CompetitionDate { get; set; }
        public TimeSpan? CompetitionStart { get; set; }
    }
}
