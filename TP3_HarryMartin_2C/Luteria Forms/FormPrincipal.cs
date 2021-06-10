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

namespace TP3_HarryMartin_2C
{
    public partial class FormPrincipal : Form, IValueRefresh
    {
        Lutheria lutheria;
        public FormPrincipal()
        {
            InitializeComponent();
            this.lutheria = new Lutheria();
            
        }

        public void ValueRefresh()
        {
            this.rtbListaInstrumentos.Text = this.lutheria.MostrarInstrumentosEnProceso();
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.ValueRefresh();
        }

        private void tsmiAlmacen_Click(object sender, EventArgs e)
        {
            FrmAlmacen frmAlmacen = new FrmAlmacen(this.lutheria);
            frmAlmacen.ShowDialog();
        }

        private void rtbListaInstrumentos_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tmsiCrearInstrumento_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCrearInstrumento frmCrearInstrumento = new FrmCrearInstrumento(this.lutheria);
                frmCrearInstrumento.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.ValueRefresh();
            }
        }
    }
}
