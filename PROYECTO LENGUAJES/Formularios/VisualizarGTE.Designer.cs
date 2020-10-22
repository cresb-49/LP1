namespace PROYECTO_LENGUAJES.Formularios
{
    partial class VisualizarGTE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizarGTE));
            this.richTextBoxMostrarDoc = new System.Windows.Forms.RichTextBox();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxMostrarDoc
            // 
            this.richTextBoxMostrarDoc.AcceptsTab = true;
            this.richTextBoxMostrarDoc.BackColor = System.Drawing.SystemColors.ControlDark;
            this.richTextBoxMostrarDoc.Location = new System.Drawing.Point(28, 23);
            this.richTextBoxMostrarDoc.Name = "richTextBoxMostrarDoc";
            this.richTextBoxMostrarDoc.ReadOnly = true;
            this.richTextBoxMostrarDoc.Size = new System.Drawing.Size(744, 351);
            this.richTextBoxMostrarDoc.TabIndex = 0;
            this.richTextBoxMostrarDoc.Text = "";
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(671, 394);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(101, 23);
            this.buttonCerrar.TabIndex = 2;
            this.buttonCerrar.Text = "Cerrar Ventana";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // VisualizarGTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 429);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.richTextBoxMostrarDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisualizarGTE";
            this.Text = "VisualizarGTE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMostrarDoc;
        private System.Windows.Forms.Button buttonCerrar;
    }
}