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
        public List<string> auxt = new List<string>();
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
            string nuevonombre = "";
            FModifcarBD vEnt = new FModifcarBD();
            
            vEnt.LlenaDatos(auxt);
            if (vEnt.ShowDialog() == DialogResult.OK)
            { 
                nombre = vEnt.nombre;
                nuevonombre = vEnt.nuevonombre;
                ModificaNT_Click(nombre,nuevonombre);
            }
            comboBox_CargaT.Items.Clear();
            comboBox_CargaT.Text = "";
            CargaTablas();
        }

        private void ModificaNT_Click(string nombrearch,string nuevoN)
        {
            try
            { 
                string file_ext = ".bin";
                string ruta1 = ruta + "/" + nombrearch + file_ext,
                    ruta2 = ruta + "/" + nuevoN + file_ext;
                if (nombrearch.CompareTo("") != 0)
                {
                    File.Move(ruta1, ruta2);
                }
                else
                {
                    MessageBox.Show("Escribe el nombre de la tabla que se eliminara");
                }
            }
            catch { }
        }

        private void BEliminarT_Click(object sender, EventArgs e)
        {
            string nombre = "";
            Borrar vEnt = new Borrar();
            vEnt.LlenaDatos(auxt);
            if (vEnt.ShowDialog() == DialogResult.OK)
            {
                nombre = vEnt.nombreb; //lee la propiedad
                //vEnt.AltaNT_Click(nombrearch, ruta);
                //this.Text = nombre; //la pone en el título
                //CargaTablas();
                BajaNT_Click(nombre);
            }
            comboBox_CargaT.Items.Clear();
            comboBox_CargaT.Text = "";
            CargaTablas();
        }
        private void BajaNT_Click(string nombre)
        {
            try
            {
                string file_ext = ".bin";
                if (nombre.CompareTo("") != 0)
                {
                    File.Delete(ruta + "/" + nombre + file_ext);
                }
                else
                {
                    MessageBox.Show("Escribe el nombre de la tabla que se eliminara");
                }
            }
            catch { }
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
                FModifcarBD mod = new FModifcarBD();
                if (mod.ShowDialog() == DialogResult.OK)
                {

                    //nombre = vEnt.nombre; //lee la propiedad
                                          //this.Text = nombre; //la pone en el título

                }
                
                //mod.Show();
            }
            else
                MessageBox.Show("Primero abre o crea una BD");
        }

        private void bAtributos_Click(object sender, EventArgs e)
        {
            Atributos_Form Atrib = new Atributos_Form(comboBox_CargaT.Text,ruta,auxt);
            Atrib.Show();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LNombreBD.Visible = true;
            nombrebd.Visible = true;
            bCrearBD.Visible = true;
            nombrebd.Text = "";
        }

        private void comboBox_CargaT_SelectedIndexChanged(object sender, EventArgs e)
        {
            dDatosAtribEnt.Visible = true;
            button1.Visible = true;
            label_NombreTabla.Visible = true;
            label_NombreTabla.Text = comboBox_CargaT.Text;
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
            //vEnt.Show();
            if (vEnt.ShowDialog() == DialogResult.OK)
            {

                nombre = vEnt.nombre; //lee la propiedad
                vEnt.AltaNT_Click(nombrearch, ruta);
                //this.Text = nombre; //la pone en el título
                CargaTablas();
            }
        }
        private void CargaTablas()
        {
            try
            {
                comboBox_CargaT.Visible = true;
                label5.Visible = true;
                auxt.Clear();
                comboBox_CargaT.Items.Clear();
                //ComboBoxEntidadparaAtrib.Items.Clear();
                //Entidad_Registro.Items.Clear();
                String[] Sep = { ".bin" };

                string[] Tablas = Directory.GetFiles(ruta);
                if (Tablas.Length != 0)
                    for (int i = 0; i < Tablas.Length; i++)
                    {
                        string Arch = Path.GetFileName(Tablas[i]);
                        //string[] codf = CodFuente.Split(Separadores, StringSplitOptions.RemoveEmptyEntries);
                        string[] A = Arch.Split(Sep, StringSplitOptions.RemoveEmptyEntries);
                        auxt.Add(A[0]);
                        comboBox_CargaT.Items.Add(A[0]);
                        //ComboBoxEntidadparaAtrib.Items.Add(A[0]);
                        //Entidad_Registro.Items.Add(A[0]);

                    }
            }
            catch { }
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
                    LNombreBD.Visible = true;
                    nombrebd.Visible = true;
                    bCrearBD.Visible = true;
                    BAgregarT.Visible = true;
                    BModificarT.Visible = true;
                    BEliminarT.Visible = true;
                    CargaTablas();
                }
            }
        }
    }
}
