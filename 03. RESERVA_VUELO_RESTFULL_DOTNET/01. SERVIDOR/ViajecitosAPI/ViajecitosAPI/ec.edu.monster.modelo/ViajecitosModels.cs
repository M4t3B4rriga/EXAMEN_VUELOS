using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ViajecitosAPI.ec.edu.monster.modelo
{
    public class Vuelo
    {
        [Key]
        public int id_vuelo { get; set; }
        public string ciudad_origen { get; set; }
        public string ciudad_destino { get; set; }
        public decimal valor { get; set; }
        public DateTime hora_salida { get; set; }
        public int asientos_disponibles { get; set; }
    }

    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string cedula { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
    }

    public class Boleto
    {
        [Key]
        public int id_boleto { get; set; }

        [ForeignKey("Usuario")]
        public int id_usuario { get; set; }

        [ForeignKey("Vuelo")]
        public int id_vuelo { get; set; }

        public DateTime fecha_compra { get; set; }
        public string numero_asiento { get; set; }
    }

    public class Compra
    {
        [Key]
        public int id_compra { get; set; }

        [ForeignKey("Usuario")]
        public int id_usuario { get; set; }

        [ForeignKey("Boleto")]
        public int id_boleto { get; set; }

        public DateTime fecha_compra { get; set; }
        public decimal monto_total { get; set; }
    }
}