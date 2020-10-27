using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.ArbolSintactico
{
    class Arbol
    {
        private int numeroDeNodo = 0;
        private List<Nodo> _nodos = new List<Nodo>();
        private Nodo _raiz;
        private Nodo _raizTemporal=null;
        public Arbol()
        {

        }
        public void inicio()
        {
            this.raiz = new Nodo(0, null, "estado0");
            this.raizTemporal = this.raiz;
            this.nodos.Add(this.raiz);
            this.sumarNodo();
        }
        public void agregarNodo(String nombre)
        {
            Nodo tmp;
            tmp = new Nodo(numeroDeNodo, this.raizTemporal, nombre);
            this.nodos.Add(tmp);
            sumarNodo();
        }
        public void sumarNodo()
        {
            numeroDeNodo++;
        }
        public Nodo raizTemporal
        {
            get { return _raizTemporal; }
            set { _raizTemporal = value; }
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
        public string recuperarDOT()
        {
            GenerarDOT generar = new GenerarDOT();
            return generar.archivoDOT(this);
        }
    }
}
