
namespace TP3_HarryMartin_2C
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbListaInstrumentos = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiCrearInstrumento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbListaInstrumentos
            // 
            this.rtbListaInstrumentos.Location = new System.Drawing.Point(12, 95);
            this.rtbListaInstrumentos.Name = "rtbListaInstrumentos";
            this.rtbListaInstrumentos.Size = new System.Drawing.Size(261, 343);
            this.rtbListaInstrumentos.TabIndex = 2;
            this.rtbListaInstrumentos.Text = "";
            this.rtbListaInstrumentos.TextChanged += new System.EventHandler(this.rtbListaInstrumentos_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlmacen,
            this.tmsiCrearInstrumento});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(980, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAlmacen
            // 
            this.tsmiAlmacen.Name = "tsmiAlmacen";
            this.tsmiAlmacen.Size = new System.Drawing.Size(66, 20);
            this.tsmiAlmacen.Text = "Almacen";
            this.tsmiAlmacen.Click += new System.EventHandler(this.tsmiAlmacen_Click);
            // 
            // tmsiCrearInstrumento
            // 
            this.tmsiCrearInstrumento.Name = "tmsiCrearInstrumento";
            this.tmsiCrearInstrumento.Size = new System.Drawing.Size(115, 20);
            this.tmsiCrearInstrumento.Text = "Crear Instrumento";
            this.tmsiCrearInstrumento.Click += new System.EventHandler(this.tmsiCrearInstrumento_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.rtbListaInstrumentos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "Lutheria";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbListaInstrumentos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlmacen;
        private System.Windows.Forms.ToolStripMenuItem tmsiCrearInstrumento;
    }
}

