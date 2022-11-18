using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.DTOs
{
    public class SANCIONESDTO
    {
        public int ID { get; set; }
        public DateTime FECHA_ACTUAL { get; set; }
        public string? SANCION { get; set; }
        public string OBSERVACION { get; set; }
        public decimal VALOR { get; set; }
        public string CONDUCTOR_ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
    }
}
