using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per PianoInvestimenti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IPianoInvestimentiProvider
    {
        int Save(PianoInvestimenti PianoInvestimentiObj);
        int SaveCollection(PianoInvestimentiCollection collectionObj);
        int Delete(PianoInvestimenti PianoInvestimentiObj);
        int DeleteCollection(PianoInvestimentiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for PianoInvestimenti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class PianoInvestimenti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdInvestimento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdProgrammazione;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.DatetimeNT _DataVariazione;
        private NullTypes.StringNT _OperatoreVariazione;
        private NullTypes.StringNT _CodStp;
        private NullTypes.IntNT _IdUnitaMisura;
        private NullTypes.DecimalNT _Quantita;
        private NullTypes.DecimalNT _CostoInvestimento;
        private NullTypes.DecimalNT _SpeseGenerali;
        private NullTypes.DecimalNT _ContributoRichiesto;
        private NullTypes.DecimalNT _QuotaContributoRichiesto;
        private NullTypes.IntNT _IdSettoreProduttivo;
        private NullTypes.IntNT _IdPrioritaSettoriale;
        private NullTypes.IntNT _IdObiettivoMisura;
        private NullTypes.BoolNT _Ammesso;
        private NullTypes.StringNT _Istruttore;
        private NullTypes.IntNT _IdInvestimentoOriginale;
        private NullTypes.DatetimeNT _DataValutazione;
        private NullTypes.IntNT _IdCodificaInvestimento;
        private NullTypes.IntNT _IdDettaglioInvestimento;
        private NullTypes.IntNT _IdSpecificaInvestimento;
        private NullTypes.StringNT _CodTp;
        private NullTypes.StringNT _CodificaInvestimento;
        private NullTypes.DecimalNT _AiutoMinimo;
        private NullTypes.StringNT _Codice;
        private NullTypes.StringNT _CodSpecifica;
        private NullTypes.StringNT _SpecificaInvestimenti;
        private NullTypes.StringNT _DettaglioInvestimenti;
        private NullTypes.BoolNT _Mobile;
        private NullTypes.DecimalNT _QuotaSpeseGenerali;
        private NullTypes.StringNT _SettoreProduttivo;
        private NullTypes.IntNT _CodTipoInvestimento;
        private NullTypes.BoolNT _RichiediParticella;
        private NullTypes.StringNT _ValutazioneInvestimento;
        private NullTypes.IntNT _IdVariante;
        private NullTypes.StringNT _CodVariazione;
        private NullTypes.DecimalNT _TassoAbbuono;
        private NullTypes.StringNT _Misura;
        private NullTypes.IntNT _IdMisura;
        private NullTypes.BoolNT _NonCofinanziato;
        private NullTypes.BoolNT _IsMax;
        private NullTypes.DecimalNT _ContributoAltreFonti;
        private NullTypes.DecimalNT _QuotaContributoAltreFonti;
        private NullTypes.IntNT _IdImpresaAggregazione;
        [NonSerialized] private IPianoInvestimentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IPianoInvestimentiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public PianoInvestimenti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:CONTRIBUTO_RICHIESTO
        /// Tipo sul db:DECIMAL(15,2)
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
        /// Corrisponde al campo:QUOTA_CONTRIBUTO_RICHIESTO
        /// Tipo sul db:DECIMAL(15,12)
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
        /// Corrisponde al campo:AMMESSO
        /// Tipo sul db:BIT
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
        /// Corrisponde al campo:COD_TP
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodTp
        {
            get { return _CodTp; }
            set
            {
                if (CodTp != value)
                {
                    _CodTp = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODIFICA_INVESTIMENTO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT CodificaInvestimento
        {
            get { return _CodificaInvestimento; }
            set
            {
                if (CodificaInvestimento != value)
                {
                    _CodificaInvestimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AIUTO_MINIMO
        /// Tipo sul db:DECIMAL(15,12)
        /// </summary>
        public NullTypes.DecimalNT AiutoMinimo
        {
            get { return _AiutoMinimo; }
            set
            {
                if (AiutoMinimo != value)
                {
                    _AiutoMinimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT Codice
        {
            get { return _Codice; }
            set
            {
                if (Codice != value)
                {
                    _Codice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_SPECIFICA
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodSpecifica
        {
            get { return _CodSpecifica; }
            set
            {
                if (CodSpecifica != value)
                {
                    _CodSpecifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPECIFICA_INVESTIMENTI
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT SpecificaInvestimenti
        {
            get { return _SpecificaInvestimenti; }
            set
            {
                if (SpecificaInvestimenti != value)
                {
                    _SpecificaInvestimenti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DETTAGLIO_INVESTIMENTI
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DettaglioInvestimenti
        {
            get { return _DettaglioInvestimenti; }
            set
            {
                if (DettaglioInvestimenti != value)
                {
                    _DettaglioInvestimenti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MOBILE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Mobile
        {
            get { return _Mobile; }
            set
            {
                if (Mobile != value)
                {
                    _Mobile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUOTA_SPESE_GENERALI
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT QuotaSpeseGenerali
        {
            get { return _QuotaSpeseGenerali; }
            set
            {
                if (QuotaSpeseGenerali != value)
                {
                    _QuotaSpeseGenerali = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SETTORE_PRODUTTIVO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT SettoreProduttivo
        {
            get { return _SettoreProduttivo; }
            set
            {
                if (SettoreProduttivo != value)
                {
                    _SettoreProduttivo = value;
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
        /// Corrisponde al campo:RICHIEDI_PARTICELLA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT RichiediParticella
        {
            get { return _RichiediParticella; }
            set
            {
                if (RichiediParticella != value)
                {
                    _RichiediParticella = value;
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
        /// Corrisponde al campo:COD_VARIAZIONE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodVariazione
        {
            get { return _CodVariazione; }
            set
            {
                if (CodVariazione != value)
                {
                    _CodVariazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TASSO_ABBUONO
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT TassoAbbuono
        {
            get { return _TassoAbbuono; }
            set
            {
                if (TassoAbbuono != value)
                {
                    _TassoAbbuono = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MISURA
        /// Tipo sul db:VARCHAR(71)
        /// </summary>
        public NullTypes.StringNT Misura
        {
            get { return _Misura; }
            set
            {
                if (Misura != value)
                {
                    _Misura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_MISURA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdMisura
        {
            get { return _IdMisura; }
            set
            {
                if (IdMisura != value)
                {
                    _IdMisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NON_COFINANZIATO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT NonCofinanziato
        {
            get { return _NonCofinanziato; }
            set
            {
                if (NonCofinanziato != value)
                {
                    _NonCofinanziato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IS_MAX
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT IsMax
        {
            get { return _IsMax; }
            set
            {
                if (IsMax != value)
                {
                    _IsMax = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_ALTRE_FONTI
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAltreFonti
        {
            get { return _ContributoAltreFonti; }
            set
            {
                if (ContributoAltreFonti != value)
                {
                    _ContributoAltreFonti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUOTA_CONTRIBUTO_ALTRE_FONTI
        /// Tipo sul db:DECIMAL(15,12)
        /// </summary>
        public NullTypes.DecimalNT QuotaContributoAltreFonti
        {
            get { return _QuotaContributoAltreFonti; }
            set
            {
                if (QuotaContributoAltreFonti != value)
                {
                    _QuotaContributoAltreFonti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_IMPRESA_AGGREGAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresaAggregazione
        {
            get { return _IdImpresaAggregazione; }
            set
            {
                if (IdImpresaAggregazione != value)
                {
                    _IdImpresaAggregazione = value;
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
    /// Summary description for PianoInvestimentiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class PianoInvestimentiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private PianoInvestimentiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((PianoInvestimenti)info.GetValue(i.ToString(), typeof(PianoInvestimenti)));
            }
        }

        //Costruttore
        public PianoInvestimentiCollection()
        {
            this.ItemType = typeof(PianoInvestimenti);
        }

        //Costruttore con provider
        public PianoInvestimentiCollection(IPianoInvestimentiProvider providerObj)
        {
            this.ItemType = typeof(PianoInvestimenti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new PianoInvestimenti this[int index]
        {
            get { return (PianoInvestimenti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new PianoInvestimentiCollection GetChanges()
        {
            return (PianoInvestimentiCollection)base.GetChanges();
        }

        [NonSerialized] private IPianoInvestimentiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IPianoInvestimentiProvider Provider
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
        public int Add(PianoInvestimenti PianoInvestimentiObj)
        {
            if (PianoInvestimentiObj.Provider == null) PianoInvestimentiObj.Provider = this.Provider;
            return base.Add(PianoInvestimentiObj);
        }

        //AddCollection
        public void AddCollection(PianoInvestimentiCollection PianoInvestimentiCollectionObj)
        {
            foreach (PianoInvestimenti PianoInvestimentiObj in PianoInvestimentiCollectionObj)
                this.Add(PianoInvestimentiObj);
        }

        //Insert
        public void Insert(int index, PianoInvestimenti PianoInvestimentiObj)
        {
            if (PianoInvestimentiObj.Provider == null) PianoInvestimentiObj.Provider = this.Provider;
            base.Insert(index, PianoInvestimentiObj);
        }

        //CollectionGetById
        public PianoInvestimenti CollectionGetById(NullTypes.IntNT IdInvestimentoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdInvestimento == IdInvestimentoValue))
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
        public PianoInvestimentiCollection SubSelect(NullTypes.IntNT IdInvestimentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.DatetimeNT DataVariazioneEqualThis, NullTypes.StringNT OperatoreVariazioneEqualThis,
NullTypes.IntNT CodTipoInvestimentoEqualThis, NullTypes.StringNT CodStpEqualThis, NullTypes.IntNT IdUnitaMisuraEqualThis,
NullTypes.DecimalNT QuantitaEqualThis, NullTypes.DecimalNT CostoInvestimentoEqualThis, NullTypes.DecimalNT SpeseGeneraliEqualThis,
NullTypes.DecimalNT ContributoRichiestoEqualThis, NullTypes.DecimalNT QuotaContributoRichiestoEqualThis, NullTypes.DecimalNT ContributoAltreFontiEqualThis,
NullTypes.DecimalNT QuotaContributoAltreFontiEqualThis, NullTypes.DecimalNT TassoAbbuonoEqualThis, NullTypes.IntNT IdSettoreProduttivoEqualThis,
NullTypes.IntNT IdPrioritaSettorialeEqualThis, NullTypes.IntNT IdObiettivoMisuraEqualThis, NullTypes.IntNT IdCodificaInvestimentoEqualThis,
NullTypes.IntNT IdDettaglioInvestimentoEqualThis, NullTypes.IntNT IdSpecificaInvestimentoEqualThis, NullTypes.BoolNT AmmessoEqualThis,
NullTypes.StringNT IstruttoreEqualThis, NullTypes.IntNT IdInvestimentoOriginaleEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis,
NullTypes.IntNT IdVarianteEqualThis, NullTypes.StringNT CodVariazioneEqualThis, NullTypes.BoolNT NonCofinanziatoEqualThis,
NullTypes.IntNT IdImpresaAggregazioneEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = new PianoInvestimentiCollection();
            foreach (PianoInvestimenti PianoInvestimentiItem in this)
            {
                if (((IdInvestimentoEqualThis == null) || ((PianoInvestimentiItem.IdInvestimento != null) && (PianoInvestimentiItem.IdInvestimento.Value == IdInvestimentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((PianoInvestimentiItem.IdProgetto != null) && (PianoInvestimentiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((PianoInvestimentiItem.IdProgrammazione != null) && (PianoInvestimentiItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((PianoInvestimentiItem.Descrizione != null) && (PianoInvestimentiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((DataVariazioneEqualThis == null) || ((PianoInvestimentiItem.DataVariazione != null) && (PianoInvestimentiItem.DataVariazione.Value == DataVariazioneEqualThis.Value))) && ((OperatoreVariazioneEqualThis == null) || ((PianoInvestimentiItem.OperatoreVariazione != null) && (PianoInvestimentiItem.OperatoreVariazione.Value == OperatoreVariazioneEqualThis.Value))) &&
((CodTipoInvestimentoEqualThis == null) || ((PianoInvestimentiItem.CodTipoInvestimento != null) && (PianoInvestimentiItem.CodTipoInvestimento.Value == CodTipoInvestimentoEqualThis.Value))) && ((CodStpEqualThis == null) || ((PianoInvestimentiItem.CodStp != null) && (PianoInvestimentiItem.CodStp.Value == CodStpEqualThis.Value))) && ((IdUnitaMisuraEqualThis == null) || ((PianoInvestimentiItem.IdUnitaMisura != null) && (PianoInvestimentiItem.IdUnitaMisura.Value == IdUnitaMisuraEqualThis.Value))) &&
((QuantitaEqualThis == null) || ((PianoInvestimentiItem.Quantita != null) && (PianoInvestimentiItem.Quantita.Value == QuantitaEqualThis.Value))) && ((CostoInvestimentoEqualThis == null) || ((PianoInvestimentiItem.CostoInvestimento != null) && (PianoInvestimentiItem.CostoInvestimento.Value == CostoInvestimentoEqualThis.Value))) && ((SpeseGeneraliEqualThis == null) || ((PianoInvestimentiItem.SpeseGenerali != null) && (PianoInvestimentiItem.SpeseGenerali.Value == SpeseGeneraliEqualThis.Value))) &&
((ContributoRichiestoEqualThis == null) || ((PianoInvestimentiItem.ContributoRichiesto != null) && (PianoInvestimentiItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && ((QuotaContributoRichiestoEqualThis == null) || ((PianoInvestimentiItem.QuotaContributoRichiesto != null) && (PianoInvestimentiItem.QuotaContributoRichiesto.Value == QuotaContributoRichiestoEqualThis.Value))) && ((ContributoAltreFontiEqualThis == null) || ((PianoInvestimentiItem.ContributoAltreFonti != null) && (PianoInvestimentiItem.ContributoAltreFonti.Value == ContributoAltreFontiEqualThis.Value))) &&
((QuotaContributoAltreFontiEqualThis == null) || ((PianoInvestimentiItem.QuotaContributoAltreFonti != null) && (PianoInvestimentiItem.QuotaContributoAltreFonti.Value == QuotaContributoAltreFontiEqualThis.Value))) && ((TassoAbbuonoEqualThis == null) || ((PianoInvestimentiItem.TassoAbbuono != null) && (PianoInvestimentiItem.TassoAbbuono.Value == TassoAbbuonoEqualThis.Value))) && ((IdSettoreProduttivoEqualThis == null) || ((PianoInvestimentiItem.IdSettoreProduttivo != null) && (PianoInvestimentiItem.IdSettoreProduttivo.Value == IdSettoreProduttivoEqualThis.Value))) &&
((IdPrioritaSettorialeEqualThis == null) || ((PianoInvestimentiItem.IdPrioritaSettoriale != null) && (PianoInvestimentiItem.IdPrioritaSettoriale.Value == IdPrioritaSettorialeEqualThis.Value))) && ((IdObiettivoMisuraEqualThis == null) || ((PianoInvestimentiItem.IdObiettivoMisura != null) && (PianoInvestimentiItem.IdObiettivoMisura.Value == IdObiettivoMisuraEqualThis.Value))) && ((IdCodificaInvestimentoEqualThis == null) || ((PianoInvestimentiItem.IdCodificaInvestimento != null) && (PianoInvestimentiItem.IdCodificaInvestimento.Value == IdCodificaInvestimentoEqualThis.Value))) &&
((IdDettaglioInvestimentoEqualThis == null) || ((PianoInvestimentiItem.IdDettaglioInvestimento != null) && (PianoInvestimentiItem.IdDettaglioInvestimento.Value == IdDettaglioInvestimentoEqualThis.Value))) && ((IdSpecificaInvestimentoEqualThis == null) || ((PianoInvestimentiItem.IdSpecificaInvestimento != null) && (PianoInvestimentiItem.IdSpecificaInvestimento.Value == IdSpecificaInvestimentoEqualThis.Value))) && ((AmmessoEqualThis == null) || ((PianoInvestimentiItem.Ammesso != null) && (PianoInvestimentiItem.Ammesso.Value == AmmessoEqualThis.Value))) &&
((IstruttoreEqualThis == null) || ((PianoInvestimentiItem.Istruttore != null) && (PianoInvestimentiItem.Istruttore.Value == IstruttoreEqualThis.Value))) && ((IdInvestimentoOriginaleEqualThis == null) || ((PianoInvestimentiItem.IdInvestimentoOriginale != null) && (PianoInvestimentiItem.IdInvestimentoOriginale.Value == IdInvestimentoOriginaleEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((PianoInvestimentiItem.DataValutazione != null) && (PianoInvestimentiItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) &&
((IdVarianteEqualThis == null) || ((PianoInvestimentiItem.IdVariante != null) && (PianoInvestimentiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((CodVariazioneEqualThis == null) || ((PianoInvestimentiItem.CodVariazione != null) && (PianoInvestimentiItem.CodVariazione.Value == CodVariazioneEqualThis.Value))) && ((NonCofinanziatoEqualThis == null) || ((PianoInvestimentiItem.NonCofinanziato != null) && (PianoInvestimentiItem.NonCofinanziato.Value == NonCofinanziatoEqualThis.Value))) &&
((IdImpresaAggregazioneEqualThis == null) || ((PianoInvestimentiItem.IdImpresaAggregazione != null) && (PianoInvestimentiItem.IdImpresaAggregazione.Value == IdImpresaAggregazioneEqualThis.Value))))
                {
                    PianoInvestimentiCollectionTemp.Add(PianoInvestimentiItem);
                }
            }
            return PianoInvestimentiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PianoInvestimentiCollection FiltroProgettoCorrelato(NullTypes.IntNT IdProgettoEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = new PianoInvestimentiCollection();
            foreach (PianoInvestimenti PianoInvestimentiItem in this)
            {
                if (((IdProgettoEqualThis == null) || ((PianoInvestimentiItem.IdProgetto != null) && (PianoInvestimentiItem.IdProgetto.Value == IdProgettoEqualThis.Value))))
                {
                    PianoInvestimentiCollectionTemp.Add(PianoInvestimentiItem);
                }
            }
            return PianoInvestimentiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PianoInvestimentiCollection FiltroInvestimentoOriginale(NullTypes.BoolNT IdInvestimentoOriginaleIsNull)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = new PianoInvestimentiCollection();
            foreach (PianoInvestimenti PianoInvestimentiItem in this)
            {
                if (((IdInvestimentoOriginaleIsNull == null) || ((PianoInvestimentiItem.IdInvestimentoOriginale == null) == IdInvestimentoOriginaleIsNull.Value)))
                {
                    PianoInvestimentiCollectionTemp.Add(PianoInvestimentiItem);
                }
            }
            return PianoInvestimentiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PianoInvestimentiCollection FiltroTipoInvestimento(NullTypes.IntNT CodTipoInvestimentoEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = new PianoInvestimentiCollection();
            foreach (PianoInvestimenti PianoInvestimentiItem in this)
            {
                if (((CodTipoInvestimentoEqualThis == null) || ((PianoInvestimentiItem.CodTipoInvestimento != null) && (PianoInvestimentiItem.CodTipoInvestimento.Value == CodTipoInvestimentoEqualThis.Value))))
                {
                    PianoInvestimentiCollectionTemp.Add(PianoInvestimentiItem);
                }
            }
            return PianoInvestimentiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PianoInvestimentiCollection FiltroVariante(NullTypes.IntNT IdVarianteEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = new PianoInvestimentiCollection();
            foreach (PianoInvestimenti PianoInvestimentiItem in this)
            {
                if (((IdVarianteEqualThis == null) || ((PianoInvestimentiItem.IdVariante != null) && (PianoInvestimentiItem.IdVariante.Value == IdVarianteEqualThis.Value))))
                {
                    PianoInvestimentiCollectionTemp.Add(PianoInvestimentiItem);
                }
            }
            return PianoInvestimentiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public PianoInvestimentiCollection FiltroCodiceVariazione(NullTypes.StringNT CodVariazioneEqualThis, NullTypes.StringNT CodVariazioneNotEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = new PianoInvestimentiCollection();
            foreach (PianoInvestimenti PianoInvestimentiItem in this)
            {
                if (((CodVariazioneEqualThis == null) || ((PianoInvestimentiItem.CodVariazione != null) && (PianoInvestimentiItem.CodVariazione.Value == CodVariazioneEqualThis.Value))) && ((CodVariazioneNotEqualThis == null) || ((PianoInvestimentiItem.CodVariazione != null) && (PianoInvestimentiItem.CodVariazione.Value != CodVariazioneNotEqualThis.Value))))
                {
                    PianoInvestimentiCollectionTemp.Add(PianoInvestimentiItem);
                }
            }
            return PianoInvestimentiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for PianoInvestimentiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class PianoInvestimentiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, PianoInvestimenti PianoInvestimentiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdInvestimento", PianoInvestimentiObj.IdInvestimento);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", PianoInvestimentiObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgrammazione", PianoInvestimentiObj.IdProgrammazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", PianoInvestimentiObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataVariazione", PianoInvestimentiObj.DataVariazione);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreVariazione", PianoInvestimentiObj.OperatoreVariazione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodStp", PianoInvestimentiObj.CodStp);
            DbProvider.SetCmdParam(cmd, firstChar + "IdUnitaMisura", PianoInvestimentiObj.IdUnitaMisura);
            DbProvider.SetCmdParam(cmd, firstChar + "Quantita", PianoInvestimentiObj.Quantita);
            DbProvider.SetCmdParam(cmd, firstChar + "CostoInvestimento", PianoInvestimentiObj.CostoInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "SpeseGenerali", PianoInvestimentiObj.SpeseGenerali);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoRichiesto", PianoInvestimentiObj.ContributoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "QuotaContributoRichiesto", PianoInvestimentiObj.QuotaContributoRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdSettoreProduttivo", PianoInvestimentiObj.IdSettoreProduttivo);
            DbProvider.SetCmdParam(cmd, firstChar + "IdPrioritaSettoriale", PianoInvestimentiObj.IdPrioritaSettoriale);
            DbProvider.SetCmdParam(cmd, firstChar + "IdObiettivoMisura", PianoInvestimentiObj.IdObiettivoMisura);
            DbProvider.SetCmdParam(cmd, firstChar + "Ammesso", PianoInvestimentiObj.Ammesso);
            DbProvider.SetCmdParam(cmd, firstChar + "Istruttore", PianoInvestimentiObj.Istruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "IdInvestimentoOriginale", PianoInvestimentiObj.IdInvestimentoOriginale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataValutazione", PianoInvestimentiObj.DataValutazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdCodificaInvestimento", PianoInvestimentiObj.IdCodificaInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDettaglioInvestimento", PianoInvestimentiObj.IdDettaglioInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdSpecificaInvestimento", PianoInvestimentiObj.IdSpecificaInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipoInvestimento", PianoInvestimentiObj.CodTipoInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "ValutazioneInvestimento", PianoInvestimentiObj.ValutazioneInvestimento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", PianoInvestimentiObj.IdVariante);
            DbProvider.SetCmdParam(cmd, firstChar + "CodVariazione", PianoInvestimentiObj.CodVariazione);
            DbProvider.SetCmdParam(cmd, firstChar + "TassoAbbuono", PianoInvestimentiObj.TassoAbbuono);
            DbProvider.SetCmdParam(cmd, firstChar + "NonCofinanziato", PianoInvestimentiObj.NonCofinanziato);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoAltreFonti", PianoInvestimentiObj.ContributoAltreFonti);
            DbProvider.SetCmdParam(cmd, firstChar + "QuotaContributoAltreFonti", PianoInvestimentiObj.QuotaContributoAltreFonti);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresaAggregazione", PianoInvestimentiObj.IdImpresaAggregazione);
        }
        //Insert
        private static int Insert(DbProvider db, PianoInvestimenti PianoInvestimentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZPianoInvestimentiInsert", new string[] {"IdProgetto", "IdProgrammazione",
"Descrizione", "DataVariazione", "OperatoreVariazione",
"CodStp", "IdUnitaMisura", "Quantita",
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto",
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale",
"IdObiettivoMisura", "Ammesso", "Istruttore",
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento",
"IdDettaglioInvestimento", "IdSpecificaInvestimento",



"CodTipoInvestimento", "ValutazioneInvestimento",
"IdVariante", "CodVariazione", "TassoAbbuono",
"NonCofinanziato",
"ContributoAltreFonti", "QuotaContributoAltreFonti",
"IdImpresaAggregazione"}, new string[] {"int", "int",
"string", "DateTime", "string",
"string", "int", "decimal",
"decimal", "decimal", "decimal",
"decimal", "int", "int",
"int", "bool", "string",
"int", "DateTime", "int",
"int", "int",



"int", "string",
"int", "string", "decimal",
"bool",
"decimal", "decimal",
"int"}, "");
                CompileIUCmd(false, insertCmd, PianoInvestimentiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    PianoInvestimentiObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
                    PianoInvestimentiObj.NonCofinanziato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COFINANZIATO"]);
                }
                PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PianoInvestimentiObj.IsDirty = false;
                PianoInvestimentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, PianoInvestimenti PianoInvestimentiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZPianoInvestimentiUpdate", new string[] {"IdInvestimento", "IdProgetto", "IdProgrammazione",
"Descrizione", "DataVariazione", "OperatoreVariazione",
"CodStp", "IdUnitaMisura", "Quantita",
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto",
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale",
"IdObiettivoMisura", "Ammesso", "Istruttore",
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento",
"IdDettaglioInvestimento", "IdSpecificaInvestimento",



"CodTipoInvestimento", "ValutazioneInvestimento",
"IdVariante", "CodVariazione", "TassoAbbuono",
"NonCofinanziato",
"ContributoAltreFonti", "QuotaContributoAltreFonti",
"IdImpresaAggregazione"}, new string[] {"int", "int", "int",
"string", "DateTime", "string",
"string", "int", "decimal",
"decimal", "decimal", "decimal",
"decimal", "int", "int",
"int", "bool", "string",
"int", "DateTime", "int",
"int", "int",



"int", "string",
"int", "string", "decimal",
"bool",
"decimal", "decimal",
"int"}, "");
                CompileIUCmd(true, updateCmd, PianoInvestimentiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PianoInvestimentiObj.IsDirty = false;
                PianoInvestimentiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, PianoInvestimenti PianoInvestimentiObj)
        {
            switch (PianoInvestimentiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, PianoInvestimentiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, PianoInvestimentiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, PianoInvestimentiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, PianoInvestimentiCollection PianoInvestimentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZPianoInvestimentiUpdate", new string[] {"IdInvestimento", "IdProgetto", "IdProgrammazione",
"Descrizione", "DataVariazione", "OperatoreVariazione",
"CodStp", "IdUnitaMisura", "Quantita",
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto",
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale",
"IdObiettivoMisura", "Ammesso", "Istruttore",
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento",
"IdDettaglioInvestimento", "IdSpecificaInvestimento",



"CodTipoInvestimento", "ValutazioneInvestimento",
"IdVariante", "CodVariazione", "TassoAbbuono",
"NonCofinanziato",
"ContributoAltreFonti", "QuotaContributoAltreFonti",
"IdImpresaAggregazione"}, new string[] {"int", "int", "int",
"string", "DateTime", "string",
"string", "int", "decimal",
"decimal", "decimal", "decimal",
"decimal", "int", "int",
"int", "bool", "string",
"int", "DateTime", "int",
"int", "int",



"int", "string",
"int", "string", "decimal",
"bool",
"decimal", "decimal",
"int"}, "");
                IDbCommand insertCmd = db.InitCmd("ZPianoInvestimentiInsert", new string[] {"IdProgetto", "IdProgrammazione",
"Descrizione", "DataVariazione", "OperatoreVariazione",
"CodStp", "IdUnitaMisura", "Quantita",
"CostoInvestimento", "SpeseGenerali", "ContributoRichiesto",
"QuotaContributoRichiesto", "IdSettoreProduttivo", "IdPrioritaSettoriale",
"IdObiettivoMisura", "Ammesso", "Istruttore",
"IdInvestimentoOriginale", "DataValutazione", "IdCodificaInvestimento",
"IdDettaglioInvestimento", "IdSpecificaInvestimento",



"CodTipoInvestimento", "ValutazioneInvestimento",
"IdVariante", "CodVariazione", "TassoAbbuono",
"NonCofinanziato",
"ContributoAltreFonti", "QuotaContributoAltreFonti",
"IdImpresaAggregazione"}, new string[] {"int", "int",
"string", "DateTime", "string",
"string", "int", "decimal",
"decimal", "decimal", "decimal",
"decimal", "int", "int",
"int", "bool", "string",
"int", "DateTime", "int",
"int", "int",



"int", "string",
"int", "string", "decimal",
"bool",
"decimal", "decimal",
"int"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZPianoInvestimentiDelete", new string[] { "IdInvestimento" }, new string[] { "int" }, "");
                for (int i = 0; i < PianoInvestimentiCollectionObj.Count; i++)
                {
                    switch (PianoInvestimentiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, PianoInvestimentiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    PianoInvestimentiCollectionObj[i].IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
                                    PianoInvestimentiCollectionObj[i].NonCofinanziato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COFINANZIATO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, PianoInvestimentiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (PianoInvestimentiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdInvestimento", (SiarLibrary.NullTypes.IntNT)PianoInvestimentiCollectionObj[i].IdInvestimento);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < PianoInvestimentiCollectionObj.Count; i++)
                {
                    if ((PianoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        PianoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        PianoInvestimentiCollectionObj[i].IsDirty = false;
                        PianoInvestimentiCollectionObj[i].IsPersistent = true;
                    }
                    if ((PianoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        PianoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        PianoInvestimentiCollectionObj[i].IsDirty = false;
                        PianoInvestimentiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, PianoInvestimenti PianoInvestimentiObj)
        {
            int returnValue = 0;
            if (PianoInvestimentiObj.IsPersistent)
            {
                returnValue = Delete(db, PianoInvestimentiObj.IdInvestimento);
            }
            PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            PianoInvestimentiObj.IsDirty = false;
            PianoInvestimentiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdInvestimentoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZPianoInvestimentiDelete", new string[] { "IdInvestimento" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdInvestimento", (SiarLibrary.NullTypes.IntNT)IdInvestimentoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, PianoInvestimentiCollection PianoInvestimentiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZPianoInvestimentiDelete", new string[] { "IdInvestimento" }, new string[] { "int" }, "");
                for (int i = 0; i < PianoInvestimentiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdInvestimento", PianoInvestimentiCollectionObj[i].IdInvestimento);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < PianoInvestimentiCollectionObj.Count; i++)
                {
                    if ((PianoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (PianoInvestimentiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        PianoInvestimentiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        PianoInvestimentiCollectionObj[i].IsDirty = false;
                        PianoInvestimentiCollectionObj[i].IsPersistent = false;
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
        public static PianoInvestimenti GetById(DbProvider db, int IdInvestimentoValue)
        {
            PianoInvestimenti PianoInvestimentiObj = null;
            IDbCommand readCmd = db.InitCmd("ZPianoInvestimentiGetById", new string[] { "IdInvestimento" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdInvestimento", (SiarLibrary.NullTypes.IntNT)IdInvestimentoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                PianoInvestimentiObj = GetFromDatareader(db);
                PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PianoInvestimentiObj.IsDirty = false;
                PianoInvestimentiObj.IsPersistent = true;
            }
            db.Close();
            return PianoInvestimentiObj;
        }

        //getFromDatareader
        public static PianoInvestimenti GetFromDatareader(DbProvider db)
        {
            PianoInvestimenti PianoInvestimentiObj = new PianoInvestimenti();
            PianoInvestimentiObj.IdInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO"]);
            PianoInvestimentiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            PianoInvestimentiObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
            PianoInvestimentiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            PianoInvestimentiObj.DataVariazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VARIAZIONE"]);
            PianoInvestimentiObj.OperatoreVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_VARIAZIONE"]);
            PianoInvestimentiObj.CodStp = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STP"]);
            PianoInvestimentiObj.IdUnitaMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UNITA_MISURA"]);
            PianoInvestimentiObj.Quantita = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUANTITA"]);
            PianoInvestimentiObj.CostoInvestimento = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_INVESTIMENTO"]);
            PianoInvestimentiObj.SpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE_GENERALI"]);
            PianoInvestimentiObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
            PianoInvestimentiObj.QuotaContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_RICHIESTO"]);
            PianoInvestimentiObj.IdSettoreProduttivo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SETTORE_PRODUTTIVO"]);
            PianoInvestimentiObj.IdPrioritaSettoriale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PRIORITA_SETTORIALE"]);
            PianoInvestimentiObj.IdObiettivoMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OBIETTIVO_MISURA"]);
            PianoInvestimentiObj.Ammesso = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AMMESSO"]);
            PianoInvestimentiObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            PianoInvestimentiObj.IdInvestimentoOriginale = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INVESTIMENTO_ORIGINALE"]);
            PianoInvestimentiObj.DataValutazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_VALUTAZIONE"]);
            PianoInvestimentiObj.IdCodificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CODIFICA_INVESTIMENTO"]);
            PianoInvestimentiObj.IdDettaglioInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DETTAGLIO_INVESTIMENTO"]);
            PianoInvestimentiObj.IdSpecificaInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SPECIFICA_INVESTIMENTO"]);
            PianoInvestimentiObj.CodTp = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TP"]);
            PianoInvestimentiObj.CodificaInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODIFICA_INVESTIMENTO"]);
            PianoInvestimentiObj.AiutoMinimo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AIUTO_MINIMO"]);
            PianoInvestimentiObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
            PianoInvestimentiObj.CodSpecifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_SPECIFICA"]);
            PianoInvestimentiObj.SpecificaInvestimenti = new SiarLibrary.NullTypes.StringNT(db.DataReader["SPECIFICA_INVESTIMENTI"]);
            PianoInvestimentiObj.DettaglioInvestimenti = new SiarLibrary.NullTypes.StringNT(db.DataReader["DETTAGLIO_INVESTIMENTI"]);
            PianoInvestimentiObj.Mobile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MOBILE"]);
            PianoInvestimentiObj.QuotaSpeseGenerali = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_SPESE_GENERALI"]);
            PianoInvestimentiObj.SettoreProduttivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["SETTORE_PRODUTTIVO"]);
            PianoInvestimentiObj.CodTipoInvestimento = new SiarLibrary.NullTypes.IntNT(db.DataReader["COD_TIPO_INVESTIMENTO"]);
            PianoInvestimentiObj.RichiediParticella = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RICHIEDI_PARTICELLA"]);
            PianoInvestimentiObj.ValutazioneInvestimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["VALUTAZIONE_INVESTIMENTO"]);
            PianoInvestimentiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            PianoInvestimentiObj.CodVariazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_VARIAZIONE"]);
            PianoInvestimentiObj.TassoAbbuono = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TASSO_ABBUONO"]);
            PianoInvestimentiObj.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
            PianoInvestimentiObj.IdMisura = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MISURA"]);
            PianoInvestimentiObj.NonCofinanziato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["NON_COFINANZIATO"]);
            PianoInvestimentiObj.IsMax = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IS_MAX"]);
            PianoInvestimentiObj.ContributoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_ALTRE_FONTI"]);
            PianoInvestimentiObj.QuotaContributoAltreFonti = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_CONTRIBUTO_ALTRE_FONTI"]);
            PianoInvestimentiObj.IdImpresaAggregazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA_AGGREGAZIONE"]);
            PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            PianoInvestimentiObj.IsDirty = false;
            PianoInvestimentiObj.IsPersistent = true;
            return PianoInvestimentiObj;
        }

        //Find Select

        public static PianoInvestimentiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataVariazioneEqualThis, SiarLibrary.NullTypes.StringNT OperatoreVariazioneEqualThis,
SiarLibrary.NullTypes.IntNT CodTipoInvestimentoEqualThis, SiarLibrary.NullTypes.StringNT CodStpEqualThis, SiarLibrary.NullTypes.IntNT IdUnitaMisuraEqualThis,
SiarLibrary.NullTypes.DecimalNT QuantitaEqualThis, SiarLibrary.NullTypes.DecimalNT CostoInvestimentoEqualThis, SiarLibrary.NullTypes.DecimalNT SpeseGeneraliEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaContributoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAltreFontiEqualThis,
SiarLibrary.NullTypes.DecimalNT QuotaContributoAltreFontiEqualThis, SiarLibrary.NullTypes.DecimalNT TassoAbbuonoEqualThis, SiarLibrary.NullTypes.IntNT IdSettoreProduttivoEqualThis,
SiarLibrary.NullTypes.IntNT IdPrioritaSettorialeEqualThis, SiarLibrary.NullTypes.IntNT IdObiettivoMisuraEqualThis, SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis,
SiarLibrary.NullTypes.IntNT IdDettaglioInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdSpecificaInvestimentoEqualThis, SiarLibrary.NullTypes.BoolNT AmmessoEqualThis,
SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, SiarLibrary.NullTypes.IntNT IdInvestimentoOriginaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataValutazioneEqualThis,
SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodVariazioneEqualThis, SiarLibrary.NullTypes.BoolNT NonCofinanziatoEqualThis,
SiarLibrary.NullTypes.IntNT IdImpresaAggregazioneEqualThis)

        {

            PianoInvestimentiCollection PianoInvestimentiCollectionObj = new PianoInvestimentiCollection();

            IDbCommand findCmd = db.InitCmd("Zpianoinvestimentifindselect", new string[] {"IdInvestimentoequalthis", "IdProgettoequalthis", "IdProgrammazioneequalthis",
"Descrizioneequalthis", "DataVariazioneequalthis", "OperatoreVariazioneequalthis",
"CodTipoInvestimentoequalthis", "CodStpequalthis", "IdUnitaMisuraequalthis",
"Quantitaequalthis", "CostoInvestimentoequalthis", "SpeseGeneraliequalthis",
"ContributoRichiestoequalthis", "QuotaContributoRichiestoequalthis", "ContributoAltreFontiequalthis",
"QuotaContributoAltreFontiequalthis", "TassoAbbuonoequalthis", "IdSettoreProduttivoequalthis",
"IdPrioritaSettorialeequalthis", "IdObiettivoMisuraequalthis", "IdCodificaInvestimentoequalthis",
"IdDettaglioInvestimentoequalthis", "IdSpecificaInvestimentoequalthis", "Ammessoequalthis",
"Istruttoreequalthis", "IdInvestimentoOriginaleequalthis", "DataValutazioneequalthis",
"IdVarianteequalthis", "CodVariazioneequalthis", "NonCofinanziatoequalthis",
"IdImpresaAggregazioneequalthis"}, new string[] {"int", "int", "int",
"string", "DateTime", "string",
"int", "string", "int",
"decimal", "decimal", "decimal",
"decimal", "decimal", "decimal",
"decimal", "decimal", "int",
"int", "int", "int",
"int", "int", "bool",
"string", "int", "DateTime",
"int", "string", "bool",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataVariazioneequalthis", DataVariazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreVariazioneequalthis", OperatoreVariazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoInvestimentoequalthis", CodTipoInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStpequalthis", CodStpEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUnitaMisuraequalthis", IdUnitaMisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Quantitaequalthis", QuantitaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CostoInvestimentoequalthis", CostoInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpeseGeneraliequalthis", SpeseGeneraliEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuotaContributoRichiestoequalthis", QuotaContributoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAltreFontiequalthis", ContributoAltreFontiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuotaContributoAltreFontiequalthis", QuotaContributoAltreFontiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TassoAbbuonoequalthis", TassoAbbuonoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSettoreProduttivoequalthis", IdSettoreProduttivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPrioritaSettorialeequalthis", IdPrioritaSettorialeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdObiettivoMisuraequalthis", IdObiettivoMisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDettaglioInvestimentoequalthis", IdDettaglioInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSpecificaInvestimentoequalthis", IdSpecificaInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ammessoequalthis", AmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoOriginaleequalthis", IdInvestimentoOriginaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataValutazioneequalthis", DataValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodVariazioneequalthis", CodVariazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NonCofinanziatoequalthis", NonCofinanziatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaAggregazioneequalthis", IdImpresaAggregazioneEqualThis);
            PianoInvestimenti PianoInvestimentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                PianoInvestimentiObj = GetFromDatareader(db);
                PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PianoInvestimentiObj.IsDirty = false;
                PianoInvestimentiObj.IsPersistent = true;
                PianoInvestimentiCollectionObj.Add(PianoInvestimentiObj);
            }
            db.Close();
            return PianoInvestimentiCollectionObj;
        }

        //Find Find

        public static PianoInvestimentiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis,
SiarLibrary.NullTypes.IntNT IdCodificaInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdDettaglioInvestimentoEqualThis, SiarLibrary.NullTypes.IntNT IdSpecificaInvestimentoEqualThis,
SiarLibrary.NullTypes.IntNT IdInvestimentoOriginaleEqualThis)

        {

            PianoInvestimentiCollection PianoInvestimentiCollectionObj = new PianoInvestimentiCollection();

            IDbCommand findCmd = db.InitCmd("Zpianoinvestimentifindfind", new string[] {"IdInvestimentoequalthis", "IdProgettoequalthis", "IdProgrammazioneequalthis",
"IdCodificaInvestimentoequalthis", "IdDettaglioInvestimentoequalthis", "IdSpecificaInvestimentoequalthis",
"IdInvestimentoOriginaleequalthis"}, new string[] {"int", "int", "int",
"int", "int", "int",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoequalthis", IdInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdCodificaInvestimentoequalthis", IdCodificaInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDettaglioInvestimentoequalthis", IdDettaglioInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSpecificaInvestimentoequalthis", IdSpecificaInvestimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdInvestimentoOriginaleequalthis", IdInvestimentoOriginaleEqualThis);
            PianoInvestimenti PianoInvestimentiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                PianoInvestimentiObj = GetFromDatareader(db);
                PianoInvestimentiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                PianoInvestimentiObj.IsDirty = false;
                PianoInvestimentiObj.IsPersistent = true;
                PianoInvestimentiCollectionObj.Add(PianoInvestimentiObj);
            }
            db.Close();
            return PianoInvestimentiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for PianoInvestimentiCollectionProvider:IPianoInvestimentiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class PianoInvestimentiCollectionProvider : IPianoInvestimentiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di PianoInvestimenti
        protected PianoInvestimentiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public PianoInvestimentiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new PianoInvestimentiCollection(this);
        }

        //Costruttore 2: popola la collection
        public PianoInvestimentiCollectionProvider(IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogrammazioneEqualThis,
IntNT IdcodificainvestimentoEqualThis, IntNT IddettaglioinvestimentoEqualThis, IntNT IdspecificainvestimentoEqualThis,
IntNT IdinvestimentooriginaleEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdinvestimentoEqualThis, IdprogettoEqualThis, IdprogrammazioneEqualThis,
IdcodificainvestimentoEqualThis, IddettaglioinvestimentoEqualThis, IdspecificainvestimentoEqualThis,
IdinvestimentooriginaleEqualThis);
        }

        //Costruttore3: ha in input pianoinvestimentiCollectionObj - non popola la collection
        public PianoInvestimentiCollectionProvider(PianoInvestimentiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public PianoInvestimentiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new PianoInvestimentiCollection(this);
        }

        //Get e Set
        public PianoInvestimentiCollection CollectionObj
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
        public int SaveCollection(PianoInvestimentiCollection collectionObj)
        {
            return PianoInvestimentiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(PianoInvestimenti pianoinvestimentiObj)
        {
            return PianoInvestimentiDAL.Save(_dbProviderObj, pianoinvestimentiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(PianoInvestimentiCollection collectionObj)
        {
            return PianoInvestimentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(PianoInvestimenti pianoinvestimentiObj)
        {
            return PianoInvestimentiDAL.Delete(_dbProviderObj, pianoinvestimentiObj);
        }

        //getById
        public PianoInvestimenti GetById(IntNT IdInvestimentoValue)
        {
            PianoInvestimenti PianoInvestimentiTemp = PianoInvestimentiDAL.GetById(_dbProviderObj, IdInvestimentoValue);
            if (PianoInvestimentiTemp != null) PianoInvestimentiTemp.Provider = this;
            return PianoInvestimentiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public PianoInvestimentiCollection Select(IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogrammazioneEqualThis,
StringNT DescrizioneEqualThis, DatetimeNT DatavariazioneEqualThis, StringNT OperatorevariazioneEqualThis,
IntNT CodtipoinvestimentoEqualThis, StringNT CodstpEqualThis, IntNT IdunitamisuraEqualThis,
DecimalNT QuantitaEqualThis, DecimalNT CostoinvestimentoEqualThis, DecimalNT SpesegeneraliEqualThis,
DecimalNT ContributorichiestoEqualThis, DecimalNT QuotacontributorichiestoEqualThis, DecimalNT ContributoaltrefontiEqualThis,
DecimalNT QuotacontributoaltrefontiEqualThis, DecimalNT TassoabbuonoEqualThis, IntNT IdsettoreproduttivoEqualThis,
IntNT IdprioritasettorialeEqualThis, IntNT IdobiettivomisuraEqualThis, IntNT IdcodificainvestimentoEqualThis,
IntNT IddettaglioinvestimentoEqualThis, IntNT IdspecificainvestimentoEqualThis, BoolNT AmmessoEqualThis,
StringNT IstruttoreEqualThis, IntNT IdinvestimentooriginaleEqualThis, DatetimeNT DatavalutazioneEqualThis,
IntNT IdvarianteEqualThis, StringNT CodvariazioneEqualThis, BoolNT NoncofinanziatoEqualThis,
IntNT IdimpresaaggregazioneEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = PianoInvestimentiDAL.Select(_dbProviderObj, IdinvestimentoEqualThis, IdprogettoEqualThis, IdprogrammazioneEqualThis,
DescrizioneEqualThis, DatavariazioneEqualThis, OperatorevariazioneEqualThis,
CodtipoinvestimentoEqualThis, CodstpEqualThis, IdunitamisuraEqualThis,
QuantitaEqualThis, CostoinvestimentoEqualThis, SpesegeneraliEqualThis,
ContributorichiestoEqualThis, QuotacontributorichiestoEqualThis, ContributoaltrefontiEqualThis,
QuotacontributoaltrefontiEqualThis, TassoabbuonoEqualThis, IdsettoreproduttivoEqualThis,
IdprioritasettorialeEqualThis, IdobiettivomisuraEqualThis, IdcodificainvestimentoEqualThis,
IddettaglioinvestimentoEqualThis, IdspecificainvestimentoEqualThis, AmmessoEqualThis,
IstruttoreEqualThis, IdinvestimentooriginaleEqualThis, DatavalutazioneEqualThis,
IdvarianteEqualThis, CodvariazioneEqualThis, NoncofinanziatoEqualThis,
IdimpresaaggregazioneEqualThis);
            PianoInvestimentiCollectionTemp.Provider = this;
            return PianoInvestimentiCollectionTemp;
        }

        //Find: popola la collection
        public PianoInvestimentiCollection Find(IntNT IdinvestimentoEqualThis, IntNT IdprogettoEqualThis, IntNT IdprogrammazioneEqualThis,
IntNT IdcodificainvestimentoEqualThis, IntNT IddettaglioinvestimentoEqualThis, IntNT IdspecificainvestimentoEqualThis,
IntNT IdinvestimentooriginaleEqualThis)
        {
            PianoInvestimentiCollection PianoInvestimentiCollectionTemp = PianoInvestimentiDAL.Find(_dbProviderObj, IdinvestimentoEqualThis, IdprogettoEqualThis, IdprogrammazioneEqualThis,
IdcodificainvestimentoEqualThis, IddettaglioinvestimentoEqualThis, IdspecificainvestimentoEqualThis,
IdinvestimentooriginaleEqualThis);
            PianoInvestimentiCollectionTemp.Provider = this;
            return PianoInvestimentiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_INVESTIMENTI>
  <ViewName>vPIANO_INVESTIMENTI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
    <Find OrderBy="ORDER BY COD_TIPO_INVESTIMENTO, ID_INVESTIMENTO">
      <ID_INVESTIMENTO>Equal</ID_INVESTIMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <ID_CODIFICA_INVESTIMENTO>Equal</ID_CODIFICA_INVESTIMENTO>
      <ID_DETTAGLIO_INVESTIMENTO>Equal</ID_DETTAGLIO_INVESTIMENTO>
      <ID_SPECIFICA_INVESTIMENTO>Equal</ID_SPECIFICA_INVESTIMENTO>
      <ID_INVESTIMENTO_ORIGINALE>Equal</ID_INVESTIMENTO_ORIGINALE>
    </Find>
  </Finds>
  <Filters>
    <FiltroProgettoCorrelato>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </FiltroProgettoCorrelato>
    <FiltroInvestimentoOriginale>
      <ID_INVESTIMENTO_ORIGINALE>IsNull</ID_INVESTIMENTO_ORIGINALE>
    </FiltroInvestimentoOriginale>
    <FiltroTipoInvestimento>
      <COD_TIPO_INVESTIMENTO>Equal</COD_TIPO_INVESTIMENTO>
    </FiltroTipoInvestimento>
    <FiltroVariante>
      <ID_VARIANTE>Equal</ID_VARIANTE>
    </FiltroVariante>
    <FiltroCodiceVariazione>
      <COD_VARIAZIONE>Equal</COD_VARIAZIONE>
      <COD_VARIAZIONE>NotEqual</COD_VARIAZIONE>
    </FiltroCodiceVariazione>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PIANO_INVESTIMENTI>
*/
