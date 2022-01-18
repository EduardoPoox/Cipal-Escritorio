using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vconstancianc
    {
        public static List<vconstancias> getconstancias(string cnn)
        {
            vconstanciadalc obj = new vconstanciadalc(cnn);
            return obj.getconstancias();
        }

        public static List<vconstancias> getvconstanciasbyparams(string folio, DateTime fi, DateTime ff, string cnn)
        {
            vconstanciadalc obj = new vconstanciadalc(cnn);
            if (string.IsNullOrEmpty(folio))
                return obj.getvconstanciasbyparams(fi, ff);
            else
                return obj.getvconstanciasbyfolio(folio);
        }
        public static vconstancias getconstancia(int id, string cnn)
        {
            vconstanciadalc obj = new vconstanciadalc(cnn);
            return obj.getconstancia(id);
        }
    }
}
