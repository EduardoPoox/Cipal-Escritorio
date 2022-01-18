using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detapoyodalc
    {
        private string _cnn;
        public detapoyodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detapoyos> getdetapoyos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detapoyos.Where(a=>a.baja==false).ToList();
            }
        }

        public detapoyos getdetapoyo(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detapoyos.Where(a => a.iddetapoyo == id).Count() > 0)
                {
                    return db.detapoyos.Where(a => a.iddetapoyo == id).First();
                }
                else
                {
                    return new detapoyos();
                }
            }
        }

        public void save(detapoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detapoyos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detapoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detapoyos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detapoyos.Count() > 0)
                {
                    return (db.detapoyos.OrderByDescending(i => i.iddetapoyo).FirstOrDefault().iddetapoyo + 1);
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
                db.detapoyos.RemoveRange(db.detapoyos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detapoyos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                //db.detapoyos.Remove(obj);
                db.detapoyos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detapoyos> getdetapoyosporid(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detapoyos.Where(a => a.baja == false && a.idapoyo == id).ToList();
            }
        }

    }
}
