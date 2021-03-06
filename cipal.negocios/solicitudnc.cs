using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class solicitudnc
    {
        public static List<solicitudes> getsolicitudes(string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            return obj.getsolicitudes();
        }

        public static List<solicitudes> getsolicitudesbyparams(string empleado, string folio, string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            return obj.getsolicitudesbyparams(empleado, folio);
        }

        public static solicitudes getsolicitud(int id, string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            return obj.getsolicitud(id);
        }

        public static void save(solicitudes entidad, string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            obj.save(entidad);
        }

        public static void update(solicitudes entidad, string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            obj.clear();
        }

        public static void delete(solicitudes entidad, string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            obj.delete(entidad);
        }



        public static int getsolicitudesgenerados(int iddocumentodigital,string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            return obj.getsolicitudesgenerados(iddocumentodigital);
        }


        public static solicitudes getsolicitudgenerado(int iddocumentodigital, string cnn)
        {
            solicituddalc obj = new solicituddalc(cnn);
            return obj.getsolicitudgenerado(iddocumentodigital);
        }

    }
}
