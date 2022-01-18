using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Diagnostics;
using System.Net.NetworkInformation;
namespace cipal.licenciaparams
{
    public static class LICManager
    {
        private static string filePath;
         
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
        string key,
        string val,
        string filePath);
 
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName,
        byte[] lpszReturnBuffer, 
        int nSize, 
        string lpFileName);


        public enum Sections
        {
            Settings,
        };

        public enum eSettings
        {
            CV1,
            CV2,
            CV3,
            CV4,
            Version,
            Revision,
            UrlServices
        };

      
        public static string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public static void VerifyINIPath()
        {
            filePath = utGeneral.GetApplicationPath() + "\\Licencia.ini";
            if (!System.IO.File.Exists(filePath))
            {
                WriteSetting(eSettings.CV1.ToString(), "-");
                WriteSetting(eSettings.CV2.ToString(), "-");
                WriteSetting(eSettings.CV3.ToString(),GetMacAddress());
                WriteSetting(eSettings.CV4.ToString(), utGeneral.GetMachineName());
                WriteSetting(eSettings.Version.ToString(), "-",false);
                WriteSetting(eSettings.Revision.ToString(), "-", false);
                WriteSetting(eSettings.UrlServices.ToString(), "https://licencias.cipal.com.mx", false);
            }
            else
            {
                if (utGeneral.IsNullValue(GetSetting(eSettings.UrlServices.ToString(),false)))
                {
                    WriteSetting(eSettings.UrlServices.ToString(), "https://licencias.cipal.com.mx", false);
                }
            }
        }


        public static void WriteSetting(String oKey, string value, bool Encrypt = true)
        {
            if (Encrypt)
                WritePrivateProfileString(Sections.Settings.ToString(), oKey.ToString(),AurMax.Security.Encryption.EncryptionDecryption.EncriptarSHA1(value), filePath);
            else
                WritePrivateProfileString(Sections.Settings.ToString(), oKey.ToString(), value, filePath);
        }
        public static string GetSetting(String oKey, bool Decrypt=true)
        {
            if (Decrypt)
            {
                if (!String.IsNullOrEmpty(Read(Sections.Settings.ToString(), oKey.ToString())))
                    return AurMax.Security.Encryption.EncryptionDecryption.DesencriptarSHA1(Read(Sections.Settings.ToString(), oKey.ToString()));
                else
                    return string.Empty;
            }
            else
                return Read(Sections.Settings.ToString(), oKey.ToString());
        }
        private static string Read(string section, string key)
        {
            StringBuilder SB = new StringBuilder(1500);
            int i = GetPrivateProfileString(section, key, "", SB, 32768, filePath);
            return SB.ToString();
        }
        public static void DeleteSetting(Sections eSecction, String oKey)
        {
            WritePrivateProfileString(eSecction.ToString(), oKey.ToString(),null, filePath);
        }

        private static string GetMacAddress()
        {
            string addr = "";
            foreach (NetworkInterface n in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (n.OperationalStatus == OperationalStatus.Up)
                {
                    addr += n.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return addr;
        }

    }
}
