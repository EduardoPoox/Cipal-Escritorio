using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class conceptodalc
    {
        private string _cnn;
        public conceptodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<conceptos> getconceptos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.conceptos.Where(a=>a.baja==false).ToList();
            }
        }

        public List<conceptos> getconceptosbyparams(string tipoconcepto,string nombre)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.conceptos.Where(a => a.baja == false && a.tipoconcepto==tipoconcepto && a.nombre.Contains(nombre)).ToList();
            }
        }

        public conceptos getconcepto(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.conceptos.Where(a => a.idconcepto == id).Count() > 0)
                {
                    return db.conceptos.Where(a => a.idconcepto == id).First();
                }
                else
                {
                    return new conceptos();
                }
            }
        }

        public void save(conceptos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.conceptos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(conceptos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.conceptos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.conceptos.Count() > 0)
                {
                    return (db.conceptos.OrderByDescending(i => i.idconcepto).FirstOrDefault().idconcepto + 1);
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
                db.conceptos.RemoveRange(db.conceptos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(conceptos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.conceptos.Remove(obj);
                db.SaveChanges();
            }
        }



        public bool existeconcepto(string clavesat)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.conceptos.Where(a => a.baja == false && a.cvesat == clavesat).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public conceptos getconceptobyclavesat(string clavesat)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.conceptos.Where(a => a.baja==false && a.cvesat == clavesat).Count() > 0)
                {
                    return db.conceptos.Where(a => a.baja == false && a.cvesat == clavesat).First();
                }
                else
                {
                    return new conceptos();
                }
            }
        }


    }
}
