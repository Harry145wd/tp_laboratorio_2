
namespace TP3_HarryMartin_2C
{
    partial class FrmCrearInstrumento
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
            this.lblTipoInstrumento = new System.Windows.Forms.Label();
            this.cmbTipoInstrumento = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblLuthier = new System.Windows.Forms.Label();
            this.txtboxLuthier = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.lblParametro = new System.Windows.Forms.Label();
            this.cmbParametro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTipoInstrumento
            // 
            this.lblTipoInstrumento.AutoSize = true;
            this.lblTipoInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoInstrumento.Location = new System.Drawing.Point(7, 9);
            this.lblTipoInstrumento.Name = "lblTipoInstrumento";
            this.lblTipoInstrumento.Size = new System.Drawing.Size(202, 25);
            this.lblTipoInstrumento.TabIndex = 0;
            this.lblTipoInstrumento.Text = "Tipo de Instrumento";
            // 
            // cmbTipoInstrumento
            // 
            this.cmbTipoInstrumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoInstrumento.FormattingEnabled = true;
            this.cmbTipoInstrumento.Location = new System.Drawing.Point(12, 37);
            this.cmbTipoInstrumento.Name = "cmbTipoInstrumento";
            this.cmbTipoInstrumento.Size = new System.Drawing.Size(222, 33);
            this.cmbTipoInstrumento.TabIndex = 1;
            // 
            // lblLuthier
            // 
            this.lblLuthier.AutoSize = true;
            this.lblLuthier.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuthier.Location = new System.Drawing.Point(7, 73);
            this.lblLuthier.Name = "lblLuthier";
            this.lblLuthier.Size = new System.Drawing.Size(78, 25);
            this.lblLuthier.TabIndex = 2;
            this.lblLuthier.Text = "Luthier";
            // 
            // txtboxLuthier
            // 
            this.txtboxLuthier.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxLuthier.Location = new System.Drawing.Point(12, 101);
            this.txtboxLuthier.Name = "txtboxLuthier";
            this.txtboxLuthier.Size = new System.Drawing.Size(222, 31);
            this.txtboxLuthier.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha de creacion";
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(12, 163);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(222, 31);
            this.dtpFechaCreacion.TabIndex = 6;
            this.dtpFechaCreacion.Value = new System.DateTime(2021, 6, 10, 18, 30, 0, 0);
            // 
            // lblParametro
            // 
            this.lblParametro.AutoSize = true;
            this.lblParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametro.Location = new System.Drawing.Point(12, 197);
            this.lblParametro.Name = "lblParametro";
            this.lblParametro.Size = new System.Drawing.Size(111, 25);
            this.lblParametro.TabIndex = 7;
            this.lblParametro.Text = "Parametro";
            // 
            // cmbParametro
            // 
            this.cmbParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParametro.FormattingEnabled = true;
            this.cmbParametro.Location = new System.Drawing.Point(12, 225);
            this.cmbParametro.Name = "cmbParametro";
            this.cmbParametro.Size = new System.Drawing.Size(222, 33);
            this.cmbParametro.TabIndex = 8;
            // 
            // FrmCrearInstrumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 279);
            this.Controls.Add(this.cmbParametro);
            this.Controls.Add(this.lblParametro);
            this.Controls.Add(this.dtpFechaCreacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtboxLuthier);
            this.Controls.Add(this.lblLuthier);
            this.Controls.Add(this.cmbTipoInstrumento);
            this.Controls.Add(this.lblTipoInstrumento);
            this.Name = "FrmCrearInstrumento";
            this.Text = "Crear un Instrumento";
            this.Load += new System.EventHandler(this.FrmCrearInstrumento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipoInstrumento;
        private System.Windows.Forms.ComboBox cmbTipoInstrumento;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblLuthier;
        private System.Windows.Forms.TextBox txtboxLuthier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.Label lblParametro;
        private System.Windows.Forms.ComboBox cmbParametro;
    }
}