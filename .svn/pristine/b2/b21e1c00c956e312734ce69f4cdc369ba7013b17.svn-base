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
    public partial class frmconcepto : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        public int idconceptonuevo;
        public frmconcepto(int id, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;

                cargaunidades();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmconcepto_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbgrupo.SetDataBinding(Enum.GetNames(typeof(genericas.enums.egrupoconcepto)), null);
                this.cmbgrupo.SelectedIndex = 0;

                this.cmbtipoconcepto.SetDataBinding(Enum.GetNames(typeof(genericas.enums.etipoconcepto)), null);
                this.cmbtipoconcepto.SelectedIndex = 0;



                cargainfo();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaunidades()
        {
            try
            {
                List<unidades> olistunidades = unidadnc.getunidades(this._connexionstring);
                this.cmbidunidad.SetDataBinding(olistunidades, null);
                this.cmbidunidad.ValueMember = "idunidad";
                this.cmbidunidad.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        private void cargainfo()
        {
            try
            {
                if(this._id > 0)
                {
                    conceptos oconcepto = conceptonc.getconcepto(this._id, this._connexionstring);
                    this.cmbgrupo.Text = oconcepto.grupo;
                    this.cmbtipoconcepto.Text = oconcepto.tipoconcepto;
                    this.cmbidunidad.Value = oconcepto.idunidad;
                    this.txtnombre.Text = oconcepto.nombre;
                    this.txtdescripcion.Text = oconcepto.descripcion;
                    this.txtcvesat.Text = oconcepto.cvesat;
                    this.chkinventariable.Checked = Convert.ToBoolean(oconcepto.inventario);
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
                    conceptos oconcepto = conceptonc.getconcepto(this._id, this._connexionstring);
                    oconcepto.grupo = this.cmbgrupo.Text;
                    oconcepto.tipoconcepto = this.cmbtipoconcepto.Text;
                    oconcepto.nombre = this.txtnombre.Text;
                    oconcepto.descripcion = this.txtdescripcion.Text;
                    oconcepto.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    oconcepto.inventario = this.chkinventariable.Checked;
                    oconcepto.cvesat = this.txtcvesat.Text;
                    conceptonc.update(oconcepto, this._connexionstring);
                }
                else
                {
                    conceptos oconcepto = new conceptos();
                    oconcepto.idconcepto = conceptonc.getid(this._connexionstring);
                    oconcepto.grupo = this.cmbgrupo.Text;
                    oconcepto.tipoconcepto = this.cmbtipoconcepto.Text;
                    oconcepto.nombre = this.txtnombre.Text;
                    oconcepto.descripcion = this.txtdescripcion.Text;
                    oconcepto.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    oconcepto.inventario = this.chkinventariable.Checked;
                    oconcepto.cvesat = this.txtcvesat.Text;
                    oconcepto.usuario = this._idusuario.ToString();
                    oconcepto.baja = false;
                    conceptonc.save(oconcepto, this._connexionstring);

                    this.idconceptonuevo = oconcepto.idconcepto;
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

        private void cmbidunidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //int id = Convert.ToInt32(this.cmbidunidad.Value) ;
                //if (id > 0)
                //{
                //    unidades ounidad = unidadnc.getunidad(id, this._connexionstring);
                //    this.txtcvesat.Text = ounidad.cveunidad;
                //}

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarunidad_Click(object sender, EventArgs e)
        {
            try
            {
                frmunidad ofrmunidad = new frmunidad(0, this._idusuario, this._connexionstring);
                ofrmunidad.ShowDialog();
                if (ofrmunidad._update)
                {
                    cargaunidades();
                    this.cmbidunidad.Value = ofrmunidad.idunidadnuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
