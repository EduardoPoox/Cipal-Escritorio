using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace cipal.licenciaparams
{
    public class Parametro
    {
        #region Variables
        String _ParamName;
        public String ParamName
        {
            get { return _ParamName; }
            set { _ParamName = value; }
        }

        String _ParamName2;
        public String ParamName2
        {
            get { return _ParamName2; }
            set { _ParamName2 = value; }
        }

        SqlDbType _dbType;
        public SqlDbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }

        Object _Value;
        public Object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        Object _Value2;
        public Object Value2
        {
            get { return _Value2; }
            set { _Value2 = value; }
        }

        String _Operador="=";
        public String Operador
        {
            get { return _Operador; }
            set { _Operador = value; }
        }

        String _Concatenador = " AND ";
        public String Concatenador
        {
            get { return _Concatenador; }
            set { _Concatenador = value; }
        }
        #endregion

    }
}

