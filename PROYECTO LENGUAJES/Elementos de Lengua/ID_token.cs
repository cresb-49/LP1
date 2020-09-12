using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class ID_token
    {
        private String ID;
        private String contenido;
        private int lineaUbicacion;
        private int inicioCadena;
        private Color colorDeTexto;

        public ID_token(String ID, String contenido, int ubicacion,int inicioCadena,Color colorTexto)
        {
            this.ID = ID;
            this.contenido = contenido;
            this.lineaUbicacion = ubicacion;
            this.inicioCadena = inicioCadena;
            this.colorDeTexto = colorTexto;
            ColorEspecial(contenido);
        }

        private void ColorEspecial(String tipo)
        {
            if (tipo.Equals("entero"))
            {
                this.colorDeTexto = Color.Purple;
            }
            if (tipo.Equals("decimal"))
            {
                this.colorDeTexto = Color.AliceBlue;
            }
            if (tipo.Equals("cadena"))
            {
                this.colorDeTexto = Color.Gray;
            }
            if (tipo.Equals("booleano"))
            {
                this.colorDeTexto = Color.Orange;
            }
            if (tipo.Equals("caracter"))
            {
                this.colorDeTexto = Color.Brown;
            }
        }

        public String getID()
        {
            return this.ID;
        }
        public void setID(String nombre)
        {
            this.ID = nombre;
        }
        public String getContenido()
        {
            return this.contenido;
        }
        public void setContenido(String tipo)
        {
            this.contenido = tipo;
        }
        public int getUbicacion()
        {
            return this.lineaUbicacion;
        }
        public void setUbicacion(int ubicacion)
        {
            this.lineaUbicacion = ubicacion;
        }
        public int getInicioCadena()
        {
            return this.inicioCadena;
        }
        public Color getColorDeTexto()
        {
            return this.colorDeTexto;
        }
    }
}
