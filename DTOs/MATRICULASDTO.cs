using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.DTOs
{
    public class MATRICULASDTO
    {
        //public int ID { get; set; }
        public string NUMERO { get; set; }
        public DateTime FECHA_EXPEDICION { get; set; }
        public DateTime VALIDA_HASTA { get; set; }
        public bool? ESTADO { get; set; }
    }
}
