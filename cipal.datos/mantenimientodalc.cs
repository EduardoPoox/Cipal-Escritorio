using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class mantenimientodalc
    {
        private string _cnn;
        public mantenimientodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<mantenimientos> getmantenimientos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.mantenimientos.Where(a=>a.baja==false).ToList();
            }
        }

        public List<mantenimientos> getmantenimientosbyparams(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.mantenimientos.Where(a => a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }

        public mantenimientos getmantenimiento(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.mantenimientos.Where(a => a.idmantenimiento == id).Count() > 0)
                {
                    return db.mantenimientos.Where(a => a.idmantenimiento == id).First();
                }
                else
                {
                    return new mantenimientos();
                }
            }
        }

        public void save(mantenimientos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.mantenimientos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(mantenimientos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.mantenimientos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.mantenimientos.Count() > 0)
                {
                    return (db.mantenimientos.OrderByDescending(i => i.idmantenimiento).FirstOrDefault().idmantenimiento + 1);
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
                db.mantenimientos.RemoveRange(db.mantenimientos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(mantenimientos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.mantenimientos.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<mantenimientos> getmantenimientosbyiddocumentodigital(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.mantenimientos.Where(a => a.baja == false && a.iddocumentodigital==iddocumentodigital).ToList();
            }
        }


        public int getmantenimientosgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.mantenimientos.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().Count();
            }
        }

    }
}
