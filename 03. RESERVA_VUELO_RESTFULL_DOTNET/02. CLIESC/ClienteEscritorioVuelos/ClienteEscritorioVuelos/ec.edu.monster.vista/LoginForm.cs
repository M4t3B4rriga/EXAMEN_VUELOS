using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteEscritorioVuelos.ec.edu.monster.vista
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblContrasena_Click(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.ToUpper() == "MONSTER" && txtContrasena.Text == "MONSTER9")
            {
                MessageBox.Show("Inicio de sesión exitoso");
                this.DialogResult = DialogResult.OK; // Indica que el login fue correcto
                this.Close(); // Cierra el LoginForm
            }
            else
            {
                MessageBox.Show("Credenciales inválidas");
            }
        }
    }
}
