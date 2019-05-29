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
        string foldername = "", rutaarch = "";
        string datoborrado = "", tipodatoborrado = "";

        List<Atributo> ListaAtributos = new List<Atributo>();
        List<Atributo> ListaAuxAtrib = new List<Atributo>();
        List<Atributo> AtribSegtabla = new List<Atributo>();//= CargaAtributos(PosEnt);
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
            dataGridView_Imp_Reg.Visible = true;
            button1.Visible = true;
            SQL.Visible = true;
            textSQL.Visible = true;
            Compilar.Visible = true;
            bTuplas.Visible = true;
            label_NombreTabla.Visible = true;
            dataSQL.Visible = true;
            label_NombreTabla.Text = comboBox_CargaT.Text;
            string Nombre = comboBox_CargaT.Text.ToString();
            long PosEnt = BuscaEntidad(Nombre);
            try
            {
                ImprimeAtributos(PosEnt);
                comboBox_Reg_Ent_Imprime_SelectedIndexChanged();
            }
            catch { }
        }
        private void ImprimeAtributos(long posEntidad)
        {
            ///se pasa la posicion de la entidad y se imprimen todos sus atributos en combobox
            nombrearch = ruta + "\\" + comboBox_CargaT.Text.ToString() + ".bin";
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, sig_a = 0, TamDato;
            string Nom;
            char tipo;
            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            comboBox_Registro_Atributo.Items.Clear();
            comboBox_Dato_Registro.Items.Clear();
            comboBox_Reg_tam.Items.Clear();
            //dataGridTablaAux.Columns.Clear();
            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    Nom = reader.ReadString();
                    tipo = reader.ReadChar();
                    TamDato = reader.ReadInt64();
                    reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    reader.ReadBoolean();
                    comboBox_Registro_Atributo.Items.Add(Nom);//Entidad_Registro
                    if (tipo.CompareTo('S') == 0)
                        TamDato++;
                    //dataGridTablaAux.Rows.Add(Nombre, tipo,TamDato);
                    comboBox_Dato_Registro.Items.Add(tipo);
                    comboBox_Reg_tam.Items.Add(TamDato);
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();
            IgualaElemntos();
        }
        private void IgualaElemntos()
        {
            ///Los combobox anteriormente llenados con los datos de los atributos se copian a una tabla
            dataGrid_Registro.Rows.Clear();
            int NumElemntos = 0;
            NumElemntos = comboBox_Registro_Atributo.Items.Count;

            for (int i = 0; i < NumElemntos; i++)
            {
                if (Int32.Parse(comboBox_Reg_tam.Items[i].ToString()) > 8)
                    dataGrid_Registro.Rows.Add(comboBox_Registro_Atributo.Items[i].ToString(), comboBox_Dato_Registro.Items[i].ToString(), Convert.ToUInt64(comboBox_Reg_tam.Items[i].ToString()));
                else
                    dataGrid_Registro.Rows.Add(comboBox_Registro_Atributo.Items[i].ToString(), comboBox_Dato_Registro.Items[i].ToString(), comboBox_Reg_tam.Items[i].ToString());
            }

            comboBox_Dato_Registro.Items.Clear();
        }
        private long BuscaFinRegistros()
        {
            ///Busca el final del archivo y regresa la posicion
            long pos;
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);

            pos = reader.BaseStream.Seek(0, SeekOrigin.End);

            writer.Close();
            reader.Close();
            fichero.Close();

            return pos;
        }
        private void comboBox_Reg_Ent_Imprime_SelectedIndexChanged()
        {
            ///Segun la entidad seleccionada se imprimieran sus registros
            Int32 i;
            int datoi = 0, Clave, r = 0, col = 0, ren = 0, cantidadAtributos;
            long tamString, posantreg = 0;
            long datol = -1, FinArch, PosEnt, ApDatos, ApPosDatos, fin = -1, SigReg = 0;
            char datoc = 'c';
            float datof = 0;
            string datos = "";
            String tipo, dato, NombreE;
            DataGridViewCell dgc;
            FinArch = BuscaFinRegistros();
            NombreE = comboBox_CargaT.Text.ToString();
            PosEnt = BuscaEntidad(NombreE);
            Clave = BuscaAtribClave(PosEnt);
            //dataGridView_Imp_Reg dataGridView_Imp_Reg.Columns.Clear();
            int cantidad = 0;
            cantidad = CantidadAtrib(PosEnt);
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);
            reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
            reader.ReadString();
            reader.ReadUInt64();
            ApPosDatos = reader.BaseStream.Position;
            ApDatos = reader.ReadInt64();
            dataGridView_Imp_Reg.Rows.Clear();
            dataGridView_Imp_Reg.Columns.Clear();
            dataGridView_Imp_Reg.Columns.Add(ListaAuxAtrib[0].Nombre_Atributo, ListaAuxAtrib[0].Nombre_Atributo);
            dataGridView_Imp_Reg.Rows.Add();
            if (cantidad > 1)
            {
                dataGridView_Imp_Reg.Rows.Clear();
                dataGridView_Imp_Reg.Columns.Clear();
                for (int j = 0; j < cantidad; j++)
                {
                    dataGridView_Imp_Reg.Columns.Add(ListaAuxAtrib[j].Nombre_Atributo, ListaAuxAtrib[j].Nombre_Atributo);
                }
            }
            if (ApDatos != -1)
            {
                SigReg = ApDatos;
                while (SigReg != fin)
                {
                    dataGridView_Imp_Reg.Rows.Add();
                    reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                    r = 0;
                    col = 0;
                    for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                    {
                        dgc = dataGrid_Registro.Rows[i].Cells[1];
                        tipo = ((String)dgc.Value);
                        if (tipo.CompareTo("I") == 0)
                        {
                            datoi = reader.ReadInt32();
                            r = 1;
                        }
                        if (tipo.CompareTo("L") == 0)
                        {
                            datol = reader.ReadInt64();
                            r = 2;
                        }
                        if (tipo.CompareTo("C") == 0)
                        {
                            datoc = reader.ReadChar();
                            r = 3;
                        }
                        if (tipo.CompareTo("F") == 0)
                        {
                            datof = reader.ReadSingle();
                            r = 4;
                        }
                        if (tipo.CompareTo("S") == 0)
                        {
                            datos = reader.ReadString();
                            r = 5;
                        }
                        switch (r)
                        {
                            case 1:
                                dataGridView_Imp_Reg.Rows[ren].Cells[col].Value = datoi;
                                col++;
                                break;
                            case 2:
                                dataGridView_Imp_Reg.Rows[ren].Cells[col].Value = datol;
                                col++;
                                break;
                            case 3:
                                dataGridView_Imp_Reg.Rows[ren].Cells[col].Value = datoc;
                                col++;
                                break;
                            case 4:
                                dataGridView_Imp_Reg.Rows[ren].Cells[col].Value = datof;
                                col++;
                                break;
                            case 5:
                                dataGridView_Imp_Reg.Rows[ren].Cells[col].Value = datos;
                                col++;
                                break;
                        }
                        r = 0;
                    }
                    posantreg = reader.BaseStream.Position;
                    SigReg = reader.ReadInt64();
                    col++;
                    ren++;
                }
            }
            writer.Close();
            reader.Close();
            fichero.Close();
        }
        private void bTuplas_Click(object sender, EventArgs e)
        {
            Tuplas Atrib = new Tuplas(comboBox_CargaT.Text, ruta, auxt);
            long PosEnt =Atrib.BuscaEntidad(comboBox_CargaT.Text.ToString());
            Atrib.ImprimeAtributos(PosEnt);
            Atrib.Show();
        }
        private void Compilar_Click(object sender, EventArgs e)
        {
            String[] sep = { " " };
            String[] coma = { "," };
            string s = textSQL.Text.ToString();
            string[] sent = s.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sent.Length; i++)
            {
                if (i == 0)
                {
                    if (sent[i].CompareTo("select") == 0 || sent[i].CompareTo("SELECT") == 0)
                    {
                        i++;
                        if (i == 1)
                        {
                            if (sent[i].CompareTo("*") == 0)
                            {
                                i++;
                                if (i == 2)
                                {
                                    if (sent[i].CompareTo("from") == 0 || sent[i].CompareTo("FROM") == 0)
                                    {
                                        //string puntoycomaaux = puntoycoma;
                                        string puntoycoma = sent[i + 1];
                                        if (puntoycoma[puntoycoma.Length - 1].CompareTo(';') == 0)
                                        {
                                            string tabla = "";
                                            for (int r = 0; r < puntoycoma.Length - 1; r++)
                                                tabla += puntoycoma[r];
                                            bool existe_tabla = false;
                                            string[] auxt = new string[0];
                                            for (int j = 0; j < comboBox_CargaT.Items.Count; i++)
                                            {
                                                if (comboBox_CargaT.Items[j].ToString().CompareTo(tabla) == 0)
                                                {
                                                    existe_tabla = true;
                                                    j = comboBox_CargaT.Items.Count + 1;
                                                }
                                            }
                                            if (existe_tabla == true)
                                            {
                                                string[] nueva = new string[3];
                                                ImprimeSQL(tabla, auxt, nueva);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            string atrib_aux = sent[i-1];
                                            if (atrib_aux.CompareTo("*") != 0)
                                            {
                                                String[] sepcoma = { "," };
                                                string[] atributos = atrib_aux.Split(sepcoma, StringSplitOptions.RemoveEmptyEntries);
                                                puntoycoma = sent[i + 2];
                                                if (puntoycoma[puntoycoma.Length - 1].CompareTo(';') == 0)
                                                {
                                                    string tabla = "";
                                                    for (int r = 0; r < puntoycoma.Length - 1; r++)
                                                        tabla += puntoycoma[r];
                                                    bool existe_tabla = false;
                                                    string[] auxt = new string[0];
                                                    for (int j = 0; j < comboBox_CargaT.Items.Count; j++)
                                                    {
                                                        if (comboBox_CargaT.Items[j].ToString().CompareTo(tabla) == 0)
                                                        {
                                                            existe_tabla = true;
                                                            j = comboBox_CargaT.Items.Count + 1;
                                                        }
                                                    }
                                                    if (existe_tabla == true)
                                                    {
                                                        string[] nueva = new string[3];
                                                        ImprimeSQL(tabla, atributos, nueva);
                                                        return;
                                                    }
                                                }
                                            }
                                            if (sent[i + 2].CompareTo("WHERE") == 0 || sent[i + 2].CompareTo("where") == 0)
                                            {
                                                i = i + 2;
                                                string tabla = puntoycoma;//sent[3];
                                                i = i + 2;
                                                bool compara = false;
                                                string[] ifcompa = new string[3];
                                                string ultimacom;
                                                for (int k = i; k < sent.Length; k++)
                                                {
                                                    string comparacion = sent[k];
                                                    ifcompa[0] = sent[k - 1];
                                                    if (comparacion.CompareTo("=") == 0 || comparacion.CompareTo("<") == 0 || comparacion.CompareTo(">") == 0
                                                        || comparacion.CompareTo(">=") == 0 || comparacion.CompareTo("<=") == 0 || comparacion.CompareTo("<>") == 0)
                                                    {
                                                        compara = true;
                                                        ifcompa[1] = sent[k];
                                                        ultimacom = sent[k + 1];
                                                        ifcompa[2] = ultimacom.Substring(0, ultimacom.Length - 1);
                                                        k = sent.Length + 1;
                                                    }

                                                }
                                                string puntoycom = sent[sent.Length - 1];
                                                if (puntoycom[puntoycom.Length - 1].CompareTo(';') == 0 && compara == true)
                                                {
                                                    string[] auxt = new string[0];
                                                    ImprimeSQL(tabla, auxt, ifcompa);
                                                    return;
                                                }
                                                else
                                                    MessageBox.Show("Error en la sentencia, falta ;");
                                            }
                                            else
                                                MessageBox.Show("Error en la sentencia, falta ;");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (sent[i + 1].CompareTo("FROM") == 0 || sent[i + 1].CompareTo("From") == 0)
                                {
                                    string atrib_aux = sent[i];
                                    String[] sepcoma = { "," };
                                    string[] atributos = atrib_aux.Split(sepcoma, StringSplitOptions.RemoveEmptyEntries);
                                    string puntoycoma = sent[i + 2];
                                    if (puntoycoma[puntoycoma.Length - 1].CompareTo(';') == 0)
                                    {
                                        string tabla = "";
                                        for (int r = 0; r < puntoycoma.Length - 1; r++)
                                            tabla += puntoycoma[r];
                                        bool existe_tabla = false;
                                        string[] auxt = new string[0];
                                        for (int j = 0; j < comboBox_CargaT.Items.Count; j++)
                                        {
                                            if (comboBox_CargaT.Items[j].ToString().CompareTo(tabla) == 0)
                                            {
                                                existe_tabla = true;
                                                j = comboBox_CargaT.Items.Count + 1;
                                            }
                                        }
                                        if (existe_tabla == true)
                                        {
                                            string[] nueva = new string[3];
                                            ImprimeSQL(tabla, atributos, nueva);
                                            return;
                                        }
                                    }
                                    if (sent[i + 3].CompareTo("WHERE") == 0 || sent[i + 3].CompareTo("where") == 0)
                                    {
                                        i = i + 2;
                                        string tabla = sent[i];
                                        i = i + 2;
                                        bool compara = false;
                                        string[] ifcompa = new string[3];
                                        string ultimacom;
                                        for (int k = i; k < sent.Length; k++)
                                        {
                                            string comparacion = sent[k];
                                            ifcompa[0] = sent[k - 1];
                                            if (comparacion.CompareTo("=") == 0 || comparacion.CompareTo("<") == 0 || comparacion.CompareTo(">") == 0
                                                || comparacion.CompareTo(">=") == 0 || comparacion.CompareTo("<=") == 0)
                                            {
                                                compara = true;
                                                ifcompa[1] = sent[k];
                                                ultimacom = sent[k + 1];
                                                ifcompa[2] = ultimacom.Substring(0, ultimacom.Length - 1);
                                                k = sent.Length + 1;
                                            }

                                        }
                                        string puntoycom = sent[sent.Length - 1];
                                        if (puntoycom[puntoycom.Length - 1].CompareTo(';') == 0 && compara == true)
                                        {
                                            ImprimeSQL(tabla, atributos, ifcompa);
                                            return;
                                        }
                                        else
                                            MessageBox.Show("Error en la sentencia, falta ;");
                                    }
                                    else
                                        MessageBox.Show("Error en la sentencia, falta ;");
                                }
                                /* else
                                 {
                                     string[] atributos = new string[sent.Length];
                                     int c = 0;
                                     bool comas = false;
                                     while (sent[i].CompareTo("From") != 0 || sent[i].CompareTo("From") != 0)
                                     {
                                         atributos[c] = sent[i];
                                         if (atributos[atributos[c].Length].CompareTo(",") == 0)
                                             comas = true;
                                         c++;
                                         i++;
                                     }
                                 }*/
                            }
                        }
                    }
                    else
                        MessageBox.Show("Sentencia incorrecta! ");
                }
            }

        }
        private long BuscaEntidad(string NombreB)
        {
            string arch = ruta + "\\" + NombreB + ".bin";
            NombreB = NombreB.PadRight(29, ' ');
            ///Se pasa el nombre de la entidad a buscar y regresa la posicion de la entidad
            FileStream fichero = File.Open(arch, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);

            long PosE = 0, aux = 0, p1, p2, p3, p4 = -1, cab;
            string Nombre;
            cab = reader.ReadInt64();
            p4 = cab;
            while (aux != -1)
            {
                reader.BaseStream.Seek(p4, SeekOrigin.Begin);
                PosE = reader.BaseStream.Position;
                Nombre = reader.ReadString();
                if ((Nombre.CompareTo(NombreB)) == 0)
                {
                    p1 = reader.ReadInt64();
                    p2 = reader.ReadInt64();
                    p3 = reader.ReadInt64();
                    p4 = reader.ReadInt64();
                    aux = -1;
                }
                else
                {
                    p1 = reader.ReadInt64();
                    p2 = reader.ReadInt64();
                    p3 = reader.ReadInt64();
                    p4 = reader.ReadInt64();
                    aux = p4;
                }
            }
            writer.Close();
            reader.Close();
            fichero.Close();
            return PosE;
        }
        private int BuscaAtribClave(long PosEntidad)
        {
            ///Busca el lugar dentro de los atributos de la clave primaria
            int NumEnt = 1;
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0, pos2;
            string Nombre, NombreNuevo;
            bool clave;
            reader.BaseStream.Seek(PosEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    Nombre = reader.ReadString();
                    reader.ReadChar();
                    reader.ReadInt64();
                    PosF = reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    clave = reader.ReadBoolean();
                    pos2 = reader.BaseStream.Position;
                    if (clave == true)
                    {
                        reader.Close();
                        writer.Close();
                        fichero.Close();
                        return NumEnt;
                    }
                    NumEnt++;
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();
            return NumEnt;
        }
        private int CantidadAtrib(long posEntidad)
        {
            ///Se contabilizan todos los atributos que contiene la entidad apartir de la posicion que se envia
            int cantidad = 0;
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0, pos2;
            string Nombre;
            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            ListaAtributos.Clear();
            ListaAuxAtrib.Clear();

            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    string nombreA;
                    char tipo;
                    long tam;
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    PosF = reader.BaseStream.Position;
                    nombreA = Nombre = reader.ReadString();
                    tipo = reader.ReadChar();
                    tam = reader.ReadInt64();
                    PosF = reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    reader.ReadBoolean();
                    pos2 = reader.BaseStream.Position;
                    cantidad++;
                    Atributo aux = new Atributo(nombreA, tipo, tam, 0, false);
                    ListaAtributos.Add(aux);
                    ListaAuxAtrib.Add(aux);
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();
            return cantidad;
        }
        private void ImprimeSQL(string tabla, string[] atributo, string[] comparacion)
        {
            ///Segun la entidad seleccionada se imprimieran sus registros
            Int32 i;
            int datoi = 0, Clave, r = 0, col = 0, ren = 0, cantidadAtributos;
            long tamString, posantreg = 0;
            long datol = -1, FinArch, PosEnt, ApDatos, ApPosDatos, fin = -1, SigReg = 0;
            char datoc = 'c';
            float datof = 0;
            string datos = "";
            bool tieneAtrib = false, tieneCompara = false;
            for (int x = 0; x < atributo.Length; x++)
                if (atributo[x] != null)
                {
                    tieneAtrib = true;
                    x = atributo.Length + 1;
                }
            for (int x = 0; x < comparacion.Length; x++)
                if (comparacion[x] != null)
                {
                    tieneCompara = true;
                    x = comparacion.Length + 1;
                }
            String tipo, dato, NombreE;
            DataGridViewCell dgc;
            nombrearch = ruta + "\\" + tabla + ".bin";
            NombreE = tabla;
            PosEnt = BuscaEntidad(NombreE);
            Clave = BuscaAtribClave(PosEnt);
            //dataGridView_Imp_Reg dataGridView_Imp_Reg.Columns.Clear();
            int cantidad = 0;
            cantidad = CantidadAtrib(PosEnt);
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);
            FinArch = reader.BaseStream.Seek(0, SeekOrigin.End);
            reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
            reader.ReadString();
            reader.ReadUInt64();
            ApPosDatos = reader.BaseStream.Position;
            ApDatos = reader.ReadInt64();
            dataSQL.Rows.Clear();
            dataSQL.Columns.Clear();
            if (tieneAtrib == false && tieneCompara == false)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    Atributo hed;
                    hed = ListaAtributos[j];
                    dataSQL.Columns.Add(hed.Nombre_Atributo.Replace(" ", ""), hed.Nombre_Atributo.Replace(" ", ""));
                }
                if (ApDatos != -1)
                {
                    SigReg = ApDatos;
                    while (SigReg != fin)
                    {
                        dataSQL.Rows.Add();
                        reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                        r = 0;
                        col = 0;
                        for (i = 0; i < cantidad; i++)
                        {
                            Atributo at;
                            at = ListaAtributos[col];
                            tipo = at.Tipo.ToString();
                            if (tipo.CompareTo("I") == 0)
                            {
                                datoi = reader.ReadInt32();
                                r = 1;
                            }
                            if (tipo.CompareTo("L") == 0)
                            {
                                datol = reader.ReadInt64();
                                r = 2;
                            }
                            if (tipo.CompareTo("C") == 0)
                            {
                                datoc = reader.ReadChar();
                                r = 3;
                            }
                            if (tipo.CompareTo("F") == 0)
                            {
                                datof = reader.ReadSingle();
                                r = 4;
                            }
                            if (tipo.CompareTo("S") == 0)
                            {
                                datos = reader.ReadString();
                                r = 5;
                            }
                            switch (r)
                            {
                                case 1:
                                    dataSQL.Rows[ren].Cells[col].Value = datoi;
                                    col++;
                                    break;
                                case 2:
                                    dataSQL.Rows[ren].Cells[col].Value = datol;
                                    col++;
                                    break;
                                case 3:
                                    dataSQL.Rows[ren].Cells[col].Value = datoc;
                                    col++;
                                    break;
                                case 4:
                                    dataSQL.Rows[ren].Cells[col].Value = datof;
                                    col++;
                                    break;
                                case 5:
                                    dataSQL.Rows[ren].Cells[col].Value = datos;
                                    col++;
                                    break;
                            }
                            r = 0;
                        }
                        posantreg = reader.BaseStream.Position;
                        SigReg = reader.ReadInt64();
                        col++;
                        ren++;
                    }
                }
            }
            if (tieneAtrib == true && tieneCompara == false)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    Atributo hed;
                    hed = ListaAtributos[j];
                    dataSQL.Columns.Add(hed.Nombre_Atributo.Replace(" ", ""), hed.Nombre_Atributo.Replace(" ", ""));
                }
                bool contain = false;
                if (ApDatos != -1)
                {
                    SigReg = ApDatos;
                    while (SigReg != fin)
                    {
                        dataSQL.Rows.Add();
                        reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                        r = 0;
                        col = 0;
                        for (i = 0; i < cantidad; i++)
                        {
                            Atributo at;
                            at = ListaAtributos[col];
                            tipo = at.Tipo.ToString();
                            if (tipo.CompareTo("I") == 0)
                            {
                                datoi = reader.ReadInt32();
                                r = 1;
                            }
                            if (tipo.CompareTo("L") == 0)
                            {
                                datol = reader.ReadInt64();
                                r = 2;
                            }
                            if (tipo.CompareTo("C") == 0)
                            {
                                datoc = reader.ReadChar();
                                r = 3;
                            }
                            if (tipo.CompareTo("F") == 0)
                            {
                                datof = reader.ReadSingle();
                                r = 4;
                            }
                            if (tipo.CompareTo("S") == 0)
                            {
                                datos = reader.ReadString();
                                r = 5;
                            }
                            switch (r)
                            {
                                case 1:
                                    dataSQL.Rows[ren].Cells[col].Value = datoi;
                                    col++;
                                    break;
                                case 2:
                                    dataSQL.Rows[ren].Cells[col].Value = datol;
                                    col++;
                                    break;
                                case 3:
                                    dataSQL.Rows[ren].Cells[col].Value = datoc;
                                    col++;
                                    break;
                                case 4:
                                    dataSQL.Rows[ren].Cells[col].Value = datof;
                                    col++;
                                    break;
                                case 5:
                                    dataSQL.Rows[ren].Cells[col].Value = datos;
                                    col++;
                                    break;
                            }
                            r = 0;
                        }
                        posantreg = reader.BaseStream.Position;
                        SigReg = reader.ReadInt64();
                        col++;
                        ren++;
                    }
                }
                int borrar = 0;
                List<int> columnsb = new List<int>();
                foreach (DataGridViewColumn columna in dataSQL.Columns)
                {

                    if (atributo.Contains(columna.HeaderText) != true)
                        columnsb.Add(borrar);
                    borrar++;
                }
                foreach (int eliminar in columnsb)
                {
                    dataSQL.Columns.RemoveAt(Convert.ToInt32(eliminar));
                }

            }
            if (tieneAtrib == true && tieneCompara == true)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    Atributo hed;
                    hed = ListaAtributos[j];
                    dataSQL.Columns.Add(hed.Nombre_Atributo.Replace(" ", ""), hed.Nombre_Atributo.Replace(" ", ""));
                }
                bool contain = false;
                if (ApDatos != -1)
                {
                    SigReg = ApDatos;
                    while (SigReg != fin)
                    {
                        dataSQL.Rows.Add();
                        reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                        r = 0;
                        col = 0;
                        for (i = 0; i < cantidad; i++)
                        {
                            Atributo at;
                            at = ListaAtributos[col];
                            tipo = at.Tipo.ToString();
                            if (tipo.CompareTo("I") == 0)
                            {
                                datoi = reader.ReadInt32();
                                r = 1;
                            }
                            if (tipo.CompareTo("L") == 0)
                            {
                                datol = reader.ReadInt64();
                                r = 2;
                            }
                            if (tipo.CompareTo("C") == 0)
                            {
                                datoc = reader.ReadChar();
                                r = 3;
                            }
                            if (tipo.CompareTo("F") == 0)
                            {
                                datof = reader.ReadSingle();
                                r = 4;
                            }
                            if (tipo.CompareTo("S") == 0)
                            {
                                datos = reader.ReadString();
                                r = 5;
                            }
                            switch (r)
                            {
                                case 1:
                                    dataSQL.Rows[ren].Cells[col].Value = datoi;
                                    col++;
                                    break;
                                case 2:
                                    dataSQL.Rows[ren].Cells[col].Value = datol;
                                    col++;
                                    break;
                                case 3:
                                    dataSQL.Rows[ren].Cells[col].Value = datoc;
                                    col++;
                                    break;
                                case 4:
                                    dataSQL.Rows[ren].Cells[col].Value = datof;
                                    col++;
                                    break;
                                case 5:
                                    dataSQL.Rows[ren].Cells[col].Value = datos;
                                    col++;
                                    break;
                            }
                            r = 0;
                        }
                        posantreg = reader.BaseStream.Position;
                        SigReg = reader.ReadInt64();
                        col++;
                        ren++;
                    }
                }
                int borrar = 0;
                List<int> columnsb = new List<int>();
                foreach (DataGridViewColumn columna in dataSQL.Columns)
                {

                    if (atributo.Contains(columna.HeaderText) != true)
                        columnsb.Add(borrar);
                    borrar++;
                }
                foreach (int eliminar in columnsb)
                {
                    dataSQL.Columns.RemoveAt(Convert.ToInt32(eliminar));
                    ListaAtributos.RemoveAt(Convert.ToInt32(eliminar));
                }


                int borrarrenglon = 0;
                int column = 0;
                List<int> rengb = new List<int>();//                                  dataSQL.Rows[ren].Cells[col].Value = datos;
                foreach (DataGridViewColumn columna in dataSQL.Columns)
                {
                    if (comparacion[0].CompareTo(columna.HeaderText) == 0)
                        column = borrarrenglon;
                    borrarrenglon++;
                }
                Atributo atri;
                for (int z = 0; z < dataSQL.Rows.Count - 1; z++)
                {
                    atri = ListaAtributos[0];
                    if (comparacion[1].CompareTo("<") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result < 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    if (comparacion[1].CompareTo(">") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp > cp2)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result > 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 < cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    if (comparacion[1].CompareTo("=") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 != cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result != 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 != cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                }
                foreach (int eliminar in rengb)
                {
                    dataSQL.Rows.RemoveAt(Convert.ToInt32(eliminar));
                }
            }
            if (tieneAtrib == false && tieneCompara == true)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    Atributo hed;
                    hed = ListaAtributos[j];
                    dataSQL.Columns.Add(hed.Nombre_Atributo.Replace(" ", ""), hed.Nombre_Atributo.Replace(" ", ""));
                }
                if (ApDatos != -1)
                {
                    SigReg = ApDatos;
                    while (SigReg != fin)
                    {
                        dataSQL.Rows.Add();
                        reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                        r = 0;
                        col = 0;
                        for (i = 0; i < cantidad; i++)
                        {
                            Atributo at;
                            at = ListaAtributos[col];
                            tipo = at.Tipo.ToString();
                            if (tipo.CompareTo("I") == 0)
                            {
                                datoi = reader.ReadInt32();
                                r = 1;
                            }
                            if (tipo.CompareTo("L") == 0)
                            {
                                datol = reader.ReadInt64();
                                r = 2;
                            }
                            if (tipo.CompareTo("C") == 0)
                            {
                                datoc = reader.ReadChar();
                                r = 3;
                            }
                            if (tipo.CompareTo("F") == 0)
                            {
                                datof = reader.ReadSingle();
                                r = 4;
                            }
                            if (tipo.CompareTo("S") == 0)
                            {
                                datos = reader.ReadString();
                                r = 5;
                            }
                            switch (r)
                            {
                                case 1:
                                    dataSQL.Rows[ren].Cells[col].Value = datoi;
                                    col++;
                                    break;
                                case 2:
                                    dataSQL.Rows[ren].Cells[col].Value = datol;
                                    col++;
                                    break;
                                case 3:
                                    dataSQL.Rows[ren].Cells[col].Value = datoc;
                                    col++;
                                    break;
                                case 4:
                                    dataSQL.Rows[ren].Cells[col].Value = datof;
                                    col++;
                                    break;
                                case 5:
                                    dataSQL.Rows[ren].Cells[col].Value = datos;
                                    col++;
                                    break;
                            }
                            r = 0;
                        }
                        posantreg = reader.BaseStream.Position;
                        SigReg = reader.ReadInt64();
                        col++;
                        ren++;
                    }
                }
               
                int borrarrenglon = 0;
                int column = 0;
                List<int> rengb = new List<int>();//                                  dataSQL.Rows[ren].Cells[col].Value = datos;
                foreach (DataGridViewColumn columna in dataSQL.Columns)
                {
                    if (comparacion[0].CompareTo(columna.HeaderText) == 0)
                        column = borrarrenglon;
                    borrarrenglon++;
                }
                Atributo atri;
                for (int z = 0; z < dataSQL.Rows.Count - 1; z++)
                {
                    atri = ListaAtributos[0];
                    if (comparacion[1].CompareTo("<") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result < 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    if (comparacion[1].CompareTo(">") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp >= cp2)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result > 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 < cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    if (comparacion[1].CompareTo("=") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 != cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result != 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 != cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    //nuevos
                    if (comparacion[1].CompareTo("<>") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 == cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result == 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 == cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    if (comparacion[1].CompareTo("<=") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result < 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                    if (comparacion[1].CompareTo(">=") == 0)
                    {
                        if (atri.Tipo.ToString().CompareTo("I") == 0)
                        {
                            try
                            {
                                int cp = Convert.ToInt32(comparacion[2]), cp2 = Convert.ToInt32(dataSQL.Rows[z].Cells[column].Value);
                                if (cp > cp2)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("S") == 0)
                        {
                            try
                            {

                                string cp = comparacion[2], cp2 = dataSQL.Rows[z].Cells[column].Value.ToString();
                                int result = String.CompareOrdinal(cp2, cp);
                                if (result > 0)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                        if (atri.Tipo.ToString().CompareTo("F") == 0)
                        {
                            try
                            {
                                float cp = System.Convert.ToSingle(comparacion[2]), cp2 = System.Convert.ToSingle(dataSQL.Rows[z].Cells[column].Value);
                                if (cp2 > cp)
                                {
                                    rengb.Add(z);
                                }
                            }
                            catch { }
                        }
                    }
                }
                int NUMRENG = dataSQL.Rows.Count;
                rengb.Sort();
                rengb.Reverse();
                foreach (int eliminar in rengb)
                {
                    try
                    {
                        this.dataSQL.Rows.RemoveAt(eliminar);
                    }
                    catch {
                        //dataSQL.Rows.Remove(dataSQL.Rows[eliminar]);
                        /*int count = 0;
                        foreach (DataGridViewRow row in dataSQL.Rows)
                        {
                            if (count == eliminar)
                                dataSQL.Rows.Remove(row);
                            else
                                break;
                        }*/
                    }
                }
            }
            writer.Close();
            reader.Close();
            fichero.Close();
            
        }
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
                    //bTuplas.Visible = true;
                    CargaTablas();
                }
            }
        }
    }
}
