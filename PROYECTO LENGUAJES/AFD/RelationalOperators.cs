using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class RelationalOperators
    {
        private String[] operadoresRelacionales = new String[] { ">", "<", ">=", "<=", "==", "!=" };
        public RelationalOperators()
        {

        }
        public Boolean analizar(String cadena)
        {
            foreach (String operador in operadoresRelacionales)
            {
                if (cadena.Equals(operador))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
