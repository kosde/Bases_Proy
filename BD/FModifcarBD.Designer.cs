namespace BD
{
    partial class FModifcarBD
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
            this.textBoxnuevoDB = new System.Windows.Forms.TextBox();
            this.label22nuevoBD = new System.Windows.Forms.Label();
            this.nombrebd = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.buttonBD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxnuevoDB
            // 
            this.textBoxnuevoDB.Location = new System.Drawing.Point(139, 44);
            this.textBoxnuevoDB.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxnuevoDB.Name = "textBoxnuevoDB";
            this.textBoxnuevoDB.Size = new System.Drawing.Size(249, 22);
            this.textBoxnuevoDB.TabIndex = 118;
            // 
            // label22nuevoBD
            // 
            this.label22nuevoBD.AutoSize = true;
            this.label22nuevoBD.Location = new System.Drawing.Point(6, 49);
            this.label22nuevoBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22nuevoBD.Name = "label22nuevoBD";
            this.label22nuevoBD.Size = new System.Drawing.Size(126, 17);
            this.label22nuevoBD.TabIndex = 117;
            this.label22nuevoBD.Text = "Nuevo Nombre BD";
            // 
            // nombrebd
            // 
            this.nombrebd.Location = new System.Drawing.Point(139, 13);
            this.nombrebd.Margin = new System.Windows.Forms.Padding(4);
            this.nombrebd.Multiline = true;
            this.nombrebd.Name = "nombrebd";
            this.nombrebd.Size = new System.Drawing.Size(249, 24);
            this.nombrebd.TabIndex = 116;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(30, 17);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 17);
            this.label20.TabIndex = 115;
            this.label20.Text = "Nombre de BD";
            // 
            // buttonBD
            // 
            this.buttonBD.Location = new System.Drawing.Point(164, 74);
            this.buttonBD.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBD.Name = "buttonBD";
            this.buttonBD.Size = new System.Drawing.Size(100, 28);
            this.buttonBD.TabIndex = 119;
            this.buttonBD.Text = "Aceptar";
            this.buttonBD.UseVisualStyleBackColor = true;
            this.buttonBD.Click += new System.EventHandler(this.buttonBD_Click);
            // 
            // FModifcarBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 110);
            this.Controls.Add(this.buttonBD);
            this.Controls.Add(this.textBoxnuevoDB);
            this.Controls.Add(this.label22nuevoBD);
            this.Controls.Add(this.nombrebd);
            this.Controls.Add(this.label20);
            this.Name = "FModifcarBD";
            this.Text = "Modifcar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxnuevoDB;
        private System.Windows.Forms.Label label22nuevoBD;
        private System.Windows.Forms.TextBox nombrebd;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonBD;
    }
}