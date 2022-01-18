using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
using Ionic.Zip;
using System.Security.Cryptography;


namespace cipal.licenciaparams
{
    public static class utGeneral
    {
        #region UTILITIES
        public static Boolean IsNullValue(Object Value)
        {
            try
            {
                if (Value == null || Value == DBNull.Value || String.IsNullOrEmpty(Value.ToString().Trim()))
                    return true;
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static Boolean IsNullOrZeroValue(Object Value)
        {
            try
            {
                if (Value != null && Value != DBNull.Value && !String.IsNullOrEmpty(Value.ToString()) && Convert.ToDecimal(Value) != 0)
                    return false;
                else
                    return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static String IsNullValueString(Object Value)
        {
            try
            {
                if (Value == null || Value == DBNull.Value || String.IsNullOrEmpty(Value.ToString().Trim()))
                    return String.Empty;
                else
                    return Value.ToString();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public static String Compress(String fileName, String NewFileName)
        {
            try
            {
                String outPath = String.Empty;
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(fileName, "");
                    zip.Save(NewFileName);
                }
                return outPath;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void Decompress(String fileCompressed, String NewFileName)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(fileCompressed))
                {
                    // Loop through the archive's files.
                    foreach (ZipEntry zip_entry in zip)
                    {
                        zip_entry.Extract(NewFileName);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static void CopyDir(string sourceFolder, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                // Get Files & Copy
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);

                    // ADD Unique File Name Check to Below!!!!
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest,true);
                }

                // Get dirs recursively and copy files
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyDir(folder, dest);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static String GetApplicationPath()
        {
            try
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public static String FormatDateForFileNames(DateTime oFecha)
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
        public static String GetMachineName()
        {
            try
            {
                return System.Environment.MachineName.ToString().ToUpper();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static String Decrypt(string value)
        {
            byte[] data = Convert.FromBase64String(value);
            string decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
        }
        #endregion
    }
}
