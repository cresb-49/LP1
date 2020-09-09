using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PROYECTO_LENGUAJES.ProcesamientoTexto;
using PROYECTO_LENGUAJES.ManejoArchivos;
namespace PROYECTO_LENGUAJES
{
    public partial class GTinsider : Form
    {
        private SeparadorTexto clasificadorTexto = new SeparadorTexto();
        private Archivos manejadorArchivos = new Archivos();
        public GTinsider()
        {
            InitializeComponent();
        }
        private void propiedadesGraficas()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Se selecciono la opcion");
            String texto = CampoDeTexto.Text;
            Console.WriteLine(texto);
            List<String> recuperacion = new List<String>();
            recuperacion = clasificadorTexto.abstraccionTexto(texto);
            foreach (string cadena in recuperacion)
            {
                Console.WriteLine(cadena);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Abrir code source";
            openFileDialog1.Filter = "Source code (*.gt)|*.gt";
            openFileDialog1.ShowDialog();
            String src = openFileDialog1.FileName;
            String resultado = "";
            if (File.Exists(src))
            {
                resultado = manejadorArchivos.LecturaArchivo(src);
                CampoDeTexto.Text = resultado;
            }
        }
    }
}
