using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cipal.entidades;
using cipal.negocios;

namespace cipal.catalogos
{
    public partial class frmimpuesto : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idimpuestonuevo;
        public frmimpuesto(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;

                this.cmbtipodeimpuesto.SetDataBinding(Enum.GetNames(typeof(genericas.enums.etipodeimpuesto)), null);
                this.cmbtipodeimpuesto.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmimpuesto_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargainfo()
        {
            try
            {
                if (this._id > 0)
                {
                    impuestos oimpuesto = impuestonc.getimpuesto(this._id, this._connexionstring);
                    this.cmbtipodeimpuesto.Text = oimpuesto.tipoimpuesto.ToString();
                    this.txtnombre.Text = oimpuesto.nombre;
                    this.txtclavesat.Text = oimpuesto.cveimpuesto;
                    this.txttasa.Value = oimpuesto.tasa;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._id > 0)
                {
                    impuestos oimpuesto = impuestonc.getimpuesto(this._id, this._connexionstring);
                    oimpuesto.tipoimpuesto = this.cmbtipodeimpuesto.Text;
                    oimpuesto.cveimpuesto = this.txtclavesat.Text;
                    oimpuesto.nombre = this.txtnombre.Text;
                    oimpuesto.tasa = Convert.ToDecimal(this.txttasa.Value);
                    impuestonc.update(oimpuesto, this._connexionstring);
                }
                else
                {
                    impuestos oimpuesto = new impuestos();

                    oimpuesto.idimpuesto = impuestonc.getid(this._connexionstring);
                    oimpuesto.tipoimpuesto = this.cmbtipodeimpuesto.Text;
                    oimpuesto.cveimpuesto = this.txtclavesat.Text;
                    oimpuesto.nombre = this.txtnombre.Text;
                    oimpuesto.tasa = Convert.ToDecimal(this.txttasa.Value);
                    oimpuesto.usuario = this._idusuario.ToString();
                    oimpuesto.baja = false;

                    impuestonc.save(oimpuesto, this._connexionstring);

                    this.idimpuestonuevo = oimpuesto.idimpuesto;
                }
                this._update = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
