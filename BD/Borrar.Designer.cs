namespace BD
{
    partial class Borrar
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
            this.buttonBD = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox_CargaT = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonBD
            // 
            this.buttonBD.Location = new System.Drawing.Point(146, 37);
            this.buttonBD.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBD.Name = "buttonBD";
            this.buttonBD.Size = new System.Drawing.Size(100, 28);
            this.buttonBD.TabIndex = 124;
            this.buttonBD.Text = "Aceptar";
            this.buttonBD.UseVisualStyleBackColor = true;
            this.buttonBD.Click += new System.EventHandler(this.buttonBD_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 9);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 17);
            this.label20.TabIndex = 120;
            this.label20.Text = "Nombre";
            // 
            // comboBox_CargaT
            // 
            this.comboBox_CargaT.FormattingEnabled = true;
            this.comboBox_CargaT.Location = new System.Drawing.Point(79, 5);
            this.comboBox_CargaT.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_CargaT.Name = "comboBox_CargaT";
            this.comboBox_CargaT.Size = new System.Drawing.Size(291, 24);
            this.comboBox_CargaT.TabIndex = 125;
            // 
            // Borrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 75);
            this.Controls.Add(this.comboBox_CargaT);
            this.Controls.Add(this.buttonBD);
            this.Controls.Add(this.label20);
            this.Name = "Borrar";
            this.Text = "Borrar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBD;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBox_CargaT;
    }
}