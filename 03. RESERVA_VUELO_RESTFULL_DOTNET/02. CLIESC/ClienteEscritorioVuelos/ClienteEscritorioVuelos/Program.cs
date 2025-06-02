using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClienteEscritorioVuelos.ec.edu.monster.vista;

namespace ClienteEscritorioVuelos
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar Login inicial (quemado)
            var loginInicial = new LoginForm(); // LoginForm = formulario con datos quemados MONSTER / MONSTER9

            if (loginInicial.ShowDialog() == DialogResult.OK)
            {
                // Si el login inicial fue correcto, abrir el menú principal
                Application.Run(new MenuForm());
            }
            else
            {
                // Si falla el login, cerrar la aplicación
                Application.Exit();
            }
        }
    }
}
