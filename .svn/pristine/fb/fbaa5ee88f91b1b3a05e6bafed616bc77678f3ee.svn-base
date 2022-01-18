using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Text;

namespace cipal.licenciaparams
{
    public class ListaParametros
    {
        List<Parametro> oParametros = new List<Parametro>();
        public ListaParametros()
        {

        }
        public ListaParametros(String ParamName, SqlDbType dbType, Object Value)
        {
            try
            {
                AddToParamList(ParamName.ToLower(), dbType, Value);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void AddToParamList(String ParamName, SqlDbType dbType, Object Value)
        {
            try
            {
                //if (dbType == SqlDbType.VarChar)
                //{
                //    if (Utilities.utGeneral.IsNullValue(Value))
                //        Value = DBNull.Value;
                //}

                Parametro oParam = new Parametro();
                oParam.ParamName = ParamName.ToLower();
                oParam.DbType = dbType;
                oParam.Value = Value;
                oParametros.Add(oParam);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public void AddToParamList(String ParamName, SqlDbType dbType, Object Value, String Operador, String Concatenador)
        {
            try
            {
                Parametro oParam = new Parametro();
                oParam.ParamName = ParamName.ToLower();
                oParam.DbType = dbType;
                oParam.Value = Value;
                oParam.Operador = Operador;
                oParam.Concatenador = Concatenador;
                oParametros.Add(oParam);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public void AddToParamList(Parametro oParam)
        {
            try
            {
                oParametros.Add(oParam);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

      

        public List<Parametro> GetListaParametros()
        {
            try
            {
                return oParametros;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Parametro GetPropertyParam(object oObjeto, String Operador="")
        {
            try
            {
                Parametro oParam = new Parametro();
                oParam.ParamName = oObjeto.GetType().Name;
                oParam.Value = oObjeto;
                oParam.Operador = Operador;
                oParam.DbType = GetPropertyDbType(oObjeto.GetType());
                return oParam;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public SqlDbType GetPropertyDbType(Type oObjeto)
        {
            try
            {
                SqlDbType oDbType;
                if (oObjeto == typeof(int))
                    oDbType = SqlDbType.Int;
                else if (oObjeto== typeof(decimal))
                    oDbType = SqlDbType.Decimal;
                else if (oObjeto== typeof(double))
                    oDbType = SqlDbType.Decimal;
                else if (oObjeto== typeof(string))
                    oDbType = SqlDbType.VarChar;
                else if (oObjeto== typeof(char))
                    oDbType = SqlDbType.VarChar;
                else if (oObjeto== typeof(DateTime))
                    oDbType = SqlDbType.Timestamp;
                else if (oObjeto== typeof(Boolean))
                    oDbType = SqlDbType.Bit;
                else
                    oDbType = SqlDbType.VarChar;
                return oDbType;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public  String GetOperadorFromParamType(SqlDbType oParamType)
        {
            try
            {
                String OperadorValue = Operador.Igual;
                if (oParamType == SqlDbType.VarChar
                    || oParamType == SqlDbType.VarChar)
                {
                    OperadorValue = Operador.Like;
                }

                return OperadorValue;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public String GetWhereParamString(Parametro oParam)
        {
            try
            {
                String pm = String.Empty;
                if (oParam.DbType == SqlDbType.VarChar
                    || oParam.DbType == SqlDbType.Date
                    || oParam.DbType == SqlDbType.Timestamp)
                {
                    if (oParam.Operador.ToLower() == Operador.Between)
                        pm = oParam.ParamName + " " + oParam.Operador.ToLower() + " @" + oParam.ParamName.ToString() + " and @" + oParam.ParamName2.ToString();
                    if (oParam.Operador.ToLower() == Operador.Like)
                        pm = "lower("+oParam.ParamName + ") " + oParam.Operador.ToLower() + " '%" + oParam.Value.ToString() + "%' ";
                    else
                        pm = oParam.ParamName + " " + oParam.Operador.ToLower() + "  @" + oParam.ParamName.ToString() + " ";
                }
                else
                {
                    if (oParam.Operador.ToLower() == Operador.Between)
                        pm = oParam.ParamName + " " + oParam.Operador.ToLower() + " @" + oParam.ParamName.ToString() + " and @" + oParam.ParamName2.ToString();
                    if (oParam.Operador.ToLower() == Operador.Like)
                        pm = oParam.ParamName + " " + oParam.Operador.ToLower() + " '%@" + oParam.ParamName.ToString() + "%' ";
                    else
                        pm = oParam.ParamName + " " + oParam.Operador.ToLower() + "  @" + oParam.ParamName.ToString() + " ";
                }

                return pm;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

