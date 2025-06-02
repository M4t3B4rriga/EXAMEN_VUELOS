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
        public static Usuario UsuarioLogueado = null;

        public IniciarSesionForm()
        {
            InitializeComponent();
            api = new ApiController();
        }

        private void IniciarSesionForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var contrasena = txtContrasena.Text;

            var user = await api.LoginApi(email, contrasena);
            if (user != null)
            {
                UsuarioLogueado = user;
                MessageBox.Show($"Bienvenido {user.nombre_usuario} {user.apellido_usuario}");
                this.Hide();
                new MenuForm().Show();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas.");
            }
        }
    }
}
