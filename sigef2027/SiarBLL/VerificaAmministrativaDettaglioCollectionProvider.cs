using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per VerificaAmministrativaDettaglio
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IVerificaAmministrativaDettaglioProvider
    {
        int Save(VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj);
        int SaveCollection(VerificaAmministrativaDettaglioCollection collectionObj);
        int Delete(VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj);
        int DeleteCollection(VerificaAmministrativaDettaglioCollection collectionObj);
    }
    /// <summary>
    /// Summary description for VerificaAmministrativaDettaglio
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VerificaAmministrativaDettaglio : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdLottoDettaglio;
        private NullTypes.IntNT _IdLotto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Asse;
        private NullTypes.BoolNT _Selezionata;
        private NullTypes.StringNT _Esito;
        private NullTypes.DatetimeNT _DataEsito;
        private NullTypes.DecimalNT _CostoTotale;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.DecimalNT _ImportoConcesso;
        private NullTypes.IntNT _NrOperazioniB;
        private NullTypes.StringNT _Beneficiario;
        private NullTypes.DecimalNT _SpesaAmmessa;
        private NullTypes.DecimalNT _ImportoContributoPubblico;
        private NullTypes.DecimalNT _SpesaAmmessaIncrementale;
        private NullTypes.DecimalNT _ImportoContributoPubblicoIncrementale;
        private NullTypes.StringNT _Esclusione;
        private NullTypes.DecimalNT _RischioIr;
        private NullTypes.DecimalNT _RischioCr;
        private NullTypes.StringNT _RischioComplessivo;
        private NullTypes.StringNT _OperatoreInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _OperatoreModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _ObiettivoSpecifico;
        private NullTypes.StringNT _Azione;
        private NullTypes.StringNT _Intervento;
        private NullTypes.StringNT _Codpsr;
        private NullTypes.DatetimeNT _DataInizio;
        private NullTypes.DatetimeNT _DataFine;
        private NullTypes.BoolNT _Definitivo;
        private NullTypes.StringNT _CodiceCup;
        private NullTypes.StringNT _CupNaturaCodice;
        private NullTypes.StringNT _CupNaturaDescrizione;
        private NullTypes.StringNT _TitoloProgetto;
        private NullTypes.StringNT _TipoDomanda;
        [NonSerialized] private IVerificaAmministrativaDettaglioProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVerificaAmministrativaDettaglioProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public VerificaAmministrativaDettaglio()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_LOTTO_DETTAGLIO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdLottoDettaglio
        {
            get { return _IdLottoDettaglio; }
            set
            {
                if (IdLottoDettaglio != value)
                {
                    _IdLottoDettaglio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_LOTTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdLotto
        {
            get { return _IdLotto; }
            set
            {
                if (IdLotto != value)
                {
                    _IdLotto = value;
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
        /// Corrisponde al campo:ASSE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Asse
        {
            get { return _Asse; }
            set
            {
                if (Asse != value)
                {
                    _Asse = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SELEZIONATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Selezionata
        {
            get { return _Selezionata; }
            set
            {
                if (Selezionata != value)
                {
                    _Selezionata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESITO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Esito
        {
            get { return _Esito; }
            set
            {
                if (Esito != value)
                {
                    _Esito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ESITO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataEsito
        {
            get { return _DataEsito; }
            set
            {
                if (DataEsito != value)
                {
                    _DataEsito = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COSTO_TOTALE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT CostoTotale
        {
            get { return _CostoTotale; }
            set
            {
                if (CostoTotale != value)
                {
                    _CostoTotale = value;
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
        /// Corrisponde al campo:IMPORTO_CONCESSO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoConcesso
        {
            get { return _ImportoConcesso; }
            set
            {
                if (ImportoConcesso != value)
                {
                    _ImportoConcesso = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NR_OPERAZIONI_B
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NrOperazioniB
        {
            get { return _NrOperazioniB; }
            set
            {
                if (NrOperazioniB != value)
                {
                    _NrOperazioniB = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:BENEFICIARIO
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Beneficiario
        {
            get { return _Beneficiario; }
            set
            {
                if (Beneficiario != value)
                {
                    _Beneficiario = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESA_AMMESSA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaAmmessa
        {
            get { return _SpesaAmmessa; }
            set
            {
                if (SpesaAmmessa != value)
                {
                    _SpesaAmmessa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_CONTRIBUTO_PUBBLICO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoContributoPubblico
        {
            get { return _ImportoContributoPubblico; }
            set
            {
                if (ImportoContributoPubblico != value)
                {
                    _ImportoContributoPubblico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESA_AMMESSA_INCREMENTALE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaAmmessaIncrementale
        {
            get { return _SpesaAmmessaIncrementale; }
            set
            {
                if (SpesaAmmessaIncrementale != value)
                {
                    _SpesaAmmessaIncrementale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoContributoPubblicoIncrementale
        {
            get { return _ImportoContributoPubblicoIncrementale; }
            set
            {
                if (ImportoContributoPubblicoIncrementale != value)
                {
                    _ImportoContributoPubblicoIncrementale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ESCLUSIONE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Esclusione
        {
            get { return _Esclusione; }
            set
            {
                if (Esclusione != value)
                {
                    _Esclusione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RISCHIO_IR
        /// Tipo sul db:DECIMAL(6,2)
        /// </summary>
        public NullTypes.DecimalNT RischioIr
        {
            get { return _RischioIr; }
            set
            {
                if (RischioIr != value)
                {
                    _RischioIr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RISCHIO_CR
        /// Tipo sul db:DECIMAL(6,2)
        /// </summary>
        public NullTypes.DecimalNT RischioCr
        {
            get { return _RischioCr; }
            set
            {
                if (RischioCr != value)
                {
                    _RischioCr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RISCHIO_COMPLESSIVO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT RischioComplessivo
        {
            get { return _RischioComplessivo; }
            set
            {
                if (RischioComplessivo != value)
                {
                    _RischioComplessivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_INSERIMENTO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT OperatoreInserimento
        {
            get { return _OperatoreInserimento; }
            set
            {
                if (OperatoreInserimento != value)
                {
                    _OperatoreInserimento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INSERIMENTO
        /// Tipo sul db:DATETIME
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
        /// Corrisponde al campo:OPERATORE_MODIFICA
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT OperatoreModifica
        {
            get { return _OperatoreModifica; }
            set
            {
                if (OperatoreModifica != value)
                {
                    _OperatoreModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataModifica
        {
            get { return _DataModifica; }
            set
            {
                if (DataModifica != value)
                {
                    _DataModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OBIETTIVO_SPECIFICO
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT ObiettivoSpecifico
        {
            get { return _ObiettivoSpecifico; }
            set
            {
                if (ObiettivoSpecifico != value)
                {
                    _ObiettivoSpecifico = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AZIONE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Azione
        {
            get { return _Azione; }
            set
            {
                if (Azione != value)
                {
                    _Azione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:INTERVENTO
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Intervento
        {
            get { return _Intervento; }
            set
            {
                if (Intervento != value)
                {
                    _Intervento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODPSR
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT Codpsr
        {
            get { return _Codpsr; }
            set
            {
                if (Codpsr != value)
                {
                    _Codpsr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizio
        {
            get { return _DataInizio; }
            set
            {
                if (DataInizio != value)
                {
                    _DataInizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFine
        {
            get { return _DataFine; }
            set
            {
                if (DataFine != value)
                {
                    _DataFine = value;
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
        /// Corrisponde al campo:CODICE_CUP
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT CodiceCup
        {
            get { return _CodiceCup; }
            set
            {
                if (CodiceCup != value)
                {
                    _CodiceCup = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUP_NATURA_CODICE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CupNaturaCodice
        {
            get { return _CupNaturaCodice; }
            set
            {
                if (CupNaturaCodice != value)
                {
                    _CupNaturaCodice = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUP_NATURA_DESCRIZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT CupNaturaDescrizione
        {
            get { return _CupNaturaDescrizione; }
            set
            {
                if (CupNaturaDescrizione != value)
                {
                    _CupNaturaDescrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TITOLO_PROGETTO
        /// Tipo sul db:VARCHAR(500)
        /// </summary>
        public NullTypes.StringNT TitoloProgetto
        {
            get { return _TitoloProgetto; }
            set
            {
                if (TitoloProgetto != value)
                {
                    _TitoloProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_DOMANDA
        /// Tipo sul db:CHAR(3)
        /// </summary>
        public NullTypes.StringNT TipoDomanda
        {
            get { return _TipoDomanda; }
            set
            {
                if (TipoDomanda != value)
                {
                    _TipoDomanda = value;
                    SetDirtyFlag();
                }
            }
        }



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
    /// Summary description for VerificaAmministrativaDettaglioCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VerificaAmministrativaDettaglioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VerificaAmministrativaDettaglioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VerificaAmministrativaDettaglio)info.GetValue(i.ToString(), typeof(VerificaAmministrativaDettaglio)));
            }
        }

        //Costruttore
        public VerificaAmministrativaDettaglioCollection()
        {
            this.ItemType = typeof(VerificaAmministrativaDettaglio);
        }

        //Costruttore con provider
        public VerificaAmministrativaDettaglioCollection(IVerificaAmministrativaDettaglioProvider providerObj)
        {
            this.ItemType = typeof(VerificaAmministrativaDettaglio);
            this.Provider = providerObj;
        }

        //Get e Set
        public new VerificaAmministrativaDettaglio this[int index]
        {
            get { return (VerificaAmministrativaDettaglio)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VerificaAmministrativaDettaglioCollection GetChanges()
        {
            return (VerificaAmministrativaDettaglioCollection)base.GetChanges();
        }

        [NonSerialized] private IVerificaAmministrativaDettaglioProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVerificaAmministrativaDettaglioProvider Provider
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
        public int Add(VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj)
        {
            if (VerificaAmministrativaDettaglioObj.Provider == null) VerificaAmministrativaDettaglioObj.Provider = this.Provider;
            return base.Add(VerificaAmministrativaDettaglioObj);
        }

        //AddCollection
        public void AddCollection(VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionObj)
        {
            foreach (VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj in VerificaAmministrativaDettaglioCollectionObj)
                this.Add(VerificaAmministrativaDettaglioObj);
        }

        //Insert
        public void Insert(int index, VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj)
        {
            if (VerificaAmministrativaDettaglioObj.Provider == null) VerificaAmministrativaDettaglioObj.Provider = this.Provider;
            base.Insert(index, VerificaAmministrativaDettaglioObj);
        }

        //CollectionGetById
        public VerificaAmministrativaDettaglio CollectionGetById(NullTypes.IntNT IdLottoDettaglioValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdLottoDettaglio == IdLottoDettaglioValue))
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
        public VerificaAmministrativaDettaglioCollection SubSelect(NullTypes.IntNT IdLottoDettaglioEqualThis, NullTypes.IntNT IdLottoEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT OperatoreModificaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT AsseEqualThis,
NullTypes.StringNT AzioneEqualThis, NullTypes.StringNT InterventoEqualThis, NullTypes.StringNT ObiettivoSpecificoEqualThis,
NullTypes.BoolNT SelezionataEqualThis, NullTypes.StringNT EsitoEqualThis, NullTypes.DatetimeNT DataEsitoEqualThis,
NullTypes.DecimalNT CostoTotaleEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis, NullTypes.DecimalNT ImportoConcessoEqualThis,
NullTypes.IntNT NrOperazioniBEqualThis, NullTypes.StringNT BeneficiarioEqualThis, NullTypes.DecimalNT SpesaAmmessaEqualThis,
NullTypes.DecimalNT ImportoContributoPubblicoEqualThis, NullTypes.DecimalNT SpesaAmmessaIncrementaleEqualThis, NullTypes.DecimalNT ImportoContributoPubblicoIncrementaleEqualThis,
NullTypes.StringNT EsclusioneEqualThis, NullTypes.DecimalNT RischioIrEqualThis, NullTypes.DecimalNT RischioCrEqualThis,
NullTypes.StringNT RischioComplessivoEqualThis)
        {
            VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionTemp = new VerificaAmministrativaDettaglioCollection();
            foreach (VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioItem in this)
            {
                if (((IdLottoDettaglioEqualThis == null) || ((VerificaAmministrativaDettaglioItem.IdLottoDettaglio != null) && (VerificaAmministrativaDettaglioItem.IdLottoDettaglio.Value == IdLottoDettaglioEqualThis.Value))) && ((IdLottoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.IdLotto != null) && (VerificaAmministrativaDettaglioItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.OperatoreInserimento != null) && (VerificaAmministrativaDettaglioItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.DataInserimento != null) && (VerificaAmministrativaDettaglioItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((OperatoreModificaEqualThis == null) || ((VerificaAmministrativaDettaglioItem.OperatoreModifica != null) && (VerificaAmministrativaDettaglioItem.OperatoreModifica.Value == OperatoreModificaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VerificaAmministrativaDettaglioItem.DataModifica != null) && (VerificaAmministrativaDettaglioItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((IdDomandaPagamentoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.IdDomandaPagamento != null) && (VerificaAmministrativaDettaglioItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.IdProgetto != null) && (VerificaAmministrativaDettaglioItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((AsseEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Asse != null) && (VerificaAmministrativaDettaglioItem.Asse.Value == AsseEqualThis.Value))) &&
((AzioneEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Azione != null) && (VerificaAmministrativaDettaglioItem.Azione.Value == AzioneEqualThis.Value))) && ((InterventoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Intervento != null) && (VerificaAmministrativaDettaglioItem.Intervento.Value == InterventoEqualThis.Value))) && ((ObiettivoSpecificoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.ObiettivoSpecifico != null) && (VerificaAmministrativaDettaglioItem.ObiettivoSpecifico.Value == ObiettivoSpecificoEqualThis.Value))) &&
((SelezionataEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Selezionata != null) && (VerificaAmministrativaDettaglioItem.Selezionata.Value == SelezionataEqualThis.Value))) && ((EsitoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Esito != null) && (VerificaAmministrativaDettaglioItem.Esito.Value == EsitoEqualThis.Value))) && ((DataEsitoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.DataEsito != null) && (VerificaAmministrativaDettaglioItem.DataEsito.Value == DataEsitoEqualThis.Value))) &&
((CostoTotaleEqualThis == null) || ((VerificaAmministrativaDettaglioItem.CostoTotale != null) && (VerificaAmministrativaDettaglioItem.CostoTotale.Value == CostoTotaleEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.ImportoAmmesso != null) && (VerificaAmministrativaDettaglioItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) && ((ImportoConcessoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.ImportoConcesso != null) && (VerificaAmministrativaDettaglioItem.ImportoConcesso.Value == ImportoConcessoEqualThis.Value))) &&
((NrOperazioniBEqualThis == null) || ((VerificaAmministrativaDettaglioItem.NrOperazioniB != null) && (VerificaAmministrativaDettaglioItem.NrOperazioniB.Value == NrOperazioniBEqualThis.Value))) && ((BeneficiarioEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Beneficiario != null) && (VerificaAmministrativaDettaglioItem.Beneficiario.Value == BeneficiarioEqualThis.Value))) && ((SpesaAmmessaEqualThis == null) || ((VerificaAmministrativaDettaglioItem.SpesaAmmessa != null) && (VerificaAmministrativaDettaglioItem.SpesaAmmessa.Value == SpesaAmmessaEqualThis.Value))) &&
((ImportoContributoPubblicoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.ImportoContributoPubblico != null) && (VerificaAmministrativaDettaglioItem.ImportoContributoPubblico.Value == ImportoContributoPubblicoEqualThis.Value))) && ((SpesaAmmessaIncrementaleEqualThis == null) || ((VerificaAmministrativaDettaglioItem.SpesaAmmessaIncrementale != null) && (VerificaAmministrativaDettaglioItem.SpesaAmmessaIncrementale.Value == SpesaAmmessaIncrementaleEqualThis.Value))) && ((ImportoContributoPubblicoIncrementaleEqualThis == null) || ((VerificaAmministrativaDettaglioItem.ImportoContributoPubblicoIncrementale != null) && (VerificaAmministrativaDettaglioItem.ImportoContributoPubblicoIncrementale.Value == ImportoContributoPubblicoIncrementaleEqualThis.Value))) &&
((EsclusioneEqualThis == null) || ((VerificaAmministrativaDettaglioItem.Esclusione != null) && (VerificaAmministrativaDettaglioItem.Esclusione.Value == EsclusioneEqualThis.Value))) && ((RischioIrEqualThis == null) || ((VerificaAmministrativaDettaglioItem.RischioIr != null) && (VerificaAmministrativaDettaglioItem.RischioIr.Value == RischioIrEqualThis.Value))) && ((RischioCrEqualThis == null) || ((VerificaAmministrativaDettaglioItem.RischioCr != null) && (VerificaAmministrativaDettaglioItem.RischioCr.Value == RischioCrEqualThis.Value))) &&
((RischioComplessivoEqualThis == null) || ((VerificaAmministrativaDettaglioItem.RischioComplessivo != null) && (VerificaAmministrativaDettaglioItem.RischioComplessivo.Value == RischioComplessivoEqualThis.Value))))
                {
                    VerificaAmministrativaDettaglioCollectionTemp.Add(VerificaAmministrativaDettaglioItem);
                }
            }
            return VerificaAmministrativaDettaglioCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VerificaAmministrativaDettaglioDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VerificaAmministrativaDettaglioDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdLottoDettaglio", VerificaAmministrativaDettaglioObj.IdLottoDettaglio);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdLotto", VerificaAmministrativaDettaglioObj.IdLotto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", VerificaAmministrativaDettaglioObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", VerificaAmministrativaDettaglioObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "Asse", VerificaAmministrativaDettaglioObj.Asse);
            DbProvider.SetCmdParam(cmd, firstChar + "Selezionata", VerificaAmministrativaDettaglioObj.Selezionata);
            DbProvider.SetCmdParam(cmd, firstChar + "Esito", VerificaAmministrativaDettaglioObj.Esito);
            DbProvider.SetCmdParam(cmd, firstChar + "DataEsito", VerificaAmministrativaDettaglioObj.DataEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "CostoTotale", VerificaAmministrativaDettaglioObj.CostoTotale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoAmmesso", VerificaAmministrativaDettaglioObj.ImportoAmmesso);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoConcesso", VerificaAmministrativaDettaglioObj.ImportoConcesso);
            DbProvider.SetCmdParam(cmd, firstChar + "NrOperazioniB", VerificaAmministrativaDettaglioObj.NrOperazioniB);
            DbProvider.SetCmdParam(cmd, firstChar + "Beneficiario", VerificaAmministrativaDettaglioObj.Beneficiario);
            DbProvider.SetCmdParam(cmd, firstChar + "SpesaAmmessa", VerificaAmministrativaDettaglioObj.SpesaAmmessa);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoContributoPubblico", VerificaAmministrativaDettaglioObj.ImportoContributoPubblico);
            DbProvider.SetCmdParam(cmd, firstChar + "SpesaAmmessaIncrementale", VerificaAmministrativaDettaglioObj.SpesaAmmessaIncrementale);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoContributoPubblicoIncrementale", VerificaAmministrativaDettaglioObj.ImportoContributoPubblicoIncrementale);
            DbProvider.SetCmdParam(cmd, firstChar + "Esclusione", VerificaAmministrativaDettaglioObj.Esclusione);
            DbProvider.SetCmdParam(cmd, firstChar + "RischioIr", VerificaAmministrativaDettaglioObj.RischioIr);
            DbProvider.SetCmdParam(cmd, firstChar + "RischioCr", VerificaAmministrativaDettaglioObj.RischioCr);
            DbProvider.SetCmdParam(cmd, firstChar + "RischioComplessivo", VerificaAmministrativaDettaglioObj.RischioComplessivo);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreInserimento", VerificaAmministrativaDettaglioObj.OperatoreInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", VerificaAmministrativaDettaglioObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "OperatoreModifica", VerificaAmministrativaDettaglioObj.OperatoreModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", VerificaAmministrativaDettaglioObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "ObiettivoSpecifico", VerificaAmministrativaDettaglioObj.ObiettivoSpecifico);
            DbProvider.SetCmdParam(cmd, firstChar + "Azione", VerificaAmministrativaDettaglioObj.Azione);
            DbProvider.SetCmdParam(cmd, firstChar + "Intervento", VerificaAmministrativaDettaglioObj.Intervento);
        }
        //Insert
        private static int Insert(DbProvider db, VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZVerificaAmministrativaDettaglioInsert", new string[] {"IdLotto", "IdDomandaPagamento",
"IdProgetto", "Asse", "Selezionata",
"Esito", "DataEsito", "CostoTotale",
"ImportoAmmesso", "ImportoConcesso", "NrOperazioniB",
"Beneficiario", "SpesaAmmessa", "ImportoContributoPubblico",
"SpesaAmmessaIncrementale", "ImportoContributoPubblicoIncrementale", "Esclusione",
"RischioIr", "RischioCr", "RischioComplessivo",
"OperatoreInserimento", "DataInserimento", "OperatoreModifica",
"DataModifica", "ObiettivoSpecifico", "Azione",
"Intervento",

}, new string[] {"int", "int",
"int", "string", "bool",
"string", "DateTime", "decimal",
"decimal", "decimal", "int",
"string", "decimal", "decimal",
"decimal", "decimal", "string",
"decimal", "decimal", "string",
"string", "DateTime", "string",
"DateTime", "string", "string",
"string",

}, "");
                CompileIUCmd(false, insertCmd, VerificaAmministrativaDettaglioObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    VerificaAmministrativaDettaglioObj.IdLottoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_DETTAGLIO"]);
                }
                VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaDettaglioObj.IsDirty = false;
                VerificaAmministrativaDettaglioObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVerificaAmministrativaDettaglioUpdate", new string[] {"IdLottoDettaglio", "IdLotto", "IdDomandaPagamento",
"IdProgetto", "Asse", "Selezionata",
"Esito", "DataEsito", "CostoTotale",
"ImportoAmmesso", "ImportoConcesso", "NrOperazioniB",
"Beneficiario", "SpesaAmmessa", "ImportoContributoPubblico",
"SpesaAmmessaIncrementale", "ImportoContributoPubblicoIncrementale", "Esclusione",
"RischioIr", "RischioCr", "RischioComplessivo",
"OperatoreInserimento", "DataInserimento", "OperatoreModifica",
"DataModifica", "ObiettivoSpecifico", "Azione",
"Intervento",

}, new string[] {"int", "int", "int",
"int", "string", "bool",
"string", "DateTime", "decimal",
"decimal", "decimal", "int",
"string", "decimal", "decimal",
"decimal", "decimal", "string",
"decimal", "decimal", "string",
"string", "DateTime", "string",
"DateTime", "string", "string",
"string",

}, "");
                CompileIUCmd(true, updateCmd, VerificaAmministrativaDettaglioObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    VerificaAmministrativaDettaglioObj.DataModifica = d;
                }
                VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaDettaglioObj.IsDirty = false;
                VerificaAmministrativaDettaglioObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj)
        {
            switch (VerificaAmministrativaDettaglioObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, VerificaAmministrativaDettaglioObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, VerificaAmministrativaDettaglioObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, VerificaAmministrativaDettaglioObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVerificaAmministrativaDettaglioUpdate", new string[] {"IdLottoDettaglio", "IdLotto", "IdDomandaPagamento",
"IdProgetto", "Asse", "Selezionata",
"Esito", "DataEsito", "CostoTotale",
"ImportoAmmesso", "ImportoConcesso", "NrOperazioniB",
"Beneficiario", "SpesaAmmessa", "ImportoContributoPubblico",
"SpesaAmmessaIncrementale", "ImportoContributoPubblicoIncrementale", "Esclusione",
"RischioIr", "RischioCr", "RischioComplessivo",
"OperatoreInserimento", "DataInserimento", "OperatoreModifica",
"DataModifica", "ObiettivoSpecifico", "Azione",
"Intervento",

}, new string[] {"int", "int", "int",
"int", "string", "bool",
"string", "DateTime", "decimal",
"decimal", "decimal", "int",
"string", "decimal", "decimal",
"decimal", "decimal", "string",
"decimal", "decimal", "string",
"string", "DateTime", "string",
"DateTime", "string", "string",
"string",

}, "");
                IDbCommand insertCmd = db.InitCmd("ZVerificaAmministrativaDettaglioInsert", new string[] {"IdLotto", "IdDomandaPagamento",
"IdProgetto", "Asse", "Selezionata",
"Esito", "DataEsito", "CostoTotale",
"ImportoAmmesso", "ImportoConcesso", "NrOperazioniB",
"Beneficiario", "SpesaAmmessa", "ImportoContributoPubblico",
"SpesaAmmessaIncrementale", "ImportoContributoPubblicoIncrementale", "Esclusione",
"RischioIr", "RischioCr", "RischioComplessivo",
"OperatoreInserimento", "DataInserimento", "OperatoreModifica",
"DataModifica", "ObiettivoSpecifico", "Azione",
"Intervento",

}, new string[] {"int", "int",
"int", "string", "bool",
"string", "DateTime", "decimal",
"decimal", "decimal", "int",
"string", "decimal", "decimal",
"decimal", "decimal", "string",
"decimal", "decimal", "string",
"string", "DateTime", "string",
"DateTime", "string", "string",
"string",

}, "");
                IDbCommand deleteCmd = db.InitCmd("ZVerificaAmministrativaDettaglioDelete", new string[] { "IdLottoDettaglio" }, new string[] { "int" }, "");
                for (int i = 0; i < VerificaAmministrativaDettaglioCollectionObj.Count; i++)
                {
                    switch (VerificaAmministrativaDettaglioCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, VerificaAmministrativaDettaglioCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    VerificaAmministrativaDettaglioCollectionObj[i].IdLottoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_DETTAGLIO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, VerificaAmministrativaDettaglioCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    VerificaAmministrativaDettaglioCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (VerificaAmministrativaDettaglioCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLottoDettaglio", (SiarLibrary.NullTypes.IntNT)VerificaAmministrativaDettaglioCollectionObj[i].IdLottoDettaglio);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < VerificaAmministrativaDettaglioCollectionObj.Count; i++)
                {
                    if ((VerificaAmministrativaDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VerificaAmministrativaDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VerificaAmministrativaDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        VerificaAmministrativaDettaglioCollectionObj[i].IsDirty = false;
                        VerificaAmministrativaDettaglioCollectionObj[i].IsPersistent = true;
                    }
                    if ((VerificaAmministrativaDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        VerificaAmministrativaDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VerificaAmministrativaDettaglioCollectionObj[i].IsDirty = false;
                        VerificaAmministrativaDettaglioCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj)
        {
            int returnValue = 0;
            if (VerificaAmministrativaDettaglioObj.IsPersistent)
            {
                returnValue = Delete(db, VerificaAmministrativaDettaglioObj.IdLottoDettaglio);
            }
            VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            VerificaAmministrativaDettaglioObj.IsDirty = false;
            VerificaAmministrativaDettaglioObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdLottoDettaglioValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVerificaAmministrativaDettaglioDelete", new string[] { "IdLottoDettaglio" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLottoDettaglio", (SiarLibrary.NullTypes.IntNT)IdLottoDettaglioValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVerificaAmministrativaDettaglioDelete", new string[] { "IdLottoDettaglio" }, new string[] { "int" }, "");
                for (int i = 0; i < VerificaAmministrativaDettaglioCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdLottoDettaglio", VerificaAmministrativaDettaglioCollectionObj[i].IdLottoDettaglio);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < VerificaAmministrativaDettaglioCollectionObj.Count; i++)
                {
                    if ((VerificaAmministrativaDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VerificaAmministrativaDettaglioCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VerificaAmministrativaDettaglioCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VerificaAmministrativaDettaglioCollectionObj[i].IsDirty = false;
                        VerificaAmministrativaDettaglioCollectionObj[i].IsPersistent = false;
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
        public static VerificaAmministrativaDettaglio GetById(DbProvider db, int IdLottoDettaglioValue)
        {
            VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj = null;
            IDbCommand readCmd = db.InitCmd("ZVerificaAmministrativaDettaglioGetById", new string[] { "IdLottoDettaglio" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdLottoDettaglio", (SiarLibrary.NullTypes.IntNT)IdLottoDettaglioValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                VerificaAmministrativaDettaglioObj = GetFromDatareader(db);
                VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaDettaglioObj.IsDirty = false;
                VerificaAmministrativaDettaglioObj.IsPersistent = true;
            }
            db.Close();
            return VerificaAmministrativaDettaglioObj;
        }

        //getFromDatareader
        public static VerificaAmministrativaDettaglio GetFromDatareader(DbProvider db)
        {
            VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj = new VerificaAmministrativaDettaglio();
            VerificaAmministrativaDettaglioObj.IdLottoDettaglio = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_DETTAGLIO"]);
            VerificaAmministrativaDettaglioObj.IdLotto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO"]);
            VerificaAmministrativaDettaglioObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            VerificaAmministrativaDettaglioObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VerificaAmministrativaDettaglioObj.Asse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ASSE"]);
            VerificaAmministrativaDettaglioObj.Selezionata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA"]);
            VerificaAmministrativaDettaglioObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
            VerificaAmministrativaDettaglioObj.DataEsito = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ESITO"]);
            VerificaAmministrativaDettaglioObj.CostoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO_TOTALE"]);
            VerificaAmministrativaDettaglioObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
            VerificaAmministrativaDettaglioObj.ImportoConcesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_CONCESSO"]);
            VerificaAmministrativaDettaglioObj.NrOperazioniB = new SiarLibrary.NullTypes.IntNT(db.DataReader["NR_OPERAZIONI_B"]);
            VerificaAmministrativaDettaglioObj.Beneficiario = new SiarLibrary.NullTypes.StringNT(db.DataReader["BENEFICIARIO"]);
            VerificaAmministrativaDettaglioObj.SpesaAmmessa = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESA_AMMESSA"]);
            VerificaAmministrativaDettaglioObj.ImportoContributoPubblico = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_CONTRIBUTO_PUBBLICO"]);
            VerificaAmministrativaDettaglioObj.SpesaAmmessaIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESA_AMMESSA_INCREMENTALE"]);
            VerificaAmministrativaDettaglioObj.ImportoContributoPubblicoIncrementale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_CONTRIBUTO_PUBBLICO_INCREMENTALE"]);
            VerificaAmministrativaDettaglioObj.Esclusione = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESCLUSIONE"]);
            VerificaAmministrativaDettaglioObj.RischioIr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RISCHIO_IR"]);
            VerificaAmministrativaDettaglioObj.RischioCr = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RISCHIO_CR"]);
            VerificaAmministrativaDettaglioObj.RischioComplessivo = new SiarLibrary.NullTypes.StringNT(db.DataReader["RISCHIO_COMPLESSIVO"]);
            VerificaAmministrativaDettaglioObj.OperatoreInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_INSERIMENTO"]);
            VerificaAmministrativaDettaglioObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            VerificaAmministrativaDettaglioObj.OperatoreModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_MODIFICA"]);
            VerificaAmministrativaDettaglioObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            VerificaAmministrativaDettaglioObj.ObiettivoSpecifico = new SiarLibrary.NullTypes.StringNT(db.DataReader["OBIETTIVO_SPECIFICO"]);
            VerificaAmministrativaDettaglioObj.Azione = new SiarLibrary.NullTypes.StringNT(db.DataReader["AZIONE"]);
            VerificaAmministrativaDettaglioObj.Intervento = new SiarLibrary.NullTypes.StringNT(db.DataReader["INTERVENTO"]);
            VerificaAmministrativaDettaglioObj.Codpsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODPSR"]);
            VerificaAmministrativaDettaglioObj.DataInizio = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO"]);
            VerificaAmministrativaDettaglioObj.DataFine = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE"]);
            VerificaAmministrativaDettaglioObj.Definitivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DEFINITIVO"]);
            VerificaAmministrativaDettaglioObj.CodiceCup = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_CUP"]);
            VerificaAmministrativaDettaglioObj.CupNaturaCodice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_NATURA_CODICE"]);
            VerificaAmministrativaDettaglioObj.CupNaturaDescrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUP_NATURA_DESCRIZIONE"]);
            VerificaAmministrativaDettaglioObj.TitoloProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TITOLO_PROGETTO"]);
            VerificaAmministrativaDettaglioObj.TipoDomanda = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_DOMANDA"]);
            VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VerificaAmministrativaDettaglioObj.IsDirty = false;
            VerificaAmministrativaDettaglioObj.IsPersistent = true;
            return VerificaAmministrativaDettaglioObj;
        }

        //Find Select

        public static VerificaAmministrativaDettaglioCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT OperatoreModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT AsseEqualThis,
SiarLibrary.NullTypes.StringNT AzioneEqualThis, SiarLibrary.NullTypes.StringNT InterventoEqualThis, SiarLibrary.NullTypes.StringNT ObiettivoSpecificoEqualThis,
SiarLibrary.NullTypes.BoolNT SelezionataEqualThis, SiarLibrary.NullTypes.StringNT EsitoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEsitoEqualThis,
SiarLibrary.NullTypes.DecimalNT CostoTotaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoConcessoEqualThis,
SiarLibrary.NullTypes.IntNT NrOperazioniBEqualThis, SiarLibrary.NullTypes.StringNT BeneficiarioEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaAmmessaEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoContributoPubblicoEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaAmmessaIncrementaleEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoContributoPubblicoIncrementaleEqualThis,
SiarLibrary.NullTypes.StringNT EsclusioneEqualThis, SiarLibrary.NullTypes.DecimalNT RischioIrEqualThis, SiarLibrary.NullTypes.DecimalNT RischioCrEqualThis,
SiarLibrary.NullTypes.StringNT RischioComplessivoEqualThis)

        {

            VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionObj = new VerificaAmministrativaDettaglioCollection();

            IDbCommand findCmd = db.InitCmd("Zverificaamministrativadettagliofindselect", new string[] {"IdLottoDettaglioequalthis", "IdLottoequalthis", "OperatoreInserimentoequalthis",
"DataInserimentoequalthis", "OperatoreModificaequalthis", "DataModificaequalthis",
"IdDomandaPagamentoequalthis", "IdProgettoequalthis", "Asseequalthis",
"Azioneequalthis", "Interventoequalthis", "ObiettivoSpecificoequalthis",
"Selezionataequalthis", "Esitoequalthis", "DataEsitoequalthis",
"CostoTotaleequalthis", "ImportoAmmessoequalthis", "ImportoConcessoequalthis",
"NrOperazioniBequalthis", "Beneficiarioequalthis", "SpesaAmmessaequalthis",
"ImportoContributoPubblicoequalthis", "SpesaAmmessaIncrementaleequalthis", "ImportoContributoPubblicoIncrementaleequalthis",
"Esclusioneequalthis", "RischioIrequalthis", "RischioCrequalthis",
"RischioComplessivoequalthis"}, new string[] {"int", "int", "string",
"DateTime", "string", "DateTime",
"int", "int", "string",
"string", "string", "string",
"bool", "string", "DateTime",
"decimal", "decimal", "decimal",
"int", "string", "decimal",
"decimal", "decimal", "decimal",
"string", "decimal", "decimal",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoDettaglioequalthis", IdLottoDettaglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreInserimentoequalthis", OperatoreInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreModificaequalthis", OperatoreModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Asseequalthis", AsseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Azioneequalthis", AzioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Interventoequalthis", InterventoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ObiettivoSpecificoequalthis", ObiettivoSpecificoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Selezionataequalthis", SelezionataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Esitoequalthis", EsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataEsitoequalthis", DataEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CostoTotaleequalthis", CostoTotaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoConcessoequalthis", ImportoConcessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NrOperazioniBequalthis", NrOperazioniBEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Beneficiarioequalthis", BeneficiarioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaAmmessaequalthis", SpesaAmmessaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoContributoPubblicoequalthis", ImportoContributoPubblicoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaAmmessaIncrementaleequalthis", SpesaAmmessaIncrementaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoContributoPubblicoIncrementaleequalthis", ImportoContributoPubblicoIncrementaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Esclusioneequalthis", EsclusioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RischioIrequalthis", RischioIrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RischioCrequalthis", RischioCrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RischioComplessivoequalthis", RischioComplessivoEqualThis);
            VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VerificaAmministrativaDettaglioObj = GetFromDatareader(db);
                VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaDettaglioObj.IsDirty = false;
                VerificaAmministrativaDettaglioObj.IsPersistent = true;
                VerificaAmministrativaDettaglioCollectionObj.Add(VerificaAmministrativaDettaglioObj);
            }
            db.Close();
            return VerificaAmministrativaDettaglioCollectionObj;
        }

        //Find Find

        public static VerificaAmministrativaDettaglioCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdLottoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoDettaglioEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataEqualThis)

        {

            VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionObj = new VerificaAmministrativaDettaglioCollection();

            IDbCommand findCmd = db.InitCmd("Zverificaamministrativadettagliofindfind", new string[] {"IdLottoequalthis", "IdLottoDettaglioequalthis", "IdDomandaPagamentoequalthis",
"IdProgettoequalthis", "Selezionataequalthis"}, new string[] {"int", "int", "int",
"int", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoequalthis", IdLottoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoDettaglioequalthis", IdLottoDettaglioEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Selezionataequalthis", SelezionataEqualThis);
            VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VerificaAmministrativaDettaglioObj = GetFromDatareader(db);
                VerificaAmministrativaDettaglioObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VerificaAmministrativaDettaglioObj.IsDirty = false;
                VerificaAmministrativaDettaglioObj.IsPersistent = true;
                VerificaAmministrativaDettaglioCollectionObj.Add(VerificaAmministrativaDettaglioObj);
            }
            db.Close();
            return VerificaAmministrativaDettaglioCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VerificaAmministrativaDettaglioCollectionProvider:IVerificaAmministrativaDettaglioProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VerificaAmministrativaDettaglioCollectionProvider : IVerificaAmministrativaDettaglioProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VerificaAmministrativaDettaglio
        protected VerificaAmministrativaDettaglioCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VerificaAmministrativaDettaglioCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VerificaAmministrativaDettaglioCollection(this);
        }

        //Costruttore 2: popola la collection
        public VerificaAmministrativaDettaglioCollectionProvider(IntNT IdlottoEqualThis, IntNT IdlottodettaglioEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis, BoolNT SelezionataEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdlottoEqualThis, IdlottodettaglioEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis, SelezionataEqualThis);
        }

        //Costruttore3: ha in input verificaamministrativadettaglioCollectionObj - non popola la collection
        public VerificaAmministrativaDettaglioCollectionProvider(VerificaAmministrativaDettaglioCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VerificaAmministrativaDettaglioCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VerificaAmministrativaDettaglioCollection(this);
        }

        //Get e Set
        public VerificaAmministrativaDettaglioCollection CollectionObj
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
        public int SaveCollection(VerificaAmministrativaDettaglioCollection collectionObj)
        {
            return VerificaAmministrativaDettaglioDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(VerificaAmministrativaDettaglio verificaamministrativadettaglioObj)
        {
            return VerificaAmministrativaDettaglioDAL.Save(_dbProviderObj, verificaamministrativadettaglioObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(VerificaAmministrativaDettaglioCollection collectionObj)
        {
            return VerificaAmministrativaDettaglioDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(VerificaAmministrativaDettaglio verificaamministrativadettaglioObj)
        {
            return VerificaAmministrativaDettaglioDAL.Delete(_dbProviderObj, verificaamministrativadettaglioObj);
        }

        //getById
        public VerificaAmministrativaDettaglio GetById(IntNT IdLottoDettaglioValue)
        {
            VerificaAmministrativaDettaglio VerificaAmministrativaDettaglioTemp = VerificaAmministrativaDettaglioDAL.GetById(_dbProviderObj, IdLottoDettaglioValue);
            if (VerificaAmministrativaDettaglioTemp != null) VerificaAmministrativaDettaglioTemp.Provider = this;
            return VerificaAmministrativaDettaglioTemp;
        }

        //Select: popola la collection
        public VerificaAmministrativaDettaglioCollection Select(IntNT IdlottodettaglioEqualThis, IntNT IdlottoEqualThis, StringNT OperatoreinserimentoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT OperatoremodificaEqualThis, DatetimeNT DatamodificaEqualThis,
IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, StringNT AsseEqualThis,
StringNT AzioneEqualThis, StringNT InterventoEqualThis, StringNT ObiettivospecificoEqualThis,
BoolNT SelezionataEqualThis, StringNT EsitoEqualThis, DatetimeNT DataesitoEqualThis,
DecimalNT CostototaleEqualThis, DecimalNT ImportoammessoEqualThis, DecimalNT ImportoconcessoEqualThis,
IntNT NroperazionibEqualThis, StringNT BeneficiarioEqualThis, DecimalNT SpesaammessaEqualThis,
DecimalNT ImportocontributopubblicoEqualThis, DecimalNT SpesaammessaincrementaleEqualThis, DecimalNT ImportocontributopubblicoincrementaleEqualThis,
StringNT EsclusioneEqualThis, DecimalNT RischioirEqualThis, DecimalNT RischiocrEqualThis,
StringNT RischiocomplessivoEqualThis)
        {
            VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionTemp = VerificaAmministrativaDettaglioDAL.Select(_dbProviderObj, IdlottodettaglioEqualThis, IdlottoEqualThis, OperatoreinserimentoEqualThis,
DatainserimentoEqualThis, OperatoremodificaEqualThis, DatamodificaEqualThis,
IddomandapagamentoEqualThis, IdprogettoEqualThis, AsseEqualThis,
AzioneEqualThis, InterventoEqualThis, ObiettivospecificoEqualThis,
SelezionataEqualThis, EsitoEqualThis, DataesitoEqualThis,
CostototaleEqualThis, ImportoammessoEqualThis, ImportoconcessoEqualThis,
NroperazionibEqualThis, BeneficiarioEqualThis, SpesaammessaEqualThis,
ImportocontributopubblicoEqualThis, SpesaammessaincrementaleEqualThis, ImportocontributopubblicoincrementaleEqualThis,
EsclusioneEqualThis, RischioirEqualThis, RischiocrEqualThis,
RischiocomplessivoEqualThis);
            VerificaAmministrativaDettaglioCollectionTemp.Provider = this;
            return VerificaAmministrativaDettaglioCollectionTemp;
        }

        //Find: popola la collection
        public VerificaAmministrativaDettaglioCollection Find(IntNT IdlottoEqualThis, IntNT IdlottodettaglioEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis, BoolNT SelezionataEqualThis)
        {
            VerificaAmministrativaDettaglioCollection VerificaAmministrativaDettaglioCollectionTemp = VerificaAmministrativaDettaglioDAL.Find(_dbProviderObj, IdlottoEqualThis, IdlottodettaglioEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis, SelezionataEqualThis);
            VerificaAmministrativaDettaglioCollectionTemp.Provider = this;
            return VerificaAmministrativaDettaglioCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VERIFICA_AMMINISTRATIVA_DETTAGLIO>
  <ViewName>VVERIFICA_AMMINISTRATIVA_DETTAGLIO</ViewName>
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
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_LOTTO_DETTAGLIO>Equal</ID_LOTTO_DETTAGLIO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <SELEZIONATA>Equal</SELEZIONATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VERIFICA_AMMINISTRATIVA_DETTAGLIO>
*/
