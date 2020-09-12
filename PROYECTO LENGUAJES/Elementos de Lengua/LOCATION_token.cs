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
        private int inicioCadena;
        private int finCadena;
        public LOCATION_token(String cadena, int linea,int inicioCadena, int finCadena)
        {
            this.cadena = cadena;
            this.lineaUnicacion = linea;
            this.inicioCadena = inicioCadena;
            this.finCadena = finCadena;
        }
        public String getCadena()
        {
            return cadena;
        }
        public int getLineaUbicacion()
        {
            return lineaUnicacion;
        }
        public int getInicioCadena()
        {
            return this.inicioCadena;
        }
    }
}
