using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PROYECTO_LENGUAJES.Pila
{
    class AnalicisSintactico
    {
        private List<String> erroresSintaxis = new List<String>();

        private String[] estadosTerminales = {"PRICIPAL","(",")","{","}","ENTERO","DECIMAL","BOOLEANO","CARACTER","CADENA","ID_ENTERO", "ID_DECIMAL", "ID_BOOLEANO",
                                                "ID_CARACTER", "ID_CADENA","NUMERO_E","NUMERO_D","CAD_TEXTO",";","=","VERDADERO","FALSO","SI","MIENTRAS"};
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
                        escribirTransicion(token, pila);
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
                case "4":
                    estado4(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_E2":
                    ASIG_E2(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_E":
                    ASIG_E(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_EP":
                    ASIG_EP(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_D2":
                    ASIG_D2(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_D":
                    ASIG_D(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_DP":
                    ASIG_DP(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_S":
                    ASIG_S(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_SP":
                    ASIG_SP(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_S2":
                    ASIG_S2(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_B":
                    ASIG_B(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_BP":
                    ASIG_BP(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_B2":
                    ASIG_B2(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_C":
                    ASIG_C(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_CP":
                    ASIG_CP(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_C2":
                    ASIG_C2(token, pila);
                    respuesta = true;
                    break;
                case "LOGICA":
                    LOGICA(token, pila);
                    respuesta = true;
                    break;
                case "ESTADO_LOGICO":
                    ESTADO_LOGICO(token, pila);
                    respuesta = true;
                    break;
                case "NUM":
                    NUM(token, pila);
                    respuesta = true;
                    break;
                default:
                    errores.Add("Error en linea " + token.lineaUbicacion + " no se esperaba otro token");
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
            else
            {
                errores.Add("Error en linea " + token.lineaUbicacion + " se esperaba el inicio de clase \"principal\"");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
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
            else if (token.ID.Equals("ReservatedWord_TOKEN"))
            {
                pila.Push("4");
            }
            else if (token.lexema.Equals("}"))
            {
                //pila.Pop();
                pila.Pop();
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " no se esperaba \" "+token.contenido+" \" ");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void estado4(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("MIENTRAS"))
            {
                pila.Pop();
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");
                pila.Push("MIENTRAS");
            }
            else if (token.lexema.Equals("SI"))
            {
                pila.Pop();
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");
                pila.Push("SI");
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " no se esperaba \" " + token.contenido + " \" ");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        public void LOGICA(ID_token token, Stack<String> pila)
        {
            if (token.ID.Equals("BooleanState_TOKEN")||token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ESTADO_LOGICO");
            }
            else if (token.lexema.Equals("NUMERO_E")|| token.lexema.Equals("NUMERO_D") || token.lexema.Equals("ID_ENTERO") || token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("NUM");
                pila.Push("OP_RELACIONAL");
                pila.Push("NUM");
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una sentencia booleana");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void NUM(ID_token token, Stack<String> pila)
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
            } else if (token.lexema.Equals("ID_ENTERO"))
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
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una sentencia booleana");
                pila.Pop();
                pila.Push(token.lexema);
            }
        }
        public void ESTADO_LOGICO(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("VERDADERO"))
            {
                pila.Pop();
                pila.Push("VERDADERO");

            } else if (token.lexema.Equals("FALSO"))
            {
                pila.Pop();
                pila.Push("FALSO");

            } else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ID_BOOLEANO");
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una sentencia booleana");
                pila.Pop();
                pila.Push(token.lexema);
            }
        }
        public void estado2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ASIG_E");
                pila.Push("ID_ENTERO");

            }
            else if (token.lexema.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("ASIG_D");
                pila.Push("ID_DECIMAL");

            }
            else if (token.lexema.Equals("ID_CADENA"))
            {
                pila.Pop();
                pila.Push("ASIG_S");
                pila.Push("ID_CADENA");

            }
            else if (token.lexema.Equals("ID_BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ASIG_B");
                pila.Push("ID_BOOLEANO");

            }
            else if (token.lexema.Equals("ID_CARACTER"))
            {
                pila.Push("ASIG_C");
                pila.Push("ID_CARACTER");
            }
            else
            {
                pila.Pop();
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " \" " + token.contenido + " \" la variable no esta declarada");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }

        public void estado3(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("ENTERO"))
            {
                pila.Pop();
                pila.Push("ASIG_E2");
                pila.Push("ID_ENTERO");
                pila.Push("ENTERO");
            }
            else if (token.lexema.Equals("DECIMAL"))
            {
                pila.Pop();
                pila.Push("ASIG_D2");
                pila.Push("ID_DECIMAL");
                pila.Push("DECIMAL");

            }
            else if (token.lexema.Equals("CADENA"))
            {
                pila.Pop();
                pila.Push("ASIG_S2");
                pila.Push("ID_CADENA");
                pila.Push("CADENA");

            }
            else if (token.lexema.Equals("BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ASIG_B2");
                pila.Push("ID_BOOLEANO");
                pila.Push("BOOLEANO");
            }
            else if (token.lexema.Equals("CARACTER"))
            {
                pila.Pop();
                pila.Push("ASIG_C2");
                pila.Push("ID_CARACTER");
                pila.Push("CARACTER");
            }
            else
            {
                pila.Pop();
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba declaracion u otro metodo");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_E(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_EP");
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
        private void ASIG_D(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_DP");
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
        private void ASIG_S(ID_token token, Stack<String> pila)
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
        private void ASIG_B(ID_token token, Stack<String> pila)
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
        private void ASIG_C(ID_token token, Stack<String> pila)
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
        private void ASIG_E2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_EP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_D2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_DP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_S2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_SP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_B2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_BP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_C2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("="))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push("ASIG_CP");
                pila.Push("=");

            }
            else if (token.lexema.Equals(";"))
            {
                pila.Pop();
                pila.Push(";");
            }
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion o fin de declaracion");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_EP(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");
            }else if (token.lexema.Equals("ID_ENTERO"))
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
                errores.Add("Error en la linea "+token.lineaUbicacion+" se esperaba una asignacion de tipo entero");
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_DP(ID_token token, Stack<String> pila)
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
            }else if (token.lexema.Equals("NUMERO_D"))
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
        private void ASIG_SP(ID_token token, Stack<String> pila)
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
        private void ASIG_BP(ID_token token, Stack<String> pila)
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
        private void ASIG_CP(ID_token token, Stack<String> pila)
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

        private void ES_MIENTRAS(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("MIENTRAS"))
            {

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
        private void escribirTransicion(ID_token token, Stack<String> pila)
        {
            if (pila.Count > 0)
            {
                Console.WriteLine("Estado: " + pila.Peek() + " Lexema: " + token.lexema);
            }
        }
    }
}
