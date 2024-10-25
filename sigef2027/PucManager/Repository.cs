using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PucManager
{
    internal partial class IgrueInvio
    {
        public int ID_INVIO { get; set; }
        public string ID_TICKET { get; set; }
        public DateTime? DATA_INVIO { get; set; }
        public DateTime? DATA_DA { get; set; }
        public DateTime? DATA_A { get; set; }
        public byte[] FILE_INVIO { get; set; }
        public int? ID_OPERATORE { get; set; }
        public int? CODICE_ESITO { get; set; }
        public string DESCRIZIONE_ESITO { get; set; }
        public string DETTAGLIO_ESITO { get; set; }
        public DateTime? TIMESTAMP_ESITO { get; set; }
        public string TIPO_FILE { get; set; }
        public string CODICE_FONDO { get; set; }
    }

    internal partial class IgrueLogErrori
    {
        public int ID_IGRUE_LOG_ERRORI { get; set; }
        public int? ID_INVIO { get; set; }
        public string ID_TICKET { get; set; }
        public DateTime? DATA_RICHIESTA { get; set; }
        public byte[] FILE_ERRORI { get; set; }
        public string ISTANZA_ERRORI { get; set; }
        public int? ID_OPERATORE { get; set; }
        public int? CODICE_ESITO { get; set; }
        public string DESCRIZIONE_ESITO { get; set; }
        public string DETTAGLIO_ESITO { get; set; }
        public DateTime? TIMESTAMP_ESITO { get; set; }
        public string TIPO_FILE { get; set; }
        public string CODICE_FONDO { get; set; }
    }

    internal partial class BandoCodiciAttivazione 
    {
        public int ID_BANDO { get; set; }
        public string COD_PROCEDURA_ATTIVAZIONE { get; set; }
    }


    public partial class BandoInfo
    {
        public int ID_BANDO { get; set; }
        public string COD_PROCEDURA_ATTIVAZIONE { get; set; }
        public string DESCRIZIONE { get; set; }
    }


    public partial class ResultInfo
    {
        public int CodiceEsito { get; set; }
        public string DescrizioneEsito { get; set; }
        public string DettaglioEsito { get; set; }
        public DateTime? TimeStampEsito { get; set; }
    }


    public partial class ResultInfoAssegnazione
    {
        public string IdProceduraAttivazione { get; set; }
        public string IdAmministrazione { get; set; }
        public int IdSistema { get; set; }
        public DateTime? DataAssegnazione { get; set; }
        public ResultInfo Esito { get; set; }
    }


    internal partial class IgrueAP00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string TITOLO_PROGETTO { get; set; }
        public string SINTESI_PRG { get; set; }
        public string TIPO_OPERAZIONE { get; set; }
        public string CUP { get; set; }
        public string TIPO_AIUTO { get; set; }
        public string DATA_INIZIO { get; set; }
        public string DATA_FINE_PREVISTA { get; set; }
        public string DATA_FINE_EFFETTIVA { get; set; }
        public string TIP_PROC_ATT_ORIG { get; set; }
        public string CODICE_PROC_ATT_ORIG { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueAP01
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PROC_ATT { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueAP02
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PRG_COMPLESSO { get; set; }
        public string GRANDE_PROGETTO { get; set; }
        public string GENERATORE_ENTRATE { get; set; }
        public string LIV_ISTITUZIONE_STR_FIN { get; set; }
        public string FONDO_DI_FONDI { get; set; }
        public string TIPO_LOCALIZZAZIONE { get; set; }
        public string COD_VULNERABILI { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueAP03
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PROGRAMMA { get; set; }
        public string TIPO_CLASS { get; set; }
        public string COD_CLASSIFICAZIONE { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueAP04
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PROGRAMMA { get; set; }
        public string STATO { get; set; }
        public string SPECIFICA_STATO { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueAP05
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_STRU_ATT { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueAP06
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_REGIONE { get; set; }
        public string COD_PROVINCIA { get; set; }
        public string COD_COMUNE { get; set; }
        public string INDIRIZZO { get; set; }
        public string COD_CAP { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_FONDO { get; set; }
        public string COD_NORMA { get; set; }
        public string COD_DEL_CIPE { get; set; }
        public string COD_LOCALIZZAZIONE { get; set; }
        public string CF_COFINANZ { get; set; }
        public decimal? IMPORTO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN01
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PROGRAMMA { get; set; }
        public string COD_LIV_GERARCHICO { get; set; }
        public decimal? IMPORTO_AMMESSO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN02
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string VOCE_SPESA { get; set; }
        public decimal? IMPORTO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN03
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string ANNO_PIANO { get; set; }
        public decimal? IMP_REALIZZATO { get; set; }
        public decimal? MP_DA_REALIZZARE { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN04
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_IMPEGNO { get; set; }
        public string TIPOLOGIA_IMPEGNO { get; set; }
        public string DATA_IMPEGNO { get; set; }
        public decimal? IMPORTO_IMPEGNO { get; set; }
        public string CAUSALE_DISIMPEGNO { get; set; }
        public string NOTE_IMPEGNO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN05
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_IMPEGNO { get; set; }
        public string TIPOLOGIA_IMPEGNO { get; set; }
        public string DATA_IMPEGNO { get; set; }
        public string COD_PROGRAMMA { get; set; }
        public string COD_LIV_GERARCHICO { get; set; }
        public string DATA_IMP_AMM { get; set; }
        public string TIPOLOGIA_IMP_AMM { get; set; }
        public string CAUSALE_DISIMPEGNO_AMM { get; set; }
        public decimal? IMPORTO_IMP_AMM { get; set; }
        public string NOTE_IMP { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN06
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PAGAMENTO { get; set; }
        public string TIPOLOGIA_PAG { get; set; }
        public string DATA_PAGAMENTO { get; set; }
        public decimal? IMPORTO_PAG { get; set; }
        public string CAUSALE_PAGAMENTO { get; set; }
        public string NOTE_PAG { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN07
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PAGAMENTO { get; set; }
        public string TIPOLOGIA_PAG { get; set; }
        public string DATA_PAGAMENTO { get; set; }
        public string COD_PROGRAMMA { get; set; }
        public string COD_LIV_GERARCHICO { get; set; }
        public string DATA_PAG_AMM { get; set; }
        public string TIPOLOGIA_PAG_AMM { get; set; }
        public string CAUSALE_PAG_AMM { get; set; }
        public decimal? IMPORTO_PAG_AMM { get; set; }
        public string NOTE_PAG { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN08
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PAGAMENTO { get; set; }
        public string TIPOLOGIA_PAG { get; set; }
        public string DATA_PAGAMENTO { get; set; }
        public string CODICE_FISCALE { get; set; }
        public string FLAG_SOGGETTO_PUBBLICO { get; set; }
        public string TIPO_PERCETTORE { get; set; }
        public decimal? IMPORTO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN09
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string DATA_DOMANDA { get; set; }
        public string ID_DOMANDA_PAGAMENTO { get; set; }
        public string TIPOLOGIA_IMPORTO { get; set; }
        public string COD_LIV_GERARCHICO { get; set; }
        public decimal? IMPORTO_SPESA_TOT { get; set; }
        public decimal? IMPORTO_SPESA_PUB { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFN10
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_FONDO { get; set; }
        public decimal? IMPORTO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueFO00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_CORSO { get; set; }
        public string INDICE_ANNUALITA { get; set; }
        public string NUMERO_ANNUALITA { get; set; }
        public string TITOLO_CORSO { get; set; }
        public string COD_MODALITA_FORMATIVA { get; set; }
        public string COD_CONTENUTO_FORMATIVO { get; set; }
        public string DATA_AVVIO { get; set; }
        public string DATA_CONCLUSIONE { get; set; }
        public string COD_CRITERI_SELEZIONE { get; set; }
        public string ESAME_FINALE { get; set; }
        public string COD_ATTESTAZIONE_FINALE { get; set; }
        public string COD_QUALIFICA { get; set; }
        public string STAGE_TIROCINI { get; set; }
        public string DURATA_AULA { get; set; }
        public string DURATA_WE { get; set; }
        public string DURATA_LABORATORIO { get; set; }
        public string DOCENTI_TUTOR { get; set; }
        public string FLAG_VOUCHER { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueIN00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string TIPO_INDICATORE_DI_RISULTATO { get; set; }
        public string COD_INDICATORE { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueIN01
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string TIPO_INDICATORE_DI_OUTPUT { get; set; }
        public string COD_INDICATORE { get; set; }
        public decimal? VAL_PROGRAMMATO { get; set; }
        public decimal? VALORE_REALIZZATO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgruePA00
    {
        public string COD_PROC_ATT { get; set; }
        public string COD_PROC_ATT_LOCALE { get; set; }
        public string COD_AIUTO_RNA { get; set; }
        public string TIP_PROCEDURA_ATT { get; set; }
        public string FLAG_AIUTI { get; set; }
        public string DESCR_PROCEDURA_ATT { get; set; }
        public string COD_TIPO_RESP_PROC { get; set; }
        public string DENOM_RESP_PROC { get; set; }
        public string DATA_AVVIO_PROCEDURA { get; set; }
        public string DATA_FINE_PROCEDURA { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgruePA01
    {
        public string COD_PROC_ATT { get; set; }
        public string COD_PROGRAMMA { get; set; }
        public decimal? IMPORTO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgruePG00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_PROC_AGG { get; set; }
        public string CIG { get; set; }
        public string MOTIVO_ASSENZA_CIG { get; set; }
        public string DESCR_PROCEDURA_AGG { get; set; }
        public string TIPO_PROC_AGG { get; set; }
        public decimal? IMPORTO_PROCEDURA_AGG { get; set; }
        public string DATA_PUBBLICAZIONE { get; set; }
        public decimal? IMPORTO_AGGIUDICATO { get; set; }
        public string DATA_AGGIUDICAZIONE { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgruePR00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_FASE { get; set; }
        public string DATA_INIZIO_PREVISTA { get; set; }
        public string DATA_INIZIO_EFFETTIVA { get; set; }
        public string DATA_FINE_PREVISTA { get; set; }
        public string DATA_FINE_EFFETTIVA { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgruePR01
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string STATO_PROGETTO { get; set; }
        public string DATA_RIFERIMENTO { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueSC00
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string COD_RUOLO_SOG { get; set; }
        public string CODICE_FISCALE { get; set; }
        public string FLAG_SOGGETTO_PUBBLICO { get; set; }
        public string COD_UNI_IPA { get; set; }
        public string DENOMINAZIONE_SOG { get; set; }
        public string FORMA_GIURIDICA { get; set; }
        public string SETT_ATT_ECONOMICA { get; set; }
        public string NOTE { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }

    internal partial class IgrueSC01
    {
        public string COD_LOCALE_PROGETTO { get; set; }
        public string CODICE_FISCALE { get; set; }
        public string CODICE_CORSO { get; set; }
        public string SESSO { get; set; }
        public string DATA_NASCITA { get; set; }
        public string COD_ISTAT_RES { get; set; }
        public string COD_ISTAT_DOM { get; set; }
        public string CITTADINANZA { get; set; }
        public string TITOLO_STUDIO { get; set; }
        public string COND_MERCATO_INGRESSO { get; set; }
        public string DURATA_RICERCA { get; set; }
        public string CODICE_VULNERABILE_PA { get; set; }
        public string STATO_PARTECIPANTE { get; set; }
        public string DATA_USCITA { get; set; }
        public string FLG_CANCELLAZIONE { get; set; }
        public string OPERAZIONE { get; set; }
        public int? ID_INVIO { get; set; }
        public int? NR_RIGA_INVIO { get; set; }
        public int? NR_RIGA_CANCELLAZIONE { get; set; }
    }
}


