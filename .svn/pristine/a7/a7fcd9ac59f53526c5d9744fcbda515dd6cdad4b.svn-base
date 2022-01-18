using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class detmantenimientonc
    {
        public static List<detmantenimientos> getdetmantenimientos(string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            return obj.getdetmantenimientos();
        }

        public static detmantenimientos getdetmantenimiento(int id, string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            return obj.getdetmantenimiento(id);
        }

        public static void save(detmantenimientos entidad, string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            obj.save(entidad);
        }

        public static void update(detmantenimientos entidad, string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            obj.clear();
        }

        public static void delete(detmantenimientos entidad, string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            obj.delete(entidad);
        }

        public static List<detmantenimientos> getdetmantenimientosbyid(int id, string cnn)
        {
            detmantenimientodalc obj = new detmantenimientodalc(cnn);
            return obj.getdetmantenimientosbyid(id);
        }
    }
}
