using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class valorpredialdalc
    {
        private string _cnn;
        public valorpredialdalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<valorpredial> getvalorprediales()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.valorpredial.ToList();
            }
        }

        public valorpredial getvalorpredial(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.valorpredial.Where(a => a.idvalorcatastral == id).Count() > 0)
                {
                    return db.valorpredial.Where(a => a.idvalorcatastral == id).First();
                }
                else
                {
                    return new valorpredial();
                }
            }
        }



        public void save(valorpredial obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.valorpredial.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(valorpredial obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.valorpredial.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.valorpredial.Count() > 0)
                {
                    return (db.valorpredial.OrderByDescending(i => i.idvalorcatastral).FirstOrDefault().idvalorcatastral + 1);
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
                db.valorpredial.RemoveRange(db.valorpredial.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(valorpredial obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.valorpredial.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
