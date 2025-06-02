namespace ClienteEscritorioVuelos.ec.edu.monster.vista
{
    partial class MostrarBoletosForm
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
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvBoletos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(32, 63);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 39);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar:";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvBoletos
            // 
            this.dgvBoletos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoletos.Location = new System.Drawing.Point(32, 125);
            this.dgvBoletos.Name = "dgvBoletos";
            this.dgvBoletos.RowHeadersWidth = 51;
            this.dgvBoletos.RowTemplate.Height = 24;
            this.dgvBoletos.Size = new System.Drawing.Size(583, 284);
            this.dgvBoletos.TabIndex = 1;
            this.dgvBoletos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBoletos_CellContentClick);
            // 
            // MostrarBoletosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 450);
            this.Controls.Add(this.dgvBoletos);
            this.Controls.Add(this.btnActualizar);
            this.Name = "MostrarBoletosForm";
            this.Text = "MostrarBoletosForm";
            this.Load += new System.EventHandler(this.MostrarBoletosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvBoletos;
    }
}