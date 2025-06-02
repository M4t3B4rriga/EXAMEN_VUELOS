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
    public partial class MostrarBoletosForm : Form
    {
        private readonly ApiController api = new ApiController();
        private Usuario UsuarioLogueado;

        public MostrarBoletosForm(Usuario usuario)
        {
            InitializeComponent();
            UsuarioLogueado = usuario;
        }

        private void dgvBoletos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (UsuarioLogueado == null)
            {
                MessageBox.Show("Debe iniciar sesión primero.");
                return;
            }

            try
            {
                var boletos = await api.MostrarBoletosUsuario(UsuarioLogueado.id_usuario);

                dgvBoletos.DataSource = null;
                dgvBoletos.DataSource = boletos;

                dgvBoletos.Columns["id_boleto"].HeaderText = "ID Boleto";
                dgvBoletos.Columns["id_vuelo"].HeaderText = "ID Vuelo";
                dgvBoletos.Columns["fecha_compra"].HeaderText = "Fecha de Compra";
                dgvBoletos.Columns["numero_asiento"].HeaderText = "Número de Asiento";
                dgvBoletos.Columns["valor"].HeaderText = "Valor";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener boletos: {ex.Message}");
            }
        }

        private void MostrarBoletosForm_Load(object sender, EventArgs e)
        {

        }
    }
}
