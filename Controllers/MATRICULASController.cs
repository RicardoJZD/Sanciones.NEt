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
    public class MATRICULASController : ControllerBase
    {
        private readonly VEHICULOSDBCONTEXT _context;

        public MATRICULASController(VEHICULOSDBCONTEXT context)
        {
            _context = context;
        }

        #region Metodos_CRUD
        /// <summary>
        /// <Method = "Get Matriculas">
        /// </Method>
        /// </summary>
        /// <returns></returns>
        // GET: api/<MATRICULASController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MATRICULASDTO>>> Get()
        {
            try 
            {
                var matriculas = await _context.Matriculas.Select(x => new MATRICULASDTO
                {
                    //ID = x.ID,
                    NUMERO = x.NUMERO,
                    FECHA_EXPEDICION = x.FECHA_EXPEDICION,
                    VALIDA_HASTA = x.VALIDA_HASTA,
                    ESTADO = x.ESTADO
                }).ToListAsync();
                if(matriculas == null)
                {
                    return NotFound();
                }
                else
                {
                    return matriculas;
                }    
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// <Method = "Get Por ID">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<MATRICULASController>/5
        [HttpGet("{NUMERO}")]
        public async Task<ActionResult<MATRICULASDTO>> Get(string NUMERO)
        {
            try 
            {
                var matriculas = await _context.Matriculas.Select(x => new MATRICULASDTO
                {
                    //ID = x.ID,
                    NUMERO = x.NUMERO,
                    FECHA_EXPEDICION = x.FECHA_EXPEDICION,
                    VALIDA_HASTA = x.VALIDA_HASTA,
                    ESTADO = x.ESTADO
                }).FirstOrDefaultAsync(x => x.NUMERO == NUMERO);
                if (matriculas == null)
                {
                    return NotFound();
                }
                else
                {
                    return matriculas;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// <Method = "POST">
        /// </Method>
        /// </summary>
        /// <param name="value"></param>
        // POST api/<MATRICULASController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(MATRICULASDTO matriculas)
        {
            try 
            {
                var entity = new MATRICULAS()
                {

                    NUMERO = matriculas.NUMERO,
                    FECHA_EXPEDICION = matriculas.FECHA_EXPEDICION,
                    VALIDA_HASTA = matriculas.VALIDA_HASTA,
                    ESTADO = matriculas.ESTADO
                };
                _context.Matriculas.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// <Method = "Put">
        /// </Method>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/<MATRICULASController>/5
        [HttpPut("{NUMERO}")]
        public  async Task<HttpStatusCode> Put(MATRICULASDTO matriculas)
        {
            try 
            {
                var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.NUMERO == matriculas.NUMERO);
                    entity.NUMERO = matriculas.NUMERO;
                    entity.FECHA_EXPEDICION = matriculas.FECHA_EXPEDICION;
                    entity.VALIDA_HASTA = matriculas.VALIDA_HASTA;
                    entity.ESTADO = matriculas.ESTADO;
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
        /// <param name="id"></param>
        // DELETE api/<MATRICULASController>/5
        [HttpDelete("{NUMERO}")]
        public async Task<HttpStatusCode> Delete(string numero)
        {
            try 
            {
                var matricula = _context.Matriculas.Find(numero);
                if(matricula.ESTADO == false)
                {
                    return HttpStatusCode.BadRequest; 
                }
                else
                {
                    var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.NUMERO == numero);
                    entity.ESTADO = false;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync(); 
                    //_context.Entry(matricula).State = EntityState.Deleted;
                    //_context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.OK;
        }
        #endregion
    }
}
