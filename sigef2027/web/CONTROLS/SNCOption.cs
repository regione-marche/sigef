using System;

namespace web.CONTROLS.SNCOptions
{
    public enum ViewOption
    {
        Immagine, Bottone, BottoneGriglia, Invisibile
    }

    public enum ReturnTypeObject
    {
        String, Json, Xml
    }

    public class ReturnTypeObjectAttribute : System.Attribute
    {
        private ReturnTypeObject _returnTypeObject;
        public ReturnTypeObject ReturnTypeObject { get { return _returnTypeObject; } }
        public ReturnTypeObjectAttribute(ReturnTypeObject tipo) { _returnTypeObject = tipo; }
    }

    public class AuthenticationRequiredAttribute : System.Attribute
    {
        private bool _authenticationRequired = false;
        public bool AuthenticationRequired { get { return _authenticationRequired; } }
        public AuthenticationRequiredAttribute(bool b) { _authenticationRequired = b; }
    }

    public class ReturnJSONObject
    {
        public ReturnJSONObject()
        {
            _risultatoEsecuzione = 0;
            _messaggioEsecuzione = string.Empty;
            _html = string.Empty;
            _returnTypeObject = ReturnTypeObject.String;
        }

        private int _risultatoEsecuzione;
        private string _messaggioEsecuzione, _html;
        private ReturnTypeObject _returnTypeObject;

        public int RisultatoEsecuzione
        {
            get { return _risultatoEsecuzione; }
            set { _risultatoEsecuzione = value; }
        }

        public string MessaggioEsecuzione
        {
            get { return _messaggioEsecuzione; }
            set { _messaggioEsecuzione = value; }
        }

        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }

        public ReturnTypeObject ReturnTypeObject
        {
            get { return _returnTypeObject; }
            set { _returnTypeObject = value; }
        }

        public void setException(string errore, int gravita)
        {
            _risultatoEsecuzione = gravita;
            _messaggioEsecuzione = errore;
            if (_returnTypeObject == ReturnTypeObject.String)
                _html = "<p class='testoRosso' style='padding:15px;width:100%;text-align:center'>ATTENZIONE!<br /><br/>" + errore + "<br /><br/></p>";
        }
        public void setException(string errore) { setException(errore, -1); }
        public void setException(Exception ex) { setException(ex.Message, -1); }
        public void setException(Exception ex, int gravita) { setException(ex.Message, gravita); }

        public string getReturnMessage()
        {
            string retval = _html;
            try
            {
                if (_returnTypeObject == ReturnTypeObject.Json)
                {
                    System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                    retval = jss.Serialize(this);
                    jss = null;
                }
            }
            catch { retval = null; }
            return retval;
        }
    }
}
