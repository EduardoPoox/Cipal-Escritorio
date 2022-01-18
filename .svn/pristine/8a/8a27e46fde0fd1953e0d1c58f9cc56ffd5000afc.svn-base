using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class tipoapoyodalc
    {
        private string _cnn;
        public tipoapoyodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<tipoapoyos> gettipoapoyos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.tipoapoyos.Where(a=>a.baja==false).ToList();
            }
        }

        /*public List<tipoapoyos> gettipoapoyosbyparams()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.tipoapoyos.Where(a => a.baja == false).ToList();
            }
        }*/

        public tipoapoyos gettipoapoyo(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.tipoapoyos.Where(a => a.idtipoapoyo == id).Count() > 0)
                {
                    return db.tipoapoyos.Where(a => a.idtipoapoyo == id).First();
                }
                else
                {
                    return new tipoapoyos();
                }
            }
        }

        public void save(tipoapoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoapoyos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(tipoapoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoapoyos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.tipoapoyos.Count() > 0)
                {
                    return (db.tipoapoyos.OrderByDescending(i => i.idtipoapoyo).FirstOrDefault().idtipoapoyo + 1);
                }
                else
                {
                    return 1;
                }
            }
        }

        public void clear()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoapoyos.RemoveRange(db.tipoapoyos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(tipoapoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoapoyos.Remove(obj);
                db.SaveChanges();
            }
        }



    }
}
