using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsolaVuelos.ec.edu.monster.modelo
{
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
}