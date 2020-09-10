using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_id_reference
    {
        private int state=0;
        public AFD_id_reference()
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
            //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                this.state = 1;
                return true;
            }
            //Letras minusculas
            if (((acii >= 97 && acii <= 122)))
            {
                this.state = 1;
                return true;
            }
            return false;
        }

        private Boolean State_1(String caracter)
        {
            int acii = System.Convert.ToInt32(caracter);
            //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                this.state = 1;
                return true;
            }
            else
            //Letras minusculas
            if (((acii >= 97 && acii <= 122)))
            {
                this.state = 1;
                return true;
            }
            else
            //numeros
            if ((acii >= 48 && acii <= 57))
            {
                this.state = 1;
                return true;
            }
            else
            //barrabaja
            if (caracter.Equals("_"))
            {
                this.state = 1;
            }
            return false;

        }
    }   
}
