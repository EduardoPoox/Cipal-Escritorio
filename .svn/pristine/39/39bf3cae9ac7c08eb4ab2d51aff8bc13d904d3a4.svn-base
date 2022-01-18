using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class documentodigitalconceptodalc
    {
        private string _cnn;
        public documentodigitalconceptodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<documentosdigitalesconceptos> getdocumentosdigitalesconceptos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.documentosdigitalesconceptos.Where(a => a.baja == false).ToList();
            }
        }

        public List<documentosdigitalesconceptos> getdocumentosdigitalesconceptosbyiddocumentodigital(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.documentosdigitalesconceptos.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList();
            }
        }

        public documentosdigitalesconceptos getdocumentodigitalconcepto(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitalesconceptos.Where(a => a.iddocumentodigitalconcepto == id).Count() > 0)
                {
                    return db.documentosdigitalesconceptos.Where(a => a.iddocumentodigitalconcepto == id).First();
                }
                else
                {
                    return new documentosdigitalesconceptos();
                }
            }
        }

        public void save(documentosdigitalesconceptos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitalesconceptos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(documentosdigitalesconceptos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitalesconceptos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitalesconceptos.Count() > 0)
                {
                    return (db.documentosdigitalesconceptos.OrderByDescending(i => i.iddocumentodigitalconcepto).FirstOrDefault().iddocumentodigitalconcepto + 1);
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
                db.documentosdigitalesconceptos.RemoveRange(db.documentosdigitalesconceptos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(documentosdigitalesconceptos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitalesconceptos.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
