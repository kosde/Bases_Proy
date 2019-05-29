namespace BD
{
    partial class Tuplas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tuplas));
            this.BEliminarT = new System.Windows.Forms.Button();
            this.BModificarT = new System.Windows.Forms.Button();
            this.BAgregarT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid_Registro = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_Dato_Registro = new System.Windows.Forms.ComboBox();
            this.comboBox_Reg_tam = new System.Windows.Forms.ComboBox();
            this.dataGridTablaAux = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_Registro_Atributo = new System.Windows.Forms.ComboBox();
            this.bGuardarR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Registro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTablaAux)).BeginInit();
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
            // dataGrid_Registro
            // 
            this.dataGrid_Registro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Registro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dataGrid_Registro.Location = new System.Drawing.Point(13, 69);
            this.dataGrid_Registro.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Registro.Name = "dataGrid_Registro";
            this.dataGrid_Registro.Size = new System.Drawing.Size(774, 334);
            this.dataGrid_Registro.TabIndex = 97;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 193F;
            this.Column1.HeaderText = "Atributo";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 193F;
            this.Column2.HeaderText = "Tipo";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 193F;
            this.Column4.HeaderText = "Tamaño";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 193F;
            this.Column3.HeaderText = "Dato";
            this.Column3.Name = "Column3";
            // 
            // comboBox_Dato_Registro
            // 
            this.comboBox_Dato_Registro.FormattingEnabled = true;
            this.comboBox_Dato_Registro.Location = new System.Drawing.Point(410, 130);
            this.comboBox_Dato_Registro.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Dato_Registro.Name = "comboBox_Dato_Registro";
            this.comboBox_Dato_Registro.Size = new System.Drawing.Size(144, 24);
            this.comboBox_Dato_Registro.TabIndex = 98;
            this.comboBox_Dato_Registro.Visible = false;
            // 
            // comboBox_Reg_tam
            // 
            this.comboBox_Reg_tam.FormattingEnabled = true;
            this.comboBox_Reg_tam.Location = new System.Drawing.Point(151, 182);
            this.comboBox_Reg_tam.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Reg_tam.Name = "comboBox_Reg_tam";
            this.comboBox_Reg_tam.Size = new System.Drawing.Size(160, 24);
            this.comboBox_Reg_tam.TabIndex = 99;
            // 
            // dataGridTablaAux
            // 
            this.dataGridTablaAux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTablaAux.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataGridTablaAux.Location = new System.Drawing.Point(49, 150);
            this.dataGridTablaAux.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridTablaAux.Name = "dataGridTablaAux";
            this.dataGridTablaAux.Size = new System.Drawing.Size(703, 150);
            this.dataGridTablaAux.TabIndex = 126;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Atributo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Tamaño";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Dato";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // comboBox_Registro_Atributo
            // 
            this.comboBox_Registro_Atributo.FormattingEnabled = true;
            this.comboBox_Registro_Atributo.Location = new System.Drawing.Point(313, 213);
            this.comboBox_Registro_Atributo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Registro_Atributo.Name = "comboBox_Registro_Atributo";
            this.comboBox_Registro_Atributo.Size = new System.Drawing.Size(175, 24);
            this.comboBox_Registro_Atributo.TabIndex = 127;
            this.comboBox_Registro_Atributo.Visible = false;
            // 
            // bGuardarR
            // 
            this.bGuardarR.Location = new System.Drawing.Point(236, 26);
            this.bGuardarR.Name = "bGuardarR";
            this.bGuardarR.Size = new System.Drawing.Size(75, 23);
            this.bGuardarR.TabIndex = 128;
            this.bGuardarR.Text = "Guardar";
            this.bGuardarR.UseVisualStyleBackColor = false;
            this.bGuardarR.Visible = false;
            this.bGuardarR.Click += new System.EventHandler(this.bGuardarR_Click);
            // 
            // Tuplas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bGuardarR);
            this.Controls.Add(this.dataGrid_Registro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BEliminarT);
            this.Controls.Add(this.BModificarT);
            this.Controls.Add(this.BAgregarT);
            this.Controls.Add(this.dataGridTablaAux);
            this.Controls.Add(this.comboBox_Dato_Registro);
            this.Controls.Add(this.comboBox_Reg_tam);
            this.Controls.Add(this.comboBox_Registro_Atributo);
            this.Name = "Tuplas";
            this.Text = "Tuplas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Registro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTablaAux)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BEliminarT;
        private System.Windows.Forms.Button BModificarT;
        private System.Windows.Forms.Button BAgregarT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid_Registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.ComboBox comboBox_Dato_Registro;
        private System.Windows.Forms.ComboBox comboBox_Reg_tam;
        private System.Windows.Forms.DataGridView dataGridTablaAux;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ComboBox comboBox_Registro_Atributo;
        private System.Windows.Forms.Button bGuardarR;
    }
}