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
            StreamWriter escritura = File.CreateText(src);
            try
            {
                escritura.Write(texto);
                escritura.Flush();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                escritura.Close();
            }
        }
        public void CrearArchivo(String src)
        {   
            try
            {
                StreamWriter crear = File.CreateText(src);
                crear.Flush();
                crear.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
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
