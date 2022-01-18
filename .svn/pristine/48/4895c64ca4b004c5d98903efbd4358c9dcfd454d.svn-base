using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class ingresonc
    {
        public static List<ingresos> getingresos(string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            return obj.getingreso();
        }

        public static List<ingresos> getingresosbyparams(string folio, string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            return obj.getingresosbyparams(folio);
        }
        
        public static ingresos getingreso(int id, string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            return obj.getingreso(id);
        }
        
        public static void save(ingresos entidad, string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            obj.save(entidad);
        }

        public static void update(ingresos entidad, string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            obj.clear();
        }

        public static void delete(ingresos entidad, string cnn)
        {
            ingresodalc obj = new ingresodalc(cnn);
            obj.delete(entidad);
        }
    }
}
