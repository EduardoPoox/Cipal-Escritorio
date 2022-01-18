using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;


namespace cipal.negocios
{
    public class detgasolinanc
    {
        public static List<detgasolinas> getdetgasolinas(string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            return obj.getdetgasolinas();
        }

        public static detgasolinas getdetgasolina(int id, string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            return obj.getdetgasolina(id);
        }

        public static void save(detgasolinas entidad, string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            obj.save(entidad);
        }

        public static void update(detgasolinas entidad, string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            obj.clear();
        }

        public static void delete(detgasolinas entidad, string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            obj.delete(entidad);
        }

        public static List<detgasolinas> getdetgasolinasbyid(int idgasolina,string cnn)
        {
            detgasolinadalc obj = new detgasolinadalc(cnn);
            return obj.getdetgasolinasbyid(idgasolina);
        }
    }
}
