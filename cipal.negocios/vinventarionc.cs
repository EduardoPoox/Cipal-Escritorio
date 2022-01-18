using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using cipal.entidades;
using cipal.datos;


namespace cipal.negocios
{
    public class vinventarionc
    {
        public static List<vinventarios> getinventarios(string cnn)
        {
            vinventariodalc obj = new vinventariodalc(cnn);
            return obj.getinventarios();
        }

        public static List<vinventarios> getinventariosbyparams(int idconcepto, string cnn)
        {
            vinventariodalc obj = new vinventariodalc(cnn);
            return obj.getinventariosbyparams(idconcepto);
        }

        public static vinventarios getinventario(int id, string cnn)
        {
            vinventariodalc obj = new vinventariodalc(cnn);
            return obj.getinventario(id);
        }
    }
}
