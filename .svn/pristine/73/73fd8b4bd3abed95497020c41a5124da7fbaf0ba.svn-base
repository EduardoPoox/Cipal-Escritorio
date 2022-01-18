using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class movinventarionc
    {
        public static List<movinventarios> getmovinventarios(string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            return obj.getmovinventarios();
        }

        public static movinventarios getmovinventario(int id, string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            return obj.getmovinventario(id);
        }

        public static void save(movinventarios entidad, string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            obj.save(entidad);
        }

        public static void update(movinventarios entidad, string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            obj.clear();
        }

        public static void delete(movinventarios entidad, string cnn)
        {
            movinventariodalc obj = new movinventariodalc(cnn);
            obj.delete(entidad);
        }
    }
}
