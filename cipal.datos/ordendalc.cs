using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class ordendalc
    {
        private string _cnn;
        public ordendalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<ordenes> getordenes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.ordenes.Where(a=>a.baja==false).ToList();
            }
        }

        public List<ordenes> getordenesbyparams(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities( this._cnn))
            {
                return db.ordenes.Where(a=> a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }

        public ordenes getorden(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.ordenes.Where(a => a.idorden == id).Count() > 0)
                {
                    return db.ordenes.Where(a => a.idorden == id).First();
                }
                else
                {
                    return new ordenes();
                }
            }
        }

        public void save(ordenes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.ordenes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(ordenes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.ordenes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.ordenes.Count() > 0)
                {
                    return (db.ordenes.OrderByDescending(i => i.idorden).FirstOrDefault().idorden + 1);
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
                db.ordenes.RemoveRange(db.ordenes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(ordenes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.ordenes.Remove(obj);
                db.SaveChanges();
            }
        }

        public int getordenesgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.ordenes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().Count();
            }
        }

        public ordenes getordengenerado(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.ordenes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).Count() > 0)
                {
                    return db.ordenes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().First();
                }
                else
                {
                    return new ordenes();
                }
            }
        }

    }
}
