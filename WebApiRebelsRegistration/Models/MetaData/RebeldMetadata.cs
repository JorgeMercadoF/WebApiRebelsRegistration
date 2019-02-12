using System.ComponentModel.DataAnnotations;

namespace WebApiRebelsRegistration.Models
{
    [MetadataType(typeof(RebeldMetadata))]
    public partial class Rebelds
    {

    }

    public class RebeldMetadata
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es requerido el nombre del rebelde")]
        [MaxLength(20, ErrorMessage = "Longitud maxima de 200")]
        [MinLength(2, ErrorMessage = "Longitud minima de 2")]
        public string Name { get; set; }
    }
}