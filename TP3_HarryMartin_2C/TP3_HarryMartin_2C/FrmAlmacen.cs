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
    public partial class FrmAlmacen : Form, IValueRefresh
    {
        Lutheria lutheria;
        public FrmAlmacen()
        {
            InitializeComponent();
        }
        public FrmAlmacen(Lutheria lutheria):this()
        {
            this.lutheria = lutheria;
        }

        public void ValueRefresh()
        {
            this.rtbMateriasPrimas.Text = lutheria.Almacen.MostrarMateriasPrimas();
            this.rtbInstrumentosEnStock.Text = lutheria.Almacen.MostrarInstrumentosEnStock();
        }
        private void Almacen_Load(object sender, EventArgs e)
        {
            this.ValueRefresh();
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            FrmRestock frmRestock = new FrmRestock(this.lutheria,this);
            frmRestock.ShowDialog();
        }
    }
}
