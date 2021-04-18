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
        /// <summary>
        /// Constructor sin parametros, Inicializa el Form.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        //Methods
        /// <summary>
        /// Convierte los strings numero en objetos de clase Numero y Realiza la operacion definida en el string operador.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Resultado de la operacion realizada o resultado de la suma (default).</returns>
        public static double Operar(string numero1,string numero2, string operador)
        {
           Numero num1 = new Numero(numero1.Trim());
           Numero num2 = new Numero(numero2.Trim());
           return Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Limpia las textBoxs de los operandos y el label del resultado.
        /// </summary>
        public void Limpiar()
        {
            this.lblResultado.Text = string.Empty;
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
        }

        //Events

        /// <summary>
        /// Hace una limpieza de los textboxs y el label al momento de cargar el Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Evento del boton "Cerrar", cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       /// <summary>
       /// Evento del Boton Limpiar, Limpia los textboxs y el label.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Evento del Boton "Operar" realiza la operacion selecionada en el ComboBox "Operador" entre los valores introducidos en los TextBoxs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = $"{Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text)}";
        }
        /// <summary>
        /// Evento del Boton "Convertir a Binario" convierte el numero que se encuentre en el label "lblResultado" a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }
        /// <summary>
        /// Evento del Boton "Convertir a decimal" convierte el numero que se encuentre en el label "lblResultado" a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text); 
        }
        /// <summary>
        /// Evento previo a que se cierre el Form, pide confirmacion de cierre y permite cancelar el cierre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
