using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class cobropredialnc
    {
        public static List<cobropredial> getcobroprediales(string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            return obj.getcobroprediales();
        }

        /*public static List<cobropredial> getcobropredialbyparams(string tipoapoyo, string folio, string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            return obj.getcobropredialbyparams(tipoapoyo, folio);
        }*/

        public static cobropredial getcobropredial(int id, string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            return obj.getcobropredial(id);
        }

        public static void save(cobropredial entidad, string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            obj.save(entidad);
        }

        public static void update(cobropredial entidad, string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            obj.clear();
        }

        public static void delete(cobropredial entidad, string cnn)
        {
            cobropredialdalc obj = new cobropredialdalc(cnn);
            obj.delete(entidad);
        }
    }
}
