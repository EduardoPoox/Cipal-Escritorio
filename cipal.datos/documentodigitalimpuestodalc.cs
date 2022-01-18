using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class documentodigitalimpuestodalc
    {
        private string _cnn;
        public documentodigitalimpuestodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<documentosdigitalesimpuestos> getdocumentosdigitalesimpuestos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.documentosdigitalesimpuestos.Where(a => a.baja == false).ToList();
            }
        }

        public List<documentosdigitalesimpuestos> getdocumentosdigitalesimpuestosbyiddocumentodigital(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.documentosdigitalesimpuestos.Where(a => a.baja == false && a.iddocumentodigital ==iddocumentodigital).ToList();
            }
        }

        public documentosdigitalesimpuestos getdocumentodigitalimpuestobyiddocumentodigitalconcepto(int iddocumentodigital, int iddocumentodigitalconcepto)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitalesimpuestos.Where(a => a.iddocumentodigital == iddocumentodigital && a.iddocumentodigitalconcepto == iddocumentodigitalconcepto).Count() > 0)
                {
                    return db.documentosdigitalesimpuestos.Where(a => a.iddocumentodigital == iddocumentodigital && a.iddocumentodigitalconcepto == iddocumentodigitalconcepto).First();
                }
                else
                {
                    return new documentosdigitalesimpuestos();
                }
            }
        }

        public documentosdigitalesimpuestos getdocumentodigitalimpuesto(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitalesimpuestos.Where(a => a.iddocumentodigitalimpuesto == id).Count() > 0)
                {
                    return db.documentosdigitalesimpuestos.Where(a => a.iddocumentodigitalimpuesto == id).First();
                }
                else
                {
                    return new documentosdigitalesimpuestos();
                }
            }
        }

        public void save(documentosdigitalesimpuestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitalesimpuestos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(documentosdigitalesimpuestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitalesimpuestos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitalesimpuestos.Count() > 0)
                {
                    return (db.documentosdigitalesimpuestos.OrderByDescending(i => i.iddocumentodigitalimpuesto).FirstOrDefault().iddocumentodigitalimpuesto + 1);
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
                db.documentosdigitalesimpuestos.RemoveRange(db.documentosdigitalesimpuestos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(documentosdigitalesimpuestos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitalesimpuestos.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<documentosdigitalesimpuestos> getdocumentodigitalimpuestosbyiddocumentodigitalconcepto(int iddocumentodigital, int iddocumentodigitalconcepto)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.documentosdigitalesimpuestos.Where(a => a.iddocumentodigital == iddocumentodigital && a.iddocumentodigitalconcepto == iddocumentodigitalconcepto).ToList();
            }
        }
    }
}
