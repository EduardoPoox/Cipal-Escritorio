using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;

namespace cipal.datos
{
    public class vpedidodalc
    {
        private string _cnn;
        public vpedidodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<vpedidos> getvpedidos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vpedidos.ToList();
            }
        }

        public List<vpedidos> getvpedidosbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vpedidos.Where(a => a.folio.Contains(folio)).ToList();
            }
        }

        public List<vpedidos> getvpedidosbyparams(int iddepartamento, int idproveedor, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vpedidos.Where(a=> a.iddepartamento==iddepartamento && a.idproveedor==idproveedor && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vpedidos> getvpedidosbyiddepartamentofechas(int iddepartamento, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vpedidos.Where(a => a.iddepartamento == iddepartamento && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vpedidos> getvpedidosbyidproveedorfechas(int idproveedor, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vpedidos.Where(a => a.idproveedor == idproveedor && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vpedidos> getvpedidosbyfechas(DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vpedidos.Where(a => a.fecha >= fi && a.fecha <= ff).ToList();

            }
        }

        public vpedidos getvpedido(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vpedidos.Where(a=> a.idpedido == id).Count() > 0)
                {
                    return db.vpedidos.Where(a=> a.idpedido == id).First();
                }
                else
                {
                    return new vpedidos();
                }
            }
        }
    }
}
