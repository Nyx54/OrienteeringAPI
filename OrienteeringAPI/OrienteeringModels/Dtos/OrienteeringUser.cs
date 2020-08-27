using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringUser : IEntity
    {
        [Required]
        public long Id { get; set; }
        [MaxLength(256)]
        public string Login { get; set; }
        public string Password { get; set; }
        [MaxLength(1)]
        public string Profil { get; set; }
    }
}
