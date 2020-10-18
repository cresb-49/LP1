using System;

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
