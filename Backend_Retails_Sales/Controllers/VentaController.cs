using Backend_Retails_Sales.Context;
using Backend_Retails_Sales.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend_Retails_Sales.Controllers
{
    [EnableCors("All")]
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        private readonly AppDBContext _context;

        public VentaController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _tarea = await _context.Ventas.ToListAsync();

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
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            try
            {
                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La venta fué creada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody] Venta venta)
        {
            try
            {
                if (id != venta.Id)
                {
                    return NotFound();
                }
                _context.Entry(venta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "La venta fué editada exitosamente." });
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
                var venta = await _context.Ventas.FindAsync(id);

                if(venta == null)
                {
                    return NotFound();
                }
                _context.Ventas.Remove(venta);
                _context.SaveChanges();
                return Ok(new {message="La venta fué eliminidada exitosamente."});
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

