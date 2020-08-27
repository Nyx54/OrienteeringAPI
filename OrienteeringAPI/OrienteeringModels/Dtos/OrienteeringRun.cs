using OrienteeringModels.Dtos.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringRun : IEntity
    {
        [Required]
        public long Id { get; set; }
        public long RaceId { get; set; }
        public long RunnerId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? Result { get; set; }
        [MaxLength(256)]
        public string Status { get; set; }
        public string Splits { get; set; }
    }
}
