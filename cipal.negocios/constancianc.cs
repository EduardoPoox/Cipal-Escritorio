using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class constancianc
    {
        public static List<constancias> getconstancias(string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            return obj.getconstancias();
        }

        public static constancias getconstancia(int id, string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            return obj.getconstancia(id);
        }

        public static void save(constancias entidad, string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            obj.save(entidad);
        }

        public static void update(constancias entidad, string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            obj.clear();
        }

        public static void delete(constancias entidad, string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            obj.delete(entidad);
        }

        public static int getconstanciasgenerados(int iddocumentodigital, string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            return obj.getconstanciasgenerados(iddocumentodigital);
        }

        public static constancias getconstanciagenerado(int iddocumentodigital, string cnn)
        {
            constanciadalc obj = new constanciadalc(cnn);
            return obj.getconstanciagenerado(iddocumentodigital);
        }
    }
}
