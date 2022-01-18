using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detordendalc
    {
        private string _cnn;
        public detordendalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detordenes> getdetordenes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detordenes.Where(a=>a.baja==false).ToList();
            }
        }

        public detordenes getdetorden(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detordenes.Where(a => a.iddetorden == id).Count() > 0)
                {
                    return db.detordenes.Where(a => a.iddetorden == id).First();
                }
                else
                {
                    return new detordenes();
                }
            }
        }

        public void save(detordenes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detordenes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detordenes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detordenes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detordenes.Count() > 0)
                {
                    return (db.detordenes.OrderByDescending(i => i.iddetorden).FirstOrDefault().iddetorden + 1);
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
                db.detordenes.RemoveRange(db.detordenes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detordenes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                //db.detordenes.Remove(obj);
                db.detordenes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detordenes> getdetordenesporid(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detordenes.Where(a => a.baja == false && a.idorden == id).ToList();
            }
        }


    }
}
