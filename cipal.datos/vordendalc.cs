using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vordendalc
    {
        private string _cnn;
        public vordendalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vordenes> getvordenes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vordenes.ToList();
            }
        }
        public List<vordenes> getvordenesbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vordenes.Where(a=> a.folio.Contains(folio)).ToList();
            }
        }
        public List<vordenes> getvordenesbyparams( DateTime fi,DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vordenes.Where(a=>a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }       

        public List<vordenes> getvordenesbyiddepartamentofechas(int iddepartamento, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vordenes.Where(a => a.iddepartamento == iddepartamento  && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }
        public List<vordenes> getvordenesbyidproveedorfechas( DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vordenes.Where(a=>  a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }
        public List<vordenes> getvordenesbyfechas(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vordenes.Where(a =>a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public vordenes getvorden(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vordenes.Where(a => a.idorden == id).Count() > 0)
                {
                    return db.vordenes.Where(a => a.idorden == id).First();
                }
                else
                {
                    return new vordenes();
                }
            }
        }

    }
}
