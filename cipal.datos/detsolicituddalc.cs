using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detsolicituddalc
    {
        private string _cnn;
        public detsolicituddalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detsolicitudes> getdetsolicitudes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detsolicitudes.Where(a=>a.baja==false).ToList();
            }
        }

        public detsolicitudes getdetsolicitud(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detsolicitudes.Where(a => a.iddetsolicitud == id).Count() > 0)
                {
                    return db.detsolicitudes.Where(a => a.iddetsolicitud == id).First();
                }
                else
                {
                    return new detsolicitudes();
                }
            }
        }

        public void save(detsolicitudes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detsolicitudes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detsolicitudes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detsolicitudes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detsolicitudes.Count() > 0)
                {
                    return (db.detsolicitudes.OrderByDescending(i => i.iddetsolicitud).FirstOrDefault().iddetsolicitud + 1);
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
                db.detsolicitudes.RemoveRange(db.detsolicitudes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detsolicitudes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detsolicitudes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detsolicitudes> getdetsolicitudesporid(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detsolicitudes.Where(a => a.baja == false && a.idsolicitud == id).ToList();
            }
        }
    }
}
