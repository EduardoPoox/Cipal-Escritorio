using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class confdapempleadonc
    {
        public static List<confdapempleados> getconfdapempleados(string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            return obj.getconfdaempleados();
        }

        public static List<confdapempleados> getconfdaempleadosbyparams(string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            return obj.getconfdaempleadosbyparams();
        }
        
        public static confdapempleados getconfdaempleado(int id, string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            return obj.getconfdaempleado(id);
        }

        public static void save(confdapempleados entidad, string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            obj.save(entidad);
        }

        public static void update(confdapempleados entidad, string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            obj.clear();
        }

        public static void delete(confdapempleados entidad, string cnn)
        {
            confdapempleadodalc obj = new confdapempleadodalc(cnn);
            obj.delete(entidad);
        }
    }
}
