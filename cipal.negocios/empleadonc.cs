using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class empleadonc
    {
        public static List<empleados> getempleados(string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            return obj.getempleados();
        }

        public static List<empleados> getempleadosbyparams(string rfc, string nombre, string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            return obj.getempleadosbyparams(rfc, nombre);
        }

        public static empleados getempleado(int id, string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            return obj.getempleado(id);
        }

        public static void save(empleados entidad, string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            obj.save(entidad);
        }

        public static void update(empleados entidad, string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            obj.clear();
        }

        public static void delete(empleados entidad, string cnn)
        {
            empleadodalc obj = new empleadodalc(cnn);
            obj.delete(entidad);
        }
    }
}
