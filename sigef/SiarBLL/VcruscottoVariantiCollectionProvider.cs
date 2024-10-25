using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoVarianti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VcruscottoVarianti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _DescrizioneBando;
        private NullTypes.DatetimeNT _DataScadenzaBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Stato;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _Impresa;
        private NullTypes.IntNT _IdVariante;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.StringNT _SegnaturaAllegati;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _SegnaturaApprovazione;
        private NullTypes.BoolNT _Approvata;
        private NullTypes.IntNT _IdUtenteIstruttore;
        private NullTypes.StringNT _Istruttore;
        private NullTypes.StringNT _NoteIstruttore;
        private NullTypes.StringNT _TipoVariante;
        private NullTypes.StringNT _Nominativo;
        private NullTypes.StringNT _Profilo;
        private NullTypes.StringNT _Ente;
        private NullTypes.DatetimeNT _DataApprovazione;
        private NullTypes.StringNT _Provincia;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.BoolNT _Annullata;
        private NullTypes.StringNT _SegnaturaAnnullamento;
        private NullTypes.StringNT _CfOperatoreAnnullamento;
        private NullTypes.DatetimeNT _DataAnnullamento;
        private NullTypes.StringNT _NominativoOperatoreAnnullamento;
        private NullTypes.StringNT _NominativoIstruttore;
        private NullTypes.StringNT _CuaaEntrante;
        private NullTypes.IntNT _IdFascicoloEntrante;
        private NullTypes.StringNT _CuaaUscente;
        private NullTypes.IntNT _IdFascicoloUscente;
        private NullTypes.StringNT _RagsocUscente;
        private NullTypes.IntNT _IdAttoApprovazione;
        private NullTypes.StringNT _CodDefinizione;
        private NullTypes.IntNT _IdProgettoValutazione;
        private NullTypes.IntNT _Ordine;
        private NullTypes.IntNT _OrdineFirma;
        private NullTypes.IntNT _IdOperatoreFirmaComitato;
        private NullTypes.StringNT _OperatoreFirmaComitato;
        private NullTypes.BoolNT _FirmaPredispostaRup;
        private NullTypes.IntNT _IdUtenteRup;
        private NullTypes.StringNT _Rup;


        //Costruttore
        public VcruscottoVarianti()
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
        /// Corrisponde al campo:DESCRIZIONE_BANDO
        /// Tipo sul db:VARCHAR(2000)
        /// </summary>
        public NullTypes.StringNT DescrizioneBando
        {
            get { return _DescrizioneBando; }
            set
            {
                if (DescrizioneBando != value)
                {
                    _DescrizioneBando = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SCADENZA_BANDO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataScadenzaBando
        {
            get { return _DataScadenzaBando; }
            set
            {
                if (DataScadenzaBando != value)
                {
                    _DataScadenzaBando = value;
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
        /// Corrisponde al campo:STATO
        /// Tipo sul db:VARCHAR(80)
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
        /// Corrisponde al campo:IMPRESA
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Impresa
        {
            get { return _Impresa; }
            set
            {
                if (Impresa != value)
                {
                    _Impresa = value;
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
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodTipo
        {
            get { return _CodTipo; }
            set
            {
                if (CodTipo != value)
                {
                    _CodTipo = value;
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
        /// Corrisponde al campo:SEGNATURA_ALLEGATI
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaAllegati
        {
            get { return _SegnaturaAllegati; }
            set
            {
                if (SegnaturaAllegati != value)
                {
                    _SegnaturaAllegati = value;
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
        /// Corrisponde al campo:SEGNATURA_APPROVAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaApprovazione
        {
            get { return _SegnaturaApprovazione; }
            set
            {
                if (SegnaturaApprovazione != value)
                {
                    _SegnaturaApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:APPROVATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Approvata
        {
            get { return _Approvata; }
            set
            {
                if (Approvata != value)
                {
                    _Approvata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_UTENTE_ISTRUTTORE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdUtenteIstruttore
        {
            get { return _IdUtenteIstruttore; }
            set
            {
                if (IdUtenteIstruttore != value)
                {
                    _IdUtenteIstruttore = value;
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
        /// Corrisponde al campo:TIPO_VARIANTE
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT TipoVariante
        {
            get { return _TipoVariante; }
            set
            {
                if (TipoVariante != value)
                {
                    _TipoVariante = value;
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
        /// Corrisponde al campo:DATA_APPROVAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataApprovazione
        {
            get { return _DataApprovazione; }
            set
            {
                if (DataApprovazione != value)
                {
                    _DataApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROVINCIA
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT Provincia
        {
            get { return _Provincia; }
            set
            {
                if (Provincia != value)
                {
                    _Provincia = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(1000)
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
        /// Corrisponde al campo:ANNULLATA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Annullata
        {
            get { return _Annullata; }
            set
            {
                if (Annullata != value)
                {
                    _Annullata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_ANNULLAMENTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaAnnullamento
        {
            get { return _SegnaturaAnnullamento; }
            set
            {
                if (SegnaturaAnnullamento != value)
                {
                    _SegnaturaAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_OPERATORE_ANNULLAMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfOperatoreAnnullamento
        {
            get { return _CfOperatoreAnnullamento; }
            set
            {
                if (CfOperatoreAnnullamento != value)
                {
                    _CfOperatoreAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_ANNULLAMENTO
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataAnnullamento
        {
            get { return _DataAnnullamento; }
            set
            {
                if (DataAnnullamento != value)
                {
                    _DataAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_OPERATORE_ANNULLAMENTO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoOperatoreAnnullamento
        {
            get { return _NominativoOperatoreAnnullamento; }
            set
            {
                if (NominativoOperatoreAnnullamento != value)
                {
                    _NominativoOperatoreAnnullamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOMINATIVO_ISTRUTTORE
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT NominativoIstruttore
        {
            get { return _NominativoIstruttore; }
            set
            {
                if (NominativoIstruttore != value)
                {
                    _NominativoIstruttore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUAA_ENTRANTE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CuaaEntrante
        {
            get { return _CuaaEntrante; }
            set
            {
                if (CuaaEntrante != value)
                {
                    _CuaaEntrante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FASCICOLO_ENTRANTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFascicoloEntrante
        {
            get { return _IdFascicoloEntrante; }
            set
            {
                if (IdFascicoloEntrante != value)
                {
                    _IdFascicoloEntrante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CUAA_USCENTE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CuaaUscente
        {
            get { return _CuaaUscente; }
            set
            {
                if (CuaaUscente != value)
                {
                    _CuaaUscente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FASCICOLO_USCENTE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFascicoloUscente
        {
            get { return _IdFascicoloUscente; }
            set
            {
                if (IdFascicoloUscente != value)
                {
                    _IdFascicoloUscente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RAGSOC_USCENTE
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT RagsocUscente
        {
            get { return _RagsocUscente; }
            set
            {
                if (RagsocUscente != value)
                {
                    _RagsocUscente = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ATTO_APPROVAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAttoApprovazione
        {
            get { return _IdAttoApprovazione; }
            set
            {
                if (IdAttoApprovazione != value)
                {
                    _IdAttoApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_DEFINIZIONE
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodDefinizione
        {
            get { return _CodDefinizione; }
            set
            {
                if (CodDefinizione != value)
                {
                    _CodDefinizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_PROGETTO_VALUTAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdProgettoValutazione
        {
            get { return _IdProgettoValutazione; }
            set
            {
                if (IdProgettoValutazione != value)
                {
                    _IdProgettoValutazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Ordine
        {
            get { return _Ordine; }
            set
            {
                if (Ordine != value)
                {
                    _Ordine = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORDINE_FIRMA
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT OrdineFirma
        {
            get { return _OrdineFirma; }
            set
            {
                if (OrdineFirma != value)
                {
                    _OrdineFirma = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_OPERATORE_FIRMA_COMITATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdOperatoreFirmaComitato
        {
            get { return _IdOperatoreFirmaComitato; }
            set
            {
                if (IdOperatoreFirmaComitato != value)
                {
                    _IdOperatoreFirmaComitato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:OPERATORE_FIRMA_COMITATO
        /// Tipo sul db:VARCHAR(511)
        /// </summary>
        public NullTypes.StringNT OperatoreFirmaComitato
        {
            get { return _OperatoreFirmaComitato; }
            set
            {
                if (OperatoreFirmaComitato != value)
                {
                    _OperatoreFirmaComitato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FIRMA_PREDISPOSTA_RUP
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FirmaPredispostaRup
        {
            get { return _FirmaPredispostaRup; }
            set
            {
                if (FirmaPredispostaRup != value)
                {
                    _FirmaPredispostaRup = value;
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
    /// Summary description for VcruscottoVariantiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoVariantiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VcruscottoVariantiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VcruscottoVarianti)info.GetValue(i.ToString(), typeof(VcruscottoVarianti)));
            }
        }

        //Costruttore
        public VcruscottoVariantiCollection()
        {
            this.ItemType = typeof(VcruscottoVarianti);
        }

        //Get e Set
        public new VcruscottoVarianti this[int index]
        {
            get { return (VcruscottoVarianti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VcruscottoVariantiCollection GetChanges()
        {
            return (VcruscottoVariantiCollection)base.GetChanges();
        }

        //Add
        public int Add(VcruscottoVarianti VcruscottoVariantiObj)
        {
            return base.Add(VcruscottoVariantiObj);
        }

        //AddCollection
        public void AddCollection(VcruscottoVariantiCollection VcruscottoVariantiCollectionObj)
        {
            foreach (VcruscottoVarianti VcruscottoVariantiObj in VcruscottoVariantiCollectionObj)
                this.Add(VcruscottoVariantiObj);
        }

        //Insert
        public void Insert(int index, VcruscottoVarianti VcruscottoVariantiObj)
        {
            base.Insert(index, VcruscottoVariantiObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VcruscottoVariantiCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT StatoEqualThis, NullTypes.IntNT IdImpresaEqualThis,
NullTypes.StringNT ImpresaEqualThis, NullTypes.IntNT IdVarianteEqualThis, NullTypes.StringNT CodTipoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT SegnaturaEqualThis,
NullTypes.StringNT SegnaturaAllegatiEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT SegnaturaApprovazioneEqualThis,
NullTypes.BoolNT ApprovataEqualThis, NullTypes.IntNT IdUtenteIstruttoreEqualThis, NullTypes.StringNT IstruttoreEqualThis,
NullTypes.StringNT TipoVarianteEqualThis, NullTypes.StringNT NominativoEqualThis, NullTypes.StringNT ProfiloEqualThis,
NullTypes.StringNT EnteEqualThis, NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.StringNT ProvinciaEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT AnnullataEqualThis, NullTypes.StringNT SegnaturaAnnullamentoEqualThis,
NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, NullTypes.DatetimeNT DataAnnullamentoEqualThis, NullTypes.StringNT NominativoOperatoreAnnullamentoEqualThis,
NullTypes.StringNT NominativoIstruttoreEqualThis, NullTypes.StringNT CuaaEntranteEqualThis, NullTypes.IntNT IdFascicoloEntranteEqualThis,
NullTypes.StringNT CuaaUscenteEqualThis, NullTypes.IntNT IdFascicoloUscenteEqualThis, NullTypes.StringNT RagsocUscenteEqualThis,
NullTypes.IntNT IdAttoApprovazioneEqualThis, NullTypes.StringNT CodDefinizioneEqualThis, NullTypes.IntNT IdProgettoValutazioneEqualThis,
NullTypes.IntNT OrdineEqualThis, NullTypes.IntNT OrdineFirmaEqualThis, NullTypes.IntNT IdOperatoreFirmaComitatoEqualThis,
NullTypes.StringNT OperatoreFirmaComitatoEqualThis, NullTypes.BoolNT FirmaPredispostaRupEqualThis, NullTypes.IntNT IdUtenteRupEqualThis,
NullTypes.StringNT RupEqualThis)
        {
            VcruscottoVariantiCollection VcruscottoVariantiCollectionTemp = new VcruscottoVariantiCollection();
            foreach (VcruscottoVarianti VcruscottoVariantiItem in this)
            {
                if (((IdBandoEqualThis == null) || ((VcruscottoVariantiItem.IdBando != null) && (VcruscottoVariantiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VcruscottoVariantiItem.DescrizioneBando != null) && (VcruscottoVariantiItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VcruscottoVariantiItem.DataScadenzaBando != null) && (VcruscottoVariantiItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) &&
((IdProgettoEqualThis == null) || ((VcruscottoVariantiItem.IdProgetto != null) && (VcruscottoVariantiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((StatoEqualThis == null) || ((VcruscottoVariantiItem.Stato != null) && (VcruscottoVariantiItem.Stato.Value == StatoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VcruscottoVariantiItem.IdImpresa != null) && (VcruscottoVariantiItem.IdImpresa.Value == IdImpresaEqualThis.Value))) &&
((ImpresaEqualThis == null) || ((VcruscottoVariantiItem.Impresa != null) && (VcruscottoVariantiItem.Impresa.Value == ImpresaEqualThis.Value))) && ((IdVarianteEqualThis == null) || ((VcruscottoVariantiItem.IdVariante != null) && (VcruscottoVariantiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((CodTipoEqualThis == null) || ((VcruscottoVariantiItem.CodTipo != null) && (VcruscottoVariantiItem.CodTipo.Value == CodTipoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((VcruscottoVariantiItem.DataInserimento != null) && (VcruscottoVariantiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CodEnteEqualThis == null) || ((VcruscottoVariantiItem.CodEnte != null) && (VcruscottoVariantiItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((VcruscottoVariantiItem.Segnatura != null) && (VcruscottoVariantiItem.Segnatura.Value == SegnaturaEqualThis.Value))) &&
((SegnaturaAllegatiEqualThis == null) || ((VcruscottoVariantiItem.SegnaturaAllegati != null) && (VcruscottoVariantiItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VcruscottoVariantiItem.DataModifica != null) && (VcruscottoVariantiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((SegnaturaApprovazioneEqualThis == null) || ((VcruscottoVariantiItem.SegnaturaApprovazione != null) && (VcruscottoVariantiItem.SegnaturaApprovazione.Value == SegnaturaApprovazioneEqualThis.Value))) &&
((ApprovataEqualThis == null) || ((VcruscottoVariantiItem.Approvata != null) && (VcruscottoVariantiItem.Approvata.Value == ApprovataEqualThis.Value))) && ((IdUtenteIstruttoreEqualThis == null) || ((VcruscottoVariantiItem.IdUtenteIstruttore != null) && (VcruscottoVariantiItem.IdUtenteIstruttore.Value == IdUtenteIstruttoreEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((VcruscottoVariantiItem.Istruttore != null) && (VcruscottoVariantiItem.Istruttore.Value == IstruttoreEqualThis.Value))) &&
((TipoVarianteEqualThis == null) || ((VcruscottoVariantiItem.TipoVariante != null) && (VcruscottoVariantiItem.TipoVariante.Value == TipoVarianteEqualThis.Value))) && ((NominativoEqualThis == null) || ((VcruscottoVariantiItem.Nominativo != null) && (VcruscottoVariantiItem.Nominativo.Value == NominativoEqualThis.Value))) && ((ProfiloEqualThis == null) || ((VcruscottoVariantiItem.Profilo != null) && (VcruscottoVariantiItem.Profilo.Value == ProfiloEqualThis.Value))) &&
((EnteEqualThis == null) || ((VcruscottoVariantiItem.Ente != null) && (VcruscottoVariantiItem.Ente.Value == EnteEqualThis.Value))) && ((DataApprovazioneEqualThis == null) || ((VcruscottoVariantiItem.DataApprovazione != null) && (VcruscottoVariantiItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((VcruscottoVariantiItem.Provincia != null) && (VcruscottoVariantiItem.Provincia.Value == ProvinciaEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((VcruscottoVariantiItem.Descrizione != null) && (VcruscottoVariantiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AnnullataEqualThis == null) || ((VcruscottoVariantiItem.Annullata != null) && (VcruscottoVariantiItem.Annullata.Value == AnnullataEqualThis.Value))) && ((SegnaturaAnnullamentoEqualThis == null) || ((VcruscottoVariantiItem.SegnaturaAnnullamento != null) && (VcruscottoVariantiItem.SegnaturaAnnullamento.Value == SegnaturaAnnullamentoEqualThis.Value))) &&
((CfOperatoreAnnullamentoEqualThis == null) || ((VcruscottoVariantiItem.CfOperatoreAnnullamento != null) && (VcruscottoVariantiItem.CfOperatoreAnnullamento.Value == CfOperatoreAnnullamentoEqualThis.Value))) && ((DataAnnullamentoEqualThis == null) || ((VcruscottoVariantiItem.DataAnnullamento != null) && (VcruscottoVariantiItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))) && ((NominativoOperatoreAnnullamentoEqualThis == null) || ((VcruscottoVariantiItem.NominativoOperatoreAnnullamento != null) && (VcruscottoVariantiItem.NominativoOperatoreAnnullamento.Value == NominativoOperatoreAnnullamentoEqualThis.Value))) &&
((NominativoIstruttoreEqualThis == null) || ((VcruscottoVariantiItem.NominativoIstruttore != null) && (VcruscottoVariantiItem.NominativoIstruttore.Value == NominativoIstruttoreEqualThis.Value))) && ((CuaaEntranteEqualThis == null) || ((VcruscottoVariantiItem.CuaaEntrante != null) && (VcruscottoVariantiItem.CuaaEntrante.Value == CuaaEntranteEqualThis.Value))) && ((IdFascicoloEntranteEqualThis == null) || ((VcruscottoVariantiItem.IdFascicoloEntrante != null) && (VcruscottoVariantiItem.IdFascicoloEntrante.Value == IdFascicoloEntranteEqualThis.Value))) &&
((CuaaUscenteEqualThis == null) || ((VcruscottoVariantiItem.CuaaUscente != null) && (VcruscottoVariantiItem.CuaaUscente.Value == CuaaUscenteEqualThis.Value))) && ((IdFascicoloUscenteEqualThis == null) || ((VcruscottoVariantiItem.IdFascicoloUscente != null) && (VcruscottoVariantiItem.IdFascicoloUscente.Value == IdFascicoloUscenteEqualThis.Value))) && ((RagsocUscenteEqualThis == null) || ((VcruscottoVariantiItem.RagsocUscente != null) && (VcruscottoVariantiItem.RagsocUscente.Value == RagsocUscenteEqualThis.Value))) &&
((IdAttoApprovazioneEqualThis == null) || ((VcruscottoVariantiItem.IdAttoApprovazione != null) && (VcruscottoVariantiItem.IdAttoApprovazione.Value == IdAttoApprovazioneEqualThis.Value))) && ((CodDefinizioneEqualThis == null) || ((VcruscottoVariantiItem.CodDefinizione != null) && (VcruscottoVariantiItem.CodDefinizione.Value == CodDefinizioneEqualThis.Value))) && ((IdProgettoValutazioneEqualThis == null) || ((VcruscottoVariantiItem.IdProgettoValutazione != null) && (VcruscottoVariantiItem.IdProgettoValutazione.Value == IdProgettoValutazioneEqualThis.Value))) &&
((OrdineEqualThis == null) || ((VcruscottoVariantiItem.Ordine != null) && (VcruscottoVariantiItem.Ordine.Value == OrdineEqualThis.Value))) && ((OrdineFirmaEqualThis == null) || ((VcruscottoVariantiItem.OrdineFirma != null) && (VcruscottoVariantiItem.OrdineFirma.Value == OrdineFirmaEqualThis.Value))) && ((IdOperatoreFirmaComitatoEqualThis == null) || ((VcruscottoVariantiItem.IdOperatoreFirmaComitato != null) && (VcruscottoVariantiItem.IdOperatoreFirmaComitato.Value == IdOperatoreFirmaComitatoEqualThis.Value))) &&
((OperatoreFirmaComitatoEqualThis == null) || ((VcruscottoVariantiItem.OperatoreFirmaComitato != null) && (VcruscottoVariantiItem.OperatoreFirmaComitato.Value == OperatoreFirmaComitatoEqualThis.Value))) && ((FirmaPredispostaRupEqualThis == null) || ((VcruscottoVariantiItem.FirmaPredispostaRup != null) && (VcruscottoVariantiItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))) && ((IdUtenteRupEqualThis == null) || ((VcruscottoVariantiItem.IdUtenteRup != null) && (VcruscottoVariantiItem.IdUtenteRup.Value == IdUtenteRupEqualThis.Value))) &&
((RupEqualThis == null) || ((VcruscottoVariantiItem.Rup != null) && (VcruscottoVariantiItem.Rup.Value == RupEqualThis.Value))))
                {
                    VcruscottoVariantiCollectionTemp.Add(VcruscottoVariantiItem);
                }
            }
            return VcruscottoVariantiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VcruscottoVariantiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VcruscottoVariantiDAL
    {

        //Operazioni

        //getFromDatareader
        public static VcruscottoVarianti GetFromDatareader(DbProvider db)
        {
            VcruscottoVarianti VcruscottoVariantiObj = new VcruscottoVarianti();
            VcruscottoVariantiObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            VcruscottoVariantiObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
            VcruscottoVariantiObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
            VcruscottoVariantiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VcruscottoVariantiObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            VcruscottoVariantiObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            VcruscottoVariantiObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
            VcruscottoVariantiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            VcruscottoVariantiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            VcruscottoVariantiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            VcruscottoVariantiObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            VcruscottoVariantiObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            VcruscottoVariantiObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            VcruscottoVariantiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            VcruscottoVariantiObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
            VcruscottoVariantiObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            VcruscottoVariantiObj.IdUtenteIstruttore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_ISTRUTTORE"]);
            VcruscottoVariantiObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            VcruscottoVariantiObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
            VcruscottoVariantiObj.TipoVariante = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_VARIANTE"]);
            VcruscottoVariantiObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            VcruscottoVariantiObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
            VcruscottoVariantiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
            VcruscottoVariantiObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            VcruscottoVariantiObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
            VcruscottoVariantiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            VcruscottoVariantiObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
            VcruscottoVariantiObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
            VcruscottoVariantiObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
            VcruscottoVariantiObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
            VcruscottoVariantiObj.NominativoOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_ANNULLAMENTO"]);
            VcruscottoVariantiObj.NominativoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_ISTRUTTORE"]);
            VcruscottoVariantiObj.CuaaEntrante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_ENTRANTE"]);
            VcruscottoVariantiObj.IdFascicoloEntrante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO_ENTRANTE"]);
            VcruscottoVariantiObj.CuaaUscente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_USCENTE"]);
            VcruscottoVariantiObj.IdFascicoloUscente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO_USCENTE"]);
            VcruscottoVariantiObj.RagsocUscente = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGSOC_USCENTE"]);
            VcruscottoVariantiObj.IdAttoApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_APPROVAZIONE"]);
            VcruscottoVariantiObj.CodDefinizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DEFINIZIONE"]);
            VcruscottoVariantiObj.IdProgettoValutazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO_VALUTAZIONE"]);
            VcruscottoVariantiObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
            VcruscottoVariantiObj.OrdineFirma = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FIRMA"]);
            VcruscottoVariantiObj.IdOperatoreFirmaComitato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_OPERATORE_FIRMA_COMITATO"]);
            VcruscottoVariantiObj.OperatoreFirmaComitato = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE_FIRMA_COMITATO"]);
            VcruscottoVariantiObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
            VcruscottoVariantiObj.IdUtenteRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_RUP"]);
            VcruscottoVariantiObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
            VcruscottoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VcruscottoVariantiObj.IsDirty = false;
            VcruscottoVariantiObj.IsPersistent = true;
            return VcruscottoVariantiObj;
        }

        //Find Select

        public static VcruscottoVariantiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis,
SiarLibrary.NullTypes.StringNT ImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneEqualThis,
SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis,
SiarLibrary.NullTypes.StringNT TipoVarianteEqualThis, SiarLibrary.NullTypes.StringNT NominativoEqualThis, SiarLibrary.NullTypes.StringNT ProfiloEqualThis,
SiarLibrary.NullTypes.StringNT EnteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAnnullamentoEqualThis,
SiarLibrary.NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis, SiarLibrary.NullTypes.StringNT NominativoOperatoreAnnullamentoEqualThis,
SiarLibrary.NullTypes.StringNT NominativoIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT CuaaEntranteEqualThis, SiarLibrary.NullTypes.IntNT IdFascicoloEntranteEqualThis,
SiarLibrary.NullTypes.StringNT CuaaUscenteEqualThis, SiarLibrary.NullTypes.IntNT IdFascicoloUscenteEqualThis, SiarLibrary.NullTypes.StringNT RagsocUscenteEqualThis,
SiarLibrary.NullTypes.IntNT IdAttoApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT CodDefinizioneEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoValutazioneEqualThis,
SiarLibrary.NullTypes.IntNT OrdineEqualThis, SiarLibrary.NullTypes.IntNT OrdineFirmaEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreFirmaComitatoEqualThis,
SiarLibrary.NullTypes.StringNT OperatoreFirmaComitatoEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteRupEqualThis,
SiarLibrary.NullTypes.StringNT RupEqualThis)

        {

            VcruscottoVariantiCollection VcruscottoVariantiCollectionObj = new VcruscottoVariantiCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottovariantifindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "DataScadenzaBandoequalthis",
"IdProgettoequalthis", "Statoequalthis", "IdImpresaequalthis",
"Impresaequalthis", "IdVarianteequalthis", "CodTipoequalthis",
"DataInserimentoequalthis", "CodEnteequalthis", "Segnaturaequalthis",
"SegnaturaAllegatiequalthis", "DataModificaequalthis", "SegnaturaApprovazioneequalthis",
"Approvataequalthis", "IdUtenteIstruttoreequalthis", "Istruttoreequalthis",
"TipoVarianteequalthis", "Nominativoequalthis", "Profiloequalthis",
"Enteequalthis", "DataApprovazioneequalthis", "Provinciaequalthis",
"Descrizioneequalthis", "Annullataequalthis", "SegnaturaAnnullamentoequalthis",
"CfOperatoreAnnullamentoequalthis", "DataAnnullamentoequalthis", "NominativoOperatoreAnnullamentoequalthis",
"NominativoIstruttoreequalthis", "CuaaEntranteequalthis", "IdFascicoloEntranteequalthis",
"CuaaUscenteequalthis", "IdFascicoloUscenteequalthis", "RagsocUscenteequalthis",
"IdAttoApprovazioneequalthis", "CodDefinizioneequalthis", "IdProgettoValutazioneequalthis",
"Ordineequalthis", "OrdineFirmaequalthis", "IdOperatoreFirmaComitatoequalthis",
"OperatoreFirmaComitatoequalthis", "FirmaPredispostaRupequalthis", "IdUtenteRupequalthis",
"Rupequalthis"}, new string[] {"int", "string", "DateTime",
"int", "string", "int",
"string", "int", "string",
"DateTime", "string", "string",
"string", "DateTime", "string",
"bool", "int", "string",
"string", "string", "string",
"string", "DateTime", "string",
"string", "bool", "string",
"string", "DateTime", "string",
"string", "string", "int",
"string", "int", "string",
"int", "string", "int",
"int", "int", "int",
"string", "bool", "int",
"string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaApprovazioneequalthis", SegnaturaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteIstruttoreequalthis", IdUtenteIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TipoVarianteequalthis", TipoVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Nominativoequalthis", NominativoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Profiloequalthis", ProfiloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Enteequalthis", EnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Provinciaequalthis", ProvinciaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAnnullamentoequalthis", SegnaturaAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfOperatoreAnnullamentoequalthis", CfOperatoreAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NominativoOperatoreAnnullamentoequalthis", NominativoOperatoreAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NominativoIstruttoreequalthis", NominativoIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CuaaEntranteequalthis", CuaaEntranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFascicoloEntranteequalthis", IdFascicoloEntranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CuaaUscenteequalthis", CuaaUscenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFascicoloUscenteequalthis", IdFascicoloUscenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagsocUscenteequalthis", RagsocUscenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoApprovazioneequalthis", IdAttoApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodDefinizioneequalthis", CodDefinizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoValutazioneequalthis", IdProgettoValutazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineFirmaequalthis", OrdineFirmaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdOperatoreFirmaComitatoequalthis", IdOperatoreFirmaComitatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OperatoreFirmaComitatoequalthis", OperatoreFirmaComitatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteRupequalthis", IdUtenteRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rupequalthis", RupEqualThis);
            VcruscottoVarianti VcruscottoVariantiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoVariantiObj = GetFromDatareader(db);
                VcruscottoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoVariantiObj.IsDirty = false;
                VcruscottoVariantiObj.IsPersistent = true;
                VcruscottoVariantiCollectionObj.Add(VcruscottoVariantiObj);
            }
            db.Close();
            return VcruscottoVariantiCollectionObj;
        }

        //Find Find

        public static VcruscottoVariantiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteIstruttoreEqualThis, SiarLibrary.NullTypes.IntNT IdOperatoreFirmaComitatoEqualThis)

        {

            VcruscottoVariantiCollection VcruscottoVariantiCollectionObj = new VcruscottoVariantiCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottovariantifindfind", new string[] { "IdUtenteIstruttoreequalthis", "IdOperatoreFirmaComitatoequalthis" }, new string[] { "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteIstruttoreequalthis", IdUtenteIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdOperatoreFirmaComitatoequalthis", IdOperatoreFirmaComitatoEqualThis);
            VcruscottoVarianti VcruscottoVariantiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoVariantiObj = GetFromDatareader(db);
                VcruscottoVariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoVariantiObj.IsDirty = false;
                VcruscottoVariantiObj.IsPersistent = true;
                VcruscottoVariantiCollectionObj.Add(VcruscottoVariantiObj);
            }
            db.Close();
            return VcruscottoVariantiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VcruscottoVariantiCollectionProvider:IVcruscottoVariantiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoVariantiCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VcruscottoVarianti
        protected VcruscottoVariantiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VcruscottoVariantiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VcruscottoVariantiCollection();
        }

        //Costruttore 2: popola la collection
        public VcruscottoVariantiCollectionProvider(IntNT IdutenteistruttoreEqualThis, IntNT IdoperatorefirmacomitatoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdutenteistruttoreEqualThis, IdoperatorefirmacomitatoEqualThis);
        }

        //Costruttore3: ha in input vcruscottovariantiCollectionObj - non popola la collection
        public VcruscottoVariantiCollectionProvider(VcruscottoVariantiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VcruscottoVariantiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VcruscottoVariantiCollection();
        }

        //Get e Set
        public VcruscottoVariantiCollection CollectionObj
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
        public VcruscottoVariantiCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, DatetimeNT DatascadenzabandoEqualThis,
IntNT IdprogettoEqualThis, StringNT StatoEqualThis, IntNT IdimpresaEqualThis,
StringNT ImpresaEqualThis, IntNT IdvarianteEqualThis, StringNT CodtipoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CodenteEqualThis, StringNT SegnaturaEqualThis,
StringNT SegnaturaallegatiEqualThis, DatetimeNT DatamodificaEqualThis, StringNT SegnaturaapprovazioneEqualThis,
BoolNT ApprovataEqualThis, IntNT IdutenteistruttoreEqualThis, StringNT IstruttoreEqualThis,
StringNT TipovarianteEqualThis, StringNT NominativoEqualThis, StringNT ProfiloEqualThis,
StringNT EnteEqualThis, DatetimeNT DataapprovazioneEqualThis, StringNT ProvinciaEqualThis,
StringNT DescrizioneEqualThis, BoolNT AnnullataEqualThis, StringNT SegnaturaannullamentoEqualThis,
StringNT CfoperatoreannullamentoEqualThis, DatetimeNT DataannullamentoEqualThis, StringNT NominativooperatoreannullamentoEqualThis,
StringNT NominativoistruttoreEqualThis, StringNT CuaaentranteEqualThis, IntNT IdfascicoloentranteEqualThis,
StringNT CuaauscenteEqualThis, IntNT IdfascicolouscenteEqualThis, StringNT RagsocuscenteEqualThis,
IntNT IdattoapprovazioneEqualThis, StringNT CoddefinizioneEqualThis, IntNT IdprogettovalutazioneEqualThis,
IntNT OrdineEqualThis, IntNT OrdinefirmaEqualThis, IntNT IdoperatorefirmacomitatoEqualThis,
StringNT OperatorefirmacomitatoEqualThis, BoolNT FirmapredispostarupEqualThis, IntNT IdutenterupEqualThis,
StringNT RupEqualThis)
        {
            VcruscottoVariantiCollection VcruscottoVariantiCollectionTemp = VcruscottoVariantiDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, DatascadenzabandoEqualThis,
IdprogettoEqualThis, StatoEqualThis, IdimpresaEqualThis,
ImpresaEqualThis, IdvarianteEqualThis, CodtipoEqualThis,
DatainserimentoEqualThis, CodenteEqualThis, SegnaturaEqualThis,
SegnaturaallegatiEqualThis, DatamodificaEqualThis, SegnaturaapprovazioneEqualThis,
ApprovataEqualThis, IdutenteistruttoreEqualThis, IstruttoreEqualThis,
TipovarianteEqualThis, NominativoEqualThis, ProfiloEqualThis,
EnteEqualThis, DataapprovazioneEqualThis, ProvinciaEqualThis,
DescrizioneEqualThis, AnnullataEqualThis, SegnaturaannullamentoEqualThis,
CfoperatoreannullamentoEqualThis, DataannullamentoEqualThis, NominativooperatoreannullamentoEqualThis,
NominativoistruttoreEqualThis, CuaaentranteEqualThis, IdfascicoloentranteEqualThis,
CuaauscenteEqualThis, IdfascicolouscenteEqualThis, RagsocuscenteEqualThis,
IdattoapprovazioneEqualThis, CoddefinizioneEqualThis, IdprogettovalutazioneEqualThis,
OrdineEqualThis, OrdinefirmaEqualThis, IdoperatorefirmacomitatoEqualThis,
OperatorefirmacomitatoEqualThis, FirmapredispostarupEqualThis, IdutenterupEqualThis,
RupEqualThis);
            return VcruscottoVariantiCollectionTemp;
        }

        //Find: popola la collection
        public VcruscottoVariantiCollection Find(IntNT IdutenteistruttoreEqualThis, IntNT IdoperatorefirmacomitatoEqualThis)
        {
            VcruscottoVariantiCollection VcruscottoVariantiCollectionTemp = VcruscottoVariantiDAL.Find(_dbProviderObj, IdutenteistruttoreEqualThis, IdoperatorefirmacomitatoEqualThis);
            return VcruscottoVariantiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_VARIANTI>
  <ViewName>VCRUSCOTTO_VARIANTI</ViewName>
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
    <Find OrderBy="ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC, ID_VARIANTE ASC">
      <ID_UTENTE_ISTRUTTORE>Equal</ID_UTENTE_ISTRUTTORE>
      <ID_OPERATORE_FIRMA_COMITATO>Equal</ID_OPERATORE_FIRMA_COMITATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_VARIANTI>
*/
