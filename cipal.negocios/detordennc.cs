using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class detordennc
    {
        public static List<detordenes> getdetordenes(string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            return obj.getdetordenes();
        }

        public static detordenes getdetorden(int id, string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            return obj.getdetorden(id);
        }

        public static void save(detordenes entidad, string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            obj.save(entidad);
        }

        public static void update(detordenes entidad, string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            obj.clear();
        }

        public static void delete(detordenes entidad, string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            obj.delete(entidad);
        }

        public static List<detordenes> getdetordenesporid(int id, string cnn)
        {
            detordendalc obj = new detordendalc(cnn);
            return obj.getdetordenesporid(id);
        }
    }
}
