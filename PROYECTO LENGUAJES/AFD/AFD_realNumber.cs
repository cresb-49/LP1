using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_realNumber
    {
        private int state = 0;
        private Boolean aceptacion = false;
        public AFD_realNumber()
        {

        }
        public Boolean analizar(String cadena)
        {
            aceptacion = false;
            state = 0;
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
                        case 3:
                            State_3(caracter);
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
                this.state = 1;
                aceptacion = false;
            }
            else
            {
                this.state = 4;
                aceptacion = false;
            }
        }
        private void State_1(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 1;
                aceptacion = false;
            }else if (caracter.Equals("."))
            {
                this.state = 2;
                aceptacion = false;
            }
            else
            {
                this.state = 4;
                aceptacion = false;
            }
        }
        private void State_2(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 3;
                aceptacion = true;
            }
            else
            {
                this.state = 4;
                aceptacion = false;
            }
        }
        private void State_3(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 3;
                aceptacion = true;
            }
            else
            {
                this.state = 4;
                aceptacion = false;
            }
        }
    }
}
