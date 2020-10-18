using System;

namespace PROYECTO_LENGUAJES.AFD
{
    class LogicOperators
    {
        private String[] operadoresLogicos = new String[] { "||", "&&", "!" };
        public LogicOperators()
        {

        }
        public Boolean analizar(String cadena)
        {
            foreach (String operador in operadoresLogicos)
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
