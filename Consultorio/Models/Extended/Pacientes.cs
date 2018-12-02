using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Consultorio.Models
{   [MetadataType(typeof(Pacientesdatos))]
    public  partial class Pacientes
    {
    }

    public class Pacientesdatos
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
    public int Cedula { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        public String Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        public String Apellido { get; set; }
        
    }
}