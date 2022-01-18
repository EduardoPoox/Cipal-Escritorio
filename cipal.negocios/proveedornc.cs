using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class proveedornc
    {
        public static List<proveedores> getproveedores(string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            return obj.getproveedores();
        }

        public static List<proveedores> getproveedoresbyparams(string rfc, string nombre, string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            return obj.getproveedoresbyparams(rfc, nombre);
        }

        public static proveedores getproveedor(int id, string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            return obj.getproveedor(id);
        }

        public static void save(proveedores entidad, string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            obj.save(entidad);
        }

        public static void update(proveedores entidad, string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            obj.clear();
        }

        public static void delete(proveedores entidad, string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            obj.delete(entidad);
        }


        public static bool existeproveedor(string rfc,string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            return obj.existeproveedor(rfc);
        }

        public static proveedores getproveedorbyrfc(string rfc, string cnn)
        {
            proveedordalc obj = new proveedordalc(cnn);
            return obj.getproveedorbyrfc(rfc);
        }

    }
}
