using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.Data;
using ViajecitosAPI.ec.edu.monster.modelo;

namespace ViajecitosAPI.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ViajecitosContext _context;

        public ComprasController(ViajecitosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            return await _context.Compras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null) return NotFound();
            return compra;
        }

        [HttpPost("comprar")]
        public async Task<ActionResult> ComprarBoletos(int idUsuario, int idVuelo, int numeroAsientos)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var vuelo = await _context.Vuelos.FirstOrDefaultAsync(v => v.id_vuelo == idVuelo);
                if (vuelo == null) return NotFound("Vuelo no encontrado.");
                if (vuelo.asientos_disponibles < numeroAsientos)
                    return BadRequest("No hay suficientes asientos disponibles.");

                vuelo.asientos_disponibles -= numeroAsientos;
                _context.Vuelos.Update(vuelo);

                for (int i = 0; i < numeroAsientos; i++)
                {
                    var boleto = new Boleto
                    {
                        id_usuario = idUsuario,
                        id_vuelo = idVuelo,
                        fecha_compra = DateTime.Now,
                        numero_asiento = $"V{idVuelo}-{(char)('A' + i)}"
                    };
                    _context.Boletos.Add(boleto);
                    await _context.SaveChangesAsync(); // Necesario para obtener el id_boleto

                    var compra = new Compra
                    {
                        id_usuario = idUsuario,
                        id_boleto = boleto.id_boleto,
                        fecha_compra = DateTime.Now,
                        monto_total = vuelo.valor
                    };
                    _context.Compras.Add(compra);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { mensaje = "Boletos comprados exitosamente." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(int id, Compra compra)
        {
            if (id != compra.id_compra) return BadRequest();
            _context.Entry(compra).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null) return NotFound();
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
