using Backend_Retails_Sales.Context;
using Backend_Retails_Sales.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend_Retails_Sales.Controllers
{
    [EnableCors("All")]
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroDocumentoController : Controller
    {
        private readonly AppDBContext _context;

        public NumeroDocumentoController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _tarea = await _context.NumeroDocumentos.ToListAsync();

                if (_tarea == null)
                {
                    return NotFound();
                }

                return Ok(_tarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NumeroDocumento numdoc)
        {
            try
            {
                _context.NumeroDocumentos.Add(numdoc);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El numero de documento fué creado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody] NumeroDocumento numdoc)
        {
            try
            {
                if (id != numdoc.Id)
                {
                    return NotFound();
                }
                _context.Entry(numdoc).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "El numero de documento fué editado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var numdoc = await _context.NumeroDocumentos.FindAsync(id);

                if(numdoc == null)
                {
                    return NotFound();
                }
                _context.NumeroDocumentos.Remove(numdoc);
                _context.SaveChanges();
                return Ok(new {message="El numero de documento fué eliminidado exitosamente."});
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

