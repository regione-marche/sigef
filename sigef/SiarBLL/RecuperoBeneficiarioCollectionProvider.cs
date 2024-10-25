using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per RecuperoBeneficiario
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IRecuperoBeneficiarioProvider
    {
        int Save(RecuperoBeneficiario RecuperoBeneficiarioObj);
        int SaveCollection(RecuperoBeneficiarioCollection collectionObj);
        int Delete(RecuperoBeneficiario RecuperoBeneficiarioObj);
        int DeleteCollection(RecuperoBeneficiarioCollection collectionObj);
    }
    /// <summary>
    /// Summary description for RecuperoBeneficiario
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class RecuperoBeneficiario : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdRecuperoBeneficiario;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _Origine;
        private NullTypes.IntNT _IdIrregolarita;
        private NullTypes.IntNT _IdRevoca;
        private NullTypes.IntNT _IdErrore;
        private NullTypes.StringNT _DecretoRecuperoNumero;
        private NullTypes.DatetimeNT _DecretoRecuperoData;
        private NullTypes.DatetimeNT _DataAvvioRecupero;
        private NullTypes.StringNT _SegnaturaPaleoComunicazioneBeneficiario;
        private NullTypes.DecimalNT _Contributo;
        private NullTypes.DecimalNT _Interessi;
        private NullTypes.DecimalNT _Spese;
        private NullTypes.DecimalNT _Sanzioni;
        private NullTypes.DecimalNT _TotaleDaRecuperare;
        private NullTypes.StringNT _Note;
        private NullTypes.BoolNT _Definitivo;
        private NullTypes.DecimalNT _ImportoRecuperato;
        private NullTypes.DecimalNT _ImportoIrrecuperabile;
        private NullTypes.StringNT _Stato;
        private NullTypes.IntNT _IdAttoRecupero;
        private NullTypes.IntNT _IdAttoRateizzazione;
        private NullTypes.DatetimeNT _DataInizioRateizzazione;
        private NullTypes.DatetimeNT _DataFineRateizzazione;
        private NullTypes.BoolNT _FlagImportoIrrecuperabile;
        private NullTypes.StringNT _RagioneSocialeImpresa;
        private NullTypes.IntNT _NumerAttoRecupero;
        private NullTypes.DatetimeNT _DataAttoRecupero;
        private NullTypes.StringNT _RegistroAttoRecupero;
        private NullTypes.IntNT _NumerAttoRateizzazione;
        private NullTypes.DatetimeNT _DataAttoRateizzazione;
        private NullTypes.StringNT _RegistroAttoRateizzazione;
        [NonSerialized] private IRecuperoBeneficiarioProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRecuperoBeneficiarioProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public RecuperoBeneficiario()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_RECUPERO_BENEFICIARIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRecuperoBeneficiario
        {
            get { return _IdRecuperoBeneficiario; }
            set
            {
                if (IdRecuperoBeneficiario != value)
                {
                    _IdRecuperoBeneficiario = value;
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
        /// Corrisponde al campo:ID_IMPRESA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdImpresa
        {
            get { return _IdImpresa; }
            set
            {
                if (IdImpresa != value)
                {
                    _IdImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORIGINE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Origine
        {
            get { return _Origine; }
            set
            {
                if (Origine != value)
                {
                    _Origine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_IRREGOLARITA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIrregolarita
        {
            get { return _IdIrregolarita; }
            set
            {
                if (IdIrregolarita != value)
                {
                    _IdIrregolarita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_REVOCA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdRevoca
        {
            get { return _IdRevoca; }
            set
            {
                if (IdRevoca != value)
                {
                    _IdRevoca = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ERRORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdErrore
        {
            get { return _IdErrore; }
            set
            {
                if (IdErrore != value)
                {
                    _IdErrore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DECRETO_RECUPERO_NUMERO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT DecretoRecuperoNumero
        {
            get { return _DecretoRecuperoNumero; }
            set
            {
                if (DecretoRecuperoNumero != value)
                {
                    _DecretoRecuperoNumero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DECRETO_RECUPERO_DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DecretoRecuperoData
        {
            get { return _DecretoRecuperoData; }
            set
            {
                if (DecretoRecuperoData != value)
                {
                    _DecretoRecuperoData = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_AVVIO_RECUPERO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAvvioRecupero
        {
            get { return _DataAvvioRecupero; }
            set
            {
                if (DataAvvioRecupero != value)
                {
                    _DataAvvioRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT SegnaturaPaleoComunicazioneBeneficiario
        {
            get { return _SegnaturaPaleoComunicazioneBeneficiario; }
            set
            {
                if (SegnaturaPaleoComunicazioneBeneficiario != value)
                {
                    _SegnaturaPaleoComunicazioneBeneficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT Contributo
        {
            get { return _Contributo; }
            set
            {
                if (Contributo != value)
                {
                    _Contributo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INTERESSI
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT Interessi
        {
            get { return _Interessi; }
            set
            {
                if (Interessi != value)
                {
                    _Interessi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT Spese
        {
            get { return _Spese; }
            set
            {
                if (Spese != value)
                {
                    _Spese = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SANZIONI
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT Sanzioni
        {
            get { return _Sanzioni; }
            set
            {
                if (Sanzioni != value)
                {
                    _Sanzioni = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOTALE_DA_RECUPERARE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT TotaleDaRecuperare
        {
            get { return _TotaleDaRecuperare; }
            set
            {
                if (TotaleDaRecuperare != value)
                {
                    _TotaleDaRecuperare = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Note
        {
            get { return _Note; }
            set
            {
                if (Note != value)
                {
                    _Note = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DEFINITIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Definitivo
        {
            get { return _Definitivo; }
            set
            {
                if (Definitivo != value)
                {
                    _Definitivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_RECUPERATO
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoRecuperato
        {
            get { return _ImportoRecuperato; }
            set
            {
                if (ImportoRecuperato != value)
                {
                    _ImportoRecuperato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_IRRECUPERABILE
        /// Tipo sul db:DECIMAL(15,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoIrrecuperabile
        {
            get { return _ImportoIrrecuperabile; }
            set
            {
                if (ImportoIrrecuperabile != value)
                {
                    _ImportoIrrecuperabile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO
        /// Tipo sul db:VARCHAR(150)
        /// </summary>
        public NullTypes.StringNT Stato
        {
            get { return _Stato; }
            set
            {
                if (Stato != value)
                {
                    _Stato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoRecupero
        {
            get { return _IdAttoRecupero; }
            set
            {
                if (IdAttoRecupero != value)
                {
                    _IdAttoRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_RATEIZZAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoRateizzazione
        {
            get { return _IdAttoRateizzazione; }
            set
            {
                if (IdAttoRateizzazione != value)
                {
                    _IdAttoRateizzazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_RATEIZZAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioRateizzazione
        {
            get { return _DataInizioRateizzazione; }
            set
            {
                if (DataInizioRateizzazione != value)
                {
                    _DataInizioRateizzazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE_RATEIZZAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFineRateizzazione
        {
            get { return _DataFineRateizzazione; }
            set
            {
                if (DataFineRateizzazione != value)
                {
                    _DataFineRateizzazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FLAG_IMPORTO_IRRECUPERABILE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FlagImportoIrrecuperabile
        {
            get { return _FlagImportoIrrecuperabile; }
            set
            {
                if (FlagImportoIrrecuperabile != value)
                {
                    _FlagImportoIrrecuperabile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RAGIONE_SOCIALE_IMPRESA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RagioneSocialeImpresa
        {
            get { return _RagioneSocialeImpresa; }
            set
            {
                if (RagioneSocialeImpresa != value)
                {
                    _RagioneSocialeImpresa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMER_ATTO_RECUPERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumerAttoRecupero
        {
            get { return _NumerAttoRecupero; }
            set
            {
                if (NumerAttoRecupero != value)
                {
                    _NumerAttoRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ATTO_RECUPERO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAttoRecupero
        {
            get { return _DataAttoRecupero; }
            set
            {
                if (DataAttoRecupero != value)
                {
                    _DataAttoRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO_ATTO_RECUPERO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT RegistroAttoRecupero
        {
            get { return _RegistroAttoRecupero; }
            set
            {
                if (RegistroAttoRecupero != value)
                {
                    _RegistroAttoRecupero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMER_ATTO_RATEIZZAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumerAttoRateizzazione
        {
            get { return _NumerAttoRateizzazione; }
            set
            {
                if (NumerAttoRateizzazione != value)
                {
                    _NumerAttoRateizzazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ATTO_RATEIZZAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAttoRateizzazione
        {
            get { return _DataAttoRateizzazione; }
            set
            {
                if (DataAttoRateizzazione != value)
                {
                    _DataAttoRateizzazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO_ATTO_RATEIZZAZIONE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT RegistroAttoRateizzazione
        {
            get { return _RegistroAttoRateizzazione; }
            set
            {
                if (RegistroAttoRateizzazione != value)
                {
                    _RegistroAttoRateizzazione = value;
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
    /// Summary description for RecuperoBeneficiarioCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RecuperoBeneficiarioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private RecuperoBeneficiarioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((RecuperoBeneficiario)info.GetValue(i.ToString(), typeof(RecuperoBeneficiario)));
            }
        }

        //Costruttore
        public RecuperoBeneficiarioCollection()
        {
            this.ItemType = typeof(RecuperoBeneficiario);
        }

        //Costruttore con provider
        public RecuperoBeneficiarioCollection(IRecuperoBeneficiarioProvider providerObj)
        {
            this.ItemType = typeof(RecuperoBeneficiario);
            this.Provider = providerObj;
        }

        //Get e Set
        public new RecuperoBeneficiario this[int index]
        {
            get { return (RecuperoBeneficiario)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new RecuperoBeneficiarioCollection GetChanges()
        {
            return (RecuperoBeneficiarioCollection)base.GetChanges();
        }

        [NonSerialized] private IRecuperoBeneficiarioProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRecuperoBeneficiarioProvider Provider
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
        public int Add(RecuperoBeneficiario RecuperoBeneficiarioObj)
        {
            if (RecuperoBeneficiarioObj.Provider == null) RecuperoBeneficiarioObj.Provider = this.Provider;
            return base.Add(RecuperoBeneficiarioObj);
        }

        //AddCollection
        public void AddCollection(RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionObj)
        {
            foreach (RecuperoBeneficiario RecuperoBeneficiarioObj in RecuperoBeneficiarioCollectionObj)
                this.Add(RecuperoBeneficiarioObj);
        }

        //Insert
        public void Insert(int index, RecuperoBeneficiario RecuperoBeneficiarioObj)
        {
            if (RecuperoBeneficiarioObj.Provider == null) RecuperoBeneficiarioObj.Provider = this.Provider;
            base.Insert(index, RecuperoBeneficiarioObj);
        }

        //CollectionGetById
        public RecuperoBeneficiario CollectionGetById(NullTypes.IntNT IdRecuperoBeneficiarioValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdRecuperoBeneficiario == IdRecuperoBeneficiarioValue))
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
        public RecuperoBeneficiarioCollection SubSelect(NullTypes.IntNT IdRecuperoBeneficiarioEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.StringNT OrigineEqualThis, NullTypes.IntNT IdIrregolaritaEqualThis, NullTypes.IntNT IdRevocaEqualThis,
NullTypes.IntNT IdErroreEqualThis, NullTypes.StringNT DecretoRecuperoNumeroEqualThis, NullTypes.DatetimeNT DecretoRecuperoDataEqualThis,
NullTypes.DatetimeNT DataAvvioRecuperoEqualThis, NullTypes.StringNT SegnaturaPaleoComunicazioneBeneficiarioEqualThis, NullTypes.DecimalNT ContributoEqualThis,
NullTypes.DecimalNT InteressiEqualThis, NullTypes.DecimalNT SpeseEqualThis, NullTypes.DecimalNT SanzioniEqualThis,
NullTypes.DecimalNT TotaleDaRecuperareEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.BoolNT DefinitivoEqualThis,
NullTypes.DecimalNT ImportoRecuperatoEqualThis, NullTypes.DecimalNT ImportoIrrecuperabileEqualThis, NullTypes.StringNT StatoEqualThis,
NullTypes.IntNT IdAttoRecuperoEqualThis, NullTypes.IntNT IdAttoRateizzazioneEqualThis, NullTypes.DatetimeNT DataInizioRateizzazioneEqualThis,
NullTypes.DatetimeNT DataFineRateizzazioneEqualThis, NullTypes.BoolNT FlagImportoIrrecuperabileEqualThis)
        {
            RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionTemp = new RecuperoBeneficiarioCollection();
            foreach (RecuperoBeneficiario RecuperoBeneficiarioItem in this)
            {
                if (((IdRecuperoBeneficiarioEqualThis == null) || ((RecuperoBeneficiarioItem.IdRecuperoBeneficiario != null) && (RecuperoBeneficiarioItem.IdRecuperoBeneficiario.Value == IdRecuperoBeneficiarioEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((RecuperoBeneficiarioItem.IdProgetto != null) && (RecuperoBeneficiarioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((RecuperoBeneficiarioItem.IdImpresa != null) && (RecuperoBeneficiarioItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((OrigineEqualThis == null) || ((RecuperoBeneficiarioItem.Origine != null) && (RecuperoBeneficiarioItem.Origine.Value == OrigineEqualThis.Value))) && ((IdIrregolaritaEqualThis == null) || ((RecuperoBeneficiarioItem.IdIrregolarita != null) && (RecuperoBeneficiarioItem.IdIrregolarita.Value == IdIrregolaritaEqualThis.Value))) && ((IdRevocaEqualThis == null) || ((RecuperoBeneficiarioItem.IdRevoca != null) && (RecuperoBeneficiarioItem.IdRevoca.Value == IdRevocaEqualThis.Value))) &&
((IdErroreEqualThis == null) || ((RecuperoBeneficiarioItem.IdErrore != null) && (RecuperoBeneficiarioItem.IdErrore.Value == IdErroreEqualThis.Value))) && ((DecretoRecuperoNumeroEqualThis == null) || ((RecuperoBeneficiarioItem.DecretoRecuperoNumero != null) && (RecuperoBeneficiarioItem.DecretoRecuperoNumero.Value == DecretoRecuperoNumeroEqualThis.Value))) && ((DecretoRecuperoDataEqualThis == null) || ((RecuperoBeneficiarioItem.DecretoRecuperoData != null) && (RecuperoBeneficiarioItem.DecretoRecuperoData.Value == DecretoRecuperoDataEqualThis.Value))) &&
((DataAvvioRecuperoEqualThis == null) || ((RecuperoBeneficiarioItem.DataAvvioRecupero != null) && (RecuperoBeneficiarioItem.DataAvvioRecupero.Value == DataAvvioRecuperoEqualThis.Value))) && ((SegnaturaPaleoComunicazioneBeneficiarioEqualThis == null) || ((RecuperoBeneficiarioItem.SegnaturaPaleoComunicazioneBeneficiario != null) && (RecuperoBeneficiarioItem.SegnaturaPaleoComunicazioneBeneficiario.Value == SegnaturaPaleoComunicazioneBeneficiarioEqualThis.Value))) && ((ContributoEqualThis == null) || ((RecuperoBeneficiarioItem.Contributo != null) && (RecuperoBeneficiarioItem.Contributo.Value == ContributoEqualThis.Value))) &&
((InteressiEqualThis == null) || ((RecuperoBeneficiarioItem.Interessi != null) && (RecuperoBeneficiarioItem.Interessi.Value == InteressiEqualThis.Value))) && ((SpeseEqualThis == null) || ((RecuperoBeneficiarioItem.Spese != null) && (RecuperoBeneficiarioItem.Spese.Value == SpeseEqualThis.Value))) && ((SanzioniEqualThis == null) || ((RecuperoBeneficiarioItem.Sanzioni != null) && (RecuperoBeneficiarioItem.Sanzioni.Value == SanzioniEqualThis.Value))) &&
((TotaleDaRecuperareEqualThis == null) || ((RecuperoBeneficiarioItem.TotaleDaRecuperare != null) && (RecuperoBeneficiarioItem.TotaleDaRecuperare.Value == TotaleDaRecuperareEqualThis.Value))) && ((NoteEqualThis == null) || ((RecuperoBeneficiarioItem.Note != null) && (RecuperoBeneficiarioItem.Note.Value == NoteEqualThis.Value))) && ((DefinitivoEqualThis == null) || ((RecuperoBeneficiarioItem.Definitivo != null) && (RecuperoBeneficiarioItem.Definitivo.Value == DefinitivoEqualThis.Value))) &&
((ImportoRecuperatoEqualThis == null) || ((RecuperoBeneficiarioItem.ImportoRecuperato != null) && (RecuperoBeneficiarioItem.ImportoRecuperato.Value == ImportoRecuperatoEqualThis.Value))) && ((ImportoIrrecuperabileEqualThis == null) || ((RecuperoBeneficiarioItem.ImportoIrrecuperabile != null) && (RecuperoBeneficiarioItem.ImportoIrrecuperabile.Value == ImportoIrrecuperabileEqualThis.Value))) && ((StatoEqualThis == null) || ((RecuperoBeneficiarioItem.Stato != null) && (RecuperoBeneficiarioItem.Stato.Value == StatoEqualThis.Value))) &&
((IdAttoRecuperoEqualThis == null) || ((RecuperoBeneficiarioItem.IdAttoRecupero != null) && (RecuperoBeneficiarioItem.IdAttoRecupero.Value == IdAttoRecuperoEqualThis.Value))) && ((IdAttoRateizzazioneEqualThis == null) || ((RecuperoBeneficiarioItem.IdAttoRateizzazione != null) && (RecuperoBeneficiarioItem.IdAttoRateizzazione.Value == IdAttoRateizzazioneEqualThis.Value))) && ((DataInizioRateizzazioneEqualThis == null) || ((RecuperoBeneficiarioItem.DataInizioRateizzazione != null) && (RecuperoBeneficiarioItem.DataInizioRateizzazione.Value == DataInizioRateizzazioneEqualThis.Value))) &&
((DataFineRateizzazioneEqualThis == null) || ((RecuperoBeneficiarioItem.DataFineRateizzazione != null) && (RecuperoBeneficiarioItem.DataFineRateizzazione.Value == DataFineRateizzazioneEqualThis.Value))) && ((FlagImportoIrrecuperabileEqualThis == null) || ((RecuperoBeneficiarioItem.FlagImportoIrrecuperabile != null) && (RecuperoBeneficiarioItem.FlagImportoIrrecuperabile.Value == FlagImportoIrrecuperabileEqualThis.Value))))
                {
                    RecuperoBeneficiarioCollectionTemp.Add(RecuperoBeneficiarioItem);
                }
            }
            return RecuperoBeneficiarioCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for RecuperoBeneficiarioDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class RecuperoBeneficiarioDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, RecuperoBeneficiario RecuperoBeneficiarioObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdRecuperoBeneficiario", RecuperoBeneficiarioObj.IdRecuperoBeneficiario);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", RecuperoBeneficiarioObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdImpresa", RecuperoBeneficiarioObj.IdImpresa);
            DbProvider.SetCmdParam(cmd, firstChar + "Origine", RecuperoBeneficiarioObj.Origine);
            DbProvider.SetCmdParam(cmd, firstChar + "IdIrregolarita", RecuperoBeneficiarioObj.IdIrregolarita);
            DbProvider.SetCmdParam(cmd, firstChar + "IdRevoca", RecuperoBeneficiarioObj.IdRevoca);
            DbProvider.SetCmdParam(cmd, firstChar + "IdErrore", RecuperoBeneficiarioObj.IdErrore);
            DbProvider.SetCmdParam(cmd, firstChar + "DecretoRecuperoNumero", RecuperoBeneficiarioObj.DecretoRecuperoNumero);
            DbProvider.SetCmdParam(cmd, firstChar + "DecretoRecuperoData", RecuperoBeneficiarioObj.DecretoRecuperoData);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAvvioRecupero", RecuperoBeneficiarioObj.DataAvvioRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaPaleoComunicazioneBeneficiario", RecuperoBeneficiarioObj.SegnaturaPaleoComunicazioneBeneficiario);
            DbProvider.SetCmdParam(cmd, firstChar + "Contributo", RecuperoBeneficiarioObj.Contributo);
            DbProvider.SetCmdParam(cmd, firstChar + "Interessi", RecuperoBeneficiarioObj.Interessi);
            DbProvider.SetCmdParam(cmd, firstChar + "Spese", RecuperoBeneficiarioObj.Spese);
            DbProvider.SetCmdParam(cmd, firstChar + "Sanzioni", RecuperoBeneficiarioObj.Sanzioni);
            DbProvider.SetCmdParam(cmd, firstChar + "TotaleDaRecuperare", RecuperoBeneficiarioObj.TotaleDaRecuperare);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", RecuperoBeneficiarioObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "Definitivo", RecuperoBeneficiarioObj.Definitivo);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoRecuperato", RecuperoBeneficiarioObj.ImportoRecuperato);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoIrrecuperabile", RecuperoBeneficiarioObj.ImportoIrrecuperabile);
            DbProvider.SetCmdParam(cmd, firstChar + "Stato", RecuperoBeneficiarioObj.Stato);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttoRecupero", RecuperoBeneficiarioObj.IdAttoRecupero);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttoRateizzazione", RecuperoBeneficiarioObj.IdAttoRateizzazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizioRateizzazione", RecuperoBeneficiarioObj.DataInizioRateizzazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFineRateizzazione", RecuperoBeneficiarioObj.DataFineRateizzazione);
            DbProvider.SetCmdParam(cmd, firstChar + "FlagImportoIrrecuperabile", RecuperoBeneficiarioObj.FlagImportoIrrecuperabile);
        }
        //Insert
        private static int Insert(DbProvider db, RecuperoBeneficiario RecuperoBeneficiarioObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZRecuperoBeneficiarioInsert", new string[] {"IdProgetto", "IdImpresa",
"Origine", "IdIrregolarita", "IdRevoca",
"IdErrore", "DecretoRecuperoNumero", "DecretoRecuperoData",
"DataAvvioRecupero", "SegnaturaPaleoComunicazioneBeneficiario", "Contributo",
"Interessi", "Spese", "Sanzioni",
"TotaleDaRecuperare", "Note", "Definitivo",
"ImportoRecuperato", "ImportoIrrecuperabile", "Stato",
"IdAttoRecupero", "IdAttoRateizzazione", "DataInizioRateizzazione",
"DataFineRateizzazione", "FlagImportoIrrecuperabile",
}, new string[] {"int", "int",
"string", "int", "int",
"int", "string", "DateTime",
"DateTime", "string", "decimal",
"decimal", "decimal", "decimal",
"decimal", "string", "bool",
"decimal", "decimal", "string",
"int", "int", "DateTime",
"DateTime", "bool",
}, "");
                CompileIUCmd(false, insertCmd, RecuperoBeneficiarioObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    RecuperoBeneficiarioObj.IdRecuperoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RECUPERO_BENEFICIARIO"]);
                }
                RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RecuperoBeneficiarioObj.IsDirty = false;
                RecuperoBeneficiarioObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, RecuperoBeneficiario RecuperoBeneficiarioObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRecuperoBeneficiarioUpdate", new string[] {"IdRecuperoBeneficiario", "IdProgetto", "IdImpresa",
"Origine", "IdIrregolarita", "IdRevoca",
"IdErrore", "DecretoRecuperoNumero", "DecretoRecuperoData",
"DataAvvioRecupero", "SegnaturaPaleoComunicazioneBeneficiario", "Contributo",
"Interessi", "Spese", "Sanzioni",
"TotaleDaRecuperare", "Note", "Definitivo",
"ImportoRecuperato", "ImportoIrrecuperabile", "Stato",
"IdAttoRecupero", "IdAttoRateizzazione", "DataInizioRateizzazione",
"DataFineRateizzazione", "FlagImportoIrrecuperabile",
}, new string[] {"int", "int", "int",
"string", "int", "int",
"int", "string", "DateTime",
"DateTime", "string", "decimal",
"decimal", "decimal", "decimal",
"decimal", "string", "bool",
"decimal", "decimal", "string",
"int", "int", "DateTime",
"DateTime", "bool",
}, "");
                CompileIUCmd(true, updateCmd, RecuperoBeneficiarioObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RecuperoBeneficiarioObj.IsDirty = false;
                RecuperoBeneficiarioObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, RecuperoBeneficiario RecuperoBeneficiarioObj)
        {
            switch (RecuperoBeneficiarioObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, RecuperoBeneficiarioObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, RecuperoBeneficiarioObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, RecuperoBeneficiarioObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZRecuperoBeneficiarioUpdate", new string[] {"IdRecuperoBeneficiario", "IdProgetto", "IdImpresa",
"Origine", "IdIrregolarita", "IdRevoca",
"IdErrore", "DecretoRecuperoNumero", "DecretoRecuperoData",
"DataAvvioRecupero", "SegnaturaPaleoComunicazioneBeneficiario", "Contributo",
"Interessi", "Spese", "Sanzioni",
"TotaleDaRecuperare", "Note", "Definitivo",
"ImportoRecuperato", "ImportoIrrecuperabile", "Stato",
"IdAttoRecupero", "IdAttoRateizzazione", "DataInizioRateizzazione",
"DataFineRateizzazione", "FlagImportoIrrecuperabile",
}, new string[] {"int", "int", "int",
"string", "int", "int",
"int", "string", "DateTime",
"DateTime", "string", "decimal",
"decimal", "decimal", "decimal",
"decimal", "string", "bool",
"decimal", "decimal", "string",
"int", "int", "DateTime",
"DateTime", "bool",
}, "");
                IDbCommand insertCmd = db.InitCmd("ZRecuperoBeneficiarioInsert", new string[] {"IdProgetto", "IdImpresa",
"Origine", "IdIrregolarita", "IdRevoca",
"IdErrore", "DecretoRecuperoNumero", "DecretoRecuperoData",
"DataAvvioRecupero", "SegnaturaPaleoComunicazioneBeneficiario", "Contributo",
"Interessi", "Spese", "Sanzioni",
"TotaleDaRecuperare", "Note", "Definitivo",
"ImportoRecuperato", "ImportoIrrecuperabile", "Stato",
"IdAttoRecupero", "IdAttoRateizzazione", "DataInizioRateizzazione",
"DataFineRateizzazione", "FlagImportoIrrecuperabile",
}, new string[] {"int", "int",
"string", "int", "int",
"int", "string", "DateTime",
"DateTime", "string", "decimal",
"decimal", "decimal", "decimal",
"decimal", "string", "bool",
"decimal", "decimal", "string",
"int", "int", "DateTime",
"DateTime", "bool",
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZRecuperoBeneficiarioDelete", new string[] { "IdRecuperoBeneficiario" }, new string[] { "int" }, "");
                for (int i = 0; i < RecuperoBeneficiarioCollectionObj.Count; i++)
                {
                    switch (RecuperoBeneficiarioCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, RecuperoBeneficiarioCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    RecuperoBeneficiarioCollectionObj[i].IdRecuperoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RECUPERO_BENEFICIARIO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, RecuperoBeneficiarioCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (RecuperoBeneficiarioCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRecuperoBeneficiario", (SiarLibrary.NullTypes.IntNT)RecuperoBeneficiarioCollectionObj[i].IdRecuperoBeneficiario);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < RecuperoBeneficiarioCollectionObj.Count; i++)
                {
                    if ((RecuperoBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RecuperoBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RecuperoBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        RecuperoBeneficiarioCollectionObj[i].IsDirty = false;
                        RecuperoBeneficiarioCollectionObj[i].IsPersistent = true;
                    }
                    if ((RecuperoBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        RecuperoBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RecuperoBeneficiarioCollectionObj[i].IsDirty = false;
                        RecuperoBeneficiarioCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, RecuperoBeneficiario RecuperoBeneficiarioObj)
        {
            int returnValue = 0;
            if (RecuperoBeneficiarioObj.IsPersistent)
            {
                returnValue = Delete(db, RecuperoBeneficiarioObj.IdRecuperoBeneficiario);
            }
            RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            RecuperoBeneficiarioObj.IsDirty = false;
            RecuperoBeneficiarioObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdRecuperoBeneficiarioValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRecuperoBeneficiarioDelete", new string[] { "IdRecuperoBeneficiario" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRecuperoBeneficiario", (SiarLibrary.NullTypes.IntNT)IdRecuperoBeneficiarioValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZRecuperoBeneficiarioDelete", new string[] { "IdRecuperoBeneficiario" }, new string[] { "int" }, "");
                for (int i = 0; i < RecuperoBeneficiarioCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdRecuperoBeneficiario", RecuperoBeneficiarioCollectionObj[i].IdRecuperoBeneficiario);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < RecuperoBeneficiarioCollectionObj.Count; i++)
                {
                    if ((RecuperoBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (RecuperoBeneficiarioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        RecuperoBeneficiarioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        RecuperoBeneficiarioCollectionObj[i].IsDirty = false;
                        RecuperoBeneficiarioCollectionObj[i].IsPersistent = false;
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
        public static RecuperoBeneficiario GetById(DbProvider db, int IdRecuperoBeneficiarioValue)
        {
            RecuperoBeneficiario RecuperoBeneficiarioObj = null;
            IDbCommand readCmd = db.InitCmd("ZRecuperoBeneficiarioGetById", new string[] { "IdRecuperoBeneficiario" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdRecuperoBeneficiario", (SiarLibrary.NullTypes.IntNT)IdRecuperoBeneficiarioValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                RecuperoBeneficiarioObj = GetFromDatareader(db);
                RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RecuperoBeneficiarioObj.IsDirty = false;
                RecuperoBeneficiarioObj.IsPersistent = true;
            }
            db.Close();
            return RecuperoBeneficiarioObj;
        }

        //getFromDatareader
        public static RecuperoBeneficiario GetFromDatareader(DbProvider db)
        {
            RecuperoBeneficiario RecuperoBeneficiarioObj = new RecuperoBeneficiario();
            RecuperoBeneficiarioObj.IdRecuperoBeneficiario = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RECUPERO_BENEFICIARIO"]);
            RecuperoBeneficiarioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            RecuperoBeneficiarioObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            RecuperoBeneficiarioObj.Origine = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORIGINE"]);
            RecuperoBeneficiarioObj.IdIrregolarita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IRREGOLARITA"]);
            RecuperoBeneficiarioObj.IdRevoca = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_REVOCA"]);
            RecuperoBeneficiarioObj.IdErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE"]);
            RecuperoBeneficiarioObj.DecretoRecuperoNumero = new SiarLibrary.NullTypes.StringNT(db.DataReader["DECRETO_RECUPERO_NUMERO"]);
            RecuperoBeneficiarioObj.DecretoRecuperoData = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DECRETO_RECUPERO_DATA"]);
            RecuperoBeneficiarioObj.DataAvvioRecupero = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_AVVIO_RECUPERO"]);
            RecuperoBeneficiarioObj.SegnaturaPaleoComunicazioneBeneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO"]);
            RecuperoBeneficiarioObj.Contributo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO"]);
            RecuperoBeneficiarioObj.Interessi = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["INTERESSI"]);
            RecuperoBeneficiarioObj.Spese = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESE"]);
            RecuperoBeneficiarioObj.Sanzioni = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SANZIONI"]);
            RecuperoBeneficiarioObj.TotaleDaRecuperare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOTALE_DA_RECUPERARE"]);
            RecuperoBeneficiarioObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            RecuperoBeneficiarioObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
            RecuperoBeneficiarioObj.ImportoRecuperato = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RECUPERATO"]);
            RecuperoBeneficiarioObj.ImportoIrrecuperabile = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_IRRECUPERABILE"]);
            RecuperoBeneficiarioObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            RecuperoBeneficiarioObj.IdAttoRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_RECUPERO"]);
            RecuperoBeneficiarioObj.IdAttoRateizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_RATEIZZAZIONE"]);
            RecuperoBeneficiarioObj.DataInizioRateizzazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_RATEIZZAZIONE"]);
            RecuperoBeneficiarioObj.DataFineRateizzazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_RATEIZZAZIONE"]);
            RecuperoBeneficiarioObj.FlagImportoIrrecuperabile = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FLAG_IMPORTO_IRRECUPERABILE"]);
            RecuperoBeneficiarioObj.RagioneSocialeImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE_IMPRESA"]);
            RecuperoBeneficiarioObj.NumerAttoRecupero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMER_ATTO_RECUPERO"]);
            RecuperoBeneficiarioObj.DataAttoRecupero = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTO_RECUPERO"]);
            RecuperoBeneficiarioObj.RegistroAttoRecupero = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO_ATTO_RECUPERO"]);
            RecuperoBeneficiarioObj.NumerAttoRateizzazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMER_ATTO_RATEIZZAZIONE"]);
            RecuperoBeneficiarioObj.DataAttoRateizzazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ATTO_RATEIZZAZIONE"]);
            RecuperoBeneficiarioObj.RegistroAttoRateizzazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO_ATTO_RATEIZZAZIONE"]);
            RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            RecuperoBeneficiarioObj.IsDirty = false;
            RecuperoBeneficiarioObj.IsPersistent = true;
            return RecuperoBeneficiarioObj;
        }

        //Find Select

        public static RecuperoBeneficiarioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRecuperoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.StringNT OrigineEqualThis, SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdRevocaEqualThis,
SiarLibrary.NullTypes.IntNT IdErroreEqualThis, SiarLibrary.NullTypes.StringNT DecretoRecuperoNumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DecretoRecuperoDataEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataAvvioRecuperoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaPaleoComunicazioneBeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoEqualThis,
SiarLibrary.NullTypes.DecimalNT InteressiEqualThis, SiarLibrary.NullTypes.DecimalNT SpeseEqualThis, SiarLibrary.NullTypes.DecimalNT SanzioniEqualThis,
SiarLibrary.NullTypes.DecimalNT TotaleDaRecuperareEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.BoolNT DefinitivoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoRecuperatoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoIrrecuperabileEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis,
SiarLibrary.NullTypes.IntNT IdAttoRecuperoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoRateizzazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInizioRateizzazioneEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataFineRateizzazioneEqualThis, SiarLibrary.NullTypes.BoolNT FlagImportoIrrecuperabileEqualThis)

        {

            RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionObj = new RecuperoBeneficiarioCollection();

            IDbCommand findCmd = db.InitCmd("Zrecuperobeneficiariofindselect", new string[] {"IdRecuperoBeneficiarioequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"Origineequalthis", "IdIrregolaritaequalthis", "IdRevocaequalthis",
"IdErroreequalthis", "DecretoRecuperoNumeroequalthis", "DecretoRecuperoDataequalthis",
"DataAvvioRecuperoequalthis", "SegnaturaPaleoComunicazioneBeneficiarioequalthis", "Contributoequalthis",
"Interessiequalthis", "Speseequalthis", "Sanzioniequalthis",
"TotaleDaRecuperareequalthis", "Noteequalthis", "Definitivoequalthis",
"ImportoRecuperatoequalthis", "ImportoIrrecuperabileequalthis", "Statoequalthis",
"IdAttoRecuperoequalthis", "IdAttoRateizzazioneequalthis", "DataInizioRateizzazioneequalthis",
"DataFineRateizzazioneequalthis", "FlagImportoIrrecuperabileequalthis"}, new string[] {"int", "int", "int",
"string", "int", "int",
"int", "string", "DateTime",
"DateTime", "string", "decimal",
"decimal", "decimal", "decimal",
"decimal", "string", "bool",
"decimal", "decimal", "string",
"int", "int", "DateTime",
"DateTime", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRecuperoBeneficiarioequalthis", IdRecuperoBeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Origineequalthis", OrigineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRevocaequalthis", IdRevocaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DecretoRecuperoNumeroequalthis", DecretoRecuperoNumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DecretoRecuperoDataequalthis", DecretoRecuperoDataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAvvioRecuperoequalthis", DataAvvioRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaPaleoComunicazioneBeneficiarioequalthis", SegnaturaPaleoComunicazioneBeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Contributoequalthis", ContributoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Interessiequalthis", InteressiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Speseequalthis", SpeseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Sanzioniequalthis", SanzioniEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotaleDaRecuperareequalthis", TotaleDaRecuperareEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Definitivoequalthis", DefinitivoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRecuperatoequalthis", ImportoRecuperatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoIrrecuperabileequalthis", ImportoIrrecuperabileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoRecuperoequalthis", IdAttoRecuperoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoRateizzazioneequalthis", IdAttoRateizzazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioRateizzazioneequalthis", DataInizioRateizzazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineRateizzazioneequalthis", DataFineRateizzazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FlagImportoIrrecuperabileequalthis", FlagImportoIrrecuperabileEqualThis);
            RecuperoBeneficiario RecuperoBeneficiarioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RecuperoBeneficiarioObj = GetFromDatareader(db);
                RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RecuperoBeneficiarioObj.IsDirty = false;
                RecuperoBeneficiarioObj.IsPersistent = true;
                RecuperoBeneficiarioCollectionObj.Add(RecuperoBeneficiarioObj);
            }
            db.Close();
            return RecuperoBeneficiarioCollectionObj;
        }

        //Find Find

        public static RecuperoBeneficiarioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdRecuperoBeneficiarioEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdIrregolaritaEqualThis, SiarLibrary.NullTypes.IntNT IdRevocaEqualThis, SiarLibrary.NullTypes.IntNT IdErroreEqualThis)

        {

            RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionObj = new RecuperoBeneficiarioCollection();

            IDbCommand findCmd = db.InitCmd("Zrecuperobeneficiariofindfind", new string[] {"IdRecuperoBeneficiarioequalthis", "IdProgettoequalthis", "IdImpresaequalthis",
"IdIrregolaritaequalthis", "IdRevocaequalthis", "IdErroreequalthis"}, new string[] {"int", "int", "int",
"int", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRecuperoBeneficiarioequalthis", IdRecuperoBeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIrregolaritaequalthis", IdIrregolaritaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdRevocaequalthis", IdRevocaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
            RecuperoBeneficiario RecuperoBeneficiarioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                RecuperoBeneficiarioObj = GetFromDatareader(db);
                RecuperoBeneficiarioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                RecuperoBeneficiarioObj.IsDirty = false;
                RecuperoBeneficiarioObj.IsPersistent = true;
                RecuperoBeneficiarioCollectionObj.Add(RecuperoBeneficiarioObj);
            }
            db.Close();
            return RecuperoBeneficiarioCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for RecuperoBeneficiarioCollectionProvider:IRecuperoBeneficiarioProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class RecuperoBeneficiarioCollectionProvider : IRecuperoBeneficiarioProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di RecuperoBeneficiario
        protected RecuperoBeneficiarioCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public RecuperoBeneficiarioCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new RecuperoBeneficiarioCollection(this);
        }

        //Costruttore 2: popola la collection
        public RecuperoBeneficiarioCollectionProvider(IntNT IdrecuperobeneficiarioEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdirregolaritaEqualThis, IntNT IdrevocaEqualThis, IntNT IderroreEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdrecuperobeneficiarioEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdirregolaritaEqualThis, IdrevocaEqualThis, IderroreEqualThis);
        }

        //Costruttore3: ha in input recuperobeneficiarioCollectionObj - non popola la collection
        public RecuperoBeneficiarioCollectionProvider(RecuperoBeneficiarioCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public RecuperoBeneficiarioCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new RecuperoBeneficiarioCollection(this);
        }

        //Get e Set
        public RecuperoBeneficiarioCollection CollectionObj
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
        public int SaveCollection(RecuperoBeneficiarioCollection collectionObj)
        {
            return RecuperoBeneficiarioDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(RecuperoBeneficiario recuperobeneficiarioObj)
        {
            return RecuperoBeneficiarioDAL.Save(_dbProviderObj, recuperobeneficiarioObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(RecuperoBeneficiarioCollection collectionObj)
        {
            return RecuperoBeneficiarioDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(RecuperoBeneficiario recuperobeneficiarioObj)
        {
            return RecuperoBeneficiarioDAL.Delete(_dbProviderObj, recuperobeneficiarioObj);
        }

        //getById
        public RecuperoBeneficiario GetById(IntNT IdRecuperoBeneficiarioValue)
        {
            RecuperoBeneficiario RecuperoBeneficiarioTemp = RecuperoBeneficiarioDAL.GetById(_dbProviderObj, IdRecuperoBeneficiarioValue);
            if (RecuperoBeneficiarioTemp != null) RecuperoBeneficiarioTemp.Provider = this;
            return RecuperoBeneficiarioTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public RecuperoBeneficiarioCollection Select(IntNT IdrecuperobeneficiarioEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
StringNT OrigineEqualThis, IntNT IdirregolaritaEqualThis, IntNT IdrevocaEqualThis,
IntNT IderroreEqualThis, StringNT DecretorecuperonumeroEqualThis, DatetimeNT DecretorecuperodataEqualThis,
DatetimeNT DataavviorecuperoEqualThis, StringNT SegnaturapaleocomunicazionebeneficiarioEqualThis, DecimalNT ContributoEqualThis,
DecimalNT InteressiEqualThis, DecimalNT SpeseEqualThis, DecimalNT SanzioniEqualThis,
DecimalNT TotaledarecuperareEqualThis, StringNT NoteEqualThis, BoolNT DefinitivoEqualThis,
DecimalNT ImportorecuperatoEqualThis, DecimalNT ImportoirrecuperabileEqualThis, StringNT StatoEqualThis,
IntNT IdattorecuperoEqualThis, IntNT IdattorateizzazioneEqualThis, DatetimeNT DatainiziorateizzazioneEqualThis,
DatetimeNT DatafinerateizzazioneEqualThis, BoolNT FlagimportoirrecuperabileEqualThis)
        {
            RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionTemp = RecuperoBeneficiarioDAL.Select(_dbProviderObj, IdrecuperobeneficiarioEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
OrigineEqualThis, IdirregolaritaEqualThis, IdrevocaEqualThis,
IderroreEqualThis, DecretorecuperonumeroEqualThis, DecretorecuperodataEqualThis,
DataavviorecuperoEqualThis, SegnaturapaleocomunicazionebeneficiarioEqualThis, ContributoEqualThis,
InteressiEqualThis, SpeseEqualThis, SanzioniEqualThis,
TotaledarecuperareEqualThis, NoteEqualThis, DefinitivoEqualThis,
ImportorecuperatoEqualThis, ImportoirrecuperabileEqualThis, StatoEqualThis,
IdattorecuperoEqualThis, IdattorateizzazioneEqualThis, DatainiziorateizzazioneEqualThis,
DatafinerateizzazioneEqualThis, FlagimportoirrecuperabileEqualThis);
            RecuperoBeneficiarioCollectionTemp.Provider = this;
            return RecuperoBeneficiarioCollectionTemp;
        }

        //Find: popola la collection
        public RecuperoBeneficiarioCollection Find(IntNT IdrecuperobeneficiarioEqualThis, IntNT IdprogettoEqualThis, IntNT IdimpresaEqualThis,
IntNT IdirregolaritaEqualThis, IntNT IdrevocaEqualThis, IntNT IderroreEqualThis)
        {
            RecuperoBeneficiarioCollection RecuperoBeneficiarioCollectionTemp = RecuperoBeneficiarioDAL.Find(_dbProviderObj, IdrecuperobeneficiarioEqualThis, IdprogettoEqualThis, IdimpresaEqualThis,
IdirregolaritaEqualThis, IdrevocaEqualThis, IderroreEqualThis);
            RecuperoBeneficiarioCollectionTemp.Provider = this;
            return RecuperoBeneficiarioCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<RECUPERO_BENEFICIARIO>
  <ViewName>VRECUPERO_BENEFICIARIO</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_RECUPERO_BENEFICIARIO>Equal</ID_RECUPERO_BENEFICIARIO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_IRREGOLARITA>Equal</ID_IRREGOLARITA>
      <ID_REVOCA>Equal</ID_REVOCA>
      <ID_ERRORE>Equal</ID_ERRORE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</RECUPERO_BENEFICIARIO>
*/
