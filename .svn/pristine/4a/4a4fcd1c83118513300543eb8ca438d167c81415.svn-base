using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class movinventariodalc
    {
        private string _cnn;
        public movinventariodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<movinventarios> getmovinventarios()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.movinventarios.ToList();
            }
        }

        public movinventarios getmovinventario(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.movinventarios.Where(a => a.idmovinventario == id).Count() > 0)
                {
                    return db.movinventarios.Where(a => a.idmovinventario == id).First();
                }
                else
                {
                    return new movinventarios();
                }
            }
        }

        public void save(movinventarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.movinventarios.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(movinventarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.movinventarios.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.movinventarios.Count() > 0)
                {
                    return (db.movinventarios.OrderByDescending(i => i.idmovinventario).FirstOrDefault().idmovinventario + 1);
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
                db.movinventarios.RemoveRange(db.movinventarios.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(movinventarios obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.movinventarios.Remove(obj);
                db.SaveChanges();
            }
        }




    }
}
