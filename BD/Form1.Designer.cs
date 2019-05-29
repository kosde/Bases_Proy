namespace BD
{
    partial class Manejador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manejador));
            this.MenuBD = new System.Windows.Forms.MenuStrip();
            this.tablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BAgregarT = new System.Windows.Forms.Button();
            this.BModificarT = new System.Windows.Forms.Button();
            this.BEliminarT = new System.Windows.Forms.Button();
            this.nombrebd = new System.Windows.Forms.TextBox();
            this.LNombreBD = new System.Windows.Forms.Label();
            this.bCrearBD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_CargaT = new System.Windows.Forms.ComboBox();
            this.dataGridView_Imp_Reg = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label_NombreTabla = new System.Windows.Forms.Label();
            this.bTuplas = new System.Windows.Forms.Button();
            this.dataSQL = new System.Windows.Forms.DataGridView();
            this.Compilar = new System.Windows.Forms.Button();
            this.SQL = new System.Windows.Forms.Label();
            this.textSQL = new System.Windows.Forms.TextBox();
            this.dataGrid_Registro = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_Dato_Registro = new System.Windows.Forms.ComboBox();
            this.comboBox_Registro_Atributo = new System.Windows.Forms.ComboBox();
            this.comboBox_Reg_tam = new System.Windows.Forms.ComboBox();
            this.MenuBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Imp_Reg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Registro)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBD
            // 
            this.MenuBD.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuBD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablaToolStripMenuItem});
            this.MenuBD.Location = new System.Drawing.Point(0, 0);
            this.MenuBD.Name = "MenuBD";
            this.MenuBD.Size = new System.Drawing.Size(1902, 28);
            this.MenuBD.TabIndex = 0;
            this.MenuBD.Text = "menuStrip1";
            // 
            // tablaToolStripMenuItem
            // 
            this.tablaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.modificarToolStripMenuItem});
            this.tablaToolStripMenuItem.Name = "tablaToolStripMenuItem";
            this.tablaToolStripMenuItem.Size = new System.Drawing.Size(41, 24);
            this.tablaToolStripMenuItem.Text = "BD";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abirToolStripMenuItem
            // 
            this.abirToolStripMenuItem.Name = "abirToolStripMenuItem";
            this.abirToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.abirToolStripMenuItem.Text = "Abrir";
            this.abirToolStripMenuItem.Click += new System.EventHandler(this.abirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.guardarToolStripMenuItem.Text = "Eliminar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // BAgregarT
            // 
            this.BAgregarT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BAgregarT.BackgroundImage")));
            this.BAgregarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BAgregarT.Location = new System.Drawing.Point(12, 31);
            this.BAgregarT.Name = "BAgregarT";
            this.BAgregarT.Size = new System.Drawing.Size(50, 50);
            this.BAgregarT.TabIndex = 1;
            this.BAgregarT.UseCompatibleTextRendering = true;
            this.BAgregarT.UseVisualStyleBackColor = true;
            this.BAgregarT.Visible = false;
            this.BAgregarT.Click += new System.EventHandler(this.BAgregarT_Click);
            // 
            // BModificarT
            // 
            this.BModificarT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BModificarT.BackgroundImage")));
            this.BModificarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BModificarT.Location = new System.Drawing.Point(68, 31);
            this.BModificarT.Name = "BModificarT";
            this.BModificarT.Size = new System.Drawing.Size(50, 50);
            this.BModificarT.TabIndex = 2;
            this.BModificarT.UseCompatibleTextRendering = true;
            this.BModificarT.UseVisualStyleBackColor = true;
            this.BModificarT.Visible = false;
            this.BModificarT.Click += new System.EventHandler(this.BModificarT_Click);
            // 
            // BEliminarT
            // 
            this.BEliminarT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BEliminarT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BEliminarT.BackgroundImage")));
            this.BEliminarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BEliminarT.Location = new System.Drawing.Point(124, 31);
            this.BEliminarT.Name = "BEliminarT";
            this.BEliminarT.Size = new System.Drawing.Size(50, 50);
            this.BEliminarT.TabIndex = 3;
            this.BEliminarT.UseCompatibleTextRendering = true;
            this.BEliminarT.UseVisualStyleBackColor = false;
            this.BEliminarT.Visible = false;
            this.BEliminarT.Click += new System.EventHandler(this.BEliminarT_Click);
            // 
            // nombrebd
            // 
            this.nombrebd.Location = new System.Drawing.Point(362, 11);
            this.nombrebd.Name = "nombrebd";
            this.nombrebd.Size = new System.Drawing.Size(394, 22);
            this.nombrebd.TabIndex = 4;
            this.nombrebd.Visible = false;
            // 
            // LNombreBD
            // 
            this.LNombreBD.AutoSize = true;
            this.LNombreBD.Location = new System.Drawing.Point(298, 11);
            this.LNombreBD.Name = "LNombreBD";
            this.LNombreBD.Size = new System.Drawing.Size(58, 17);
            this.LNombreBD.TabIndex = 5;
            this.LNombreBD.Text = "Nombre";
            this.LNombreBD.Visible = false;
            // 
            // bCrearBD
            // 
            this.bCrearBD.Location = new System.Drawing.Point(762, 10);
            this.bCrearBD.Name = "bCrearBD";
            this.bCrearBD.Size = new System.Drawing.Size(75, 23);
            this.bCrearBD.TabIndex = 6;
            this.bCrearBD.Text = "Crear";
            this.bCrearBD.UseVisualStyleBackColor = true;
            this.bCrearBD.Visible = false;
            this.bCrearBD.Click += new System.EventHandler(this.bCrearBD_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 85;
            this.label5.Text = "Tabla(s)";
            this.label5.Visible = false;
            // 
            // comboBox_CargaT
            // 
            this.comboBox_CargaT.FormattingEnabled = true;
            this.comboBox_CargaT.Items.AddRange(new object[] {
            "Alta",
            "Baja",
            "Modifica"});
            this.comboBox_CargaT.Location = new System.Drawing.Point(362, 45);
            this.comboBox_CargaT.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_CargaT.Name = "comboBox_CargaT";
            this.comboBox_CargaT.Size = new System.Drawing.Size(147, 24);
            this.comboBox_CargaT.TabIndex = 84;
            this.comboBox_CargaT.Visible = false;
            this.comboBox_CargaT.SelectedIndexChanged += new System.EventHandler(this.comboBox_CargaT_SelectedIndexChanged);
            // 
            // dataGridView_Imp_Reg
            // 
            this.dataGridView_Imp_Reg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Imp_Reg.Location = new System.Drawing.Point(12, 162);
            this.dataGridView_Imp_Reg.Name = "dataGridView_Imp_Reg";
            this.dataGridView_Imp_Reg.RowTemplate.Height = 24;
            this.dataGridView_Imp_Reg.Size = new System.Drawing.Size(920, 814);
            this.dataGridView_Imp_Reg.TabIndex = 86;
            this.dataGridView_Imp_Reg.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 87;
            this.button1.Text = "Atributos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.bAtributos_Click);
            // 
            // label_NombreTabla
            // 
            this.label_NombreTabla.AutoSize = true;
            this.label_NombreTabla.Location = new System.Drawing.Point(465, 130);
            this.label_NombreTabla.Name = "label_NombreTabla";
            this.label_NombreTabla.Size = new System.Drawing.Size(44, 17);
            this.label_NombreTabla.TabIndex = 88;
            this.label_NombreTabla.Text = "Tabla";
            this.label_NombreTabla.Visible = false;
            // 
            // bTuplas
            // 
            this.bTuplas.Location = new System.Drawing.Point(640, 45);
            this.bTuplas.Name = "bTuplas";
            this.bTuplas.Size = new System.Drawing.Size(75, 23);
            this.bTuplas.TabIndex = 89;
            this.bTuplas.Text = "Tuplas";
            this.bTuplas.UseVisualStyleBackColor = true;
            this.bTuplas.Visible = false;
            this.bTuplas.Click += new System.EventHandler(this.bTuplas_Click);
            // 
            // dataSQL
            // 
            this.dataSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSQL.Location = new System.Drawing.Point(970, 162);
            this.dataSQL.Name = "dataSQL";
            this.dataSQL.RowTemplate.Height = 24;
            this.dataSQL.Size = new System.Drawing.Size(920, 814);
            this.dataSQL.TabIndex = 90;
            this.dataSQL.Visible = false;
            // 
            // Compilar
            // 
            this.Compilar.Location = new System.Drawing.Point(1700, 88);
            this.Compilar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Compilar.Name = "Compilar";
            this.Compilar.Size = new System.Drawing.Size(100, 28);
            this.Compilar.TabIndex = 127;
            this.Compilar.Text = "Ejecutar";
            this.Compilar.UseVisualStyleBackColor = true;
            this.Compilar.Visible = false;
            this.Compilar.Click += new System.EventHandler(this.Compilar_Click);
            // 
            // SQL
            // 
            this.SQL.AutoSize = true;
            this.SQL.Location = new System.Drawing.Point(1112, 96);
            this.SQL.Name = "SQL";
            this.SQL.Size = new System.Drawing.Size(36, 17);
            this.SQL.TabIndex = 126;
            this.SQL.Text = "SQL";
            this.SQL.Visible = false;
            // 
            // textSQL
            // 
            this.textSQL.Location = new System.Drawing.Point(1155, 93);
            this.textSQL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textSQL.Name = "textSQL";
            this.textSQL.Size = new System.Drawing.Size(526, 22);
            this.textSQL.TabIndex = 125;
            this.textSQL.Visible = false;
            // 
            // dataGrid_Registro
            // 
            this.dataGrid_Registro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Registro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dataGrid_Registro.Location = new System.Drawing.Point(124, 454);
            this.dataGrid_Registro.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Registro.Name = "dataGrid_Registro";
            this.dataGrid_Registro.Size = new System.Drawing.Size(703, 155);
            this.dataGrid_Registro.TabIndex = 128;
            this.dataGrid_Registro.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Atributo";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tamaño";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Dato";
            this.Column3.Name = "Column3";
            // 
            // comboBox_Dato_Registro
            // 
            this.comboBox_Dato_Registro.FormattingEnabled = true;
            this.comboBox_Dato_Registro.Location = new System.Drawing.Point(560, 380);
            this.comboBox_Dato_Registro.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Dato_Registro.Name = "comboBox_Dato_Registro";
            this.comboBox_Dato_Registro.Size = new System.Drawing.Size(144, 24);
            this.comboBox_Dato_Registro.TabIndex = 130;
            this.comboBox_Dato_Registro.Visible = false;
            // 
            // comboBox_Registro_Atributo
            // 
            this.comboBox_Registro_Atributo.FormattingEnabled = true;
            this.comboBox_Registro_Atributo.Location = new System.Drawing.Point(301, 380);
            this.comboBox_Registro_Atributo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Registro_Atributo.Name = "comboBox_Registro_Atributo";
            this.comboBox_Registro_Atributo.Size = new System.Drawing.Size(175, 24);
            this.comboBox_Registro_Atributo.TabIndex = 129;
            this.comboBox_Registro_Atributo.Visible = false;
            // 
            // comboBox_Reg_tam
            // 
            this.comboBox_Reg_tam.FormattingEnabled = true;
            this.comboBox_Reg_tam.Location = new System.Drawing.Point(301, 432);
            this.comboBox_Reg_tam.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Reg_tam.Name = "comboBox_Reg_tam";
            this.comboBox_Reg_tam.Size = new System.Drawing.Size(160, 24);
            this.comboBox_Reg_tam.TabIndex = 131;
            this.comboBox_Reg_tam.Visible = false;
            // 
            // Manejador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.Compilar);
            this.Controls.Add(this.SQL);
            this.Controls.Add(this.textSQL);
            this.Controls.Add(this.dataSQL);
            this.Controls.Add(this.bTuplas);
            this.Controls.Add(this.label_NombreTabla);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_Imp_Reg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_CargaT);
            this.Controls.Add(this.bCrearBD);
            this.Controls.Add(this.LNombreBD);
            this.Controls.Add(this.nombrebd);
            this.Controls.Add(this.BEliminarT);
            this.Controls.Add(this.BModificarT);
            this.Controls.Add(this.BAgregarT);
            this.Controls.Add(this.MenuBD);
            this.Controls.Add(this.dataGrid_Registro);
            this.Controls.Add(this.comboBox_Dato_Registro);
            this.Controls.Add(this.comboBox_Registro_Atributo);
            this.Controls.Add(this.comboBox_Reg_tam);
            this.MainMenuStrip = this.MenuBD;
            this.Name = "Manejador";
            this.Text = "Manejador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuBD.ResumeLayout(false);
            this.MenuBD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Imp_Reg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Registro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBD;
        private System.Windows.Forms.ToolStripMenuItem tablaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Button BAgregarT;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.Button BModificarT;
        private System.Windows.Forms.Button BEliminarT;
        private System.Windows.Forms.TextBox nombrebd;
        private System.Windows.Forms.Label LNombreBD;
        private System.Windows.Forms.Button bCrearBD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_CargaT;
        private System.Windows.Forms.DataGridView dataGridView_Imp_Reg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_NombreTabla;
        private System.Windows.Forms.Button bTuplas;
        private System.Windows.Forms.DataGridView dataSQL;
        private System.Windows.Forms.Button Compilar;
        private System.Windows.Forms.Label SQL;
        private System.Windows.Forms.TextBox textSQL;
        private System.Windows.Forms.DataGridView dataGrid_Registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.ComboBox comboBox_Dato_Registro;
        private System.Windows.Forms.ComboBox comboBox_Registro_Atributo;
        private System.Windows.Forms.ComboBox comboBox_Reg_tam;
    }
}

