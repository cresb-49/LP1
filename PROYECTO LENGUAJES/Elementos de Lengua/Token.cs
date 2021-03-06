﻿using System;
using System.Drawing;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class Token
    {
        private String _ID;
        private String _lexema;
        private String _contenido;
        private int _lineaUbicacion;
        private int _inicioCadena;
        private Color _colorDeTexto;

        public Token(String ID, String lexema, String contenido, int lineaUbicacion, int inicioCadena, Color colorDeTexto)
        {
            this._ID = ID;
            this._contenido = contenido;
            this._lineaUbicacion = lineaUbicacion;
            this._inicioCadena = inicioCadena;
            this._colorDeTexto = colorDeTexto;

        }
        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public String lexema
        {
            get { return _lexema; }
            set { _lexema = value; }
        }
        public String contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }
        public int lineaUbicacion
        {
            get { return _lineaUbicacion; }
            set { _lineaUbicacion = value; }
        }
        public int inicioCadena
        {
            get { return _inicioCadena; }
            set { _inicioCadena = value; }
        }
        public Color colorDeTexto
        {
            get { return _colorDeTexto; }
            set { _colorDeTexto = value; }
        }
    }
}
