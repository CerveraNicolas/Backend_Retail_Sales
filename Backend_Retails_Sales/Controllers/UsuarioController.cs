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
    public class UsuarioController : Controller
    {
        private readonly AppDBContext _context;

        public UsuarioController(AppDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ReclamoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _tarea = await _context.Usuarios.ToListAsync();

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
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fué creada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return NotFound();
                }
                usuario.Status = !usuario.Status;
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fué editada exitosamente." });
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
                var usuario = await _context.Usuarios.FindAsync(id);

                if(usuario == null)
                {
                    return NotFound();
                }
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return Ok(new {message="La tarea fué eliminidada exitosamente."});
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

