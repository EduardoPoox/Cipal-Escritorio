using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class vconfdapempleadodalc
    {
        private string _cnn;
        public vconfdapempleadodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }

        public List<vconfdapempleados> getconfdaempleados()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vconfdapempleados.ToList();
            }
        }

        public List<vconfdapempleados> getconfdaempleadosbyparams(int iddepartamento, int idpuesto)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vconfdapempleados.Where(a=> a.baja==false && a.iddepartamento==iddepartamento || a.idpuesto==idpuesto).ToList();
            }
        }

        public List<vconfdapempleados> getconfdaempleadosbyiddepartamento(int iddepartamento)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vconfdapempleados.Where(a => a.baja == false && a.iddepartamento == iddepartamento).ToList();
            }
        }

        public List<vconfdapempleados> getconfdaempleadosbyidpuesto(int idpuesto)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vconfdapempleados.Where(a => a.baja == false && a.idpuesto == idpuesto).ToList();
            }
        }




        public vconfdapempleados getconfdaempleado(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vconfdapempleados.Where(a => a.idconfdapempleado == id).Count() > 0)
                {
                    return db.vconfdapempleados.Where(a => a.idconfdapempleado == id).First();
                }
                else
                {
                    return new vconfdapempleados();
                }
            }
        }

    }
}
