using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class formatonc
    {
        public static List<formatos> getformatos(string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getformatos();
        }

        public static List<formatos> getformatosvigentes(string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getformatosvigentes();
        }

        public static List<formatos> getformatosvigentesbygrupoformatos(string grupoformato,string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getformatosvigentesbygrupoformatos(grupoformato);
        }
        public static formatos getformato(int id, string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getformato(id);
        }

        public static formatos getformatosvigentesbygrupoformatoandtipo(string grupoformato, string tipo, string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getformatosvigentesbygrupoformatoandtipo(grupoformato, tipo);
        }

        public static void save(formatos entidad, string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            obj.save(entidad);
        }

        public static void update(formatos entidad, string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            obj.clear();
        }

        public static void delete(formatos entidad, string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            obj.delete(entidad);
        }


        public static List<formatos> getformatosbygrupogeneral(string grupogeneral, string cnn)
        {
            formatodalc obj = new formatodalc(cnn);
            return obj.getformatosbygrupogeneral(grupogeneral);
        }

    }
}
