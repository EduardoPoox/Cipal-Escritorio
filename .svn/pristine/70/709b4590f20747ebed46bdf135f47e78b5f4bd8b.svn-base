using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class detpedidodalc
    {
        private string _cnn;
        public detpedidodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<detpedidos> getdetpedidos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detpedidos.ToList();
            }
        }

        public detpedidos getdetpedido(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detpedidos.Where(a => a.iddetpedido == id).Count() > 0)
                {
                    return db.detpedidos.Where(a => a.iddetpedido == id).First();
                }
                else
                {
                    return new detpedidos();
                }
            }
        }

        public void save(detpedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detpedidos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(detpedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detpedidos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.detpedidos.Count() > 0)
                {
                    return (db.detpedidos.OrderByDescending(i => i.iddetpedido).FirstOrDefault().iddetpedido + 1);
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
                db.detpedidos.RemoveRange(db.detpedidos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(detpedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.detpedidos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<detpedidos> getdetpedidosbyidpedido(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.detpedidos.Where(a => a.baja == false && a.idpedido == id).ToList();
            }
        }

    }
}
