using System.ComponentModel.DataAnnotations;

namespace WebApiRebelsRegistration.Models
{
    [MetadataType(typeof(RegisterMetadata))]
    public partial class RegisterRebelds
    {

    }

    public class RegisterMetadata
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es requerido informar el Nombre del Rebelde")]
        public int IdRebeld { get; set; }
        [Required(ErrorMessage = "Es requerido informar el Planeta donde se encontro al Rebelde")]
        public int IdPlanet { get; set; }
        public System.DateTime DateRegsiter { get; set; }
    }
}
