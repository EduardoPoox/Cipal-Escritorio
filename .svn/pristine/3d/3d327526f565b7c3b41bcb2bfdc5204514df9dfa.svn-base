using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class pedidonc
    {
        public static List<pedidos> getpedidos(string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            return obj.getpedidos();
        }

        public static List<pedidos> getpedidosbyparams(string folio, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            return obj.getpedidosbyparams(folio);
        }

        public static pedidos getpedido(int id, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            return obj.getpedido(id);
        }

        public static void save(pedidos entidad, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            obj.save(entidad);
        }

        public static void update(pedidos entidad, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            obj.clear();
        }

        public static void delete(pedidos entidad, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            obj.delete(entidad);
        }

        public static int getpedidosgenerados(int iddocumentodigital, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            return obj.getpedidosgenerados(iddocumentodigital);
        }

        public static pedidos getpedidogenerado(int iddocumentodigital, string cnn)
        {
            pedidodalc obj = new pedidodalc(cnn);
            return obj.getpedidogenerado(iddocumentodigital);
        }

    }
}
