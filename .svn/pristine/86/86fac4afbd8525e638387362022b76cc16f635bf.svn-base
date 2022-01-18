using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class parametronc
    {
        public static List<parametros> getparametros(string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            return obj.getparametros();
        }

        public static parametros getparametro(int id,string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            return obj.getparametro(id);
        }

        public static void save(parametros entidad,string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            obj.save(entidad);
        }

        public static void update(parametros entidad,string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            obj.clear();
        }

        public static void delete(parametros entidad,string cnn)
        {
            parametrodalc obj = new parametrodalc(cnn);
            obj.delete(entidad);
        }
    }
}
