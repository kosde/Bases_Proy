using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    class Atributo
    {
        public string Nombre_Tabla;
        public string Nombre_Atributo;         // Nombre del Atributo
        public char Tipo;                      // Tipo de atributo Long Sting Char Float
        public long Tamaño;                    // Tamaño segun tipo ^
        public long Posicion;                  // Posicion de inicio Atributo
        public long Sig_Atributo;              // Posicion Siguiente Atributo
        public bool Clave;                     // Clave True-False
        public string llavef;                  // Llave foranea

        public Atributo()
        {
            Nombre_Tabla = "";
            Nombre_Atributo = "";
            Tipo = ' ';
            Tamaño=-1;
            Posicion = -1;
            Sig_Atributo = -1;
            Clave = false;
            llavef = "";
        }

        public Atributo(string Nom, char tipo, long tamaño, long posicion, bool ToF)
        {
            Nombre_Atributo = Nom;
            Tipo = tipo;
            Tamaño = tamaño;
            Posicion = posicion;
            Sig_Atributo = -1;
            Clave = ToF;
        }
        public Atributo(string Nom, char tipo, long tamaño, long posicion, long sigAtrib, bool ToF, string foranea)
        {
            Nombre_Atributo = Nom;
            Tipo = tipo;
            Tamaño = tamaño;
            Posicion = posicion;
            Sig_Atributo = sigAtrib;
            Clave = ToF;
            llavef = foranea;
        }
        public Atributo(string nombreT, string Nom, char tipo, long tamaño, long posicion, long sigAtrib, bool ToF, string foranea)
        {
            Nombre_Tabla = nombreT;
            Nombre_Atributo = Nom;
            Tipo = tipo;
            Tamaño = tamaño;
            Posicion = posicion;
            Sig_Atributo = sigAtrib;
            Clave = ToF;
            llavef = foranea;
        }
    }
}
