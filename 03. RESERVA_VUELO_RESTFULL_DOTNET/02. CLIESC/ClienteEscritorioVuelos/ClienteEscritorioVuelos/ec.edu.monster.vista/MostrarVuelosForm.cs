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
    public partial class MostrarVuelosForm : Form
    {
        private readonly ApiController api = new ApiController();

        public MostrarVuelosForm()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var vuelos = await api.MostrarTodosVuelos();

                dgvTodosVuelos.DataSource = null;
                dgvTodosVuelos.DataSource = vuelos;

                // Opcional: Ajustar cabeceras de columnas
                dgvTodosVuelos.Columns["id_vuelo"].HeaderText = "ID Vuelo";
                dgvTodosVuelos.Columns["ciudad_origen"].HeaderText = "Origen";
                dgvTodosVuelos.Columns["ciudad_destino"].HeaderText = "Destino";
                dgvTodosVuelos.Columns["valor"].HeaderText = "Valor";
                dgvTodosVuelos.Columns["hora_salida"].HeaderText = "Hora de Salida";
                dgvTodosVuelos.Columns["asientos_disponibles"].HeaderText = "Asientos Disponibles";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener vuelos: {ex.Message}");
            }
        }

        private void dgvTodosVuelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MostrarVuelosForm_Load(object sender, EventArgs e)
        {

        }
    }
}
