using System;
using System.IO;
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
    public partial class Manejador : Form
    {
        public string nombrearch, ruta, auxf;
        public int OpEnt = 0, OpAtr, OpBD, OpTB, ContEnt = 0, OpReg = 0, rep = 2;
        bool MismoNombreAtributo = false, ArchivoInicia = false;
        public long posModifica = -1, taml = 8;

        private void bCrearBD_Click(object sender, EventArgs e)
        {
            if (nombrebd.Text.CompareTo("") == 0)
                MessageBox.Show("Primero coloca el nombre de la base de datos a crear");
            else
            {
                MessageBox.Show("Seleccione la ruta donde se creara la base de datos");
                string foldername = nombrebd.Text.ToString();
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.ShowNewFolderButton = false;
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        BAgregarT.Visible = true;
                        BModificarT.Visible = true;
                        BEliminarT.Visible = true;
                        ruta = fbd.SelectedPath;
                        if (foldername.CompareTo("") != 0)
                            ruta = ruta + "\\" + foldername;
                        if (Directory.Exists(ruta) == false)
                        {
                            DirectoryInfo di = Directory.CreateDirectory(ruta);
                        }
                        nombrebd.Text = ruta;
                    }
                }
            }
        }

        private void BModificarT_Click(object sender, EventArgs e)
        {
            string nombre="";
            FEntidad vEnt = new FEntidad(2,ref nombre);
            vEnt.Show();
        }

        private void BEliminarT_Click(object sender, EventArgs e)
        {
            string nombre = "";
            FEntidad vEnt = new FEntidad(3, ref nombre);
            vEnt.Show();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ruta = fbd.SelectedPath;
                    //ruta = ruta + "/" + foldername;
                    if (Directory.Exists(ruta) == true)
                    {
                        System.IO.Directory.Delete(ruta, true);
                        MessageBox.Show("Se a elminado la BD seleccionada");
                    }
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nombrebd.Text != "")
            {
                string nombre = "";
                FModifcarBD mod = new FModifcarBD(2, ref nombre);
                mod.Show();
            }
            else
                MessageBox.Show("Primero abre o crea una BD");
        }

        private void bAtributos_Click(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LNombreBD.Visible = true;
            nombrebd.Visible = true;
            bCrearBD.Visible = true;
            nombrebd.Text = "";
        }

        string foldername = "", rutaarch = "";
        string datoborrado = "", tipodatoborrado = "";

        List<Atributo> ListaAtributos = new List<Atributo>();
        List<Atributo> ListaAuxAtrib = new List<Atributo>();
        List<Atributo> AtribSegtabla = new List<Atributo>();//= CargaAtributos(PosEnt);
        public Manejador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            WindowState = FormWindowState.Maximized;


        }

        private void BAgregarT_Click(object sender, EventArgs e)
        {
            string nombre = "";
            FEntidad vEnt = new FEntidad(1, ref nombre);
            vEnt.Show();
        }

        private void abirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string foldername = "";
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    LNombreBD.Visible = true;
                    nombrebd.Visible = true;
                    ruta = fbd.SelectedPath;
                    if (foldername.CompareTo("") != 0)
                        ruta = ruta + "\\" + foldername;
                    if (Directory.Exists(ruta) == false)
                    {
                        DirectoryInfo di = Directory.CreateDirectory(ruta);
                    }
                    nombrebd.Text = ruta;
                }
            }
        }
    }
}
