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

namespace cipal.licenciaparams
{
    public static class CheckVersion
    {
        public static string VERSION_DIR = @"\publicACT\";
       
        private static string[] VerificarLicenciaDescarga()
        {
            string[] consulta = new string[6];
            consulta[0] = "-1"; //SIN CONEXION
            consulta[1] = "El sistema no cuenta con una licencia vigente";
            try
            {
                string sistema = LICManager.GetSetting(LICManager.eSettings.CV1.ToString()).Replace("-","");
                string cliente = LICManager.GetSetting(LICManager.eSettings.CV2.ToString()).Replace("-", "");
                string macaddress = LICManager.GetSetting(LICManager.eSettings.CV3.ToString()).Replace("-", "");
                string nombreequipo = LICManager.GetSetting(LICManager.eSettings.CV4.ToString()).Replace("-", "");
                string version = LICManager.GetSetting(LICManager.eSettings.Version.ToString(), false).Replace("-", "");
                string revision = LICManager.GetSetting(LICManager.eSettings.Revision.ToString(), false).Replace("-", "");
                string urlservices = LICManager.GetSetting(LICManager.eSettings.UrlServices.ToString(), false).Replace("-", "");

                if (!string.IsNullOrEmpty(sistema) && !string.IsNullOrEmpty(cliente) && !string.IsNullOrEmpty(macaddress))
                {
                    
                    ListaParametros listaParametros = new ListaParametros();
                    listaParametros.AddToParamList("sistema", SqlDbType.VarChar, sistema);
                    listaParametros.AddToParamList("cliente", SqlDbType.VarChar, cliente);
                    listaParametros.AddToParamList("macadress", SqlDbType.VarChar, macaddress);
                    listaParametros.AddToParamList("nombreequipo", SqlDbType.VarChar, nombreequipo);
                    listaParametros.AddToParamList("version", SqlDbType.VarChar, version);
                    listaParametros.AddToParamList("revision", SqlDbType.VarChar, revision);

                    String str = "checkversion=" + GetJsonParams(listaParametros.GetListaParametros());
                    var data = Encoding.ASCII.GetBytes(str);

                    string urlphp = urlservices;
                    urlphp += "/chekv.php";
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(urlphp);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.ContentLength = data.Length;
                    
                    using (var stream = httpWebRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    WebResponse response = httpWebRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string text = streamReader.ReadToEnd();
                    streamReader.Close();
                    response.Close();

                    if (string.IsNullOrEmpty(text))
                        throw new System.Exception(text);

                    JObject obj = JObject.Parse(text);
                    string licencia = obj["licencia"].ToString();
                    string zipfile = obj["zipfile"].ToString();
                    string act = obj["act"].ToString();
                    string message = obj["message"].ToString();
                    string nuevaversion = obj["nuevaversion"].ToString();
                    string nuevarevision = obj["nuevarevision"].ToString();

                    consulta[0] = licencia; //-1 SIN CONEXION 0 SIN LICENCIA 1 LICENCIA VALIDA
                    consulta[1] = message;
                    consulta[2] = act; // 1 APLICA ACTUALIZACION 0 SIN ACTUALIZACION
                    consulta[3] = zipfile; //MENSAJE DE ERROR
                    consulta[4] = nuevaversion;
                    consulta[5] = nuevarevision;

                }
                return consulta;
             
            }
            catch (System.Exception ex)
            {
                consulta[1] = ex.Message;
                return consulta;
            }
        }

        public static string VerificaryActualizar()
        {
            string mensaje = "";
            try
            {
                //DEVOLVERA STRING COMO MENSAJE SI HUBO ALGUN ERROR O SUCESO QUE NO VAYA A BLOQUEAR LA APERTURA DEL SISTEMA
                //DE LO CONTRARIO HARA TRHOW

                string[] arr = VerificarLicenciaDescarga();
                if (arr[0] == "-1")
                {
                    mensaje = arr[1]; //si no tiene conexion o marco errpr
                }
                else if (arr[0] == "0") // si no tiene licencia
                {
                    throw new System.Exception(arr[1]);
                }
                else if (arr[0] == "1") //si todo ok
                {
                    if (arr[2] == "1")//si hay actualizacion intenta descargarla
                    {
                        string newZip = getFileName();
                        mensaje = downloadfile(arr[3],newZip);
                        if (string.IsNullOrEmpty(mensaje))
                            mensaje = actualizar(newZip);

                        LICManager.WriteSetting(LICManager.eSettings.Version.ToString(), arr[4],false);
                        LICManager.WriteSetting(LICManager.eSettings.Revision.ToString(), arr[5],false);
                    }
                }
                return mensaje;
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
            
        }

        public static string Verificar()
        {
            string mensaje = "";
            try
            {
                //DEVOLVERA STRING COMO MENSAJE SI HUBO ALGUN ERROR O SUCESO QUE NO VAYA A BLOQUEAR LA APERTURA DEL SISTEMA
                //DE LO CONTRARIO HARA TRHOW

                string[] arr = VerificarLicenciaDescarga();
                if (arr[0] == "-1")
                {
                    mensaje = arr[1]; //si no tiene conexion o marco errpr
                }
                else if (arr[0] == "0") // si no tiene licencia
                {
                    throw new System.Exception(arr[1]);
                }
                else if (arr[0] == "1") //si todo ok
                {
                   
                }
                return mensaje;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private static string actualizar(string fileZip)
        {
            try
            {
                string filesFilder = fileZip.ToLower().Replace(".zip","");
                utGeneral.Decompress(fileZip, filesFilder);
                utGeneral.CopyDir(filesFilder, utGeneral.GetApplicationPath());
                return string.Empty;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        private static string downloadfile(string file, string newfile)
        {
            try
            {
                //REFENCIA DE SEGURIDAD PARA EL NETFRAMEWORK 4.0
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    webClient.DownloadFile(file, newfile);
                }

                return string.Empty;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        private static string getFileName()
        {
            string dir = utGeneral.GetApplicationPath() + @"\" + VERSION_DIR;
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            return dir + utGeneral.FormatDateForFileNames(DateTime.Now) + ".zip";
        }

        #region JSON
        public static string GetJsonParams(List<Parametro> oParamList)
        {
            ListaParametros oListaParam = new ListaParametros();
            JObject oJson = new JObject();
            JProperty val = null;
            List<JObject> tmp = new List<JObject>();
            foreach (Parametro oParam in oParamList)
            {
                if (oParam.Value is List<List<Parametro>>)
                {
                    foreach (List<Parametro> oSubList in (List<List<Parametro>>)oParam.Value)
                    {
                        tmp.Add(GetJsonParamsObject(oSubList));
                    }
                    val = new JProperty(oParam.ParamName, tmp);
                }
                else if (oParam.Value is Byte[])
                {
                    val = new JProperty(oParam.ParamName, "\"" + Convert.ToBase64String((Byte[])oParam.Value) + "\"");
                }
                else if (oParam.Value is decimal || oParam.Value is int)
                {
                    val = new JProperty(oParam.ParamName, oParam.Value);
                }
                else
                {
                    //val = new JProperty(oParam.ParamName, "\"" + (oParam.Value != null ? ReplaceSpecialChars(oParam.Value.ToString()) : String.Empty) + "\"");
                    val = new JProperty(oParam.ParamName, oParam.Value);
                }

                oJson.Add(val);
            }



            /*var sr = new StringWriter();
            var jsonWriter = new JsonTextWriter(sr)
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            };
            new JsonSerializer().Serialize(jsonWriter, oJson);*/

            string json = oJson.ToString();
            return json;
        }

        public static JObject GetJsonParamsObject(List<Parametro> oParamList)
        {
            ListaParametros oListaParam = new ListaParametros();

            JObject oJson = new JObject();
            JProperty val = null;
            List<JObject> tmp = new List<JObject>();
            foreach (Parametro oParam in oParamList)
            {
                if (oParam.Value is List<List<Parametro>>)
                {
                    foreach (List<Parametro> oSubList in (List<List<Parametro>>)oParam.Value)
                    {
                        tmp.Add(GetJsonParamsObject(oSubList));
                    }
                    val = new JProperty(oParam.ParamName, tmp);
                }
                else if (oParam.Value is Byte[])
                {
                    val = new JProperty(oParam.ParamName, "\"" + Convert.ToBase64String((Byte[])oParam.Value) + "\"");
                }
                else if (oParam.Value is decimal || oParam.Value is int)
                {
                    val = new JProperty(oParam.ParamName, oParam.Value);
                }
                else
                    val = new JProperty(oParam.ParamName, "\"" + (oParam.Value != null ? ReplaceSpecialChars(oParam.Value.ToString()) : String.Empty) + "\"");
                oJson.Add(val);
            }
            return oJson;
        }

        public static string ReplaceSpecialChars(string Query)
        {
            Query = Query.Replace("%", "%25");
            Query = Query.Replace("'", "%27");
            Query = Query.Replace("\\", "\\\\");
            Query = Query.Replace("+", "%2B");
            //Query = System.Uri.EscapeDataString(Query);
            return Query;
        }

        #endregion


        
    }
}
