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
    public partial class IniciarSesionForm : Form
    {
        private readonly ApiController api;
        public static Usuario UsuarioLogueado = null; // Guardar usuario logueado

        public IniciarSesionForm()
        {
            InitializeComponent();
            api = new ApiController();
        }

        private void IniciarSesionForm_Load(object sender, EventArgs e)
        {
            // Puedes dejar esto vacío o inicializar algo si lo necesitas
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Puedes dejar esto vacío o eliminarlo si no lo necesitas
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            // Puedes dejar esto vacío o eliminarlo si no lo necesitas
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Puedes dejar esto vacío o eliminarlo si no lo necesitas
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            // Puedes dejar esto vacío o eliminarlo si no lo necesitas
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese el email y la contraseña.");
                return;
            }

            var user = await api.LoginApi(email, contrasena);
            if (user != null)
            {
                UsuarioLogueado = user; // Guardar usuario logueado para otras pantallas
                MessageBox.Show($"Bienvenido {user.nombre_usuario} {user.apellido_usuario}");

                // Oculta el formulario actual
                this.Hide();

                // Abre el menú principal
                var menu = new MenuForm();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas.");
            }
        }
    }
}
