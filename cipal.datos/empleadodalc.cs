using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class empleadodalc
    {
        private string _cnn;
        public empleadodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<empleados> getempleados()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.empleados.Where(a=>a.baja==false).ToList();
            }
        }

        public List<empleados> getempleadosbyparams(string rfc, string nombre)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.empleados.Where(a => a.baja == false && a.rfc.Contains(rfc) && a.nombres.Contains(nombre)).ToList();
            }
        }

        public empleados getempleado(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.empleados.Where(a => a.idempleado == id).Count() > 0)
                {
                    return db.empleados.Where(a => a.idempleado == id).First();
                }
                else
                {
                    return new empleados();
                }
            }
        }

        public void save(empleados obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.empleados.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(empleados obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.empleados.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.empleados.Count() > 0)
                {
                    return (db.empleados.OrderByDescending(i => i.idempleado).FirstOrDefault().idempleado + 1);
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
                db.empleados.RemoveRange(db.empleados.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(empleados obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.empleados.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
