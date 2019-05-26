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
    public partial class FEntidad : Form
    {
        public int op = 0;
        public string nombre { get; set; }
    
        public string narch="";
        public FEntidad(int opt,ref string nombre)
        {
            InitializeComponent();
            if(opt==2)
            {
                label22.Visible = true;
                textBoxTablaNuevo.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nombre = Archivo_text.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public void AltaNT_Click(string nombrearch,string ruta)
        {
            ///Al presionar el boton se carga el archivo o se crea con el nombre que se acaba de establecer
            ///tambien se inicializa la cabecera de ser necesario
            try
            {
                string file_ext = ".bin";
                nombrearch = Archivo_text.Text;
                //IniciaCabecera();
                if (nombrearch.CompareTo("") != 0)
                {
                    narch = nombrearch = ruta + "\\" + nombrearch + file_ext;
                    long cab = 0;
                    try
                    {
                        FileStream stream = new FileStream(nombrearch, FileMode.Open, FileAccess.Read);
                        BinaryReader reader = new BinaryReader(stream);
                        cab = reader.ReadInt64();
                        reader.Close();
                        stream.Close();
                        //Imprime_ComboBox();
                    }
                    catch
                    {
                        if (cab != 8)
                        {
                            IniciaCabecera(nombrearch);
                        }
                        AltaE_Click();
                    }
                }
                else
                    MessageBox.Show("Escribe el nombre de la tabla");
                //Imprimir_botonn_Click(sender, e);
            }
            catch { }
        }
        private long BuscaFinal()
        {
            ///Aqui se busca el final de los atributos y entidades que existen
            FileStream fichero = File.Open(narch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long cabecera, aux = 0, auxAtrib = 0, Ult_pos = 0, PosF = -1;
            long atrib, sig_ent, sig_a = 0, dato;

            cabecera = reader.ReadInt64();
            sig_ent = cabecera;

            if (cabecera != -1)
            {
                while (aux != -1)
                {
                    reader.BaseStream.Seek(sig_ent, SeekOrigin.Begin);
                    reader.ReadString();
                    sig_a = atrib = reader.ReadInt64();
                    dato = reader.ReadInt64();
                    reader.ReadInt64();
                    aux = sig_ent = reader.ReadInt64();
                    Ult_pos = reader.BaseStream.Position;
                    if (PosF < Ult_pos)
                        PosF = Ult_pos;
                    if (dato != -1)
                    {

                    }
                    if (atrib != -1)
                    {
                        while (auxAtrib != -1)
                        {
                            reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                            reader.ReadString();//reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            auxAtrib = sig_a = reader.ReadInt64();
                            reader.ReadBoolean();
                            Ult_pos = reader.BaseStream.Position;
                            if (PosF < Ult_pos)
                                PosF = Ult_pos;
                        }
                        auxAtrib = 0;
                    }
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();
            return PosF;
        }
        private void AltaE_Click()                                    //********** Alta Entidad*************//
        {
            ///Alta de Entidad
            ///se busca si el archivo contiene entidades de no ser asi se actualiza la cabecera en caso de que contenga se recorre hasta el final de las entidades
            long FinalArch;
            FinalArch = BuscaFinal();
            FileStream fichero = File.Open(narch, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);
            long cab = 0;
            string Nombre;
            cab = reader.ReadInt64();
            if (cab == -1)
            {
                writer.BaseStream.Seek(0, SeekOrigin.Begin);
                cab = 8;
                writer.Write(cab);
                Nombre = Archivo_text.Text.ToString();
                Entidad nueva = new Entidad(Nombre.PadRight(29, ' '));
                writer.Write(nueva.Nombre_Entidad);
                writer.Write(nueva.Atributo);
                writer.Write(nueva.Datos);
                writer.Write(cab);
                writer.Write(nueva.Sig_Entidad);
                writer.Close();
                reader.Close();
                fichero.Close();
            }
            else
            {
                long aux = cab;
                long sigent = 0;
                long pos = -1;
                string nombre_entidad;

                Nombre = Archivo_text.Text;
                while (aux != -1)
                {
                    reader.BaseStream.Seek(aux, SeekOrigin.Begin);
                    nombre_entidad = reader.ReadString();
                    if (nombre_entidad.CompareTo(Nombre.PadRight(29, ' ')) == 0)
                    {
                        MessageBox.Show("Ya exixte una entidad con este nombre, ingresa otro diferente.");
                        writer.Close();
                        reader.Close();
                        fichero.Close();
                        return;
                    }
                    reader.ReadInt64();
                    reader.ReadInt64();
                    reader.ReadInt64();
                    pos = reader.BaseStream.Position;
                    aux = reader.ReadInt64();
                }
                reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                writer.Write(FinalArch);
                reader.BaseStream.Seek(FinalArch, SeekOrigin.Begin);
                Entidad nueva = new Entidad(Nombre.PadRight(29, ' '));
                writer.Write(nueva.Nombre_Entidad);
                writer.Write(nueva.Atributo);
                writer.Write(nueva.Datos);
                writer.Write(FinalArch);
                writer.Write(nueva.Sig_Entidad);
                writer.Close();
                reader.Close();
                fichero.Close();
            }
        }
        private void IniciaCabecera(string nombrearch)                                 //********** Inicia la cabecera -1*****//
        {
            ///Inicilizacion de la cabecera escribiendo un -1 al inicio del archivo
            long cab = -1;
            FileStream stream = new FileStream(nombrearch, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(stream);

            writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.Write(cab);

            writer.Close();
            stream.Close();
        }

        private void FEntidad_Load(object sender, EventArgs e)
        {

        }
    }
}
