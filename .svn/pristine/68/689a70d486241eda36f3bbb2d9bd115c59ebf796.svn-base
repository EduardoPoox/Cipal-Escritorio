using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class impdetpedidonc
    {
        public static List<impdetpedidos> getimpdetpedidos(string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            return obj.getimpdetpedidos();
        }

        public static impdetpedidos getimpdetpedido(int id, string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            return obj.getimpdetpedido(id);
        }

        public static List<impdetpedidos> getimpdetpedidoporpedido(int idpedido, string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            return obj.getimpdetpedidoporpedido(idpedido);
        }

        public static void save(impdetpedidos entidad, string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            obj.save(entidad);
        }

        public static void update(impdetpedidos entidad, string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            obj.update(entidad);
        }

        public static int getid(string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            obj.clear();
        }

        public static void delete(impdetpedidos entidad, string cnn)
        {
            impdetpedidodalc obj = new impdetpedidodalc(cnn);
            obj.delete(entidad);
        }
    }
}
