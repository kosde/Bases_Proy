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
            this.dDatosAtribEnt = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.MenuBD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dDatosAtribEnt)).BeginInit();
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
            this.nombrebd.Location = new System.Drawing.Point(248, 11);
            this.nombrebd.Name = "nombrebd";
            this.nombrebd.Size = new System.Drawing.Size(195, 22);
            this.nombrebd.TabIndex = 4;
            this.nombrebd.Visible = false;
            // 
            // LNombreBD
            // 
            this.LNombreBD.AutoSize = true;
            this.LNombreBD.Location = new System.Drawing.Point(184, 11);
            this.LNombreBD.Name = "LNombreBD";
            this.LNombreBD.Size = new System.Drawing.Size(58, 17);
            this.LNombreBD.TabIndex = 5;
            this.LNombreBD.Text = "Nombre";
            this.LNombreBD.Visible = false;
            // 
            // bCrearBD
            // 
            this.bCrearBD.Location = new System.Drawing.Point(449, 10);
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
            this.label5.Location = new System.Drawing.Point(181, 64);
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
            this.comboBox_CargaT.Location = new System.Drawing.Point(250, 57);
            this.comboBox_CargaT.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_CargaT.Name = "comboBox_CargaT";
            this.comboBox_CargaT.Size = new System.Drawing.Size(147, 24);
            this.comboBox_CargaT.TabIndex = 84;
            this.comboBox_CargaT.Visible = false;
            // 
            // dDatosAtribEnt
            // 
            this.dDatosAtribEnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dDatosAtribEnt.Location = new System.Drawing.Point(12, 100);
            this.dDatosAtribEnt.Name = "dDatosAtribEnt";
            this.dDatosAtribEnt.RowTemplate.Height = 24;
            this.dDatosAtribEnt.Size = new System.Drawing.Size(1132, 406);
            this.dDatosAtribEnt.TabIndex = 86;
            this.dDatosAtribEnt.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 87;
            this.button1.Text = "Atributos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.bAtributos_Click);
            // 
            // Manejador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dDatosAtribEnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_CargaT);
            this.Controls.Add(this.bCrearBD);
            this.Controls.Add(this.LNombreBD);
            this.Controls.Add(this.nombrebd);
            this.Controls.Add(this.BEliminarT);
            this.Controls.Add(this.BModificarT);
            this.Controls.Add(this.BAgregarT);
            this.Controls.Add(this.MenuBD);
            this.MainMenuStrip = this.MenuBD;
            this.Name = "Manejador";
            this.Text = "Manejador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuBD.ResumeLayout(false);
            this.MenuBD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dDatosAtribEnt)).EndInit();
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
        private System.Windows.Forms.DataGridView dDatosAtribEnt;
        private System.Windows.Forms.Button button1;
    }
}

