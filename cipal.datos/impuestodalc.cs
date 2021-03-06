using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class impuestodalc
    {
        private string _cnn;
        public impuestodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<impuestos> getimpuestos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.impuestos.Where(a=>a.baja==false).ToList();
            }
        }

        public impuestos getimpuesto(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.impuestos.Where(a => a.idimpuesto == id).Count() > 0)
                {
                    return db.impuestos.Where(a => a.idimpuesto == id).First();
                }
                else
                {
                    return new impuestos();
                }
            }
        }

        public void save(impuestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.impuestos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(impuestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.impuestos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.impuestos.Count() > 0)
                {
                    return (db.impuestos.OrderByDescending(i => i.idimpuesto).FirstOrDefault().idimpuesto + 1);
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
                db.impuestos.RemoveRange(db.impuestos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(impuestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.impuestos.Remove(obj);
                db.SaveChanges();
            }
        }


        public impuestos getimpuestobyparams(string tipoimpuesto, string cveimpuesto, decimal tasa)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.impuestos.Where(a => a.baja==false && a.tipoimpuesto == tipoimpuesto && a.cveimpuesto==cveimpuesto && a.tasa== tasa).Count() > 0)
                {
                    return db.impuestos.Where(a => a.baja == false && a.tipoimpuesto == tipoimpuesto && a.cveimpuesto == cveimpuesto && a.tasa == tasa).First();
                }
                else
                {
                    return new impuestos();
                }
            }
        }


    }
}
