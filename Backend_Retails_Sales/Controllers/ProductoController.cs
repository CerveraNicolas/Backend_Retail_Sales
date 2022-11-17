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
    public class ProductoController : Controller
    {
        private readonly AppDBContext _context;

        public ProductoController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _tarea = await _context.Productos.ToListAsync();

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
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto fué creado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != producto.Id)
                {
                    return NotFound();
                }
                producto.Status = !producto.Status;
                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto fué editado exitosamente." });
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
                var producto = await _context.Productos.FindAsync(id);

                if(producto == null)
                {
                    return NotFound();
                }
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return Ok(new {message="El producto fué eliminidado exitosamente."});
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

