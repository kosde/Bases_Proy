using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    class Entidad
    {
        public string Nombre_Entidad;          // Nombre de la entidad
        public long Atributo;                  // apuntador atributo
        public long Datos;                     // apuntador a datos
        public long Inicio_Entidad;            // apuntador misma entidad
        public long Sig_Entidad;               // apuntador sig entidad*
        public Entidad(string Nom)
        {
            Nombre_Entidad = Nom;
            Atributo = -1;
            Datos = -1;
            Inicio_Entidad = -1;
            Sig_Entidad = -1;
        }
    }
}
