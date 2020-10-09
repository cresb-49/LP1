using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Pila
{
    class AnalicisSintactico
    {
        private List<String> erroresSintaxis = new List<String>();

        private String[] estadosTerminales = {"PRICIPAL","(",")","{","}","ENTERO","DECIMAL","BOOLEANO","CARACTER","CADENA","ID_ENTERO", "ID_DECIMAL", "ID_BOOLEANO",
                                                "ID_CARACTER", "ID_CADENA","NUMERO_E","NUMERO_D","CAD_TEXTO",";","="};
        public AnalicisSintactico()
        {

        }
        public List<String> errores
        {
            get { return erroresSintaxis; }
        }
        public void ejecutar(List<ID_token>tokes)
        {
            if (tokes.Count > 0)
            {
                ID_token fin = new ID_token("FINAL_TOKEN", "$", 0, 0, Color.Orange);
                fin.lexema = "$";
                tokes.Add(fin);
                Stack<String> pila = new Stack<String>();

                pila.Push("$");
                pila.Push("0");
                ID_token token;
                Boolean res=false;
                for(int j = 0; j < tokes.Count; j++)
                {
                    token = tokes.ElementAt(j);
                    do
                    {
                        res = verificacionTerminal(token, pila);
                        if (pila.Count > 0)
                        {
                            Console.WriteLine("Estado: "+pila.Peek()+" Lexema: "+token.lexema);
                        }
                    } while (res);
                }
                foreach(String var in pila)
                {
                    Console.WriteLine(var);
                }
            }

        }
        public Boolean verificacionTerminal(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals(pila.Peek()))
            {
                pila.Pop();
                return false;
            }
            else
            {
                if (isTerminal(pila.Peek()))
                {

                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba " + " \""+pila.Peek()+" \" ");
                    pila.Pop();
                    pila.Push(token.lexema);
                    return true;
                }
                else
                {
                    Boolean temp = shift(token, pila);
                    return temp;
                }
            }
        }
        public Boolean shift(ID_token token, Stack<String> pila)
        {
            Boolean respuesta = false;
            switch (pila.Peek())
            {
                case "0":
                    estado0(token, pila);
                    respuesta = true;
                    break;
                case "1":
                    estado1(token, pila);
                    respuesta = true;
                    break;
                case "2":
                    estado2(token, pila);
                    respuesta = true;
                    break;
                case "3":
                    estado3(token, pila);
                    respuesta = true;
                    break;
                default:
                    respuesta = false;
                    break;
            }
            return respuesta;
        }

        public void estado0(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("PRINCIPAL"))
            {
                pila.Pop();
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push(")");
                pila.Push("(");
                pila.Push("PRINCIPAL");
            }
        }
        public void estado1(ID_token token, Stack<String> pila)
        {
            if (token.ID.Equals("Id_TOKEN"))
            {
                pila.Push("2");
            }else if (token.ID.Equals("VariableType_TOKEN"))
            {
                pila.Push("3");
            }
            else if (token.lexema.Equals("}"))
            {
                pila.Pop();
            }
            else
            {
                pila.Push(token.lexema);
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + "no se esperaba \" "+token.contenido+" \" ");
            }
        }

        public void estado2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("NUMERO_E");
                pila.Push("=");
                pila.Push("ID_ENTERO");
            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("NUMERO_D");
                pila.Push("=");
                pila.Push("ID_DECIMAL");

            }
            else if (token.lexema.Equals("ID_CADENA"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("CAD_TEXTO");
                pila.Push("=");
                pila.Push("ID_CADENA");

            }
            else
            {
                pila.Push(token.lexema);
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " \" " + token.contenido + " \" la variable no esta declarada");
            }
            /*
            else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Push(";");
                pila.Push("NUMERO_E");
                pila.Push("=");
                pila.Push("ID_BOOLEANO");

            }
            else if (token.lexema.Equals("ID_CARACTER"))
            {
                pila.Push(";");
                pila.Push("NUMERO_E");
                pila.Push("=");
                pila.Push("ID_CARACTER");
            }
            */
        }

        public void estado3(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("ENTERO"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("NUMERO_E");
                pila.Push("=");
                pila.Push("ID_ENTERO");
                pila.Push("ENTERO");
            }
            else if (token.lexema.Equals("DECIMAL"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("NUMERO_D");
                pila.Push("=");
                pila.Push("ID_DECIMAL");
                pila.Push("DECIMAL");

            }
            else if (token.lexema.Equals("CADENA"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("CAD_TEXTO");
                pila.Push("=");
                pila.Push("ID_CADENA");
                pila.Push("CADENA");

            }
            else
            {
                pila.Push(token.lexema);
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba declaracion u otro metodo");
            }
        }

        private Boolean isTerminal(String lexema)
        {
            foreach(String var in estadosTerminales)
            {
                if (var.Equals(lexema))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
