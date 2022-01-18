using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class parametrodalc
    {
        private string _cnn;
        public parametrodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<parametros> getparametros()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.parametros.ToList();
            }
        }

        public parametros getparametro(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.parametros.Where(a => a.idparametro == id).Count() > 0)
                {
                    return db.parametros.Where(a => a.idparametro == id).First();
                }
                else
                {
                    return new parametros();
                }
            }
        }

        public void save(parametros obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.parametros.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(parametros obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.parametros.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.parametros.Count() > 0)
                {
                    return (db.parametros.OrderByDescending(i => i.idparametro).FirstOrDefault().idparametro + 1);
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
                db.parametros.RemoveRange(db.parametros.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(parametros obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.parametros.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
