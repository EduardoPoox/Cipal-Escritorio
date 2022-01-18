using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class puestodalc
    {
        private string _cnn;
        public puestodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<puestos> getpuestos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.puestos.Where(a=>a.baja==false).ToList();
            }
        }

        public puestos getpuesto(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.puestos.Where(a => a.idpuesto == id).Count() > 0)
                {
                    return db.puestos.Where(a => a.idpuesto == id).First();
                }
                else
                {
                    return new puestos();
                }
            }
        }

        public void save(puestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.puestos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(puestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.puestos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.puestos.Count() > 0)
                {
                    return (db.puestos.OrderByDescending(i => i.idpuesto).FirstOrDefault().idpuesto + 1);
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
                db.puestos.RemoveRange(db.puestos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(puestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.puestos.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
