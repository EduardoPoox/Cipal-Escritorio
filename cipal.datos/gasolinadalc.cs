using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class gasolinadalc
    {
        private string _cnn;
        public  gasolinadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }


        public List<gasolinas> getgasolinas()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.gasolinas.Where(a=>a.baja==false).ToList();
            }
        }

        public List<gasolinas> getgasolinasbyparams()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.gasolinas.Where(a => a.baja == false).ToList();
            }
        }
        
        public gasolinas getgasolina(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.gasolinas.Where(a => a.idgasolina == id).Count() > 0)
                {
                    return db.gasolinas.Where(a => a.idgasolina == id).First();
                }
                else
                {
                    return new gasolinas();
                }
            }
        }

        public void save(gasolinas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.gasolinas.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(gasolinas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.gasolinas.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.gasolinas.Count() > 0)
                {
                    return (db.gasolinas.OrderByDescending(i => i.idgasolina).FirstOrDefault().idgasolina + 1);
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
                db.gasolinas.RemoveRange(db.gasolinas.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(gasolinas obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.gasolinas.Remove(obj);
                db.SaveChanges();
            }
        }


        public List<gasolinas> getgasolinasbyiddocumentodigital(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.gasolinas.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList();
            }
        }


        public int getgasolinasgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.gasolinas.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().Count();
            }
        }

    }
}
