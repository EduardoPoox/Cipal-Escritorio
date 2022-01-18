using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class proveedordalc
    {
        private string _cnn;
        public proveedordalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<proveedores> getproveedores()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.proveedores.Where(a=>a.baja==false).ToList();
            }
        }

        public List<proveedores> getproveedoresbyparams(string rfc, string nombre)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.proveedores.Where(a => a.baja == false && a.rfc.Contains(rfc) && a.nombre.Contains(nombre)).ToList();
            }
        }

        public proveedores getproveedor(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.proveedores.Where(a => a.idproveedor == id).Count() > 0)
                {
                    return db.proveedores.Where(a => a.idproveedor == id).First();
                }
                else
                {
                    return new proveedores();
                }
            }
        }

        public void save(proveedores obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.proveedores.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(proveedores obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.proveedores.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.proveedores.Count() > 0)
                {
                    return (db.proveedores.OrderByDescending(i => i.idproveedor).FirstOrDefault().idproveedor + 1);
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
                db.proveedores.RemoveRange(db.proveedores.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(proveedores obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.proveedores.Remove(obj);
                db.SaveChanges();
            }
        }

        public bool existeproveedor(string rfc)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.proveedores.Where(a => a.baja == false && a.rfc == rfc).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public proveedores getproveedorbyrfc(string rfc)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.proveedores.Where(a => a.baja == false && a.rfc == rfc).Count() > 0)
                {
                    return db.proveedores.Where(a => a.baja == false && a.rfc == rfc).First();
                }
                else
                {
                    return new proveedores();
                }
            }
        }

    }
}
