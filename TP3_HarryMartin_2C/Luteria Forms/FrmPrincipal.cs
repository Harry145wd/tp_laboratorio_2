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
            foreach (Instrumento instrumento in this.lutheria.InstrumentosEnProceso)
            {
                this.lBoxRecienCreados.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Barnizadora.Instrumentos)
            {
                this.lBoxBarnizadora.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Encordadora.Instrumentos)
            {
                this.lBoxEncordadora.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Afinadora.Instrumentos)
            {
                this.lBoxAfinadora.Items.Add(instrumento);
            }
            foreach (Instrumento instrumento in this.lutheria.Limpiadora.Instrumentos)
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

        #region PasarA_Validators
        private bool PasarABarnizadora(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is IBarnizable)
            {
                ret = true;
            }
            else
            {
                throw new Exception("Este instrumento no puede ser barnizado con la Barnizadora");
            }
            return ret;
        }
        private bool PasarALimpiadora(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is ILimpiable)
            {
                ret = true;
            }
            else
            {
                throw new Exception("Este instrumento no se puede ser limpiado con la Limpiadora");
            }
            return ret;
        }
        private bool PasarAEncordadora(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is ICuerdas)
            {
                if (instrumento is IBarnizable)
                {
                    IBarnizable iCuerdas = (IBarnizable)instrumento;
                    if (iCuerdas.EstaBarnizado)
                    {
                        ret = true;
                    }
                    else
                    {
                        throw new Exception("El instrumento no se puede encordar todavia ya que necesita barniz");
                    }
                }
                else
                {
                    ret = true;
                }
            }
            else
            {
                throw new Exception("Este instrumento no se puede encordar ya que no es un instrumento de cuerda");
            }
            return ret;
        }
        private bool PasarAAfinadora(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is IAfinable)
            {
                if (instrumento is ICuerdas)
                {
                    ICuerdas iCuerdas = (ICuerdas)instrumento;
                    if (iCuerdas.EstaEncordado)
                    {
                        ret = true;
                    }
                    else
                    {
                        throw new Exception("El instrumento no se puede afinar ya que no tiene cuerdas");
                    }
                }
                if (instrumento is ILimpiable)
                {
                    ILimpiable ilimpiable = (ILimpiable)instrumento;
                    if (ilimpiable.EstaLimpio)
                    {
                        ret = true;
                    }
                    else
                    {
                        throw new Exception("El instrumento no se puede afinar ya que no fue limpiado");
                    }
                }
                
                ret = true;
            }
            else
            {
                throw new Exception("Este instrumento no se puede afinar con la Afinadora");
            }
            return ret;
        }
        private bool PasarAStock(Instrumento instrumento)
        {
            bool ret = false;
            if (instrumento is ITerminado)
            {
                ITerminado iterminado = (ITerminado)instrumento;
                if (iterminado.Terminado)
                {
                    ret = true;
                }
                else
                {
                    throw new Exception("Este instrumento no puede pasarse al Almacen ya que no esta terminado");
                }
            }

            return ret;
        }
        #endregion

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
                    if (this.PasarABarnizadora(instrumentoAPasar))
                    {
                        IBarnizable instrumento = (IBarnizable)instrumentoAPasar;
                        instrumento.Barnizar();
                        this.lutheria.Barnizadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.InstrumentosEnProceso.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAEncordadora(instrumentoAPasar))
                    {
                        ICuerdas instrumento = (ICuerdas)instrumentoAPasar;
                        instrumento.Encordar();
                        this.lutheria.Encordadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.InstrumentosEnProceso.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAAfinadora(instrumentoAPasar))
                    {
                        IAfinable instrumento = (IAfinable)instrumentoAPasar;
                        instrumento.Afinar();
                        this.lutheria.Afinadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.InstrumentosEnProceso.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarALimpiadora(instrumentoAPasar))
                    {
                        ILimpiable instrumento = (ILimpiable)instrumentoAPasar;
                        instrumento.Limpiar();
                        this.lutheria.Limpiadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.InstrumentosEnProceso.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAStock(instrumentoAPasar))
                    {
                        this.lutheria.Almacen.StockInstrumentos.Add(instrumentoAPasar);
                        this.lutheria.InstrumentosEnProceso.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(null);
                    }
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
                    this.lutheria.InstrumentosEnProceso.Add(instrumentoAPasar);
                    this.lutheria.Barnizadora.Instrumentos.Remove(instrumentoAPasar);
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
                    if (this.PasarAEncordadora(instrumentoAPasar))
                    {
                        ICuerdas instrumento = (ICuerdas)instrumentoAPasar;
                        instrumento.Encordar();
                        this.lutheria.Encordadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Barnizadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAAfinadora(instrumentoAPasar))
                    {
                        IAfinable instrumento = (IAfinable)instrumentoAPasar;
                        instrumento.Afinar();
                        this.lutheria.Afinadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Barnizadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAStock(instrumentoAPasar))
                    {
                        this.lutheria.Almacen.StockInstrumentos.Add(instrumentoAPasar);
                        this.lutheria.Barnizadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(null);
                    }
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
                    this.lutheria.InstrumentosEnProceso.Add(instrumentoAPasar);
                    this.lutheria.Encordadora.Instrumentos.Remove(instrumentoAPasar);
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
                    if (this.PasarABarnizadora(instrumentoAPasar))
                    {
                        IBarnizable instrumento = (IBarnizable)instrumentoAPasar;
                        instrumento.Barnizar();
                        this.lutheria.Barnizadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Encordadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAAfinadora(instrumentoAPasar))
                    {
                        IAfinable instrumento = (IAfinable)instrumentoAPasar;
                        instrumento.Afinar();
                        this.lutheria.Afinadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Encordadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAStock(instrumentoAPasar))
                    {
                        this.lutheria.Almacen.StockInstrumentos.Add(instrumentoAPasar);
                        this.lutheria.Encordadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(null);
                    }
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
                    this.lutheria.InstrumentosEnProceso.Add(instrumentoAPasar);
                    this.lutheria.Limpiadora.Instrumentos.Remove(instrumentoAPasar);
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
                    if (this.PasarAAfinadora(instrumentoAPasar))
                    {
                        IAfinable instrumento = (IAfinable)instrumentoAPasar;
                        instrumento.Afinar();
                        this.lutheria.Afinadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Limpiadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAStock(instrumentoAPasar))
                    {
                        this.lutheria.Almacen.StockInstrumentos.Add(instrumentoAPasar);
                        this.lutheria.Limpiadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(null);
                    }
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
                    this.lutheria.InstrumentosEnProceso.Add(instrumentoAPasar);
                    this.lutheria.Afinadora.Instrumentos.Remove(instrumentoAPasar);
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
                    if (this.PasarABarnizadora(instrumentoAPasar))
                    {
                        IBarnizable instrumento = (IBarnizable)instrumentoAPasar;
                        instrumento.Barnizar();
                        this.lutheria.Barnizadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Afinadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAEncordadora(instrumentoAPasar))
                    {
                        ICuerdas instrumento = (ICuerdas)instrumentoAPasar;
                        instrumento.Encordar();
                        this.lutheria.Encordadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Afinadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarALimpiadora(instrumentoAPasar))
                    {
                        ILimpiable instrumento = (ILimpiable)instrumentoAPasar;
                        instrumento.Limpiar();
                        this.lutheria.Limpiadora.Instrumentos.Add(instrumentoAPasar);
                        this.lutheria.Afinadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(instrumentoAPasar);
                    }
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
                    if (this.PasarAStock(instrumentoAPasar))
                    {
                        this.lutheria.Almacen.StockInstrumentos.Add(instrumentoAPasar);
                        this.lutheria.Afinadora.Instrumentos.Remove(instrumentoAPasar);
                        this.ValueRefresh();
                        this.SelectedItemRefresh(null);
                    }
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
