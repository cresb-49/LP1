using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class BooleanRefrence
    {
        private String[] estadoBooleano = new string[] { "verdadero", "falso" };
        public BooleanRefrence()
        {

        }
        public Boolean analizar(String cadena)
        {
            foreach (String estado in estadoBooleano)
            {
                if (cadena.Equals(estado))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
