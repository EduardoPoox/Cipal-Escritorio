using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class solicituddescarganc
    {
        public static List<solicitudesdescargas> getsolicitudesdescargas(string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            return obj.getsolicitudesdescargas();
        }

        public static List<solicitudesdescargas> getsolicitudesdescargasbyidsolicitud(string idsolicitud,string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            return obj.getsolicitudesdescargasbyidsolicitud(idsolicitud);
        }

        public static solicitudesdescargas getsolicituddescarga(int id,string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            return obj.getsolicituddescarga(id);
        }

        public static void save(solicitudesdescargas entidad,string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            obj.save(entidad);
        }

        public static void update(solicitudesdescargas entidad,string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            obj.clear();
        }

        public static void delete(solicitudesdescargas entidad,string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            obj.delete(entidad);
        }



        public static List<solicitudesdescargas> getsolicitudesdescargasportiposolicitud(string tiposolicitud,string cnn)
        {
            solicituddescargadalc obj = new solicituddescargadalc(cnn);
            return obj.getsolicitudesdescargasportiposolicitud(tiposolicitud);
        }
    }
}
