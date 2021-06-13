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
    public partial class FrmCrearInstrumento : Form ,IValueRefresh
    {
        FrmPrincipal frmPrincipal; 
        Lutheria lutheria;
        private FrmCrearInstrumento()
        {
            InitializeComponent();
            this.cmbTipoInstrumento.DataSource = Enum.GetValues(typeof(eTipoInstrumento));
            this.cmbTipoInstrumento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dtpFechaCreacion.Format = DateTimePickerFormat.Custom;
            this.dtpFechaCreacion.CustomFormat = "dd/MM/yyyy";
            
        }
        public  FrmCrearInstrumento(Lutheria lutheria,FrmPrincipal frmPrincipal ):this()
        {
            this.lutheria = lutheria;
            this.frmPrincipal = frmPrincipal;
        }

        public void ValueRefresh()
        {
            
        }

        private void FrmCrearInstrumento_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lutheria.ListaDeInstrumentos.Add(this.lutheria.CrearInstrumento((eTipoInstrumento)this.cmbTipoInstrumento.SelectedItem, this.txtboxLuthier.Text, this.dtpFechaCreacion.Value));
            }
            catch (NotEnoughMaterialsException exc)
            {
                MessageBox.Show(exc.Message, "Faltan materiales", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            this.frmPrincipal.ValueRefresh();
        }

        private void cmbTipoInstrumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
