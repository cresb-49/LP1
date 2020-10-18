using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PROYECTO_LENGUAJES.ProcesamientoTexto
{
    class SeparadorTexto
    {
        private String[] operadoresAritmeticos = new String[] { "+", "-", "*", "/", "++", "--" };
        private String[] operadoresRelacionales = new String[] { ">", "<", ">=", "<=", "==", "!=" };
        private String[] operadoresLogicos = new String[] { "||", "&&", "!" };
        private String[] signoAgrupacion = new string[] { "(", ")", "{", "}" };
        private String asignacionDeSentencia = "=";
        private String finalizacionSentencia = ";";
        private String separadorVarables = ",";
        private String comillas = "\"";


        public SeparadorTexto()
        {

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
        public List<LOCATION_token> abstraccionTexto(String arreglo)
        {
            arreglo = arreglo + "  " + "\n";
            List<LOCATION_token> token = new List<LOCATION_token>();

            int inicio = 0;
            int fin = 0;
            int legth = arreglo.Length;
            String apuntador1;
            String apuntador2;
            int i = 0;
            int numeroLinea = 1;
            for (i = 0; i < (legth - 1); i++)
            {
                apuntador1 = arreglo.Substring(i, 1);
                apuntador2 = arreglo.Substring((i + 1), 1);
                if (apuntador1.Equals("\n"))
                {
                    numeroLinea++;
                }

                if (!(apuntador1.Equals(" ") || apuntador1.Equals("\n") || apuntador1.Equals("\t")) && (apuntador2.Equals(" ") || apuntador2.Equals("\n") || apuntador2.Equals("\t")))
                {
                    fin = i;
                    String extraccion = extraerTexto(arreglo, inicio, fin);
                    if (!extraccion.Equals(" ") && !extraccion.Equals("\n") && !extraccion.Equals("") && !extraccion.Equals("\t"))
                    {
                        if (extraccion.Equals(comillas) || extraccion.StartsWith(comillas))
                        {
                            //inicio es el mismo de la cadena de segundo analicis
                            int saltoDeLinea = arreglo.IndexOf("\n", inicio);
                            int rango = saltoDeLinea - inicio;
                            int segundaComilla = arreglo.IndexOf(comillas, inicio + 1, rango);
                            fin = segundaComilla;
                            if (fin < 0)
                            {
                                fin = saltoDeLinea - 1;
                            }
                            extraccion = extraerTexto(arreglo, inicio, fin);
                            token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));

                            inicio = fin + 1;
                            i = fin - 1;
                        }
                        else
                        {
                            token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));
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
                if ((apuntador1.Equals(" ") || apuntador1.Equals("\n") || apuntador1.Equals("\t")) && !(apuntador2.Equals(" ") || apuntador2.Equals("\n") || apuntador2.Equals("\t")))
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
                        ////Console.WriteLine("Aqui 2:" + extraccion + "---");
                        if (!extraccion.Equals(" ") && !extraccion.Equals("\n") && !extraccion.Equals("") && !extraccion.Equals("\t"))
                        {
                            if (extraccion.Equals(comillas) || extraccion.StartsWith(comillas))
                            {
                                int saltoDeLinea = arreglo.IndexOf("\n", inicio);
                                int rango = saltoDeLinea - inicio;
                                int segundaComilla = arreglo.IndexOf(comillas, inicio + 1, rango);
                                fin = segundaComilla;
                                if (fin < 0)
                                {
                                    fin = saltoDeLinea - 1;
                                }
                                extraccion = extraerTexto(arreglo, inicio, fin);
                                token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));
                                inicio = fin + 1;
                                i = fin - 1;
                            }
                            else
                            {
                                token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));
                                inicio = fin + 1;
                            }
                        }
                    }
                }
                if (saltoPorSignoEspecial(apuntador1) && !(saltoPorSignoEspecial(apuntador2)))
                {
                    if (apuntador2.Equals(" ") || apuntador2.Equals("\n") || apuntador2.Equals("\t"))
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
                        ////Console.WriteLine("Aqui 3:" + extraccion +"---");
                        token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));
                        inicio = fin + 1;

                    }
                }
                if (igualdadesAceptadas(apuntador1, apuntador2))
                {
                    if (apuntador1.Equals("/") && apuntador2.Equals("/"))
                    {
                        inicio = i;
                        fin = arreglo.IndexOf("\n", i);
                        String extraccion = extraerTexto(arreglo, inicio, fin - 1);
                        ////Console.WriteLine("aqui 6:" + extraccion + "---");
                        token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));

                        i = fin - 1;
                        inicio = fin + 1;
                    }
                    else
                    {
                        if (apuntador1.Equals("/") && apuntador2.Equals("*"))
                        {
                            int tempNumLinea = numeroLinea;
                            inicio = i;
                            int ubicacionEspacio = i;
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

                            String extraccion;
                            if (fin == legth)
                            {
                                extraccion = extraerTexto(arreglo, inicio, fin - 1);
                            }
                            else
                            {
                                extraccion = extraerTexto(arreglo, inicio, fin + 1);
                            }

                            token.Add(new LOCATION_token(extraccion, tempNumLinea, inicio));
                            ////Console.WriteLine("aqui 7:" + extraccion + "---");
                            i = fin + 1;
                            inicio = fin + 3;
                        }
                        else
                        {
                            inicio = i;
                            fin = i + 1;
                            String extraccion = extraerTexto(arreglo, inicio, fin);
                            ////Console.WriteLine("aqui 4:" + extraccion + "---");
                            token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));
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
                        ////Console.WriteLine("aqui 5:" + extraccion + "---");
                        token.Add(new LOCATION_token(extraccion, numeroLinea, inicio));
                        inicio = i + 1;
                    }
                }
            }
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
            if (cadena.Equals(separadorVarables))
            {
                return true;
            }
            return false;
        }
    }
}
