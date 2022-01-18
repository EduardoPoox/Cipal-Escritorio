using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vehiculodalc
    {
        private string _cnn;
        public vehiculodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vehiculos> getvehiculos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vehiculos.Where(a=>a.baja==false).ToList();
            }
        }

        public vehiculos getvehiculo(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vehiculos.Where(a => a.idvehiculo == id).Count() > 0)
                {
                    return db.vehiculos.Where(a => a.idvehiculo == id).First();
                }
                else
                {
                    return new vehiculos();
                }
            }
        }

        public void save(vehiculos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.vehiculos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(vehiculos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.vehiculos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vehiculos.Count() > 0)
                {
                    return (db.vehiculos.OrderByDescending(i => i.idvehiculo).FirstOrDefault().idvehiculo + 1);
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
                db.vehiculos.RemoveRange(db.vehiculos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(vehiculos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.vehiculos.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
