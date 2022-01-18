using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class detinformenc
    {
        public static List<detinformes> getdetinformes(string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            return obj.getdetinformes();
        }

        public static detinformes getdetinforme(int id, string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            return obj.getdetinforme(id);
        }

        public static void save(detinformes entidad, string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            obj.save(entidad);
        }

        public static void update(detinformes entidad, string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            obj.clear();
        }

        public static void delete(detinformes entidad, string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            obj.delete(entidad);
        }

        public static List<detinformes> getdetinformesporid(int id, string cnn)
        {
            detinformedalc obj = new detinformedalc(cnn);
            return obj.getdetinformesporid(id);
        }
    }
}
