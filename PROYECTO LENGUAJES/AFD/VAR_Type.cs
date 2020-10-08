using System;

namespace PROYECTO_LENGUAJES.AFD
{
    class VAR_Type
    {
        String[] tipoVariable = new String[] { "entero", "decimal", "cadena", "booleano", "caracter" };
        public VAR_Type()
        {

        }
        public Boolean verificacion(String cadena)
        {
            foreach (String palabra in tipoVariable)
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
