using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        //Methods
        public static double Operar(string numero1,string numero2, string operador)
        {
           Numero num1 = new Numero(numero1.Trim());
           Numero num2 = new Numero(numero2.Trim());
           return Calculadora.Operar(num1, num2, operador);
        }

        public void Limpiar()
        {
            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
        }

        //Events

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = $"{Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text)}";
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text); 
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar?", "Confirme si desea cerrar",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button2)==DialogResult.No)
            {
                e.Cancel = true;
            } 
        }

       
    }
}
