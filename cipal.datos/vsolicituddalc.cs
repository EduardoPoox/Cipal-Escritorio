using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vsolicituddalc
    {
        private string _cnn;
        public vsolicituddalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vsolicitudes> getvsolicitudes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vsolicitudes.ToList();
            }
        }

        public List<vsolicitudes> getvsolicitudesbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vsolicitudes.Where(a => a.folio.Contains(folio)).ToList();
            }
        }

        public List<vsolicitudes> getvsolicitudesbyparams(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                
                return db.vsolicitudes.Where(a => a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }


        public vsolicitudes getvsolicitud(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vsolicitudes.Where(a => a.idsolicitud == id).Count() > 0)
                {
                    return db.vsolicitudes.Where(a => a.idsolicitud == id).First();
                }
                else
                {
                    return new vsolicitudes();
                }
            }
        }

    }
}
