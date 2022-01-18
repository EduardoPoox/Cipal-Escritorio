using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class tipoingresonc
    {
        public static List<tipoingresos> gettipoingresos(string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            return obj.gettipoingresos();
        }

        public static tipoingresos gettipoingreso(int id, string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            return obj.gettipoingreso(id);
        }

        public static void save(tipoingresos entidad, string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            obj.save(entidad);
        }

        public static void update(tipoingresos entidad, string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            obj.clear();
        }

        public static void delete(tipoingresos entidad, string cnn)
        {
            tipoingresodalc obj = new tipoingresodalc(cnn);
            obj.delete(entidad);
        }
    }
}
