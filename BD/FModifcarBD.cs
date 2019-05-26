﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class FModifcarBD : Form
    {
        public string nombre { get; set; }
        public string nuevonombre { get; set; }
        public FModifcarBD()
        {
            InitializeComponent();
        }

        private void buttonBD_Click(object sender, EventArgs e)
        {
            nombre = comboBox_CargaT.Text;
            nuevonombre = textBoxnuevoDB.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public void LlenaDatos(List<string> Tablas)
        {
            if (Tablas.Count != 0)
                for (int i = 0; i < Tablas.Count; i++)
                    comboBox_CargaT.Items.Add(Tablas[i]);
        }
    }
}
