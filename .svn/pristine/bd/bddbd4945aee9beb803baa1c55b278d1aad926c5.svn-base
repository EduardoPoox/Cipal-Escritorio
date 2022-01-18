using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class contribuyentesapocrifonc
    {
        public static List<contribuyentesapocrifos> getcontribuyentesapocrifos(string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            return obj.getcontribuyentesapocrifos();
        }

        public static List<contribuyentesapocrifos> getcontribuyentesapocrifosbyparams(string nombre, string rfc, string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            return obj.getcontribuyentesapocrifosbyparams(nombre, rfc);
        }
        
        public static contribuyentesapocrifos getcontribuyentesapocrifo(int id, string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            return obj.getcontribuyentesapocrifo(id);
        }

        public static void save(contribuyentesapocrifos entidad, string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            obj.save(entidad);
        }

        public static void update(contribuyentesapocrifos entidad, string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            obj.clear();
        }

        public static void delete(contribuyentesapocrifos entidad, string cnn)
        {
            contribuyentesapocrifodalc obj = new contribuyentesapocrifodalc(cnn);
            obj.delete(entidad);
        }
    }
}
