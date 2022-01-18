using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vmantenimientonc
    {
        public static List<vmantenimientos> getvmantenimientos(string cnn)
        {
            vmantenimientodalc obj = new vmantenimientodalc(cnn);
            return obj.getvmantenimientos();
        }

        public static List<vmantenimientos> getvmantenimientosbyparams(int iddepartamento, int idvehiculo, string folio, DateTime fi, DateTime ff, string cnn)
        {
            vmantenimientodalc obj = new vmantenimientodalc(cnn);

            if (folio != "")
            {
                return obj.getvmantenimientosbyfolio(folio);
            }
            else
            {
                if (iddepartamento == 0 && idvehiculo == 0)
                {
                    return obj.getvmantenimientosbyfechas(fi, ff);
                }
                else
                {
                    if (iddepartamento != 0 && idvehiculo != 0)
                    {
                        return obj.getvmantenimientosbyparams(iddepartamento, idvehiculo, fi, ff);
                    }
                    else
                    {
                        if (iddepartamento != 0)
                        {
                            return obj.getvmantenimientosbyiddepartamentofechas(iddepartamento, fi, ff);
                        }
                        else
                        {
                            return obj.getvmantenimientosbyidvehiculofechas(idvehiculo, fi, ff);
                        }
                    }
                }
            }
        }

        public static vmantenimientos getvmantenimiento(int id, string cnn)
        {
            vmantenimientodalc obj = new vmantenimientodalc(cnn);
            return obj.getvmantenimiento(id);
        }

        public static List<vmantenimientos> getvmantenimientosbyiddocumentodigital(int iddocumentodigital,string cnn)
        {
            vmantenimientodalc obj = new vmantenimientodalc(cnn);
            return obj.getvmantenimientosbyiddocumentodigital(iddocumentodigital);
        }
    }
}
