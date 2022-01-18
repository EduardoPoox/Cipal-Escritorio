using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class confdapempleadodalc
    {
        private string _cnn;
        public confdapempleadodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<confdapempleados> getconfdaempleados()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.confdapempleados.Where(a=>a.baja==false).ToList();
            }
        }

        public List<confdapempleados> getconfdaempleadosbyparams()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.confdapempleados.Where(a => a.baja == false).ToList();
            }
        }

        public confdapempleados getconfdaempleado(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.confdapempleados.Where(a => a.idconfdapempleado == id).Count() > 0)
                {
                    return db.confdapempleados.Where(a => a.idconfdapempleado == id).First();
                }
                else
                {
                    return new confdapempleados();
                }
            }
        }

        public void save(confdapempleados obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.confdapempleados.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(confdapempleados obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.confdapempleados.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.confdapempleados.Count() > 0)
                {
                    return (db.confdapempleados.OrderByDescending(i => i.idconfdapempleado).FirstOrDefault().idconfdapempleado + 1);
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
                db.confdapempleados.RemoveRange(db.confdapempleados.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(confdapempleados obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.confdapempleados.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
