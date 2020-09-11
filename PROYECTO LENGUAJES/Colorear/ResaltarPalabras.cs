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
        public void Resaltado(RichTextBox box, string palabra, Color color)
        {
            int pos = box.SelectionStart;
            box.SelectAll();
            box.SelectionColor = Color.Black;
            string s = box.Text;
            for (int ix = 0; ;)
            {
                int jx = s.IndexOf(palabra, ix, StringComparison.CurrentCultureIgnoreCase);
                if (jx < 0) break;
                box.SelectionStart = jx;
                box.SelectionLength = palabra.Length;
                box.SelectionColor = color;
                ix = jx + 1;
            }
            box.SelectionStart = pos;
            box.SelectionLength = 0;
        }
    }
}
