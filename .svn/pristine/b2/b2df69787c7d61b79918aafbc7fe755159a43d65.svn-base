using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class apoyodalc
    {
        private string _cnn;
        public apoyodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<apoyos> getapoyos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.apoyos.Where(a=>a.baja==false).ToList();
            }
        }

        public List<apoyos> getapoyosbyparams(string tipoapoyo, string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.apoyos.Where(a=> a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }

        public apoyos getapoyo(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
               if (db.apoyos.Where(a=> a.idapoyo == id).Count() > 0)
                {
                    return db.apoyos.Where(a => a.idapoyo == id).First();
                }
                else
                {
                    return new apoyos();
                }
            }
        }



        public void save(apoyos obj)
        {
            using(DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.apoyos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(apoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.apoyos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.apoyos.Count() > 0)
                {
                    return (db.apoyos.OrderByDescending(i => i.idapoyo).FirstOrDefault().idapoyo + 1);
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
                db.apoyos.RemoveRange(db.apoyos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(apoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.apoyos.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
