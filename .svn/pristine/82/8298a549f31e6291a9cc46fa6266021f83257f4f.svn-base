using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class departamentonc
    {
        public static List<departamentos> getdepartamentos(string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            return obj.getdepartamentos();
        }

        public static departamentos getdepartamento(int id, string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            return obj.getdepartamento(id);
        }

        public static void save(departamentos entidad, string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            obj.save(entidad);
        }

        public static void update(departamentos entidad, string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            obj.clear();
        }

        public static void delete(departamentos entidad, string cnn)
        {
            departamentodalc obj = new departamentodalc(cnn);
            obj.delete(entidad);
        }
    }
}
