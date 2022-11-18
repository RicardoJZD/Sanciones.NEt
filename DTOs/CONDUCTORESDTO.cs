using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.DTOs
{
    public class CONDUCTORESDTO
    {
        //public int ID { get; set; }
        public string IDENTIFICACION { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string? DIRECCION { get; set; }
        public string? TELEFONO { get; set; }
        public string? EMAIL { get; set; }
        public DateTime? FECHA_NACIMIENTO { get; set; }
        public bool? ESTADO { get; set; }
        public string NUMERO_MATRICULA { get; set; }
        public DateTime? FECHA_EXPEDICION { get; set; }
        public DateTime? VALIDA_HASTA { get; set; }
    }
}
