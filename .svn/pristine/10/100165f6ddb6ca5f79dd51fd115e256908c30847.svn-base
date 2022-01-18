using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class impdetpedidodalc
    {
        private string _cnn;
        public impdetpedidodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<impdetpedidos> getimpdetpedidos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.impdetpedidos.ToList();
            }
        }

        public impdetpedidos getimpdetpedido(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.impdetpedidos.Where(a => a.idimpdetpedido == id).Count() > 0)
                {
                    return db.impdetpedidos.Where(a => a.idimpdetpedido == id).First();
                }
                else
                {
                    return new impdetpedidos();
                }
            }
        }

        public List<impdetpedidos> getimpdetpedidoporpedido(int idpedido)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.impdetpedidos.Where(a => a.baja == false && a.idpedido == idpedido).ToList();
            }
        }

        public void save(impdetpedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.impdetpedidos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(impdetpedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.impdetpedidos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.impdetpedidos.Count() > 0)
                {
                    return (db.impdetpedidos.OrderByDescending(i => i.idimpdetpedido).FirstOrDefault().idimpdetpedido + 1);
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
                db.impdetpedidos.RemoveRange(db.impdetpedidos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(impdetpedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.impdetpedidos.Remove(obj);
                db.SaveChanges();
            }
        }


    }
}
