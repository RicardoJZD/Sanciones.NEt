using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.DAL.ENTIDADES
{
    public class SANCIONES
    {
        [Key]
        public int ID { get; set; }
        public DateTime FECHA_ACTUAL { get; set; }
        public string? SANCION { get; set; }
        public string OBSERVACION { get; set; }
        public decimal VALOR { get; set; }
        public string CONDUCTOR_ID { get; set; }
        [ForeignKey("CONDUCTOR_ID")]
        public virtual CONDUCTORES Conductores {get;set;}
    }
}
