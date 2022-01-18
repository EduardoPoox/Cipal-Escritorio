using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class cobropredialdalc
    {
        private string _cnn;
        public cobropredialdalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<cobropredial> getcobroprediales()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.cobropredial.ToList();
            }
        }

        public cobropredial getcobropredial(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.cobropredial.Where(a => a.idcobropredial == id).Count() > 0)
                {
                    return db.cobropredial.Where(a => a.idcobropredial == id).First();
                }
                else
                {
                    return new cobropredial();
                }
            }
        }

        public void save(cobropredial obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.cobropredial.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(cobropredial obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.cobropredial.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.cobropredial.Count() > 0)
                {
                    return (db.cobropredial.OrderByDescending(i => i.idcobropredial).FirstOrDefault().idcobropredial + 1);
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
                db.cobropredial.RemoveRange(db.cobropredial.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(cobropredial obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.cobropredial.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
