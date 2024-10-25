using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace web.CONTROLS
{
    public partial class jsonData : System.Web.UI.Page
    {
        private string m_returnStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            ctrlRequest();
            Response.Write(m_returnStr);
            Response.End();
        }

        private void ctrlRequest()
        {
            string metodo = Request.Form["type"];
            if (string.IsNullOrEmpty(metodo)) metodo = Request.Params["type"];
            try
            {
                if (string.IsNullOrEmpty(metodo)) throw new Exception("Metodo non specificato.");
                System.Reflection.MethodInfo mi = this.GetType().GetMethod(metodo);
                mi.Invoke(this, null);
            }
            catch (Exception ex) { m_returnStr = ""; }
        }

        //private string ToJSON(object obj)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    return serializer.Serialize(obj);
        //}

        //private string ToJSON(object obj, int recursionDepth)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    serializer.RecursionLimit = recursionDepth;
        //    return serializer.Serialize(obj);
        //}

        // type = getAtecoBando
        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getATECO2007Bando()
        {
            try
            {
                string codIniziaPer = "";
                string descrContiene = "";
                string qry = "";
                SiarLibrary.Ateco2007Collection doc_ateco = new SiarLibrary.Ateco2007Collection();
                int id_bando = 0; int top = 0;
                int.TryParse(Request.Params["idb"], out id_bando);
                int.TryParse(Request.Params["top"], out top);
                if (Request.QueryString["term"] != null && Request.QueryString["term"].ToString().Length > 0 && id_bando > 0)
                {
                    qry = Request.QueryString["term"];
                    if (qry.Trim().Length > 0)
                    {
                        Regex isCodice = new Regex("^[0-9.]{1,8}$");
                        if (isCodice.IsMatch(qry)) codIniziaPer = qry;
                        else descrContiene = qry;
                        doc_ateco = new SiarBLL.Ateco2007CollectionProvider().Find((codIniziaPer != "" ? codIniziaPer : null), (descrContiene != "" ? descrContiene : null), id_bando);
                    }
                }
                //return_object.Html = ToJSON(doc_ateco);
                m_returnStr = "[";
                int ix = 0;
                for (ix = 0; ix < (top > 0 && top < doc_ateco.Count ? top : doc_ateco.Count); ix++)
                {
                    SiarLibrary.Ateco2007 af = doc_ateco[ix];
                    m_returnStr += "{\"value\":\"" + af.CodiceAteco.ToString() + " - " + af.Descrizione.ToString().Replace("\"", "\\\"") + "\",\"data\":\"" + af.IdAteco2007 + "\"},";
                }
                if (m_returnStr.EndsWith(",")) m_returnStr = m_returnStr.Substring(0, m_returnStr.Length - 1);
                m_returnStr += "]";
            }
            catch (Exception ex)
            {
                m_returnStr = "[]";
                //return_object.setException(ex); 
            }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getComuni()
        {
            try
            {
                string qry = "";
                SiarLibrary.ComuniCollection doc_comuni = new SiarLibrary.ComuniCollection();
                //int id_bando = 0; 
                int top = 0;
                //int.TryParse(Request.Params["idb"], out id_bando);
                int.TryParse(Request.Params["top"], out top);
                //  && id_bando > 0
                if (Request.QueryString["term"] != null && Request.QueryString["term"].ToString().Length > 0)
                {
                    qry = Request.QueryString["term"];
                    if (qry.Trim().Length > 0)
                    {
                        Regex isCodice = new Regex("^[0-9.]{1,8}$");
                        doc_comuni = new SiarBLL.ComuniCollectionProvider().Find(null, null, null, null, null, null, true, qry);
                    }
                }
                //return_object.Html = ToJSON(doc_ateco);
                // [{"value":"NomeComune","data":{"codice":"32","cap":"60100","prov":"AN"}}];
                m_returnStr = "[";
                int ix = 0;
                for (ix = 0; ix < (top > 0 && top < doc_comuni.Count ? top : doc_comuni.Count); ix++)
                {
                    SiarLibrary.Comuni af = doc_comuni[ix];
                    m_returnStr += "{\"value\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + "\",\"data\":{\"codice\":\"" + af.IdComune + "\",\"cap\":\"" + af.Cap + "\",\"prov\":\"" + af.Sigla + "\",\"istat\":\"" + af.Istat + "\",\"belfiore\":\"" + af.CodBelfiore + "\"}},";
                }
                if (m_returnStr.EndsWith(",")) m_returnStr = m_returnStr.Substring(0, m_returnStr.Length - 1);
                m_returnStr += "]";
            }
            catch (Exception ex)
            {
                m_returnStr = "[]";
                //return_object.setException(ex); 
            }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getComuniBandoLocalizzazioneProgetti()
        {
            try
            {
                string qry = "";
                SiarLibrary.ComuniCollection doc_comuni = new SiarLibrary.ComuniCollection();
                int id_bando = 0; 
                int top = 0;
                int.TryParse(Request.Params["idb"], out id_bando);
                int.TryParse(Request.Params["top"], out top);
                if (Request.QueryString["term"] != null && Request.QueryString["term"].ToString().Length > 0 && id_bando > 0)
                {
                    qry = Request.QueryString["term"];
                    if (qry.Trim().Length > 0)
                    {
                        Regex isCodice = new Regex("^[0-9.]{1,8}$");
                        doc_comuni = new SiarBLL.ComuniCollectionProvider().FindXLocalizzazioniBando(id_bando, null, null, null, null, null, null, true, qry);
                    }
                }
                //return_object.Html = ToJSON(doc_ateco);
                // [{"value":"NomeComune","data":{"codice":"32","cap":"60100","prov":"AN"}}];
                m_returnStr = "[";
                int ix = 0;
                for (ix = 0; ix < (top > 0 && top < doc_comuni.Count ? top : doc_comuni.Count); ix++)
                {
                    SiarLibrary.Comuni af = doc_comuni[ix];
                    m_returnStr += "{\"value\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + "\",\"data\":{\"codice\":\"" + af.IdComune + "\",\"cap\":\"" + af.Cap + "\",\"prov\":\"" + af.Sigla + "\",\"istat\":\"" + af.Istat + "\",\"belfiore\":\"" + af.CodBelfiore + "\"}},";
                }
                if (m_returnStr.EndsWith(",")) m_returnStr = m_returnStr.Substring(0, m_returnStr.Length - 1);
                m_returnStr += "]";
            }
            catch (Exception ex)
            {
                m_returnStr = "[]";
                //return_object.setException(ex); 
            }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getComuniMarche()
        {
            try
            {
                string qry = "";
                SiarLibrary.ComuniCollection doc_comuni = new SiarLibrary.ComuniCollection();
                int top = 0;
                int.TryParse(Request.Params["top"], out top);
                if (Request.QueryString["term"] != null && Request.QueryString["term"].ToString().Length > 0)
                {
                    qry = Request.QueryString["term"];
                    if (qry.Trim().Length > 0)
                    {
                        Regex isCodice = new Regex("^[0-9.]{1,8}$");
                        doc_comuni = new SiarBLL.ComuniCollectionProvider().FindXLocalizzazioniBandoCovid(null, null, null, null, null, null, true, qry);
                    }
                }
                //return_object.Html = ToJSON(doc_ateco);
                // [{"value":"NomeComune","data":{"codice":"32","cap":"60100","prov":"AN"}}];
                m_returnStr = "[";
                int ix = 0;
                for (ix = 0; ix < (top > 0 && top < doc_comuni.Count ? top : doc_comuni.Count); ix++)
                {
                    SiarLibrary.Comuni af = doc_comuni[ix];
                    m_returnStr += "{\"value\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + "\",\"data\":{\"codice\":\"" + af.IdComune + "\",\"cap\":\"" + af.Cap + "\",\"prov\":\"" + af.Sigla + "\",\"istat\":\"" + af.Istat + "\",\"belfiore\":\"" + af.CodBelfiore + "\"}},";
                }
                if (m_returnStr.EndsWith(",")) m_returnStr = m_returnStr.Substring(0, m_returnStr.Length - 1);
                m_returnStr += "]";
            }
            catch (Exception ex)
            {
                m_returnStr = "[]";
                //return_object.setException(ex); 
            }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getComuniAttivi()
        {
            try
            {
                string qry = "";
                SiarLibrary.ComuniCollection doc_comuni = new SiarLibrary.ComuniCollection();
                int top = 0;
                int.TryParse(Request.Params["top"], out top);
                if (Request.QueryString["term"] != null && Request.QueryString["term"].ToString().Length > 0)
                {
                    qry = Request.QueryString["term"];
                    if (qry.Trim().Length > 0)
                    {
                        Regex isCodice = new Regex("^[0-9.]{1,8}$");
                        doc_comuni = new SiarBLL.ComuniCollectionProvider().FindComuniAttivi(true, qry);
                    }
                }
                //return_object.Html = ToJSON(doc_ateco);
                // [{"value":"NomeComune","data":{"codice":"32","cap":"60100","prov":"AN"}}];
                m_returnStr = "[";
                int ix = 0;
                for (ix = 0; ix < (top > 0 && top < doc_comuni.Count ? top : doc_comuni.Count); ix++)
                {
                    SiarLibrary.Comuni af = doc_comuni[ix];
                    m_returnStr += "{\"value\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + " | (" + af.Sigla + ") | " + af.Cap + "\",\"data\":{\"codice\":\"" + af.IdComune + "\", \"cap\":\"" + af.Cap + "\", \"denominazione\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + "\", \"prov\":\"" + af.Sigla + "\",\"istat\":\"" + af.Istat + "\",\"belfiore\":\"" + af.CodBelfiore + "\"}},";
                }
                if (m_returnStr.EndsWith(",")) 
                    m_returnStr = m_returnStr.Substring(0, m_returnStr.Length - 1);
                m_returnStr += "]";
            }
            catch (Exception ex)
            {
                m_returnStr = "[]";
                //return_object.setException(ex); 
            }
        }

        [SNCOptions.AuthenticationRequiredAttribute(false)]
        [SNCOptions.ReturnTypeObject(SNCOptions.ReturnTypeObject.Json)]
        public void getComuniAttiviENon()
        {
            try
            {
                string qry = "";
                SiarLibrary.ComuniCollection doc_comuni = new SiarLibrary.ComuniCollection();
                int top = 0;
                int.TryParse(Request.Params["top"], out top);
                if (Request.QueryString["term"] != null && Request.QueryString["term"].ToString().Length > 0)
                {
                    qry = Request.QueryString["term"];
                    if (qry.Trim().Length > 0)
                    {
                        Regex isCodice = new Regex("^[0-9.]{1,8}$");
                        doc_comuni = new SiarBLL.ComuniCollectionProvider().FindComuniAttivi(null, qry);
                    }
                }
                //return_object.Html = ToJSON(doc_ateco);
                // [{"value":"NomeComune","data":{"codice":"32","cap":"60100","prov":"AN"}}];
                m_returnStr = "[";
                int ix = 0;
                for (ix = 0; ix < (top > 0 && top < doc_comuni.Count ? top : doc_comuni.Count); ix++)
                {
                    SiarLibrary.Comuni af = doc_comuni[ix];
                    m_returnStr += "{\"value\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + " | (" + af.Sigla + ") | " + af.Cap + "\",\"data\":{\"codice\":\"" + af.IdComune + "\", \"cap\":\"" + af.Cap + "\", \"denominazione\":\"" + af.Denominazione.ToString().Replace("\"", "\\\"") + "\", \"prov\":\"" + af.Sigla + "\",\"istat\":\"" + af.Istat + "\",\"belfiore\":\"" + af.CodBelfiore + "\"}},";
                }
                if (m_returnStr.EndsWith(",")) 
                    m_returnStr = m_returnStr.Substring(0, m_returnStr.Length - 1);
                m_returnStr += "]";
            }
            catch (Exception ex)
            {
                m_returnStr = "[]";
                //return_object.setException(ex); 
            }
        }
    }
}
