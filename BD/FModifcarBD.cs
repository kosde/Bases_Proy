using System;
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
        public int op = 0;
        public string nombre = "";
        public FModifcarBD(int opt, ref string nombre)
        {
            InitializeComponent();
            if (opt == 2)
            {
                //label22.Visible = true;
                //textBoxTablaNuevo.Visible = true;
            }
        }

        private void buttonBD_Click(object sender, EventArgs e)
        {

        }
    }
}
