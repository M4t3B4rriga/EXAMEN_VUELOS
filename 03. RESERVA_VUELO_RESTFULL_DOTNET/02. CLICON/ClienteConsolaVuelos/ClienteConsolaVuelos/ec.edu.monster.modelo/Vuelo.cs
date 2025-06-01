using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsolaVuelos.ec.edu.monster.modelo
{
    public class Vuelo
    {
        public int id_vuelo { get; set; }
        public string ciudad_origen { get; set; }
        public string ciudad_destino { get; set; }
        public decimal valor { get; set; }
        public DateTime hora_salida { get; set; }
        public int asientos_disponibles { get; set; }
    }

}