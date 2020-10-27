using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
