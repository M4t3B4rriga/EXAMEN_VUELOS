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
    public partial class ComprarBoletosForm : Form
    {
        private readonly ApiController api = new ApiController();
        private Usuario UsuarioLogueado;

        public ComprarBoletosForm(Usuario usuario)
        {
            InitializeComponent();
            UsuarioLogueado = usuario;
        }

        private void ComprarBoletosForm_Load(object sender, EventArgs e)
        {

        }

        private void txtIdVuelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIdVuelo_Click(object sender, EventArgs e)
        {

        }

        private void lblAsientos_Click(object sender, EventArgs e)
        {

        }

        private void txtAsientos_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnComprar_Click(object sender, EventArgs e)
        {
            if (UsuarioLogueado == null)
            {
                MessageBox.Show("Debe iniciar sesión primero.");
                return;
            }

            if (!int.TryParse(txtIdVuelo.Text.Trim(), out int idVuelo))
            {
                MessageBox.Show("Ingrese un ID de vuelo válido.");
                return;
            }

            if (!int.TryParse(txtAsientos.Text.Trim(), out int numeroAsientos) || numeroAsientos <= 0)
            {
                MessageBox.Show("Ingrese un número de asientos válido.");
                return;
            }

            try
            {
                var result = await api.ComprarBoletos(UsuarioLogueado.id_usuario, idVuelo, numeroAsientos);
                MessageBox.Show($"Resultado: {result}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al comprar boletos: {ex.Message}");
            }
        }
    }
}
