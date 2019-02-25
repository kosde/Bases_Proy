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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.BEliminarT.Visible = false;
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
            this.BModificarT.Visible = false;
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
            this.BAgregarT.Visible = false;
            this.BAgregarT.Click += new System.EventHandler(this.BAgregarT_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(754, 303);
            this.dataGridView1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Atributos_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BEliminarT);
            this.Controls.Add(this.BModificarT);
            this.Controls.Add(this.BAgregarT);
            this.Name = "Atributos_Form";
            this.Text = "Atributos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BEliminarT;
        private System.Windows.Forms.Button BModificarT;
        private System.Windows.Forms.Button BAgregarT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}