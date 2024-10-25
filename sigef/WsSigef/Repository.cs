using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WsSigef
{

    internal partial class ImportServiceLogProgetto
    {
        public int IdImportServiceLogProgetto { get; set; }
        public string SistemaMittente { get; set; }
        public string IstanzaRichiesta { get; set; }
        public string IstanzaRisposta { get; set; }
        public string Esito { get; set; }
        public string Errore { get; set; }
        public DateTime? DataRichiesta { get; set; }
        public DateTime? DataRisposta { get; set; }
        public bool Importato { get; set; }
        public DateTime? DataAcquisizione { get; set; }
        public int? IdProgetto { get; set; }

    }

    internal partial class ImportServiceLogBando
    {
        public int IdImportServiceLogBando { get; set; }
        public string SistemaMittente { get; set; }
        public string IstanzaRichiesta { get; set; }
        public string IstanzaRisposta { get; set; }
        public string Esito { get; set; }
        public string Errore { get; set; }
        public DateTime? DataRichiesta { get; set; }
        public DateTime? DataRisposta { get; set; }
        public bool Importato { get; set; }
        public DateTime? DataAcquisizione { get; set; }
        public int? IdBando { get; set; }

    }

    internal partial class ImportServiceLogDomandaPagamento
    {
        public int IdImportServiceLogDomandaPagamento { get; set; }
        public string SistemaMittente { get; set; }
        public string IstanzaRichiesta { get; set; }
        public string IstanzaRisposta { get; set; }
        public string Esito { get; set; }
        public string Errore { get; set; }
        public DateTime? DataRichiesta { get; set; }
        public DateTime? DataRisposta { get; set; }
        public bool Importato { get; set; }
        public DateTime? DataAcquisizione { get; set; }
        public int? IdDomandaPagamento { get; set; }

    }

    internal partial class ImportServiceLogVariante
    {
        public int IdImportServiceLogVariante { get; set; }
        public string SistemaMittente { get; set; }
        public string IstanzaRichiesta { get; set; }
        public string IstanzaRisposta { get; set; }
        public string Esito { get; set; }
        public string Errore { get; set; }
        public DateTime? DataRichiesta { get; set; }
        public DateTime? DataRisposta { get; set; }
        public bool Importato { get; set; }
        public DateTime? DataAcquisizione { get; set; }
        public int? IdVariante { get; set; }

    }

    internal partial class ImportServiceSistemaCensito
    {
        public int IdImportServiceSistemaCensito { get; set; }
        public string CodiceSistema { get; set; }
        public DateTime? DataInizioValidita { get; set; }
        public DateTime? DataFineValidita { get; set; }
        public bool? FlagAbilitato { get; set; }
        public DateTime? DataInserimento { get; set; }
        public DateTime? DataAggiornamento { get; set; }
    }

    internal partial class ResultInfoLogBandi
    {
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public DateTime? DataOperazione { get; set; }
        public int? IdBando { get; set; }
        public int? IdImportServiceLogBando { get; set; }
    }

    internal partial class ResultInfoLogProgetti
    {
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public DateTime? DataOperazione { get; set; }
        public int? IdProgetto { get; set; }
        public int? IdImportServiceLogProgetto { get; set; }
    }

    internal partial class ResultInfoLogDomandePagamento
    {
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public DateTime? DataOperazione { get; set; }
        public int? IdDomandaPagamento { get; set; }
        public int? IdImportServiceLogDomandaPagamento { get; set; }
    }

    internal partial class ResultInfoLogVarianti
    {
        public string Esito { get; set; }
        public string DescrizioneEsito { get; set; }
        public DateTime? DataOperazione { get; set; }
        public int? IdVariante { get; set; }
        public int? IdImportServiceLogVariante { get; set; }
    }

    public partial class ProceduraAttivazioneResultInfo
    {
        public int IdTicketProceduraAttivazione { get; set; }
        public string Esito { get; set; }
        public string Errors { get; set; }
        public int? IdProceduraAttivazione { get; set; }
    }

    public partial class ProgettoResultInfo
    {
        public int IdTicketProgetto { get; set; }
        public string Esito { get; set; }
        public string Errors { get; set; }
        public int? IdProgetto { get; set; }
    }

    public partial class DomandaPagamentoResultInfo
    {
        public int IdTicketDomandaPagamento { get; set; }
        public string Esito { get; set; }
        public string Errors { get; set; }
        public int? IdDomandaPagamento { get; set; }
    }

    public partial class DomandaVarianteResultInfo
    {
        public int IdTicketDomandaVariante { get; set; }
        public string Esito { get; set; }
        public string Errors { get; set; }
        public int? IdVariante { get; set; }
    }

    public partial class AuthInfo
    {
        public string CodiceSistema { get; set; }
        public string Username { get;  set; }
        public string Password { get; set; }
    }

    public class AuthInfoResult
    {
        public string Result { get; set; } 
        public string User { get; set; }
        public string Message { get; set; }

        public AuthInfoResult(string result, string user, string message)
        {
            Result = result;
            User = user;
            Message = message;
        }
    }

}