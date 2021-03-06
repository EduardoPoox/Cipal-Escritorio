using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class vingresodalc
    {
        private string _cnn;
        public vingresodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vingresos> getingreso()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vingresos.ToList();
            }
        }
        public List<vingresos> getingresosbyparams(int idtipoingreso,DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vingresos.Where(a => a.baja==false && a.idtipoingreso==idtipoingreso && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vingresos> getingresosbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vingresos.Where(a=> a.folio.Contains(folio)).ToList();
            }
        }

        public List<vingresos> getingresosbyfechas(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vingresos.Where(a => a.baja == false  && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }


        public vingresos getingreso(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vingresos.Where(a => a.idingreso == id).Count() > 0)
                {
                    return db.vingresos.Where(a => a.idingreso == id).First();
                }
                else
                {
                    return new vingresos();
                }
            }
        }
    }
}
