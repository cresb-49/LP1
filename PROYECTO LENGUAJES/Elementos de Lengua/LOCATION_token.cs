using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class LOCATION_token
    {
        private String cadena;
        private int lineaUnicacion;
        public LOCATION_token(String cadena, int linea)
        {
            this.cadena = cadena;
            this.lineaUnicacion = linea;
        }
        public String getCadena()
        {
            return cadena;
        }
        public int getLineaUbicacion()
        {
            return lineaUnicacion;
        }
    }
}
