using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class contribuyentenc
    {
        public static List<contribuyentes> getcontribuyentes(string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            return obj.getcontribuyentes();
        }
        public static List<contribuyentes> getcontribuyentesbyparams(string rfc, string nombre,string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            return obj.getcontribuyentesbyparams(rfc, nombre);
        }

        public static contribuyentes getcontribuyentes(int id, string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            return obj.getcontribuyente(id);
        }

        public static void save(contribuyentes entidad, string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            obj.save(entidad);
        }

        public static void update(contribuyentes entidad, string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            obj.clear();
        }

        public static void delete(contribuyentes entidad, string cnn)
        {
            contribuyentedalc obj = new contribuyentedalc(cnn);
            obj.delete(entidad);
        }
    }
}
