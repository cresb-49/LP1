using System;
using System.Drawing;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class ID_token : Token
    {

        public ID_token(String ID, String contenido, int ubicacion, int inicioCadena, Color colorTexto)
            : base(ID,null, contenido, ubicacion, inicioCadena, colorTexto)
        {
            ColorEspecial(contenido);
        }

        private void ColorEspecial(String tipo)
        {
            if (tipo.Equals("entero"))
            {
                this.colorDeTexto = Color.BlueViolet;
            }
            if (tipo.Equals("decimal"))
            {
                this.colorDeTexto = Color.Cyan;
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
    }
}
