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
    public partial class FrmRestock : Form, IValueRefresh
    {
        Lutheria lutheria;
        FrmAlmacen frmAlmacen;
        public FrmRestock()
        {
            InitializeComponent();
            this.cmbMaterialARestockear.DataSource = Enum.GetValues(typeof(eMaterial));
            this.cmbMaterialARestockear.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public FrmRestock(Lutheria lutheria,FrmAlmacen frmAlmacen):this()
        {
            this.lutheria = lutheria;
            this.frmAlmacen = frmAlmacen;
        }
        private void frmRestock_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            this.lutheria.Almacen[(eMaterial)this.cmbMaterialARestockear.SelectedItem].ReStock((int)this.nudCantidad.Value);
            MessageBox.Show("Pedido en Camino","Pedido Generado",MessageBoxButtons.OK);
            MessageBox.Show($"Su pedido de {this.cmbMaterialARestockear.SelectedItem.ToString()} ha llegado","Arrivo de pedido", MessageBoxButtons.OK);
            frmAlmacen.ValueRefresh();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        public void ValueRefresh()
        {
            throw new NotImplementedException();
        }
    }
}
