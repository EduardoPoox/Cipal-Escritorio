using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class inventariodalc
    {
        private string _cnn;
        public inventariodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<inventarios> getinventarios()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.inventarios.Where(a => a.baja == false).ToList();
            }
        }

        public List<inventarios> getinventariosbyparams()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.inventarios.Where(a => a.baja == false).ToList();
            }
        }
        
        public inventarios getinventario(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.inventarios.Where(a => a.idinventario == id).Count() > 0)
                {
                    return db.inventarios.Where(a => a.idinventario == id).First();
                }
                else
                {
                    return new inventarios();
                }
            }
        }

        public void save(inventarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.inventarios.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(inventarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.inventarios.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.inventarios.Count() > 0)
                {
                    return (db.inventarios.OrderByDescending(i => i.idinventario).FirstOrDefault().idinventario + 1);
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
                db.inventarios.RemoveRange(db.inventarios.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(inventarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.inventarios.Remove(obj);
                db.SaveChanges();
            }
        }

    }
}
