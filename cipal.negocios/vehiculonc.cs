using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vehiculonc
    {
        public static List<vehiculos> getvehiculos(string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            return obj.getvehiculos();
        }

        public static vehiculos getvehiculo(int id, string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            return obj.getvehiculo(id);
        }

        public static void save(vehiculos entidad, string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            obj.save(entidad);
        }

        public static void update(vehiculos entidad, string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            obj.clear();
        }

        public static void delete(vehiculos entidad, string cnn)
        {
            vehiculodalc obj = new vehiculodalc(cnn);
            obj.delete(entidad);
        }
    }
}
