using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class conceptonc
    {
        public static List<conceptos> getconceptos(string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            return obj.getconceptos();
        }

        public static List<conceptos> getconceptosbyparams(string tipoconcepto,string nombre, string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            return obj.getconceptosbyparams(tipoconcepto,nombre);
        }

        public static conceptos getconcepto(int id, string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            return obj.getconcepto(id);
        }

        public static void save(conceptos entidad, string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            obj.save(entidad);
        }

        public static void update(conceptos entidad, string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            obj.clear();
        }

        public static void delete(conceptos entidad, string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            obj.delete(entidad);
        }


        public static bool existeconcepto(string clavesat,string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            return obj.existeconcepto(clavesat);
        }

        public static conceptos getconceptobyclavesat(string clavesat,string cnn)
        {
            conceptodalc obj = new conceptodalc(cnn);
            return obj.getconceptobyclavesat(clavesat);
        }
    }
}
