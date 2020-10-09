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
            else
            {
                errores.Add("Error en linea " + token.lineaUbicacion + " se esperaba el inicio de clase \"principal\"");
                pila.Pop();
                pila.Push(token.lexema);
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
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " no se esperaba \" "+token.contenido+" \" ");
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
                pila.Push(";");
                pila.Push("CAD_TEXTO");
                pila.Push("=");
                pila.Push("ID_CADENA");

            }
            else
            {
                pila.Pop();
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " \" " + token.contenido + " \" la variable no esta declarada");
                pila.Push(token.lexema);
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
                pila.Push(";");
                pila.Push("CAD_TEXTO");
                pila.Push("=");
                pila.Push("ID_CADENA");
                pila.Push("CADENA");

            }
            else
            {
                //pila.Pop();
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba declaracion u otro metodo");
                pila.Push(token.lexema);
            }
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
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo entero");
                pila.Push(token.lexema);
            }
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
            else
            {
                pila.Pop();
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo decimal u entera");
                pila.Push(token.lexema);
            }
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
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" " + token.contenido + " \" no esta declarada");
                }
                errores.Add("Error en la linea "+token.lineaUbicacion+" se esperaba una asignacion de tipo entero");
                pila.Push(token.lexema);
            }
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
                    errores.Add("Error en la linea " + token.lineaUbicacion + " la variable \" "+token.contenido+" \" no esta declarada");
                }
                errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo decimal u entera");
                pila.Push(token.lexema);
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
