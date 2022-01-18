using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class unidaddalc
    {
        private string _cnn;
        public unidaddalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<unidades> getunidades()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.unidades.Where(a=>a.baja==false).ToList();
            }
        }

        public unidades getunidad(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.unidades.Where(a => a.idunidad == id).Count() > 0)
                {
                    return db.unidades.Where(a => a.idunidad == id).First();
                }
                else
                {
                    return new unidades();
                }
            }
        }

        public void save(unidades obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.unidades.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(unidades obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.unidades.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.unidades.Count() > 0)
                {
                    return (db.unidades.OrderByDescending(i => i.idunidad).FirstOrDefault().idunidad + 1);
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
                db.unidades.RemoveRange(db.unidades.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(unidades obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.unidades.Remove(obj);
                db.SaveChanges();
            }
        }


        public bool existeunidad(string claveunidad)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.unidades.Where(a => a.baja == false && a.cveunidad ==claveunidad).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public unidades getunidadbyclaveunidad(string claveunidad)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.unidades.Where(a =>a.baja==false && a.cveunidad == claveunidad).Count() > 0)
                {
                    return db.unidades.Where(a => a.baja == false && a.cveunidad == claveunidad).First();
                }
                else
                {
                    return new unidades();
                }
            }
        }

    }
}
