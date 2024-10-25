using System;
using System.Collections.Generic;
using System.Text;

namespace SiarLibrary
{
    public static class TextProvider
    {
        public static string Get(TextErrorCodes c)
        {
            string retval = "", hd_email = System.Configuration.ConfigurationManager.AppSettings["APP:HDEmail"];
            switch (c)
            {
                case TextErrorCodes.Generico:
                    retval = "Si è verificato un errore sul server. Se la situazione persiste si prega<br />di segnalare il problema a " + hd_email + ".";
                    break;
                case TextErrorCodes.GenericoConLink:
                    retval = "Si è verificato un errore sul server. Se la situazione persiste si prega<br />di segnalare il problema a <a href='mailto:" + hd_email
                        + "' style='font-style:italic;font-size:12px;color:red'>[" + hd_email + "]</a>";
                    break;
                case TextErrorCodes.RappresentanteLegale:
                    retval = "L'impresa non ha un rappresentante legale valido. Impossibile continuare.";
                    break;
                case TextErrorCodes.PraticaNonValida:
                    retval = "La pratica selezionata non è valida. Impossibile continuare.";
                    break;
                case TextErrorCodes.ElementoNonSelezionato:
                    retval = "L`elemento selezionato non è valido. Impossibile continuare.";
                    break;
                case TextErrorCodes.ChecklistNonVerificata:
                    retval = "La pratica non soddisfa tutti i requisiti obbligatori imposti dalla checklist.";
                    break;
                case TextErrorCodes.RegistroProtocolloChiuso:
                    retval = "Il registro di protocollo è momentaneamente chiuso. Si consiglia di attendere almeno mezz`ora e poi riprovare.";
                    break;
                case TextErrorCodes.RegistroProtocolloNonAttivo:
                    retval = "Il servizio di protocollo regionale non è attivo. Impossibile eseguire la richiesta.";
                    break;
                case TextErrorCodes.DocumentoNonValido:
                    retval = //"Il documento selezionato non è valido.";
                        "La segnatura specificata non corrisponde ad un protocollo valido o il documento non è stato acquisito.";
                    break;
                case TextErrorCodes.DocumentoNonProtocollato:
                    retval = "Si è verificato un errore durante la procollazione del documento. Segnalare il problema a <a href='mailto:" + hd_email
                        + "' style='font-style:italic;font-size:12px;color:red'>[" + hd_email + "]</a>";
                    break;
                case TextErrorCodes.ModificaDisabilitata:
                    retval = "La modifica dei dati è disabilitata.";
                    break;
                case TextErrorCodes.UtenteSenzaPermessi:
                    retval = "L`utente non dispone dei permessi necessari alla visualizzazione della pagina selezionata.";
                    break;
                case TextErrorCodes.DownloadFallito:
                    retval = "Non è stato possibile recuperati i dati richiesti, si consiglia di ripetere il download.";
                    break;
                case TextErrorCodes.SianNonRaggiungibile:
                    retval = "Non è stato possibile contattare il server Sian, si consiglia di attendere qualche minuto e poi riprovare.";
                    break;
                case TextErrorCodes.EmailNonInviata:
                    retval = "Si è verificato un problema durante l'invio dell'email richiesta.<br />Se la situazione persiste si prega di segnalare il problema a <a href='mailto:"
                        + hd_email + "' style='font-style:italic;font-size:12px;color:red'>[" + hd_email + "]</a>";
                    break;
            }
            return retval;
        }

        public static string Get(TextMessageCodes c)
        {
            string retval = "";
            switch (c)
            {
                case TextMessageCodes.ModificheSalvate:
                    retval = "Modifiche salvate correttamente.";
                    break;
                case TextMessageCodes.ChecklistVerificata:
                    retval = "Checklist verificata correttamente. Ora è possibile procedere con la firma digitale.";
                    break;
            }
            return retval;
        }
    }

    public enum TextErrorCodes
    {
        None, Generico, GenericoConLink, RappresentanteLegale, PraticaNonValida, ElementoNonSelezionato, ChecklistNonVerificata, RegistroProtocolloChiuso,
        RegistroProtocolloNonAttivo, DocumentoNonValido, DocumentoNonProtocollato, ModificaDisabilitata, UtenteSenzaPermessi,
        DownloadFallito, SianNonRaggiungibile, EmailNonInviata
    }

    public enum TextMessageCodes { None, ModificheSalvate, ChecklistVerificata }
}