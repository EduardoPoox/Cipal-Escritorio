using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;



namespace cipal.negocios
{
    public class detconstancianc
    {
        public static List<detconstancias> getdetconstancias(string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            return obj.getdetconstancias();
        }

        public static detconstancias getdetconstancia(int id, string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            return obj.getdetconstancia(id);
        }

        public static void save(detconstancias entidad, string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            obj.save(entidad);
        }

        public static void update(detconstancias entidad, string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            obj.clear();
        }

        public static void delete(detconstancias entidad, string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            obj.delete(entidad);
        }
        public static List<detconstancias> getdetconstanciasporid(int id, string cnn)
        {
            detconstanciadalc obj = new detconstanciadalc(cnn);
            return obj.getdetconstanciasporid(id);
        }
    }
}
