using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class puestonc
    {
        public static List<puestos> getpuestos(string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            return obj.getpuestos();
        }

        public static puestos getpuesto(int id, string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            return obj.getpuesto(id);
        }

        public static void save(puestos entidad, string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            obj.save(entidad);
        }

        public static void update(puestos entidad, string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            obj.clear();
        }

        public static void delete(puestos entidad, string cnn)
        {
            puestodalc obj = new puestodalc(cnn);
            obj.delete(entidad);
        }
    }
}
