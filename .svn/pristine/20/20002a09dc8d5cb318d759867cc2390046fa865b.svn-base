using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace cipal.genericas
{
    public static class helpers
    {
        #region ESPECIALES DE GRID DE INFRAGISTICS
        public static void FormatGridColumnCurrency(Infragistics.Win.UltraWinGrid.UltraGridColumn gridColumn)
        {
            try
            {
                gridColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
                gridColumn.Format = "$###,###,###,###,##0.00";
                gridColumn.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void FormatGridColumnCurrency_4Des(Infragistics.Win.UltraWinGrid.UltraGridColumn gridColumn)
        {
            try
            {
                gridColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency;
                gridColumn.Format = "$###,###,###,###,##0.0000";
                gridColumn.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void FormatGridColumnDecimal(Infragistics.Win.UltraWinGrid.UltraGridColumn gridColumn)
        {
            try
            {
                gridColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                gridColumn.Format = "###,###,###,###,##0.00";
                gridColumn.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void FormatGridColumnDecimal_4Des(Infragistics.Win.UltraWinGrid.UltraGridColumn gridColumn)
        {
            try
            {
                gridColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
                gridColumn.Format = "###,###,###,###,##0.0000";
                gridColumn.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void FormatGridColumnNumber_NonDecimal(Infragistics.Win.UltraWinGrid.UltraGridColumn gridColumn)
        {
            try
            {
                gridColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer;
                gridColumn.Format = "###,###,###,###,##0";
                gridColumn.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void convertirAMayuscula(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
            }
        }
        public static void NoAceptarNum(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static void NoAceptaLetra(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            {
                e.Handled = true;
            }
        }
        public static void CargaCombo(Infragistics.Win.UltraWinGrid.UltraCombo combo, DataSet data, string valueMember, string dataMember, string KeycolumnDisplay, string columndisplay)
        {
            combo.SetDataBinding(data, null);
            combo.DisplayMember = dataMember;
            combo.ValueMember = valueMember;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn vColumn in combo.Rows.Band.Columns)
            {
                if (vColumn.Key == KeycolumnDisplay)
                {
                    vColumn.Header.Caption = columndisplay;
                    vColumn.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                else
                {
                    vColumn.Hidden = true;
                }
            }
            combo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            combo.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            combo.Value = -1;
        }
        #endregion


        #region DATATABLES

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name != "foto")
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                    }

                }
            }
            return obj;
        }



        #endregion



        //EXCEL
        // VARIABLE TIPO PUBLICA 
        public static OleDbConnection Connection { get; private set; }


        //METODO QUE GENERA LAS POSIBLES CADENAS DE CONEXION 
        private static String GenerateConnectionString(String RutaAcceso)
        {
            var Result = String.Empty;
            if (File.Exists(RutaAcceso))
            {
                Result = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", RutaAcceso);

            }
            return Result;
        }


        //metodo que nos realiza la conexion 
        private static OleDbConnection GetConnection(String RutaAcceso)
        {
            var ConnString = GenerateConnectionString(RutaAcceso);
            if (ConnString == null)
                return null;
            var Result = new OleDbConnection(ConnString);
            Result.Open();
            return Result;
        }


        public static string[] WorkSheetNames(string excelFilePath)
        {
            string[] workSheetNames;
            Connection = GetConnection(excelFilePath);
            //using (OleDbConnection oledbConnection = new OleDbConnection(string.Format(oledbProviderString, excelFilePath)))
            //{                
            //oledbConnection.Open();                                
            //DataTable dataTable = oledbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            DataTable dataTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            workSheetNames = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                workSheetNames[i] = (string)dataTable.Rows[i]["TABLE_NAME"];
            }
            //oledbConnection.Close();
            Connection.Close();
            //}
            return workSheetNames;
        }
        public static DataColumnCollection ColumnNamesCollection(string excelFilePath)
        {
            return ColumnNamesCollection(excelFilePath, "Sheet1$");
        }
        public static DataColumnCollection ColumnNamesCollection(string excelFilePath, string sheetName)
        {
            DataColumnCollection columNames;
            Connection = GetConnection(excelFilePath);
            //using (OleDbConnection oledbConnection = new OleDbConnection(string.Format(oledbProviderString, excelFilePath)))
            //{
            string sqlStatement = "Select top 1 * from [" + sheetName + "]";
            // oledbConnection.Open();
            //OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStatement, oledbConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStatement, Connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            columNames = table.Columns;
            //oledbConnection.Close();
            Connection.Close();
            //}
            return columNames;
        }
        public static DataSet ExcelToDataSet(string excelFilePath)
        {
            string[] workSheets = WorkSheetNames(excelFilePath);
            DataSet dataSet = new DataSet();
            foreach (string workSheet in workSheets)
            {
                DataTable dataTable = new DataTable(workSheet);
                dataTable = ExcelToDataTable(excelFilePath, workSheet);
                dataSet.Tables.Add(dataTable);
            }
            return dataSet;
        }
        public static DataTable ExcelToDataTable(string filePath, string workSheet)
        {
            DataTable dataTable = new DataTable(workSheet);
            //using (OleDbConnection oledbConnection = new OleDbConnection(string.Format(oledbProviderString, filePath)))
            //{
            Connection = GetConnection(filePath);
            string sqlStatement = @"SELECT * FROM [" + workSheet + "]";
            //oledbConnection.Open();
            try
            {
                //OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStatement, oledbConnection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStatement, Connection);
                adapter.Fill(dataTable);
            }
            catch { }
            //oledbConnection.Close();
            Connection.Close();
            //}
            return dataTable;
        }
        public static DataTable ExcelToDataTable(string filePath)
        {
            return ExcelToDataTable(filePath, 0);
        }
        public static DataTable ExcelToDataTable(string filePath, int index)
        {
            return ExcelToDataSet(filePath).Tables[index];
        }
        public static string[] ColumnNamesArray(string excelFilePath)
        {
            DataColumnCollection columCollection = ColumnNamesCollection(excelFilePath);
            string[] columNames = new string[columCollection.Count];
            foreach (DataColumn column in columCollection)
            {
                columNames[column.Ordinal] = column.ColumnName;
            }
            return columNames;
        }

        public static String[] GetSheetsNames(String FilePath)
        {
            String[] emptyArray = null;
            try
            {
                Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook theWorkbook = null;
                string strPath = FilePath;//"MENTION PATH OF EXCEL FILE HERE";
                theWorkbook = ExcelObj.Workbooks.Open(strPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Microsoft.Office.Interop.Excel.Sheets sheets = theWorkbook.Worksheets;
                String[] NombresHojas = new String[theWorkbook.Sheets.Count];
                for (int ind = 1; ind <= theWorkbook.Sheets.Count; ind++)
                {
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(ind);
                    NombresHojas[ind - 1] = worksheet.Name;//Get the name of worksheet.
                }
                theWorkbook.Close(false, Type.Missing, Type.Missing);
                ExcelObj.Quit();
                return NombresHojas;
            }
            catch (System.Exception ex)
            {
                return emptyArray;
                throw ex;
            }
        }


        public static string GetXMLAttributeValue(XmlNodeList listXML, String Attribute)
        {
            try
            {
                string Value = String.Empty;
                foreach (XmlNode node in listXML)
                {
                    if (node.Attributes[Attribute] != null)
                        Value = node.Attributes[Attribute].Value;
                }
                return Value;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static object GetAttributeValue(XmlNode oNode, String Attribute)
        {
            try
            {
                object Value = DBNull.Value;
                if (oNode.Attributes[Attribute] != null)
                    Value = oNode.Attributes[Attribute].Value;
                return Value;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
