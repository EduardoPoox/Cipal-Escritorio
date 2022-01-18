using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace cipal.genericas
{
    public static class generales
    {
        public static string getconnexionstring(string tipodeinstalacion, string servidor, string instancia, string username, string password, string basededatos)
        {
            string connexionString = string.Empty;
            string IntegratedSecurity = string.Empty;
            if (string.Equals(tipodeinstalacion, enums.etipoinstalacion.monousuario.ToString()))
                IntegratedSecurity = (true).ToString();
            else
                IntegratedSecurity = (false).ToString();
            string DataSource = (instancia != ".") ? string.Format("{0}\\{1}", servidor, instancia) : servidor;

            if (Convert.ToBoolean(IntegratedSecurity))
                connexionString = string.Format("Data Source={0};Initial Catalog=" + basededatos + ";Integrated Security=SSPI", DataSource);
            else
                connexionString = string.Format("Data Source={0};Initial Catalog=" + basededatos + ";User Id={1};Password={2}", DataSource, username, password);
            return connexionString;
        }

        public static string connexiontest(string servidor, string instancia, string username, string password, string tipodeinstalacion)
        {
            try
            {
                OleDbConnection oConn;
                String ConnString = "";
                ConnString = "Provider=SQLOLEDB;";
                if (String.Equals(tipodeinstalacion, enums.etipoinstalacion.monousuario.ToString()))
                {
                    if (instancia == ".")
                    {
                        ConnString = ConnString + "Data Source=" + servidor + ";Initial Catalog=master;Integrated Security=SSPI";
                    }
                    else
                    {
                        ConnString = ConnString + "Data Source=" + servidor + "\\" + instancia + ";Initial Catalog=master;Integrated Security=SSPI";
                    }
                    
                }
                    
                else
                {
                    if (instancia == ".")
                    {
                        ConnString = ConnString + "Data Source=" + servidor +  ";Initial Catalog=master;User ID=" + username + ";password=" + password;
                    }
                    else
                    {
                        ConnString = ConnString + "Data Source=" + servidor + "\\" + instancia + ";Initial Catalog=master;User ID=" + username + ";password=" + password;
                    }
                   
                }
                    
                oConn = new OleDbConnection(ConnString);
                oConn.Open();
                oConn.Close();
                return "";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public static string connexiontestdb(string servidor, string instancia, string username, string password, string basededatos, string tipodeinstalacion)
        {
            try
            {
                OleDbConnection oConn;
                String ConnString = "";
                ConnString = "Provider=SQLOLEDB;";
                if (String.Equals(tipodeinstalacion, enums.etipoinstalacion.monousuario.ToString()))
                    ConnString = ConnString + "Data Source=" + servidor + "\\" + instancia + ";Initial Catalog=" + basededatos + ";Integrated Security=SSPI";
                else
                    ConnString = ConnString + "Data Source=" + servidor + "\\" + instancia + ";Initial Catalog=" + basededatos + ";User ID=" + username + ";password=" + password;
                oConn = new OleDbConnection(ConnString);
                oConn.Open();
                oConn.Close();
                return "";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }


        public static DataSet executeDS(string query, string conexionString)
        {
            DataSet ds = new DataSet();
            SqlCommand Command;
            SqlDataAdapter oFbAdapter;
            using (SqlConnection oConn = new SqlConnection(conexionString))
            {
                oConn.Open();
                if (oConn.State != System.Data.ConnectionState.Open)
                    throw new Exception("No se pudo abrir la Conexión a la Base de Datos");
                try
                {
                    Command = new SqlCommand(query, oConn);
                    oFbAdapter = new SqlDataAdapter(Command);
                    oFbAdapter.Fill(ds);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oConn.Close();
                }
            }
            return ds;
        }
        public static int executeNonQuery(string query, string conexionString)
        {
            SqlCommand Command;
            using (SqlConnection oConn = new SqlConnection(conexionString))
            {
                oConn.Open();
                if (oConn.State != System.Data.ConnectionState.Open)
                    throw new Exception("No se pudo abrir la Conexión a la Base de Datos");
                try
                {
                    Command = new SqlCommand(query, oConn);
                    return Command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oConn.Close();
                }

            }
        }
        public static int executeNonQueryid(ref int id, string query, string conexionString)
        {
            SqlCommand Command;
            using (SqlConnection oConn = new SqlConnection(conexionString))
            {
                oConn.Open();
                if (oConn.State != System.Data.ConnectionState.Open)
                    throw new Exception("No se pudo abrir la Conexión a la Base de Datos");
                try
                {
                    Command = new SqlCommand(query, oConn);
                    id = Convert.ToInt32(Command.ExecuteScalar());
                    return id;
                }
                catch
                {
                    return id;
                }
                finally
                {
                    oConn.Close();
                }

            }
        }



        public static bool pingtest(string ipaddress)
        {
            Ping ping = new Ping();

            PingReply pingStatus = ping.Send(IPAddress.Parse(ipaddress));

            if (pingStatus.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getserialkey()
        {
            try
            {
                Random oRand = new Random();
                string serialkey = "";
                //1ra Secuencia
                serialkey = getformatnumber(oRand.Next(1, 99999).ToString(), 5);
                //2da Secuencia
                serialkey += "-" + getformatnumber(oRand.Next(1, 99999).ToString(), 5);
                //3ra Secuencia
                serialkey += "-" + getformatnumber(oRand.Next(1, 99999).ToString(), 5);
                //4ta Secuencia
                serialkey += "-" + getformatnumber(oRand.Next(1, 99999).ToString(), 5);
                //5ta Secuencia
                serialkey += "-" + getformatnumber(oRand.Next(1, 99999).ToString(), 5);
                return serialkey;
            }
            catch
            {
                return "";
            }
        }
        private static string getformatnumber(string folio, int longitud)
        {
            string foliocompleto = folio;
            if (folio.Length < longitud)
            {
                for (int i = 0; i < (longitud - folio.Length); i++)
                    foliocompleto = foliocompleto.Insert(0, "0");
            }
            return foliocompleto;
        }
        public static string getvolumeserialnumber()
        {
            try
            {
                string ExecutionDrive = System.Environment.GetEnvironmentVariable("windir").Substring(0, 1);
                if (ExecutionDrive == "" || ExecutionDrive == null)
                    ExecutionDrive = "C";
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + ExecutionDrive + ":\"");
                disk.Get();
                return disk["VolumeSerialNumber"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public static string getusername()
        {
            try
            {
                return System.Environment.UserName;
            }
            catch
            {
                return "";
            }
        }
        public static string getmachinename()
        {
            try
            {
                return System.Environment.MachineName;
            }
            catch
            {
                return "";
            }
        }
        public static string getdatetimeformat()
        {
            try
            {
                return DateTime.Now.ToString("s");
            }
            catch
            {
                return "";
            }
        }

        public static string encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        public static string desencriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static long DateDiff(enums.DateInterval interval, DateTime dt1, DateTime dt2)
        {
            return DateDiff(interval, dt1, dt2, System.Globalization.DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }
        private static int GetQuarter(int nMonth)
        {
            if (nMonth <= 3)
                return 1;
            if (nMonth <= 6)
                return 2;
            if (nMonth <= 9)
                return 3;
            return 4;
        }
        public static long DateDiff(enums.DateInterval interval, DateTime dt1, DateTime dt2, DayOfWeek eFirstDayOfWeek)
        {

            if (interval == enums.DateInterval.Year)
                return dt2.Year - dt1.Year;

            if (interval == enums.DateInterval.Month)
                return (dt2.Month - dt1.Month) + (12 * (dt2.Year - dt1.Year));

            TimeSpan ts = dt2 - dt1;

            if (interval == enums.DateInterval.Day || interval == enums.DateInterval.DayOfYear)
                return Round(ts.TotalDays);

            if (interval == enums.DateInterval.Hour)
                return Round(ts.TotalHours);

            if (interval == enums.DateInterval.Minute)
                return Round(ts.TotalMinutes);

            if (interval == enums.DateInterval.Second)
                return Round(ts.TotalSeconds);

            if (interval == enums.DateInterval.Weekday)
            {
                return Round(ts.TotalDays / 7.0);
            }

            if (interval == enums.DateInterval.WeekOfYear)
            {
                while (dt2.DayOfWeek != eFirstDayOfWeek)
                    dt2 = dt2.AddDays(-1);
                while (dt1.DayOfWeek != eFirstDayOfWeek)
                    dt1 = dt1.AddDays(-1);
                ts = dt2 - dt1;
                return Round(ts.TotalDays / 7.0);
            }

            if (interval == enums.DateInterval.Quarter)
            {
                double d1Quarter = GetQuarter(dt1.Month);
                double d2Quarter = GetQuarter(dt2.Month);
                double d1 = d2Quarter - d1Quarter;
                double d2 = (4 * (dt2.Year - dt1.Year));
                return Round(d1 + d2);
            }

            return 0;

        }
        private static long Round(double dVal)
        {
            if (dVal >= 0)
                return (long)Math.Floor(dVal);
            return (long)Math.Ceiling(dVal);
        }


        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public static string BytesToString(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        // FormatDate funciones Cinthia 06/06/2021
        public static DateTime FormatDateWithoutHour(DateTime oFecha)
        {
            try
            {
                return new DateTime(oFecha.Year, oFecha.Month, oFecha.Day, 0, 0, 0);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
      
        public static DateTime FormatDateAllHour(DateTime oFecha)
        {
            try
            {
                return new DateTime(oFecha.Year, oFecha.Month, oFecha.Day, 23, 59, 59);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string FormatDateForFileNames(DateTime oFecha)
        {
            try
            {
                String FormatedDate = oFecha.Day.ToString().PadLeft(2, '0') + "-" + oFecha.Month.ToString().PadLeft(2, '0') + "-" + oFecha.Year.ToString() + "_" + oFecha.Hour.ToString() + oFecha.Minute.ToString() + oFecha.Second.ToString() + oFecha.Millisecond.ToString();
                return FormatedDate;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string cleantextcharacters(string cad)
        {
            try
            {
                string result = cad;
                result = result.Replace("á", "a").Replace("Á", "A").Replace("é", "e").Replace("É", "E").Replace("í", "i").Replace("Í", "I").Replace("ó", "o").Replace("Ó", "O").Replace("ú", "u").Replace("Ú", "U");
                result = result.Replace("ñ", "n").Replace("Ñ", "N").Replace(";", "").Replace(",", "").Replace("Ü", "U").Replace("ü", "u");
                Regex.Replace(result, @"[^0-9a-zA-Z]+", "");

                return result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

    }
}
