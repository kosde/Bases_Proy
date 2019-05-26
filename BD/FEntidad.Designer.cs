namespace BD
{
    partial class FEntidad
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
            this.textBoxTablaNuevo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Archivo_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTablaNuevo
            // 
            this.textBoxTablaNuevo.Location = new System.Drawing.Point(134, 60);
            this.textBoxTablaNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTablaNuevo.Name = "textBoxTablaNuevo";
            this.textBoxTablaNuevo.Size = new System.Drawing.Size(249, 22);
            this.textBoxTablaNuevo.TabIndex = 128;
            this.textBoxTablaNuevo.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(25, 63);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 17);
            this.label22.TabIndex = 127;
            this.label22.Text = "Nuevo Nombre";
            this.label22.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 120);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 126;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 120;
            this.label3.Text = "Tabla";
            // 
            // Archivo_text
            // 
            this.Archivo_text.Location = new System.Drawing.Point(134, 29);
            this.Archivo_text.Margin = new System.Windows.Forms.Padding(4);
            this.Archivo_text.Multiline = true;
            this.Archivo_text.Name = "Archivo_text";
            this.Archivo_text.Size = new System.Drawing.Size(249, 24);
            this.Archivo_text.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 117;
            this.label1.Text = "Nombre de Tabla";
            // 
            // FEntidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 161);
            this.Controls.Add(this.textBoxTablaNuevo);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Archivo_text);
            this.Controls.Add(this.label1);
            this.Name = "FEntidad";
            this.Text = "Entidad";
            this.Load += new System.EventHandler(this.FEntidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTablaNuevo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Archivo_text;
        private System.Windows.Forms.Label label1;
    }
}