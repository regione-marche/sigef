using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per PagamentiRichiesti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IPagamentiRichiestiProvider
    {
        int Save(PagamentiRichiesti PagamentiRichiestiObj);
        int SaveCollection(PagamentiRichiestiCollection collectionObj);
        int Delete(PagamentiRichiesti PagamentiRichiestiObj);
        int DeleteCollection(PagamentiRichiestiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for PagamentiRichiesti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class PagamentiRichiesti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdPagamentoRichiesto;
        private NullTypes.IntNT _IdInvestimento;
        private NullTypes.DatetimeNT _DataRichiestaPagamento;
        private NullTypes.DecimalNT _ContributoRichiesto;
        private NullTypes.DecimalNT _ContributoAmmesso;
        private NullTypes.BoolNT _Ammesso;
        private NullTypes.StringNT _Istruttore;
        private NullTypes.DatetimeNT _DataValutazione;
        private NullTypes.DecimalNT _ImportoComputoMetrico;
        private NullTypes.DecimalNT _ImportoRichiesto;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdProgrammazione;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.DatetimeNT _DataVariazione;
        private NullTypes.StringNT _OperatoreVariazione;
        private NullTypes.IntNT _CodTipoInvestimento;
        private NullTypes.StringNT _CodStp;
        private NullTypes.IntNT _IdUnitaMisura;
        private NullTypes.DecimalNT _Quantita;
        private NullTypes.DecimalNT _CostoInvestimento;
        private NullTypes.DecimalNT _SpeseGenerali;
        private NullTypes.DecimalNT _ContributoRichiestoInvestimento;
        private NullTypes.DecimalNT _QuotaContributoRichiesto;
        private NullTypes.IntNT _IdSettoreProduttivo;
        private NullTypes.IntNT _IdPrioritaSettoriale;
        private NullTypes.IntNT _IdObiettivoMisura;
        private NullTypes.IntNT _IdCodificaInvestimento;
        private NullTypes.IntNT _IdDettaglioInvestimento;
        private NullTypes.IntNT _IdSpecificaInvestimento;
        private NullTypes.BoolNT _InvestimentoAmmesso;
        private NullTypes.StringNT _IstruttoreInvestimento;
        private NullTypes.IntNT _IdInvestimentoOriginale;
        private NullTypes.DatetimeNT _DataValutazioneInvestimento;
        private NullTypes.StringNT _ValutazioneInvestimento;
        private NullTypes.IntNT _IdVariante;
        private NullTypes.DecimalNT _ImportoComputoMetricoAmmesso;
        private NullTypes.DecimalNT _ContributoRichiestoRecuperoAnticipo;
        private NullTypes.DecimalNT _ContributoAmmessoRecuperoAnticipo;
        private NullTypes.StringNT _NoteIstruttore;
        private NullTypes.StringNT _CodSanzioneVariazioneInvestimenti;
        private NullTypes.DecimalNT _ImportoDisavanzoCostiAmmessi;
        private NullTypes.DecimalNT _ContributoDisavanzoCostiAmmessi;
        private NullTypes.DecimalNT _ContributoRichiestoAltreFonti;
        private NullTypes.DecimalNT _ContributoAmmessoAltreFonti;
        [NonSerialized]
        private IPagamentiRichiestiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IPagamentiRichiestiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public PagamentiRichiesti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_PAGAMENTO_RICHIESTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPagamentoRichiesto
        {
            get { return _IdPagamentoRichiesto; }
            set
            {
                if (IdPagamentoRichiesto != value)
                {
                    _IdPagamentoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdInvestimento
        {
            get { return _IdInvestimento; }
            set
            {
                if (IdInvestimento != value)
                {
                    _IdInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_RICHIESTA_PAGAMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRichiestaPagamento
        {
            get { return _DataRichiestaPagamento; }
            set
            {
                if (DataRichiestaPagamento != value)
                {
                    _DataRichiestaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_RICHIESTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoRichiesto
        {
            get { return _ContributoRichiesto; }
            set
            {
                if (ContributoRichiesto != value)
                {
                    _ContributoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAmmesso
        {
            get { return _ContributoAmmesso; }
            set
            {
                if (ContributoAmmesso != value)
                {
                    _ContributoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AMMESSO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Ammesso
        {
            get { return _Ammesso; }
            set
            {
                if (Ammesso != value)
                {
                    _Ammesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTRUTTORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Istruttore
        {
            get { return _Istruttore; }
            set
            {
                if (Istruttore != value)
                {
                    _Istruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VALUTAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataValutazione
        {
            get { return _DataValutazione; }
            set
            {
                if (DataValutazione != value)
                {
                    _DataValutazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_COMPUTO_METRICO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoComputoMetrico
        {
            get { return _ImportoComputoMetrico; }
            set
            {
                if (ImportoComputoMetrico != value)
                {
                    _ImportoComputoMetrico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RICHIESTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRichiesto
        {
            get { return _ImportoRichiesto; }
            set
            {
                if (ImportoRichiesto != value)
                {
                    _ImportoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_AMMESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoAmmesso
        {
            get { return _ImportoAmmesso; }
            set
            {
                if (ImportoAmmesso != value)
                {
                    _ImportoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgetto
        {
            get { return _IdProgetto; }
            set
            {
                if (IdProgetto != value)
                {
                    _IdProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DOMANDA_PAGAMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDomandaPagamento
        {
            get { return _IdDomandaPagamento; }
            set
            {
                if (IdDomandaPagamento != value)
                {
                    _IdDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGRAMMAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgrammazione
        {
            get { return _IdProgrammazione; }
            set
            {
                if (IdProgrammazione != value)
                {
                    _IdProgrammazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT Descrizione
        {
            get { return _Descrizione; }
            set
            {
                if (Descrizione != value)
                {
                    _Descrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VARIAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataVariazione
        {
            get { return _DataVariazione; }
            set
            {
                if (DataVariazione != value)
                {
                    _DataVariazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_VARIAZIONE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT OperatoreVariazione
        {
            get { return _OperatoreVariazione; }
            set
            {
                if (OperatoreVariazione != value)
                {
                    _OperatoreVariazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT CodTipoInvestimento
        {
            get { return _CodTipoInvestimento; }
            set
            {
                if (CodTipoInvestimento != value)
                {
                    _CodTipoInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_STP
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodStp
        {
            get { return _CodStp; }
            set
            {
                if (CodStp != value)
                {
                    _CodStp = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_UNITA_MISURA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUnitaMisura
        {
            get { return _IdUnitaMisura; }
            set
            {
                if (IdUnitaMisura != value)
                {
                    _IdUnitaMisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUANTITA
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT Quantita
        {
            get { return _Quantita; }
            set
            {
                if (Quantita != value)
                {
                    _Quantita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COSTO_INVESTIMENTO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT CostoInvestimento
        {
            get { return _CostoInvestimento; }
            set
            {
                if (CostoInvestimento != value)
                {
                    _CostoInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESE_GENERALI
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT SpeseGenerali
        {
            get { return _SpeseGenerali; }
            set
            {
                if (SpeseGenerali != value)
                {
                    _SpeseGenerali = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_RICHIESTO_INVESTIMENTO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoRichiestoInvestimento
        {
            get { return _ContributoRichiestoInvestimento; }
            set
            {
                if (ContributoRichiestoInvestimento != value)
                {
                    _ContributoRichiestoInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUOTA_CONTRIBUTO_RICHIESTO
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT QuotaContributoRichiesto
        {
            get { return _QuotaContributoRichiesto; }
            set
            {
                if (QuotaContributoRichiesto != value)
                {
                    _QuotaContributoRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_SETTORE_PRODUTTIVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSettoreProduttivo
        {
            get { return _IdSettoreProduttivo; }
            set
            {
                if (IdSettoreProduttivo != value)
                {
                    _IdSettoreProduttivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PRIORITA_SETTORIALE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPrioritaSettoriale
        {
            get { return _IdPrioritaSettoriale; }
            set
            {
                if (IdPrioritaSettoriale != value)
                {
                    _IdPrioritaSettoriale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_OBIETTIVO_MISURA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdObiettivoMisura
        {
            get { return _IdObiettivoMisura; }
            set
            {
                if (IdObiettivoMisura != value)
                {
                    _IdObiettivoMisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_CODIFICA_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdCodificaInvestimento
        {
            get { return _IdCodificaInvestimento; }
            set
            {
                if (IdCodificaInvestimento != value)
                {
                    _IdCodificaInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_DETTAGLIO_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDettaglioInvestimento
        {
            get { return _IdDettaglioInvestimento; }
            set
            {
                if (IdDettaglioInvestimento != value)
                {
                    _IdDettaglioInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_SPECIFICA_INVESTIMENTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSpecificaInvestimento
        {
            get { return _IdSpecificaInvestimento; }
            set
            {
                if (IdSpecificaInvestimento != value)
                {
                    _IdSpecificaInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INVESTIMENTO_AMMESSO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT InvestimentoAmmesso
        {
            get { return _InvestimentoAmmesso; }
            set
            {
                if (InvestimentoAmmesso != value)
                {
                    _InvestimentoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ISTRUTTORE_INVESTIMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT IstruttoreInvestimento
        {
            get { return _IstruttoreInvestimento; }
            set
            {
                if (IstruttoreInvestimento != value)
                {
                    _IstruttoreInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_INVESTIMENTO_ORIGINALE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdInvestimentoOriginale
        {
            get { return _IdInvestimentoOriginale; }
            set
            {
                if (IdInvestimentoOriginale != value)
                {
                    _IdInvestimentoOriginale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_VALUTAZIONE_INVESTIMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataValutazioneInvestimento
        {
            get { return _DataValutazioneInvestimento; }
            set
            {
                if (DataValutazioneInvestimento != value)
                {
                    _DataValutazioneInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:VALUTAZIONE_INVESTIMENTO
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT ValutazioneInvestimento
        {
            get { return _ValutazioneInvestimento; }
            set
            {
                if (ValutazioneInvestimento != value)
                {
                    _ValutazioneInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_VARIANTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdVariante
        {
            get { return _IdVariante; }
            set
            {
                if (IdVariante != value)
                {
                    _IdVariante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_COMPUTO_METRICO_AMMESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoComputoMetricoAmmesso
        {
            get { return _ImportoComputoMetricoAmmesso; }
            set
            {
                if (ImportoComputoMetricoAmmesso != value)
                {
                    _ImportoComputoMetricoAmmesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoRichiestoRecuperoAnticipo
        {
            get { return _ContributoRichiestoRecuperoAnticipo; }
            set
            {
                if (ContributoRichiestoRecuperoAnticipo != value)
                {
                    _ContributoRichiestoRecuperoAnticipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAmmessoRecuperoAnticipo
        {
            get { return _ContributoAmmessoRecuperoAnticipo; }
            set
            {
                if (ContributoAmmessoRecuperoAnticipo != value)
                {
                    _ContributoAmmessoRecuperoAnticipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE_ISTRUTTORE
        /// Tipo sul db:NTEXT
        /// </summary>
        public NullTypes.StringNT NoteIstruttore
        {
            get { return _NoteIstruttore; }
            set
            {
                if (NoteIstruttore != value)
                {
                    _NoteIstruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_SANZIONE_VARIAZIONE_INVESTIMENTI
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT CodSanzioneVariazioneInvestimenti
        {
            get { return _CodSanzioneVariazioneInvestimenti; }
            set
            {
                if (CodSanzioneVariazioneInvestimenti != value)
                {
                    _CodSanzioneVariazioneInvestimenti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DISAVANZO_COSTI_AMMESSI
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDisavanzoCostiAmmessi
        {
            get { return _ImportoDisavanzoCostiAmmessi; }
            set
            {
                if (ImportoDisavanzoCostiAmmessi != value)
                {
                    _ImportoDisavanzoCostiAmmessi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_DISAVANZO_COSTI_AMMESSI
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoDisavanzoCostiAmmessi
        {
            get { return _ContributoDisavanzoCostiAmmessi; }
            set
            {
                if (ContributoDisavanzoCostiAmmessi != value)
                {
                    _ContributoDisavanzoCostiAmmessi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_RICHIESTO_ALTRE_FONTI
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoRichiestoAltreFonti
        {
            get { return _ContributoRichiestoAltreFonti; }
            set
            {
                if (ContributoRichiestoAltreFonti != value)
                {
                    _ContributoRichiestoAltreFonti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO_ALTRE_FONTI
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAmmessoAltreFonti
        {
            get { return _ContributoAmmessoAltreFonti; }
            set
            {
                if (ContributoAmmessoAltreFonti != value)
                {
                    _ContributoAmmessoAltreFonti = value;
                    SetDirtyFlag();
                }
            }
        }


        //Get e Set dei campi 'ForeignKey'

        public int Save()
        {
            if (this.IsDirty)
            {
                return _provider.Save(this);
            }
            else
            {
                return 0;
            }
        }

        public int Delete()
        {
            return _provider.Delete(this);
        }

        //Get e Set dei campi 'aggiuntivi'

    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for PagamentiRichiestiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class PagamentiRichiestiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
    {

        //Serializzazione xml
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("_count", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue(i.ToString(), this[i]);
            }
        }
        private PagamentiRichiestiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((PagamentiRichiesti)info.GetValue(i.ToString(), typeof(PagamentiRichiesti)));
            }
        }

        //Costruttore
        public PagamentiRichiestiCollection()
        {
            this.ItemType = typeof(PagamentiRichiesti);
        }

        //Costruttore con provider
        public PagamentiRichiestiCollection(IPagamentiRichiestiProvider providerObj)
        {
            this.ItemType = typeof(PagamentiRichiesti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new PagamentiRichiesti this[int index]
        {
            get { return (PagamentiRichiesti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new PagamentiRichiestiCollection GetChanges()
        {
            return (PagamentiRichiestiCollection)base.GetChanges();
        }

        [NonSerialized]
        private IPagamentiRichiestiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IPagamentiRichiestiProvider Provider
        {
            get { return _provider; }
            set
            {
                _provider = value;
                for (int i = 0; i < this.Count; i++)
                {
                    this[i].Provider = value;
                }
            }
        }

        public int SaveCollection()
        {
            return _provider.SaveCollection(this);
        }
        public int DeleteCollection()
        {
            return _provider.DeleteCollection(this);
        }
        //Add
        public int Add(PagamentiRichiesti PagamentiRichiestiObj)
        {
            if (PagamentiRichiestiObj.Provider == null) PagamentiRichiestiObj.Provider = this.Provider;
            return base.Add(PagamentiRichiestiObj);
        }

        //AddCollection
        public void AddCollection(PagamentiRichiestiCollection PagamentiRichiestiCollectionObj)
        {
            foreach (PagamentiRichiesti PagamentiRichiestiObj in PagamentiRichiestiCollectionObj)
                this.Add(PagamentiRichiestiObj);
        }

        //Insert
        public void Insert(int index, PagamentiRichiesti PagamentiRichiestiObj)
        {
            if (PagamentiRichiestiObj.Provider == null) PagamentiRichiestiObj.Provider = this.Provider;
            base.Insert(index, PagamentiRichiestiObj);
        }

        //CollectionGetById
        public PagamentiRichiesti CollectionGetById(NullTypes.IntNT IdPagamentoRichiestoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdPagamentoRichiesto == IdPagamentoRichiestoValue))
                    find = true;
                else
                    i++;
            }
            if (find)
                return this[i];
            else
                return null;
        }
        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PagamentiRichiestiCollection SubSelect(NullTypes.IntNT IdPagamentoRichiestoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdInvestimentoEqualThis,
NullTypes.DatetimeNT DataRichiestaPagamentoEqualThis, NullTypes.DecimalNT ImportoComputoMetricoEqualThis, NullTypes.DecimalNT ImportoRichiestoEqualThis,
NullTypes.DecimalNT ContributoRichiestoEqualThis, NullTypes.DecimalNT ContributoRichiestoAltreFontiEqualThis, NullTypes.DecimalNT ImportoDisavanzoCostiAmmessiEqualThis,
NullTypes.DecimalNT ContributoDisavanzoCostiAmmessiEqualThis, NullTypes.DecimalNT ContributoRichiestoRecuperoAnticipoEqualThis, NullTypes.DecimalNT ImportoComputoMetricoAmmessoEqualThis,
NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ContributoAmmessoEqualThis, NullTypes.DecimalNT ContributoAmmessoAltreFontiEqualThis,
NullTypes.DecimalNT ContributoAmmessoRecuperoAnticipoEqualThis, NullTypes.BoolNT AmmessoEqualThis, NullTypes.StringNT IstruttoreEqualThis,
NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT CodSanzioneVariazioneInvestimentiEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = new PagamentiRichiestiCollection();
            foreach (PagamentiRichiesti PagamentiRichiestiItem in this)
            {
                if (((IdPagamentoRichiestoEqualThis == null) || ((PagamentiRichiestiItem.IdPagamentoRichiesto != null) && (PagamentiRichiestiItem.IdPagamentoRichiesto.Value == IdPagamentoRichiestoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((PagamentiRichiestiItem.IdDomandaPagamento != null) && (PagamentiRichiestiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdInvestimentoEqualThis == null) || ((PagamentiRichiestiItem.IdInvestimento != null) && (PagamentiRichiestiItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) &&
((DataRichiestaPagamentoEqualThis == null) || ((PagamentiRichiestiItem.DataRichiestaPagamento != null) && (PagamentiRichiestiItem.DataRichiestaPagamento.Value == DataRichiestaPagamentoEqualThis.Value))) && ((ImportoComputoMetricoEqualThis == null) || ((PagamentiRichiestiItem.ImportoComputoMetrico != null) && (PagamentiRichiestiItem.ImportoComputoMetrico.Value == ImportoComputoMetricoEqualThis.Value))) && ((ImportoRichiestoEqualThis == null) || ((PagamentiRichiestiItem.ImportoRichiesto != null) && (PagamentiRichiestiItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) &&
((ContributoRichiestoEqualThis == null) || ((PagamentiRichiestiItem.ContributoRichiesto != null) && (PagamentiRichiestiItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && ((ContributoRichiestoAltreFontiEqualThis == null) || ((PagamentiRichiestiItem.ContributoRichiestoAltreFonti != null) && (PagamentiRichiestiItem.ContributoRichiestoAltreFonti.Value == ContributoRichiestoAltreFontiEqualThis.Value))) && ((ImportoDisavanzoCostiAmmessiEqualThis == null) || ((PagamentiRichiestiItem.ImportoDisavanzoCostiAmmessi != null) && (PagamentiRichiestiItem.ImportoDisavanzoCostiAmmessi.Value == ImportoDisavanzoCostiAmmessiEqualThis.Value))) &&
((ContributoDisavanzoCostiAmmessiEqualThis == null) || ((PagamentiRichiestiItem.ContributoDisavanzoCostiAmmessi != null) && (PagamentiRichiestiItem.ContributoDisavanzoCostiAmmessi.Value == ContributoDisavanzoCostiAmmessiEqualThis.Value))) && ((ContributoRichiestoRecuperoAnticipoEqualThis == null) || ((PagamentiRichiestiItem.ContributoRichiestoRecuperoAnticipo != null) && (PagamentiRichiestiItem.ContributoRichiestoRecuperoAnticipo.Value == ContributoRichiestoRecuperoAnticipoEqualThis.Value))) && ((ImportoComputoMetricoAmmessoEqualThis == null) || ((PagamentiRichiestiItem.ImportoComputoMetricoAmmesso != null) && (PagamentiRichiestiItem.ImportoComputoMetricoAmmesso.Value == ImportoComputoMetricoAmmessoEqualThis.Value))) &&
((ImportoAmmessoEqualThis == null) || ((PagamentiRichiestiItem.ImportoAmmesso != null) && (PagamentiRichiestiItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ContributoAmmessoEqualThis == null) || ((PagamentiRichiestiItem.ContributoAmmesso != null) && (PagamentiRichiestiItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && ((ContributoAmmessoAltreFontiEqualThis == null) || ((PagamentiRichiestiItem.ContributoAmmessoAltreFonti != null) && (PagamentiRichiestiItem.ContributoAmmessoAltreFonti.Value == ContributoAmmessoAltreFontiEqualThis.Value))) &&
((ContributoAmmessoRecuperoAnticipoEqualThis == null) || ((PagamentiRichiestiItem.ContributoAmmessoRecuperoAnticipo != null) && (PagamentiRichiestiItem.ContributoAmmessoRecuperoAnticipo.Value == ContributoAmmessoRecuperoAnticipoEqualThis.Value))) && ((AmmessoEqualThis == null) || ((PagamentiRichiestiItem.Ammesso != null) && (PagamentiRichiestiItem.Ammesso.Value == AmmessoEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((PagamentiRichiestiItem.Istruttore != null) && (PagamentiRichiestiItem.Istruttore.Value == IstruttoreEqualThis.Value))) &&
((DataValutazioneEqualThis == null) || ((PagamentiRichiestiItem.DataValutazione != null) && (PagamentiRichiestiItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((CodSanzioneVariazioneInvestimentiEqualThis == null) || ((PagamentiRichiestiItem.CodSanzioneVariazioneInvestimenti != null) && (PagamentiRichiestiItem.CodSanzioneVariazioneInvestimenti.Value == CodSanzioneVariazioneInvestimentiEqualThis.Value))))
                {
                    PagamentiRichiestiCollectionTemp.Add(PagamentiRichiestiItem);
                }
            }
            return PagamentiRichiestiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PagamentiRichiestiCollection FiltroProgetto(NullTypes.IntNT IdProgettoEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = new PagamentiRichiestiCollection();
            foreach (PagamentiRichiesti PagamentiRichiestiItem in this)
            {
                if (((IdProgettoEqualThis == null) || ((PagamentiRichiestiItem.IdProgetto != null) && (PagamentiRichiestiItem.IdProgetto.Value == IdProgettoEqualThis.Value))))
                {
                    PagamentiRichiestiCollectionTemp.Add(PagamentiRichiestiItem);
                }
            }
            return PagamentiRichiestiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PagamentiRichiestiCollection FiltroAmmesso(NullTypes.BoolNT AmmessoEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = new PagamentiRichiestiCollection();
            foreach (PagamentiRichiesti PagamentiRichiestiItem in this)
            {
                if (((AmmessoEqualThis == null) || ((PagamentiRichiestiItem.Ammesso != null) && (PagamentiRichiestiItem.Ammesso.Value == AmmessoEqualThis.Value))))
                {
                    PagamentiRichiestiCollectionTemp.Add(PagamentiRichiestiItem);
                }
            }
            return PagamentiRichiestiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PagamentiRichiestiCollection FiltroDomandaPagamento(NullTypes.IntNT IdDomandaPagamentoEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = new PagamentiRichiestiCollection();
            foreach (PagamentiRichiesti PagamentiRichiestiItem in this)
            {
                if (((IdDomandaPagamentoEqualThis == null) || ((PagamentiRichiestiItem.IdDomandaPagamento != null) && (PagamentiRichiestiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))))
                {
                    PagamentiRichiestiCollectionTemp.Add(PagamentiRichiestiItem);
                }
            }
            return PagamentiRichiestiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PagamentiRichiestiCollection FiltroInvestimento(NullTypes.IntNT IdInvestimentoEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = new PagamentiRichiestiCollection();
            foreach (PagamentiRichiesti PagamentiRichiestiItem in this)
            {
                if (((IdInvestimentoEqualThis == null) || ((PagamentiRichiestiItem.IdInvestimento != null) && (PagamentiRichiestiItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))))
                {
                    PagamentiRichiestiCollectionTemp.Add(PagamentiRichiestiItem);
                }
            }
            return PagamentiRichiestiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for PagamentiRichiestiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class PagamentiRichiestiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PagamentiRichiesti PagamentiRichiestiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdPagamentoRichiesto", PagamentiRichiestiObj.IdPagamentoRichiesto);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdInvestimento", PagamentiRichiestiObj.IdInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRichiestaPagamento", PagamentiRichiestiObj.DataRichiestaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoRichiesto", PagamentiRichiestiObj.ContributoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoAmmesso", PagamentiRichiestiObj.ContributoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "Ammesso", PagamentiRichiestiObj.Ammesso);
            DbProvider.SetCmdParam(cmd, firstChar + "Istruttore", PagamentiRichiestiObj.Istruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataValutazione", PagamentiRichiestiObj.DataValutazione);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoComputoMetrico", PagamentiRichiestiObj.ImportoComputoMetrico);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRichiesto", PagamentiRichiestiObj.ImportoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoAmmesso", PagamentiRichiestiObj.ImportoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", PagamentiRichiestiObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoComputoMetricoAmmesso", PagamentiRichiestiObj.ImportoComputoMetricoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoRichiestoRecuperoAnticipo", PagamentiRichiestiObj.ContributoRichiestoRecuperoAnticipo);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoAmmessoRecuperoAnticipo", PagamentiRichiestiObj.ContributoAmmessoRecuperoAnticipo);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteIstruttore", PagamentiRichiestiObj.NoteIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "CodSanzioneVariazioneInvestimenti", PagamentiRichiestiObj.CodSanzioneVariazioneInvestimenti);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDisavanzoCostiAmmessi", PagamentiRichiestiObj.ImportoDisavanzoCostiAmmessi);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoDisavanzoCostiAmmessi", PagamentiRichiestiObj.ContributoDisavanzoCostiAmmessi);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoRichiestoAltreFonti", PagamentiRichiestiObj.ContributoRichiestoAltreFonti);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoAmmessoAltreFonti", PagamentiRichiestiObj.ContributoAmmessoAltreFonti);
        }
        //Insert
        private static int Insert(DbProvider db, PagamentiRichiesti PagamentiRichiestiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZPagamentiRichiestiInsert", new string[] {"IdInvestimento", "DataRichiestaPagamento", 
"ContributoRichiesto", "ContributoAmmesso", "Ammesso", 
"Istruttore", "DataValutazione", "ImportoComputoMetrico", 
"ImportoRichiesto", "ImportoAmmesso", 
"IdDomandaPagamento", 







"ImportoComputoMetricoAmmesso", "ContributoRichiestoRecuperoAnticipo", 
"ContributoAmmessoRecuperoAnticipo", "NoteIstruttore", "CodSanzioneVariazioneInvestimenti", 
"ImportoDisavanzoCostiAmmessi", "ContributoDisavanzoCostiAmmessi", "ContributoRichiestoAltreFonti", 
"ContributoAmmessoAltreFonti"}, new string[] {"int", "DateTime", 
"decimal", "decimal", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", 
"int", 







"decimal", "decimal", 
"decimal", "string", "string", 
"decimal", "decimal", "decimal", 
"decimal"}, "");
                CompileIUCmd(false, insertCmd, PagamentiRichiestiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    PagamentiRichiestiObj.IdPagamentoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO"]);
                    PagamentiRichiestiObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                }
                PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiObj.IsDirty = false;
                PagamentiRichiestiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, PagamentiRichiesti PagamentiRichiestiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZPagamentiRichiestiUpdate", new string[] {"IdPagamentoRichiesto", "IdInvestimento", "DataRichiestaPagamento", 
"ContributoRichiesto", "ContributoAmmesso", "Ammesso", 
"Istruttore", "DataValutazione", "ImportoComputoMetrico", 
"ImportoRichiesto", "ImportoAmmesso", 
"IdDomandaPagamento", 







"ImportoComputoMetricoAmmesso", "ContributoRichiestoRecuperoAnticipo", 
"ContributoAmmessoRecuperoAnticipo", "NoteIstruttore", "CodSanzioneVariazioneInvestimenti", 
"ImportoDisavanzoCostiAmmessi", "ContributoDisavanzoCostiAmmessi", "ContributoRichiestoAltreFonti", 
"ContributoAmmessoAltreFonti"}, new string[] {"int", "int", "DateTime", 
"decimal", "decimal", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", 
"int", 







"decimal", "decimal", 
"decimal", "string", "string", 
"decimal", "decimal", "decimal", 
"decimal"}, "");
                CompileIUCmd(true, updateCmd, PagamentiRichiestiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiObj.IsDirty = false;
                PagamentiRichiestiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, PagamentiRichiesti PagamentiRichiestiObj)
        {
            switch (PagamentiRichiestiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, PagamentiRichiestiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, PagamentiRichiestiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, PagamentiRichiestiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, PagamentiRichiestiCollection PagamentiRichiestiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZPagamentiRichiestiUpdate", new string[] {"IdPagamentoRichiesto", "IdInvestimento", "DataRichiestaPagamento", 
"ContributoRichiesto", "ContributoAmmesso", "Ammesso", 
"Istruttore", "DataValutazione", "ImportoComputoMetrico", 
"ImportoRichiesto", "ImportoAmmesso", 
"IdDomandaPagamento", 







"ImportoComputoMetricoAmmesso", "ContributoRichiestoRecuperoAnticipo", 
"ContributoAmmessoRecuperoAnticipo", "NoteIstruttore", "CodSanzioneVariazioneInvestimenti", 
"ImportoDisavanzoCostiAmmessi", "ContributoDisavanzoCostiAmmessi", "ContributoRichiestoAltreFonti", 
"ContributoAmmessoAltreFonti"}, new string[] {"int", "int", "DateTime", 
"decimal", "decimal", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", 
"int", 







"decimal", "decimal", 
"decimal", "string", "string", 
"decimal", "decimal", "decimal", 
"decimal"}, "");
                IDbCommand insertCmd = db.InitCmd("ZPagamentiRichiestiInsert", new string[] {"IdInvestimento", "DataRichiestaPagamento", 
"ContributoRichiesto", "ContributoAmmesso", "Ammesso", 
"Istruttore", "DataValutazione", "ImportoComputoMetrico", 
"ImportoRichiesto", "ImportoAmmesso", 
"IdDomandaPagamento", 







"ImportoComputoMetricoAmmesso", "ContributoRichiestoRecuperoAnticipo", 
"ContributoAmmessoRecuperoAnticipo", "NoteIstruttore", "CodSanzioneVariazioneInvestimenti", 
"ImportoDisavanzoCostiAmmessi", "ContributoDisavanzoCostiAmmessi", "ContributoRichiestoAltreFonti", 
"ContributoAmmessoAltreFonti"}, new string[] {"int", "DateTime", 
"decimal", "decimal", "bool", 
"string", "DateTime", "decimal", 
"decimal", "decimal", 
"int", 







"decimal", "decimal", 
"decimal", "string", "string", 
"decimal", "decimal", "decimal", 
"decimal"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZPagamentiRichiestiDelete", new string[] { "IdPagamentoRichiesto" }, new string[] { "int" }, "");
                for (int i = 0; i < PagamentiRichiestiCollectionObj.Count; i++)
                {
                    switch (PagamentiRichiestiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, PagamentiRichiestiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    PagamentiRichiestiCollectionObj[i].IdPagamentoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO"]);
                                    PagamentiRichiestiCollectionObj[i].Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, PagamentiRichiestiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (PagamentiRichiestiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdPagamentoRichiesto", (SiarLibrary.NullTypes.IntNT)PagamentiRichiestiCollectionObj[i].IdPagamentoRichiesto);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < PagamentiRichiestiCollectionObj.Count; i++)
                {
                    if ((PagamentiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        PagamentiRichiestiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        PagamentiRichiestiCollectionObj[i].IsDirty = false;
                        PagamentiRichiestiCollectionObj[i].IsPersistent = true;
                    }
                    if ((PagamentiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        PagamentiRichiestiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        PagamentiRichiestiCollectionObj[i].IsDirty = false;
                        PagamentiRichiestiCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //Delete
        public static int Delete(DbProvider db, PagamentiRichiesti PagamentiRichiestiObj)
        {
            int returnValue = 0;
            if (PagamentiRichiestiObj.IsPersistent)
            {
                returnValue = Delete(db, PagamentiRichiestiObj.IdPagamentoRichiesto);
            }
            PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            PagamentiRichiestiObj.IsDirty = false;
            PagamentiRichiestiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdPagamentoRichiestoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZPagamentiRichiestiDelete", new string[] { "IdPagamentoRichiesto" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdPagamentoRichiesto", (SiarLibrary.NullTypes.IntNT)IdPagamentoRichiestoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, PagamentiRichiestiCollection PagamentiRichiestiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZPagamentiRichiestiDelete", new string[] { "IdPagamentoRichiesto" }, new string[] { "int" }, "");
                for (int i = 0; i < PagamentiRichiestiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdPagamentoRichiesto", PagamentiRichiestiCollectionObj[i].IdPagamentoRichiesto);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < PagamentiRichiestiCollectionObj.Count; i++)
                {
                    if ((PagamentiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PagamentiRichiestiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        PagamentiRichiestiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        PagamentiRichiestiCollectionObj[i].IsDirty = false;
                        PagamentiRichiestiCollectionObj[i].IsPersistent = false;
                    }
                }
            }
            catch
            {
                db.Rollback();
                throw;
            }
            finally
            {
                db.Close();
            }
            return returnValue;
        }

        //getById
        public static PagamentiRichiesti GetById(DbProvider db, int IdPagamentoRichiestoValue)
        {
            PagamentiRichiesti PagamentiRichiestiObj = null;
            IDbCommand readCmd = db.InitCmd("ZPagamentiRichiestiGetById", new string[] { "IdPagamentoRichiesto" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdPagamentoRichiesto", (SiarLibrary.NullTypes.IntNT)IdPagamentoRichiestoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                PagamentiRichiestiObj = GetFromDatareader(db);
                PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiObj.IsDirty = false;
                PagamentiRichiestiObj.IsPersistent = true;
            }
            db.Close();
            return PagamentiRichiestiObj;
        }

        //getFromDatareader
        public static PagamentiRichiesti GetFromDatareader(DbProvider db)
        {
            PagamentiRichiesti PagamentiRichiestiObj = new PagamentiRichiesti();
            PagamentiRichiestiObj.IdPagamentoRichiesto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PAGAMENTO_RICHIESTO"]);
            PagamentiRichiestiObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
            PagamentiRichiestiObj.DataRichiestaPagamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA_PAGAMENTO"]);
            PagamentiRichiestiObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
            PagamentiRichiestiObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
            PagamentiRichiestiObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
            PagamentiRichiestiObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            PagamentiRichiestiObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
            PagamentiRichiestiObj.ImportoComputoMetrico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_COMPUTO_METRICO"]);
            PagamentiRichiestiObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
            PagamentiRichiestiObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
            PagamentiRichiestiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            PagamentiRichiestiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            PagamentiRichiestiObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
            PagamentiRichiestiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            PagamentiRichiestiObj.DataVariazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VARIAZIONE"]);
            PagamentiRichiestiObj.OperatoreVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_VARIAZIONE"]);
            PagamentiRichiestiObj.CodTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_INVESTIMENTO"]);
            PagamentiRichiestiObj.CodStp = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STP"]);
            PagamentiRichiestiObj.IdUnitaMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UNITA_MISURA"]);
            PagamentiRichiestiObj.Quantita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUANTITA"]);
            PagamentiRichiestiObj.CostoInvestimento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
            PagamentiRichiestiObj.SpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_GENERALI"]);
            PagamentiRichiestiObj.ContributoRichiestoInvestimento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO_INVESTIMENTO"]);
            PagamentiRichiestiObj.QuotaContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_RICHIESTO"]);
            PagamentiRichiestiObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
            PagamentiRichiestiObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
            PagamentiRichiestiObj.IdObiettivoMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO_MISURA"]);
            PagamentiRichiestiObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
            PagamentiRichiestiObj.IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
            PagamentiRichiestiObj.IdSpecificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPECIFICA_INVESTIMENTO"]);
            PagamentiRichiestiObj.InvestimentoAmmesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INVESTIMENTO_AMMESSO"]);
            PagamentiRichiestiObj.IstruttoreInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE_INVESTIMENTO"]);
            PagamentiRichiestiObj.IdInvestimentoOriginale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_ORIGINALE"]);
            PagamentiRichiestiObj.DataValutazioneInvestimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE_INVESTIMENTO"]);
            PagamentiRichiestiObj.ValutazioneInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_INVESTIMENTO"]);
            PagamentiRichiestiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            PagamentiRichiestiObj.ImportoComputoMetricoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_COMPUTO_METRICO_AMMESSO"]);
            PagamentiRichiestiObj.ContributoRichiestoRecuperoAnticipo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO"]);
            PagamentiRichiestiObj.ContributoAmmessoRecuperoAnticipo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO"]);
            PagamentiRichiestiObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
            PagamentiRichiestiObj.CodSanzioneVariazioneInvestimenti = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SANZIONE_VARIAZIONE_INVESTIMENTI"]);
            PagamentiRichiestiObj.ImportoDisavanzoCostiAmmessi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DISAVANZO_COSTI_AMMESSI"]);
            PagamentiRichiestiObj.ContributoDisavanzoCostiAmmessi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_DISAVANZO_COSTI_AMMESSI"]);
            PagamentiRichiestiObj.ContributoRichiestoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO_ALTRE_FONTI"]);
            PagamentiRichiestiObj.ContributoAmmessoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_ALTRE_FONTI"]);
            PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            PagamentiRichiestiObj.IsDirty = false;
            PagamentiRichiestiObj.IsPersistent = true;
            return PagamentiRichiestiObj;
        }

        //Find Select

        public static PagamentiRichiestiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataRichiestaPagamentoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoComputoMetricoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoAltreFontiEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDisavanzoCostiAmmessiEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoDisavanzoCostiAmmessiEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoRecuperoAnticipoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoComputoMetricoAmmessoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoAltreFontiEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoAmmessoRecuperoAnticipoEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis, SiarLibrary.NullTypes.StringNT CodSanzioneVariazioneInvestimentiEqualThis)
        {

            PagamentiRichiestiCollection PagamentiRichiestiCollectionObj = new PagamentiRichiestiCollection();

            IDbCommand findCmd = db.InitCmd("Zpagamentirichiestifindselect", new string[] {"IdPagamentoRichiestoequalthis", "IdDomandaPagamentoequalthis", "IdInvestimentoequalthis", 
"DataRichiestaPagamentoequalthis", "ImportoComputoMetricoequalthis", "ImportoRichiestoequalthis", 
"ContributoRichiestoequalthis", "ContributoRichiestoAltreFontiequalthis", "ImportoDisavanzoCostiAmmessiequalthis", 
"ContributoDisavanzoCostiAmmessiequalthis", "ContributoRichiestoRecuperoAnticipoequalthis", "ImportoComputoMetricoAmmessoequalthis", 
"ImportoAmmessoequalthis", "ContributoAmmessoequalthis", "ContributoAmmessoAltreFontiequalthis", 
"ContributoAmmessoRecuperoAnticipoequalthis", "Ammessoequalthis", "Istruttoreequalthis", 
"DataValutazioneequalthis", "CodSanzioneVariazioneInvestimentiequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "bool", "string", 
"DateTime", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRichiestaPagamentoequalthis", DataRichiestaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoComputoMetricoequalthis", ImportoComputoMetricoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoRichiestoAltreFontiequalthis", ContributoRichiestoAltreFontiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDisavanzoCostiAmmessiequalthis", ImportoDisavanzoCostiAmmessiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoDisavanzoCostiAmmessiequalthis", ContributoDisavanzoCostiAmmessiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoRichiestoRecuperoAnticipoequalthis", ContributoRichiestoRecuperoAnticipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoComputoMetricoAmmessoequalthis", ImportoComputoMetricoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoAltreFontiequalthis", ContributoAmmessoAltreFontiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoRecuperoAnticipoequalthis", ContributoAmmessoRecuperoAnticipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodSanzioneVariazioneInvestimentiequalthis", CodSanzioneVariazioneInvestimentiEqualThis);
            PagamentiRichiesti PagamentiRichiestiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                PagamentiRichiestiObj = GetFromDatareader(db);
                PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiObj.IsDirty = false;
                PagamentiRichiestiObj.IsPersistent = true;
                PagamentiRichiestiCollectionObj.Add(PagamentiRichiestiObj);
            }
            db.Close();
            return PagamentiRichiestiCollectionObj;
        }

        //Find Find

        public static PagamentiRichiestiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdPagamentoRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis)
        {

            PagamentiRichiestiCollection PagamentiRichiestiCollectionObj = new PagamentiRichiestiCollection();

            IDbCommand findCmd = db.InitCmd("Zpagamentirichiestifindfind", new string[] {"IdPagamentoRichiestoequalthis", "IdInvestimentoequalthis", "IdProgettoequalthis", 
"IdDomandaPagamentoequalthis"}, new string[] {"int", "int", "int", 
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPagamentoRichiestoequalthis", IdPagamentoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            PagamentiRichiesti PagamentiRichiestiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                PagamentiRichiestiObj = GetFromDatareader(db);
                PagamentiRichiestiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PagamentiRichiestiObj.IsDirty = false;
                PagamentiRichiestiObj.IsPersistent = true;
                PagamentiRichiestiCollectionObj.Add(PagamentiRichiestiObj);
            }
            db.Close();
            return PagamentiRichiestiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for PagamentiRichiestiCollectionProvider:IPagamentiRichiestiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class PagamentiRichiestiCollectionProvider : IPagamentiRichiestiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di PagamentiRichiesti
        protected PagamentiRichiestiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public PagamentiRichiestiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new PagamentiRichiestiCollection(this);
        }

        //Costruttore 2: popola la collection
        public PagamentiRichiestiCollectionProvider(IntNT IdpagamentorichiestoEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IddomandapagamentoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdpagamentorichiestoEqualThis, IdinvestimentoEqualThis, IdprogettoEqualThis,
IddomandapagamentoEqualThis);
        }

        //Costruttore3: ha in input pagamentirichiestiCollectionObj - non popola la collection
        public PagamentiRichiestiCollectionProvider(PagamentiRichiestiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public PagamentiRichiestiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new PagamentiRichiestiCollection(this);
        }

        //Get e Set
        public PagamentiRichiestiCollection CollectionObj
        {
            get
            {
                return _CollectionObj;
            }
            set
            {
                _CollectionObj = value;
            }
        }

        public DbProvider DbProviderObj
        {
            get
            {
                return _dbProviderObj;
            }
            set
            {
                _dbProviderObj = value;
            }
        }

        //Operazioni

        //Save1: registra l'intera collection
        public int SaveCollection()
        {
            return SaveCollection(_CollectionObj);
        }

        //Save2: registra una collection
        public int SaveCollection(PagamentiRichiestiCollection collectionObj)
        {
            return PagamentiRichiestiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(PagamentiRichiesti pagamentirichiestiObj)
        {
            return PagamentiRichiestiDAL.Save(_dbProviderObj, pagamentirichiestiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(PagamentiRichiestiCollection collectionObj)
        {
            return PagamentiRichiestiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(PagamentiRichiesti pagamentirichiestiObj)
        {
            return PagamentiRichiestiDAL.Delete(_dbProviderObj, pagamentirichiestiObj);
        }

        //getById
        public PagamentiRichiesti GetById(IntNT IdPagamentoRichiestoValue)
        {
            PagamentiRichiesti PagamentiRichiestiTemp = PagamentiRichiestiDAL.GetById(_dbProviderObj, IdPagamentoRichiestoValue);
            if (PagamentiRichiestiTemp != null) PagamentiRichiestiTemp.Provider = this;
            return PagamentiRichiestiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public PagamentiRichiestiCollection Select(IntNT IdpagamentorichiestoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdinvestimentoEqualThis,
DatetimeNT DatarichiestapagamentoEqualThis, DecimalNT ImportocomputometricoEqualThis, DecimalNT ImportorichiestoEqualThis,
DecimalNT ContributorichiestoEqualThis, DecimalNT ContributorichiestoaltrefontiEqualThis, DecimalNT ImportodisavanzocostiammessiEqualThis,
DecimalNT ContributodisavanzocostiammessiEqualThis, DecimalNT ContributorichiestorecuperoanticipoEqualThis, DecimalNT ImportocomputometricoammessoEqualThis,
DecimalNT ImportoammessoEqualThis, DecimalNT ContributoammessoEqualThis, DecimalNT ContributoammessoaltrefontiEqualThis,
DecimalNT ContributoammessorecuperoanticipoEqualThis, BoolNT AmmessoEqualThis, StringNT IstruttoreEqualThis,
DatetimeNT DatavalutazioneEqualThis, StringNT CodsanzionevariazioneinvestimentiEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = PagamentiRichiestiDAL.Select(_dbProviderObj, IdpagamentorichiestoEqualThis, IddomandapagamentoEqualThis, IdinvestimentoEqualThis,
DatarichiestapagamentoEqualThis, ImportocomputometricoEqualThis, ImportorichiestoEqualThis,
ContributorichiestoEqualThis, ContributorichiestoaltrefontiEqualThis, ImportodisavanzocostiammessiEqualThis,
ContributodisavanzocostiammessiEqualThis, ContributorichiestorecuperoanticipoEqualThis, ImportocomputometricoammessoEqualThis,
ImportoammessoEqualThis, ContributoammessoEqualThis, ContributoammessoaltrefontiEqualThis,
ContributoammessorecuperoanticipoEqualThis, AmmessoEqualThis, IstruttoreEqualThis,
DatavalutazioneEqualThis, CodsanzionevariazioneinvestimentiEqualThis);
            PagamentiRichiestiCollectionTemp.Provider = this;
            return PagamentiRichiestiCollectionTemp;
        }

        //Find: popola la collection
        public PagamentiRichiestiCollection Find(IntNT IdpagamentorichiestoEqualThis, IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IddomandapagamentoEqualThis)
        {
            PagamentiRichiestiCollection PagamentiRichiestiCollectionTemp = PagamentiRichiestiDAL.Find(_dbProviderObj, IdpagamentorichiestoEqualThis, IdinvestimentoEqualThis, IdprogettoEqualThis,
IddomandapagamentoEqualThis);
            PagamentiRichiestiCollectionTemp.Provider = this;
            return PagamentiRichiestiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PAGAMENTI_RICHIESTI>
  <ViewName>vPAGAMENTI_RICHIESTI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_DOMANDA_PAGAMENTO, DATA_RICHIESTA_PAGAMENTO">
      <ID_PAGAMENTO_RICHIESTO>Equal</ID_PAGAMENTO_RICHIESTO>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProgetto>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </FiltroProgetto>
    <FiltroAmmesso>
      <AMMESSO>Equal</AMMESSO>
    </FiltroAmmesso>
    <FiltroDomandaPagamento>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </FiltroDomandaPagamento>
    <FiltroInvestimento>
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
    </FiltroInvestimento>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PAGAMENTI_RICHIESTI>
*/
