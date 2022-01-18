using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class apoyonc
    {
        public static List<apoyos> getapoyos(string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            return obj.getapoyos();
        }

        public static List<apoyos> getapoyosbyparams(string tipoapoyo, string folio, string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            return obj.getapoyosbyparams(tipoapoyo, folio);
        }

        public static apoyos getapoyo(int id, string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            return obj.getapoyo(id);
        }

        public static void save (apoyos entidad, string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            obj.save(entidad);
        }

        public static void update(apoyos entidad, string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            obj.clear();
        }

        public static void delete(apoyos entidad, string cnn)
        {
            apoyodalc obj = new apoyodalc(cnn);
            obj.delete(entidad);
        }

    }
}
