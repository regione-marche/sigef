using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnaManager
{
    #region classe project info da passare ai metodi di RnaOperazioni

    public partial class ProjectInfo
    {
        public int? IdProgetto { get; set; }
        public string IdProgettoRna { get; set; }
        public int IdImpresa { get; set; }
        public string IdFiscaleImpresa { get; set; }
        public int IdOperatore { get; set; }
        public string CodiceBandoRna { get; set; }
    }

    #endregion

    #region classi result
    public interface IResultInfo
    {
        int? IdProgetto { get; set; }
        DateTime DataRichiesta { get; set; }
        bool Success { get; set; }
        int CodiceEsito { get; set; }
        string DescrizioneEsito { get; set; }
        string IdRichiesta { get; set; }
    }

    public partial class ResultInfoBase: IResultInfo
    {
        public int? IdProgetto { get; set; }
        public string IdProgettoRna { get; set; }
        public DateTime DataRichiesta { get; set; }
        public bool Success { get; set; }
        public int CodiceEsito { get; set; }
        public string DescrizioneEsito { get; set; }
        public string IdRichiesta { get; set; }
    }

    public partial class ResultInfo: ResultInfoBase
    {
        public string COR { get; set; }
        public string StatoConcessione { get; set; }
        public byte[] PayloadEsito { get; set; }
    }

    public partial class ResultInfoVisura: ResultInfoBase
    {
        public string TipoVisura { get; set; }
        public byte[] PayloadEsito { get; set; }
    }

    public partial class ResultInfoConcessione: ResultInfoBase
    {
        public string COR { get; set; }
        public string StatoConcessione { get; set; }
        public string IstanzaRichiesta { get; set; }
        public string IstanzaRisposta { get; set; }
        public bool? SuccessEsitoRichiesta { get; set; }
        public int? CodiceEsitoRichiesta { get; set; }
        public string DescrizioneEsitoRichiesta { get; set; }
        public byte[] PayloadEsito { get; set; }
    }

    #endregion

    #region classi POCO per gestione Log
    internal partial class RnaLogVisura
    {
        public int? ID_RNA_LOG_VISURA { get; set; }
        public int? ID_PROGETTO { get; set; }
        public int ID_IMPRESA { get; set; }
        public string ID_FISCALE_IMPRESA { get; set; }
        public string ID_RICHIESTA { get; set; }
        public string TIPO_VISURA { get; set; }
        public int CODICE_ESITO { get; set; }
        public string DESCRIZIONE_ESITO { get; set; }
        public DateTime DATA_RICHIESTA { get; set; }
        public int? CODICE_STATO_RICHIESTA { get; set; }
        public string DESCRIZIONE_STATO_RICHIESTA { get; set; }
        public DateTime? DATA_STATO_RICHIESTA { get; set; }
        public int ID_OPERATORE { get; set; }
        public DateTime DATA_INSERIMENTO { get; set; }
        public DateTime DATA_AGGIORNAMENTO { get; set; }
        public int ID_ARCHIVIO_FILE { get; set; }
    }


    internal partial class RnaLogConcessione
    {
        public int? ID_RNA_LOG_CONCESSIONE { get; set; }
        public int? ID_PROGETTO { get; set; }
        public string ID_PROGETTO_RNA { get; set; }
        public int ID_IMPRESA { get; set; }
        public string ID_FISCALE_IMPRESA { get; set; }
        public string ID_RICHIESTA { get; set; }
        public DateTime DATA_RICHIESTA { get; set; }
        public int ID_OPERATORE_REG_AIUTO { get; set; }
        public string ISTANZA_RICHIESTA { get; set; }
        public string ISTANZA_RISPOSTA { get; set; }
        public string COR { get; set; }
        public int CODICE_ESITO { get; set; }
        public string DESCRIZIONE_ESITO { get; set; }
        public int? CODICE_ESITO_STATO_RICHIESTA { get; set; }
        public string DESCRIZIONE_ESITO_STATO_RICHIESTA { get; set; }
        public int? ID_OPERATORE_STATO_RICHIESTA { get; set; }
        public DateTime? DATA_STATO_RICHIESTA { get; set; }
        //public string TIPO_RISPOSTA { get; set; }
        //public byte[] PAYLOAD { get; set; }
        public string ERRORE { get; set; }
        //public string METODO { get; set; }
        public DateTime DATA_INSERIMENTO { get; set; }
        public DateTime DATA_AGGIORNAMENTO { get; set; }
        public bool? PRODUZIONE { get; set; }
    }


    internal partial class RnaProgettoCor
    {
        public int ID_RNA_PROGETTO_COR { get; set; }
        public int ID_PROGETTO { get; set; }
        public string ID_PROGETTO_RNA { get; set; }
        public string ID_RICHIESTA { get; set; }
        public int ID_IMPRESA { get; set; }
        public string ID_FISCALE_IMPRESA { get; set; }
        public int ID_OPERATORE_ASSEGNAZIONE_COR { get; set; }
        public string COR { get; set; }
        public string STATO_CONCESSIONE { get; set; }
        public bool CONFERMATO { get; set; }
        public DateTime? DATA_ASSEGNAZIONE_COR { get; set; }
        public int? ID_OPERATORE_CONFERMA_CONCESSIONE { get; set; }
        public DateTime? DATA_CONFERMA_CONCESSIONE { get; set; }
        public bool? ANNULLATO { get; set; }
        public int? ID_OPERATORE_ANNULLAMENTO { get; set; }
        public DateTime? DATA_ANNULLAMENTO { get; set; }
        public DateTime DATA_INSERIMENTO { get; set; }
        public DateTime DATA_AGGIORNAMENTO { get; set; }
        public int? CODICE_ESITO_CONFERMA { get; set; }
        public string DESCRIZIONE_ESITO_CONFERMA { get; set; }
    }
    #endregion
}
