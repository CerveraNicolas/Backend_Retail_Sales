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
    public class RolController : Controller
    {
        private readonly AppDBContext _context;

        public RolController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _tarea = await _context.Roles.ToListAsync();

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
        public async Task<IActionResult> Post([FromBody] Rol rol)
        {
            try
            {
                _context.Roles.Add(rol);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El rol fué creado exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody] Rol rol)
        {
            try
            {
                if (id != rol.Id)
                {
                    return NotFound();
                }
                rol.Status = !rol.Status;
                _context.Entry(rol).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "El rol fué editado exitosamente." });
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
                return Ok(new {message="El rol fué eliminidado exitosamente."});
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

