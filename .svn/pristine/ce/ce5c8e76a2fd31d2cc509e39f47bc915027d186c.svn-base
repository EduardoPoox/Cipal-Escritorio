using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class departamentodalc
    {
        private string _cnn;
        public departamentodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<departamentos> getdepartamentos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.departamentos.Where(a=>a.baja==false).ToList();
            }
        }

        public departamentos getdepartamento(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.departamentos.Where(a => a.iddepartamento == id).Count() > 0)
                {
                    return db.departamentos.Where(a => a.iddepartamento == id).First();
                }
                else
                {
                    return new departamentos();
                }
            }
        }

        public void save(departamentos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.departamentos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(departamentos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.departamentos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.departamentos.Count() > 0)
                {
                    return (db.departamentos.OrderByDescending(i => i.iddepartamento).FirstOrDefault().iddepartamento + 1);
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
                db.departamentos.RemoveRange(db.departamentos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(departamentos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.departamentos.Remove(obj);
                db.SaveChanges();
            }
        }


    }
}
