using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class vapoyodalc
    {
        private string _cnn;
        public vapoyodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vapoyos> getapoyos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vapoyos.ToList();
            }
        }

        public List<vapoyos> getapoyosbyparams(string folio, int idtipoapoyo)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vapoyos.Where(a => a.folio.Contains(folio) && a.idtipoapoyo==idtipoapoyo).ToList();
            }
        }

        public vapoyos getapoyo(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vapoyos.Where(a => a.idapoyo == id).Count() > 0)
                {
                    return db.vapoyos.Where(a => a.idapoyo == id).First();
                }
                else
                {
                    return new vapoyos();
                }
            }
        }
    }
}
