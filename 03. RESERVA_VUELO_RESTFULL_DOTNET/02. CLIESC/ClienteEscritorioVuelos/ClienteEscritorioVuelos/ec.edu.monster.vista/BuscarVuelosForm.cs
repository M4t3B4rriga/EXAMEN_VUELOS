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
    public partial class BuscarVuelosForm : Form
    {
        private readonly ApiController api = new ApiController();

        public BuscarVuelosForm()
        {
            InitializeComponent();
        }

        private void lblOrigen_Click(object sender, EventArgs e)
        {

        }

        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDestino_Click(object sender, EventArgs e)
        {

        }

        private void txtDestino_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string origen = txtOrigen.Text.Trim();
            string destino = txtDestino.Text.Trim();
            DateTime fechaSeleccionada = dtpFecha.Value.Date; // Obtener fecha del DateTimePicker

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Por favor, ingrese el origen y el destino.");
                return;
            }

            try
            {
                var vuelos = await api.BuscarVuelos(origen, destino);

                // Filtrar por la fecha seleccionada
                var vuelosFiltrados = vuelos.Where(v => v.hora_salida.Date == fechaSeleccionada).ToList();

                if (vuelosFiltrados.Any())
                {
                    dgvVuelos.DataSource = vuelosFiltrados;
                }
                else
                {
                    MessageBox.Show("No se encontraron vuelos para la fecha seleccionada.");
                    dgvVuelos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar vuelos: {ex.Message}");
            }
        }

        private void dgvVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarVuelosForm_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today; // Establece la fecha actual como predeterminada
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
