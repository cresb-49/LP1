using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class WORD_recerved
    {
        String[] palabrasRecervadas = new String[] { "SI", "SINO", "SINO_SI","MIENTRAS","HACER","DESDE","HASTA","INCREMENTO"};
        public WORD_recerved()
        {

        }
        public Boolean verificacion(String cadena)
        {
            foreach (String palabra in palabrasRecervadas)
            {
                if (palabra.Equals(cadena))
                {
                    return true;
                }
            }
            return false;
        }
        

    }
}
