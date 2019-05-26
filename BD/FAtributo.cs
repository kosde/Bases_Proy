using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BD
{
    public partial class FAtributo : Form
    {
        public string Nombre_Tabla { get; set; }
        public string Nombre_Atributo { get; set; }         // Nombre del Atributo
        public char Tipo { get; set; }                      // Tipo de atributo Long Sting Char Float
        public long Tamaño { get; set; }                    // Tamaño segun tipo ^
        public long Posicion { get; set; }                  // Posicion de inicio Atributo
        public long Sig_Atributo { get; set; }              // Posicion Siguiente Atributo
        public bool Clave { get; set; }                     // Clave True-False
        public string llavef { get; set; }                  // Llave foranea
        public bool nollaves { get; set; }
        public long PosEnt;
        public string nombrearch;
        public string archactual;
        public List<string> listaT = new List<string>();

        public FAtributo()
        {
            InitializeComponent();
        }
        public FAtributo(long pose,string narch, string archivoactual,List<string>LT)
        {
            InitializeComponent();
            PosEnt = pose;
            nombrearch = narch;
            archactual = archivoactual;
            listaT = LT;
        }
        
        public void llenacampos()
        {
            Nombre_Atributo = Nombre_Atributo.Replace(" ", "");
            TextBox_NombreEntidad.Text = Nombre_Atributo.ToString();
            textBox4.Text = Nombre_Atributo.ToString();
            comboBox_Tipo.Text = Tipo.ToString();
            comboBox_tam_1.Text = Tamaño.ToString();
            comboBox_Clave.Text = Clave.ToString();
            if (llavef == "")
                llavef = "false";
            comb_KeyF.Text = llavef;
            noLlave.Text = nollaves.ToString();
            comboTabla_llaveF.Text = llavef;

        }
        private void AceptarBoton_Atributo_Click(object sender, EventArgs e)
        {
            string ClaveB, NombreE, llaveF = "";
            bool clave = false, exite = false, todoOk = false;
            Nombre_Tabla = comboTabla_llaveF.Text;
            Nombre_Atributo = textBox4.Text;
            Tamaño = TamañoTipoAtributo();
            Tipo = comboBox_Tipo.Text[0];
            //tipo = TipoDedatoCombobox[0];
            Activa_o_Desactiva_Llave(PosEnt);
            ClaveB = comboBox_Clave.Text.ToString();
            if (comb_KeyF.SelectedItem != null)
            {
                if (comb_KeyF.SelectedItem.ToString().CompareTo("true") == 0)
                {
                    llavef = comboTabla_llaveF.Text.ToString();
                    llavef = llavef.PadRight(29, ' ');
                    llavef = llavef.Substring(0, 29);
                }
                else
                {
                    llavef = "false";
                    llavef = llavef.PadRight(29, ' ');
                    llavef = llavef.Substring(0, 29);
                }
            }
            else
                MessageBox.Show("Se debe seleccionar llave foranea");
            if (ClaveB.CompareTo("true") == 0)
                clave = true;
            Clave = clave;

            if (noLlave.Text.CompareTo("true") == 0)
                nollaves = true;
            else
                nollaves = false;

            DialogResult = DialogResult.OK;
            this.Close();
        }
        private long TamañoTipoAtributo()
        {
            ///De acuerdo al tipo de dato seleccionado se calcula el tamaño y se regresa
            long tipo = 0;
            string TipoC;
            TipoC = comboBox_Tipo.Text.ToString();
            if (TipoC.CompareTo("Int") == 0)
                tipo = 4;
            if (TipoC.CompareTo("Long") == 0 || TipoC.CompareTo("Float") == 0)
                tipo = 8;
            if (TipoC.CompareTo("String") == 0)
            {
                tipo = int.Parse(comboBox_tam_1.Text.ToString());
                tipo = tipo - 1;
            }
            if (TipoC.CompareTo("Char") == 0)
                tipo = 1;
            return tipo;
        }
        private void Activa_o_Desactiva_Llave(long PosEnt)
        {
             ///Se busca si existe una llave primaria para habilitar o deshabilitar
             bool existe = false;
             existe = BuscaClave(PosEnt);
             if (existe == true)
             {
                 comboBox_Clave.SelectedIndex = 1;
                 comboBox_Clave.Enabled = false;
             }
             else
             {
                 comboBox_Clave.Enabled = true;
             }
        }
        private bool BuscaClave(long posEntidad)
        {
            ///Busca si existe una clave primearia apartir de la posicion de la entidad
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0;
            bool bandera = false;

            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();

            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    PosF = reader.BaseStream.Position;
                    reader.ReadString();
                    reader.ReadChar();
                    reader.ReadInt64();
                    reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    bandera = reader.ReadBoolean();
                    if (bandera == true)
                    {
                        reader.Close();
                        writer.Close();
                        fichero.Close();
                        return bandera;
                    }
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();

            return bandera;
        }
        private void comboBox_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///Combo box de seleccion de tipo de dato mostrando u ocultando los campos requeridos
            string L = "Long", S = "String", C = "Char", F = "Float", I = "Int", Seleccion;
            Seleccion = comboBox_Tipo.Text.ToString();
            if (I.CompareTo(Seleccion) == 0)
            {
                Tamlabel.Visible = false;
                comboBox_tam_1.Visible = false;
                return;
            }
            if (L.CompareTo(Seleccion) == 0)
            {
                Tamlabel.Visible = false;
                comboBox_tam_1.Visible = false;
                return;
            }
            if (S.CompareTo(Seleccion) == 0)
            {
                Tamlabel.Visible = true;
                comboBox_tam_1.Visible = true;
                return;
            }
            if (C.CompareTo(Seleccion) == 0)
            {
                Tamlabel.Visible = false;
                comboBox_tam_1.Visible = false;
                return;
            }
            if (F.CompareTo(Seleccion) == 0)
            {
                Tamlabel.Visible = false;
                comboBox_tam_1.Visible = false;
                return;
            }
        }
        private void comb_KeyF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = comb_KeyF.SelectedItem.ToString();
            if (seleccion.CompareTo("true") == 0)
            {
                label23.Visible = true;
                comboTabla_llaveF.Visible = true;
            }
            else
            {
                label23.Visible = false;
                comboTabla_llaveF.Visible = false;
            }
            imprime_tablasllave_F();
        }
        private void imprime_tablasllave_F()
        {
            comboTabla_llaveF.Items.Clear();
            string nombreTabla_actual = archactual;
            string[] tablas = new string[listaT.Count];
            for (int i = 0; i < listaT.Count; i++)
            {
                if (nombreTabla_actual.CompareTo(listaT[i].ToString()) != 0)
                    tablas[i] = listaT[i].ToString();
            }
            foreach (string t in tablas)
            {
                if (t != null)
                    comboTabla_llaveF.Items.Add(t);
            }
        }
        private void FAtributo_Load(object sender, EventArgs e)
        {

        }
    }
}
