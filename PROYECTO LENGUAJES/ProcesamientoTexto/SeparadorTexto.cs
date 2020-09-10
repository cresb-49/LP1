using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROYECTO_LENGUAJES.Elementos_de_Lengua;
namespace PROYECTO_LENGUAJES.ProcesamientoTexto
{
    class SeparadorTexto
    {
        private String[] operadoresAritmeticos = new String[] { "+", "-", "*", "/", "++", "--" };
        private String[] operadoresRelacionales = new String[] { ">", "<", ">=", "<=", "==", "!=" };
        private String[] operadoresLogicos = new String[] { "||", "&&", "!" };
        private String[] signoAgrupacion = new string[] { "(", ")" };
        private String asignacionDeSentencia = "=";
        private String finalizacionSentencia = ";";
        private String comillas = "\"";

        private int tamanoMax = 0;

        public SeparadorTexto()
        {

        }
        public List<String> lineasTexto(String textoAnalizar)
        {
            List<String> resultados = new List<String>();
            resultados = palabrasEncontadas(textoAnalizar);
            return resultados;
        }
        private String extraerTexto(String cadena, int inicio, int fin)
        {
            String temporal = "";
            for (int i = inicio; i <= fin; i++)
            {
                temporal = temporal + cadena.Substring(i, 1);
            }
            return temporal;
        }
        private int contadorEspacios(String cadenaProcesar)
        {
            int inicio = 0;
            int cantidadEspacios = 0;
            while (cadenaProcesar.IndexOf(" ", inicio) != -1)
            {
                if (cadenaProcesar.IndexOf(" ", inicio) > -1)
                {
                    cantidadEspacios++;
                    inicio = cadenaProcesar.IndexOf(" ", inicio) + 1;
                }
            }
            return cantidadEspacios;
        }
        public List<LOCATION_token> abstraccionTexto(String arreglo)
        {
            //agrega el caracter de finalizacion de lectura
            arreglo = arreglo + "  " + "\n";
            //List<String> palabras = new List<String>();
            List<LOCATION_token> token = new List<LOCATION_token>();
            
            int inicio = 0;
            int fin = 0;
            int legth = arreglo.Length;
            String apuntador1;
            String apuntador2;
            int i = 0;
            int numeroLinea = 1;
            Console.WriteLine("Tamano del texto: " + legth);
            for (i = 0; i < (legth - 1); i++)
            {
                apuntador1 = arreglo.Substring(i, 1);
                apuntador2 = arreglo.Substring((i + 1), 1);
                if(apuntador1.Equals("\n"))
                {
                    //Console.WriteLine(numeroLinea);
                    numeroLinea++;
                }

                if (!(apuntador1.Equals(" ")|| apuntador1.Equals("\n")|| apuntador1.Equals("\t")) && (apuntador2.Equals(" ")||apuntador2.Equals("\n") || apuntador2.Equals("\t")))
                {
                    fin = i;
                    String extraccion = extraerTexto(arreglo, inicio, fin);
                    //Console.WriteLine("Apuntador1: " + apuntador1);
                    //Console.WriteLine("Apuntador2: " + apuntador2);
                    Console.WriteLine("Aqui 1:" + extraccion + "---");
                    if (!extraccion.Equals(" ")&& !extraccion.Equals("\n") && !extraccion.Equals("") && !extraccion.Equals("\t"))
                    {
                        if (extraccion.Equals(comillas) || extraccion.StartsWith(comillas))
                        {
                            //inicio es el mismo de la cadena de segundo analicis
                            //Console.WriteLine("Candidato 1");
                            int saltoDeLinea = arreglo.IndexOf("\n", inicio);
                            //Console.WriteLine("Salto de linea: " + inicio);
                            int rango = saltoDeLinea - inicio;
                            int segundaComilla = arreglo.IndexOf(comillas, inicio + 1, rango);
                            //Console.WriteLine("inicio: "+inicio);
                            //Console.WriteLine("Segunda Comilla aqui 1: " + segundaComilla);
                            fin = segundaComilla;
                            if (fin < 0)
                            {
                                fin = saltoDeLinea-1;
                            }
                            extraccion = extraerTexto(arreglo, inicio, fin);
                            token.Add(new LOCATION_token(extraccion,numeroLinea));
                            //palabras.Add(extraccion);
                        
                            inicio = fin + 1;
                            i = fin - 1;
                        }
                        else
                        {
                            token.Add(new LOCATION_token(extraccion, numeroLinea));
                            //palabras.Add(extraccion);
                            if (apuntador2.Equals("\n"))
                            {
                                inicio = fin + 2;
                            }
                            else
                            {
                                inicio = fin + 1;
                            }
                        }
                    }
                }
                if ((apuntador1.Equals(" ")||apuntador1.Equals("\n") || apuntador1.Equals("\t")) && !(apuntador2.Equals(" ")||apuntador2.Equals("\n") || apuntador2.Equals("\t")))
                {
                    inicio = i + 1;
                }
                if (!(saltoPorSignoEspecial(apuntador1)) && saltoPorSignoEspecial(apuntador2))
                {
                    if (apuntador1.Equals(" "))
                    {
                        inicio = i + 1;
                    }
                    else
                    {
                        fin = i;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        //Console.WriteLine("Apuntador1: " + apuntador1);
                        //Console.WriteLine("Apuntador2: " + apuntador2);
                        Console.WriteLine("Aqui 2:" + extraccion + "---");
                        if (!extraccion.Equals(" ") && !extraccion.Equals("\n") && !extraccion.Equals("") && !extraccion.Equals("\t"))
                        {
                            if (extraccion.Equals(comillas) || extraccion.StartsWith(comillas))
                            {
                                //inicio es el mismo de la cadena de segundo analicis
                                //Console.WriteLine("Candidato aqui dos");
                                int saltoDeLinea = arreglo.IndexOf("\n", inicio);
                                //Console.WriteLine("Salto de linea: " + saltoDeLinea);
                                int rango = saltoDeLinea - inicio;
                                //Console.WriteLine("rango: " + rango);
                                int segundaComilla = arreglo.IndexOf(comillas, inicio + 1, rango);
                                //Console.WriteLine("inicio aqui dos: " + inicio);
                                //Console.WriteLine("Segunda comilla aqui dos: " + segundaComilla);
                                fin = segundaComilla;
                                if (fin < 0)
                                {
                                    fin = saltoDeLinea - 1;
                                }
                                extraccion = extraerTexto(arreglo, inicio, fin);
                                //palabras.Add(extraccion);
                                //Console.WriteLine("Verificacion linea:" + fin+"<>" + extraccion);
                                token.Add(new LOCATION_token(extraccion, numeroLinea));
                                inicio = fin + 1;
                                i = fin - 1;
                            }
                            else
                            {
                                //palabras.Add(extraccion);
                                token.Add(new LOCATION_token(extraccion, numeroLinea));
                                inicio = fin + 1;
                            }
                        }
                    }
                }
                if (saltoPorSignoEspecial(apuntador1) && !(saltoPorSignoEspecial(apuntador2)))
                {
                    if (apuntador2.Equals(" ")|| apuntador2.Equals("\n") || apuntador2.Equals("\t"))
                    {
                        if (apuntador2.Equals("\n"))
                        {
                            inicio = i + 2;
                        }
                        else
                        {
                            inicio = i + 1;
                        }
                    }
                    else
                    {

                        fin = i;
                        inicio = i;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        Console.WriteLine("Aqui 3:" + extraccion +"---");
                        //palabras.Add(extraccion);
                        token.Add(new LOCATION_token(extraccion, numeroLinea));
                        inicio = fin + 1;

                    }
                }
                if (igualdadesAceptadas(apuntador1, apuntador2))
                {
                    if (apuntador1.Equals("/") && apuntador2.Equals("/"))
                    {
                        inicio = i;
                        //fin = i + 1;
                        fin = arreglo.IndexOf("\n", i);
                        String extraccion = extraerTexto(arreglo, inicio, fin-1);
                        Console.WriteLine("aqui 6:" + extraccion + "---");
                        //palabras.Add(extraccion);
                        //token.Add(new LOCATION_token(extraccion, numeroLinea));
                        //inicio = fin + 1;
                        //extraccion = extraerTexto(arreglo, inicio, fin-1);
                        //Console.WriteLine("aqui 7: " + extraccion + "---");
                        //palabras.Add(extraccion);
                        token.Add(new LOCATION_token(extraccion, numeroLinea));

                        i = fin - 1;
                        inicio = fin + 1;
                    }
                    else
                    {
                        if(apuntador1.Equals("/") && apuntador2.Equals("*"))
                        {
                            inicio = i;
                            int ubicacionEspacio=i;
                            //fin = i + 1;
                            fin = arreglo.IndexOf("*/", i);
                            if (fin < 0)
                            {
                                fin = legth;
                            }

                            do
                            {
                                ubicacionEspacio = arreglo.IndexOf("\n", ubicacionEspacio + 1);
                                if (ubicacionEspacio < 0)
                                {
                                    break;
                                }
                                else
                                {
                                    numeroLinea++;
                                }
                            } while (ubicacionEspacio < fin);
                            numeroLinea--;
                            String extraccion = extraerTexto(arreglo, inicio, fin+1);
                            Console.WriteLine("aqui 7:" + extraccion + "---");
                            //palabras.Add(extraccion);
                            //token.Add(new LOCATION_token(extraccion, numeroLinea));
                            //inicio = fin + 1;
                            //extraccion = extraerTexto(arreglo, inicio, fin-1);
                            //Console.WriteLine("aqui 7: " + extraccion + "---");
                            //palabras.Add(extraccion);
                            token.Add(new LOCATION_token(extraccion, numeroLinea));

                            i = fin +1;
                            inicio = fin + 3;
                        }
                        else
                        {
                            inicio = i;
                            fin = i + 1;
                            String extraccion = extraerTexto(arreglo, inicio, fin);
                            Console.WriteLine("aqui 4:" + extraccion + "---");
                            //palabras.Add(extraccion);
                            token.Add(new LOCATION_token(extraccion, numeroLinea));
                            //apuntador1 = arreglo.Substring(fin+1, 1);
                            if (apuntador1.Equals("\n"))
                            {
                                inicio = i + 3;
                            }
                            else
                            {
                                inicio = i + 2;
                            }
                            i = i + 1;
                        }
                    }
                }
                else
                {
                    if (saltoPorSignoEspecial(apuntador1) && saltoPorSignoEspecial(apuntador2))
                    {
                        inicio = i;
                        fin = inicio;
                        String extraccion = extraerTexto(arreglo, inicio, fin);
                        if (apuntador1.Equals("\n"))
                        {
                            Console.WriteLine("deduction");
                        }
                        Console.WriteLine("aqui 5:" + extraccion + "---");
                        //palabras.Add(extraccion);
                        token.Add(new LOCATION_token(extraccion, numeroLinea));
                        inicio = i + 1;
                    }
                }
            }
            //Console.WriteLine(numeroLinea);
            //return palabras;
            return token;

        }

        private Boolean igualdadesAceptadas(String apuntador1, String apuntador2)
        {

            if (apuntador1.Equals("+") && apuntador2.Equals("+"))
            {
                return true;
            }
            if (apuntador1.Equals("-") && apuntador2.Equals("-"))
            {
                return true;
            }
            if (apuntador1.Equals("=") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("|") && apuntador2.Equals("|"))
            {
                return true;
            }
            if (apuntador1.Equals("&") && apuntador2.Equals("&"))
            {
                return true;
            }
            if (apuntador1.Equals(">") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("<") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("!") && apuntador2.Equals("="))
            {
                return true;
            }
            if (apuntador1.Equals("/") && apuntador2.Equals("*"))
            {
                return true;
            }
            if (apuntador1.Equals("*") && apuntador2.Equals("/"))
            {
                return true;
            }
            if (apuntador1.Equals("/") && apuntador2.Equals("/"))
            {
                return true;
            }
            return false;
        }
        private Boolean saltoPorSignoEspecial(String cadena)
        {
            foreach (String valor in operadoresAritmeticos)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in operadoresAritmeticos)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in operadoresRelacionales)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in operadoresLogicos)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            foreach (String valor in signoAgrupacion)
            {
                if (cadena.Equals(valor))
                {
                    return true;
                }
            }
            if (cadena.Equals(asignacionDeSentencia))
            {
                return true;
            }
            if (cadena.Equals(finalizacionSentencia))
            {
                return true;
            }
            return false;
        }
        public List<String> palabrasEncontadas(String arreglo)
        {

            List<String> palabras = new List<String>();
            List<String> subProcesadopalabras = new List<String>();
            int inicio = 0;
            int fin = 0;
            fin = arreglo.IndexOf(" ") - 1;
            for (int i = 0; i < contadorEspacios(arreglo); i++)
            {
                palabras.Add(extraerTexto(arreglo, inicio, fin));
                inicio = fin + 2;
                fin = arreglo.IndexOf(" ", inicio) - 1;
            }
            fin = (arreglo.Length) - 1;
            String textoEncontrado = extraerTexto(arreglo, inicio, fin);
            palabras.Add(textoEncontrado);
            foreach (String cadena in palabras)
            {
                if (!cadena.Equals(""))
                {
                    subProcesadopalabras.Add(cadena);
                }
            }
            return subProcesadopalabras;
        }
        public void ContadorCaracteres(String cadena)
        {
            int tam = 0;
            tam = cadena.Length;
            if (tamanoMax <= tam)
            {
                this.tamanoMax = tam;
            }
        }
        public int getTamanoMax()
        {
            return this.tamanoMax;
        }
    }
}
