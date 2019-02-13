using System.ComponentModel;
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
        [DisplayName("Nombre del Rebelde")]
        public int IdRebeld { get; set; }
        [Required(ErrorMessage = "Es necesario informar el Planeta del Rebelde")]
        [DisplayName("Nombre del Planeta")]
        public int IdPlanet { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Es necesario informar la Fecha de captura")]
        [DisplayName("Fecha de captura")]
        public System.DateTime DateRegsiter { get; set; }

        [DisplayName("Planeta")]
        public virtual Planets Planets { get; set; }
        [DisplayName("Rebelde")]
        public virtual Rebelds Rebelds { get; set; }
    }
}