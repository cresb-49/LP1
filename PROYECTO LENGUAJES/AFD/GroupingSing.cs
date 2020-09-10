using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class GroupingSing
    {
        private String[] signoAgrupacion = new string[] { "(", ")" };
        public GroupingSing()
        {

        }
        public Boolean analizar(String cadena)
        {
            foreach (String agrupacion in signoAgrupacion)
            {
                if (cadena.Equals(agrupacion))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
