
namespace TP3_HarryMartin_2C
{
    partial class FrmAlmacen
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
            this.rtbMateriasPrimas = new System.Windows.Forms.RichTextBox();
            this.rtbInstrumentosEnStock = new System.Windows.Forms.RichTextBox();
            this.btnRestock = new System.Windows.Forms.Button();
            this.lblMateriaPrima = new System.Windows.Forms.Label();
            this.IblInstrumentosEnStock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbMateriasPrimas
            // 
            this.rtbMateriasPrimas.Location = new System.Drawing.Point(12, 37);
            this.rtbMateriasPrimas.Name = "rtbMateriasPrimas";
            this.rtbMateriasPrimas.Size = new System.Drawing.Size(200, 250);
            this.rtbMateriasPrimas.TabIndex = 0;
            this.rtbMateriasPrimas.Text = "";
            // 
            // rtbInstrumentosEnStock
            // 
            this.rtbInstrumentosEnStock.Location = new System.Drawing.Point(238, 37);
            this.rtbInstrumentosEnStock.Name = "rtbInstrumentosEnStock";
            this.rtbInstrumentosEnStock.Size = new System.Drawing.Size(220, 289);
            this.rtbInstrumentosEnStock.TabIndex = 1;
            this.rtbInstrumentosEnStock.Text = "";
            // 
            // btnRestock
            // 
            this.btnRestock.Location = new System.Drawing.Point(12, 293);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(200, 33);
            this.btnRestock.TabIndex = 2;
            this.btnRestock.Text = "Re-Stockear";
            this.btnRestock.UseVisualStyleBackColor = true;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // lblMateriaPrima
            // 
            this.lblMateriaPrima.AutoSize = true;
            this.lblMateriaPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMateriaPrima.Location = new System.Drawing.Point(12, 9);
            this.lblMateriaPrima.Name = "lblMateriaPrima";
            this.lblMateriaPrima.Size = new System.Drawing.Size(145, 25);
            this.lblMateriaPrima.TabIndex = 3;
            this.lblMateriaPrima.Text = "Materia Prima";
            // 
            // IblInstrumentosEnStock
            // 
            this.IblInstrumentosEnStock.AutoSize = true;
            this.IblInstrumentosEnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblInstrumentosEnStock.Location = new System.Drawing.Point(233, 9);
            this.IblInstrumentosEnStock.Name = "IblInstrumentosEnStock";
            this.IblInstrumentosEnStock.Size = new System.Drawing.Size(225, 25);
            this.IblInstrumentosEnStock.TabIndex = 4;
            this.IblInstrumentosEnStock.Text = "Instrumentos en Stock";
            // 
            // frmAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 338);
            this.Controls.Add(this.IblInstrumentosEnStock);
            this.Controls.Add(this.lblMateriaPrima);
            this.Controls.Add(this.btnRestock);
            this.Controls.Add(this.rtbInstrumentosEnStock);
            this.Controls.Add(this.rtbMateriasPrimas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAlmacen";
            this.Text = "Almacen";
            this.Load += new System.EventHandler(this.Almacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMateriasPrimas;
        private System.Windows.Forms.RichTextBox rtbInstrumentosEnStock;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.Label lblMateriaPrima;
        private System.Windows.Forms.Label IblInstrumentosEnStock;
    }
}