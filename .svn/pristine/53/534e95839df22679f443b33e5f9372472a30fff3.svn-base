using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class empresanc 
    {
        public static List<empresa> getempresa(string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            return obj.getempresa();
        }

        public static empresa getempresa(int id,string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            return obj.getempresa(id);
        }

        public static void save(empresa entidad, string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            obj.save(entidad);
        }

        public static void update(empresa entidad,string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            obj.clear();
        }

        public static void delete(empresa entidad,string cnn)
        {
            empresadalc obj = new empresadalc(cnn);
            obj.delete(entidad);
        }
    }
}
