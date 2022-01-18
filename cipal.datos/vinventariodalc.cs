using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vinventariodalc
    {
        private string _cnn;
        public vinventariodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vinventarios> getinventarios()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vinventarios.ToList();
            }
        }

        public List<vinventarios> getinventariosbyparams(int idconcepto)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vinventarios.Where(a=> a.idconcepto==idconcepto).ToList();
            }
        }

        public vinventarios getinventario(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vinventarios.Where(a => a.idinventario == id).Count() > 0)
                {
                    return db.vinventarios.Where(a => a.idinventario == id).First();
                }
                else
                {
                    return new vinventarios();
                }
            }
        }
    }
}
