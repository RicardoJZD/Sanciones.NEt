using ActividadASPNET.DAL.DbContext;
using ActividadASPNET.DAL.ENTIDADES;
using ActividadASPNET.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SANCIONESController : ControllerBase
    {
        private readonly VEHICULOSDBCONTEXT _context;

        public SANCIONESController(VEHICULOSDBCONTEXT context)
        {
            _context = context;
        }

        #region Metodos_CRUD
        /// <summary>
        /// <Method = "GET">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        // GET: api/<SANCIONESController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SANCIONESDTO>>> Get()
        {
            try
            {
                var sanciones = await _context.Sanciones.Select(x => new SANCIONESDTO
                {
                    ID = x.ID, 
                    FECHA_ACTUAL = x.FECHA_ACTUAL,
                    SANCION = x.SANCION,
                    OBSERVACION =x.OBSERVACION,
                    VALOR = x.VALOR,
                    CONDUCTOR_ID = x.CONDUCTOR_ID,
                    NOMBRE = x.Conductores.NOMBRE,
                    APELLIDO = x.Conductores.APELLIDO
                }).ToListAsync();
                if (sanciones == null)
                {
                    return NotFound();
                }
                else
                {
                    return sanciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// <Method = "Get Por Id">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<SANCIONESController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SANCIONESDTO>> Get(int id)
        {
            try
            {
                var sanciones = await _context.Sanciones.Select(x => new SANCIONESDTO
                {
                    ID = x.ID,
                    FECHA_ACTUAL = x.FECHA_ACTUAL,
                    SANCION = x.SANCION,
                    OBSERVACION = x.OBSERVACION,
                    VALOR = x.VALOR,
                    CONDUCTOR_ID = x.CONDUCTOR_ID,
                    NOMBRE = x.Conductores.NOMBRE,
                    APELLIDO = x.Conductores.APELLIDO
                }).FirstOrDefaultAsync(x => x.ID == id);
                if (sanciones == null)
                {
                    return NotFound();
                }
                else
                {
                    return sanciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// <Method = "Post">
        /// </Method>
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        // POST api/<SANCIONESController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SANCIONESDTO sanciones)
        {
            try
            {
                var entity = new SANCIONES()
                {
                    ID = sanciones.ID,
                    FECHA_ACTUAL = DateTime.Now,
                    SANCION = sanciones.SANCION,
                    OBSERVACION = sanciones.OBSERVACION,
                    VALOR = sanciones.VALOR,
                    CONDUCTOR_ID = sanciones.CONDUCTOR_ID
                };
                _context.Sanciones.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// <Method = "Put">
        /// </Method>
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        // PUT api/<SANCIONESController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SANCIONESDTO sanciones)
        {
            try
            {
                var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.ID == sanciones.ID);
                    entity.ID = sanciones.ID;
                    entity.FECHA_ACTUAL = sanciones.FECHA_ACTUAL;
                    entity.SANCION = sanciones.SANCION;
                    entity.OBSERVACION = sanciones.OBSERVACION;
                    entity.VALOR = sanciones.VALOR;
                    entity.CONDUCTOR_ID = sanciones.CONDUCTOR_ID;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        /// <summary>
        /// <Method = "Delete">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<SANCIONESController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var entity = new SANCIONES()
                {
                    ID = id
                };
                _context.Sanciones.Attach(entity);
                _context.Sanciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
