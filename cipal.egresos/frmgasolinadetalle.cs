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

using cipal.entidades;
using cipal.negocios;

namespace cipal.egresos
{
    public partial class frmgasolinadetalle : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _idgasolina;
        private int _iddetgasolina;

        public bool _update = false;

        public detgasolinas _odetgasolina;

        public frmgasolinadetalle(int idgasolina, int iddetgasolina, int idusuario, string connexionstring)
        {
            try
            {
                InitializeComponent();
                this._connexionstring = connexionstring;
                this._idusuario = idusuario;
                this._idgasolina = idgasolina;
                this._iddetgasolina = iddetgasolina;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void frmgasolina_Load(object sender, EventArgs e)
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
                if (this._iddetgasolina > 0)
                {
                    _odetgasolina = detgasolinanc.getdetgasolina(this._iddetgasolina, this._connexionstring);
                    this.dtfecha.Value = _odetgasolina.fecha;
                    this.txtkminicial.Value = _odetgasolina.kminicial;
                    this.txtkmfinal.Value = _odetgasolina.kmfinal;
                    this.txtorigen.Text = _odetgasolina.origen;
                    this.txtdestino.Text = _odetgasolina.destino;
                    this.txtkmrecorridos.Value = _odetgasolina.kmrecorridos;
                    this.txtlitros.Value = _odetgasolina.litros;
                    this.txtimporte.Value = _odetgasolina.pesos;
                    this.txtmotivo.Text = _odetgasolina.motivoviaje;
                    //this.txtfactor.value = _odetgasolina.factor;
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
                if (this._iddetgasolina == 0)
                {
                    _odetgasolina = new detgasolinas();
                    _odetgasolina.idgasolina = this._idgasolina;
                    _odetgasolina.iddetgasolina = 0;

                    _odetgasolina.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    _odetgasolina.kminicial = Convert.ToDecimal(this.txtkminicial.Value);
                    _odetgasolina.kmfinal = Convert.ToDecimal(this.txtkmfinal.Value);
                    _odetgasolina.origen = this.txtorigen.Text;
                    _odetgasolina.destino = this.txtdestino.Text;
                    _odetgasolina.kmrecorridos = Convert.ToDecimal(this.txtkmrecorridos.Value);
                    _odetgasolina.litros = Convert.ToDecimal(this.txtlitros.Value);
                    _odetgasolina.pesos = Convert.ToDecimal(this.txtimporte.Value);
                    _odetgasolina.motivoviaje = this.txtmotivo.Text;
                    _odetgasolina.factor = 0;
                    _odetgasolina.usuario = this._idusuario.ToString();
                    _odetgasolina.baja = false;
                }
                else
                {
                    _odetgasolina.fecha = Convert.ToDateTime(this.dtfecha.Value);
                    _odetgasolina.kminicial = Convert.ToDecimal(this.txtkminicial.Value);
                    _odetgasolina.kmfinal = Convert.ToDecimal(this.txtkmfinal.Value);
                    _odetgasolina.origen = this.txtorigen.Text;
                    _odetgasolina.destino = this.txtdestino.Text;
                    _odetgasolina.kmrecorridos = Convert.ToDecimal(this.txtkmrecorridos.Value);
                    _odetgasolina.litros = Convert.ToDecimal(this.txtlitros.Value);
                    _odetgasolina.pesos = Convert.ToDecimal(this.txtimporte.Value);
                    _odetgasolina.motivoviaje = this.txtmotivo.Text;
                    _odetgasolina.factor = 0;
                    _odetgasolina.usuario = this._idusuario.ToString();
                    _odetgasolina.baja = false;

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
