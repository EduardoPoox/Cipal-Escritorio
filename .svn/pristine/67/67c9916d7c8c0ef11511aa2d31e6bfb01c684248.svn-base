using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class seriefoliaciondalc
    {
        private string _cnn;
        public seriefoliaciondalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }

        public List<seriesfoliacion> getseriesfoliacion()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.seriesfoliacion.Where(a => a.baja == false).ToList();
            }
        }
        public List<seriesfoliacion> getseriesfoliacionvigentes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.seriesfoliacion.Where(a => a.baja == false && a.vigente ==true).ToList();
            }
        }
        public seriesfoliacion getseriefoliacionvigentebytiposerie(string tiposerie)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.seriesfoliacion.Where(a => a.baja == false && a.vigente==true && a.tiposerie==tiposerie).Count() > 0)
                {
                    return db.seriesfoliacion.Where(a => a.baja == false && a.vigente == true && a.tiposerie == tiposerie).First();
                }
                else
                {
                    return new seriesfoliacion();
                }
            }
        }

        public seriesfoliacion getseriefoliacion(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.seriesfoliacion.Where(a => a.idseriefoliacion == id).Count() > 0)
                {
                    return db.seriesfoliacion.Where(a => a.idseriefoliacion == id).First();
                }
                else
                {
                    return new seriesfoliacion();
                }
            }
        }

        public void save(seriesfoliacion obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.seriesfoliacion.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(seriesfoliacion obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.seriesfoliacion.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.seriesfoliacion.Count() > 0)
                {
                    return (db.seriesfoliacion.OrderByDescending(i => i.idseriefoliacion).FirstOrDefault().idseriefoliacion + 1);
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
                db.seriesfoliacion.RemoveRange(db.seriesfoliacion.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(seriesfoliacion obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.seriesfoliacion.Remove(obj);
                db.SaveChanges();
            }
        }

        //DALC - Consulta las series de foliación de un tipo en específico
        public List<seriesfoliacion> getseriesfoliacionbytiposerie(string tiposerie)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.seriesfoliacion.Where(a => a.baja == false && a.tiposerie.Contains(tiposerie)).ToList();
            }
        }

    }
}
