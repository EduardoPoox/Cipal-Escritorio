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

namespace cipal.egresos
{
    public partial class frmpedidodetalle : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idpedido;
        private int _iddetpedido;

        public bool _update = false;

        public detpedidos _odetpedido;
        public DataTable dtImpuestos = null;

        public frmpedidodetalle(detpedidos odetpedido, DataTable dtImp, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._odetpedido = odetpedido;
                this.dtImpuestos = dtImp;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmpedidodetalle(int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._odetpedido = null;
                this._idpedido = 0;
                this._iddetpedido = 0; ;
                this.dtImpuestos = null;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarImpuestos(int idpedido, int iddetpedido)
        {
            string query = "Select";
            query += " impdetpedidos.idimpuesto, ";
            query += " impuestos.tipoimpuesto,";
            query += " impdetpedidos.nombre, ";
            query += " impdetpedidos.tasa, ";
            query += " impdetpedidos.cveimpuesto, ";
            query += " impdetpedidos.importe ";
            query += " From impdetpedidos ";
            query += " Left Join impuestos on impdetpedidos.idimpuesto = impuestos.idimpuesto";
            query += " where impdetpedidos.idpedido = " + idpedido.ToString();
            query += " and impdetpedidos.iddetpedido = " + iddetpedido.ToString();
            dtImpuestos = genericas.generales.executeDS(query, this._connexionstring).Tables[0];
        }

        private void cargaconceptos()
        {
            try
            {
                List<conceptos> olistconceptos = conceptonc.getconceptos(this._connexionstring);
                this.cmbidconcepto.SetDataBinding(olistconceptos, null);
                this.cmbidconcepto.ValueMember = "idconcepto";
                this.cmbidconcepto.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
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
        private void frmordendecompradetalle_Load(object sender, EventArgs e)
        {
            try
            {
                cargaconceptos();
                cargaunidades();
                cargainfo();

                txtcantidad.ValueChanged += txtCnt_ValueChanged;
                txtpreciounitario.ValueChanged += txtCnt_ValueChanged;
                txtsubtotal.ValueChanged += txtCnt_ValueChanged;
                txtdescuentos.ValueChanged += txtCnt_ValueChanged;
                txtSubtotaldescuento.ValueChanged += txtSubtotal_ValueChanged;

                cmbidconcepto.ValueChanged += cmbConcepto_ValueChanged;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbConcepto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbidconcepto.Value!=null)
                {
                    int idconcenpto = Convert.ToInt32(cmbidconcepto.Value);

                    conceptos odoc = conceptonc.getconcepto(idconcenpto, this._connexionstring);
                    txtcvesat.Text = odoc.cvesat;
                    cmbidunidad.Value = odoc.idunidad;

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCnt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularSubtotal();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSubtotal_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal(true);
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
                if (this._odetpedido != null)
                {
                    this._idpedido = _odetpedido.idpedido;
                    this._iddetpedido = _odetpedido.iddetpedido;
                    // _odetpedido = detpedidonc.getdetpedido(this._iddetpedido, this._connexionstring);
                    this.cmbidconcepto.Value = _odetpedido.idconcepto;
                    this.cmbidunidad.Value = _odetpedido.idunidad;
                    this.txtcantidad.Value = _odetpedido.cantidad;
                    this.txtpreciounitario.Value = _odetpedido.preciounitario;

                    txtsubtotal.Value = _odetpedido.subtotal;
                    txtdescuentos.Value = _odetpedido.descuentos;
                    txtSubtotaldescuento.Value = _odetpedido.subtotal - _odetpedido.descuentos;
                    txtimpuestostrasladados.Value = _odetpedido.impuestostrasladados;
                    txtimpuestosretenidos.Value = _odetpedido.impuestosretenidos;
                    txtimpuestostrasladadoslocales.Value = _odetpedido.impuestostrasladadoslocales;
                    txtimpuestosretenidoslocales.Value = _odetpedido.impuestosretenidoslocales;
                    txttotal.Value = _odetpedido.total;
                }
                else
                {
                    this._odetpedido = new detpedidos();
                    txtsubtotal.Value = 0;
                    txtdescuentos.Value = 0;
                    txtSubtotaldescuento.Value = 0;
                    txtimpuestostrasladados.Value = 0;
                    txtimpuestosretenidos.Value = 0;
                    txtimpuestostrasladadoslocales.Value = 0;
                    txtimpuestosretenidoslocales.Value = 0;
                    txttotal.Value =  0;
                    CargarImpuestos(this._idpedido, this._iddetpedido);
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
                if (this._iddetpedido == 0)
                {
                    _odetpedido = new detpedidos();
                    _odetpedido.idpedido = this._idpedido;

                    _odetpedido.iddetpedido = 0;
                    _odetpedido.idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    _odetpedido.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    _odetpedido.cantidad = Convert.ToDecimal(this.txtcantidad.Value);
                    _odetpedido.usuario = this._idusuario.ToString();
                    _odetpedido.comentarios = txtdescripcion.Text;
                    _odetpedido.descripcion = cmbidconcepto.Text;

                    _odetpedido.preciounitario = Convert.ToDecimal(this.txtpreciounitario.Value);
                    _odetpedido.subtotal = Convert.ToDecimal(this.txtsubtotal.Value);
                    _odetpedido.descuentos = Convert.ToDecimal(this.txtdescuentos.Value);
                    _odetpedido.impuestostrasladados = Convert.ToDecimal(this.txtimpuestostrasladados.Value);
                    _odetpedido.impuestosretenidos = Convert.ToDecimal(this.txtimpuestosretenidos.Value);
                    _odetpedido.impuestostrasladadoslocales = Convert.ToDecimal(this.txtimpuestostrasladadoslocales.Value);
                    _odetpedido.impuestosretenidoslocales = Convert.ToDecimal(this.txtimpuestosretenidoslocales.Value);
                    _odetpedido.total = Convert.ToDecimal(this.txttotal.Value);


                    _odetpedido.baja = false;
                }
                else
                {
                    _odetpedido.idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    _odetpedido.idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    _odetpedido.cantidad = Convert.ToDecimal(this.txtcantidad.Value);
                    _odetpedido.usuario = this._idusuario.ToString();
                    _odetpedido.comentarios = txtdescripcion.Text;
                    _odetpedido.descripcion = cmbidconcepto.Text;

                    _odetpedido.preciounitario = Convert.ToDecimal(this.txtpreciounitario.Value);
                    _odetpedido.subtotal = Convert.ToDecimal(this.txtsubtotal.Value);
                    _odetpedido.descuentos = Convert.ToDecimal(this.txtdescuentos.Value);
                    _odetpedido.impuestostrasladados = Convert.ToDecimal(this.txtimpuestostrasladados.Value);
                    _odetpedido.impuestosretenidos = Convert.ToDecimal(this.txtimpuestosretenidos.Value);
                    _odetpedido.impuestostrasladadoslocales = Convert.ToDecimal(this.txtimpuestostrasladadoslocales.Value);
                    _odetpedido.impuestosretenidoslocales = Convert.ToDecimal(this.txtimpuestosretenidoslocales.Value);
                    _odetpedido.total = Convert.ToDecimal(this.txttotal.Value);

                    _odetpedido.baja = false;
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

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }

        private void btnagregarimpuestos_Click(object sender, EventArgs e)
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(txtsubtotal.Value);
                frmpedidodetalleimpuesto ofrmordendecompradetalle = new frmpedidodetalleimpuesto(dtImpuestos.Copy(),subtotal, this._connexionstring);
                ofrmordendecompradetalle.ShowDialog();
                if (ofrmordendecompradetalle._update)
                {
                    dtImpuestos = ofrmordendecompradetalle._dtImpuestoDetalle;
                    dtImpuestos.AcceptChanges();
                    CalcularTotal(false);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularSubtotal()
        {
            try
            {
                decimal cantidad = Convert.ToDecimal(txtcantidad.Value);
                decimal precio = Convert.ToDecimal(txtpreciounitario.Value);
                decimal subtotal = System.Math.Round(cantidad * precio, 6);
                decimal descuento = Convert.ToDecimal(txtdescuentos.Value);
                txtsubtotal.Value = subtotal;
                subtotal = System.Math.Round(subtotal - descuento, 6);
                txtSubtotaldescuento.Value = subtotal;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotal(bool recalcularimpuestos)
        {
            try
            {
                decimal subtotalbase = Convert.ToDecimal(txtSubtotaldescuento.Value);
                decimal totaltraslados = 0;
                decimal totalretenciones = 0;
                decimal totaltrasladoslocales = 0;
                decimal totalretencioneslocales = 0;
                decimal total = 0;
                for (int x=0;x < dtImpuestos.Rows.Count;x++)
                {
                    //txtimporte.Value = System.Math.Round(_baseimpuesto * ((decimal)odoc.tasa/ (decimal)100), 6);
                    if (recalcularimpuestos)
                    {
                        dtImpuestos.Rows[x]["importe"] = System.Math.Round(subtotalbase * ((decimal)dtImpuestos.Rows[x]["tasa"] / (decimal)100), 6);
                    }

                    if (Convert.ToString(dtImpuestos.Rows[x]["tipoimpuesto"]) == genericas.enums.etipodeimpuesto.trasladado.ToString())
                    {
                        totaltraslados += Convert.ToDecimal(dtImpuestos.Rows[x]["importe"]);
                    }
                    else if (Convert.ToString(dtImpuestos.Rows[x]["tipoimpuesto"]) == genericas.enums.etipodeimpuesto.retenido.ToString())
                    {
                        totalretenciones += Convert.ToDecimal(dtImpuestos.Rows[x]["importe"]);
                    }
                    else if (Convert.ToString(dtImpuestos.Rows[x]["tipoimpuesto"]) == genericas.enums.etipodeimpuesto.trasladadolocal.ToString())
                    {
                        totaltrasladoslocales += Convert.ToDecimal(dtImpuestos.Rows[x]["importe"]);
                    }
                    else if (Convert.ToString(dtImpuestos.Rows[x]["tipoimpuesto"]) == genericas.enums.etipodeimpuesto.retenidolocal.ToString())
                    {
                        totalretencioneslocales += Convert.ToDecimal(dtImpuestos.Rows[x]["importe"]);
                    }
                }

                total = subtotalbase + totaltraslados - totalretenciones + totaltrasladoslocales - totalretencioneslocales;
                total = System.Math.Round(total,6);

                txtimpuestostrasladados.Value = totaltraslados;
                txtimpuestosretenidos.Value = totalretenciones;
                txtimpuestostrasladadoslocales.Value = totaltrasladoslocales;
                txtimpuestosretenidoslocales.Value = totalretencioneslocales;
                txttotal.Value = total;

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
                if (this.cmbidunidad.Text != "")
                {
                    int idunidad = Convert.ToInt32(this.cmbidunidad.Value);
                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);
                    this.txtsimbologia.Text = ounidad.simbologia;
                    this.txtcveunidad.Text = ounidad.cveunidad;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbidconcepto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbidconcepto.Text != "")
                {
                    int idconcepto = Convert.ToInt32(this.cmbidconcepto.Value);
                    conceptos oconcepto = conceptonc.getconcepto(idconcepto, this._connexionstring);
                    this.txtcvesat.Text = oconcepto.cvesat;
                    this.txtdescripcion.Text = oconcepto.descripcion;
                }
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

        private void btnagregarconcepto_Click(object sender, EventArgs e)
        {
            try
            {
                frmconcepto ofrmconcepto = new frmconcepto(0, this._idusuario, this._connexionstring);
                ofrmconcepto.ShowDialog();
                if (ofrmconcepto._update)
                {
                    cargaconceptos();
                    this.cmbidconcepto.Value = ofrmconcepto.idconceptonuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
