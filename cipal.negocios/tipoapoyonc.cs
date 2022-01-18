using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class tipoapoyonc
    {
        public static List<tipoapoyos> gettipoapoyos(string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            return obj.gettipoapoyos();
        }

        /*public static List<tipoapoyos> gettipoapoyosbyparams(string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            return obj.gettipoapoyosbyparams();
        }*/

        
        public static tipoapoyos gettipoapoyo(int id, string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            return obj.gettipoapoyo(id);
        }

        public static void save(tipoapoyos entidad, string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            obj.save(entidad);
        }

        public static void update(tipoapoyos entidad, string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            obj.clear();
        }

        public static void delete(tipoapoyos entidad, string cnn)
        {
            tipoapoyodalc obj = new tipoapoyodalc(cnn);
            obj.delete(entidad);
        }
    }
}
