using System;
using System.Diagnostics;

namespace PROYECTO_LENGUAJES.ArbolSintactico
{
    class GenerarDOT
    {
        public GenerarDOT()
        {

        }

        public String archivoDOT(Arbol arbol)
        {
            String doc = "";
            doc = "digraph Arbol{\n";
            //Declaracion de los nodos del arbol
            foreach(Nodo nodo in arbol.nodos)
            {
                doc = doc+ nodo.asignacionGraphviz() + "\n";
            }
            //Declaracion de las realciones de los nodos del arbol
            foreach (Nodo nodo in arbol.nodos)
            {
                doc = doc + nodo.relacionPadreHijo() + "\n";
            }
            doc = doc + "}\n";
            return doc;
        }
        public void generarGrafico()
        {
            String fileInputPath = "C:\\temp\\grafo.dot";
            String fileOutputPath = "C:\\temp\\grafo.png";
            ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe");
            startInfo.Arguments = "-Tpng "+fileInputPath+" -o "+fileOutputPath;
            Process.Start(startInfo);
        }
        
    }
}
