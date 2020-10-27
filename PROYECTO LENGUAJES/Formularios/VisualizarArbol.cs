using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PROYECTO_LENGUAJES.Formularios
{
    public partial class VisualizarArbol : Form
    {
        public VisualizarArbol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = System.Drawing.Image.FromFile("C:\\temp\\grafo.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Esportar Arbol";
            saveFileDialog1.Filter = "IMG (*.png)|*.png";
            saveFileDialog1.FileName = "Sin titulo 1";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String source = saveFileDialog1.FileName;
                File.Copy("C:\\temp\\grafo.png",source);
            }
        }
    }
}
