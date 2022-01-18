using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detinformedalc
    {
        private string _cnn;
        public detinformedalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detinformes> getdetinformes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detinformes.Where(a => a.baja == false).ToList();
            }
        }

        public detinformes getdetinforme(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detinformes.Where(a => a.iddetinforme == id).Count() > 0)
                {
                    return db.detinformes.Where(a => a.iddetinforme == id).First();
                }
                else
                {
                    return new detinformes();
                }
            }
        }

        public void save(detinformes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detinformes.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detinformes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detinformes.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detinformes.Count() > 0)
                {
                    return (db.detinformes.OrderByDescending(i => i.iddetinforme).FirstOrDefault().iddetinforme + 1);
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
                db.detinformes.RemoveRange(db.detinformes.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detinformes obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detinformes.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<detinformes> getdetinformesporid(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detinformes.Where(a => a.baja == false && a.idinforme == id).ToList();
            }
        }


       




    }
}
