namespace BD
{
    partial class Atributos_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Atributos_Form));
            this.BEliminarT = new System.Windows.Forms.Button();
            this.BModificarT = new System.Windows.Forms.Button();
            this.BAgregarT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid_Atributo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Atributo)).BeginInit();
            this.SuspendLayout();
            // 
            // BEliminarT
            // 
            this.BEliminarT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BEliminarT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BEliminarT.BackgroundImage")));
            this.BEliminarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BEliminarT.Location = new System.Drawing.Point(125, 12);
            this.BEliminarT.Name = "BEliminarT";
            this.BEliminarT.Size = new System.Drawing.Size(50, 50);
            this.BEliminarT.TabIndex = 6;
            this.BEliminarT.UseCompatibleTextRendering = true;
            this.BEliminarT.UseVisualStyleBackColor = false;
            this.BEliminarT.Click += new System.EventHandler(this.BEliminarT_Click);
            // 
            // BModificarT
            // 
            this.BModificarT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BModificarT.BackgroundImage")));
            this.BModificarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BModificarT.Location = new System.Drawing.Point(69, 12);
            this.BModificarT.Name = "BModificarT";
            this.BModificarT.Size = new System.Drawing.Size(50, 50);
            this.BModificarT.TabIndex = 5;
            this.BModificarT.UseCompatibleTextRendering = true;
            this.BModificarT.UseVisualStyleBackColor = true;
            this.BModificarT.Click += new System.EventHandler(this.BModificarT_Click);
            // 
            // BAgregarT
            // 
            this.BAgregarT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BAgregarT.BackgroundImage")));
            this.BAgregarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BAgregarT.Location = new System.Drawing.Point(13, 12);
            this.BAgregarT.Name = "BAgregarT";
            this.BAgregarT.Size = new System.Drawing.Size(50, 50);
            this.BAgregarT.TabIndex = 4;
            this.BAgregarT.UseCompatibleTextRendering = true;
            this.BAgregarT.UseVisualStyleBackColor = true;
            this.BAgregarT.Click += new System.EventHandler(this.BAgregarT_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid_Atributo
            // 
            this.dataGrid_Atributo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Atributo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Clave,
            this.col4,
            this.col5});
            this.dataGrid_Atributo.Location = new System.Drawing.Point(13, 69);
            this.dataGrid_Atributo.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Atributo.Name = "dataGrid_Atributo";
            this.dataGrid_Atributo.Size = new System.Drawing.Size(774, 334);
            this.dataGrid_Atributo.TabIndex = 70;
            this.dataGrid_Atributo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Atributo_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nom_data";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 87;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "calif_data";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Tamaño";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 89;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Llave Primaria";
            this.Clave.Name = "Clave";
            // 
            // col4
            // 
            this.col4.HeaderText = "Llave Foranea";
            this.col4.Name = "col4";
            // 
            // col5
            // 
            this.col5.HeaderText = "No llave";
            this.col5.Name = "col5";
            // 
            // Atributos_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGrid_Atributo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BEliminarT);
            this.Controls.Add(this.BModificarT);
            this.Controls.Add(this.BAgregarT);
            this.Name = "Atributos_Form";
            this.Text = "Atributos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Atributo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BEliminarT;
        private System.Windows.Forms.Button BModificarT;
        private System.Windows.Forms.Button BAgregarT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid_Atributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
    }
}