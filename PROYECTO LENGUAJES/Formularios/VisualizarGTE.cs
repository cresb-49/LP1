using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PROYECTO_LENGUAJES.ManejoArchivos;

namespace PROYECTO_LENGUAJES.Formularios
{
    public partial class VisualizarGTE : Form
    {
        private Archivos manejadorArchivos = new Archivos();
        public VisualizarGTE(String src)
        {
            InitializeComponent();
            contenidoVentana(src);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void contenidoVentana(String src)
        {
            richTextBoxMostrarDoc.Text = manejadorArchivos.LecturaArchivo(src);
        }
    }
}
