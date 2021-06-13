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
using System.IO;

namespace TP3_HarryMartin_2C
{
    public partial class FrmPrincipal : Form, IValueRefresh
    {
        string binPath;
        string almacenLogPath;
        string configPath;
        public List<string> paths;
        Lutheria lutheria;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.configPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\lutheriaApp.config";
            this.binPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\data.bin";
            this.almacenLogPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\almacen.txt";
            this.paths = new List<string>();
            this.paths.Add(this.configPath);
            this.paths.Add(this.binPath);
            this.paths.Add(this.almacenLogPath);
            this.lutheria = new Lutheria();
            if (File.Exists(this.configPath))
            {
                try
                {
                    this.paths = Archivos.LeerXML<List<string>>(this.paths[0]);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (File.Exists(this.paths[1]))
            {
                try
                {
                    this.lutheria = Archivos.LeerBin<Lutheria>(this.paths[1]);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            this.rtbDetalles.ReadOnly = true;
            this.lBoxRecienCreados.HorizontalScrollbar = true;           
        }

        #region Refreshers
        public void ValueRefresh()
        {
            this.lBoxRecienCreados.Items.Clear();
            this.lBoxBarnizadora.Items.Clear();
            this.lBoxEncordadora.Items.Clear();
            this.lBoxAfinadora.Items.Clear();
            this.lBoxLimpiadora.Items.Clear();
            foreach (Instrumento instrumento in this.lutheria.ListaDeInstrumentos)
            {
                this.lBoxRecienCreados.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Barnizadora.ListaDeInstrumentos)
            {
                this.lBoxBarnizadora.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Encordadora.ListaDeInstrumentos)
            {
                this.lBoxEncordadora.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Afinadora.ListaDeInstrumentos)
            {
                this.lBoxAfinadora.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Limpiadora.ListaDeInstrumentos)
            {
                this.lBoxLimpiadora.Items.Add(instrumento);
            }

        }
        public void SelectedItemRefresh(Instrumento instrumento)
        {
            if (instrumento != null)
            {
                this.rtbDetalles.Text = instrumento.ToString();
            }
            else
            {
                this.rtbDetalles.Text = "Ningun instrumento seleccionado";
            }
        }
        #endregion
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.ValueRefresh();
            this.SelectedItemRefresh(null);
        }


        #region ListBox_SelectedItemChanged
        private void lBoxRecienCreados_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedItemRefresh((Instrumento)this.lBoxRecienCreados.SelectedItem);
        }

        private void lBoxBarnizadora_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedItemRefresh((Instrumento)this.lBoxBarnizadora.SelectedItem);
        }

        private void lBoxEncordadora_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedItemRefresh((Instrumento)this.lBoxEncordadora.SelectedItem);
        }

        private void lBoxLimpiadora_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedItemRefresh((Instrumento)this.lBoxLimpiadora.SelectedItem);
        }

        private void lBoxAfinadora_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedItemRefresh((Instrumento)this.lBoxAfinadora.SelectedItem);
        }
        #endregion

        #region MenuStrip_Buttons
        private void tsmiAlmacen_Click(object sender, EventArgs e)
        {
            FrmAlmacen frmAlmacen = new FrmAlmacen(this.lutheria);
            frmAlmacen.ShowDialog();
        }

        private void tmsiCrearInstrumento_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCrearInstrumento frmCrearInstrumento = new FrmCrearInstrumento(this.lutheria, this);
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
        #endregion

        #region RecienCreados_Buttons
        private void btnRCABarnizadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxRecienCreados.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxRecienCreados.SelectedItem;
                    this.lutheria.PasarA<Barnizadora>(this.lutheria.Barnizadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRCAEncordadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxRecienCreados.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxRecienCreados.SelectedItem;
                    this.lutheria.PasarA<Encordadora>(this.lutheria.Encordadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRCAAfinadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxRecienCreados.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxRecienCreados.SelectedItem;
                    this.lutheria.PasarA<Afinadora>(this.lutheria.Afinadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRCALimpiadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxRecienCreados.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxRecienCreados.SelectedItem;
                    this.lutheria.PasarA<Limpiadora>(this.lutheria.Limpiadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRCAStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxRecienCreados.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxRecienCreados.SelectedItem;
                    this.lutheria.PasarA<Almacen>(this.lutheria.Almacen, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Barnizadora_Buttons
        private void btnBARecienCreados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxBarnizadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxBarnizadora.SelectedItem;
                    this.lutheria.Barnizadora.PasarA<Lutheria>(this.lutheria, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);                  
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBAEncordadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxBarnizadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxBarnizadora.SelectedItem;
                    this.lutheria.Barnizadora.PasarA<Encordadora>(this.lutheria.Encordadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBAAfinadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxBarnizadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxBarnizadora.SelectedItem;
                    this.lutheria.Barnizadora.PasarA<Afinadora>(this.lutheria.Afinadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBAStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxBarnizadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxBarnizadora.SelectedItem;
                    this.lutheria.Barnizadora.PasarA<Almacen>(this.lutheria.Almacen, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Encordadora_Buttons
        private void btnEARecienCreados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxEncordadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxEncordadora.SelectedItem;
                    this.lutheria.Encordadora.PasarA<Lutheria>(this.lutheria, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEABarnizadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxEncordadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxEncordadora.SelectedItem;
                    this.lutheria.Encordadora.PasarA<Barnizadora>(this.lutheria.Barnizadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEAAfinadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxEncordadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxEncordadora.SelectedItem;
                    this.lutheria.Encordadora.PasarA<Afinadora>(this.lutheria.Afinadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEAStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxEncordadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxEncordadora.SelectedItem;
                    this.lutheria.Encordadora.PasarA<Almacen>(this.lutheria.Almacen, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Limpiadora_Buttons
        private void btnLARecienCreados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxLimpiadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxLimpiadora.SelectedItem;
                    this.lutheria.Limpiadora.PasarA<Lutheria>(this.lutheria, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLAAfinadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxLimpiadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxLimpiadora.SelectedItem;
                    this.lutheria.Limpiadora.PasarA<Afinadora>(this.lutheria.Afinadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLAStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxLimpiadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxLimpiadora.SelectedItem;
                    this.lutheria.Limpiadora.PasarA<Almacen>(this.lutheria.Almacen, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Afinadora_Buttons
        private void btnAARecienCreados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxAfinadora.SelectedItem != null)
                {
                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxAfinadora.SelectedItem;
                    this.lutheria.Afinadora.PasarA<Lutheria>(this.lutheria, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAABarnizadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxAfinadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxAfinadora.SelectedItem;
                    this.lutheria.Afinadora.PasarA<Barnizadora>(this.lutheria.Barnizadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAAEncordadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxAfinadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxAfinadora.SelectedItem;
                    this.lutheria.Afinadora.PasarA<Encordadora>(this.lutheria.Encordadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAALimpiadora_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxAfinadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxAfinadora.SelectedItem;
                    this.lutheria.Afinadora.PasarA<Limpiadora>(this.lutheria.Limpiadora, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAAStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lBoxAfinadora.SelectedItem != null)
                {

                    Instrumento instrumentoAPasar = (Instrumento)this.lBoxAfinadora.SelectedItem;
                    this.lutheria.Afinadora.PasarA<Almacen>(this.lutheria.Almacen, instrumentoAPasar);
                    this.ValueRefresh();
                    this.SelectedItemRefresh(instrumentoAPasar);
                }
                else
                {
                    throw new Exception("No se selecciono ningun instrumento");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Archivos.GuardarBin<Lutheria>(this.paths[1], this.lutheria);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                Archivos.GuardarTxt(this.paths[2], this.lutheria.Almacen.ToString());
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
