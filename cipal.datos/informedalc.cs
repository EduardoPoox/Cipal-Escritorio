using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class informedalc
    {
        private string _cnn;
        public informedalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<informes> getinformes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.informes.ToList();
            }
        }

        public List<informes> getinformesbyparams(string empleado, string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.informes.Where(a => a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }

        
        public informes getinforme(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.informes.Where(a => a.idinforme == id).Count() > 0)
                {
                    return db.informes.Where(a => a.idinforme == id).First();
                }
                else
                {
                    return new informes();
                }
            }
        }

        public void save(informes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.informes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(informes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.informes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.informes.Count() > 0)
                {
                    return (db.informes.OrderByDescending(i => i.idinforme).FirstOrDefault().idinforme + 1);
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
                db.informes.RemoveRange(db.informes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(informes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.informes.Remove(obj);
                db.SaveChanges();
            }
        }


        public int getinformesgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.informes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().Count();
            }
        }

        public informes getinformegenerado(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.informes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).Count() > 0)
                {
                    return db.informes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().First();
                }
                else
                {
                    return new informes();
                }
            }
        }
    }
}
