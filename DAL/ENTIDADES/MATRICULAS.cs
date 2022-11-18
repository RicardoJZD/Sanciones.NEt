using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ActividadASPNET.DAL.ENTIDADES
{
    public class MATRICULAS
    {
        [Key]
        public string NUMERO { get; set; }
        //public int ID { get; set; }
        public DateTime FECHA_EXPEDICION { get; set; }
        public DateTime VALIDA_HASTA { get; set; }
        public bool? ESTADO { get; set; }
        public virtual ICollection<CONDUCTORES> Conductores {get; set;}
    }
}
