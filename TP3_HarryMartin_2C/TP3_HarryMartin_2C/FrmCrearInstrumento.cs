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
        Lutheria lutheria;
        private FrmCrearInstrumento()
        {
            InitializeComponent();
            this.cmbTipoInstrumento.DataSource = Enum.GetValues(typeof(eTipoInstrumento));
            this.cmbTipoInstrumento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dtpFechaCreacion.Format = DateTimePickerFormat.Custom;
            this.dtpFechaCreacion.CustomFormat = "dd/MM/yyyy";
            this.cmbParametro.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public  FrmCrearInstrumento(Lutheria lutheria):this()
        {
            this.lutheria = lutheria;
        }

        public void ValueRefresh()
        {
            
        }

        private void FrmCrearInstrumento_Load(object sender, EventArgs e)
        {

        }
    }
}
