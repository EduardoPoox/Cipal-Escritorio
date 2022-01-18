using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class beneficiarionc
    {
        public static List<beneficiarios> getbeneficiarios(string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            return obj.getbeneficiarios();
        }
        public static List<beneficiarios> getbeneficiariosbyparams(string rfc, string nombre, string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            return obj.getbeneficiariosbyparams(rfc, nombre);
        }

        public static beneficiarios getbeneficiario(int id, string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            return obj.getbeneficiario(id);
        }

        public static void save(beneficiarios entidad, string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            obj.save(entidad);
        }

        public static void update(beneficiarios entidad, string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            obj.clear();
        }

        public static void delete(beneficiarios entidad, string cnn)
        {
            beneficiariodalc obj = new beneficiariodalc(cnn);
            obj.delete(entidad);
        }

    }

}
