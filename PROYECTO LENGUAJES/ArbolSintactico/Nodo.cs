using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_LENGUAJES.ArbolSintactico
{
    class Nodo
    {
        private int _numero;
        private Nodo _padre;
        private List<Nodo> _hijos = new List<Nodo>();
        private String _nombre;
        public Nodo()
        {

        }
        public Nodo(int numero, Nodo padre,String nombre)
        {
            this.numero = numero;
            this.padre = padre;
            this.nombre = nombre;
        }
        public int numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public Nodo padre
        {
            get { return _padre; }
            set { _padre = value; }
        }

        public List<Nodo> hijos
        {
            get { return _hijos; }
            set { _hijos = value; }
        }
        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public String asignacionGraphviz()
        {
            return "nodo"+this.numero+"[label=\""+this.nombre+"\"];";
        }
        public String nombreGraphviz()
        {
            return "nodo" + this.numero;
        }
        public String relacionPadreHijo()
        {
            if (padre == null)
            {
                return "";
            }
            else
            {
                return this.padre.nombreGraphviz() + " -- " + this.nombreGraphviz();
            }
        }
    }
}
