using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detgasolinadalc
    {
        private string _cnn;
        public detgasolinadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detgasolinas> getdetgasolinas()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detgasolinas.Where(a => a.baja == false).ToList();
            }
        }

        public detgasolinas getdetgasolina(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detgasolinas.Where(a => a.iddetgasolina == id).Count() > 0)
                {
                    return db.detgasolinas.Where(a => a.iddetgasolina == id).First();
                }
                else
                {
                    return new detgasolinas();
                }
            }
        }

        public void save(detgasolinas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detgasolinas.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detgasolinas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detgasolinas.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detgasolinas.Count() > 0)
                {
                    return (db.detgasolinas.OrderByDescending(i => i.iddetgasolina).FirstOrDefault().iddetgasolina + 1);
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
                db.detgasolinas.RemoveRange(db.detgasolinas.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detgasolinas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detgasolinas.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detgasolinas> getdetgasolinasbyid(int idgasolina)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detgasolinas.Where(a => a.baja == false && a.idgasolina==idgasolina).ToList();
            }
        }
    }
}
