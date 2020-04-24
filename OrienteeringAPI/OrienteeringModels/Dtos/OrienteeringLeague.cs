using OrienteeringModels.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrienteeringModels.Dtos
{
    public class OrienteeringLeague : IEntity
    {
        [Required]
        public long Id { get; set; }
        [MaxLength(6)]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
