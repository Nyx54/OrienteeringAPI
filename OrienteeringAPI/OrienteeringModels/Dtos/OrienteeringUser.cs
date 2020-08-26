using OrienteeringModels.Dtos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringUser : IEntity
    {
        [Required]
        public long Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [MaxLength(1)]
        public string Profil { get; set; }
        public long TeamId { get; set; }
    }
}
