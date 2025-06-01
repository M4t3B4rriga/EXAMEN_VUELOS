using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.Data;
using ViajecitosAPI.ec.edu.monster.modelo;

namespace ViajecitosAPI.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly ViajecitosContext _context;

        public BoletosController(ViajecitosContext context)
        {
            _context = context;
        }

        // GET: api/Boletos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletos()
        {
            return await _context.Boletos.ToListAsync();
        }

        // GET: api/Boletos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null) return NotFound();
            return boleto;
        }

        // GET: api/Boletos/usuario/5
        [HttpGet("usuario/{id_usuario}")]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletosPorUsuario(int id_usuario)
        {
            var boletos = await _context.Boletos
                .Where(b => b.id_usuario == id_usuario)
                .ToListAsync();

            if (boletos == null || boletos.Count == 0)
                return NotFound($"No se encontraron boletos para el usuario con ID {id_usuario}.");

            return boletos;
        }

        // POST: api/Boletos
        [HttpPost]
        public async Task<ActionResult<Boleto>> PostBoleto(Boleto boleto)
        {
            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.id_boleto }, boleto);
        }

        // PUT: api/Boletos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleto(int id, Boleto boleto)
        {
            if (id != boleto.id_boleto) return BadRequest();
            _context.Entry(boleto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Boletos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null) return NotFound();
            _context.Boletos.Remove(boleto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
