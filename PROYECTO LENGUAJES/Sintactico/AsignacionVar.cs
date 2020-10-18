using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Sintactico
{
    class AsignacionVar
    {
        public AsignacionVar()
        {

        }
        public void ASIG_E(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_EP2");
                pila.Push("=");

            }
            else if (token.lexema.Equals("++"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("++");
            }
            else if (token.lexema.Equals("--"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("--");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo entero");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_D(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_DP2");
                pila.Push("=");

            }
            else if (token.lexema.Equals("++"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("++");
            }
            else if (token.lexema.Equals("--"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("--");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo decimal u entera");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_S(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_SP");
                pila.Push("=");

            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo cadena");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_B(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_BP");
                pila.Push("=");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo cadena");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_C(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_CP");
                pila.Push("=");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo caracter");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_E2(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_EP2");
                pila.Push("=");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_E2");
                pila.Push("ID_ENTERO");
                pila.Push(",");
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ASIG_E2");
                pila.Push("ID_ENTERO");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya ah sido declarada con anteoridad");
                }
                else
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                }
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_D2(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_DP2");
                pila.Push("=");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_D2");
                pila.Push("ID_DECIMAL");
                pila.Push(",");
            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("ASIG_D2");
                pila.Push("ID_DECIMAL");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya ah sido declarada con anteoridad");
                }
                else
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                }
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_S2(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_SP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_S2");
                pila.Push("ID_CADENA");
                pila.Push(",");
            }
            else if (token.lexema.Equals("ID_CADENA"))
            {
                pila.Pop();
                pila.Push("ASIG_S2");
                pila.Push("ID_CADENA");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya ah sido declarada con anteoridad");
                }
                else
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                }
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_B2(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_BP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_B2");
                pila.Push("ID_BOOLEANO");
                pila.Push(",");
            }
            else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ASIG_B2");
                pila.Push("ID_BOOLEANO");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya ah sido declarada con anteoridad");
                }
                else
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                }
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_C2(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_CP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_C2");
                pila.Push("ID_CARACTER");
                pila.Push(",");
            }
            else if (token.lexema.Equals("ID_CARACTER"))
            {
                pila.Pop();
                pila.Push("ASIG_C2");
                pila.Push("ID_CARACTER");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya ah sido declarada con anteoridad");
                }
                else
                {
                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                }
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_EP2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("ASIG_EP");
                pila.Push("-");
            }
            else
            {
                pila.Pop();
                pila.Push("ASIG_EP");
            }
        }
        public void ASIG_EP(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    if (token.lexema.Equals("ID_"))
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" no esta declarada");
                    }
                    else
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya esta declarada");
                    }
                }
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo entero");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_DP2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("ASIG_DP");
                pila.Push("-");
            }
            else
            {
                pila.Pop();
                pila.Push("ASIG_DP");
            }
        }
        public void ASIG_DP(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");
            }
            else if (token.lexema.Equals("NUMERO_D"))
            {
                pila.Pop();
                pila.Push("NUMERO_D");
            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("ID_DECIMAL");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    if (token.lexema.Equals("ID_"))
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" no esta declarada");
                    }
                    else
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya esta declarada");
                    }
                }
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo decimal u entera");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_SP(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("CAD_TEXTO"))
            {
                pila.Pop();
                pila.Push("CAD_TEXTO");
            }
            else if (token.lexema.Equals("ID_CADENA"))
            {
                pila.Pop();
                pila.Push("ID_CADENA");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    if (token.lexema.Equals("ID_"))
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" no esta declarada");
                    }
                    else
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya esta declarada");
                    }
                }
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo cadena");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_BP(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("VERDADERO"))
            {
                pila.Pop();
                pila.Push("VERDADERO");
            }
            else if (token.lexema.Equals("FALSO"))
            {
                pila.Pop();
                pila.Push("FALSO");
            }
            else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ID_BOOLEANO");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    if (token.lexema.Equals("ID_"))
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" no esta declarada");
                    }
                    else
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya esta declarada");
                    }
                }
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo booleano");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ASIG_CP(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("LETRA"))
            {
                pila.Pop();
                pila.Push("LETRA");
            }
            else if (token.lexema.Equals("ID_CARACTER"))
            {
                pila.Pop();
                pila.Push("ID_CARACTER");
            }
            else
            {
                pila.Pop();
                if (token.ID.Equals("Id_TOKEN"))
                {
                    if (token.lexema.Equals("ID_"))
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" no esta declarada");
                    }
                    else
                    {
                        errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" ya esta declarada");
                    }
                }
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo caracter");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void escribirTransicion(ID_token token, Stack<String> pila)
        {
            if (pila.Count > 0)
            {
                Console.WriteLine("Estado: " + pila.Peek() + " Lexema: " + token.lexema);
            }
        }
    }
}
