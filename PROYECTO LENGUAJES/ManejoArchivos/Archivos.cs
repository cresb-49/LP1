using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PROYECTO_LENGUAJES.ManejoArchivos
{
    class Archivos
    {
        public Archivos()
        {

        }
        public void EscrituraArchivo(String src, String texto)
        {
            TextWriter escritura = new StreamWriter(src);
            try
            {
                escritura.WriteLine(texto);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                escritura.Close();
            }
        }
        public String LecturaArchivo(String src)
        {
            String archivoLeido="";
            TextReader lecturaArchivo = new StreamReader(src);
            try
            {
                archivoLeido = lecturaArchivo.ReadToEnd();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                lecturaArchivo.Close();
            }
            return archivoLeido;
        }

    }
}
