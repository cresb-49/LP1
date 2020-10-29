using PROYECTO_LENGUAJES.ArbolSintactico;
using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PROYECTO_LENGUAJES.Sintactico
{
    class ExprecionesLogicas
    {
        private Arbol arbolSintactico;
        public ExprecionesLogicas(Arbol arbol)
        {
            this.arbolSintactico = arbol;
        }
        public void LOGICA(ID_token token, Stack<String> pila, List<String> errores)
        {
            asignacionRaiz(pila);
            if (token.ID.Equals("BooleanState_TOKEN") || token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push("ESTADO_LOGICO");

                arbolSintactico.agregarNodo("ESTADO_LOGICO");
                arbolSintactico.agregarNodo("LOGICA2");

            }
            else if (token.lexema.Equals("NUMERO_E") || token.lexema.Equals("NUMERO_D") || token.lexema.Equals("ID_ENTERO") || token.lexema.Equals("ID_DECIMAL") || token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push("NUM3");
                pila.Push("OP_RELACIONAL");
                pila.Push("NUM2");

                arbolSintactico.agregarNodo("NUM2");
                arbolSintactico.agregarNodo("OP_RELACIONAL");
                arbolSintactico.agregarNodo("NUM3");
                arbolSintactico.agregarNodo("LOGICA2");

            }
            else if (token.contenido.Equals("!"))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push("LOGICA");
                pila.Push("!");

                arbolSintactico.agregarNodo("!");
                arbolSintactico.agregarNodo("LOGICA");
                arbolSintactico.agregarNodo("LOGICA2");

            }
            else if (token.lexema.Equals("("))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");

                arbolSintactico.agregarNodo("(");
                arbolSintactico.agregarNodo("LOGICA");
                arbolSintactico.agregarNodo(")");
                arbolSintactico.agregarNodo("LOGICA2");
                
            }
            else
            {
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una sentencia booleana");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void LOGICA2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("&&"))
            {
                asignacionRaiz(pila);

                pila.Pop();
                pila.Push("LOGICA");
                pila.Push("&&");

                arbolSintactico.agregarNodo("&&");
                arbolSintactico.agregarNodo("LOGICA");

            }
            else if (token.lexema.Equals("||"))
            {
                asignacionRaiz(pila);

                pila.Pop();
                pila.Push("LOGICA");
                pila.Push("||");

                arbolSintactico.agregarNodo("||");
                arbolSintactico.agregarNodo("LOGICA");
            }
            else
            {
                pila.Pop();
            }
            escribirTransicion(token, pila);
        }
        public void NUM3(ID_token token, Stack<String> pila)
        {
            asignacionRaiz(pila);
            if (token.lexema.Equals("NUMERO_E") || token.lexema.Equals("NUMERO_D") || token.lexema.Equals("ID_ENTERO") || token.lexema.Equals("ID_DECIMAL") || token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("NUM2");

                arbolSintactico.agregarNodo("NUM2");
            }
        }
        public void NUM2(ID_token token, Stack<String> pila)
        {
            asignacionRaiz(pila);
            if (token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("NUM");
                pila.Push("-");

                arbolSintactico.agregarNodo("-");
                arbolSintactico.agregarNodo("NUM");
            }
            else
            {
                pila.Pop();
                pila.Push("NUM");

                arbolSintactico.agregarNodo("NUM");
            }
        }
        public void NUM(ID_token token, Stack<String> pila, List<String> errores)
        {
            asignacionRaiz(pila);
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");

                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("NUMERO_D"))
            {
                pila.Pop();
                pila.Push("NUMERO_D");

                arbolSintactico.agregarNodo(token.lexema);
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");

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
                errores.Add("Error en la linea " + token.lineaUbicacion +", "+" \""+token.contenido+"\" "+" se esperaba una variable o valor de tipo numerico");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void ESTADO_LOGICO(ID_token token, Stack<String> pila, List<String> errores)
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
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una sentencia booleana");
                pila.Pop();
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
            else
            {
                Console.WriteLine("No encontre el nodo pedido, escalare el arbol");
                arbolSintactico.escalarArbol();
                asignacionRaiz(pila);
            }
        }
    }
}
