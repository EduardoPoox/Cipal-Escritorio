using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detconstanciadalc
    {
        private string _cnn;
        public detconstanciadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detconstancias> getdetconstancias()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detconstancias.Where(a => a.baja == false).ToList();
            }
        }

        public detconstancias getdetconstancia(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detconstancias.Where(a => a.iddetconstancia == id).Count() > 0)
                {
                    return db.detconstancias.Where(a => a.iddetconstancia == id).First();
                }
                else
                {
                    return new detconstancias();
                }
            }
        }

        public void save(detconstancias obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detconstancias.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detconstancias obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detconstancias.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detconstancias.Count() > 0)
                {
                    return (db.detconstancias.OrderByDescending(i => i.iddetconstancia).FirstOrDefault().iddetconstancia + 1);
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
                db.detconstancias.RemoveRange(db.detconstancias.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detconstancias obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detconstancias.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detconstancias> getdetconstanciasporid(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detconstancias.Where(a => a.baja == false && a.idconstancia == id).ToList();
            }
        }
    }
}
