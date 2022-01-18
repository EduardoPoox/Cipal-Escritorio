using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class contribuyentesapocrifodalc
    {
        private string _cnn;
        public contribuyentesapocrifodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<contribuyentesapocrifos> getcontribuyentesapocrifos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.contribuyentesapocrifos.Where(a=>a.baja==false).ToList();
            }
        }

        public List<contribuyentesapocrifos> getcontribuyentesapocrifosbyparams(string nombre, string rfc)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.contribuyentesapocrifos.Where(a => a.baja == false && a.nombre.Contains(nombre) && a.rfc.Contains(rfc)).ToList();
            }
        }
        
        public contribuyentesapocrifos getcontribuyentesapocrifo(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.contribuyentesapocrifos.Where(a => a.idcontribuyenteapocrifo == id).Count() > 0)
                {
                    return db.contribuyentesapocrifos.Where(a => a.idcontribuyenteapocrifo == id).First();
                }
                else
                {
                    return new contribuyentesapocrifos();
                }
            }
        }

        public void save(contribuyentesapocrifos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.contribuyentesapocrifos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(contribuyentesapocrifos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.contribuyentesapocrifos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.contribuyentesapocrifos.Count() > 0)
                {
                    return (db.contribuyentesapocrifos.OrderByDescending(i => i.idcontribuyenteapocrifo).FirstOrDefault().idcontribuyenteapocrifo + 1);
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
                db.contribuyentesapocrifos.RemoveRange(db.contribuyentesapocrifos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(contribuyentesapocrifos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.contribuyentesapocrifos.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
