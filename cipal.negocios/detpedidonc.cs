using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class detpedidonc
    {
        public static List<detpedidos> getdetpedidos(string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            return obj.getdetpedidos();
        }

        public static detpedidos getdetpedido(int id, string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            return obj.getdetpedido(id);
        }

        public static void save(detpedidos entidad, string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            obj.save(entidad);
        }

        public static void update(detpedidos entidad, string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            obj.clear();
        }

        public static void delete(detpedidos entidad, string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            obj.delete(entidad);
        }

        public static List<detpedidos> getdetpedidosbyidpedido(int id, string cnn)
        {
            detpedidodalc obj = new detpedidodalc(cnn);
            return obj.getdetpedidosbyidpedido(id);
        }
    }
}
