using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;

namespace cipal.datos
{
    public class vgasolinadalc
    {
        private string _cnn;
        public vgasolinadalc(string cnn)
        {
            EntityConnectionStringBuilder sbcnn = new EntityConnectionStringBuilder();
            sbcnn.Provider = "System.Data.SqlClient";
            sbcnn.ProviderConnectionString = cnn;
            sbcnn.Metadata = @"res://*/DBcipal.csdl|res://*/DBcipal.ssdl|res://*/DBcipal.msl";
            this._cnn = sbcnn.ToString();
        }

        public List<vgasolinas> getgasolinas()
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.ToList();
            }
        }

        public List<vgasolinas> getgasolinasbyparams(int iddepartamento, int idvehiculo, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.Where(a=> a.iddepartamento==iddepartamento && a.idvehiculo== idvehiculo && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vgasolinas> getgasolinasbyiddepartamentofechas(int iddepartamento, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.Where(a => a.iddepartamento == iddepartamento && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vgasolinas> getgasolinasbyidvehiculofechas(int idvehiculo, DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.Where(a => a.idvehiculo == idvehiculo && a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public List<vgasolinas> getgasolinasbyfechas( DateTime fi, DateTime ff)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.Where(a => a.fecha >= fi && a.fecha <= ff).ToList();
            }
        }

        public vgasolinas getgasolina(int id)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                if (db.vgasolinas.Where(a => a.idgasolina == id).Count() > 0)
                {
                    return db.vgasolinas.Where(a => a.idgasolina == id).First();
                }
                else
                {
                    return new vgasolinas();
                }
            }
        }


        public List<vgasolinas> getvgasolinasbyiddocumentodigital(int iddocumentodigital)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.Where(a => a.iddocumentodigital == iddocumentodigital).ToList();
            }
        }


        public List<vgasolinas> getgasolinasbyfolio(string folio)
        {
            using (DBcipalEntities db = new DBcipalEntities(this._cnn))
            {
                return db.vgasolinas.Where(a => a.baja == false && a.folio.Contains(folio)).ToList();
            }
        }

    }
}
