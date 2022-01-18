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
    public partial class frmdepartamentos : Form
    {
        private string _connexionstring;
        private int _idusuario;
        private int _id;

        public bool _update = false;
        public frmdepartamentos(int id, int idusuario, string connexionstring)
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

        private void frmdepartamento_Load(object sender, EventArgs e)
        {
            try
            {

                consultar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultar()
        {
            List<departamentos> olistdepartamentos = departamentonc.getdepartamentos(this._connexionstring);
            this.grddepartamentos.SetDataBinding(olistdepartamentos, null);
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn oColumn in this.grddepartamentos.DisplayLayout.Bands[0].Columns)
            {
                oColumn.Hidden = true;
            }
            this.grddepartamentos.DisplayLayout.Bands[0].Columns["nombre"].Hidden = false;

            this.grddepartamentos.DisplayLayout.Bands[0].Columns["nombre"].Header.Caption = "Departamentos";

            this.grddepartamentos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                departamentos odepartamento = new departamentos();

                odepartamento.iddepartamento = departamentonc.getid(this._connexionstring);
                odepartamento.nombre = this.txtnombre.Text;
                odepartamento.usuario = this._idusuario.ToString();
                odepartamento.baja = false;

                departamentonc.save(odepartamento, this._connexionstring);

                this.txtnombre.Text = "";
                //this.Close();
                consultar();
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

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.grddepartamentos.ActiveRow.Cells["iddepartamento"].Value);
                if (MessageBox.Show("¿Esta seguro de borrar el registro", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    departamentos odepartamentos = departamentonc.getdepartamento(id, this._connexionstring);
                    odepartamentos.baja = true;
                    departamentonc.update(odepartamentos, this._connexionstring);
                     
                    consultar();

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
