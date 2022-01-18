using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vconstanciadalc
    {
        private string _cnn;
        public vconstanciadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }

        public List<vconstancias> getconstancias()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vconstancias.ToList();
            }
        }

        public List<vconstancias> getvconstanciasbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vconstancias.Where(a => a.folio.Contains(folio)).ToList();
            }
        }

        public List<vconstancias> getvconstanciasbyparams(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {

                return db.vconstancias.Where(a => a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }
        public vconstancias getconstancia(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vconstancias.Where(a => a.idconstancia == id).Count() > 0)
                {
                    return db.vconstancias.Where(a => a.idconstancia == id).First();
                }
                else
                {
                    return new vconstancias();
                }
            }
        }
    }
}
