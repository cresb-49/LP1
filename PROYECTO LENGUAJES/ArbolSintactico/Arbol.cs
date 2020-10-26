using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.ArbolSintactico
{
    class Arbol
    {
        private List<Nodo> _nodos;
        private Nodo _raiz;
        public Arbol()
        {

        }
        public List<Nodo> nodos
        {
            get { return _nodos; }
            set { _nodos = value; }
        }
        public Nodo raiz
        {
            get { return _raiz; }
            set { _raiz = value; }
        }
    }
}
