using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoBandiProcAttivazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VcruscottoBandiProcAttivazione : BaseObject
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
        private NullTypes.IntNT _IdUtenteRup;
        private NullTypes.StringNT _CfRup;
        private NullTypes.StringNT _Rup;


        //Costruttore
        public VcruscottoBandiProcAttivazione()
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

        /// <summary>
        /// Corrisponde al campo:ID_UTENTE_RUP
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtenteRup
        {
            get { return _IdUtenteRup; }
            set
            {
                if (IdUtenteRup != value)
                {
                    _IdUtenteRup = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_RUP
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfRup
        {
            get { return _CfRup; }
            set
            {
                if (CfRup != value)
                {
                    _CfRup = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RUP
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT Rup
        {
            get { return _Rup; }
            set
            {
                if (Rup != value)
                {
                    _Rup = value;
                    SetDirtyFlag();
                }
            }
        }




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoBandiProcAttivazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoBandiProcAttivazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VcruscottoBandiProcAttivazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VcruscottoBandiProcAttivazione)info.GetValue(i.ToString(), typeof(VcruscottoBandiProcAttivazione)));
            }
        }

        //Costruttore
        public VcruscottoBandiProcAttivazioneCollection()
        {
            this.ItemType = typeof(VcruscottoBandiProcAttivazione);
        }

        //Get e Set
        public new VcruscottoBandiProcAttivazione this[int index]
        {
            get { return (VcruscottoBandiProcAttivazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VcruscottoBandiProcAttivazioneCollection GetChanges()
        {
            return (VcruscottoBandiProcAttivazioneCollection)base.GetChanges();
        }

        //Add
        public int Add(VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneObj)
        {
            return base.Add(VcruscottoBandiProcAttivazioneObj);
        }

        //AddCollection
        public void AddCollection(VcruscottoBandiProcAttivazioneCollection VcruscottoBandiProcAttivazioneCollectionObj)
        {
            foreach (VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneObj in VcruscottoBandiProcAttivazioneCollectionObj)
                this.Add(VcruscottoBandiProcAttivazioneObj);
        }

        //Insert
        public void Insert(int index, VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneObj)
        {
            base.Insert(index, VcruscottoBandiProcAttivazioneObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VcruscottoBandiProcAttivazioneCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT DescrizioneEqualThis,
NullTypes.StringNT ParoleChiaveEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.BoolNT DisposizioniAttuativeEqualThis,
NullTypes.IntNT IdSchedaValutazioneEqualThis, NullTypes.BoolNT MultiprogettoEqualThis, NullTypes.BoolNT MultimisuraEqualThis,
NullTypes.BoolNT InteresseFilieraEqualThis, NullTypes.BoolNT FascicoloRichiestoEqualThis, NullTypes.IntNT IdStoricoUltimoEqualThis,
NullTypes.DatetimeNT DataAperturaEqualThis, NullTypes.IntNT IdModelloDomandaEqualThis, NullTypes.IntNT IdProgrammazioneEqualThis,
NullTypes.IntNT IdIntegrazioneUltimaEqualThis, NullTypes.DatetimeNT DataScadenzaEqualThis, NullTypes.DecimalNT ImportoEqualThis,
NullTypes.DecimalNT ImportoDiMisuraEqualThis, NullTypes.DecimalNT QuotaRiservaEqualThis, NullTypes.IntNT IdAttoIntegrazioneEqualThis,
NullTypes.StringNT CodStatoEqualThis, NullTypes.DatetimeNT DataEqualThis, NullTypes.IntNT OperatoreEqualThis,
NullTypes.StringNT SegnaturaEqualThis, NullTypes.IntNT IdAttoEqualThis, NullTypes.IntNT OrdineStatoEqualThis,
NullTypes.StringNT StatoEqualThis, NullTypes.StringNT ProfiloEqualThis, NullTypes.StringNT NominativoEqualThis,
NullTypes.StringNT CodTipoEnteEqualThis, NullTypes.StringNT EnteEqualThis, NullTypes.BoolNT FirmaRichiestaEqualThis,
NullTypes.BoolNT AbilitaValutazioneEqualThis, NullTypes.BoolNT AggregazioneEqualThis, NullTypes.IntNT IdUtenteRupEqualThis,
NullTypes.StringNT CfRupEqualThis, NullTypes.StringNT RupEqualThis)
        {
            VcruscottoBandiProcAttivazioneCollection VcruscottoBandiProcAttivazioneCollectionTemp = new VcruscottoBandiProcAttivazioneCollection();
            foreach (VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneItem in this)
            {
                if (((IdBandoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdBando != null) && (VcruscottoBandiProcAttivazioneItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodEnteEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.CodEnte != null) && (VcruscottoBandiProcAttivazioneItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Descrizione != null) && (VcruscottoBandiProcAttivazioneItem.Descrizione.Value == DescrizioneEqualThis.Value))) &&
((ParoleChiaveEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.ParoleChiave != null) && (VcruscottoBandiProcAttivazioneItem.ParoleChiave.Value == ParoleChiaveEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.DataInserimento != null) && (VcruscottoBandiProcAttivazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((DisposizioniAttuativeEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.DisposizioniAttuative != null) && (VcruscottoBandiProcAttivazioneItem.DisposizioniAttuative.Value == DisposizioniAttuativeEqualThis.Value))) &&
((IdSchedaValutazioneEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdSchedaValutazione != null) && (VcruscottoBandiProcAttivazioneItem.IdSchedaValutazione.Value == IdSchedaValutazioneEqualThis.Value))) && ((MultiprogettoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Multiprogetto != null) && (VcruscottoBandiProcAttivazioneItem.Multiprogetto.Value == MultiprogettoEqualThis.Value))) && ((MultimisuraEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Multimisura != null) && (VcruscottoBandiProcAttivazioneItem.Multimisura.Value == MultimisuraEqualThis.Value))) &&
((InteresseFilieraEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.InteresseFiliera != null) && (VcruscottoBandiProcAttivazioneItem.InteresseFiliera.Value == InteresseFilieraEqualThis.Value))) && ((FascicoloRichiestoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.FascicoloRichiesto != null) && (VcruscottoBandiProcAttivazioneItem.FascicoloRichiesto.Value == FascicoloRichiestoEqualThis.Value))) && ((IdStoricoUltimoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdStoricoUltimo != null) && (VcruscottoBandiProcAttivazioneItem.IdStoricoUltimo.Value == IdStoricoUltimoEqualThis.Value))) &&
((DataAperturaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.DataApertura != null) && (VcruscottoBandiProcAttivazioneItem.DataApertura.Value == DataAperturaEqualThis.Value))) && ((IdModelloDomandaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdModelloDomanda != null) && (VcruscottoBandiProcAttivazioneItem.IdModelloDomanda.Value == IdModelloDomandaEqualThis.Value))) && ((IdProgrammazioneEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdProgrammazione != null) && (VcruscottoBandiProcAttivazioneItem.IdProgrammazione.Value == IdProgrammazioneEqualThis.Value))) &&
((IdIntegrazioneUltimaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdIntegrazioneUltima != null) && (VcruscottoBandiProcAttivazioneItem.IdIntegrazioneUltima.Value == IdIntegrazioneUltimaEqualThis.Value))) && ((DataScadenzaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.DataScadenza != null) && (VcruscottoBandiProcAttivazioneItem.DataScadenza.Value == DataScadenzaEqualThis.Value))) && ((ImportoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Importo != null) && (VcruscottoBandiProcAttivazioneItem.Importo.Value == ImportoEqualThis.Value))) &&
((ImportoDiMisuraEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.ImportoDiMisura != null) && (VcruscottoBandiProcAttivazioneItem.ImportoDiMisura.Value == ImportoDiMisuraEqualThis.Value))) && ((QuotaRiservaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.QuotaRiserva != null) && (VcruscottoBandiProcAttivazioneItem.QuotaRiserva.Value == QuotaRiservaEqualThis.Value))) && ((IdAttoIntegrazioneEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdAttoIntegrazione != null) && (VcruscottoBandiProcAttivazioneItem.IdAttoIntegrazione.Value == IdAttoIntegrazioneEqualThis.Value))) &&
((CodStatoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.CodStato != null) && (VcruscottoBandiProcAttivazioneItem.CodStato.Value == CodStatoEqualThis.Value))) && ((DataEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Data != null) && (VcruscottoBandiProcAttivazioneItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Operatore != null) && (VcruscottoBandiProcAttivazioneItem.Operatore.Value == OperatoreEqualThis.Value))) &&
((SegnaturaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Segnatura != null) && (VcruscottoBandiProcAttivazioneItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((IdAttoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdAtto != null) && (VcruscottoBandiProcAttivazioneItem.IdAtto.Value == IdAttoEqualThis.Value))) && ((OrdineStatoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.OrdineStato != null) && (VcruscottoBandiProcAttivazioneItem.OrdineStato.Value == OrdineStatoEqualThis.Value))) &&
((StatoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Stato != null) && (VcruscottoBandiProcAttivazioneItem.Stato.Value == StatoEqualThis.Value))) && ((ProfiloEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Profilo != null) && (VcruscottoBandiProcAttivazioneItem.Profilo.Value == ProfiloEqualThis.Value))) && ((NominativoEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Nominativo != null) && (VcruscottoBandiProcAttivazioneItem.Nominativo.Value == NominativoEqualThis.Value))) &&
((CodTipoEnteEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.CodTipoEnte != null) && (VcruscottoBandiProcAttivazioneItem.CodTipoEnte.Value == CodTipoEnteEqualThis.Value))) && ((EnteEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Ente != null) && (VcruscottoBandiProcAttivazioneItem.Ente.Value == EnteEqualThis.Value))) && ((FirmaRichiestaEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.FirmaRichiesta != null) && (VcruscottoBandiProcAttivazioneItem.FirmaRichiesta.Value == FirmaRichiestaEqualThis.Value))) &&
((AbilitaValutazioneEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.AbilitaValutazione != null) && (VcruscottoBandiProcAttivazioneItem.AbilitaValutazione.Value == AbilitaValutazioneEqualThis.Value))) && ((AggregazioneEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Aggregazione != null) && (VcruscottoBandiProcAttivazioneItem.Aggregazione.Value == AggregazioneEqualThis.Value))) && ((IdUtenteRupEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.IdUtenteRup != null) && (VcruscottoBandiProcAttivazioneItem.IdUtenteRup.Value == IdUtenteRupEqualThis.Value))) &&
((CfRupEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.CfRup != null) && (VcruscottoBandiProcAttivazioneItem.CfRup.Value == CfRupEqualThis.Value))) && ((RupEqualThis == null) || ((VcruscottoBandiProcAttivazioneItem.Rup != null) && (VcruscottoBandiProcAttivazioneItem.Rup.Value == RupEqualThis.Value))))
                {
                    VcruscottoBandiProcAttivazioneCollectionTemp.Add(VcruscottoBandiProcAttivazioneItem);
                }
            }
            return VcruscottoBandiProcAttivazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VcruscottoBandiProcAttivazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VcruscottoBandiProcAttivazioneDAL
    {

        //Operazioni

        //getFromDatareader
        public static VcruscottoBandiProcAttivazione GetFromDatareader(DbProvider db)
        {
            VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneObj = new VcruscottoBandiProcAttivazione();
            VcruscottoBandiProcAttivazioneObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            VcruscottoBandiProcAttivazioneObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            VcruscottoBandiProcAttivazioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            VcruscottoBandiProcAttivazioneObj.ParoleChiave = new SiarLibrary.NullTypes.StringNT(db.DataReader["PAROLE_CHIAVE"]);
            VcruscottoBandiProcAttivazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            VcruscottoBandiProcAttivazioneObj.DisposizioniAttuative = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DISPOSIZIONI_ATTUATIVE"]);
            VcruscottoBandiProcAttivazioneObj.IdSchedaValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_SCHEDA_VALUTAZIONE"]);
            VcruscottoBandiProcAttivazioneObj.Multiprogetto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIPROGETTO"]);
            VcruscottoBandiProcAttivazioneObj.Multimisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MULTIMISURA"]);
            VcruscottoBandiProcAttivazioneObj.InteresseFiliera = new SiarLibrary.NullTypes.BoolNT(db.DataReader["INTERESSE_FILIERA"]);
            VcruscottoBandiProcAttivazioneObj.FascicoloRichiesto = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FASCICOLO_RICHIESTO"]);
            VcruscottoBandiProcAttivazioneObj.IdStoricoUltimo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_STORICO_ULTIMO"]);
            VcruscottoBandiProcAttivazioneObj.DataApertura = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APERTURA"]);
            VcruscottoBandiProcAttivazioneObj.IdModelloDomanda = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_MODELLO_DOMANDA"]);
            VcruscottoBandiProcAttivazioneObj.IdProgrammazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGRAMMAZIONE"]);
            VcruscottoBandiProcAttivazioneObj.IdIntegrazioneUltima = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_INTEGRAZIONE_ULTIMA"]);
            VcruscottoBandiProcAttivazioneObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
            VcruscottoBandiProcAttivazioneObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            VcruscottoBandiProcAttivazioneObj.ImportoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DI_MISURA"]);
            VcruscottoBandiProcAttivazioneObj.QuotaRiserva = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["QUOTA_RISERVA"]);
            VcruscottoBandiProcAttivazioneObj.IdAttoIntegrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_INTEGRAZIONE"]);
            VcruscottoBandiProcAttivazioneObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
            VcruscottoBandiProcAttivazioneObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            VcruscottoBandiProcAttivazioneObj.Operatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OPERATORE"]);
            VcruscottoBandiProcAttivazioneObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            VcruscottoBandiProcAttivazioneObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            VcruscottoBandiProcAttivazioneObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
            VcruscottoBandiProcAttivazioneObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            VcruscottoBandiProcAttivazioneObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
            VcruscottoBandiProcAttivazioneObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            VcruscottoBandiProcAttivazioneObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
            VcruscottoBandiProcAttivazioneObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
            VcruscottoBandiProcAttivazioneObj.FirmaRichiesta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_RICHIESTA"]);
            VcruscottoBandiProcAttivazioneObj.AbilitaValutazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITA_VALUTAZIONE"]);
            VcruscottoBandiProcAttivazioneObj.Aggregazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AGGREGAZIONE"]);
            VcruscottoBandiProcAttivazioneObj.IdUtenteRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_RUP"]);
            VcruscottoBandiProcAttivazioneObj.CfRup = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RUP"]);
            VcruscottoBandiProcAttivazioneObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
            VcruscottoBandiProcAttivazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VcruscottoBandiProcAttivazioneObj.IsDirty = false;
            VcruscottoBandiProcAttivazioneObj.IsPersistent = true;
            return VcruscottoBandiProcAttivazioneObj;
        }

        //Find Select

        public static VcruscottoBandiProcAttivazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis,
SiarLibrary.NullTypes.StringNT ParoleChiaveEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.BoolNT DisposizioniAttuativeEqualThis,
SiarLibrary.NullTypes.IntNT IdSchedaValutazioneEqualThis, SiarLibrary.NullTypes.BoolNT MultiprogettoEqualThis, SiarLibrary.NullTypes.BoolNT MultimisuraEqualThis,
SiarLibrary.NullTypes.BoolNT InteresseFilieraEqualThis, SiarLibrary.NullTypes.BoolNT FascicoloRichiestoEqualThis, SiarLibrary.NullTypes.IntNT IdStoricoUltimoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataAperturaEqualThis, SiarLibrary.NullTypes.IntNT IdModelloDomandaEqualThis, SiarLibrary.NullTypes.IntNT IdProgrammazioneEqualThis,
SiarLibrary.NullTypes.IntNT IdIntegrazioneUltimaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoDiMisuraEqualThis, SiarLibrary.NullTypes.DecimalNT QuotaRiservaEqualThis, SiarLibrary.NullTypes.IntNT IdAttoIntegrazioneEqualThis,
SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis, SiarLibrary.NullTypes.IntNT OperatoreEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqualThis,
SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.StringNT ProfiloEqualThis, SiarLibrary.NullTypes.StringNT NominativoEqualThis,
SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, SiarLibrary.NullTypes.StringNT EnteEqualThis, SiarLibrary.NullTypes.BoolNT FirmaRichiestaEqualThis,
SiarLibrary.NullTypes.BoolNT AbilitaValutazioneEqualThis, SiarLibrary.NullTypes.BoolNT AggregazioneEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteRupEqualThis,
SiarLibrary.NullTypes.StringNT CfRupEqualThis, SiarLibrary.NullTypes.StringNT RupEqualThis)

        {

            VcruscottoBandiProcAttivazioneCollection VcruscottoBandiProcAttivazioneCollectionObj = new VcruscottoBandiProcAttivazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottobandiprocattivazionefindselect", new string[] {"IdBandoequalthis", "CodEnteequalthis", "Descrizioneequalthis",
"ParoleChiaveequalthis", "DataInserimentoequalthis", "DisposizioniAttuativeequalthis",
"IdSchedaValutazioneequalthis", "Multiprogettoequalthis", "Multimisuraequalthis",
"InteresseFilieraequalthis", "FascicoloRichiestoequalthis", "IdStoricoUltimoequalthis",
"DataAperturaequalthis", "IdModelloDomandaequalthis", "IdProgrammazioneequalthis",
"IdIntegrazioneUltimaequalthis", "DataScadenzaequalthis", "Importoequalthis",
"ImportoDiMisuraequalthis", "QuotaRiservaequalthis", "IdAttoIntegrazioneequalthis",
"CodStatoequalthis", "Dataequalthis", "Operatoreequalthis",
"Segnaturaequalthis", "IdAttoequalthis", "OrdineStatoequalthis",
"Statoequalthis", "Profiloequalthis", "Nominativoequalthis",
"CodTipoEnteequalthis", "Enteequalthis", "FirmaRichiestaequalthis",
"AbilitaValutazioneequalthis", "Aggregazioneequalthis", "IdUtenteRupequalthis",
"CfRupequalthis", "Rupequalthis"}, new string[] {"int", "string", "string",
"string", "DateTime", "bool",
"int", "bool", "bool",
"bool", "bool", "int",
"DateTime", "int", "int",
"int", "DateTime", "decimal",
"decimal", "decimal", "int",
"string", "DateTime", "int",
"string", "int", "int",
"string", "string", "string",
"string", "string", "bool",
"bool", "bool", "int",
"string", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ParoleChiaveequalthis", ParoleChiaveEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DisposizioniAttuativeequalthis", DisposizioniAttuativeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdSchedaValutazioneequalthis", IdSchedaValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multiprogettoequalthis", MultiprogettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Multimisuraequalthis", MultimisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InteresseFilieraequalthis", InteresseFilieraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FascicoloRichiestoequalthis", FascicoloRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdStoricoUltimoequalthis", IdStoricoUltimoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAperturaequalthis", DataAperturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdModelloDomandaequalthis", IdModelloDomandaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgrammazioneequalthis", IdProgrammazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdIntegrazioneUltimaequalthis", IdIntegrazioneUltimaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaequalthis", DataScadenzaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDiMisuraequalthis", ImportoDiMisuraEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuotaRiservaequalthis", QuotaRiservaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoIntegrazioneequalthis", IdAttoIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineStatoequalthis", OrdineStatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Profiloequalthis", ProfiloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Nominativoequalthis", NominativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Enteequalthis", EnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaRichiestaequalthis", FirmaRichiestaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AbilitaValutazioneequalthis", AbilitaValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Aggregazioneequalthis", AggregazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteRupequalthis", IdUtenteRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfRupequalthis", CfRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rupequalthis", RupEqualThis);
            VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoBandiProcAttivazioneObj = GetFromDatareader(db);
                VcruscottoBandiProcAttivazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoBandiProcAttivazioneObj.IsDirty = false;
                VcruscottoBandiProcAttivazioneObj.IsPersistent = true;
                VcruscottoBandiProcAttivazioneCollectionObj.Add(VcruscottoBandiProcAttivazioneObj);
            }
            db.Close();
            return VcruscottoBandiProcAttivazioneCollectionObj;
        }

        //Find Find

        public static VcruscottoBandiProcAttivazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteRupEqualThis)

        {

            VcruscottoBandiProcAttivazioneCollection VcruscottoBandiProcAttivazioneCollectionObj = new VcruscottoBandiProcAttivazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottobandiprocattivazionefindfind", new string[] { "IdBandoequalthis", "IdUtenteRupequalthis" }, new string[] { "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteRupequalthis", IdUtenteRupEqualThis);
            VcruscottoBandiProcAttivazione VcruscottoBandiProcAttivazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoBandiProcAttivazioneObj = GetFromDatareader(db);
                VcruscottoBandiProcAttivazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoBandiProcAttivazioneObj.IsDirty = false;
                VcruscottoBandiProcAttivazioneObj.IsPersistent = true;
                VcruscottoBandiProcAttivazioneCollectionObj.Add(VcruscottoBandiProcAttivazioneObj);
            }
            db.Close();
            return VcruscottoBandiProcAttivazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VcruscottoBandiProcAttivazioneCollectionProvider:IVcruscottoBandiProcAttivazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoBandiProcAttivazioneCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VcruscottoBandiProcAttivazione
        protected VcruscottoBandiProcAttivazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VcruscottoBandiProcAttivazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VcruscottoBandiProcAttivazioneCollection();
        }

        //Costruttore 2: popola la collection
        public VcruscottoBandiProcAttivazioneCollectionProvider(IntNT IdbandoEqualThis, IntNT IdutenterupEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdbandoEqualThis, IdutenterupEqualThis);
        }

        //Costruttore3: ha in input vcruscottobandiprocattivazioneCollectionObj - non popola la collection
        public VcruscottoBandiProcAttivazioneCollectionProvider(VcruscottoBandiProcAttivazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VcruscottoBandiProcAttivazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VcruscottoBandiProcAttivazioneCollection();
        }

        //Get e Set
        public VcruscottoBandiProcAttivazioneCollection CollectionObj
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

        //Select: popola la collection
        public VcruscottoBandiProcAttivazioneCollection Select(IntNT IdbandoEqualThis, StringNT CodenteEqualThis, StringNT DescrizioneEqualThis,
StringNT ParolechiaveEqualThis, DatetimeNT DatainserimentoEqualThis, BoolNT DisposizioniattuativeEqualThis,
IntNT IdschedavalutazioneEqualThis, BoolNT MultiprogettoEqualThis, BoolNT MultimisuraEqualThis,
BoolNT InteressefilieraEqualThis, BoolNT FascicolorichiestoEqualThis, IntNT IdstoricoultimoEqualThis,
DatetimeNT DataaperturaEqualThis, IntNT IdmodellodomandaEqualThis, IntNT IdprogrammazioneEqualThis,
IntNT IdintegrazioneultimaEqualThis, DatetimeNT DatascadenzaEqualThis, DecimalNT ImportoEqualThis,
DecimalNT ImportodimisuraEqualThis, DecimalNT QuotariservaEqualThis, IntNT IdattointegrazioneEqualThis,
StringNT CodstatoEqualThis, DatetimeNT DataEqualThis, IntNT OperatoreEqualThis,
StringNT SegnaturaEqualThis, IntNT IdattoEqualThis, IntNT OrdinestatoEqualThis,
StringNT StatoEqualThis, StringNT ProfiloEqualThis, StringNT NominativoEqualThis,
StringNT CodtipoenteEqualThis, StringNT EnteEqualThis, BoolNT FirmarichiestaEqualThis,
BoolNT AbilitavalutazioneEqualThis, BoolNT AggregazioneEqualThis, IntNT IdutenterupEqualThis,
StringNT CfrupEqualThis, StringNT RupEqualThis)
        {
            VcruscottoBandiProcAttivazioneCollection VcruscottoBandiProcAttivazioneCollectionTemp = VcruscottoBandiProcAttivazioneDAL.Select(_dbProviderObj, IdbandoEqualThis, CodenteEqualThis, DescrizioneEqualThis,
ParolechiaveEqualThis, DatainserimentoEqualThis, DisposizioniattuativeEqualThis,
IdschedavalutazioneEqualThis, MultiprogettoEqualThis, MultimisuraEqualThis,
InteressefilieraEqualThis, FascicolorichiestoEqualThis, IdstoricoultimoEqualThis,
DataaperturaEqualThis, IdmodellodomandaEqualThis, IdprogrammazioneEqualThis,
IdintegrazioneultimaEqualThis, DatascadenzaEqualThis, ImportoEqualThis,
ImportodimisuraEqualThis, QuotariservaEqualThis, IdattointegrazioneEqualThis,
CodstatoEqualThis, DataEqualThis, OperatoreEqualThis,
SegnaturaEqualThis, IdattoEqualThis, OrdinestatoEqualThis,
StatoEqualThis, ProfiloEqualThis, NominativoEqualThis,
CodtipoenteEqualThis, EnteEqualThis, FirmarichiestaEqualThis,
AbilitavalutazioneEqualThis, AggregazioneEqualThis, IdutenterupEqualThis,
CfrupEqualThis, RupEqualThis);
            return VcruscottoBandiProcAttivazioneCollectionTemp;
        }

        //Find: popola la collection
        public VcruscottoBandiProcAttivazioneCollection Find(IntNT IdbandoEqualThis, IntNT IdutenterupEqualThis)
        {
            VcruscottoBandiProcAttivazioneCollection VcruscottoBandiProcAttivazioneCollectionTemp = VcruscottoBandiProcAttivazioneDAL.Find(_dbProviderObj, IdbandoEqualThis, IdutenterupEqualThis);
            return VcruscottoBandiProcAttivazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_BANDI_PROC_ATTIVAZIONE>
  <ViewName>VCRUSCOTTO_BANDI_PROC_ATTIVAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY DATA_SCADENZA ASC">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_UTENTE_RUP>Equal</ID_UTENTE_RUP>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_BANDI_PROC_ATTIVAZIONE>
*/
