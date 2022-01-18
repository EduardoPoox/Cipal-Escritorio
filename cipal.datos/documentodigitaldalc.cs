using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class documentodigitaldalc
    {
        private string _cnn;
        public documentodigitaldalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<documentosdigitales> getdocumentodigital()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.documentosdigitales.Where(a=>a.baja==false).ToList();
            }
        }

        public documentosdigitales getdocumentodigital(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitales.Where(a => a.iddocumentodigital == id).Count() > 0)
                {
                    return db.documentosdigitales.Where(a => a.iddocumentodigital == id).First();
                }
                else
                {
                    return new documentosdigitales();
                }
            }
        }

        public void save(documentosdigitales obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitales.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(documentosdigitales obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitales.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.documentosdigitales.Count() > 0)
                {
                    return (db.documentosdigitales.OrderByDescending(i => i.iddocumentodigital).FirstOrDefault().iddocumentodigital + 1);
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
                db.documentosdigitales.RemoveRange(db.documentosdigitales.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(documentosdigitales obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.documentosdigitales.Remove(obj);
                db.SaveChanges();
            }
        }


        public bool existeuuid(string uuid)
        {
            bool existe = false;
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                int cantidad = db.documentosdigitales.Where(a => a.uuid.Contains(uuid.ToUpper()) && a.baja == false).Count();
                if (cantidad >= 1) existe = true;
            }
            return existe;
        }

        public List<documentosdigitales> getdocumentodigitalbyparams(string tiposolicitud, string tipoxml, DateTime fi, DateTime ff, string rfc, string nombre)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {

                List<documentosdigitales> olist;
                List<documentosdigitales> olisttmp;
                if (tiposolicitud == "recibidos")
                {
                    olisttmp = db.documentosdigitales.Where(a => a.baja == false && a.tiposolicitud == tiposolicitud && a.tipoxml == tipoxml && a.fechaemision >= fi && a.fechaemision <= ff).ToList();
                    // && a.rfcreceptor.Contains(rfc) && a.nombrereceptor.Contains(nombre)).ToList();
                    olist = olisttmp.Where(a => a.rfcemisor.Contains(rfc) && a.nombreemisor.Contains(nombre)).ToList();
                }
                else
                {
                    olisttmp = db.documentosdigitales.Where(a => a.baja == false && a.tiposolicitud == tiposolicitud && a.tipoxml == tipoxml && a.fechaemision >= fi && a.fechaemision <= ff).ToList();
                    // && a.rfcemisor.Contains(rfc)  && a.nombreemisor.Contains(nombre)).ToList();
                    olist = olisttmp.Where(a => a.rfcreceptor.Contains(rfc) && a.nombrereceptor.Contains(nombre)).ToList();
                   
                }



                return olist;
            }
        }

        public string savetransaction(documentosdigitales obj, List<documentosdigitalesconceptos> objconceptos, List<documentosdigitalesimpuestos> objimpuestos)
        {
            string log = "";
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int iddocumentodigitalnuevo = 0;
                        if (db.documentosdigitales.OrderByDescending(i => i.iddocumentodigital).Count() > 0)
                        {
                            iddocumentodigitalnuevo = (db.documentosdigitales.OrderByDescending(i => i.iddocumentodigital).FirstOrDefault().iddocumentodigital + 1);
                        }
                        else
                        {
                            iddocumentodigitalnuevo = 1;
                        }
                        obj.iddocumentodigital = iddocumentodigitalnuevo;

                        db.documentosdigitales.Add(obj);
                        db.SaveChanges();

                        foreach (documentosdigitalesconceptos oconcepto in objconceptos)
                        {
                            oconcepto.iddocumentodigital = obj.iddocumentodigital;
                            int iddocumentodigitalconceptonuevo = 0;
                            if (db.documentosdigitalesconceptos.OrderByDescending(i => i.iddocumentodigitalconcepto).Count()>0) 
                            {
                                iddocumentodigitalconceptonuevo = (db.documentosdigitalesconceptos.OrderByDescending(i => i.iddocumentodigitalconcepto).FirstOrDefault().iddocumentodigitalconcepto + 1);
                            }
                            else
                            {
                                iddocumentodigitalconceptonuevo = 1;
                            }
                            foreach (documentosdigitalesimpuestos oimpuesto in objimpuestos.Where(a=>a.iddocumentodigitalconcepto==oconcepto.iddocumentodigitalconcepto).ToList())
                            {
                                oimpuesto.iddocumentodigital = obj.iddocumentodigital;
                                oimpuesto.iddocumentodigitalconcepto = iddocumentodigitalconceptonuevo;

                                int iddocumentodigitalimpuestonuevo = 0;
                                if (db.documentosdigitalesimpuestos.OrderByDescending(i => i.iddocumentodigitalimpuesto).Count() > 0)
                                {
                                    iddocumentodigitalimpuestonuevo = (db.documentosdigitalesimpuestos.OrderByDescending(i => i.iddocumentodigitalimpuesto).FirstOrDefault().iddocumentodigitalimpuesto + 1);
                                }
                                else
                                {
                                    iddocumentodigitalimpuestonuevo = 1;
                                }
                                oimpuesto.iddocumentodigitalimpuesto = iddocumentodigitalimpuestonuevo;
                                db.documentosdigitalesimpuestos.Add(oimpuesto);
                                db.SaveChanges();
                            }
                            oconcepto.iddocumentodigitalconcepto = iddocumentodigitalconceptonuevo;
                            db.documentosdigitalesconceptos.Add(oconcepto);
                            db.SaveChanges();
                        }




                        transaction.Commit();
                        return log;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log = ex.Message;
                    }
                }
            }

            return log;
        }
    }
}
