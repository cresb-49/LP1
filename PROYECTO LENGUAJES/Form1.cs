using PROYECTO_LENGUAJES.ArbolSintactico;
using PROYECTO_LENGUAJES.Colorear;
using PROYECTO_LENGUAJES.Elementos_de_Lengua;
using PROYECTO_LENGUAJES.Formularios;
using PROYECTO_LENGUAJES.ManejoArchivos;
using PROYECTO_LENGUAJES.Pila;
using PROYECTO_LENGUAJES.ProcesamientoTexto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PROYECTO_LENGUAJES
{
    public partial class GTinsider : Form
    {
        private SeparadorTexto clasificadorTexto = new SeparadorTexto();
        private Archivos manejadorArchivos = new Archivos();
        private String CurrentFileSource = "";
        private ResaltarPalabras resaltarPalabras = new ResaltarPalabras();
        private Boolean realizarCambios = true;
        private Boolean coloreadoSelectivo = false;
        private int carcater;
        private GenerarDOT generarGrafico = new GenerarDOT();


        public GTinsider()
        {
            InitializeComponent();
            propiedadesGraficas();
        }

        private void propiedadesGraficas()
        {
            CampoDeTexto.Enabled = false;
            buttonExportar.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Start();

        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonExportar.Enabled = true;
            logText.Lines = null;
            String texto = CampoDeTexto.Text;
            //Console.WriteLine(texto);
            List<LOCATION_token> recuperacion = new List<LOCATION_token>();
            recuperacion = clasificadorTexto.abstraccionTexto(texto);
            TOKEN_sorter identificaion = new TOKEN_sorter();
            identificaion.clsificarTokens(recuperacion);
            List<ID_token> recuperacion2 = new List<ID_token>();
            recuperacion2 = identificaion.GetID_Tokens();

            Boolean banderaSintactico = true;

            String resultadoCompi = "";
            foreach (ID_token token in recuperacion2)
            {
                if (token.ID.Equals("unknown_TOKEN"))
                {
                    resultadoCompi = resultadoCompi + "-----------------------------------------------------------------------------------------------------------------------------\n";
                    resultadoCompi = resultadoCompi + "Token type: " + token.ID + " Lexema: " + token.lexema + " Linea ubicacion: " + token.lineaUbicacion + "  Contenido: " + token.contenido + "\n";
                    resultadoCompi = resultadoCompi + "-----------------------------------------------------------------------------------------------------------------------------\n";
                    banderaSintactico = false;
                }
            }
            if (banderaSintactico)
            {
                resultadoCompi = resultadoCompi + "---------------RESULTADO DE ANALISIS SINTACTICO---------------" + "\n";
                AnalicisSintactico an = new AnalicisSintactico();
                an.ejecutar(recuperacion2);

                Arbol arbolSintactico = an.retornarArbol;

                if (an.errores.Count == 0)
                {
                    resultadoCompi = resultadoCompi + "---------------NINGUN FALLO DE GRAMATICA---------------" + "\n";
                    resultadoCompi = resultadoCompi + "-----------GENERANDO DOT DE ARBOL SINTACTICO-----------" + "\n";
                    resultadoCompi = resultadoCompi + arbolSintactico.recuperarDOT();

                    manejadorArchivos.EscrituraArchivo("C:\\temp\\grafo.dot", arbolSintactico.recuperarDOT());
                    generarGrafico.generarGrafico();
                }
                else
                {
                    foreach (String res in an.errores)
                    {
                        resultadoCompi = resultadoCompi + res + "\n";
                    }
                }
            }
            else
            {
                resultadoCompi = resultadoCompi + "---------------EXISTEN ERRORES DE ESCRITURA---------------" + "\n";
            }
            
            logText.Text = resultadoCompi;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coloreadoSelectivo = false;
            buttonExportar.Enabled = false;
            logText.Lines = null;
            if (!CurrentFileSource.Equals(""))
            {
                if (MessageBox.Show("Desea guardar los cambios del documento", "Guardar cambios", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    guardarArchivo();
                }
            }
            CampoDeTexto.Lines = null;
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
                editadoDeTexto();
                coloreadoSelectivo = true;
            }
        }

        private void abrirgtE()
        {
            openFileDialog1.Title = "Abrir resultado de Analisis";
            openFileDialog1.Filter = "Source code (*.gtE)|*.gtE";
            openFileDialog1.ShowDialog();
            String src = openFileDialog1.FileName;
            if (File.Exists(src))
            {
                VisualizarGTE leerGTE = new VisualizarGTE(src);
                leerGTE.ShowDialog();
                //leerGTE.TopMost = true;
            }
        }

        private void archivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarArchivo();
        }
        private void guardarArchivo()
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
            buttonExportar.Enabled = false;
            logText.Lines = null;

            if (!CurrentFileSource.Equals(""))
            {
                if (MessageBox.Show("Desea guardar los cambios del documento", "Guardar cambios", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    guardarArchivo();
                }
            }
            CampoDeTexto.Lines = null;

            saveFileDialog1.Title = "Guardar Source Code";
            saveFileDialog1.Filter = "Source code (*.gt)|*.gt";
            saveFileDialog1.FileName = "Sin titulo 1";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String source = saveFileDialog1.FileName;
                CampoDeTexto.Enabled = true;
                manejadorArchivos.CrearArchivo(source);
                this.CurrentFileSource = source;
                coloreadoSelectivo = true;
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

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            String[] lineas = logText.Lines;

            saveFileDialog1.Title = "Esportar log";
            saveFileDialog1.Filter = "log (*.gtE)|*.gtE";
            saveFileDialog1.FileName = "Sin titulo 1";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String source = saveFileDialog1.FileName;
                CampoDeTexto.Enabled = true;
                manejadorArchivos.ExportarLog(source, lineas);
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CampoDeTexto.SelectionLength > 0)
            {
                CampoDeTexto.Copy();
            }
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (CampoDeTexto.SelectionLength > 0)
                {
                    if (MessageBox.Show("¿Quieres pegar sobre la selección actual? ", "Aviso", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        CampoDeTexto.SelectionStart = CampoDeTexto.SelectionStart + CampoDeTexto.SelectionLength;
                    }
                }
                CampoDeTexto.Paste();
            }
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CampoDeTexto.SelectedText != "")
            {
                CampoDeTexto.Cut();
            }

        }

        private void CampoDeTexto_TextChanged(object sender, EventArgs e)
        {
            if (realizarCambios && coloreadoSelectivo)
            {
                realizarCambios = false;
                int numerolinea = CampoDeTexto.GetLineFromCharIndex(CampoDeTexto.SelectionStart) + 1;
                editadoDeTextoPorLinea(numerolinea);
                realizarCambios = true;
            }
            //ubiCursor();
        }

        private void editadoDeTexto()
        {
            String texto = CampoDeTexto.Text;
            List<LOCATION_token> recuperacion = new List<LOCATION_token>();
            recuperacion = clasificadorTexto.abstraccionTexto(texto);
            TOKEN_sorter identificaion = new TOKEN_sorter();
            identificaion.clsificarTokens(recuperacion);
            List<ID_token> recuperacion2 = new List<ID_token>();
            recuperacion2 = identificaion.GetID_Tokens();
            resaltarPalabras.colorearTexto(CampoDeTexto, recuperacion2);
            textoCompiLog(recuperacion2);
        }
        private void editadoDeTextoPorLinea(int linea)
        {
            logText.Text = null;
            String texto = CampoDeTexto.Text;
            List<LOCATION_token> recuperacion = new List<LOCATION_token>();
            recuperacion = clasificadorTexto.abstraccionTexto(texto);
            TOKEN_sorter identificaion = new TOKEN_sorter();
            identificaion.clsificarTokens(recuperacion);
            List<ID_token> recuperacion2 = new List<ID_token>();
            recuperacion2 = identificaion.GetID_Tokens();
            resaltarPalabras.colorearTextoSegunLinea(CampoDeTexto, recuperacion2, linea);
            textoCompiLog(recuperacion2);
        }
        private void textoCompiLog(List<ID_token> tokens)
        {
            String reportes = "";
            foreach (ID_token item in tokens)
            {
                if (item.ID.Equals("unknown_TOKEN"))
                {
                    reportes = reportes + "-----------------------------------------------------------------------------------------------------------------------\n";
                    reportes = reportes + ("Token type: " + item.ID +" Lexema: "+item.lexema+ " Linea ubicacion: " + item.lineaUbicacion + "  Contenido: " + item.contenido) + "\n";
                    reportes = reportes + "-----------------------------------------------------------------------------------------------------------------------\n";
                }
            }
            logText.Text = reportes;
        }
        private void CampoDeTexto_KeyDown(object sender, KeyEventArgs e)
        {
            UbicacionCarrete.Text = "Ubicacion: linea " + (CampoDeTexto.GetLineFromCharIndex(CampoDeTexto.SelectionStart) + 1);
        }

        private void CampoDeTexto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ubiCursor();
        }

        private void GTinsider_KeyUp(object sender, KeyEventArgs e)
        {
            
            
        }

        public void ubiCursor()
        {
            int pos = this.CampoDeTexto.SelectionStart;
            LabelUbiCursor.Text = pos.ToString();
            Console.WriteLine("Ubicacion cursor: " + pos);
        }

        private void eliminarDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFileSource.Equals(""))
            {
                MessageBox.Show("No hay un archivo abierto");
            }
            else
            {
                if (MessageBox.Show("¿Quieres elminar el documento en curso?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(CurrentFileSource);
                        if (File.Exists(CurrentFileSource))
                        {
                            Console.WriteLine("El archivo sigue existiendo.");
                        }
                        else
                        {
                            Console.WriteLine("El archivo ya no existe.");
                            CampoDeTexto.Enabled = false;
                            CampoDeTexto.Text = "";
                            logText.Text = "";
                            CurrentFileSource = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al borrar archivo: {0}", ex.ToString());
                    }
                }
            }
                
                
        }

        private void leerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirgtE();
        }
    }
}
