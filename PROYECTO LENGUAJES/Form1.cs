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
using System.Net.Configuration;
using PROYECTO_LENGUAJES.Elementos_de_Lengua;

namespace PROYECTO_LENGUAJES
{
    public partial class GTinsider : Form
    {
        private SeparadorTexto clasificadorTexto = new SeparadorTexto();
        private Archivos manejadorArchivos = new Archivos();
        private String CurrentFileSource="";
        private int carcater;
        public GTinsider()
        {
            InitializeComponent();
            propiedadesGraficas();
        }

        private void propiedadesGraficas()
        {
            CampoDeTexto.Enabled = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Start();
        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Se selecciono la opcion");
            String texto = CampoDeTexto.Text;
            Console.WriteLine(texto);
            //List<String> recuperacion = new List<String>();

            List<LOCATION_token> recuperacion = new List<LOCATION_token>();
            recuperacion = clasificadorTexto.abstraccionTexto(texto);

            TOKEN_sorter identificaion = new TOKEN_sorter();

            identificaion.clsificarTokens(recuperacion);

            List<ID_token> recuperacion2 = new List<ID_token>();

            recuperacion2 = identificaion.GetID_Tokens();

            foreach (ID_token token in recuperacion2)
            {
                Console.WriteLine("Token type:-"+token.getID()+" Contenido:-"+token.getTipo());
                Console.WriteLine("-------------------------------------");
            }
            /*
            foreach (LOCATION_token token in recuperacion)
            {
                //Console.WriteLine(token);
                Console.WriteLine("Token: "+token.getCadena()+" Ubicacion: "+token.getLineaUbicacion());
                Console.WriteLine("-------------------------------------");
            }*/
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
            this.CurrentFileSource = src;
            String resultado = "";
            if (File.Exists(src))
            {
                CampoDeTexto.Enabled = true;
                resultado = manejadorArchivos.LecturaArchivo(src);
                CampoDeTexto.Text = resultado;
            }
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFileSource.Equals(""))
            {
                MessageBox.Show("No esta trabajado bajo algun archivo");
            }
            else
            {
                String txt = CampoDeTexto.Text;
                manejadorArchivos.EscrituraArchivo(CurrentFileSource, txt);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar Source Code";
            saveFileDialog1.Filter = "Source code (*.gt)|*.gt";
            saveFileDialog1.FileName = "Sin titulo 1";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String source = saveFileDialog1.FileName;
                if (File.Exists(source))
                {
                    MessageBox.Show("Un archivo ya existe con este nombre");
                }
                else
                {
                    CampoDeTexto.Enabled = true;
                    manejadorArchivos.CrearArchivo(source);
                    this.CurrentFileSource = source;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            carcater = 0;
            int ALTURA = CampoDeTexto.GetPositionFromCharIndex(0).Y;

            if (CampoDeTexto.Lines.Length > 0)
            {
                for (int i = 0; i < CampoDeTexto.Lines.Length; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), CampoDeTexto.Font, Brushes.Black, pictureBox1.Width - (e.Graphics.MeasureString((i + 1).ToString(), CampoDeTexto.Font).Width + 10), ALTURA);
                    carcater += CampoDeTexto.Lines.ElementAt(i).Length + 1;
                    ALTURA = CampoDeTexto.GetPositionFromCharIndex(carcater).Y;
                }
            }
            else
            {
                e.Graphics.DrawString("1", CampoDeTexto.Font, Brushes.Black, pictureBox1.Width - (e.Graphics.MeasureString("1", CampoDeTexto.Font).Width + 10), ALTURA);
            }
        }
    }
}
