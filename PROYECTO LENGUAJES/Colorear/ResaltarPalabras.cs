﻿using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using PROYECTO_LENGUAJES.ProcesamientoTexto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        //Este metodo solo se utliza al principio cuando se carga el docuemento a editar
        public void colorearTexto(RichTextBox campoDeTexto, List<ID_token> tokens)
        {
            Color color;
            //posicion donde se encuntra el apuntador antes de iniciar el metodo
            int pos = campoDeTexto.SelectionStart;
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
        public void colorearTextoSegunLinea(RichTextBox campoDeTexto, List<ID_token> tokens,int linea)
        {
            Color color;
            //posicion donde se encuntra el apuntador antes de iniciar el metodo
            int pos = campoDeTexto.SelectionStart;
            foreach (ID_token cadena in tokens)
            {
                if (cadena.getUbicacion() == linea)
                {
                    campoDeTexto.SelectionStart = cadena.getInicioCadena();
                    campoDeTexto.SelectionLength = cadena.getContenido().Length;
                    campoDeTexto.SelectionColor = cadena.getColorDeTexto();
                }

                //Restauracion de valores originales de posicion en richbox text
                campoDeTexto.SelectionStart = pos;
                campoDeTexto.SelectionLength = 0;
            }
        }
    }
}
