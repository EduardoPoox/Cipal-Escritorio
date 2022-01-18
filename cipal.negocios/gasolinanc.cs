using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class gasolinanc
    {
        public static List<gasolinas> getgasolinas(string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            return obj.getgasolinas();
        }

        public static List<gasolinas> getgasolinasbyparams(string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            return obj.getgasolinasbyparams();
        }
        
        public static gasolinas getgasolina(int id, string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            return obj.getgasolina(id);
        }

        public static void save(gasolinas entidad, string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            obj.save(entidad);
        }

        public static void update(gasolinas entidad, string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            obj.clear();
        }

        public static void delete(gasolinas entidad, string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            obj.delete(entidad);
        }

        public static List<gasolinas> getgasolinasbyiddocumentodigital(int iddocumentodigital,string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            return obj.getgasolinasbyiddocumentodigital(iddocumentodigital);
        }

        public static int getgasolinasgenerados(int iddocumentodigital, string cnn)
        {
            gasolinadalc obj = new gasolinadalc(cnn);
            return obj.getgasolinasgenerados(iddocumentodigital);
        }
    }
}
