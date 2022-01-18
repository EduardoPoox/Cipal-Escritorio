using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class unidadnc
    {
        public static List<unidades> getunidades(string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            return obj.getunidades();
        }

        public static unidades getunidad(int id, string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            return obj.getunidad(id);
        }

        public static void save(unidades entidad, string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            obj.save(entidad);
        }

        public static void update(unidades entidad, string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            obj.clear();
        }

        public static void delete(unidades entidad, string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            obj.delete(entidad);
        }


        public static bool existeunidad(string claveunidad,string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            return obj.existeunidad(claveunidad);
        }

        public static unidades getunidadbyclaveunidad(string claveunidad, string cnn)
        {
            unidaddalc obj = new unidaddalc(cnn);
            return obj.getunidadbyclaveunidad(claveunidad);
        }

    }
}
