using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class tipoingresodalc
    {
        private string _cnn;
        public tipoingresodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<tipoingresos> gettipoingresos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.tipoingresos.Where(a=>a.baja==false).ToList();
            }
        }

        public tipoingresos gettipoingreso(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.tipoingresos.Where(a => a.idtipoingreso == id).Count() > 0)
                {
                    return db.tipoingresos.Where(a => a.idtipoingreso == id).First();
                }
                else
                {
                    return new tipoingresos();
                }
            }
        }

        public void save(tipoingresos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoingresos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(tipoingresos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoingresos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.tipoingresos.Count() > 0)
                {
                    return (db.tipoingresos.OrderByDescending(i => i.idtipoingreso).FirstOrDefault().idtipoingreso + 1);
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
                db.tipoingresos.RemoveRange(db.tipoingresos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(tipoingresos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.tipoingresos.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
