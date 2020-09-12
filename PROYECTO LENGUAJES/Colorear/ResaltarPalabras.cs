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
        private String[] cadenasAzules = new String[] { "+", "-", "*", "/", "++", "--", ">", "<", ">=", "<=", "==", "!=", "||", "&&", "!", "(", ")"};
        private String[] cadenasVerdes = new String[] { "SI", "SINO", "SINO_SI", "MENTRAS", "HACER", "DESDE", "HASTA", "INCREMENTO" };
        private String[] cadenasNaranjas = new String[] { "verdadero", "falso" };
        private String[] cadenasRosa = new String[] { "=", ";" };

        public ResaltarPalabras()
        {

        }
        public void Resaltado(RichTextBox campoDeTexto)
        {
            Color color;
            int pos = campoDeTexto.SelectionStart;
            campoDeTexto.SelectAll();
            campoDeTexto.SelectionColor = Color.Black;
            string s = campoDeTexto.Text;
            color = Color.Blue;
            foreach (String cadena in cadenasAzules)
            {
                for (int ubicacion = 0; ;)
                {
                    int resultado = s.IndexOf(cadena, ubicacion, StringComparison.CurrentCultureIgnoreCase);
                    if (resultado < 0) break;
                    campoDeTexto.SelectionStart = resultado;
                    campoDeTexto.SelectionLength = cadena.Length;
                    campoDeTexto.SelectionColor = color;
                    ubicacion = resultado + 1;
                }
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
            color = Color.Green;
            foreach (String cadena in cadenasVerdes)
            {
                for (int ubicacion = 0; ;)
                {
                    int resultado = s.IndexOf(cadena, ubicacion, StringComparison.CurrentCultureIgnoreCase);
                    if (resultado < 0) break;
                    campoDeTexto.SelectionStart = resultado;
                    campoDeTexto.SelectionLength = cadena.Length;
                    campoDeTexto.SelectionColor = color;
                    ubicacion = resultado + 1;
                }
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
            color = Color.Orange;
            foreach (String cadena in cadenasNaranjas)
            {
                for (int ubicacion = 0; ;)
                {
                    int resultado = s.IndexOf(cadena, ubicacion, StringComparison.CurrentCultureIgnoreCase);
                    if (resultado < 0) break;
                    campoDeTexto.SelectionStart = resultado;
                    campoDeTexto.SelectionLength = cadena.Length;
                    campoDeTexto.SelectionColor = color;
                    ubicacion = resultado + 1;
                }
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
            color = Color.Pink;
            foreach (String cadena in cadenasRosa)
            {
                for (int ubicacion = 0; ;)
                {
                    int resultado = s.IndexOf(cadena, ubicacion, StringComparison.CurrentCultureIgnoreCase);
                    if (resultado < 0) break;
                    campoDeTexto.SelectionStart = resultado;
                    campoDeTexto.SelectionLength = cadena.Length;
                    campoDeTexto.SelectionColor = color;
                    ubicacion = resultado + 1;
                }
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
            color = Color.Red;
            foreach (String cadena in cadenasRosa)
            {
                for (int ubicacion = 0; ;)
                {
                    int resultado = s.IndexOf("//", ubicacion, StringComparison.CurrentCultureIgnoreCase);
                    if (resultado < 0) break;
                    campoDeTexto.SelectionStart = resultado;
                    int largoSeleccion = s.IndexOf("\n", resultado, StringComparison.CurrentCultureIgnoreCase);
                    if (largoSeleccion < 0) break;
                    //campoDeTexto.SelectionLength = cadena.Length;
                    campoDeTexto.SelectionLength = largoSeleccion;
                    campoDeTexto.SelectionColor = color;
                    ubicacion = resultado + 1;
                }
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
        }
        public void colorearTexto(RichTextBox campoDeTexto, List<ID_token> tokens)
        {
            Color color;
            int pos = campoDeTexto.SelectionStart;
            campoDeTexto.SelectAll();
            campoDeTexto.SelectionColor = Color.Black;
            string s = campoDeTexto.Text;
            color = Color.Blue;
            foreach (ID_token cadena in tokens)
            {
                campoDeTexto.SelectionStart = cadena.getInicioCadena();
                campoDeTexto.SelectionLength = cadena.getContenido().Length;
                campoDeTexto.SelectionColor = cadena.getColorDeTexto();

                //Restauracion de valores originales
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
        }
    }
}
