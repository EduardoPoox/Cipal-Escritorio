using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class mantenimientonc
    {
        public static List<mantenimientos> getmantenimientos(string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            return obj.getmantenimientos();
        }

        public static List<mantenimientos> getmantenimientosbyparams(string folio, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            return obj.getmantenimientosbyparams(folio);
        }
        
        public static mantenimientos getmantenimiento(int id, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            return obj.getmantenimiento(id);
        }

        public static void save(mantenimientos entidad, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            obj.save(entidad);
        }

        public static void update(mantenimientos entidad, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            obj.clear();
        }

        public static void delete(mantenimientos entidad, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            obj.delete(entidad);
        }


        public static List<mantenimientos> getmantenimientosbyiddocumentodigital(int iddocumentodigital, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            return obj.getmantenimientosbyiddocumentodigital(iddocumentodigital);
        }

        public static int getmantenimientosgenerados(int iddocumentodigital, string cnn)
        {
            mantenimientodalc obj = new mantenimientodalc(cnn);
            return obj.getmantenimientosgenerados(iddocumentodigital);
        }
    }
}

