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
    public partial class frmopcionesemitidos : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;
        private int _idconfig;

        public bool update = false;
        public frmopcionesemitidos(int id, int idconfig, int idusuario, string connexionstring)
        {
            InitializeComponent();
            this._connexionstring = connexionstring;
            this._idusuario = idusuario;
            this._id = id;
            this._idconfig = idconfig;
        }

        private void frmopcionesemitidos_Load(object sender, EventArgs e)
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
                parametros oconfig = parametronc.getparametro(this._idconfig, this._connexionstring);
                this.txtdirinformes.Text = oconfig.dirinformes;

                documentosdigitales odoc = documentodigitalnc.getgetdocumentodigital(this._id, this._connexionstring);
                this.txtfoliointerno.Text = odoc.serie + odoc.folio;
                this.txtuuid.Text = odoc.uuid;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
