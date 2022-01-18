using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
namespace cipal.licenciaparams
{
    public static class Operador
    {
        #region Operadores
        static String _Igual = "=";
        public static String Igual
        {
            get { return _Igual; }
        }

        static String _Mayor = ">";
        public static String Mayor
        {
            get { return _Mayor; }
        }

        static String _Menor = "<";
        public static String Menor
        {
            get { return _Menor; }
        }

        static String _Between = "between";
        static public String Between
        {
            get { return _Between; }
        }

        static String _Like = "like";
        public static String Like
        {
            get { return _Like; }
        }


        static String _Diff = "!=";
        public static String Diff
        {
            get { return _Diff; }
        }
        #endregion

    }
}

