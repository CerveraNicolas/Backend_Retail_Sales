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
    public class DetalleVentaController : Controller
    {
        private readonly AppDBContext _context;

        public DetalleVentaController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _tarea = await _context.DetalleVentas.ToListAsync();

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
        public async Task<IActionResult> Post([FromBody] DetalleVenta detalleVenta)
        {
            try
            {
                _context.DetalleVentas.Add(detalleVenta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Los detalles sobre la venta fueron creados exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody] DetalleVenta detalleVenta)
        {
            try
            {
                if (id != detalleVenta.Id)
                {
                    return NotFound();
                }
                _context.Entry(detalleVenta).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Los detalles de la venta fueron editados exitosamente." });
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
                var detalleVenta = await _context.DetalleVentas.FindAsync(id);

                if(detalleVenta == null)
                {
                    return NotFound();
                }
                _context.DetalleVentas.Remove(detalleVenta);
                _context.SaveChanges();
                return Ok(new {message="Los detalles sobre la venta fueron eliminidados exitosamente."});
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

