using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Bando
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IBandoProvider
    {
        int Save(Bando BandoObj);
        int SaveCollection(BandoCollection collectionObj);
        int Delete(Bando BandoObj);
        int DeleteCollection(BandoCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Bando
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Bando : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _ParoleChiave;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.BoolNT _DisposizioniAttuative;
        private NullTypes.IntNT _IdSchedaValutazione;
        private NullTypes.BoolNT _Multiprogetto;
        private NullTypes.BoolNT _Multimisura;
        private NullTypes.BoolNT _InteresseFiliera;
        private NullTypes.BoolNT _FascicoloRichiesto;
        private NullTypes.IntNT _IdStoricoUltimo;
        private NullTypes.DatetimeNT _DataApertura;
        private NullTypes.IntNT _IdModelloDomanda;
        private NullTypes.IntNT _IdProgrammazione;
        private NullTypes.IntNT _IdIntegrazioneUltima;
        private NullTypes.DatetimeNT _DataScadenza;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.DecimalNT _ImportoDiMisura;
        private NullTypes.DecimalNT _QuotaRiserva;
        private NullTypes.IntNT _IdAttoIntegrazione;
        private NullTypes.StringNT _CodStato;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.IntNT _Operatore;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.IntNT _OrdineStato;
        private NullTypes.StringNT _Stato;
        private NullTypes.StringNT _Profilo;
        private NullTypes.StringNT _Nominativo;
        private NullTypes.StringNT _CodTipoEnte;
        private NullTypes.StringNT _Ente;
        private NullTypes.BoolNT _FirmaRichiesta;
        private NullTypes.BoolNT _AbilitaValutazione;
        private NullTypes.BoolNT _Aggregazione;
        [NonSerialized] private IBandoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IBandoProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Bando()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_BANDO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdBando
        {
            get { return _IdBando; }
            set
            {
                if (IdBando != value)
                {
                    _IdBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_ENTE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnte
        {
            get { return _CodEnte; }
            set
            {
                if (CodEnte != value)
                {
                    _CodEnte = value;
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
        /// Corrisponde al campo:PAROLE_CHIAVE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT ParoleChiave
        {
            get { return _ParoleChiave; }
            set
            {
                if (ParoleChiave != value)
                {
                    _ParoleChiave = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
        /// </summary>
        public NullTypes.DatetimeNT DataInserimento
        {
            get { return _DataInserimento; }
            set
            {
                if (DataInserimento != value)
                {
                    _DataInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DISPOSIZIONI_ATTUATIVE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT DisposizioniAttuative
        {
            get { return _DisposizioniAttuative; }
            set
            {
                if (DisposizioniAttuative != value)
                {
                    _DisposizioniAttuative = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_SCHEDA_VALUTAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdSchedaValutazione
        {
            get { return _IdSchedaValutazione; }
            set
            {
                if (IdSchedaValutazione != value)
                {
                    _IdSchedaValutazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MULTIPROGETTO
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Multiprogetto
        {
            get { return _Multiprogetto; }
            set
            {
                if (Multiprogetto != value)
                {
                    _Multiprogetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:MULTIMISURA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Multimisura
        {
            get { return _Multimisura; }
            set
            {
                if (Multimisura != value)
                {
                    _Multimisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INTERESSE_FILIERA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT InteresseFiliera
        {
            get { return _InteresseFiliera; }
            set
            {
                if (InteresseFiliera != value)
                {
                    _InteresseFiliera = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FASCICOLO_RICHIESTO
        /// Tipo sul db:BIT
        /// Default:((1))
        /// </summary>
        public NullTypes.BoolNT FascicoloRichiesto
        {
            get { return _FascicoloRichiesto; }
            set
            {
                if (FascicoloRichiesto != value)
                {
                    _FascicoloRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_STORICO_ULTIMO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdStoricoUltimo
        {
            get { return _IdStoricoUltimo; }
            set
            {
                if (IdStoricoUltimo != value)
                {
                    _IdStoricoUltimo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_APERTURA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataApertura
        {
            get { return _DataApertura; }
            set
            {
                if (DataApertura != value)
                {
                    _DataApertura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_MODELLO_DOMANDA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdModelloDomanda
        {
            get { return _IdModelloDomanda; }
            set
            {
                if (IdModelloDomanda != value)
                {
                    _IdModelloDomanda = value;
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
        /// Corrisponde al campo:ID_INTEGRAZIONE_ULTIMA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdIntegrazioneUltima
        {
            get { return _IdIntegrazioneUltima; }
            set
            {
                if (IdIntegrazioneUltima != value)
                {
                    _IdIntegrazioneUltima = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SCADENZA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataScadenza
        {
            get { return _DataScadenza; }
            set
            {
                if (DataScadenza != value)
                {
                    _DataScadenza = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT Importo
        {
            get { return _Importo; }
            set
            {
                if (Importo != value)
                {
                    _Importo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DI_MISURA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDiMisura
        {
            get { return _ImportoDiMisura; }
            set
            {
                if (ImportoDiMisura != value)
                {
                    _ImportoDiMisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:QUOTA_RISERVA
        /// Tipo sul db:DECIMAL(10,2)
        /// </summary>
        public NullTypes.DecimalNT QuotaRiserva
        {
            get { return _QuotaRiserva; }
            set
            {
                if (QuotaRiserva != value)
                {
                    _QuotaRiserva = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_INTEGRAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoIntegrazione
        {
            get { return _IdAttoIntegrazione; }
            set
            {
                if (IdAttoIntegrazione != value)
                {
                    _IdAttoIntegrazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_STATO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodStato
        {
            get { return _CodStato; }
            set
            {
                if (CodStato != value)
                {
                    _CodStato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT Data
        {
            get { return _Data; }
            set
            {
                if (Data != value)
                {
                    _Data = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Operatore
        {
            get { return _Operatore; }
            set
            {
                if (Operatore != value)
                {
                    _Operatore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT Segnatura
        {
            get { return _Segnatura; }
            set
            {
                if (Segnatura != value)
                {
                    _Segnatura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAtto
        {
            get { return _IdAtto; }
            set
            {
                if (IdAtto != value)
                {
                    _IdAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE_STATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OrdineStato
        {
            get { return _OrdineStato; }
            set
            {
                if (OrdineStato != value)
                {
                    _OrdineStato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO
        /// Tipo sul db:VARCHAR(50)
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
        /// Corrisponde al campo:PROFILO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Profilo
        {
            get { return _Profilo; }
            set
            {
                if (Profilo != value)
                {
                    _Profilo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT Nominativo
        {
            get { return _Nominativo; }
            set
            {
                if (Nominativo != value)
                {
                    _Nominativo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO_ENTE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodTipoEnte
        {
            get { return _CodTipoEnte; }
            set
            {
                if (CodTipoEnte != value)
                {
                    _CodTipoEnte = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ENTE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Ente
        {
            get { return _Ente; }
            set
            {
                if (Ente != value)
                {
                    _Ente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FIRMA_RICHIESTA
        /// Tipo sul db:BIT
        /// Default:((1))
        /// </summary>
        public NullTypes.BoolNT FirmaRichiesta
        {
            get { return _FirmaRichiesta; }
            set
            {
                if (FirmaRichiesta != value)
                {
                    _FirmaRichiesta = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ABILITA_VALUTAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT AbilitaValutazione
        {
            get { return _AbilitaValutazione; }
            set
            {
                if (AbilitaValutazione != value)
                {
                    _AbilitaValutazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AGGREGAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT Aggregazione
        {
            get { return _Aggregazione; }
            set
            {
                if (Aggregazione != value)
                {
                    _Aggregazione = value;
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
    /// Summary description for BandoCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class BandoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private BandoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Bando)info.GetValue(i.ToString(), typeof(Bando)));
            }
        }

        //Costruttore
        public BandoCollection()
        {
            this.ItemType = typeof(Bando);
        }

        //Costruttore con provider
        public BandoCollection(IBandoProvider providerObj)
        {
            this.ItemType = typeof(Bando);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Bando this[int index]
        {
            get { return (Bando)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new BandoCollection GetChanges()
        {
            return (BandoCollection)base.GetChanges();
        }

        [NonSerialized] private IBandoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IBandoProvider Provider
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
        public int Add(Bando BandoObj)
        {
            if (BandoObj.Provider == null) BandoObj.Provider = this.Provider;
            return base.Add(BandoObj);
        }

        //AddCollection
        public void AddCollection(BandoCollection BandoCollectionObj)
        {
            foreach (Bando BandoObj in BandoCollectionObj)
                this.Add(BandoObj);
        }

        //Insert
        public void Insert(int index, Bando BandoObj)
        {
            if (BandoObj.Provider == null) BandoObj.Provider = this.Provider;
            base.Insert(index, BandoObj);
        }

        //CollectionGetById
        public Bando CollectionGetById(NullTypes.IntNT IdBandoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdBando == IdBandoValue))
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
        public BandoCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT DescrizioneEqualThis,
NullTypes.StringNT ParoleChiaveEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.DatetimeNT DataAperturaEqualThis,
NullTypes.BoolNT DisposizioniAttuativeEqualThis, NullTypes.IntNT IdSchedaValutazioneEqualThis, NullTypes.IntNT IdModelloDomandaEqualThis,
NullTypes.IntNT IdProgrammazioneEqualThis, NullTypes.BoolNT MultiprogettoEqualThis, NullTypes.BoolNT MultimisuraEqualThis,
NullTypes.BoolNT InteresseFilieraEqualThis, NullTypes.BoolNT FascicoloRichiestoEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis,
NullTypes.IntNT IdIntegrazioneUltimaEqualThis, NullTypes.BoolNT FirmaRichiestaEqualThis, NullTypes.BoolNT AbilitaValutazioneEqualThis,
NullTypes.BoolNT AggregazioneEqualThis)
        {
            BandoCollection BandoCollectionTemp = new BandoCollection();
            foreach (Bando BandoItem in this)
            {
                if (((IdBandoEqualThis == null) || ((BandoItem.IdBando != null) && (BandoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodEnteEqualThis == null) || ((BandoItem.CodEnte != null) && (BandoItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((BandoItem.Descrizione != null) && (BandoItem.Descrizione.Value == DescrizioneEqualThis.Value))) &&
((ParoleChiaveEqualThis == null) || ((BandoItem.ParoleChiave != null) && (BandoItem.ParoleChiave.Value == ParoleChiaveEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((BandoItem.DataInserimento != null) && (BandoItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DataAperturaEqualThis == null) || ((BandoItem.DataApertura != null) && (BandoItem.DataApertura.Value == DataAperturaEqualThis.Value))) &&
((DisposizioniAttuativeEqualThis == null) || ((BandoItem.DisposizioniAttuative != null) && (BandoItem.DisposizioniAttuative.Value == DisposizioniAttuativeEqualThis.Value))) && ((IdSchedaValutazioneEqualThis == null) || ((BandoItem.IdSchedaValutazione != null) && (BandoItem.IdSchedaValutazione.Value == IdSchedaValutazioneEqualThis.Value))) && ((IdModelloDomandaEqualThis == null) || ((BandoItem.IdModelloDomanda != null) && (BandoItem.IdModelloDomanda.Value == IdModelloDomandaEqualThis.Value))) &&
((IdProgrammazioneEqualThis == null) || ((BandoItem.IdProgrammazione != null) && (BandoItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) && ((MultiprogettoEqualThis == null) || ((BandoItem.Multiprogetto != null) && (BandoItem.Multiprogetto.Value == MultiprogettoEqualThis.Value))) && ((MultimisuraEqualThis == null) || ((BandoItem.Multimisura != null) && (BandoItem.Multimisura.Value == MultimisuraEqualThis.Value))) &&
((InteresseFilieraEqualThis == null) || ((BandoItem.InteresseFiliera != null) && (BandoItem.InteresseFiliera.Value == InteresseFilieraEqualThis.Value))) && ((FascicoloRichiestoEqualThis == null) || ((BandoItem.FascicoloRichiesto != null) && (BandoItem.FascicoloRichiesto.Value == FascicoloRichiestoEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((BandoItem.IdStoricoUltimo != null) && (BandoItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))) &&
((IdIntegrazioneUltimaEqualThis == null) || ((BandoItem.IdIntegrazioneUltima != null) && (BandoItem.IdIntegrazioneUltima.Value == IdIntegrazioneUltimaEqualThis.Value))) && ((FirmaRichiestaEqualThis == null) || ((BandoItem.FirmaRichiesta != null) && (BandoItem.FirmaRichiesta.Value == FirmaRichiestaEqualThis.Value))) && ((AbilitaValutazioneEqualThis == null) || ((BandoItem.AbilitaValutazione != null) && (BandoItem.AbilitaValutazione.Value == AbilitaValutazioneEqualThis.Value))) &&
((AggregazioneEqualThis == null) || ((BandoItem.Aggregazione != null) && (BandoItem.Aggregazione.Value == AggregazioneEqualThis.Value))))
                {
                    BandoCollectionTemp.Add(BandoItem);
                }
            }
            return BandoCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for BandoDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class BandoDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Bando BandoObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdBando", BandoObj.IdBando);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnte", BandoObj.CodEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", BandoObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "ParoleChiave", BandoObj.ParoleChiave);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", BandoObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DisposizioniAttuative", BandoObj.DisposizioniAttuative);
            DbProvider.SetCmdParam(cmd, firstChar + "IdSchedaValutazione", BandoObj.IdSchedaValutazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Multiprogetto", BandoObj.Multiprogetto);
            DbProvider.SetCmdParam(cmd, firstChar + "Multimisura", BandoObj.Multimisura);
            DbProvider.SetCmdParam(cmd, firstChar + "InteresseFiliera", BandoObj.InteresseFiliera);
            DbProvider.SetCmdParam(cmd, firstChar + "FascicoloRichiesto", BandoObj.FascicoloRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdStoricoUltimo", BandoObj.IdStoricoUltimo);
            DbProvider.SetCmdParam(cmd, firstChar + "DataApertura", BandoObj.DataApertura);
            DbProvider.SetCmdParam(cmd, firstChar + "IdModelloDomanda", BandoObj.IdModelloDomanda);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgrammazione", BandoObj.IdProgrammazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdIntegrazioneUltima", BandoObj.IdIntegrazioneUltima);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaRichiesta", BandoObj.FirmaRichiesta);
            DbProvider.SetCmdParam(cmd, firstChar + "AbilitaValutazione", BandoObj.AbilitaValutazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Aggregazione", BandoObj.Aggregazione);
        }
        //Insert
        private static int Insert(DbProvider db, Bando BandoObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZBandoInsert", new string[] {"CodEnte", "Descrizione",
"ParoleChiave", "DataInserimento", "DisposizioniAttuative",
"IdSchedaValutazione", "Multiprogetto", "Multimisura",
"InteresseFiliera", "FascicoloRichiesto", "IdStoricoUltimo",
"DataApertura", "IdModelloDomanda", "IdProgrammazione",
"IdIntegrazioneUltima",




"FirmaRichiesta",
"AbilitaValutazione", "Aggregazione"}, new string[] {"string", "string",
"string", "DateTime", "bool",
"int", "bool", "bool",
"bool", "bool", "int",
"DateTime", "int", "int",
"int",




"bool",
"bool", "bool"}, "");
                CompileIUCmd(false, insertCmd, BandoObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    BandoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
                    BandoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    BandoObj.DisposizioniAttuative = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DISPOSIZIONI_ATTUATIVE"]);
                    BandoObj.Multiprogetto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIPROGETTO"]);
                    BandoObj.Multimisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIMISURA"]);
                    BandoObj.InteresseFiliera = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTERESSE_FILIERA"]);
                    BandoObj.FascicoloRichiesto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FASCICOLO_RICHIESTO"]);
                    BandoObj.FirmaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_RICHIESTA"]);
                    BandoObj.AbilitaValutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_VALUTAZIONE"]);
                    BandoObj.Aggregazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AGGREGAZIONE"]);
                }
                BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                BandoObj.IsDirty = false;
                BandoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Bando BandoObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZBandoUpdate", new string[] {"IdBando", "CodEnte", "Descrizione",
"ParoleChiave", "DataInserimento", "DisposizioniAttuative",
"IdSchedaValutazione", "Multiprogetto", "Multimisura",
"InteresseFiliera", "FascicoloRichiesto", "IdStoricoUltimo",
"DataApertura", "IdModelloDomanda", "IdProgrammazione",
"IdIntegrazioneUltima",




"FirmaRichiesta",
"AbilitaValutazione", "Aggregazione"}, new string[] {"int", "string", "string",
"string", "DateTime", "bool",
"int", "bool", "bool",
"bool", "bool", "int",
"DateTime", "int", "int",
"int",




"bool",
"bool", "bool"}, "");
                CompileIUCmd(true, updateCmd, BandoObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                BandoObj.IsDirty = false;
                BandoObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Bando BandoObj)
        {
            switch (BandoObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, BandoObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, BandoObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, BandoObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, BandoCollection BandoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZBandoUpdate", new string[] {"IdBando", "CodEnte", "Descrizione",
"ParoleChiave", "DataInserimento", "DisposizioniAttuative",
"IdSchedaValutazione", "Multiprogetto", "Multimisura",
"InteresseFiliera", "FascicoloRichiesto", "IdStoricoUltimo",
"DataApertura", "IdModelloDomanda", "IdProgrammazione",
"IdIntegrazioneUltima",




"FirmaRichiesta",
"AbilitaValutazione", "Aggregazione"}, new string[] {"int", "string", "string",
"string", "DateTime", "bool",
"int", "bool", "bool",
"bool", "bool", "int",
"DateTime", "int", "int",
"int",




"bool",
"bool", "bool"}, "");
                IDbCommand insertCmd = db.InitCmd("ZBandoInsert", new string[] {"CodEnte", "Descrizione",
"ParoleChiave", "DataInserimento", "DisposizioniAttuative",
"IdSchedaValutazione", "Multiprogetto", "Multimisura",
"InteresseFiliera", "FascicoloRichiesto", "IdStoricoUltimo",
"DataApertura", "IdModelloDomanda", "IdProgrammazione",
"IdIntegrazioneUltima",




"FirmaRichiesta",
"AbilitaValutazione", "Aggregazione"}, new string[] {"string", "string",
"string", "DateTime", "bool",
"int", "bool", "bool",
"bool", "bool", "int",
"DateTime", "int", "int",
"int",




"bool",
"bool", "bool"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZBandoDelete", new string[] { "IdBando" }, new string[] { "int" }, "");
                for (int i = 0; i < BandoCollectionObj.Count; i++)
                {
                    switch (BandoCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, BandoCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    BandoCollectionObj[i].IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
                                    BandoCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    BandoCollectionObj[i].DisposizioniAttuative = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DISPOSIZIONI_ATTUATIVE"]);
                                    BandoCollectionObj[i].Multiprogetto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIPROGETTO"]);
                                    BandoCollectionObj[i].Multimisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIMISURA"]);
                                    BandoCollectionObj[i].InteresseFiliera = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTERESSE_FILIERA"]);
                                    BandoCollectionObj[i].FascicoloRichiesto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FASCICOLO_RICHIESTO"]);
                                    BandoCollectionObj[i].FirmaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_RICHIESTA"]);
                                    BandoCollectionObj[i].AbilitaValutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_VALUTAZIONE"]);
                                    BandoCollectionObj[i].Aggregazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AGGREGAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, BandoCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (BandoCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)BandoCollectionObj[i].IdBando);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < BandoCollectionObj.Count; i++)
                {
                    if ((BandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        BandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        BandoCollectionObj[i].IsDirty = false;
                        BandoCollectionObj[i].IsPersistent = true;
                    }
                    if ((BandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        BandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        BandoCollectionObj[i].IsDirty = false;
                        BandoCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Bando BandoObj)
        {
            int returnValue = 0;
            if (BandoObj.IsPersistent)
            {
                returnValue = Delete(db, BandoObj.IdBando);
            }
            BandoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            BandoObj.IsDirty = false;
            BandoObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdBandoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZBandoDelete", new string[] { "IdBando" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, BandoCollection BandoCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZBandoDelete", new string[] { "IdBando" }, new string[] { "int" }, "");
                for (int i = 0; i < BandoCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdBando", BandoCollectionObj[i].IdBando);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < BandoCollectionObj.Count; i++)
                {
                    if ((BandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (BandoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        BandoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        BandoCollectionObj[i].IsDirty = false;
                        BandoCollectionObj[i].IsPersistent = false;
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
        public static Bando GetById(DbProvider db, int IdBandoValue)
        {
            Bando BandoObj = null;
            IDbCommand readCmd = db.InitCmd("ZBandoGetById", new string[] { "IdBando" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdBando", (SiarLibrary.NullTypes.IntNT)IdBandoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                BandoObj = GetFromDatareader(db);
                BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                BandoObj.IsDirty = false;
                BandoObj.IsPersistent = true;
            }
            db.Close();
            return BandoObj;
        }

        //getFromDatareader
        public static Bando GetFromDatareader(DbProvider db)
        {
            Bando BandoObj = new Bando();
            BandoObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            BandoObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            BandoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            BandoObj.ParoleChiave = new SiarLibrary.NullTypes.StringNT(db.DataReader["PAROLE_CHIAVE"]);
            BandoObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            BandoObj.DisposizioniAttuative = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DISPOSIZIONI_ATTUATIVE"]);
            BandoObj.IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
            BandoObj.Multiprogetto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIPROGETTO"]);
            BandoObj.Multimisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIMISURA"]);
            BandoObj.InteresseFiliera = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTERESSE_FILIERA"]);
            BandoObj.FascicoloRichiesto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FASCICOLO_RICHIESTO"]);
            BandoObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
            BandoObj.DataApertura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA"]);
            BandoObj.IdModelloDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODELLO_DOMANDA"]);
            BandoObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
            BandoObj.IdIntegrazioneUltima = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_ULTIMA"]);
            BandoObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
            BandoObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            BandoObj.ImportoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DI_MISURA"]);
            BandoObj.QuotaRiserva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_RISERVA"]);
            BandoObj.IdAttoIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_INTEGRAZIONE"]);
            BandoObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
            BandoObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            BandoObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            BandoObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            BandoObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            BandoObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
            BandoObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            BandoObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
            BandoObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            BandoObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
            BandoObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
            BandoObj.FirmaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_RICHIESTA"]);
            BandoObj.AbilitaValutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_VALUTAZIONE"]);
            BandoObj.Aggregazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AGGREGAZIONE"]);
            BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            BandoObj.IsDirty = false;
            BandoObj.IsPersistent = true;
            return BandoObj;
        }

        //Find Select

        public static BandoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis,
SiarLibrary.NullTypes.StringNT ParoleChiaveEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAperturaEqualThis,
SiarLibrary.NullTypes.BoolNT DisposizioniAttuativeEqualThis, SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.IntNT IdModelloDomandaEqualThis,
SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.BoolNT MultiprogettoEqualThis, SiarLibrary.NullTypes.BoolNT MultimisuraEqualThis,
SiarLibrary.NullTypes.BoolNT InteresseFilieraEqualThis, SiarLibrary.NullTypes.BoolNT FascicoloRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis,
SiarLibrary.NullTypes.IntNT IdIntegrazioneUltimaEqualThis, SiarLibrary.NullTypes.BoolNT FirmaRichiestaEqualThis, SiarLibrary.NullTypes.BoolNT AbilitaValutazioneEqualThis,
SiarLibrary.NullTypes.BoolNT AggregazioneEqualThis)

        {

            BandoCollection BandoCollectionObj = new BandoCollection();

            IDbCommand findCmd = db.InitCmd("Zbandofindselect", new string[] {"IdBandoequalthis", "CodEnteequalthis", "Descrizioneequalthis",
"ParoleChiaveequalthis", "DataInserimentoequalthis", "DataAperturaequalthis",
"DisposizioniAttuativeequalthis", "IdSchedaValutazioneequalthis", "IdModelloDomandaequalthis",
"IdProgrammazioneequalthis", "Multiprogettoequalthis", "Multimisuraequalthis",
"InteresseFilieraequalthis", "FascicoloRichiestoequalthis", "IdStoricoUltimoequalthis",
"IdIntegrazioneUltimaequalthis", "FirmaRichiestaequalthis", "AbilitaValutazioneequalthis",
"Aggregazioneequalthis"}, new string[] {"int", "string", "string",
"string", "DateTime", "DateTime",
"bool", "int", "int",
"int", "bool", "bool",
"bool", "bool", "int",
"int", "bool", "bool",
"bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ParoleChiaveequalthis", ParoleChiaveEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAperturaequalthis", DataAperturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DisposizioniAttuativeequalthis", DisposizioniAttuativeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModelloDomandaequalthis", IdModelloDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multiprogettoequalthis", MultiprogettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multimisuraequalthis", MultimisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InteresseFilieraequalthis", InteresseFilieraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FascicoloRichiestoequalthis", FascicoloRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIntegrazioneUltimaequalthis", IdIntegrazioneUltimaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaRichiestaequalthis", FirmaRichiestaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AbilitaValutazioneequalthis", AbilitaValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Aggregazioneequalthis", AggregazioneEqualThis);
            Bando BandoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                BandoObj = GetFromDatareader(db);
                BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                BandoObj.IsDirty = false;
                BandoObj.IsPersistent = true;
                BandoCollectionObj.Add(BandoObj);
            }
            db.Close();
            return BandoCollectionObj;
        }

        //Find Find

        public static BandoCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqGreaterThanThis,
SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqLessThanThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.BoolNT MultiprogettoEqualThis,
SiarLibrary.NullTypes.BoolNT MultimisuraEqualThis, SiarLibrary.NullTypes.BoolNT DisposizioniAttuativeEqualThis, SiarLibrary.NullTypes.StringNT ParoleChiaveLikeThis)

        {

            BandoCollection BandoCollectionObj = new BandoCollection();

            IDbCommand findCmd = db.InitCmd("Zbandofindfind", new string[] {"CodEnteequalthis", "CodStatoequalthis", "OrdineStatoeqgreaterthanthis",
"DataScadenzaeqlessthanthis", "IdProgrammazioneequalthis", "Multiprogettoequalthis",
"Multimisuraequalthis", "DisposizioniAttuativeequalthis", "ParoleChiavelikethis"}, new string[] {"string", "string", "int",
"DateTime", "int", "bool",
"bool", "bool", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineStatoeqgreaterthanthis", OrdineStatoEqGreaterThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaeqlessthanthis", DataScadenzaEqLessThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multiprogettoequalthis", MultiprogettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multimisuraequalthis", MultimisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DisposizioniAttuativeequalthis", DisposizioniAttuativeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ParoleChiavelikethis", ParoleChiaveLikeThis);
            Bando BandoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                BandoObj = GetFromDatareader(db);
                BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                BandoObj.IsDirty = false;
                BandoObj.IsPersistent = true;
                BandoCollectionObj.Add(BandoObj);
            }
            db.Close();
            return BandoCollectionObj;
        }

        //Find Find2

        public static BandoCollection Find2(DbProvider db, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqGreaterThanThis,
SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqLessThanThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis, SiarLibrary.NullTypes.BoolNT MultiprogettoEqualThis,
SiarLibrary.NullTypes.BoolNT MultimisuraEqualThis, SiarLibrary.NullTypes.BoolNT DisposizioniAttuativeEqualThis, SiarLibrary.NullTypes.StringNT ParoleChiaveLikeThis,
SiarLibrary.NullTypes.IntNT IdBandoEqualThis)

        {

            BandoCollection BandoCollectionObj = new BandoCollection();

            IDbCommand findCmd = db.InitCmd("Zbandofindfind2", new string[] {"CodEnteequalthis", "CodStatoequalthis", "OrdineStatoeqgreaterthanthis",
"DataScadenzaeqlessthanthis", "IdProgrammazioneequalthis", "Multiprogettoequalthis",
"Multimisuraequalthis", "DisposizioniAttuativeequalthis", "ParoleChiavelikethis",
"IdBandoequalthis"}, new string[] {"string", "string", "int",
"DateTime", "int", "bool",
"bool", "bool", "string",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineStatoeqgreaterthanthis", OrdineStatoEqGreaterThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaeqlessthanthis", DataScadenzaEqLessThanThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multiprogettoequalthis", MultiprogettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multimisuraequalthis", MultimisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DisposizioniAttuativeequalthis", DisposizioniAttuativeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ParoleChiavelikethis", ParoleChiaveLikeThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            Bando BandoObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                BandoObj = GetFromDatareader(db);
                BandoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                BandoObj.IsDirty = false;
                BandoObj.IsPersistent = true;
                BandoCollectionObj.Add(BandoObj);
            }
            db.Close();
            return BandoCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for BandoCollectionProvider:IBandoProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class BandoCollectionProvider : IBandoProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Bando
        protected BandoCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public BandoCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new BandoCollection(this);
        }

        //Costruttore 2: popola la collection
        public BandoCollectionProvider(StringNT CodenteEqualThis, StringNT CodstatoEqualThis, IntNT OrdinestatoEqGreaterThanThis,
DatetimeNT DatascadenzaEqLessThanThis, IntNT IdprogrammazioneEqualThis, BoolNT MultiprogettoEqualThis,
BoolNT MultimisuraEqualThis, BoolNT DisposizioniattuativeEqualThis, StringNT ParolechiaveLikeThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(CodenteEqualThis, CodstatoEqualThis, OrdinestatoEqGreaterThanThis,
DatascadenzaEqLessThanThis, IdprogrammazioneEqualThis, MultiprogettoEqualThis,
MultimisuraEqualThis, DisposizioniattuativeEqualThis, ParolechiaveLikeThis);
        }

        //Costruttore3: ha in input bandoCollectionObj - non popola la collection
        public BandoCollectionProvider(BandoCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public BandoCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new BandoCollection(this);
        }

        //Get e Set
        public BandoCollection CollectionObj
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
        public int SaveCollection(BandoCollection collectionObj)
        {
            return BandoDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Bando bandoObj)
        {
            return BandoDAL.Save(_dbProviderObj, bandoObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(BandoCollection collectionObj)
        {
            return BandoDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Bando bandoObj)
        {
            return BandoDAL.Delete(_dbProviderObj, bandoObj);
        }

        //getById
        public Bando GetById(IntNT IdBandoValue)
        {
            Bando BandoTemp = BandoDAL.GetById(_dbProviderObj, IdBandoValue);
            if (BandoTemp != null) BandoTemp.Provider = this;
            return BandoTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public BandoCollection Select(IntNT IdbandoEqualThis, StringNT CodenteEqualThis, StringNT DescrizioneEqualThis,
StringNT ParolechiaveEqualThis, DatetimeNT DatainserimentoEqualThis, DatetimeNT DataaperturaEqualThis,
BoolNT DisposizioniattuativeEqualThis, IntNT IdschedavalutazioneEqualThis, IntNT IdmodellodomandaEqualThis,
IntNT IdprogrammazioneEqualThis, BoolNT MultiprogettoEqualThis, BoolNT MultimisuraEqualThis,
BoolNT InteressefilieraEqualThis, BoolNT FascicolorichiestoEqualThis, IntNT IdstoricoultimoEqualThis,
IntNT IdintegrazioneultimaEqualThis, BoolNT FirmarichiestaEqualThis, BoolNT AbilitavalutazioneEqualThis,
BoolNT AggregazioneEqualThis)
        {
            BandoCollection BandoCollectionTemp = BandoDAL.Select(_dbProviderObj, IdbandoEqualThis, CodenteEqualThis, DescrizioneEqualThis,
ParolechiaveEqualThis, DatainserimentoEqualThis, DataaperturaEqualThis,
DisposizioniattuativeEqualThis, IdschedavalutazioneEqualThis, IdmodellodomandaEqualThis,
IdprogrammazioneEqualThis, MultiprogettoEqualThis, MultimisuraEqualThis,
InteressefilieraEqualThis, FascicolorichiestoEqualThis, IdstoricoultimoEqualThis,
IdintegrazioneultimaEqualThis, FirmarichiestaEqualThis, AbilitavalutazioneEqualThis,
AggregazioneEqualThis);
            BandoCollectionTemp.Provider = this;
            return BandoCollectionTemp;
        }

        //Find: popola la collection
        public BandoCollection Find(StringNT CodenteEqualThis, StringNT CodstatoEqualThis, IntNT OrdinestatoEqGreaterThanThis,
DatetimeNT DatascadenzaEqLessThanThis, IntNT IdprogrammazioneEqualThis, BoolNT MultiprogettoEqualThis,
BoolNT MultimisuraEqualThis, BoolNT DisposizioniattuativeEqualThis, StringNT ParolechiaveLikeThis)
        {
            BandoCollection BandoCollectionTemp = BandoDAL.Find(_dbProviderObj, CodenteEqualThis, CodstatoEqualThis, OrdinestatoEqGreaterThanThis,
DatascadenzaEqLessThanThis, IdprogrammazioneEqualThis, MultiprogettoEqualThis,
MultimisuraEqualThis, DisposizioniattuativeEqualThis, ParolechiaveLikeThis);
            BandoCollectionTemp.Provider = this;
            return BandoCollectionTemp;
        }

        //Find2: popola la collection
        public BandoCollection Find2(StringNT CodenteEqualThis, StringNT CodstatoEqualThis, IntNT OrdinestatoEqGreaterThanThis,
DatetimeNT DatascadenzaEqLessThanThis, IntNT IdprogrammazioneEqualThis, BoolNT MultiprogettoEqualThis,
BoolNT MultimisuraEqualThis, BoolNT DisposizioniattuativeEqualThis, StringNT ParolechiaveLikeThis,
IntNT IdbandoEqualThis)
        {
            BandoCollection BandoCollectionTemp = BandoDAL.Find2(_dbProviderObj, CodenteEqualThis, CodstatoEqualThis, OrdinestatoEqGreaterThanThis,
DatascadenzaEqLessThanThis, IdprogrammazioneEqualThis, MultiprogettoEqualThis,
MultimisuraEqualThis, DisposizioniattuativeEqualThis, ParolechiaveLikeThis,
IdbandoEqualThis);
            BandoCollectionTemp.Provider = this;
            return BandoCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO>
  <ViewName>vBANDO</ViewName>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <COD_ENTE>Equal</COD_ENTE>
      <COD_STATO>Equal</COD_STATO>
      <ORDINE_STATO>EqGreaterThan</ORDINE_STATO>
      <DATA_SCADENZA>EqLessThan</DATA_SCADENZA>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <MULTIPROGETTO>Equal</MULTIPROGETTO>
      <MULTIMISURA>Equal</MULTIMISURA>
      <DISPOSIZIONI_ATTUATIVE>Equal</DISPOSIZIONI_ATTUATIVE>
      <PAROLE_CHIAVE>Like</PAROLE_CHIAVE>
    </Find>
    <Find2 OrderBy="ORDER BY DATA DESC">
      <COD_ENTE>Equal</COD_ENTE>
      <COD_STATO>Equal</COD_STATO>
      <ORDINE_STATO>EqGreaterThan</ORDINE_STATO>
      <DATA_SCADENZA>EqLessThan</DATA_SCADENZA>
      <ID_PROGRAMMAZIONE>Equal</ID_PROGRAMMAZIONE>
      <MULTIPROGETTO>Equal</MULTIPROGETTO>
      <MULTIMISURA>Equal</MULTIMISURA>
      <DISPOSIZIONI_ATTUATIVE>Equal</DISPOSIZIONI_ATTUATIVE>
      <PAROLE_CHIAVE>Like</PAROLE_CHIAVE>
      <ID_BANDO>Equal</ID_BANDO>
    </Find2>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO>
*/
