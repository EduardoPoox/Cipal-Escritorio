using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class beneficiariodalc
    {
        private string _cnn;
        public beneficiariodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<beneficiarios> getbeneficiarios()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.beneficiarios.Where(a=>a.baja==false).ToList();
            }
        }
        public List<beneficiarios> getbeneficiariosbyparams(string rfc, string nombre)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.beneficiarios.Where(a=>a.baja ==false && a.rfc.Contains(rfc) && a.nombre.Contains(nombre)).ToList();
            }
        }

        public beneficiarios getbeneficiario(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.beneficiarios.Where(a => a.idbeneficiario == id).Count() > 0)
                {
                    return db.beneficiarios.Where(a => a.idbeneficiario == id).First();
                }
                else
                {
                    return new beneficiarios();
                }
            }
        }

        public void save(beneficiarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.beneficiarios.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(beneficiarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.beneficiarios.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.beneficiarios.Count() > 0)
                {
                    return (db.beneficiarios.OrderByDescending(i => i.idbeneficiario).FirstOrDefault().idbeneficiario + 1);
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
                db.beneficiarios.RemoveRange(db.beneficiarios.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(beneficiarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.beneficiarios.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
