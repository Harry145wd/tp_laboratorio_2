
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
            this.gBoxMateriaPrima = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gBoxMateriaPrima.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMateriasPrimas
            // 
            this.rtbMateriasPrimas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMateriasPrimas.Location = new System.Drawing.Point(10, 28);
            this.rtbMateriasPrimas.Name = "rtbMateriasPrimas";
            this.rtbMateriasPrimas.Size = new System.Drawing.Size(230, 283);
            this.rtbMateriasPrimas.TabIndex = 0;
            this.rtbMateriasPrimas.Text = "";
            // 
            // rtbInstrumentosEnStock
            // 
            this.rtbInstrumentosEnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInstrumentosEnStock.Location = new System.Drawing.Point(9, 28);
            this.rtbInstrumentosEnStock.Name = "rtbInstrumentosEnStock";
            this.rtbInstrumentosEnStock.Size = new System.Drawing.Size(230, 328);
            this.rtbInstrumentosEnStock.TabIndex = 1;
            this.rtbInstrumentosEnStock.Text = "";
            // 
            // btnRestock
            // 
            this.btnRestock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestock.Location = new System.Drawing.Point(10, 317);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(230, 40);
            this.btnRestock.TabIndex = 2;
            this.btnRestock.Text = "Re-Stockear";
            this.btnRestock.UseVisualStyleBackColor = true;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // gBoxMateriaPrima
            // 
            this.gBoxMateriaPrima.BackColor = System.Drawing.Color.LightGray;
            this.gBoxMateriaPrima.Controls.Add(this.rtbMateriasPrimas);
            this.gBoxMateriaPrima.Controls.Add(this.btnRestock);
            this.gBoxMateriaPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxMateriaPrima.Location = new System.Drawing.Point(12, 14);
            this.gBoxMateriaPrima.Name = "gBoxMateriaPrima";
            this.gBoxMateriaPrima.Size = new System.Drawing.Size(250, 365);
            this.gBoxMateriaPrima.TabIndex = 5;
            this.gBoxMateriaPrima.TabStop = false;
            this.gBoxMateriaPrima.Text = "Materia Prima";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.rtbInstrumentosEnStock);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(274, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 365);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instrumentos en Stock";
            // 
            // FrmAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 391);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxMateriaPrima);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Almacen";
            this.Load += new System.EventHandler(this.Almacen_Load);
            this.gBoxMateriaPrima.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMateriasPrimas;
        private System.Windows.Forms.RichTextBox rtbInstrumentosEnStock;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.GroupBox gBoxMateriaPrima;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}