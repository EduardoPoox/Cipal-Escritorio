using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class constanciadalc
    {
        private string _cnn;
        public constanciadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<constancias> getconstancias()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.constancias.Where(a => a.baja == false).ToList();
            }
        }

        public constancias getconstancia(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.constancias.Where(a => a.idconstancia == id).Count() > 0)
                {
                    return db.constancias.Where(a => a.idconstancia == id).First();
                }
                else
                {
                    return new constancias();
                }
            }
        }

        public void save(constancias obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.constancias.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(constancias obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.constancias.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.constancias.Count() > 0)
                {
                    return (db.constancias.OrderByDescending(i => i.idconstancia).FirstOrDefault().idconstancia + 1);
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
                db.constancias.RemoveRange(db.constancias.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(constancias obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.constancias.Remove(obj);
                db.SaveChanges();
            }
        }

        public int getconstanciasgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.constancias.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().Count();
            }
        }

        public constancias getconstanciagenerado(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.constancias.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).Count() > 0)
                {
                    return db.constancias.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().First();
                }
                else
                {
                    return new constancias();
                }
            }
        }
    }
}
