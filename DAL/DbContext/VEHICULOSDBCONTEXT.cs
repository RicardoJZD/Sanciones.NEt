using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActividadASPNET.DAL.DbContext
{
    using ActividadASPNET.DAL.ENTIDADES;
    using Microsoft.EntityFrameworkCore;
    public class VEHICULOSDBCONTEXT:DbContext
    {
        public VEHICULOSDBCONTEXT(DbContextOptions<VEHICULOSDBCONTEXT> options):
            base (options)
        {
        }
        public virtual DbSet<MATRICULAS> Matriculas { get; set; }
        public virtual DbSet<CONDUCTORES> Conductores { get; set; }
        public virtual DbSet<SANCIONES> Sanciones { get; set; }
    }
}
