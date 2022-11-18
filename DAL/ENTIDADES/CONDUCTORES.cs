using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.DAL.ENTIDADES
{
    public class CONDUCTORES
    {
        [Key]
        public string IDENTIFICACION { get; set; }
        //public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string? DIRECCION { get; set; }
        public string? TELEFONO { get; set; }
        public string? EMAIL { get; set; }
        public DateTime? FECHA_NACIMIENTO { get; set; }
        public bool? ESTADO { get; set; }
        public string NUMERO_MATRICULA { get; set; }
        [ForeignKey("NUMERO_MATRICULA")]
        public virtual MATRICULAS Matriculas{ get; set; }
    }
}
