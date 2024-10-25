using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using FirmaRemotaManager;
using System.IO;

namespace web.CONTROLS
{
    public partial class SignLogger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonResponse = "{\"esito\":\"OK\"}";
            try
            {
                ProcessRequest();
            }
            catch (Exception ex)
            {

                jsonResponse = "{\"esito\":\"KO\"}";
            }
            finally
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.Write(jsonResponse);
                Response.End();
            }        
            
        }

        protected void ProcessRequest()
        {

            var json = String.Empty;

           Request.InputStream.Position = 0;
            using (var inputStream = new StreamReader(Request.InputStream))
            {
                json = inputStream.ReadToEnd();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var logger = new Logger();
            LogInfo logInfo = (LogInfo)serializer.Deserialize(json, typeof(LogInfo));
            logInfo.DataFirma = System.DateTime.Now;

            logger.SaveLogFirma(logInfo);

        }

    }

    
}