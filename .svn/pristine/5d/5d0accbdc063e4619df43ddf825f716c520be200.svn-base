using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vordennc
    {
        public static List<vordenes> getvordenes(string cnn)
        {
            vordendalc obj = new vordendalc(cnn);
            return obj.getvordenes();
        }

        public static List<vordenes> getvordenesbyparams(string folio, DateTime fi, DateTime ff, string cnn)
        {
            vordendalc obj = new vordendalc(cnn);

            if (string.IsNullOrEmpty(folio))
                return obj.getvordenesbyparams(fi, ff);
            else
                return obj.getvordenesbyfolio(folio);

        }

        public static vordenes getvorden(int id, string cnn)
        {
            vordendalc obj = new vordendalc(cnn);
            return obj.getvorden(id);
        }

    }
}
