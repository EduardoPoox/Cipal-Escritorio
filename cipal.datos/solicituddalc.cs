using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class solicituddalc
    {
        private string _cnn;
        public solicituddalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<solicitudes> getsolicitudes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.solicitudes.ToList();
            }
        }

        public List<solicitudes> getsolicitudesbyparams(string empleado, string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.solicitudes.Where(a => a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }

        
        public solicitudes getsolicitud(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.solicitudes.Where(a => a.idsolicitud == id).Count() > 0)
                {
                    return db.solicitudes.Where(a => a.idsolicitud == id).First();
                }
                else
                {
                    return new solicitudes();
                }
            }
        }

        public void save(solicitudes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.solicitudes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(solicitudes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.solicitudes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.solicitudes.Count() > 0)
                {
                    return (db.solicitudes.OrderByDescending(i => i.idsolicitud).FirstOrDefault().idsolicitud + 1);
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
                db.solicitudes.RemoveRange(db.solicitudes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(solicitudes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.solicitudes.Remove(obj);
                db.SaveChanges();
            }
        }


        public int getsolicitudesgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.solicitudes.Where(a=>a.baja==false && a.iddocumentodigital==iddocumentodigital).ToList().Count();
            }
        }


        public solicitudes getsolicitudgenerado(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.solicitudes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).Count() > 0)
                {
                    return db.solicitudes.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().First();
                }
                else
                {
                    return new solicitudes();
                }
            }
        }

    }
}
