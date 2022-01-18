using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vinformedalc
    {
        private string _cnn;
        public vinformedalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }

        public List<vinformes> getinformes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vinformes.ToList();
            }
        }
        public List<vinformes> getvinformesbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vinformes.Where(a => a.folio.Contains(folio)).ToList();
            }
        }

        public List<vinformes> getvinformesbyparams(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {

                return db.vinformes.Where(a => a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public vinformes getinforme(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vinformes.Where(a => a.idinforme == id).Count() > 0)
                {
                    return db.vinformes.Where(a => a.idinforme == id).First();
                }
                else
                {
                    return new vinformes();
                }
            }
        }
    }
}
