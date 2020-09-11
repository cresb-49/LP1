using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_cadena
    {
        private int state = 0;
        private Boolean aceptacion = false;
        public AFD_cadena()
        {

        }
        public Boolean analizar(String cadena)
        {
            aceptacion = false;
            if (!cadena.Equals(""))
            {
                String caracter = "";
                for (int i = 0; i < cadena.Length; i++)
                {
                    caracter = cadena.Substring(i, 1);
                    switch (state)
                    {
                        case 0:
                            State_0(caracter);
                            break;
                        case 1:
                            State_1(caracter);
                            break;
                        case 2:
                            State_2(caracter);
                            break;
                        default:
                            state = 0;
                            return aceptacion;
                    }
                }
                state = 0;
                return aceptacion;
            }
            else
            {
                return false;
            }
        }
        private void State_0(String caracter)
        {
            if (caracter.Equals("\""))
            {
                this.state = 1;
                aceptacion = false;
            }
        }
        private void State_1(String caracter)
        {
            if (caracter.Equals("\""))
            {
                this.state = 2;
                aceptacion = true;
            }
            else
            {
                aceptacion = false;
                this.state = 1;
            }
        }
        private void State_2(String caracter)
        {
            if (caracter.Equals("\""))
            {
                aceptacion = true;
                this.state = 1;
            }
            else
            {
                aceptacion = false;
                this.state = 1;
            }
        }
    }
}
