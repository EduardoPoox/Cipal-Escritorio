using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vingresonc
    {
        public static List<vingresos> getingresos(string cnn)
        {
            vingresodalc obj = new vingresodalc(cnn);
            return obj.getingreso();
        }
        
        public static List<vingresos> getingresosbyparams(int idtipoingreso,DateTime fi,DateTime ff, string folio, string cnn)
        {
            vingresodalc obj = new vingresodalc(cnn);
            if (folio != "")
            {
                return obj.getingresosbyfolio(folio);
            }
            else
            {
                if (idtipoingreso == 0)
                {
                    return obj.getingresosbyfechas(fi, ff);
                }
                else
                {
                    return obj.getingresosbyparams(idtipoingreso, fi, ff);
                }
            }
        }

        public static vingresos getingreso(int id, string cnn)
        {
            vingresodalc obj = new vingresodalc(cnn);
            return obj.getingreso(id);
        }

    }
}
