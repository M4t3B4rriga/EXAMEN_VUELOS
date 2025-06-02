using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteEscritorioVuelos.ec.edu.monster.modelo
{
    public class Boleto
    {
        public int id_boleto { get; set; }
        public int id_usuario { get; set; }
        public int id_vuelo { get; set; }
        public DateTime fecha_compra { get; set; }
        public string numero_asiento { get; set; }
        public decimal valor { get; set; } // Si la API lo devuelve
    }
}