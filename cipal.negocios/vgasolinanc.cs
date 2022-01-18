using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vgasolinanc
    {
        public static List<vgasolinas> getgasolinas(string cnn)
        {
            vgasolinadalc obj = new vgasolinadalc(cnn);
            return obj.getgasolinas();
        }

        public static List<vgasolinas> getgasolinasbyparams(int iddepartamento, int idvehiculo,string folio, DateTime fi, DateTime ff, string cnn)
        {
            vgasolinadalc obj = new vgasolinadalc(cnn);

            if (folio != "")
            {
                return obj.getgasolinasbyfolio(folio);
            }
            else
            {
                if (iddepartamento == 0 && idvehiculo == 0)
                {
                    return obj.getgasolinasbyfechas(fi, ff);
                }
                else
                {
                    if (iddepartamento != 0 && idvehiculo != 0)
                    {
                        return obj.getgasolinasbyparams(iddepartamento, idvehiculo, fi, ff);
                    }
                    else
                    {
                        if (iddepartamento != 0)
                        {
                            return obj.getgasolinasbyiddepartamentofechas(iddepartamento, fi, ff);
                        }
                        else
                        {
                            return obj.getgasolinasbyidvehiculofechas(idvehiculo, fi, ff);
                        }
                    }
                }
            }
        }

        public static vgasolinas getgasolina(int id, string cnn)
        {
            vgasolinadalc obj = new vgasolinadalc(cnn);
            return obj.getgasolina(id);
        }


        public static List<vgasolinas> getvgasolinasbyiddocumentodigital(int iddocumentodigital, string cnn)
        {
            vgasolinadalc obj = new vgasolinadalc(cnn);
            return obj.getvgasolinasbyiddocumentodigital(iddocumentodigital);
        }
    }
}
