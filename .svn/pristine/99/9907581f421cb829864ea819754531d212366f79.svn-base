using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class ordennc
    {
        public static List<ordenes> getordenes(string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            return obj.getordenes();
        }

        public static List<ordenes> getordenesbyparams(string folio, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            return obj.getordenesbyparams(folio); 
        }

        public static ordenes getorden(int id, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            return obj.getorden(id);
        }

        public static void save(ordenes entidad, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            obj.save(entidad);
        }

        public static void update(ordenes entidad, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            obj.clear();
        }

        public static void delete(ordenes entidad, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            obj.delete(entidad);
        }

        public static int getordenesgenerados(int iddocumentodigital, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            return obj.getordenesgenerados(iddocumentodigital);
        }

        public static ordenes getordengenerado(int iddocumentodigital, string cnn)
        {
            ordendalc obj = new ordendalc(cnn);
            return obj.getordengenerado(iddocumentodigital);
        }
    }
}
