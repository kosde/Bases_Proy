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
    public partial class Tuplas : Form
    {
        string nombre, ruta,nombrearch;
        public List<string> LT = new List<string>();
        List<Atributo> AtribSegtabla = new List<Atributo>();
        string auxf, tipodatoborrado = "", datoborrado = "";
        public Tuplas(string n,string r, List<string> ListaTablas)
        {
            nombre = nombrearch = n;
            ruta = r;
            InitializeComponent();
            nombrearch = ruta + '\\' + nombrearch + ".bin";
            LT = ListaTablas;
        }
        public void ImprimeAtributos(long posEntidad)
        {
            ///se pasa la posicion de la entidad y se imprimen todos sus atributos en combobox
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
        public long BuscaEntidad(string NombreB)
        {
            ///Se pasa el nombre de la entidad a buscar y regresa la posicion de la entidad
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
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
            string Nombre;
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
        private List<Atributo> CargaAtributos(long posEntidad)//CargaAtributos//
        {
            ///Busca si existe una clave primearia apartir de la posicion de la entidad
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            List<Atributo> AtribTabla = new List<Atributo>();
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
                    Atributo res = new Atributo(reader.ReadString(), reader.ReadChar(), reader.ReadInt64(),
                                                reader.ReadInt64(), auxAtrib = sig_a = reader.ReadInt64(), reader.ReadBoolean(), reader.ReadString());
                    AtribTabla.Add(res);
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();

            return AtribTabla;
        }
        private void ImprimeAtributosTablaAux(long posEntidad, string nombrearch)
        {
            ///se pasa la posicion de la entidad y se imprimen todos sus atributos en combobox
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, sig_a = 0, TamDato;
            string Nom;
            char tipo;
            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            dataGridTablaAux.Rows.Clear();
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
                    dataGridTablaAux.Rows.Add(Nom, tipo, TamDato);
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();
        }
        private bool checarinsercionllavef(string llavef, int llave)////checarinsercionllavef(checar.llavef);
        {
            ///Busca si existe una clave primearia apartir de la posicion de la entidad
            llavef = llavef.Replace(" ", "");
            string auxruta = ruta + "\\" + llavef + ".bin";
            auxf = auxruta;

            Int32 i;
            int datoi, Clave;
            bool Claveb = false, insertar = true;
            long tamString, posantreg = 0;
            long datol, FinArch, PosEnt, ApDatos, ApPosDatos, SigReg = 0, fin = -1;
            char datoc;
            float datof;
            String tipo, dato, NombreE;
            DataGridViewCell dgc;
            List<Atributo> AtribTabla = new List<Atributo>();

            NombreE = llavef;
            PosEnt = BuscaEntidad(NombreE);
            Clave = BuscaAtribClave(PosEnt);
            Claveb = BuscaClave(PosEnt);
            AtribSegtabla = CargaAtributos(PosEnt);
            //AtribTabla = CargaAtributos(PosEnt); altar
            ImprimeAtributosTablaAux(8, auxruta);
            FileStream fichero = File.Open(auxruta, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);

            FinArch = reader.BaseStream.Seek(0, SeekOrigin.End);
            reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
            reader.ReadString();
            reader.ReadUInt64();
            posantreg = ApPosDatos = reader.BaseStream.Position;
            ApDatos = reader.ReadInt64();

            //No se encuentran datos
            if (ApDatos != -1)
            {
                SigReg = ApDatos;
                SigReg = Busca_RegistroTablaAux(Clave, reader, writer, SigReg, ref posantreg);
                if (SigReg == -1 )
                {
                    //MessageBox.Show("El dato que se intenta agregar no tiene registro en la tabla: " + llavef);
                    writer.Close();
                    reader.Close();
                    fichero.Close();
                    return false;

                }
            }
            else
                insertar = false;
            writer.Close();
            reader.Close();
            fichero.Close();
            return insertar;
        }
        private long Busca_RegistroTablaAux(int Clave, BinaryReader reader, BinaryWriter writer, long SigReg, ref long posantreg)
        {
            ///Se busca un registro y se regresa el siguiente registro y el registro anterior
            Int32 i;
            int datoi;
            long tamString;
            long datol, fin = -1;
            char datoc;
            float datof;
            String tipo, dato;

            int lugar = 1;
            while (SigReg != -1)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                #region "for"
                for (i = 0; i < dataGridTablaAux.Rows.Count - 1; i++)
                {
                    lugar = i + 1;
                    int entero;
                    long largo;
                    char caracter;
                    float flotante;
                    string cadena;
                    DataGridViewCell dgc;
                    dgc = dataGridTablaAux.Rows[i].Cells[1];
                    tipo = dgc.Value.ToString();
                    dgc = dataGridTablaAux.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);
                    dgc = dataGrid_Registro.Rows[Clave].Cells[3];
                    dato = dgc.Value.ToString();
                    if (tipo.CompareTo("I") == 0)
                    {
                        entero = reader.ReadInt32();
                        if (Clave == lugar)
                        {
                            datoi = Int32.Parse(dato);
                            if (datoi < entero)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (datoi == entero)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        largo = reader.ReadInt64();
                        if (Clave == lugar)
                        {
                            datol = Convert.ToInt64(dato);
                            if (datol < largo)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (datol == largo)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        caracter = reader.ReadChar();
                        if (Clave == lugar)
                        {
                            datoc = dato[0];
                            if (caracter > datoc)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (caracter.CompareTo(datoc) == 0)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        flotante = reader.ReadSingle();
                        if (Clave == lugar)
                        {
                            datof = System.Convert.ToSingle(dato);
                            if (flotante > datof)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (flotante == datof)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        cadena = reader.ReadString();

                        if (Clave == lugar)
                        {
                            int result;
                            dato = dato.PadRight(Convert.ToInt32(tamString + fin), ' ');
                            cadena = cadena.Substring(0, Convert.ToInt32(tamString + fin));
                            dato = dato.Substring(0, Convert.ToInt32(tamString + fin));
                            //tamañoCad = cad.Length;
                            //if(tamañoCad>)
                            result = String.CompareOrdinal(cadena, dato);
                            if (result > 0)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (result == 0)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                }
                #endregion
                posantreg = reader.BaseStream.Position;
                SigReg = reader.ReadInt64();
            }
            return SigReg;
        }
        private long Busca_Registro(int Clave, BinaryReader reader, BinaryWriter writer, long SigReg, ref long posantreg)
        {
            ///Se busca un registro y se regresa el siguiente registro y el registro anterior
            Int32 i;
            int datoi;
            long tamString;
            long datol, fin = -1;
            char datoc;
            float datof;
            String tipo, dato;

            int lugar = 1;
            while (SigReg != -1)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                #region "for"
                for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                {
                    lugar = i + 1;
                    int entero;
                    long largo;
                    char caracter;
                    float flotante;
                    string cadena;
                    DataGridViewCell dgc;
                    dgc = dataGrid_Registro.Rows[i].Cells[1];
                    tipo = ((String)dgc.Value);
                    dgc = dataGrid_Registro.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);
                    dgc = dataGrid_Registro.Rows[i].Cells[3];
                    dato = dgc.Value.ToString();
                    if (tipo.CompareTo("I") == 0)
                    {
                        entero = reader.ReadInt32();
                        if (Clave == lugar)
                        {
                            datoi = Int32.Parse(dato);
                            if (datoi < entero)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (datoi == entero)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        largo = reader.ReadInt64();
                        if (Clave == lugar)
                        {
                            datol = Convert.ToInt64(dato);
                            if (datol < largo)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (datol == largo)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        caracter = reader.ReadChar();
                        if (Clave == lugar)
                        {
                            datoc = dato[0];
                            if (caracter > datoc)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (caracter.CompareTo(datoc) == 0)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        flotante = reader.ReadSingle();
                        if (Clave == lugar)
                        {
                            datof = System.Convert.ToSingle(dato);
                            if (flotante > datof)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (flotante == datof)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        cadena = reader.ReadString();

                        if (Clave == lugar)
                        {
                            int result;
                            dato = dato.PadRight(Convert.ToInt32(tamString + fin), ' ');
                            cadena = cadena.Substring(0, Convert.ToInt32(tamString + fin));
                            dato = dato.Substring(0, Convert.ToInt32(tamString + fin));
                            //tamañoCad = cad.Length;
                            //if(tamañoCad>)
                            result = String.CompareOrdinal(cadena, dato);
                            if (result > 0)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (result == 0)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                }
                #endregion
                posantreg = reader.BaseStream.Position;
                SigReg = reader.ReadInt64();
            }
            return SigReg;
        }
        private void BAgregarT_Click(object sender, EventArgs e)
        {
            #region "Declaracion Variables"
            try
            {
                Int32 i;
                int datoi, Clave;
                bool Claveb = false, insertar = false;

                long tamString, posantreg = 0;
                long datol, FinArch, PosEnt, ApDatos, ApPosDatos, Posencontrado = -1, SigReg = 0, fin = -1;
                char datoc;
                float datof;
                String tipo, dato, NombreE;
                DataGridViewCell dgc;
                List<Atributo> AtribTabla = new List<Atributo>();
                FinArch = BuscaFinRegistros();
                NombreE = nombre;//Entidad_Registro.Text.ToString();
                PosEnt = BuscaEntidad(NombreE);
                Clave = BuscaAtribClave(PosEnt);
                Claveb = BuscaClave(PosEnt);
                AtribTabla = CargaAtributos(PosEnt);
                bool[] listaatribpasados = new bool[AtribTabla.Count];
                int contador = 0;
                string checarf;//hed.Nombre_Atributo.Replace(" ", "")
                foreach (Atributo checar in AtribTabla)
                {
                    checarf = checar.llavef;
                    checarf = checarf.Replace(" ", "");
                    if (checarf == "")
                        checarf = "false";
                    if (checar.Clave == true && checarf.CompareTo("false") != 0)
                        listaatribpasados[contador] = true;
                    if (checar.Clave == false && checarf.CompareTo("false") == 0)
                        listaatribpasados[contador] = true;
                    if (checar.Clave  ==  true && checarf.CompareTo("false") == 0)
                        listaatribpasados[contador] = true;
                    if (checar.Clave == false )
                    {
                        if (checarf.CompareTo("false") != 0)
                        {
                            listaatribpasados[contador] = checarinsercionllavef(checar.llavef, contador-1);
                        }
                    }
                    contador++;
                }
                if (Claveb == false)
                {
                    MessageBox.Show("No se puede insertar un registro, se necesita llave primaria");
                    return;
                }
                foreach (bool b in listaatribpasados)
                {
                    if (b == true)
                        insertar = true;
                    if (b == false)
                    {
                        insertar = false;
                        break;
                    }
                }
                FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                BinaryWriter writer = new BinaryWriter(fichero);
                BinaryReader reader = new BinaryReader(fichero);
                #endregion
                if (insertar == true)
                {
                    reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                    reader.ReadString();
                    reader.ReadUInt64();
                    posantreg = ApPosDatos = reader.BaseStream.Position;
                    ApDatos = reader.ReadInt64();
                    //No se encuentran datos
                    #region "No se encuentra Registro"
                    if (ApDatos == -1)
                    {
                        reader.BaseStream.Seek(ApPosDatos, SeekOrigin.Begin);
                        writer.Write(FinArch);
                        reader.BaseStream.Seek(FinArch, SeekOrigin.Begin);
                        for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                        {
                            dgc = dataGrid_Registro.Rows[i].Cells[1];
                            tipo = ((String)dgc.Value);
                            dgc = dataGrid_Registro.Rows[i].Cells[2];
                            tamString = Convert.ToInt64(dgc.Value);//Int32.Parse(TamString);
                            dgc = dataGrid_Registro.Rows[i].Cells[3];
                            dato = ((String)dgc.Value);

                            if (tipo.CompareTo("I") == 0)
                            {
                                datoi = Int32.Parse(dato);
                                writer.Write(datoi);
                            }
                            if (tipo.CompareTo("L") == 0)
                            {
                                datol = Convert.ToInt64(dato);
                                writer.Write(datol);
                            }
                            if (tipo.CompareTo("C") == 0)
                            {
                                datoc = dato[0];
                                writer.Write(datoc);
                            }
                            if (tipo.CompareTo("F") == 0)
                            {
                                datof = System.Convert.ToSingle(dato);
                                writer.Write(datof);
                            }
                            if (tipo.CompareTo("S") == 0)
                            {
                                int tamañoCad, TamTotalS;
                                string cad = dato;
                                TamTotalS = Convert.ToInt32(tamString + fin);     // tamaño maximo que debe de tener la cadena
                                tamañoCad = dato.Length + 1;                      //
                                if (tamañoCad - 1 > TamTotalS)
                                {
                                    MessageBox.Show("El dato es mayor al tamaño permitido, por lo que se recortara la cadena al tamaño asigando");
                                    cad = cad.PadRight(TamTotalS, ' ');
                                    writer.Write(cad.Substring(0, TamTotalS));
                                }
                                else
                                {
                                    cad = cad.PadRight(TamTotalS, ' ');
                                    writer.Write(cad.Substring(0, TamTotalS));
                                    //writer.Write(cad);
                                }
                            }
                        }
                        writer.Write(fin);
                    }
                    #endregion
                    else
                    {
                        SigReg = ApDatos;
                        SigReg = Busca_Registro(Clave, reader, writer, SigReg, ref posantreg);
                        if (SigReg != -999)
                        {
                            reader.BaseStream.Seek(posantreg, SeekOrigin.Begin);
                            writer.Write(FinArch);
                            reader.BaseStream.Seek(FinArch, SeekOrigin.Begin);
                            #region "Escribe datos"

                            for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                            {
                                dgc = dataGrid_Registro.Rows[i].Cells[1];
                                tipo = ((String)dgc.Value);
                                dgc = dataGrid_Registro.Rows[i].Cells[2];
                                tamString = Convert.ToInt64(dgc.Value);//Int32.Parse(TamString);
                                dgc = dataGrid_Registro.Rows[i].Cells[3];
                                dato = dgc.Value.ToString();

                                if (tipo.CompareTo("I") == 0)
                                {
                                    datoi = Int32.Parse(dato);
                                    writer.Write(datoi);
                                }
                                if (tipo.CompareTo("L") == 0)
                                {
                                    datol = Convert.ToInt64(dato);
                                    writer.Write(datol);
                                }
                                if (tipo.CompareTo("C") == 0)
                                {
                                    datoc = dato[0];
                                    writer.Write(datoc);
                                }
                                if (tipo.CompareTo("F") == 0)
                                {
                                    datof = System.Convert.ToSingle(dato);
                                    writer.Write(datof);
                                }
                                if (tipo.CompareTo("S") == 0)
                                {
                                    int tamañoCad, TamTotalS;
                                    string cad = dato;
                                    TamTotalS = Convert.ToInt32(tamString + fin);     // tamaño maximo que debe de tener la cadena
                                    tamañoCad = dato.Length + 1;                      //
                                    if (tamañoCad - 1 > TamTotalS)
                                    {
                                        MessageBox.Show("El dato es mayor al tamaño permitido, por lo que se recortara");
                                        cad = cad.PadRight(TamTotalS, ' ');
                                        writer.Write(cad.Substring(0, TamTotalS));
                                    }
                                    else
                                    {
                                        cad = cad.PadRight(TamTotalS, ' ');
                                        writer.Write(cad.Substring(0, TamTotalS));
                                        // writer.Write(cad);
                                    }
                                }
                            }
                            writer.Write(SigReg);
                            #endregion
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se puede insertar la tupla, ya que no hay una llave que corresponda a la llave foranea");
                }
                writer.Close();
                reader.Close();
                fichero.Close();
            }
            catch
            {
            }
        }
        private List<Atributo> Carga_tablas()
        {
            List<Atributo> tablas = new List<Atributo>();
            string[] t = new string[LT.Count];
            string archivo;
            long auxAtrib = 0, PosF = -1, sig_a = 0;

            for (int i = 0; i < LT.Count; i++)
            {
                archivo = ruta + "\\" + LT[i].ToString() + ".bin";
                FileStream fichero = File.Open(archivo, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader reader = new BinaryReader(fichero);
                BinaryWriter writer = new BinaryWriter(fichero);
                reader.BaseStream.Seek(8, SeekOrigin.Begin);
                reader.ReadString();
                auxAtrib = sig_a = reader.ReadInt64();

                if (sig_a != -1)
                {
                    while (auxAtrib != -1)
                    {

                        reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                        PosF = reader.BaseStream.Position;
                        Atributo atribaux = new Atributo(LT[i].ToString(), reader.ReadString(), reader.ReadChar(),
                        reader.ReadInt64(), reader.ReadInt64(), auxAtrib = sig_a = reader.ReadInt64(), reader.ReadBoolean(), reader.ReadString());
                        tablas.Add(atribaux);
                    }
                }
                reader.Close();
                writer.Close();
                fichero.Close();

            }
            return tablas;
        }
        private void BModificarT_Click(object sender, EventArgs e)
        {
            long PosEnt = 8, posantreg = 0, ApPosDatos, ApDatos, SigReg, FinArch, datol,fin = -1;
            int datoi, Clave;
            char datoc;
            float datof;
            long tamString;
            Int32 i;
            String tipo, dato, NombreE;
            DataGridViewCell dgc;
            bGuardarR.Visible = true;
            Clave = BuscaAtribClave(PosEnt);
            FinArch = BuscaFinRegistros();
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter writer = new BinaryWriter(fichero);
            BinaryReader reader = new BinaryReader(fichero);
                reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                reader.ReadString();
                reader.ReadUInt64();
                posantreg = ApPosDatos = reader.BaseStream.Position;
                ApDatos = reader.ReadInt64();
            SigReg = ApDatos;
            Busca_Registro_sinB(Clave, reader, writer,ref SigReg, ref posantreg);
            if (SigReg != -999)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);

                for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                {
                    dgc = dataGrid_Registro.Rows[i].Cells[1];
                    tipo = ((String)dgc.Value);
                    dgc = dataGrid_Registro.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);//Int32.Parse(TamString);

                    if (tipo.CompareTo("I") == 0)
                    {
                        dataGrid_Registro.Rows[i].Cells[3].Value= reader.ReadInt32();
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        dataGrid_Registro.Rows[i].Cells[3].Value = reader.ReadInt64();
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        dataGrid_Registro.Rows[i].Cells[3].Value = reader.ReadChar();
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        dataGrid_Registro.Rows[i].Cells[3].Value = reader.ReadSingle();
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        dataGrid_Registro.Rows[i].Cells[3].Value = reader.ReadString();
                    }
                }
            }
        
    
            writer.Close();
            reader.Close();
            fichero.Close();
                
            borraR();

        }
        private void altaR()
        {
            #region "Declaracion Variables"
            try
            {
                Int32 i;
                int datoi, Clave;
                bool Claveb = false, insertar = false;

                long tamString, posantreg = 0;
                long datol, FinArch, PosEnt, ApDatos, ApPosDatos, Posencontrado = -1, SigReg = 0, fin = -1;
                char datoc;
                float datof;
                String tipo, dato, NombreE;
                DataGridViewCell dgc;
                List<Atributo> AtribTabla = new List<Atributo>();
                FinArch = BuscaFinRegistros();
                NombreE = nombre;//Entidad_Registro.Text.ToString();
                PosEnt = BuscaEntidad(NombreE);
                Clave = BuscaAtribClave(PosEnt);
                Claveb = BuscaClave(PosEnt);
                AtribTabla = CargaAtributos(PosEnt);
                bool[] listaatribpasados = new bool[AtribTabla.Count];
                int contador = 0;
                string checarf;//hed.Nombre_Atributo.Replace(" ", "")
                foreach (Atributo checar in AtribTabla)
                {
                    checarf = checar.llavef;
                    checarf = checarf.Replace(" ", "");
                    if (checarf == "")
                        checarf = "false";
                    if (checar.Clave == true && checarf.CompareTo("false") != 0)
                        listaatribpasados[contador] = true;
                    if (checar.Clave == false && checarf.CompareTo("false") == 0)
                        listaatribpasados[contador] = true;
                    if (checar.Clave == true && checarf.CompareTo("false") == 0)
                        listaatribpasados[contador] = true;
                    if (checar.Clave == false)
                    {
                        if (checarf.CompareTo("false") != 0)
                        {
                            listaatribpasados[contador] = checarinsercionllavef(checar.llavef, contador - 1);
                        }
                    }
                    contador++;
                }
                if (Claveb == false)
                {
                    MessageBox.Show("No se puede insertar un registro, se necesita llave primaria");
                    return;
                }
                foreach (bool b in listaatribpasados)
                {
                    if (b == true)
                        insertar = true;
                    if (b == false)
                    {
                        insertar = false;
                        break;
                    }
                }
                FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                BinaryWriter writer = new BinaryWriter(fichero);
                BinaryReader reader = new BinaryReader(fichero);
                #endregion
                if (insertar == true)
                {
                    reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                    reader.ReadString();
                    reader.ReadUInt64();
                    posantreg = ApPosDatos = reader.BaseStream.Position;
                    ApDatos = reader.ReadInt64();
                    //No se encuentran datos
                    #region "No se encuentra Registro"
                    if (ApDatos == -1)
                    {
                        reader.BaseStream.Seek(ApPosDatos, SeekOrigin.Begin);
                        writer.Write(FinArch);
                        reader.BaseStream.Seek(FinArch, SeekOrigin.Begin);
                        for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                        {
                            dgc = dataGrid_Registro.Rows[i].Cells[1];
                            tipo = ((String)dgc.Value);
                            dgc = dataGrid_Registro.Rows[i].Cells[2];
                            tamString = Convert.ToInt64(dgc.Value);//Int32.Parse(TamString);
                            dgc = dataGrid_Registro.Rows[i].Cells[3];
                            dato = ((String)dgc.Value);

                            if (tipo.CompareTo("I") == 0)
                            {
                                datoi = Int32.Parse(dato);
                                writer.Write(datoi);
                            }
                            if (tipo.CompareTo("L") == 0)
                            {
                                datol = Convert.ToInt64(dato);
                                writer.Write(datol);
                            }
                            if (tipo.CompareTo("C") == 0)
                            {
                                datoc = dato[0];
                                writer.Write(datoc);
                            }
                            if (tipo.CompareTo("F") == 0)
                            {
                                datof = System.Convert.ToSingle(dato);
                                writer.Write(datof);
                            }
                            if (tipo.CompareTo("S") == 0)
                            {
                                int tamañoCad, TamTotalS;
                                string cad = dato;
                                TamTotalS = Convert.ToInt32(tamString + fin);     // tamaño maximo que debe de tener la cadena
                                tamañoCad = dato.Length + 1;                      //
                                if (tamañoCad - 1 > TamTotalS)
                                {
                                    MessageBox.Show("El dato es mayor al tamaño permitido, por lo que se recortara la cadena al tamaño asigando");
                                    cad = cad.PadRight(TamTotalS, ' ');
                                    writer.Write(cad.Substring(0, TamTotalS));
                                }
                                else
                                {
                                    cad = cad.PadRight(TamTotalS, ' ');
                                    writer.Write(cad.Substring(0, TamTotalS));
                                    //writer.Write(cad);
                                }
                            }
                        }
                        writer.Write(fin);
                    }
                    #endregion
                    else
                    {
                        SigReg = ApDatos;
                        SigReg = Busca_Registro(Clave, reader, writer, SigReg, ref posantreg);
                        if (SigReg != -999)
                        {
                            reader.BaseStream.Seek(posantreg, SeekOrigin.Begin);
                            writer.Write(FinArch);
                            reader.BaseStream.Seek(FinArch, SeekOrigin.Begin);
                            #region "Escribe datos"

                            for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                            {
                                dgc = dataGrid_Registro.Rows[i].Cells[1];
                                tipo = ((String)dgc.Value);
                                dgc = dataGrid_Registro.Rows[i].Cells[2];
                                tamString = Convert.ToInt64(dgc.Value);//Int32.Parse(TamString);
                                dgc = dataGrid_Registro.Rows[i].Cells[3];
                                dato = dgc.Value.ToString();

                                if (tipo.CompareTo("I") == 0)
                                {
                                    datoi = Int32.Parse(dato);
                                    writer.Write(datoi);
                                }
                                if (tipo.CompareTo("L") == 0)
                                {
                                    datol = Convert.ToInt64(dato);
                                    writer.Write(datol);
                                }
                                if (tipo.CompareTo("C") == 0)
                                {
                                    datoc = dato[0];
                                    writer.Write(datoc);
                                }
                                if (tipo.CompareTo("F") == 0)
                                {
                                    datof = System.Convert.ToSingle(dato);
                                    writer.Write(datof);
                                }
                                if (tipo.CompareTo("S") == 0)
                                {
                                    int tamañoCad, TamTotalS;
                                    string cad = dato;
                                    TamTotalS = Convert.ToInt32(tamString + fin);     // tamaño maximo que debe de tener la cadena
                                    tamañoCad = dato.Length + 1;                      //
                                    if (tamañoCad - 1 > TamTotalS)
                                    {
                                        MessageBox.Show("El dato es mayor al tamaño permitido, por lo que se recortara");
                                        cad = cad.PadRight(TamTotalS, ' ');
                                        writer.Write(cad.Substring(0, TamTotalS));
                                    }
                                    else
                                    {
                                        cad = cad.PadRight(TamTotalS, ' ');
                                        writer.Write(cad.Substring(0, TamTotalS));
                                        // writer.Write(cad);
                                    }
                                }
                            }
                            writer.Write(SigReg);
                            #endregion
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se puede insertar la tupla, ya que no hay una llave que corresponda a la llave foranea");
                }
                writer.Close();
                reader.Close();
                fichero.Close();
            }
            catch
            {
            }
        }
        private void borraR()
        {
            try
            {
                #region "Declaracion Variables"
                Int32 i;
                int datoi, Clave, CprimeraT;
                long tamString, posantreg = 0;
                long datol, FinArch, PosEnt, ApDatos, ApPosDatos, Posencontrado = -1, SigReg = 0, fin = -1;
                char datoc;
                float datof;
                bool insertar = false;
                String tipo, dato, NombreE;
                DataGridViewCell dgc;
                FinArch = BuscaFinRegistros();
                NombreE = nombrearch;//Entidad_Registro.Text.ToString();
                PosEnt = BuscaEntidad(NombreE);
                Clave = BuscaAtribClave(PosEnt);
                string[] sep = NombreE.Split('\\');
                string[] nombre = sep[sep.Count() - 1].Split('.');
                string nombreTactual = nombre[0];
                List<Atributo> AtribTabla = new List<Atributo>();
                List<Atributo> Ts = new List<Atributo>();
                List<String> Tsig = new List<String>();
                List<Int32> claves = new List<Int32>();
                List<Atributo> check = new List<Atributo>();
                List<Boolean> pas = new List<Boolean>();
                List<Atributo> Tablas = new List<Atributo>();
                string datocelda = dataGrid_Registro.Rows[Clave - 1].Cells[3].Value.ToString();
                Tablas = Carga_tablas();
                int posclave = 1;
                int posclaveentablaactual = 0;
                #endregion
                foreach (var tab in Tablas)
                {
                    if (tab.Nombre_Tabla.CompareTo(nombreTactual) != 0)
                    {
                        long cambiot = tab.Sig_Atributo;
                        bool band = false;
                        if (cambiot != -1)
                        {
                            string llavF = tab.llavef;
                            llavF = llavF.Replace(" ", "");
                            if (llavF.CompareTo(nombreTactual) == 0)
                                if (Tsig.Contains(nombreTactual) == false)
                                {
                                    Tsig.Add(tab.Nombre_Tabla);
                                    claves.Add(posclave);
                                }
                            posclave++;
                        }
                        else
                            posclave = 1;
                    }
                }
                for (int j = 0; j < Tsig.Count(); j++)
                {
                    ImprimeAtributosTablaAux(8, ruta + '\\' + Tsig[j] + ".bin");
                    FileStream fichero = File.Open(ruta + '\\' + Tsig[j] + ".bin", FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(fichero);
                    BinaryReader reader = new BinaryReader(fichero);

                    reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                    reader.ReadString();
                    reader.ReadUInt64();
                    posantreg = ApPosDatos = reader.BaseStream.Position;
                    ApDatos = reader.ReadInt64();
                    SigReg = ApDatos;
                    CprimeraT = Clave;
                    SigReg = Busca_Registro_BorrarExite(claves[j], reader, writer, SigReg, ref posantreg, datocelda);
                    if (SigReg == -999)
                        pas.Add(true);
                    //reader.BaseStream.Seek(posantreg, SeekOrigin.Begin);
                    //writer.Write(SigReg);
                    writer.Close();
                    reader.Close();
                    fichero.Close();

                }
                foreach (bool b in pas)
                {
                    if (b == true)
                        insertar = true;
                    if (b == false)
                    {
                        insertar = false;
                        break;
                    }
                }
                if (insertar == true)
                {
                    FileStream fic = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter w = new BinaryWriter(fic);
                    BinaryReader r = new BinaryReader(fic);
                    r.BaseStream.Seek(8, SeekOrigin.Begin);
                    r.ReadString();
                    r.ReadUInt64();
                    posantreg = ApPosDatos = r.BaseStream.Position;
                    ApDatos = r.ReadInt64();
                    SigReg = ApDatos;
                    SigReg = Busca_Registro_Borrar(Clave, r, w, SigReg, ref posantreg);
                    r.BaseStream.Seek(posantreg, SeekOrigin.Begin);
                    w.Write(SigReg);
                    w.Close();
                    r.Close();
                    fic.Close();
                }
                else
                    MessageBox.Show("No se puede eliminar el dato, ya que tiene una referencia en otra trabla");
            }
            catch { }
        }
        private void dataGrid_Atributo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private long Busca_Registro_Borrar(int Clave, BinaryReader reader, BinaryWriter writer, long SigReg, ref long posantreg)
        {
            ///Se busca el atributo a borrar y se regresa el siguiente registro como el apntador del registro anterior y la posicion del registro a borrar
            Int32 i;
            int datoi;
            long tamString;
            long datol, fin = -1;
            char datoc;
            float datof;
            String tipo, dato;
            DataGridViewCell dgc;
            int lugar = 1;
            int encontrado = 0;
            while (SigReg != -1)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                #region "for"
                for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                {
                    lugar = i + 1;
                    int entero;
                    long largo;
                    char caracter;
                    float flotante;
                    string cadena;
                    dgc = dataGrid_Registro.Rows[i].Cells[1];
                    tipodatoborrado = tipo = ((String)dgc.Value);
                    dgc = dataGrid_Registro.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);
                    dgc = dataGrid_Registro.Rows[i].Cells[3];
                    datoborrado = dato = dgc.Value.ToString();
                    if (tipo.CompareTo("I") == 0)
                    {
                        entero = reader.ReadInt32();
                        if (Clave == lugar)
                        {
                            datoi = Int32.Parse(dato);
                            if (datoi == entero)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        largo = reader.ReadInt64();
                        if (Clave == lugar)
                        {
                            datol = Convert.ToInt64(dato);
                            if (datol == largo)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        caracter = reader.ReadChar();
                        if (Clave == lugar)
                        {
                            datoc = dato[0];
                            if (caracter == datoc)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        flotante = reader.ReadSingle();
                        if (Clave == lugar)
                        {
                            datof = System.Convert.ToSingle(dato);
                            if (flotante == datof)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        cadena = reader.ReadString();
                        string cad = cadena.PadRight(Convert.ToInt32(tamString + fin), ' ');
                        if (Clave == lugar)
                        {
                            string dat;
                            dat = dato.PadRight(Convert.ToInt32(tamString + fin), ' ');
                            if (cad.Equals(dat) == true)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                }
                #endregion
                //posantreg = reader.BaseStream.Position;

                if (encontrado == 1)
                {
                    SigReg = reader.ReadInt64();
                    return SigReg;
                }
                posantreg = reader.BaseStream.Position;
                SigReg = reader.ReadInt64();
            }
            return SigReg;
        }
        private void Busca_Registro_sinB(int Clave, BinaryReader reader, BinaryWriter writer,ref long SigReg, ref long posantreg)
        {
            ///Se busca el atributo a borrar y se regresa el siguiente registro como el apntador del registro anterior y la posicion del registro a borrar
            Int32 i;
            int datoi;
            long tamString;
            long datol, fin = -1;
            char datoc;
            float datof;
            String tipo, dato;
            DataGridViewCell dgc;
            int lugar = 1;
            int encontrado = 0;
            while (SigReg != -1)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                #region "for"
                for (i = 0; i < dataGrid_Registro.Rows.Count - 1; i++)
                {
                    lugar = i + 1;
                    int entero;
                    long largo;
                    char caracter;
                    float flotante;
                    string cadena;
                    dgc = dataGrid_Registro.Rows[i].Cells[1];
                    tipodatoborrado = tipo = ((String)dgc.Value);
                    dgc = dataGrid_Registro.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);
                    dgc = dataGrid_Registro.Rows[Clave-1].Cells[3];
                    datoborrado = dato = dgc.Value.ToString();
                    if (tipo.CompareTo("I") == 0)
                    {
                        entero = reader.ReadInt32();
                        if (Clave == lugar)
                        {
                            datoi = Int32.Parse(dato);
                            if (datoi == entero)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        largo = reader.ReadInt64();
                        if (Clave == lugar)
                        {
                            datol = Convert.ToInt64(dato);
                            if (datol == largo)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        caracter = reader.ReadChar();
                        if (Clave == lugar)
                        {
                            datoc = dato[0];
                            if (caracter == datoc)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        flotante = reader.ReadSingle();
                        if (Clave == lugar)
                        {
                            datof = System.Convert.ToSingle(dato);
                            if (flotante == datof)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        cadena = reader.ReadString();
                        string cad = cadena.PadRight(Convert.ToInt32(tamString + fin), ' ');
                        if (Clave == lugar)
                        {
                            string dat;
                            dat = dato.PadRight(Convert.ToInt32(tamString + fin), ' ');
                            if (cad.Equals(dat) == true)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                }
                #endregion
                if (encontrado == 1)
                    return;
                SigReg = reader.ReadInt64();
                
            }
            
        }
        private void bGuardarR_Click(object sender, EventArgs e)
        {
            bGuardarR.Visible = false;
            altaR();
        }
        private long Busca_Registro_BorrarExite(int Clave, BinaryReader reader, BinaryWriter writer, long SigReg, ref long posantreg,string dato)
        {
            ///Se busca un registro y se regresa el siguiente registro y el registro anterior
            Int32 i;
            int datoi;
            long tamString;
            long datol, fin = -1;
            char datoc;
            float datof;
            String tipo;//, dato;

            int lugar = 1;
            while (SigReg != -1)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                #region "for"
                for (i = 0; i < dataGridTablaAux.Rows.Count - 1; i++)
                {
                    lugar = i + 1;
                    int entero;
                    long largo;
                    char caracter;
                    float flotante;
                    string cadena;
                    DataGridViewCell dgc;
                    dgc = dataGridTablaAux.Rows[i].Cells[1];
                    tipo = dgc.Value.ToString();
                    dgc = dataGridTablaAux.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);
                    dgc = dataGrid_Registro.Rows[Clave - 1].Cells[3];
                    //dato = dgc.Value.ToString();
                    if (tipo.CompareTo("I") == 0)
                    {
                        entero = reader.ReadInt32();
                        if (Clave == lugar)
                        {
                            datoi = Int32.Parse(dato);
                            if (datoi < entero)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (datoi == entero)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        largo = reader.ReadInt64();
                        if (Clave == lugar)
                        {
                            datol = Convert.ToInt64(dato);
                            if (datol < largo)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (datol == largo)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        caracter = reader.ReadChar();
                        if (Clave == lugar)
                        {
                            datoc = dato[0];
                            if (caracter > datoc)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (caracter.CompareTo(datoc) == 0)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        flotante = reader.ReadSingle();
                        if (Clave == lugar)
                        {
                            datof = System.Convert.ToSingle(dato);
                            if (flotante > datof)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (flotante == datof)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        cadena = reader.ReadString();

                        if (Clave == lugar)
                        {
                            int result;
                            dato = dato.PadRight(Convert.ToInt32(tamString + fin), ' ');
                            cadena = cadena.Substring(0, Convert.ToInt32(tamString + fin));
                            dato = dato.Substring(0, Convert.ToInt32(tamString + fin));
                            //tamañoCad = cad.Length;
                            //if(tamañoCad>)
                            result = String.CompareOrdinal(cadena, dato);
                            if (result > 0)
                            {
                                lugar++;
                                return SigReg;
                            }
                            if (result == 0)
                            {
                                SigReg = -999;
                                return SigReg;
                            }
                        }
                    }
                }
                #endregion
                posantreg = reader.BaseStream.Position;
                SigReg = reader.ReadInt64();
            }
            return SigReg;
        }
        private void BEliminarT_Click(object sender, EventArgs e)
        {
            ///Baja de un registro
            try
            {
                #region "Declaracion Variables"
                Int32 i;
                int datoi, Clave, CprimeraT;
                long tamString, posantreg = 0;
                long datol, FinArch, PosEnt, ApDatos, ApPosDatos, Posencontrado = -1, SigReg = 0, fin = -1;
                char datoc;
                float datof;
                bool insertar = false;
                String tipo, dato, NombreE;
                DataGridViewCell dgc;
                FinArch = BuscaFinRegistros();
                NombreE = nombrearch;//Entidad_Registro.Text.ToString();
                PosEnt = BuscaEntidad(NombreE);
                Clave = BuscaAtribClave(PosEnt);
                string[] sep = NombreE.Split('\\');
                string[] nombre = sep[sep.Count() - 1].Split('.');
                string nombreTactual = nombre[0];
                List<Atributo> AtribTabla = new List<Atributo>();
                List<Atributo> Ts = new List<Atributo>();
                List<String> Tsig = new List<String>();
                List<Int32> claves = new List<Int32>();
                List<Atributo> check = new List<Atributo>();
                List<Boolean> pas = new List<Boolean>();
                List<Atributo> Tablas = new List<Atributo>();
                string datocelda = dataGrid_Registro.Rows[Clave - 1].Cells[3].Value.ToString();
                Tablas = Carga_tablas();
                int posclave = 1;
                int posclaveentablaactual = 0;
                #endregion
                foreach (var tab in Tablas)
                {
                    if (tab.Nombre_Tabla.CompareTo(nombreTactual) != 0)
                    {
                        long cambiot = tab.Sig_Atributo;
                        bool band = false;
                        if (cambiot != -1)
                        {
                            string llavF = tab.llavef;
                            llavF = llavF.Replace(" ", "");
                            if (llavF.CompareTo(nombreTactual) == 0)
                                if (Tsig.Contains(nombreTactual) == false)
                                {
                                    Tsig.Add(tab.Nombre_Tabla);
                                    claves.Add(posclave);
                                }
                            posclave++;
                        }
                        else
                            posclave = 1;
                    }
                }
                for (int j = 0; j < Tsig.Count(); j++)
                {
                    ImprimeAtributosTablaAux(8, ruta + '\\' + Tsig[j] + ".bin");
                    FileStream fichero = File.Open(ruta + '\\' + Tsig[j] + ".bin", FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(fichero);
                    BinaryReader reader = new BinaryReader(fichero);

                    reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                    reader.ReadString();
                    reader.ReadUInt64();
                    posantreg = ApPosDatos = reader.BaseStream.Position;
                    ApDatos = reader.ReadInt64();
                    SigReg = ApDatos;
                    CprimeraT = Clave;
                    SigReg = Busca_Registro_BorrarExite(claves[j], reader, writer, SigReg, ref posantreg, datocelda);
                    if (SigReg == -999)
                        pas.Add(true);
                    //reader.BaseStream.Seek(posantreg, SeekOrigin.Begin);
                    //writer.Write(SigReg);
                    writer.Close();
                    reader.Close();
                    fichero.Close();

                }
                foreach (bool b in pas)
                {
                    if (b == true)
                        insertar = true;
                    if (b == false)
                    {
                        insertar = false;
                        break;
                    }
                }
                if (insertar == true)
                {
                    FileStream fic = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter w = new BinaryWriter(fic);
                    BinaryReader r = new BinaryReader(fic);
                    r.BaseStream.Seek(8, SeekOrigin.Begin);
                    r.ReadString();
                    r.ReadUInt64();
                    posantreg = ApPosDatos = r.BaseStream.Position;
                    ApDatos = r.ReadInt64();
                    SigReg = ApDatos;
                    SigReg = Busca_Registro_Borrar(Clave, r, w, SigReg, ref posantreg);
                    r.BaseStream.Seek(posantreg, SeekOrigin.Begin);
                    w.Write(SigReg);
                    w.Close();
                    r.Close();
                    fic.Close();
                }
                else
                    MessageBox.Show("No se puede eliminar el dato, ya que tiene una referencia en otra trabla");
            }
            catch { }
        }
        private long Busca_Siguiente_Registro_Borrar(int Clave, BinaryReader reader, BinaryWriter writer, long SigReg, ref long posantreg, int ClavePrimera)
        {
            ///Se busca el atributo a borrar y se regresa el siguiente registro como el apntador del registro anterior y la posicion del registro a borrar
            Int32 i;
            int datoi;
            long tamString;
            long datol, fin = -1;
            char datoc;
            float datof;
            String tipo, dato;
            DataGridViewCell dgc;
            int lugar = 1;
            int encontrado = 0;
            while (SigReg != -1)
            {
                reader.BaseStream.Seek(SigReg, SeekOrigin.Begin);
                #region "for"
                for (i = 0; i < dataGridTablaAux.Rows.Count - 1; i++)
                {
                    lugar = i + 1;
                    int entero;
                    long largo;
                    char caracter;
                    float flotante;
                    string cadena;
                    dgc = dataGridTablaAux.Rows[i].Cells[1];
                    tipodatoborrado = tipo = dgc.Value.ToString();
                    dgc = dataGridTablaAux.Rows[i].Cells[2];
                    tamString = Convert.ToInt64(dgc.Value);
                    dgc = dataGrid_Registro.Rows[ClavePrimera].Cells[3];
                    datoborrado = dato = dgc.Value.ToString();
                    if (tipo.CompareTo("I") == 0)
                    {
                        entero = reader.ReadInt32();
                        if (Clave == lugar)
                        {
                            datoi = Int32.Parse(dato);
                            if (datoi == entero)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("L") == 0)
                    {
                        largo = reader.ReadInt64();
                        if (Clave == lugar)
                        {
                            datol = Convert.ToInt64(dato);
                            if (datol == largo)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("C") == 0)
                    {
                        caracter = reader.ReadChar();
                        if (Clave == lugar)
                        {
                            datoc = dato[0];
                            if (caracter == datoc)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("F") == 0)
                    {
                        flotante = reader.ReadSingle();
                        if (Clave == lugar)
                        {
                            datof = System.Convert.ToSingle(dato);
                            if (flotante == datof)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                    if (tipo.CompareTo("S") == 0)
                    {
                        cadena = reader.ReadString();
                        string cad = cadena.PadRight(Convert.ToInt32(tamString + fin), ' ');
                        if (Clave == lugar)
                        {
                            string dat;
                            dat = dato.PadRight(Convert.ToInt32(tamString + fin), ' ');
                            if (cad.Equals(dat) == true)
                            {
                                encontrado = 1;
                            }
                        }
                    }
                }
                #endregion

                if (encontrado == 1)
                {
                    SigReg = reader.ReadInt64();
                    return SigReg;
                }
                posantreg = reader.BaseStream.Position;
                SigReg = reader.ReadInt64();
            }
            dataGridTablaAux.Rows.Clear();
            return SigReg;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
