using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Sintactico
{
    class ExprecionesLogicas
    {
        public ExprecionesLogicas()
        {

        }
        public void LOGICA(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.ID.Equals("BooleanState_TOKEN") || token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push("ESTADO_LOGICO");
            }
            else if (token.lexema.Equals("NUMERO_E") || token.lexema.Equals("NUMERO_D") || token.lexema.Equals("ID_ENTERO") || token.lexema.Equals("ID_DECIMAL") || token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push("NUM2");
                pila.Push("OP_RELACIONAL");
                pila.Push("NUM2");
            }
            else if (token.contenido.Equals("!"))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push("LOGICA");
                pila.Push("!");
            }
            else if (token.lexema.Equals("("))
            {
                pila.Pop();
                pila.Push("LOGICA2");
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");
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
                pila.Pop();
                pila.Push("LOGICA");
                pila.Push("&&");
            }
            else if (token.lexema.Equals("||"))
            {
                pila.Pop();
                pila.Push("LOGICA");
                pila.Push("||");
            }
            else
            {
                pila.Pop();
            }
            escribirTransicion(token, pila);
        }
        public void NUM2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("-"))
            {
                pila.Pop();
                pila.Push("NUM");
                pila.Push("-");
            }
            else
            {
                pila.Pop();
                pila.Push("NUM");
            }
        }
        public void NUM(ID_token token, Stack<String> pila, List<String> errores)
        {
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");
            }
            else if (token.lexema.Equals("NUMERO_D"))
            {
                pila.Pop();
                pila.Push("NUMERO_D");
            }
            else if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");
            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("ID_DECIMAL");
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
    }
}
