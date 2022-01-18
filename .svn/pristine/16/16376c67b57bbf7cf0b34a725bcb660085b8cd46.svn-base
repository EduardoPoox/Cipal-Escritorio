using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vsolicitudnc
    {
        public static List<vsolicitudes> getvsolicitudes(string cnn)
        {
            vsolicituddalc obj = new vsolicituddalc(cnn);
            return obj.getvsolicitudes();
        }

        public static List<vsolicitudes> getvsolicitudesbyparams(string folio, DateTime fi, DateTime ff,string cnn)
        {
            vsolicituddalc obj = new vsolicituddalc(cnn);
            if(string.IsNullOrEmpty(folio))
                return obj.getvsolicitudesbyparams(fi, ff);
            else
                return obj.getvsolicitudesbyfolio(folio);
        }

        public static vsolicitudes getvsolicitud(int id, string cnn)
        {
            vsolicituddalc obj = new vsolicituddalc(cnn);
            return obj.getvsolicitud(id);
        }



    }
}
