using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vmantenimientodalc
    {
        private string _cnn;
        public vmantenimientodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vmantenimientos> getvmantenimientos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.ToList();
            }
        }

        public List<vmantenimientos> getvmantenimientosbyparams(int iddepartamento, int idvehiculo, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.Where(a => a.iddepartamento == iddepartamento && a.idvehiculo == idvehiculo && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vmantenimientos> getvmantenimientosbyiddepartamentofechas(int iddepartamento, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.Where(a => a.iddepartamento == iddepartamento && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vmantenimientos> getvmantenimientosbyidvehiculofechas(int idvehiculo, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.Where(a => a.idvehiculo == idvehiculo && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vmantenimientos> getvmantenimientosbyfechas(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.Where(a => a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }


        public vmantenimientos getvmantenimiento(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vmantenimientos.Where(a => a.idmantenimiento == id).Count() > 0)
                {
                    return db.vmantenimientos.Where(a => a.idmantenimiento == id).First();
                }
                else
                {
                    return new vmantenimientos();
                }
            }
        }

        public List<vmantenimientos> getvmantenimientosbyiddocumentodigital(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.Where(a=>a.iddocumentodigital==iddocumentodigital).ToList();
            }
        }


        public List<vmantenimientos> getvmantenimientosbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vmantenimientos.Where(a => a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }


    }
}
