using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.Data;
using ViajecitosAPI.ec.edu.monster.modelo;
using ViajecitosAPI.Services;

namespace ViajecitosAPI.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly ViajecitosContext _context;
        private readonly FacturaPdfService _pdfService;

        public FacturasController(ViajecitosContext context)
        {
            _context = context;
            _pdfService = new FacturaPdfService();
        }

        [HttpPost("generar")]
        public async Task<IActionResult> GenerarFactura([FromBody] Factura factura)
        {
            if (factura == null || factura.id_compra <= 0)
                return BadRequest("Datos de factura no válidos.");

            // Buscar la compra con su usuario
            var compra = await _context.Compras
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.id_compra == factura.id_compra);

            if (compra == null)
                return NotFound("Compra no encontrada.");

            var usuario = compra.Usuario;

            // Calcular subtotal
            var subtotal = factura.precio_unitario * factura.cantidad;

            // Aplicar descuento según la lógica
            if (factura.cantidad >= 9)
                factura.descuento = subtotal * 0.30m;
            else if (factura.cantidad >= 6)
                factura.descuento = subtotal * 0.20m;
            else if (factura.cantidad >= 3)
                factura.descuento = subtotal * 0.10m;
            else
                factura.descuento = 0;

            // Calcular IVA y total
            var iva = subtotal * factura.iva;
            factura.precio_total = subtotal - factura.descuento + iva;

            // ✅ Establecer fecha/hora del servidor
            factura.fecha_emision = DateTime.Now;

            // Guardar la factura en la BD
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            // Rellenar datos del cliente para el PDF (no se guardan en BD)
            factura.nombre_cliente = usuario.nombre_usuario + " " + usuario.apellido_usuario;
            factura.cedula = usuario.cedula;
            factura.telefono = usuario.celular;
            factura.email = usuario.email;

            // Generar PDF
            var pdfBytes = _pdfService.GenerarPdf(factura);

            return File(pdfBytes, "application/pdf", $"Factura_{factura.id_factura}.pdf");
        }
    }
}
