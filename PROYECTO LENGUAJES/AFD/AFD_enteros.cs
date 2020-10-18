using System;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_enteros
    {
        private int state = 0;
        private Boolean aceptacion = false;
        public AFD_enteros()
        {

        }
        public Boolean analizar(String cadena)
        {
            state = 0;
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
                state = 0;
                return aceptacion;
            }
        }
        private void State_0(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 0;
                this.aceptacion = true;
            }
            else
            {
                this.state = 1;
                this.aceptacion = false;
            }
        }
    }
}
