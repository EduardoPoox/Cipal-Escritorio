using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cipal.entidades;
using cipal.datos;

namespace cipal.negocios
{
    public class vconfdapempleadonc
    {
        public static List<vconfdapempleados> getconfdapempleados(string cnn)
        {
            vconfdapempleadodalc obj = new vconfdapempleadodalc(cnn);
            return obj.getconfdaempleados();
        }

        public static List<vconfdapempleados> getconfdaempleadosbyparams(int iddepartamento, int idpuesto, string cnn)
        {
            vconfdapempleadodalc obj = new vconfdapempleadodalc(cnn);

            if (iddepartamento!=0 && idpuesto != 0)
            {
                return obj.getconfdaempleadosbyparams(iddepartamento, idpuesto);
            }
            else
            {
                if (iddepartamento == 0)
                {
                    if (idpuesto == 0)
                    {
                        return obj.getconfdaempleados();
                    }
                    else
                    {
                        return obj.getconfdaempleadosbyidpuesto(idpuesto);
                    }
                }
                else
                {
                    if (idpuesto == 0)
                    {
                        return obj.getconfdaempleadosbyiddepartamento(iddepartamento);
                    }
                    else
                    {
                        return obj.getconfdaempleadosbyparams(iddepartamento, idpuesto);
                    }
                }
            }
        }

        public static vconfdapempleados getconfdaempleado(int id, string cnn)
        {
            vconfdapempleadodalc obj = new vconfdapempleadodalc(cnn);
            return obj.getconfdaempleado(id);
        }
    }
}
