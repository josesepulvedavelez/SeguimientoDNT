using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Dto
{
    public class PersonaSeguimientoDto
    {        
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


        public int IdSeguimiento { get; set; }               

        [StringLength(24)]
        public string EstadoVital { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDefuncion { get; set; }

        [StringLength(1)]
        public string UbicacionDefuncion { get; set; }

        [StringLength(12)]
        public string CodLugarAtencion { get; set; }

        public DateTime? FechaAtencion { get; set; }

        public decimal? PesoKg { get; set; }

        public short? TallaCm { get; set; }

        [StringLength(2)]
        public string CodClasificacionNutricional { get; set; }

        [StringLength(2)]
        public string CodManejoActual { get; set; }

        [StringLength(250)]
        public string DesManejo { get; set; }

        [StringLength(2)]
        public string CodUbicacion { get; set; }

        [StringLength(250)]
        public string DesUbicacion { get; set; }

        [StringLength(2)]
        public string CodTratamiento { get; set; }

        public short? TotalSobresFTLC { get; set; }

        [StringLength(256)]
        public string OtroTratamiento { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
