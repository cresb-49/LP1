using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_character
    {
        private int state = 0;
        private Boolean aceptacion = false;
        public AFD_character()
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
            if ((acii >= 65 && acii <= 90))
            {
                //Letras mayuscula
                this.state = 1;
                aceptacion = true;
            }else
            if (((acii >= 97 && acii <= 122)))
            {
                //Letras minusculas
                this.state = 1;
                aceptacion = true;
            }
            else
            {
                this.state = 1;
                aceptacion = false;
            }
        }
        private void State_1(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                this.state = 1;
                aceptacion = false;
            }
            //Letras minusculas
            if (((acii >= 97 && acii <= 122)))
            {
                this.state = 1;
                aceptacion = false;
            }
            {
                this.state = 0;
                aceptacion = false;
            }
            
        }
    }
}
