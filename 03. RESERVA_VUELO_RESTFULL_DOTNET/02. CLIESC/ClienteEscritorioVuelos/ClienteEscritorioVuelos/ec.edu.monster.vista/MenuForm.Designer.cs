namespace ClienteEscritorioVuelos.ec.edu.monster.vista
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.btnBuscarVuelos = new System.Windows.Forms.Button();
            this.btnComprarBoletos = new System.Windows.Forms.Button();
            this.btnMostrarBoletos = new System.Windows.Forms.Button();
            this.btnMostrarVuelos = new System.Windows.Forms.Button();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBuscarVuelos
            // 
            this.btnBuscarVuelos.Location = new System.Drawing.Point(304, 223);
            this.btnBuscarVuelos.Name = "btnBuscarVuelos";
            this.btnBuscarVuelos.Size = new System.Drawing.Size(164, 35);
            this.btnBuscarVuelos.TabIndex = 0;
            this.btnBuscarVuelos.Text = "Buscar Vuelos";
            this.btnBuscarVuelos.UseVisualStyleBackColor = true;
            this.btnBuscarVuelos.Click += new System.EventHandler(this.btnBuscarVuelos_Click);
            // 
            // btnComprarBoletos
            // 
            this.btnComprarBoletos.Location = new System.Drawing.Point(304, 122);
            this.btnComprarBoletos.Name = "btnComprarBoletos";
            this.btnComprarBoletos.Size = new System.Drawing.Size(164, 36);
            this.btnComprarBoletos.TabIndex = 1;
            this.btnComprarBoletos.Text = "Comprar Boletos";
            this.btnComprarBoletos.UseVisualStyleBackColor = true;
            this.btnComprarBoletos.Click += new System.EventHandler(this.btnComprarBoletos_Click);
            // 
            // btnMostrarBoletos
            // 
            this.btnMostrarBoletos.Location = new System.Drawing.Point(304, 171);
            this.btnMostrarBoletos.Name = "btnMostrarBoletos";
            this.btnMostrarBoletos.Size = new System.Drawing.Size(164, 36);
            this.btnMostrarBoletos.TabIndex = 2;
            this.btnMostrarBoletos.Text = "Mostrar Mis Boletos";
            this.btnMostrarBoletos.UseVisualStyleBackColor = true;
            this.btnMostrarBoletos.Click += new System.EventHandler(this.btnMostrarBoletos_Click);
            // 
            // btnMostrarVuelos
            // 
            this.btnMostrarVuelos.Location = new System.Drawing.Point(52, 223);
            this.btnMostrarVuelos.Name = "btnMostrarVuelos";
            this.btnMostrarVuelos.Size = new System.Drawing.Size(184, 35);
            this.btnMostrarVuelos.TabIndex = 3;
            this.btnMostrarVuelos.Text = "Mostrar Todos los Vuelos";
            this.btnMostrarVuelos.UseVisualStyleBackColor = true;
            this.btnMostrarVuelos.Click += new System.EventHandler(this.btnMostrarVuelos_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Location = new System.Drawing.Point(52, 122);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(184, 36);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.Location = new System.Drawing.Point(52, 173);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(184, 34);
            this.btnCrearCuenta.TabIndex = 5;
            this.btnCrearCuenta.Text = "Crear Cuenta";
            this.btnCrearCuenta.UseVisualStyleBackColor = true;
            this.btnCrearCuenta.Click += new System.EventHandler(this.btnCrearCuenta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(196, 292);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(138, 38);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Aerolinea Viajecitos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(518, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCrearCuenta);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.btnMostrarVuelos);
            this.Controls.Add(this.btnMostrarBoletos);
            this.Controls.Add(this.btnComprarBoletos);
            this.Controls.Add(this.btnBuscarVuelos);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarVuelos;
        private System.Windows.Forms.Button btnComprarBoletos;
        private System.Windows.Forms.Button btnMostrarBoletos;
        private System.Windows.Forms.Button btnMostrarVuelos;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
    }
}