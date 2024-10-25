using System;
using System.Collections.Generic;
using System.Text;

namespace SiarActions
{
    public class StepResult
    {
        public StepResult()
        {
            _esito = false;
            _descrizione = null;
        }
        private string _descrizione;
        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }        
        }

        private bool _esito;
        public bool Esito
        {
            get { return _esito; }
            set { _esito = value; }
        }    
    }
    public static class StepProvider
    {

        public static StepResult SendMail(int ID_Domanda)
        {
            StepResult retval = new StepResult();
            retval.Esito = true;
            retval.Descrizione = "Email inviata correttamente.";
            return retval;
        }

        public static StepResult SendMail2(int ID_Domanda)
        {
            StepResult retval = new StepResult();
            retval.Esito = false;
            retval.Descrizione = "Invio email fallito. Server non trovato.";
            return retval;
        }
    }
}
