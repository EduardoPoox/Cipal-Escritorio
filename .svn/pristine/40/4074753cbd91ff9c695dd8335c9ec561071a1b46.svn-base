using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class ingresodalc
    {
        private string _cnn;
        public ingresodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<ingresos> getingreso()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.ingresos.Where(a=>a.baja==false).ToList();
            }
        }

        public List<ingresos> getingresosbyparams(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.ingresos.Where(a => a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }
        
        public ingresos getingreso(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.ingresos.Where(a => a.idingreso == id).Count() > 0)
                {
                    return db.ingresos.Where(a => a.idingreso == id).First();
                }
                else
                {
                    return new ingresos();
                }
            }
        }

        public void save(ingresos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.ingresos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(ingresos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.ingresos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.ingresos.Count() > 0)
                {
                    return (db.ingresos.OrderByDescending(i => i.idingreso).FirstOrDefault().idingreso + 1);
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
                db.ingresos.RemoveRange(db.ingresos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(ingresos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.ingresos.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
