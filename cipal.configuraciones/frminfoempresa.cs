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

namespace cipal.configuraciones
{
    public partial class frminfoempresa : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        public frminfoempresa(int id, int idusuario, string connexionstring)
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

        private void frmempresa_Load(object sender, EventArgs e)
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
                    empresa oempresa = empresanc.getempresa(this._id, this._connexionstring);
                    this.txtrfc.Text = oempresa.rfc;
                    this.txtnombre.Text = oempresa.nombre;
                    this.txtcp.Text = oempresa.cp;
                    this.txtcalle.Text = oempresa.calle;
                    this.txtnuminterior.Text = oempresa.nointerior;
                    this.txtnumexterior.Text = oempresa.noexterior;
                    this.txtcruzamientos.Text = oempresa.cruzamientos;
                    this.txtreferencias.Text = oempresa.referencias;
                    this.txtcolonia.Text = oempresa.colonia;
                    this.txtlocalidad.Text = oempresa.localidad;
                    this.txtmunicipio.Text = oempresa.municipio;
                    this.txtestado.Text = oempresa.estado;
                    this.txtpais.Text = oempresa.pais;
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
                empresa oempresa = new empresa();
                if (this._id > 0)
                {
                    oempresa = empresanc.getempresa(this._id, this._connexionstring);
                }
                else
                {
                    oempresa.idempresa = empresanc.getid(this._connexionstring);
                }

                oempresa.rfc = this.txtrfc.Text;
                oempresa.nombre = this.txtnombre.Text;
                oempresa.cp = this.txtcp.Text;
                oempresa.calle = this.txtcalle.Text;
                oempresa.nointerior = this.txtnuminterior.Text;
                oempresa.noexterior = this.txtnumexterior.Text;
                oempresa.cruzamientos = this.txtcruzamientos.Text;
                oempresa.referencias = this.txtreferencias.Text;
                oempresa.colonia = this.txtcolonia.Text;
                oempresa.localidad = this.txtlocalidad.Text;
                oempresa.municipio = this.txtmunicipio.Text;
                oempresa.estado = this.txtpais.Text;
       

                if (this._id > 0)
                {
                    empresanc.update(oempresa, this._connexionstring);
                }
                else
                {
                    oempresa.usuario = this._idusuario.ToString();
                    oempresa.baja = false;
                    empresanc.save(oempresa, this._connexionstring);
                }
                   

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
