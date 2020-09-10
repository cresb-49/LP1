using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_enteros
    {
        private int state = 0;
        public AFD_enteros()
        {

        }
        public Boolean analizar(String cadena)
        {
            if (!cadena.Equals(""))
            {
                String caracter = "";
                for (int i = 0; i < cadena.Length; i++)
                {
                    caracter = cadena.Substring(i, 1);
                    switch (state)
                    {
                        case 0:
                            if (State_0(caracter) == false)
                            {
                                return false;
                            }
                            break;
                        default:
                            return false;
                    }
                }
                return true;
            }
            else
            {
               return false;
            }
        }
        private Boolean State_0(String caracter)
        {
            int acii = System.Convert.ToInt32(caracter);
            if ((acii >= 48 && acii <= 57))
            {
                return true;
            }
            return false;
        }
        private Boolean numeros(char caracter)
        {
            int acii = System.Convert.ToInt32(caracter);
            if ((acii >= 48 && acii <= 57))
            {
                return true;
            }
            return false;
        }
    }
}
