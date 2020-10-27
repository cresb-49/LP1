using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }
    }
}
