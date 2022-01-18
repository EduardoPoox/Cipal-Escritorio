using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class seriefoliacionnc
    {
        public static List<seriesfoliacion> getseriesfoliacion(string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            return obj.getseriesfoliacion();
        }

        public static List<seriesfoliacion> getseriesfoliacionvigentes(string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            return obj.getseriesfoliacionvigentes();
        }

        public static seriesfoliacion getseriefoliacionvigentebytiposerie(string tiposerie,string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            return obj.getseriefoliacionvigentebytiposerie(tiposerie);
        }

        public static seriesfoliacion getseriefoliacion(int id, string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            return obj.getseriefoliacion(id);
        }

        public static void save(seriesfoliacion entidad, string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            obj.save(entidad);
        }

        public static void update(seriesfoliacion entidad, string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            obj.clear();
        }

        public static void delete(seriesfoliacion entidad, string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            obj.delete(entidad);
        }


        //NC - Consulta las series de foliación de un tipo en específico
        public static List<seriesfoliacion> getseriesfoliacionbytiposerie(string tiposerie,string cnn)
        {
            seriefoliaciondalc obj = new seriefoliaciondalc(cnn);
            return obj.getseriesfoliacionbytiposerie(tiposerie);
        }


    }
}
