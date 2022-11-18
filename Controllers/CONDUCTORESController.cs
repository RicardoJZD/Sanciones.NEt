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
    public class CONDUCTORESController : ControllerBase
    {
        private readonly VEHICULOSDBCONTEXT _context;

        public CONDUCTORESController(VEHICULOSDBCONTEXT context)
        {
            _context = context;
        }


        #region Metodos_CRUD

        /// <summary>
        /// <Method = "Get">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        // GET: api/<CONDUCTORESController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CONDUCTORESDTO>>> Get()
        {
            try
            {
                var conductor = await _context.Conductores.Select(x => new CONDUCTORESDTO
                {
                    //ID = x.ID,
                    IDENTIFICACION = x.IDENTIFICACION,
                    NOMBRE = x.NOMBRE,
                    APELLIDO = x.APELLIDO,
                    DIRECCION = x.DIRECCION,
                    TELEFONO = x.TELEFONO,
                    EMAIL = x.EMAIL,
                    FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                    ESTADO = x.ESTADO,
                    NUMERO_MATRICULA = x.NUMERO_MATRICULA,
                    FECHA_EXPEDICION = x.Matriculas.FECHA_EXPEDICION,
                    VALIDA_HASTA = x.Matriculas.VALIDA_HASTA
                }).ToListAsync();
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// <Method = "Get Por IDentificacion">
        /// </Method>
        /// </summary>
        /// <param name="IDENTIFICACION"></param>
        /// <returns></returns>
        // GET api/<CONDUCTORESController>/5
        [HttpGet("{IDENTIFICACION}")]
        public async Task<ActionResult<CONDUCTORESDTO>> Get(string IDENTIFICACION)
        {
            try
            {
                var conductores = await _context.Conductores.Select(x => new CONDUCTORESDTO
                {
                    //ID = x.ID,
                    IDENTIFICACION = x.IDENTIFICACION,
                    NOMBRE = x.NOMBRE,
                    APELLIDO = x.APELLIDO,
                    DIRECCION = x.DIRECCION,
                    TELEFONO = x.TELEFONO,
                    EMAIL = x.EMAIL,
                    FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                    ESTADO = x.ESTADO,
                    NUMERO_MATRICULA = x.NUMERO_MATRICULA,
                    FECHA_EXPEDICION = x.Matriculas.FECHA_EXPEDICION,
                    VALIDA_HASTA = x.Matriculas.VALIDA_HASTA
                }).FirstOrDefaultAsync(x => x.IDENTIFICACION == IDENTIFICACION);
                if (conductores == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductores;
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
        /// <param name="conductores"></param>
        /// <returns></returns>
        // POST api/<CONDUCTORESController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(CONDUCTORESDTO conductores)
        {
            try
            {
                var entity = new CONDUCTORES()
                {
                    
                    IDENTIFICACION = conductores.IDENTIFICACION,
                    NOMBRE = conductores.NOMBRE,
                    APELLIDO = conductores.APELLIDO,
                    DIRECCION = conductores.DIRECCION,
                    TELEFONO = conductores.TELEFONO,
                    EMAIL = conductores.EMAIL,
                    FECHA_NACIMIENTO = conductores.FECHA_NACIMIENTO,
                    ESTADO = conductores.ESTADO,
                    NUMERO_MATRICULA = conductores.NUMERO_MATRICULA
                };
                _context.Conductores.Add(entity);
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
        /// <param name="conductores"></param>
        /// <returns></returns>
        // PUT api/<CONDUCTORESController>/5
        [HttpPut("{IDENTIFICACION}")]
        public async Task<HttpStatusCode> Put(CONDUCTORESDTO conductores)
        {
            try 
            {
                var entity = await _context.Conductores.FirstOrDefaultAsync(v => v.IDENTIFICACION == conductores.IDENTIFICACION);
                    entity.IDENTIFICACION = conductores.IDENTIFICACION;
                    entity.NOMBRE = conductores.NOMBRE;
                    entity.APELLIDO = conductores.APELLIDO;
                    entity.DIRECCION = conductores.DIRECCION;
                    entity.TELEFONO = conductores.TELEFONO;
                    entity.EMAIL = conductores.EMAIL;
                    entity.FECHA_NACIMIENTO = conductores.FECHA_NACIMIENTO;
                    entity.ESTADO = conductores.ESTADO;
                    entity.NUMERO_MATRICULA = conductores.NUMERO_MATRICULA;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        /// <summary>
        /// <Method = "Delete">
        /// </Method>
        /// </summary>
        /// <param name="IDENTIFICACION"></param>
        /// <returns></returns>
        // DELETE api/<CONDUCTORESController>/5
        [HttpDelete("{IDENTIFICACION}")]
        public async Task<HttpStatusCode> Delete(string IDENTIFICACION)
        {
            try
            {
                var conductores = _context.Conductores.Find(IDENTIFICACION);
                if (conductores.ESTADO == false)
                {
                    return HttpStatusCode.BadRequest;
                }
                else
                {
                    var entity = await _context.Conductores.FirstOrDefaultAsync(v => v.IDENTIFICACION == IDENTIFICACION);
                    entity.ESTADO = false;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    //_context.Entry(matricula).State = EntityState.Deleted;
                    //_context.SaveChanges();
                }
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
