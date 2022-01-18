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

namespace cipal.descargas
{
    public partial class frmdocumentodigital : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        public frmdocumentodigital(int id, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
        }

        private void frmdocumentodigital_Load(object sender, EventArgs e)
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
                if (this._id == 0)
                {
                    //REGISTRO NUEVO

                }
                else
                {
                    //REGISTRO EXISTENTE

                }


            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



        private void lblfechaemision_Click(object sender, EventArgs e)
        {

        }

        private void lblxml_Click(object sender, EventArgs e)
        {

        }

        private void gbdocumentodogital_Click(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                documentosdigitales odocumentosdigitales = new documentosdigitales();

                odocumentosdigitales.iddocumentodigital = documentodigitalnc.getid(this._connexionstring);
                odocumentosdigitales.tipoxml = this.txttipoxml.Text;
                odocumentosdigitales.uuid = this.txtuuid.Text;
                odocumentosdigitales.rfcemisor = this.txtrfcemisor.Text;
                odocumentosdigitales.nombreemisor = this.txtnombrereceptor.Text;
                odocumentosdigitales.rfcreceptor = this.txtrfcreceptor.Text;
                odocumentosdigitales.nombrereceptor = this.txtnombrereceptor.Text;
                odocumentosdigitales.rfcpac = this.txtrfcpac.Text;
                odocumentosdigitales.fechaemision = this.dtfechaemision.DateTime;
                odocumentosdigitales.fechacertificacionsat = this.dtfechacertificacionsat.DateTime;
                odocumentosdigitales.monto = Convert.ToDecimal(this.txtmonto.Value);
                odocumentosdigitales.fechacancelacion = this.dtfechacancelacion.DateTime;
                // odocumentosdigitales.xml = Convert.ToBinary(this.txtmonto.Value);
                odocumentosdigitales.usuario = this._idusuario.ToString();
                odocumentosdigitales.baja = false;

                documentodigitalnc.save(odocumentosdigitales, this._connexionstring);

                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
