using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class solicituddescargadalc
    {
        private string _cnn;
        public solicituddescargadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }

        public List<solicitudesdescargas> getsolicitudesdescargas()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.solicitudesdescargas.Where(a=>a.baja==false).ToList();
            }
        }

        public List<solicitudesdescargas> getsolicitudesdescargasbyidsolicitud(string idsolicitud)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.solicitudesdescargas.Where(x => x.idsolicitud.Contains(idsolicitud)).ToList() ;
            }
        }

        public solicitudesdescargas getsolicituddescarga(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.solicitudesdescargas.Where(a => a.idsolicituddescarga == id).Count() > 0)
                {
                    return db.solicitudesdescargas.Where(a => a.idsolicituddescarga == id).First();
                }
                else
                {
                    return new solicitudesdescargas();
                }
            }
        }

        public void save(solicitudesdescargas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.solicitudesdescargas.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(solicitudesdescargas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.solicitudesdescargas.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.solicitudesdescargas.Count() > 0)
                {
                    return (db.solicitudesdescargas.OrderByDescending(i => i.idsolicituddescarga).FirstOrDefault().idsolicituddescarga + 1);
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
                db.solicitudesdescargas.RemoveRange(db.solicitudesdescargas.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(solicitudesdescargas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.solicitudesdescargas.Remove(obj);
                db.SaveChanges();
            }
        }



        public List<solicitudesdescargas> getsolicitudesdescargasportiposolicitud(string tiposolicitud)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.solicitudesdescargas.Where(a=>a.baja==false && a.tiposolicitud==tiposolicitud).ToList();
            }
        }
    }
}
