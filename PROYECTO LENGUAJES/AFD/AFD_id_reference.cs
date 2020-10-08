using System;
using System.Text.RegularExpressions;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_id_reference
    {
        public AFD_id_reference()
        {

        }
        public Boolean analizar(String cadena)
        {
            return new Regex("^[_A-Za-z][_A-Za-z0-9]+$").IsMatch(cadena);
        }
        
    }
}
