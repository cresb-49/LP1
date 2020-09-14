using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class LOCATION_token : Token
    {
        public LOCATION_token(String cadena, int linea,int inicioCadena)
            :base(null,cadena,linea,inicioCadena,Color.Empty)
        {
        }
    }
}
