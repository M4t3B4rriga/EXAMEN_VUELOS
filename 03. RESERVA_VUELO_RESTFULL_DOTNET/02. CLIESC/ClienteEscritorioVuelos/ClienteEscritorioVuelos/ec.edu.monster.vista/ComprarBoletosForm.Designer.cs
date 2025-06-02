namespace ClienteEscritorioVuelos.ec.edu.monster.vista
{
    partial class ComprarBoletosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprarBoletosForm));
            this.lblIdVuelo = new System.Windows.Forms.Label();
            this.lblAsientos = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.txtIdVuelo = new System.Windows.Forms.TextBox();
            this.txtAsientos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblIdVuelo
            // 
            this.lblIdVuelo.AutoSize = true;
            this.lblIdVuelo.Location = new System.Drawing.Point(38, 83);
            this.lblIdVuelo.Name = "lblIdVuelo";
            this.lblIdVuelo.Size = new System.Drawing.Size(61, 16);
            this.lblIdVuelo.TabIndex = 0;
            this.lblIdVuelo.Text = "ID Vuelo:";
            this.lblIdVuelo.Click += new System.EventHandler(this.lblIdVuelo_Click);
            // 
            // lblAsientos
            // 
            this.lblAsientos.AutoSize = true;
            this.lblAsientos.Location = new System.Drawing.Point(38, 165);
            this.lblAsientos.Name = "lblAsientos";
            this.lblAsientos.Size = new System.Drawing.Size(113, 16);
            this.lblAsientos.TabIndex = 1;
            this.lblAsientos.Text = "Número Asientos:";
            this.lblAsientos.Click += new System.EventHandler(this.lblAsientos_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(101, 230);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(107, 39);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.Text = "Comprar:";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // txtIdVuelo
            // 
            this.txtIdVuelo.Location = new System.Drawing.Point(191, 83);
            this.txtIdVuelo.Name = "txtIdVuelo";
            this.txtIdVuelo.Size = new System.Drawing.Size(100, 22);
            this.txtIdVuelo.TabIndex = 3;
            this.txtIdVuelo.TextChanged += new System.EventHandler(this.txtIdVuelo_TextChanged);
            // 
            // txtAsientos
            // 
            this.txtAsientos.Location = new System.Drawing.Point(191, 162);
            this.txtAsientos.Name = "txtAsientos";
            this.txtAsientos.Size = new System.Drawing.Size(100, 22);
            this.txtAsientos.TabIndex = 4;
            this.txtAsientos.TextChanged += new System.EventHandler(this.txtAsientos_TextChanged);
            // 
            // ComprarBoletosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(387, 328);
            this.Controls.Add(this.txtAsientos);
            this.Controls.Add(this.txtIdVuelo);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.lblAsientos);
            this.Controls.Add(this.lblIdVuelo);
            this.Name = "ComprarBoletosForm";
            this.Text = "ComprarBoletosForm";
            this.Load += new System.EventHandler(this.ComprarBoletosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdVuelo;
        private System.Windows.Forms.Label lblAsientos;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.TextBox txtIdVuelo;
        private System.Windows.Forms.TextBox txtAsientos;
    }
}