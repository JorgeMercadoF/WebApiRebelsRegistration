using System.ComponentModel.DataAnnotations;

namespace WebApiRebelsRegistration.Models
{
    [MetadataType(typeof(RegisterRebeldsMetadata))]
    public partial class RegisterRebelds
    {

    }
    public class RegisterRebeldsMetadata
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es necesario informar el Nombre del Rebelde")]
        public int IdRebeld { get; set; }
        [Required(ErrorMessage = "Es necesario informar el Planeta del Rebelde")]
        public int IdPlanet { get; set; }
        [Required(ErrorMessage = "Es necesario informar la Fecha de captura")]
        public System.DateTime DateRegsiter { get; set; }

        //public virtual Planets Planets { get; set; }
        //public virtual Rebelds Rebelds { get; set; }
    }
}