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
        public AFD_realNumber()
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
                        case 1:
                            if (State_1(caracter) == false)
                            {
                                return false;
                            }
                            break;
                        case 2:
                            if (State_2(caracter) == false)
                            {
                                return false;
                            }
                            break;
                        default:
                            state = 0;
                            return false;
                    }
                }
                state = 0;
                return true;
            }
            else
            {
                state = 0;
                return false;
            }
        }
        private Boolean State_0(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 1;
                return true;
            }
            return false;
        }
        private Boolean State_1(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 1;
                return true;
            }else if (caracter.Equals("."))
            {
                this.state = 2;
            }
            return false;
           
        }
        private Boolean State_2(String caracter)
        {
            if (caracter.Equals("."))
            {
                this.state = 2;
                return true;
            }
            return false;
        }
    }
}
