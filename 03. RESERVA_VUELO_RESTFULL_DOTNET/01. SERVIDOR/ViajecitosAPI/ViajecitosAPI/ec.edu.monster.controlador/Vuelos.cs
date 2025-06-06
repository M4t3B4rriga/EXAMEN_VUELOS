﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.Data;
using ViajecitosAPI.ec.edu.monster.modelo;

namespace ViajecitosAPI.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class VuelosController : ControllerBase
    {
        private readonly ViajecitosContext _context;

        public VuelosController(ViajecitosContext context)
        {
            _context = context;
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Vuelo>>> BuscarVuelos(string origen, string destino)
        {
            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
                return BadRequest("Debe proporcionar origen y destino para buscar vuelos.");

            var vuelos = await _context.Vuelos
                .Where(v => v.ciudad_origen == origen && v.ciudad_destino == destino)
                .ToListAsync();

            if (vuelos == null || vuelos.Count == 0)
                return NotFound("No se encontraron vuelos para esa ruta.");

            return vuelos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelos()
        {
            return await _context.Vuelos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelo>> GetVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null) return NotFound();
            return vuelo;
        }

        [HttpPost]
        public async Task<ActionResult<Vuelo>> PostVuelo(Vuelo vuelo)
        {
            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVuelo), new { id = vuelo.id_vuelo }, vuelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVuelo(int id, Vuelo vuelo)
        {
            if (id != vuelo.id_vuelo) return BadRequest();
            _context.Entry(vuelo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null) return NotFound();
            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
