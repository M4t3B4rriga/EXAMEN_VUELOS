using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViajecitosAPI.ec.edu.monster.modelo
{
    public class Factura
    {
        [Key]
        public int id_factura { get; set; }

        [ForeignKey("Compra")]
        public int id_compra { get; set; }

        public string agente_venta { get; set; }

        public decimal descuento { get; set; }
        public decimal iva { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }

        public decimal precio_total { get; set; }  // ✅ Importante: NO debe ser Computed

        public DateTime fecha_emision { get; set; }

        // No se guardan
        [NotMapped] public string nombre_cliente { get; set; }
        [NotMapped] public string cedula { get; set; }
        [NotMapped] public string telefono { get; set; }
        [NotMapped] public string email { get; set; }
    }

}
