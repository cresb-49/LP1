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
            Console.WriteLine("Agregando el nodo: " + nombre);
            Nodo tmp;
            tmp = new Nodo(numeroDeNodo, this.raizTemporal, nombre);
            this.nodos.Add(tmp);
            this.raizTemporal.hijos.Add(tmp);
            sumarNodo();
        }
        public void escalarArbol()
        {
            Nodo tmp = this.raizTemporal;
            if (tmp.padre == null)
            {
                raizTemporal = tmp;
            }
            else
            {
                raizTemporal = tmp.padre;
            }
        }
        public Nodo retornarNodo(String nombre)
        {
            Nodo tmp = null;
            Console.WriteLine("Nodo buscado: " + nombre);
            foreach (Nodo nodo in this.raizTemporal.hijos)
            {
                if (nodo.nombre.Equals(nombre))
                {
                    Console.WriteLine("Nodo encontardo: " + nodo.nombre);
                    tmp = nodo;
                }
            }
            return tmp;
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
