using System;

namespace PROYECTO_LENGUAJES.AFD
{
    class AFD_Comentario
    {
        private int state = 0;
        private Boolean aceptacion = false;
        public AFD_Comentario()
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
                        case 3:
                            State_3(caracter);
                            break;
                        case 4:
                            State_4(caracter);
                            break;
                        default:
                            state = 0;
                            return false;
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
            if (caracter.Equals("/"))
            {
                aceptacion = false;
                this.state = 1;
            }
        }
        private void State_1(String caracter)
        {
            if (caracter.Equals("/"))
            {
                aceptacion = true;
                this.state = 2;
            }
            if (caracter.Equals("*"))
            {
                aceptacion = false;
                this.state = 3;
            }
        }

        private void State_2(String caracter)
        {
            aceptacion = true;
            state = 2;
        }
        private void State_3(String caracter)
        {
            if (caracter.Equals("*"))
            {
                this.state = 4;
            }
            else
            {
                aceptacion = false;
                this.state = 3;
            }
        }
        private void State_4(String caracter)
        {
            if (caracter.Equals("/"))
            {
                aceptacion = true;
                this.state = 4;
            }
            else
            {
                aceptacion = false;
                this.state = 3;
            }
        }
    }
}
