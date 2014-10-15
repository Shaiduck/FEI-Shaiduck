namespace Buscador_Personalizado
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.busqueda = new System.Windows.Forms.TextBox();
            this.ResultadoBusqueda = new System.Windows.Forms.DataGridView();
            this.Título = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enlace = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Fuente = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResultadoBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // busqueda
            // 
            this.busqueda.Location = new System.Drawing.Point(256, 61);
            this.busqueda.Name = "busqueda";
            this.busqueda.Size = new System.Drawing.Size(322, 20);
            this.busqueda.TabIndex = 1;
            // 
            // ResultadoBusqueda
            // 
            this.ResultadoBusqueda.AllowUserToAddRows = false;
            this.ResultadoBusqueda.AllowUserToDeleteRows = false;
            this.ResultadoBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultadoBusqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ResultadoBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultadoBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Título,
            this.Enlace,
            this.Fuente});
            this.ResultadoBusqueda.Location = new System.Drawing.Point(2, 112);
            this.ResultadoBusqueda.Name = "ResultadoBusqueda";
            this.ResultadoBusqueda.Size = new System.Drawing.Size(862, 150);
            this.ResultadoBusqueda.TabIndex = 2;
            this.ResultadoBusqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultadoBusqueda_CellContentClick);
            // 
            // Título
            // 
            this.Título.HeaderText = "Título";
            this.Título.Name = "Título";
            // 
            // Enlace
            // 
            this.Enlace.HeaderText = "Enlace";
            this.Enlace.Name = "Enlace";
            this.Enlace.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enlace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Fuente
            // 
            this.Fuente.HeaderText = "Fuente";
            this.Fuente.Name = "Fuente";
            this.Fuente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fuente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscador Shaiduck v0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultadoBusqueda);
            this.Controls.Add(this.busqueda);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Buscador Shaiduck";
            this.TransparencyKey = System.Drawing.Color.Red;
            ((System.ComponentModel.ISupportInitialize)(this.ResultadoBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox busqueda;
        private System.Windows.Forms.DataGridView ResultadoBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Título;
        private System.Windows.Forms.DataGridViewLinkColumn Enlace;
        private System.Windows.Forms.DataGridViewLinkColumn Fuente;
        private System.Windows.Forms.Label label1;
    }
}

