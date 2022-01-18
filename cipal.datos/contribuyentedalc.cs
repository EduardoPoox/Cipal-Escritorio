using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class contribuyentedalc
    {
        private string _cnn;
        public contribuyentedalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<contribuyentes> getcontribuyentes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.contribuyentes.Where(a=>a.baja==false).ToList();
            }
        }

        public List<contribuyentes> getcontribuyentesbyparams(string rfc, string nombre)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.contribuyentes.Where(a => a.baja == false && a.rfc.Contains(rfc) && a.nombre.Contains(nombre)).ToList();
            }
        }

        public contribuyentes getcontribuyente(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.contribuyentes.Where(a => a.idcontribuyente == id).Count() > 0)
                {
                    return db.contribuyentes.Where(a => a.idcontribuyente == id).First();
                }
                else
                {
                    return new contribuyentes();
                }
            }
        }

        public void save(contribuyentes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.contribuyentes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(contribuyentes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.contribuyentes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.contribuyentes.Count() > 0)
                {
                    return (db.contribuyentes.OrderByDescending(i => i.idcontribuyente).FirstOrDefault().idcontribuyente + 1);
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
                db.contribuyentes.RemoveRange(db.contribuyentes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(contribuyentes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.contribuyentes.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
