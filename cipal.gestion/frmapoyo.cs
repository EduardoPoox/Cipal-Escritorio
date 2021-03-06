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

namespace cipal.gestion
{
    public partial class frmapoyo : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;

        private List<detapoyos> odetapoyos = new List<detapoyos>();

        public frmapoyo(int id, int idusuario,string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._id = id;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmapoyo_Load(object sender, EventArgs e)
        {
            try
            {
                cargainfo();
                cargatipoapoyo();
                cargabeneficiario();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargatipoapoyo()
        {
            try
            {
                List<tipoapoyos> olisttipoapoyos = tipoapoyonc.gettipoapoyos(this._connexionstring);
                this.cmbidtipoapoyo.SetDataBinding(olisttipoapoyos, null);
                this.cmbidtipoapoyo.ValueMember = "idtipoapoyo";
                this.cmbidtipoapoyo.DisplayMember = "nombre";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void cargabeneficiario()
        {
            try
            {
                List<beneficiarios> olistbeneficiarios = beneficiarionc.getbeneficiarios(this._connexionstring);
                this.cmbidbeneficiario.SetDataBinding(olistbeneficiarios, null);
                this.cmbidbeneficiario.ValueMember = "idbeneficiario";
                this.cmbidbeneficiario.DisplayMember = "nombre";
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
                if (this._id > 0)
                {
                    apoyos oapoyo = apoyonc.getapoyo(this._id, this._connexionstring);
                    this.cmbidtipoapoyo.Value = oapoyo.idtipoapoyo;
                    this.cmbidbeneficiario.Value = oapoyo.idbeneficiario;
                    this.txtfolio.Text = oapoyo.folio;
                    this.dtfechasolicitud.DateTime = (DateTime)oapoyo.fechasolicitud;
                    this.dtfechaentrega.DateTime = (DateTime)oapoyo.fechaentrega;
                    this.txtcomentario.Text = oapoyo.comentarios;
                }
                this.cargardetalle();
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmapoyodetalle ofrmdetapoyo = new frmapoyodetalle(this._id, 0, this._idusuario, this._connexionstring);
                ofrmdetapoyo.ShowDialog();
                if (ofrmdetapoyo._update)
                {
                    this.odetapoyos.Add(ofrmdetapoyo._odetapoyo);
                    cargardetalle();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cargardetalle()
        {
            try
            {
                if (this._id > 0)
                {
                    List<detapoyos> otmp = detapoyonc.getdetapoyosporid(this._id, this._connexionstring);
                    if (odetapoyos.Count == 0)
                    {
                        odetapoyos.AddRange(otmp);
                    }
                }



                DataTable dtdettapoyos = genericas.helpers.ToDataTable(odetapoyos);
                dtdettapoyos.Columns.Add(new DataColumn("nombreunidad", typeof(string)));

                foreach(DataRow orow in dtdettapoyos.Rows)
                {
                    int idunidad = Convert.ToInt32(orow["idunidad"]);
                    unidades ounidad = unidadnc.getunidad(idunidad, this._connexionstring);
                    orow["nombreunidad"] = ounidad.nombre;
                }
                dtdettapoyos.AcceptChanges();

                this.grddetapoyos.SetDataBinding(dtdettapoyos, null);


                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddetapoyos.DisplayLayout.Bands[0].Columns)
                {
                    oColumn.Hidden = true;
                }

                this.grddetapoyos.DisplayLayout.Bands[0].Columns["cantidad"].Hidden = false;
                this.grddetapoyos.DisplayLayout.Bands[0].Columns["descripcion"].Hidden = false;
                this.grddetapoyos.DisplayLayout.Bands[0].Columns["nombreunidad"].Hidden = false;

                this.grddetapoyos.DisplayLayout.Bands[0].Columns["cantidad"].Header.Caption = "Cantidad";
                this.grddetapoyos.DisplayLayout.Bands[0].Columns["descripcion"].Header.Caption = "Descripción";
                this.grddetapoyos.DisplayLayout.Bands[0].Columns["nombreunidad"].Header.Caption = "Unidad de Medida";

                this.grddetapoyos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
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
                    apoyos oapoyo = apoyonc.getapoyo(this._id, this._connexionstring);
                    oapoyo.idtipoapoyo = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    oapoyo.idbeneficiario = Convert.ToInt32(this.cmbidbeneficiario.Value);
                    oapoyo.folio = this.txtfolio.Text;
                    oapoyo.fechasolicitud = this.dtfechasolicitud.DateTime;
                    oapoyo.fechaentrega = this.dtfechaentrega.DateTime;
                    oapoyo.comentarios = this.txtcomentario.Text;
                    apoyonc.update(oapoyo, this._connexionstring);

                    List<detapoyos> otmp = detapoyonc.getdetapoyosporid(oapoyo.idapoyo, this._connexionstring);
                    foreach (detapoyos odet in otmp)
                    {
                        detapoyonc.delete(odet, this._connexionstring);
                    }

                    foreach (detapoyos odetapoyo in this.odetapoyos)
                    {
                        odetapoyo.idapoyo = oapoyo.idapoyo;
                        odetapoyo.iddetapoyo = detapoyonc.getid(this._connexionstring);
                        detapoyonc.save(odetapoyo, this._connexionstring);
                    }
                }
                else
                {
                    apoyos oapoyo = new apoyos();
                    oapoyo.idapoyo = apoyonc.getid(this._connexionstring);
                    oapoyo.idtipoapoyo = Convert.ToInt32(this.cmbidtipoapoyo.Value);
                    oapoyo.idbeneficiario = Convert.ToInt32(this.cmbidbeneficiario.Value);
                    oapoyo.folio = this.txtfolio.Text;
                    oapoyo.fechasolicitud = this.dtfechasolicitud.DateTime;
                    oapoyo.fechaentrega = this.dtfechaentrega.DateTime;
                    oapoyo.comentarios = this.txtcomentario.Text;
                    oapoyo.usuario = this._idusuario.ToString();
                    oapoyo.baja = false;
                    apoyonc.save(oapoyo, this._connexionstring);

                    foreach (detapoyos odetapoyo in this.odetapoyos)
                    {
                        odetapoyo.idapoyo = oapoyo.idapoyo;
                        odetapoyo.iddetapoyo = detapoyonc.getid(this._connexionstring);
                        detapoyonc.save(odetapoyo, this._connexionstring);
                    }
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

        private void btnquitar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grddetapoyos.ActiveRow.Cells["iddetapoyo"].Value);
                if (MessageBox.Show("¿Esta seguro de eliminar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.odetapoyos.RemoveAt(this.grddetapoyos.ActiveRow.Index);
                    
                    this.cargardetalle();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregartipoapoyo_Click(object sender, EventArgs e)
        {
            try
            {
                frmtipoapoyo ofrmtipoapoyo = new frmtipoapoyo(0, this._idusuario, this._connexionstring);
                ofrmtipoapoyo.ShowDialog();
                if (ofrmtipoapoyo._update)
                {
                    cargatipoapoyo();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregarbeneficiario_Click(object sender, EventArgs e)
        {
            try
            {
                frmbeneficiario ofrmbeneficiario = new frmbeneficiario(0, this._idusuario, this._connexionstring);
                ofrmbeneficiario.ShowDialog();
                if (ofrmbeneficiario._update)
                {
                    cargabeneficiario();
                    this.cmbidbeneficiario.Value = ofrmbeneficiario.idbeneficiarionuevo;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gbgeneral_Click(object sender, EventArgs e)
        {

        }

        
    }
}
