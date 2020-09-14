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
        private Boolean aceptacion = false;
        public AFD_id_reference()
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
                return false;
            }
        }
        private void State_0(String caracter)
        {
           int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
           //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                this.state = 1;
                aceptacion = false;
            }else
            if (((acii >= 97 && acii <= 122)))
            {
                //Letras minusculas
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
            //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                this.state = 2;
                aceptacion = true;
            }
            else
            if (((acii >= 97 && acii <= 122)))
            {
                //Letras minusculas
                this.state = 2;
                aceptacion = true;
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
            //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                //Letras mayuscula
                this.state = 2;
                aceptacion = true;
            }
            else
            if (((acii >= 97 && acii <= 122)))
            {
                //Letras minuscula
                this.state = 2;
                aceptacion = true;
            }
            else
            if ((acii >= 48 && acii <= 57))
            {
                //numeros
                this.state = 3;
                aceptacion = true;
            }
            else
            if (caracter.Equals("_"))
            {
                this.state = 3;
                aceptacion = true;
            }
            else
            {
                aceptacion = false;
                this.state =4;
            }
        }
        private void State_3(String caracter)
        {
            int acii = System.Convert.ToInt32(Convert.ToChar(caracter));
            //Letras mayuscula
            if ((acii >= 65 && acii <= 90))
            {
                //Letras mayuscula
                this.state = 3;
                aceptacion = true;
            }
            else
            if (((acii >= 97 && acii <= 122)))
            {
                //Letras minuscula
                this.state = 3;
                aceptacion = true;
            }
            else
            if ((acii >= 48 && acii <= 57))
            {
                //numeros
                this.state = 3;
                aceptacion = true;
            }
            else
            if (caracter.Equals("_"))
            {
                this.state = 3;
                aceptacion = true;
            }
            else
            {
                aceptacion = false;
                this.state = 4;
            }

        }
    }   
}
