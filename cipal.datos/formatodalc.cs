using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;


namespace cipal.datos
{
    public class formatodalc
    {
        private string _cnn;
        public formatodalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }
        public List<formatos> getformatos()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.formatos.Where(a => a.baja == false).ToList();
            }
        }
        public List<formatos> getformatosvigentes()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.formatos.Where(a => a.baja == false && a.vigente==true).ToList();
            }
        }
        public List<formatos> getformatosvigentesbygrupoformatos(string grupoformato)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.formatos.Where(a => a.baja == false && a.vigente == true && a.clasificador==grupoformato).ToList();
            }
        }
        public formatos getformatosvigentesbygrupoformatoandtipo(string grupoformato, string tipo)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.formatos.Where(a => a.baja == false && a.vigente == true && a.clasificador == grupoformato && a.tipo == tipo).Count() > 0)
                {
                    return db.formatos.Where(a => a.baja == false && a.vigente == true && a.clasificador == grupoformato && a.tipo == tipo).First();
                }
                else
                {
                    return new formatos();
                }
            }
        }



        public formatos getformato(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.formatos.Where(a => a.idformato == id).Count() > 0)
                {
                    return db.formatos.Where(a => a.idformato == id).First();
                }
                else
                {
                    return new formatos();
                }
            }
        }

        public void save(formatos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.formatos.Add(obj);
                db.SaveChanges();
            }
        }

        public void update(formatos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.formatos.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int getid()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.formatos.Count() > 0)
                {
                    return (db.formatos.OrderByDescending(i => i.idformato).FirstOrDefault().idformato + 1);
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
                db.formatos.RemoveRange(db.formatos.AsEnumerable());
                db.SaveChanges();
            }
        }

        public void delete(formatos obj)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                db.formatos.Remove(obj);
                db.SaveChanges();
            }
        }


        public List<formatos> getformatosbygrupogeneral(string grupogeneral)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.formatos.Where(a => a.baja == false && a.tipogeneral == grupogeneral).ToList();
            }
        }


    }
}
