using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vinformenc
    {
        public static List<vinformes> getinformes(string cnn)
        {
            vinformedalc obj = new vinformedalc(cnn);
            return obj.getinformes();
        }

        public static List<vinformes> getvinformesbyparams(string folio, DateTime fi, DateTime ff, string cnn)
        {
            vinformedalc obj = new vinformedalc(cnn);
            if (string.IsNullOrEmpty(folio))
                return obj.getvinformesbyparams(fi, ff);
            else
                return obj.getvinformesbyfolio(folio);
        }
        public static vinformes getinforme(int id, string cnn)
        {
            vinformedalc obj = new vinformedalc(cnn);
            return obj.getinforme(id);
        }
    }
}
