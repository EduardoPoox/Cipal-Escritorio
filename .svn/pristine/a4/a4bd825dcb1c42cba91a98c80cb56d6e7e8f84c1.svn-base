using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class valorpredialnc
    {
        public static List<valorpredial> getvalorprediales(string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            return obj.getvalorprediales();
        }

        /*public static List<valorpredial> getvalorpredialbyparams(string tipoapoyo, string folio, string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            return obj.getvalorpredialbyparams(tipoapoyo, folio);
        }*/

        public static valorpredial getvalorpredial(int id, string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            return obj.getvalorpredial(id);
        }

        public static void save(valorpredial entidad, string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            obj.save(entidad);
        }

        public static void update(valorpredial entidad, string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            obj.clear();
        }

        public static void delete(valorpredial entidad, string cnn)
        {
            valorpredialdalc obj = new valorpredialdalc(cnn);
            obj.delete(entidad);
        }
    }

}
