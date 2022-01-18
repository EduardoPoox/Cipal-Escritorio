using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class detsolicitudnc
    {
        public static List<detsolicitudes> getdetsolicitudes(string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            return obj.getdetsolicitudes();
        }

        public static detsolicitudes getdetsolicitud(int id, string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            return obj.getdetsolicitud(id);
        }

        public static void save(detsolicitudes entidad, string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            obj.save(entidad);
        }

        public static void update(detsolicitudes entidad, string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            obj.clear();
        }

        public static void delete(detsolicitudes entidad, string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            obj.delete(entidad);
        }

        public static List<detsolicitudes> getdetsolicitudesporid(int id, string cnn)
        {
            detsolicituddalc obj = new detsolicituddalc(cnn);
            return obj.getdetsolicitudesporid(id);
        }
    }
}
