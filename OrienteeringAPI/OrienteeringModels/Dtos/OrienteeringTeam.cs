using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringTeam : IEntity
    {
        [Required]
        public long Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(12)]
        public string ShortName { get; set; }
        public int Code { get; set; }
        public long LeagueId { get; set; }
    }
}
