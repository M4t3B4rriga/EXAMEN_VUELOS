using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClienteEscritorioVuelos.ec.edu.monster.controlador;
using ClienteEscritorioVuelos.ec.edu.monster.modelo;


namespace ClienteEscritorioVuelos.ec.edu.monster.vista
{
    public partial class MenuForm : Form
    {
        public Usuario UsuarioLogueado { get; private set; }

        public MenuForm()

        {

            InitializeComponent();

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            new IniciarSesionForm().Show();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            new CrearCuentaForm().Show();
        }

        private void btnMostrarVuelos_Click(object sender, EventArgs e)
        {
            var form = new MostrarVuelosForm();
            form.Show();
        }

        private void btnComprarBoletos_Click(object sender, EventArgs e)
        {
            var form = new ComprarBoletosForm(UsuarioLogueado);
            form.Show();
        }

        private void btnMostrarBoletos_Click(object sender, EventArgs e)
        {
            var form = new MostrarBoletosForm(UsuarioLogueado);
            form.Show();
        }

        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            var form = new BuscarVuelosForm();
            form.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
