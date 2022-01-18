using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detmantenimientodalc
    {
        private string _cnn;
        public detmantenimientodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detmantenimientos> getdetmantenimientos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detmantenimientos.Where(a=>a.baja==false).ToList();
            }
        }

        public detmantenimientos getdetmantenimiento(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detmantenimientos.Where(a => a.iddetmantenimiento == id).Count() > 0)
                {
                    return db.detmantenimientos.Where(a => a.iddetmantenimiento == id).First();
                }
                else
                {
                    return new detmantenimientos();
                }
            }
        }

        public void save(detmantenimientos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detmantenimientos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detmantenimientos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detmantenimientos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detmantenimientos.Count() > 0)
                {
                    return (db.detmantenimientos.OrderByDescending(i => i.iddetmantenimiento).FirstOrDefault().iddetmantenimiento + 1);
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
                db.detmantenimientos.RemoveRange(db.detmantenimientos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detmantenimientos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detmantenimientos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detmantenimientos> getdetmantenimientosbyid(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detmantenimientos.Where(a => a.baja == false && a.idmantenimiento == id).ToList();
            }
        }
    }
}
