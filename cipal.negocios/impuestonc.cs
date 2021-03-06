using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{

    public class impuestonc
    {
        public static List<impuestos> getimpuestos(string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            return obj.getimpuestos();
        }

        public static impuestos getimpuesto(int id, string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            return obj.getimpuesto(id);
        }

        public static void save(impuestos entidad, string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            obj.save(entidad);
        }

        public static void update(impuestos entidad, string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            obj.clear();
        }

        public static void delete(impuestos entidad, string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            obj.delete(entidad);
        }

        public static impuestos getimpuestobyparams(string tipoimpuesto, string cveimpuesto, decimal tasa, string cnn)
        {
            impuestodalc obj = new impuestodalc(cnn);
            return obj.getimpuestobyparams(tipoimpuesto,cveimpuesto,tasa);
        }
    }

}
