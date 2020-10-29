using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PROYECTO_LENGUAJES.ManejoArchivos;

namespace PROYECTO_LENGUAJES.ArbolSintactico
{
    class GenerarDOT
    {
        private Archivos manejadorArchivos = new Archivos();
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

            try
            {
                File.Delete(fileOutputPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe");
                startInfo.Arguments = "-Tpng " + fileInputPath + " -o " + fileOutputPath;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Al parecer no tienes instalado Graphviz\nInstalalo para poder utilizar esta funcionalidad ;)", "Funcionalidad Recortada");
            }
            
        }
        
    }
}
