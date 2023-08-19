using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Models
{
    [Table("Persona")]
    public class Persona
    {
        public Persona()
        {
            Seguimiento = new HashSet<Seguimiento>();
        }

        [Key]
        public int IdPersona { get; set; }

        [StringLength(2)]
        public string TipoIdentificacion { get; set; }

        [StringLength(17)]
        public string NroIdentificacion { get; set; }

        [StringLength(60)]
        public string PrimerNombre { get; set; }

        [StringLength(60)]
        public string SegundoNombre { get; set; }

        [StringLength(60)]
        public string PrimerApellido { get; set; }

        [StringLength(60)]
        public string SegundoApellido { get; set; }

        [StringLength(2)]
        public string Sexo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(5)]
        public string CodMpioResidencia { get; set; }

        [StringLength(6)]
        public string CodAsegurador { get; set; }

        public DateTime? fechaRegistro { get; set; }
                
        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
    }
}
