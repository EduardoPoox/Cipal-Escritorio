using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cipal.catalogos;

using cipal.entidades;
using cipal.negocios;

namespace cipal.descargas
{
    public partial class frmparametrosdocumentos : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;

        public bool update = false;


        public int iddepartamentoseleccionado = 0;
        public int idempleadoseleccionado = 0;
        public int idproveedorseleccionado = 0;
        public frmparametrosdocumentos(int id, int idconfig, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
            this._idconfig = idconfig;
        }
        private void frmparametrosdocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                cargadepartamentos();
                cargaproveedores();
                cargaempleados();
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
                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._id, this._connexionstring);
                this.txtfoliointerno.Text = odoc.serie + odoc.folio;
                this.txtuuid.Text = odoc.uuid;


                List<proveedores> listproveedores = (List<proveedores>)this.cmbproveedores.DataSource;
                foreach(proveedores oproveedor in listproveedores)
                {
                    if (odoc.rfcemisor== oproveedor.rfc)
                    {
                        this.cmbproveedores.Value = oproveedor.idproveedor;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        private void cargadepartamentos()
        {
            try
            {
                List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);
                this.cmbdepartamentos.SetDataBinding(olistdepartamentos, null);
                this.cmbdepartamentos.ValueMember = "iddepartamento";
                this.cmbdepartamentos.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaproveedores()
        {
            try
            {
                List<proveedores> olistproveedores = proveedornc.getproveedores(this._connexionstring);
                this.cmbproveedores.SetDataBinding(olistproveedores, null);
                this.cmbproveedores.ValueMember = "idproveedor";
                this.cmbproveedores.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargaempleados()
        {
            try
            {
                List<empleados> olistempleados = empleadonc.getempleados(this._connexionstring);
                foreach(empleados oempleado in olistempleados)
                {
                    oempleado.nombres = oempleado.nombres + " " + oempleado.apellidopaterno + " " + oempleado.apellidomaterno;
                }

                this.cmbempleados.SetDataBinding(olistempleados, null);
                this.cmbempleados.ValueMember = "idempleado";
                this.cmbempleados.DisplayMember = "nombres";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnagregardepartamento_Click(object sender, EventArgs e)
        {
            try
            {
                frmdepartamento ofrmdepartamento = new frmdepartamento(0, this._idusuario, this._connexionstring);
                ofrmdepartamento.ShowDialog();
                if (ofrmdepartamento._update)
                {
                    this.cmbdepartamentos.Value = ofrmdepartamento.iddepartamentonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarempleado_Click(object sender, EventArgs e)
        {
            try
            {
                frmempleado ofrmempleado = new frmempleado(0, this._idusuario, this._connexionstring);
                ofrmempleado.ShowDialog();
                if (ofrmempleado._update)
                {
                    this.cmbempleados.Value = ofrmempleado.idempleadonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.idempleadoseleccionado = Convert.ToInt32(this.cmbempleados.Value);
                this.iddepartamentoseleccionado = Convert.ToInt32(this.cmbdepartamentos.Value);
                this.idproveedorseleccionado = Convert.ToInt32(this.cmbproveedores.Value);
                this.update = true;

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

        private void btnagregarproveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmproveedor ofrmproveedor = new frmproveedor(0, this._idusuario, this._connexionstring);
                ofrmproveedor.ShowDialog();
                if (ofrmproveedor._update)
                {
                    cargaproveedores();
                    this.cmbproveedores.Value = ofrmproveedor.idproveedornuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
