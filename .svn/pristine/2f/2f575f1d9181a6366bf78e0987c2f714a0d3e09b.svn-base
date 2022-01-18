using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vapoyonc
    {
        public static List<vapoyos> getapoyos(string cnn)
        {
            vapoyodalc obj = new vapoyodalc(cnn);
            return obj.getapoyos();
        }

        public static List<vapoyos> getapoyosbyparams(string folio, int idtipoapoyo, string cnn)
        {
            vapoyodalc obj = new vapoyodalc(cnn);
            return obj.getapoyosbyparams(folio, idtipoapoyo);
        }

        public static vapoyos getapoyo(int id, string cnn)
        {
            vapoyodalc obj = new vapoyodalc(cnn);
            return obj.getapoyo(id);
        }

    }
}
