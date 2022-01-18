using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class pedidodalc
    {
        private string _cnn;
        public pedidodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<pedidos> getpedidos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.pedidos.Where(a=>a.baja==false).ToList();
            }
        }

        public List<pedidos> getpedidosbyparams(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.pedidos.Where(a=>a.baja==false && a.folio.Contains(folio)).ToList();
            }
        }

        public pedidos getpedido(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.pedidos.Where(a => a.idpedido == id).Count() > 0)
                {
                    return db.pedidos.Where(a => a.idpedido == id).First();
                }
                else
                {
                    return new pedidos();
                }
            }
        }

        public void save(pedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.pedidos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(pedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.pedidos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.pedidos.Count() > 0)
                {
                    return (db.pedidos.OrderByDescending(i => i.idpedido).FirstOrDefault().idpedido + 1);
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
                db.pedidos.RemoveRange(db.pedidos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(pedidos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.pedidos.Remove(obj);
                db.SaveChanges();
            }
        }


        public int getpedidosgenerados(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.pedidos.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().Count();
            }
        }

        public pedidos getpedidogenerado(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.pedidos.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).Count() > 0)
                {
                    return db.pedidos.Where(a => a.baja == false && a.iddocumentodigital == iddocumentodigital).ToList().First();
                }
                else
                {
                    return new pedidos();
                }
            }
        }

    }
}
