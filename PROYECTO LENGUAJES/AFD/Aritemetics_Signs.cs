using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class Aritemetics_Signs
    {
        private String[] operadoresAritmeticos = new String[] { "+", "-", "*", "/", "++", "--" };

        public Aritemetics_Signs()
        {

        }
        public Boolean analizar(String cadena)
        {
            foreach (String signo in operadoresAritmeticos)
            {
                if (cadena.Equals(signo))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
