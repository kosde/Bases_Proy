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
    public partial class Atributos_Form : Form
    {
        string nombre, ruta,nombrearch;
        public List<string> LT = new List<string>();
        public Atributos_Form(string n,string r, List<string> ListaTablas)
        {
            nombre = nombrearch = n;
            ruta = r;
            InitializeComponent();
            nombrearch = ruta + "/" + nombrearch + ".bin";
            LT = ListaTablas;
            imprime_AtributosGrid();
        }
        private long BuscaEntidad(string NombreB)
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
        private long BuscaPosInicioAtributos(long posEntidad)
        {
            ///Busca y regresa la posicion del primer atributo
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long PosF = -1;

            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            PosF = reader.ReadInt64();
            reader.ReadInt64();
            reader.ReadInt64();
            reader.ReadInt64();

            reader.Close();
            writer.Close();
            fichero.Close();
            return PosF;
        }
        private long BuscaFinAtributos(long posEntidad)
        {
            ///Recorrido de atributos segun la posicion de la entidad donde estamos regresando la posicion final
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0;

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
                    reader.ReadBoolean();
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();

            return PosF;
        }
        private void Imprime_Atributos_ppor_Pos(long posEntidad)
        {
            ///Se imprimiran los atributos de acuerdo a la entidad seleccionada
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            string nombre, nombrea, llaveF;
            char tipo;
            long aux = 0, auxatrib = 0;
            long atrib, datos, entidad, sig_ent;
            long tamaño, posa, sig_a;
            bool clave,nollave;

            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();


            if (sig_a != -1)
            {
                while (auxatrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    nombrea = reader.ReadString();
                    tipo = reader.ReadChar();
                    tamaño = reader.ReadInt64();
                    posa = reader.ReadInt64();
                    auxatrib = sig_a = reader.ReadInt64();
                    clave = reader.ReadBoolean();
                    llaveF = reader.ReadString();
                    nollave = reader.ReadBoolean();
                    //if (tamaño > 8)
                    //  tamaño = tamaño + 1;
                    if (tipo.CompareTo('S') == 0)
                        tamaño++;
                    dataGrid_Atributo.Rows.Add(nombrea, tipo, tamaño,clave, llaveF,nollave);
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();
            //IgualaElemntos();
        }
        private void imprime_AtributosGrid()
        {
            string Tabla = nombre;
            //Archivo_text.Text = Tabla;
            nombrearch = ruta + "\\" + Tabla + ".bin";

            string Nombre;
            long PosEnt;
            dataGrid_Atributo.Rows.Clear();
            Nombre = Tabla;
            PosEnt = BuscaEntidad(Nombre.PadRight(29, ' '));
            Imprime_Atributos_ppor_Pos(PosEnt);

            /*string NombreE = "";
            NombreE = ComboBoxEntidadparaAtrib.Text.ToString();
            PosEnt = BuscaEntidad(NombreE.PadRight(29, ' '));
            Activa_o_Desactiva_Llave(PosEnt);*/
        }
        private void BAgregarT_Click(object sender, EventArgs e)
        {
                ///Se da de alta un atributo
                long PosEnt, FinalArch, PosAtrib, TamañoAtrib, PosInicioAtrib;
                string NombreAtributo, TipoDedatoCombobox;
                char tipo;
                string ClaveB, NombreE, llaveF = "";
                bool clave = false, exite = false,todoOk=false,nollave=false;
                NombreE = nombre;
                PosEnt = BuscaEntidad(NombreE.PadRight(29, ' '));

                PosInicioAtrib = BuscaPosInicioAtributos(PosEnt);
                PosAtrib = BuscaFinAtributos(PosEnt);

                Atributo Atrib = new Atributo();

                FAtributo vEnt = new FAtributo(PosEnt,nombrearch,nombre,LT);
                if (vEnt.ShowDialog() == DialogResult.OK)
                    todoOk = true;
                if (todoOk == true)
                {
                    NombreAtributo = vEnt.Nombre_Atributo;
                    TamañoAtrib = vEnt.Tamaño;
                    tipo = vEnt.Tipo;
                    clave = vEnt.Clave;
                    nollave = vEnt.nollaves;
                    FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(fichero);
                    BinaryReader reader = new BinaryReader(fichero);
                    FinalArch = reader.BaseStream.Seek(0, SeekOrigin.End);
                    if (PosAtrib == -1)
                    {
                        reader.BaseStream.Seek(FinalArch, SeekOrigin.Begin);
                        Atributo nueva = new Atributo(NombreAtributo.PadRight(29, ' '), tipo, TamañoAtrib, FinalArch, clave);
                        writer.Write(nueva.Nombre_Atributo);
                        writer.Write(nueva.Tipo);
                        writer.Write(nueva.Tamaño);
                        writer.Write(nueva.Posicion);
                        writer.Write(nueva.Sig_Atributo);
                        writer.Write(nueva.Clave);
                        writer.Write(llaveF);
                        writer.Write(nollave);
                        reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                        reader.ReadString();
                        writer.Write(FinalArch);
                    }
                    else
                    {
                        exite = ChecaNombreExite_Atributo(NombreAtributo, PosInicioAtrib, writer, reader);
                        if (exite == false)
                        {
                            reader.BaseStream.Seek(FinalArch, SeekOrigin.Begin);
                            Atributo nueva = new Atributo(NombreAtributo.PadRight(29, ' '), tipo, TamañoAtrib, FinalArch, clave);
                            writer.Write(nueva.Nombre_Atributo);
                            writer.Write(nueva.Tipo);
                            writer.Write(nueva.Tamaño);
                            writer.Write(nueva.Posicion);
                            writer.Write(nueva.Sig_Atributo);
                            writer.Write(nueva.Clave);
                            writer.Write(llaveF);
                            writer.Write(nollave);
                            reader.BaseStream.Seek(PosAtrib, SeekOrigin.Begin);
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            writer.Write(FinalArch);
                        }
                        else
                            MessageBox.Show("El atributo con este nombre ya exite!");
                    }
                    writer.Close();
                    reader.Close();
                    fichero.Close();
                    //Activa_o_Desactiva_Llave(PosEnt);
                    imprime_AtributosGrid();
            }
        }
        private bool ChecaNombreExite_Atributo(string nombre, long posAtrib, BinaryWriter writer, BinaryReader reader)
        {
            ///Aqui se pasa el nombre de un atributo y la posicion de inicio de los atributos donde se buscara si el nombre de la entidad ya existe
            long sigEntd = posAtrib;
            string NombreB;
            bool band = false;
            reader.BaseStream.Seek(posAtrib, SeekOrigin.Begin);
            while (sigEntd != -1)
            {
                reader.BaseStream.Seek(sigEntd, SeekOrigin.Begin);
                NombreB = reader.ReadString();
                if ((NombreB.CompareTo(nombre.PadRight(29, ' '))) == 0)
                    band = true;
                reader.ReadChar();
                reader.ReadInt64();
                reader.ReadInt64();
                sigEntd = reader.ReadInt64();
                reader.ReadBoolean();
            }
            return band;
        }
        private void BModificarT_Click(object sender, EventArgs e)
        {
            int i = dataGrid_Atributo.CurrentRow.Index;
            bool todoOk = false;
            string NombreE = dataGrid_Atributo.Rows[i].Cells[0].Value.ToString();
            long PosEnt = BuscaEntidad(NombreE);
            FAtributo vAtrib2 = new FAtributo();
            FAtributo vAtrib1 = new FAtributo(PosEnt, nombrearch, nombre, LT);
            vAtrib1.Nombre_Atributo = NombreE;
            vAtrib1.Tipo = Convert.ToChar( dataGrid_Atributo.Rows[i].Cells[1].Value);
            vAtrib1.Tamaño = Convert.ToInt64( dataGrid_Atributo.Rows[i].Cells[2].Value.ToString());
            vAtrib1.Clave = Convert.ToBoolean(dataGrid_Atributo.Rows[i].Cells[3].Value.ToString());
            vAtrib1.llavef = dataGrid_Atributo.Rows[i].Cells[4].Value.ToString();
            vAtrib1.nollaves = Convert.ToBoolean(dataGrid_Atributo.Rows[i].Cells[5].Value.ToString());
            vAtrib1.llenacampos();
            vAtrib2 = vAtrib1;
            if (vAtrib1.ShowDialog() == DialogResult.OK)
                todoOk = true;
            if(todoOk == true)
            {
                elim();
                agrm(vAtrib1);
               
            }
        }
        private void agrm(FAtributo vAtrib1)
        {
            ///Se da de alta un atributo
            long PosEnt, FinalArch, PosAtrib, TamañoAtrib, PosInicioAtrib;
            string NombreAtributo, TipoDedatoCombobox;
            char tipo;
            string ClaveB, NombreE, llaveF = "";
            bool clave = false, exite = false, todoOk = true, nollave = false;
            NombreE = nombre;
            PosEnt = BuscaEntidad(NombreE.PadRight(29, ' '));

            PosInicioAtrib = BuscaPosInicioAtributos(PosEnt);
            PosAtrib = BuscaFinAtributos(PosEnt);

            FAtributo vEnt = vAtrib1;
            if (todoOk == true)
            {/*
                public string Nombre_Tabla;
                public string Nombre_Atributo;         // Nombre del Atributo
                public char Tipo;                      // Tipo de atributo Long Sting Char Float
                public long Tamaño;                    // Tamaño segun tipo ^
                public long Posicion;                  // Posicion de inicio Atributo
                public long Sig_Atributo;              // Posicion Siguiente Atributo
                public bool Clave;                     // Clave True-False
                public string llavef;                  // Llave foranea
                 */
                NombreAtributo = vEnt.Nombre_Atributo;
                TamañoAtrib = vEnt.Tamaño;
                tipo = vEnt.Tipo;
                clave = vEnt.Clave;
                nollave = vEnt.nollaves;
                FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                BinaryWriter writer = new BinaryWriter(fichero);
                BinaryReader reader = new BinaryReader(fichero);
                FinalArch = reader.BaseStream.Seek(0, SeekOrigin.End);
                if (PosAtrib == -1)
                {
                    reader.BaseStream.Seek(FinalArch, SeekOrigin.Begin);
                    Atributo nueva = new Atributo(NombreAtributo.PadRight(29, ' '), tipo, TamañoAtrib, FinalArch, clave);
                    writer.Write(nueva.Nombre_Atributo);
                    writer.Write(nueva.Tipo);
                    writer.Write(nueva.Tamaño);
                    writer.Write(nueva.Posicion);
                    writer.Write(nueva.Sig_Atributo);
                    writer.Write(nueva.Clave);
                    writer.Write(llaveF);
                    writer.Write(nollave);
                    reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                    reader.ReadString();
                    writer.Write(FinalArch);
                }
                else
                {
                    exite = ChecaNombreExite_Atributo(NombreAtributo, PosInicioAtrib, writer, reader);
                    if (exite == false)
                    {
                        reader.BaseStream.Seek(FinalArch, SeekOrigin.Begin);
                        Atributo nueva = new Atributo(NombreAtributo.PadRight(29, ' '), tipo, TamañoAtrib, FinalArch, clave);
                        writer.Write(nueva.Nombre_Atributo);
                        writer.Write(nueva.Tipo);
                        writer.Write(nueva.Tamaño);
                        writer.Write(nueva.Posicion);
                        writer.Write(nueva.Sig_Atributo);
                        writer.Write(nueva.Clave);
                        writer.Write(llaveF);
                        writer.Write(nollave);
                        reader.BaseStream.Seek(PosAtrib, SeekOrigin.Begin);
                        reader.ReadString();
                        reader.ReadChar();
                        reader.ReadInt64();
                        reader.ReadInt64();
                        writer.Write(FinalArch);
                    }
                    else
                        MessageBox.Show("El atributo con este nombre ya exite!");
                }
                writer.Close();
                reader.Close();
                fichero.Close();
                //Activa_o_Desactiva_Llave(PosEnt);
                imprime_AtributosGrid();
            }
        }
        private void elim()
        {
            try
            {
                long PosEnt, FinalArch, PosAtrib, TamañoAtrib, PosAtrib_en_Entidad, posSigAtrib, posAtribAnte;
                string NombreNuevo, TipoDedatoCombobox;
                char tipo;
                string ClaveB, NombreE;
                long p1, p2, existe = -5, posaux, Datos;
                bool clave = false;
                int i = dataGrid_Atributo.CurrentRow.Index;
                NombreE = nombre;
                PosEnt = BuscaEntidad(NombreE.PadRight(29, ' '));
                //FinalArch = BuscaFinal();
                PosAtrib = BuscaAtributo(PosEnt);
                NombreNuevo = dataGrid_Atributo.Rows[i].Cells[0].Value.ToString();
                TamañoAtrib = Convert.ToInt64(dataGrid_Atributo.Rows[i].Cells[2].Value.ToString());
                TipoDedatoCombobox = dataGrid_Atributo.Rows[i].Cells[1].Value.ToString();
                posAtribAnte = BuscaPosAntAtrib(PosEnt);
                existe = BuscaExisteAtributos(PosEnt, NombreNuevo);
                //Activa_o_Desactiva_Llave(PosEnt);
                Datos = RegresaApDatos(PosEnt);
                if (Datos == -1)
                {
                    FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(fichero);
                    BinaryReader reader = new BinaryReader(fichero);

                    if (existe == 0)
                    {
                        reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                        reader.ReadString();
                        posaux = reader.BaseStream.Position;
                        PosAtrib_en_Entidad = reader.ReadInt64();
                        if (PosAtrib_en_Entidad == PosAtrib)
                        {
                            reader.BaseStream.Seek(PosAtrib, SeekOrigin.Begin);
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            posSigAtrib = reader.ReadInt64();
                            reader.BaseStream.Seek(posaux, SeekOrigin.Begin);
                            writer.Write(posSigAtrib);
                        }
                        else
                        {
                            reader.BaseStream.Seek(posAtribAnte, SeekOrigin.Begin);
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            p1 = reader.BaseStream.Position;
                            posSigAtrib = reader.ReadInt64();
                            reader.ReadBoolean();
                            reader.ReadString();
                            reader.ReadBoolean();
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            posAtribAnte = reader.ReadInt64();
                            reader.BaseStream.Seek(p1, SeekOrigin.Begin);
                            writer.Write(posAtribAnte);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atributo no exite");
                    }

                    writer.Close();
                    reader.Close();
                    fichero.Close();
                    //Activa_o_Desactiva_Llave(PosEnt);
                }
                else
                    MessageBox.Show("No se eliminara el atributo porque la entidad contiene datos");
            }
            catch { }
            //imprime_AtributosGrid();
        }
        private void dataGrid_Atributo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BEliminarT_Click(object sender, EventArgs e)
        {     
            try
            {
                long PosEnt, FinalArch, PosAtrib, TamañoAtrib, PosAtrib_en_Entidad, posSigAtrib, posAtribAnte;
                string NombreNuevo, TipoDedatoCombobox;
                char tipo;
                string ClaveB, NombreE;
                long p1, p2, existe = -5, posaux, Datos;
                bool clave = false;
                int i = dataGrid_Atributo.CurrentRow.Index;
                NombreE = nombre;
                PosEnt = BuscaEntidad(NombreE.PadRight(29, ' '));
                //FinalArch = BuscaFinal();
                PosAtrib = BuscaAtributo(PosEnt);
                NombreNuevo = dataGrid_Atributo.Rows[i].Cells[0].Value.ToString();
                TamañoAtrib = Convert.ToInt64(dataGrid_Atributo.Rows[i].Cells[2].Value.ToString());
                TipoDedatoCombobox = dataGrid_Atributo.Rows[i].Cells[1].Value.ToString();
                posAtribAnte = BuscaPosAntAtrib(PosEnt);
                existe = BuscaExisteAtributos(PosEnt, NombreNuevo);
                //Activa_o_Desactiva_Llave(PosEnt);
                Datos = RegresaApDatos(PosEnt);
                if (Datos == -1)
                {
                    FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(fichero);
                    BinaryReader reader = new BinaryReader(fichero);

                    if (existe == 0)
                    {
                        reader.BaseStream.Seek(PosEnt, SeekOrigin.Begin);
                        reader.ReadString();
                        posaux = reader.BaseStream.Position;
                        PosAtrib_en_Entidad = reader.ReadInt64();
                        if (PosAtrib_en_Entidad == PosAtrib)
                        {
                            reader.BaseStream.Seek(PosAtrib, SeekOrigin.Begin);
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            posSigAtrib = reader.ReadInt64();
                            reader.BaseStream.Seek(posaux, SeekOrigin.Begin);
                            writer.Write(posSigAtrib);
                        }
                        else
                        {
                            reader.BaseStream.Seek(posAtribAnte, SeekOrigin.Begin);
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            p1 = reader.BaseStream.Position;
                            posSigAtrib = reader.ReadInt64();
                            reader.ReadBoolean();
                            reader.ReadString();
                            reader.ReadBoolean();
                            reader.ReadString();
                            reader.ReadChar();
                            reader.ReadInt64();
                            reader.ReadInt64();
                            posAtribAnte = reader.ReadInt64();
                            reader.BaseStream.Seek(p1, SeekOrigin.Begin);
                            writer.Write(posAtribAnte);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Atributo no exite");
                    }

                    writer.Close();
                    reader.Close();
                    fichero.Close();
                    //Activa_o_Desactiva_Llave(PosEnt);
                }
                else
                    MessageBox.Show("No se eliminara el atributo porque la entidad contiene datos");
            }
            catch { }
            imprime_AtributosGrid();
        }
        private long RegresaApDatos(long posEntidad)
        {
            ///Se busca el apuntador a datos de la entidad y se regresa
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long sig_a = 0, p2;
            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            p2 = reader.ReadInt64();
            reader.Close();
            writer.Close();
            fichero.Close();
            return p2;
        }
        private long BuscaExisteAtributos(long posEntidad, string nombre)
        {
            ///Busca si existe atributo el nombre solicitado de ser asi regresa la posicion donde se encuentra
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0, Bandera = -1;

            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            string nombreBuscado, nombre1;
            nombre1 = nombre.PadRight(29, ' ');
            reader.ReadString();
            sig_a = reader.ReadInt64();

            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    PosF = reader.BaseStream.Position;
                    nombreBuscado = reader.ReadString();
                    if (nombreBuscado.CompareTo(nombre1) == 0)
                        Bandera = 0;
                    reader.ReadChar();
                    reader.ReadInt64();
                    reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    reader.ReadBoolean();
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();

            return Bandera;
        }
        private long BuscaPosAntAtrib(long posEntidad)
        {
            ///Busca la posicion anteriror del atributo buscado ingresando la posicion de la entidad donde se buscara y regresando la posicion del atributo anterior
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0, pos2;
            string Nombre, NombreNuevo;
            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            int i = dataGrid_Atributo.CurrentRow.Index;
            NombreNuevo = dataGrid_Atributo.Rows[i].Cells[0].Value.ToString();
            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    Nombre = reader.ReadString();
                    if ((Nombre.CompareTo(NombreNuevo.PadRight(29, ' '))) == 0)
                    {
                        reader.ReadChar();
                        reader.ReadInt64();
                        //PosF = 
                        reader.ReadInt64();
                        reader.Close();
                        writer.Close();
                        fichero.Close();
                        return PosF;
                    }
                    reader.ReadChar();
                    reader.ReadInt64();
                    PosF = reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    reader.ReadBoolean();
                    pos2 = reader.BaseStream.Position;
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();

            return PosF;
        }
        /*private long TamañoTipoAtributo()
        {
            ///De acuerdo al tipo de dato seleccionado se calcula el tamaño y se regresa
            long tipo = 0;
            string TipoC;
            TipoC = comboBox_Tipo.Text.ToString();
            if (TipoC.CompareTo("I") == 0)
                tipo = 4;
            if (TipoC.CompareTo("L") == 0 || TipoC.CompareTo("F") == 0)
                tipo = 8;
            if (TipoC.CompareTo("S") == 0)
            {
                tipo = int.Parse(comboBox_tam_1.Text.ToString());
                tipo = tipo - 1;
            }
            if (TipoC.CompareTo("C") == 0)
                tipo = 1;
            return tipo;
        }*/
        private long BuscaAtributo(long posEntidad)
        {
            ///Se busca un atributo segun la entidad donde estemos y se regresa la posicion del atributo encontrado
            FileStream fichero = File.Open(nombrearch, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(fichero);
            BinaryWriter writer = new BinaryWriter(fichero);
            long auxAtrib = 0, PosF = -1, sig_a = 0, pos2;
            string Nombre, NombreNuevo;
            reader.BaseStream.Seek(posEntidad, SeekOrigin.Begin);
            reader.ReadString();
            sig_a = reader.ReadInt64();
            int i = dataGrid_Atributo.CurrentRow.Index;
            NombreNuevo = dataGrid_Atributo.Rows[i].Cells[0].Value.ToString();
            if (sig_a != -1)
            {
                while (auxAtrib != -1)
                {
                    reader.BaseStream.Seek(sig_a, SeekOrigin.Begin);
                    PosF = reader.BaseStream.Position;
                    Nombre = reader.ReadString();
                    if ((Nombre.CompareTo(NombreNuevo.PadRight(29, ' '))) == 0)
                    {
                        reader.Close();
                        writer.Close();
                        fichero.Close();
                        return PosF;
                    }
                    reader.ReadChar();
                    reader.ReadInt64();
                    PosF = reader.ReadInt64();
                    auxAtrib = sig_a = reader.ReadInt64();
                    reader.ReadBoolean();
                    pos2 = reader.BaseStream.Position;
                }
            }
            reader.Close();
            writer.Close();
            fichero.Close();

            return PosF;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
