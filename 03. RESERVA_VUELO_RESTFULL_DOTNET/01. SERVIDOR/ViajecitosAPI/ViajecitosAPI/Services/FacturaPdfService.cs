using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using ViajecitosAPI.ec.edu.monster.modelo;
using System.IO;
using iTextDocument = iText.Layout.Document;
using iTextParagraph = iText.Layout.Element.Paragraph;

namespace ViajecitosAPI.Services
{
    public class FacturaPdfService
    {
        public byte[] GenerarPdf(Factura factura)
        {
            using (var ms = new MemoryStream())
            {
                var writer = new PdfWriter(ms);
                var pdfDoc = new PdfDocument(writer);
                var doc = new iTextDocument(pdfDoc);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                doc.Add(new iTextParagraph("FACTURA ELECTRÓNICA")
                    .SetFont(boldFont)
                    .SetFontSize(18));

                doc.Add(new iTextParagraph($"Fecha: {factura.fecha_emision:dd/MM/yyyy HH:mm}"));
                doc.Add(new iTextParagraph($"Cliente: {factura.nombre_cliente}"));
                doc.Add(new iTextParagraph($"Cédula: {factura.cedula}"));
                doc.Add(new iTextParagraph($"Email: {factura.email}"));
                doc.Add(new iTextParagraph($"Teléfono: {factura.telefono}"));
                doc.Add(new iTextParagraph($"Agente de venta: {factura.agente_venta}"));

                doc.Add(new iTextParagraph("\nDETALLE:"));
                doc.Add(new iTextParagraph($"Cantidad: {factura.cantidad}"));
                doc.Add(new iTextParagraph($"Precio Unitario: ${factura.precio_unitario:F2}"));
                doc.Add(new iTextParagraph($"Descuento: ${factura.descuento:F2}"));
                doc.Add(new iTextParagraph($"IVA: ${factura.iva:F2}"));
                doc.Add(new iTextParagraph($"TOTAL A PAGAR: ${factura.precio_total:F2}").SetFont(boldFont));

                doc.Close();
                return ms.ToArray();
            }
        }
    }
}
