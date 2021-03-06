using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class documentodigitalimpuestonc
    {
        public static List<documentosdigitalesimpuestos> getdocumentosdigitalesimpuestos(string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            return obj.getdocumentosdigitalesimpuestos();
        }
        public static List<documentosdigitalesimpuestos> getdocumentosdigitalesimpuestosbyiddocumentodigital(int iddocumentodigital,string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            return obj.getdocumentosdigitalesimpuestosbyiddocumentodigital(iddocumentodigital);
        }

        public static documentosdigitalesimpuestos getdocumentodigitalimpuestobyiddocumentodigitalconcepto(int iddocumentodigital, int iddocumentodigitalconcepto, string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            return obj.getdocumentodigitalimpuestobyiddocumentodigitalconcepto(iddocumentodigital, iddocumentodigitalconcepto);
        }

        public static documentosdigitalesimpuestos getdocumentodigitalimpuesto(int id, string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            return obj.getdocumentodigitalimpuesto(id);
        }

        public static void save(documentosdigitalesimpuestos entidad, string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            obj.save(entidad);
        }

        public static void update(documentosdigitalesimpuestos entidad, string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            obj.update(entidad);
        }


        public static int getid(string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            return obj.getid();
        }

        public static void clear(string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            obj.clear();
        }

        public static void delete(documentosdigitalesimpuestos entidad, string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            obj.delete(entidad);
        }


        public static List<documentosdigitalesimpuestos> getdocumentodigitalimpuestosbyiddocumentodigitalconcepto(int iddocumentodigital, int iddocumentodigitalconcepto, string cnn)
        {
            documentodigitalimpuestodalc obj = new documentodigitalimpuestodalc(cnn);
            return obj.getdocumentodigitalimpuestosbyiddocumentodigitalconcepto(iddocumentodigital, iddocumentodigitalconcepto);
        }
    }
}
