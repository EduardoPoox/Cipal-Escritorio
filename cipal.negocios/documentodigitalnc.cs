using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class documentodigitalnc
    {
        public static List<documentosdigitalesconceptos> odocumentosdigitalesconceptos = new List<documentosdigitalesconceptos>();
        public static List<documentosdigitalesimpuestos> odocumentosdigitalesimpuestos = new List<documentosdigitalesimpuestos>();
        public static List<documentosdigitales> getdocumentosdigitales(string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            return obj.getdocumentodigital();
        }

        public static documentosdigitales getgetdocumentodigital(int id, string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            return obj.getdocumentodigital(id);
        }

        public static void save(documentosdigitales entidad, string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            obj.save(entidad);
        }

        public static void update(documentosdigitales entidad, string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            obj.clear();
        }

        public static void delete(documentosdigitales entidad, string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            obj.delete(entidad);
        }

        public static bool existeuuid(string uuid,string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            return obj.existeuuid(uuid);
        }

        public static List<documentosdigitales> getdocumentosdigitalesbyparams(string tiposolicitud,string tipoxml, DateTime fi, DateTime ff, string rfc, string nombre,string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            return obj.getdocumentodigitalbyparams(tiposolicitud,tipoxml,fi,ff,rfc,nombre);
        }

        public static string savetransaction(documentosdigitales entidad, string cnn)
        {
            documentodigitaldalc obj = new documentodigitaldalc(cnn);
            return obj.savetransaction(entidad, odocumentosdigitalesconceptos, odocumentosdigitalesimpuestos);
        }
    }
}
