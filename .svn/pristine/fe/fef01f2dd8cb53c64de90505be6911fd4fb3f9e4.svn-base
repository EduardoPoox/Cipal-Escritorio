using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class empresadalc
    {
        private string _cnn;
        public empresadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<empresa> getempresa()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.empresa.ToList();
            }
        }

        public empresa getempresa(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.empresa.Where(a => a.idempresa == id).Count() > 0)
                {
                    return db.empresa.Where(a => a.idempresa == id).First();
                }
                else
                {
                    return new empresa();
                }
            }
        }

        public void save(empresa obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.empresa.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(empresa obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.empresa.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.empresa.Count() > 0)
                {
                    return (db.empresa.OrderByDescending(i => i.idempresa).FirstOrDefault().idempresa + 1);
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
                db.empresa.RemoveRange(db.empresa.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(empresa obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.empresa.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
