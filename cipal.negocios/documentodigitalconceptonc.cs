using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;


namespace cipal.negocios
{
    public class documentodigitalconceptonc
    {
        public static List<documentosdigitalesconceptos> getdocumentosdigitalesconceptos(string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            return obj.getdocumentosdigitalesconceptos();
        }

        public static List<documentosdigitalesconceptos> getdocumentosdigitalesconceptosbyiddocumentodigital(int iddocumentodigital,string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            return obj.getdocumentosdigitalesconceptosbyiddocumentodigital(iddocumentodigital);
        }

        public static documentosdigitalesconceptos getdocumentodigitalconcepto(int id, string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            return obj.getdocumentodigitalconcepto(id);
        }

        public static void save(documentosdigitalesconceptos entidad, string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            obj.save(entidad);
        }

        public static void update(documentosdigitalesconceptos entidad, string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            obj.clear();
        }

        public static void delete(documentosdigitalesconceptos entidad, string cnn)
        {
            documentodigitalconceptodalc obj = new documentodigitalconceptodalc(cnn);
            obj.delete(entidad);
        }
    }
}
