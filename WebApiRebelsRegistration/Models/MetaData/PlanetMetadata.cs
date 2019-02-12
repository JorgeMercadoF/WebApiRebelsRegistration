using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiRebelsRegistration.Models
{
    [MetadataType(typeof(PlanetMetadata))]
    public partial class Planets
    {

    }

    public class PlanetMetadata
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es requerido el nombre del planeta")]
        [MaxLength(20, ErrorMessage = "Longitud maxima de 200")]
        [MinLength(2, ErrorMessage = "Longitud minima de 2")]
        public string Name { get; set; }
    }
}