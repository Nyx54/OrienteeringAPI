using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringTeam : IEntity
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public long Code { get; set; }
    }
}
