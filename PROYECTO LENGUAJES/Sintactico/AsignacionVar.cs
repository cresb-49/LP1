using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using PROYECTO_LENGUAJES.ArbolSintactico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Sintactico
{
    class AsignacionVar
    {
        private Arbol arbolSintactico;

        public AsignacionVar(Arbol arbol)
        {
            this.arbolSintactico = arbol;
        }
        public void ASIG_E(ID_token token, Stack<String> pila, List<String> errores)
        {
            asignacionRaiz(pila);
            
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_EP2");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_EP2");
                arbolSintactico.agregarNodo(";");

            }
            else if (token.lexema.Equals("++"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("++");

                arbolSintactico.agregarNodo("++");
                arbolSintactico.agregarNodo(";");
            }
            else if (token.lexema.Equals("--"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("--");

                arbolSintactico.agregarNodo("--");
                arbolSintactico.agregarNodo(";");
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
            arbolSintactico.agregarNodo(pila.Peek());
            asignacionRaiz(pila);

            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_DP2");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_DP2");
                arbolSintactico.agregarNodo(";");
            }
            else if (token.lexema.Equals("++"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("++");
                arbolSintactico.agregarNodo("++");
                arbolSintactico.agregarNodo(";");
            }
            else if (token.lexema.Equals("--"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("--");
                arbolSintactico.agregarNodo("--");
                arbolSintactico.agregarNodo(";");
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
            arbolSintactico.agregarNodo(pila.Peek());
            asignacionRaiz(pila);

            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_SP");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_SP");
                arbolSintactico.agregarNodo(";");
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
            arbolSintactico.agregarNodo(pila.Peek());
            asignacionRaiz(pila);

            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_BP");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_BP");
                arbolSintactico.agregarNodo(";");
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
            arbolSintactico.agregarNodo(pila.Peek());
            asignacionRaiz(pila);

            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_CP");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_CP");
                arbolSintactico.agregarNodo(";");
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_EP2");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_EP2");
                arbolSintactico.agregarNodo(";");
            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_E2");
                pila.Push("ID_ENTERO");
                pila.Push(",");

                arbolSintactico.agregarNodo(",");
                arbolSintactico.agregarNodo("ID_ENTERO");
                arbolSintactico.agregarNodo("ASIG_E2");
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ASIG_E2");
                pila.Push("ID_ENTERO");

                arbolSintactico.agregarNodo("ID_ENTERO");
                arbolSintactico.agregarNodo("ASIG_E2");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");

                arbolSintactico.agregarNodo(";");
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_DP2");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_DP2");
                arbolSintactico.agregarNodo(";");
            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_D2");
                pila.Push("ID_DECIMAL");
                pila.Push(",");

                arbolSintactico.agregarNodo(",");
                arbolSintactico.agregarNodo("ID_DECIMAL");
                arbolSintactico.agregarNodo("ASIG_D2");
            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("ASIG_D2");
                pila.Push("ID_DECIMAL");

                arbolSintactico.agregarNodo("ID_DECIMAL");
                arbolSintactico.agregarNodo("ASIG_D2");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
                arbolSintactico.agregarNodo(";");
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_SP");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_SP");
                arbolSintactico.agregarNodo(";");
            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_S2");
                pila.Push("ID_CADENA");
                pila.Push(",");

                arbolSintactico.agregarNodo(",");
                arbolSintactico.agregarNodo("ID_CADENA");
                arbolSintactico.agregarNodo("ASIG_S2");
            }
            else if (token.lexema.Equals("ID_CADENA"))
            {
                pila.Pop();
                pila.Push("ASIG_S2");
                pila.Push("ID_CADENA");

                arbolSintactico.agregarNodo("ID_CADENA");
                arbolSintactico.agregarNodo("ASIG_S2");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");

                arbolSintactico.agregarNodo(";");
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_BP");
                pila.Push("=");

                
                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_BP");
                arbolSintactico.agregarNodo(";");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_B2");
                pila.Push("ID_BOOLEANO");
                pila.Push(",");

                arbolSintactico.agregarNodo(",");
                arbolSintactico.agregarNodo("ID_BOOLEANO");
                arbolSintactico.agregarNodo("ASIG_B2");
            }
            else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ASIG_B2");
                pila.Push("ID_BOOLEANO");

                arbolSintactico.agregarNodo("ID_BOOLEANO");
                arbolSintactico.agregarNodo("ASIG_B2");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
                arbolSintactico.agregarNodo(";");
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_CP");
                pila.Push("=");

                arbolSintactico.agregarNodo("=");
                arbolSintactico.agregarNodo("ASIG_CP");
                arbolSintactico.agregarNodo(";");

            }
            else if (token.lexema.Equals(","))
            {
                pila.Pop();
                pila.Push("ASIG_C2");
                pila.Push("ID_CARACTER");
                pila.Push(",");

                arbolSintactico.agregarNodo(",");
                arbolSintactico.agregarNodo("ID_CARACTER");
                arbolSintactico.agregarNodo("ASIG_C2");
            }
            else if (token.lexema.Equals("ID_CARACTER"))
            {
                pila.Pop();
                pila.Push("ASIG_C2");
                pila.Push("ID_CARACTER");

                arbolSintactico.agregarNodo("ID_CARACTER");
                arbolSintactico.agregarNodo("ASIG_C2");
            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");

                arbolSintactico.agregarNodo(";");
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("ASIG_EP");
                pila.Push("-");

                arbolSintactico.agregarNodo("-");
                arbolSintactico.agregarNodo("ASIG_EP");
            }
            else
            {
                pila.Pop();
                pila.Push("ASIG_EP");

                arbolSintactico.agregarNodo("ASIG_EP");
            }
        }
        public void ASIG_EP(ID_token token, Stack<String> pila, List<String> errores)
        {
            asignacionRaiz(pila);
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");
                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");
                arbolSintactico.agregarNodo(token.lexema);
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
            asignacionRaiz(pila);

            if (token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("ASIG_DP");
                pila.Push("-");

                arbolSintactico.agregarNodo("-");
                arbolSintactico.agregarNodo("ASIG_DP");
            }
            else
            {
                pila.Pop();
                pila.Push("ASIG_DP");

                arbolSintactico.agregarNodo("ASIG_DP");
            }
        }
        public void ASIG_DP(ID_token token, Stack<String> pila, List<String> errores)
        {
            asignacionRaiz(pila);
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");

                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");

                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("NUMERO_D"))
            {
                pila.Pop();
                pila.Push("NUMERO_D");

                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("ID_DECIMAL");

                arbolSintactico.agregarNodo(token.lexema);
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("CAD_TEXTO"))
            {
                pila.Pop();
                pila.Push("CAD_TEXTO");
                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_CADENA"))
            {
                pila.Pop();
                pila.Push("ID_CADENA");
                arbolSintactico.agregarNodo(token.lexema);
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("VERDADERO"))
            {
                pila.Pop();
                pila.Push("VERDADERO");
                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("FALSO"))
            {
                pila.Pop();
                pila.Push("FALSO");
                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ID_BOOLEANO");
                arbolSintactico.agregarNodo(token.lexema);
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
            asignacionRaiz(pila);
            if (token.lexema.Equals("LETRA"))
            {
                pila.Pop();
                pila.Push("LETRA");
                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_CARACTER"))
            {
                pila.Pop();
                pila.Push("ID_CARACTER");
                arbolSintactico.agregarNodo(token.lexema);
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
        private void asignacionRaiz(Stack<String> pila)
        {
            Nodo temp = arbolSintactico.retornarNodo(pila.Peek());
            if (temp != null)
            {
                arbolSintactico.raizTemporal = temp;
            }
        }
    }
}
