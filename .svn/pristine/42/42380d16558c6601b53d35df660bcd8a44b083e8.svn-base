using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vpedidonc
    {
        public static List<vpedidos> getvpedidos(string cnn)
        {
            vpedidodalc obj = new vpedidodalc(cnn);
            return obj.getvpedidos();
        }

        public static List<vpedidos> getvpedidosbyparams(string folio,int iddepartamento, int idproveedor, DateTime fi, DateTime ff, string cnn)
        {
            vpedidodalc obj = new vpedidodalc(cnn);

            if (folio != "")
            {
                return obj.getvpedidosbyfolio(folio);
            }
            else
            {
                if (iddepartamento == 0 && idproveedor == 0)
                {
                    return obj.getvpedidosbyfechas(fi, ff);
                }
                else
                {
                    if (iddepartamento != 0 && idproveedor != 0)
                    {
                        return obj.getvpedidosbyparams(iddepartamento, idproveedor, fi, ff);
                    }
                    else
                    {
                        if (iddepartamento != 0)
                        {
                            return obj.getvpedidosbyiddepartamentofechas(iddepartamento, fi, ff);
                        }
                        else
                        {
                            return obj.getvpedidosbyidproveedorfechas(idproveedor, fi, ff);
                        }
                    }
                }
            }
        }

        public static vpedidos getcompra(int id, string cnn)
        {
            vpedidodalc obj = new vpedidodalc(cnn);
            return obj.getvpedido(id);
        }
    }
}
