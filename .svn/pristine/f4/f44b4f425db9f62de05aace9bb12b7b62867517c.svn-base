using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class inventarionc
    {
        public static List<inventarios> getinventarios(string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            return obj.getinventarios();
        }

        public static List<inventarios> getinventariosbyparams(string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            return obj.getinventariosbyparams();
        }
        
        public static inventarios getinventario(int id, string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            return obj.getinventario(id);
        }

        public static void save(inventarios entidad, string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            obj.save(entidad);
        }

        public static void update(inventarios entidad, string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            obj.clear();
        }

        public static void delete(inventarios entidad, string cnn)
        {
            inventariodalc obj = new inventariodalc(cnn);
            obj.delete(entidad);
        }
    }
}
