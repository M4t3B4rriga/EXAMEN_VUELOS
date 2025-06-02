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
    public partial class CrearCuentaForm : Form
    {
        private readonly ApiController api;

        public CrearCuentaForm()
        {
            InitializeComponent();
            api = new ApiController();
        }


        private void CrearCuentaForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                nombre_usuario = txtNombre.Text,
                apellido_usuario = txtApellido.Text,
                cedula = txtCedula.Text,
                celular = txtCelular.Text,
                email = txtEmail.Text,
                contrasena = txtContrasena.Text
            };

            var result = await api.RegistrarUsuario(usuario);
            if (result != null)
            {
                MessageBox.Show("Usuario registrado correctamente. Inicie sesión para continuar.");
                this.Hide();
                new IniciarSesionForm().Show();
            }
            else
            {
                MessageBox.Show("Error al registrar usuario.");
            }
        }
    }
}
