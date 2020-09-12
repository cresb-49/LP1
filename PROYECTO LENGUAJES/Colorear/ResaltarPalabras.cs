using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_LENGUAJES.Colorear
{
    class ResaltarPalabras
    {
        public ResaltarPalabras()
        {

        }
        public void colorearTexto(RichTextBox campoDeTexto, List<ID_token> tokens)
        {
            Color color;
            int pos = campoDeTexto.SelectionStart;
            campoDeTexto.SelectAll();
            campoDeTexto.SelectionColor = Color.Black;
            foreach (ID_token cadena in tokens)
            {
                campoDeTexto.SelectionStart = cadena.getInicioCadena();
                campoDeTexto.SelectionLength = cadena.getContenido().Length;
                campoDeTexto.SelectionColor = cadena.getColorDeTexto();

                //Restauracion de valores originales de posicion en richbox text
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
        }
    }
}
