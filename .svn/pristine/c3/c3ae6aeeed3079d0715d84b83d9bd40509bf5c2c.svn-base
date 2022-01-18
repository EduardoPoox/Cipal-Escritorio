using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class detapoyonc
    {
        public static List<detapoyos> getdetapoyos(string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            return obj.getdetapoyos();
        }

        public static detapoyos getdetapoyo(int id, string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            return obj.getdetapoyo(id);
        }

        public static void save(detapoyos entidad, string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            obj.save(entidad);
        }

        public static void update(detapoyos entidad, string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            obj.clear();
        }

        public static void delete(detapoyos entidad, string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            obj.delete(entidad);
        }

        public static List<detapoyos> getdetapoyosporid(int id, string cnn)
        {
            detapoyodalc obj = new detapoyodalc(cnn);
            return obj.getdetapoyosporid(id);
        }
    }
}
