using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Lexemas
{

    class LexemasTokens
    {
        public LexemasTokens()
        {

        }
        public string PalabraRecercada(ID_token token)
        {
            return token.contenido.ToUpper();
        }

        public string tiposVariables(ID_token token)
        {
            return token.contenido.ToUpper();
        }
    }
}
