using System;
using System.Drawing;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class LOCATION_token : Token
    {
        public LOCATION_token(String cadena, int linea, int inicioCadena)
            : base(null,null, cadena, linea, inicioCadena, Color.Empty)
        {
        }
    }
}
