﻿using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using PROYECTO_LENGUAJES.Sintactico;
using PROYECTO_LENGUAJES.ArbolSintactico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PROYECTO_LENGUAJES.Pila
{
    class AnalicisSintactico
    {
        private List<String> erroresSintaxis = new List<String>();
        private Arbol arbolSintactico = new Arbol();

        private String[] estadosTerminales = {"PRICIPAL","(",")","{","}","-","+","--","++","/","*","ENTERO","DECIMAL","BOOLEANO","CARACTER","CADENA","ID_ENTERO", "ID_DECIMAL", "ID_BOOLEANO",
                                                "ID_CARACTER", "ID_CADENA","NUMERO_E","NUMERO_D","CAD_TEXTO",";","=","VERDADERO","FALSO","SI","MIENTRAS","HACER","DESDE",
                                                "HASTA","INCREMENTO","&&","||","$","SINO","SINO_SI",","};
        
        //CLASE RESPECTIVA A LA ASIGNACION DE VARIABLES
        private AsignacionVar asignacionVariables = new AsignacionVar();
        private ExprecionesLogicas expLogicas = new ExprecionesLogicas();


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
                //Agregacion de la raiz del arbol sintactico
                arbolSintactico.inicio();
                ///////////////////////////////////////////
                ID_token token;
                Boolean res=false;
                for(int j = 0; j < tokes.Count; j++)
                {
                    token = tokes.ElementAt(j);
                    do
                    {
                        res = verificacionTerminal(token, pila);
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
            if (pila.Count == 0)
            {
                return false;
            }
            if (token.lexema.Equals(pila.Peek()))
            {
                Console.WriteLine("Se encontro igual: T = " + token.lexema + " P = " + pila.Peek());
                pila.Pop();
                return false;
            }
            else
            {
                if (isTerminal(pila.Peek()))
                {

                    errores.Add("Error en la linea " + token.lineaUbicacion + " se esperaba " + " \""+pila.Peek()+" \" ");
                    pila.Pop();
                    //pila.Push(token.lexema);
                    escribirTransicion(token, pila);
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
                    this.asignacionVariables.ASIG_E2(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_E":
                    this.asignacionVariables.ASIG_E(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_EP":
                    this.asignacionVariables.ASIG_EP(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_D2":
                    this.asignacionVariables.ASIG_D2(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_D":
                    this.asignacionVariables.ASIG_D(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_DP":
                    this.asignacionVariables.ASIG_DP(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_S":
                    this.asignacionVariables.ASIG_S(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_SP":
                    this.asignacionVariables.ASIG_SP(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_S2":
                    this.asignacionVariables.ASIG_S2(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_B":
                    this.asignacionVariables.ASIG_B(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_BP":
                    this.asignacionVariables.ASIG_BP(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_B2":
                    this.asignacionVariables.ASIG_B2(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_C":
                    this.asignacionVariables.ASIG_C(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_CP":
                    this.asignacionVariables.ASIG_CP(token, pila,errores);
                    respuesta = true;
                    break;
                case "ASIG_C2":
                    this.asignacionVariables.ASIG_C2(token, pila,errores);
                    respuesta = true;
                    break;
                case "LOGICA":
                    this.expLogicas.LOGICA(token, pila,errores);
                    respuesta = true;
                    break;
                case "LOGICA2":
                    this.expLogicas.LOGICA2(token, pila);
                    respuesta = true;
                    break;
                case "ESTADO_LOGICO":
                    this.expLogicas.ESTADO_LOGICO(token, pila,errores);
                    respuesta = true;
                    break;
                case "NUM":
                    this.expLogicas.NUM(token, pila,errores);
                    respuesta = true;
                    break;
                case "NUM2":
                    this.expLogicas.NUM2(token, pila);
                    respuesta = true;
                    break;
                case "ASIG":
                    ASIG(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_P":
                    ASIG_P(token,pila);
                    respuesta = true;
                    break;
                case "ES_SI_2":
                    ES_SI_2(token, pila);
                    respuesta = true;
                    break;
                case "EXP":
                    EXP(token, pila);
                    respuesta = true;
                    break;
                case "EXP_P":
                    EXP_P(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_EP2":
                    this.asignacionVariables.ASIG_EP2(token, pila);
                    respuesta = true;
                    break;
                case "ASIG_DP2":
                    this.asignacionVariables.ASIG_DP2(token, pila);
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

                arbolSintactico.agregarNodo("PRINCIPAL");
                arbolSintactico.agregarNodo("(");
                arbolSintactico.agregarNodo(")");
                arbolSintactico.agregarNodo("{");
                arbolSintactico.agregarNodo("estado1");
                arbolSintactico.agregarNodo("}");
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
            else if (token.lexema.Equals("COMENTARIO"))
            {
                ///la produccion genera el estado terminal de tipo COMENTARIO
                pila.Push("COMENTARIO");
            }
            else
            {
                pila.Pop();
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
                pila.Push("ES_SI_2");
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");
                pila.Push("SI");
            }
            else if (token.lexema.Equals("HACER"))
            {
                pila.Pop();
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");
                pila.Push("MIENTRAS");
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push("HACER");
            }
            else if (token.lexema.Equals("DESDE"))
            {
                pila.Pop();
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push("ASIG_EP2");
                pila.Push("INCREMENTO");
                pila.Push("LOGICA");
                pila.Push("HASTA");
                pila.Push("ASIG");
                pila.Push("DESDE");
            }
            else if (token.lexema.Equals("IMPRIMIR"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push(")");
                pila.Push("EXP");
                pila.Push("(");
                pila.Push("IMPRIMIR");
            }
            else if (token.lexema.Equals("LEER"))
            {
                pila.Pop();
                pila.Push(";");
                pila.Push(")");
                pila.Push("ID_CADENA");
                pila.Push("(");
                pila.Push("LEER");
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " no se esperaba \" " + token.contenido + " \" ");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void EXP(ID_token token, Stack<String> pila)
        {
            String lexTemp = token.lexema;
            if (lexTemp.Equals("CAD_TEXTO")|| lexTemp.Equals("ID_CADENA")|| lexTemp.Equals("NUMERO_E")|| lexTemp.Equals("ID_ENTERO")|| lexTemp.Equals("NUMERO_D")|| lexTemp.Equals("ID_DECIMAL"))
            {
                pila.Pop();
                pila.Push("EXP_P");
                pila.Push(token.lexema);
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se espera una variable contenedora o una cantidad numerica");
                pila.Pop();
                pila.Push(token.lexema);
            }
        }
        private void EXP_P(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("+"))
            {
                pila.Pop();
                pila.Push("EXP");
                pila.Push("+");
            }
            else
            {
                pila.Pop();
            }
        }
        private void ES_SI_2(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("SINO"))
            {
                pila.Pop();
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push("SINO");
            }
            else if (token.lexema.Equals("SINO_SI"))
            {
                pila.Push("ES_SI_2");
                pila.Pop();
                pila.Push("}");
                pila.Push("1");
                pila.Push("{");
                pila.Push(")");
                pila.Push("LOGICA");
                pila.Push("(");
                pila.Push("SINO_SI");
            }
            else
            {
                pila.Pop();
            }
            escribirTransicion(token, pila);
        }
        private void ASIG(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ASIG_EP2");
                pila.Push("=");
                pila.Push("ID_ENTERO");
            } 
            else if (token.lexema.Equals("ENTERO"))
            {
                pila.Pop();
                pila.Push("ASIG_EP2");
                pila.Push("=");
                pila.Push("ID_ENTERO");
                pila.Push("ENTERO");
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una referencia de tipo entero");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
        }
        private void ASIG_P(ID_token token, Stack<String> pila)
        {
            if (token.lexema.Equals("ID_ENTERO"))
            {
                pila.Pop();
                pila.Push("ID_ENTERO");
            }
            else if (token.lexema.Equals("NUMERO_E"))
            {
                pila.Pop();
                pila.Push("NUMERO_E");
            }
            else
            {
                erroresSintaxis.Add("Error en la linea " + token.lineaUbicacion + " se esperaba una asignacion de tipo entera");
                pila.Pop();
                pila.Push(token.lexema);
            }
            escribirTransicion(token, pila);
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
                pila.Push("ENTERO");
            }
            else if (token.lexema.Equals("DECIMAL"))
            {
                pila.Pop();
                pila.Push("ASIG_D2");
                pila.Push("DECIMAL");

            }
            else if (token.lexema.Equals("CADENA"))
            {
                pila.Pop();
                pila.Push("ASIG_S2");
                pila.Push("CADENA");

            }
            else if (token.lexema.Equals("BOOLEANO"))
            {
                pila.Pop();
                pila.Push("ASIG_B2");
                pila.Push("BOOLEANO");
            }
            else if (token.lexema.Equals("CARACTER"))
            {
                pila.Pop();
                pila.Push("ASIG_C2");
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

        public Arbol retornarArbol
        {
            get { return arbolSintactico; }
        }
    }
}
