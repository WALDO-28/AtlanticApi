using Microsoft.AspNetCore.Mvc;
using AtlanticApi.Data;
using AtlanticApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlanticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AseguradoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear un asegurado
        [HttpPost]
        public async Task<IActionResult> CrearAsegurado([FromBody] Asegurado asegurado)
        {
            //Console.WriteLine($"Recibiendo asegurado: {Newtonsoft.Json.JsonConvert.SerializeObject(asegurado)}");

            if (asegurado == null)
            {
                return BadRequest("El objeto asegurado es nulo.");
            }

            try
            {
                _context.Asegurados.Add(asegurado);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(ObtenerAseguradoPorId), new { id = asegurado.NumeroIdentificacion }, asegurado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
        }


        // Obtener asegurados con paginación
        [HttpGet]
        public async Task<IActionResult> ObtenerAsegurados([FromQuery] int pagina = 1, [FromQuery] int cantidad = 10)
        {
            var asegurados = await _context.Asegurados
                .Skip((pagina - 1) * cantidad)
                .Take(cantidad)
                .ToListAsync();
            return Ok(asegurados);
        }

        // Obtener asegurado por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAseguradoPorId(int id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado == null) return NotFound();
            return Ok(asegurado);
        }

        // Actualizar un asegurado
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarAsegurado(int id, Asegurado asegurado)
        {
           
            try {
               
                var aseguradoExistente = _context.Asegurados.Find(id);
                if (aseguradoExistente == null)
                {
                    return NotFound("Asegurado no encontrado.");
                }

                aseguradoExistente.PrimerNombre = asegurado.PrimerNombre;
                aseguradoExistente.SegundoNombre = asegurado.SegundoNombre;
                aseguradoExistente.PrimerApellido = asegurado.PrimerApellido;
                aseguradoExistente.SegundoApellido = asegurado.SegundoApellido;
                aseguradoExistente.Telefono = asegurado.Telefono;
                aseguradoExistente.Email = asegurado.Email;
                aseguradoExistente.FechaNacimiento = asegurado.FechaNacimiento;
                aseguradoExistente.ValorEstimado = asegurado.ValorEstimado;
                aseguradoExistente.Observaciones = asegurado.Observaciones;

                _context.SaveChanges();
                return Ok(aseguradoExistente);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno del servidor.");
            }
            
        }

        // Eliminar un asegurado
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAsegurado(int id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado == null) return NotFound();
            _context.Asegurados.Remove(asegurado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
