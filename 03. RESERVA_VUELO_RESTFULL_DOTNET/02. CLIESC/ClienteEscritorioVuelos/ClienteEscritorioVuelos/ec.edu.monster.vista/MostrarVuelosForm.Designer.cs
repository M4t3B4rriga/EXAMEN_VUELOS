namespace ClienteEscritorioVuelos.ec.edu.monster.vista
{
    partial class MostrarVuelosForm
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
            this.dgvTodosVuelos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodosVuelos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(31, 31);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(124, 44);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar: ";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvTodosVuelos
            // 
            this.dgvTodosVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodosVuelos.Location = new System.Drawing.Point(31, 90);
            this.dgvTodosVuelos.Name = "dgvTodosVuelos";
            this.dgvTodosVuelos.RowHeadersWidth = 51;
            this.dgvTodosVuelos.RowTemplate.Height = 24;
            this.dgvTodosVuelos.Size = new System.Drawing.Size(588, 284);
            this.dgvTodosVuelos.TabIndex = 1;
            this.dgvTodosVuelos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTodosVuelos_CellContentClick);
            // 
            // MostrarVuelosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 395);
            this.Controls.Add(this.dgvTodosVuelos);
            this.Controls.Add(this.btnActualizar);
            this.Name = "MostrarVuelosForm";
            this.Text = "MostrarVuelosForm";
            this.Load += new System.EventHandler(this.MostrarVuelosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodosVuelos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvTodosVuelos;
    }
}