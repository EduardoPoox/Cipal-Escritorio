using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class informenc
    {
        public static List<informes> getinformes(string cnn)
        {
            informedalc obj = new informedalc(cnn);
            return obj.getinformes();
        }

        public static List<informes> getinformesbyparams(string empleado, string folio, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            return obj.getinformesbyparams(empleado, folio);
        }

        public static informes getinforme(int id, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            return obj.getinforme(id);
        }

        public static void save(informes entidad, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            obj.save(entidad);
        }

        public static void update(informes entidad, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            informedalc obj = new informedalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            informedalc obj = new informedalc(cnn);
            obj.clear();
        }

        public static void delete(informes entidad, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            obj.delete(entidad);
        }

        public static int getinformesgenerados(int iddocumentodigital, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            return obj.getinformesgenerados(iddocumentodigital);
        }


        public static informes getinformegenerado(int iddocumentodigital, string cnn)
        {
            informedalc obj = new informedalc(cnn);
            return obj.getinformegenerado(iddocumentodigital);
        }

    }
}
