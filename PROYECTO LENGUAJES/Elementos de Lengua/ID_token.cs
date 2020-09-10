using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class ID_token
    {
        private String ID;
        private String tipo;
        private int lineaUbicacion;

        public ID_token(String ID, String tipo, int ubicacion)
        {
            this.ID = ID;
            this.tipo = tipo;
            this.lineaUbicacion = ubicacion;
        }

        public String getNombre()
        {
            return this.ID;
        }
        public void setNombre(String nombre)
        {
            this.ID = nombre;
        }
        public String getTipo()
        {
            return this.tipo;
        }
        public void setTipo(String tipo)
        {
            this.tipo = tipo;
        }
        public int getUbicacion()
        {
            return this.lineaUbicacion;
        }
        public void setUbicacion(int ubicacion)
        {
            this.lineaUbicacion = ubicacion;
        }
    }
}
