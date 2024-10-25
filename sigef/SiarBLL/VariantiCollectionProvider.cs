using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Varianti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IVariantiProvider
    {
        int Save(Varianti VariantiObj);
        int SaveCollection(VariantiCollection collectionObj);
        int Delete(Varianti VariantiObj);
        int DeleteCollection(VariantiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Varianti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Varianti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdVariante;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CodEnte;
        private NullTypes.StringNT _Operatore;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _Segnatura;
        private NullTypes.StringNT _SegnaturaAllegati;
        private NullTypes.StringNT _SegnaturaApprovazione;
        private NullTypes.BoolNT _Approvata;
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
        private NullTypes.StringNT _AwDocnumber;
        private NullTypes.StringNT _CodDefinizione;
        private NullTypes.IntNT _AwDocnumberNuovo;
        private NullTypes.BoolNT _FirmaPredispostaRup;
        private NullTypes.BoolNT _FirmaPredisposta;
        [NonSerialized] private IVariantiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVariantiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Varianti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:OPERATORE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT Operatore
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
        /// Default:((0))
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
        /// Corrisponde al campo:AW_DOCNUMBER
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT AwDocnumber
        {
            get { return _AwDocnumber; }
            set
            {
                if (AwDocnumber != value)
                {
                    _AwDocnumber = value;
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
        /// Corrisponde al campo:AW_DOCNUMBER_NUOVO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT AwDocnumberNuovo
        {
            get { return _AwDocnumberNuovo; }
            set
            {
                if (AwDocnumberNuovo != value)
                {
                    _AwDocnumberNuovo = value;
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
        /// Corrisponde al campo:FIRMA_PREDISPOSTA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT FirmaPredisposta
        {
            get { return _FirmaPredisposta; }
            set
            {
                if (FirmaPredisposta != value)
                {
                    _FirmaPredisposta = value;
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
    /// Summary description for VariantiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VariantiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VariantiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Varianti)info.GetValue(i.ToString(), typeof(Varianti)));
            }
        }

        //Costruttore
        public VariantiCollection()
        {
            this.ItemType = typeof(Varianti);
        }

        //Costruttore con provider
        public VariantiCollection(IVariantiProvider providerObj)
        {
            this.ItemType = typeof(Varianti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Varianti this[int index]
        {
            get { return (Varianti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VariantiCollection GetChanges()
        {
            return (VariantiCollection)base.GetChanges();
        }

        [NonSerialized] private IVariantiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IVariantiProvider Provider
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
        public int Add(Varianti VariantiObj)
        {
            if (VariantiObj.Provider == null) VariantiObj.Provider = this.Provider;
            return base.Add(VariantiObj);
        }

        //AddCollection
        public void AddCollection(VariantiCollection VariantiCollectionObj)
        {
            foreach (Varianti VariantiObj in VariantiCollectionObj)
                this.Add(VariantiObj);
        }

        //Insert
        public void Insert(int index, Varianti VariantiObj)
        {
            if (VariantiObj.Provider == null) VariantiObj.Provider = this.Provider;
            base.Insert(index, VariantiObj);
        }

        //CollectionGetById
        public Varianti CollectionGetById(NullTypes.IntNT IdVarianteValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdVariante == IdVarianteValue))
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
        public VariantiCollection SubSelect(NullTypes.IntNT IdVarianteEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodTipoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT OperatoreEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT SegnaturaEqualThis,
NullTypes.StringNT SegnaturaAllegatiEqualThis, NullTypes.StringNT SegnaturaApprovazioneEqualThis, NullTypes.BoolNT ApprovataEqualThis,
NullTypes.DatetimeNT DataApprovazioneEqualThis, NullTypes.StringNT IstruttoreEqualThis, NullTypes.StringNT CuaaEntranteEqualThis,
NullTypes.IntNT IdFascicoloEntranteEqualThis, NullTypes.StringNT CuaaUscenteEqualThis, NullTypes.StringNT RagsocUscenteEqualThis,
NullTypes.IntNT IdFascicoloUscenteEqualThis, NullTypes.BoolNT AnnullataEqualThis, NullTypes.StringNT SegnaturaAnnullamentoEqualThis,
NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, NullTypes.DatetimeNT DataAnnullamentoEqualThis, NullTypes.IntNT IdAttoApprovazioneEqualThis,
NullTypes.BoolNT FirmaPredispostaEqualThis, NullTypes.BoolNT FirmaPredispostaRupEqualThis)
        {
            VariantiCollection VariantiCollectionTemp = new VariantiCollection();
            foreach (Varianti VariantiItem in this)
            {
                if (((IdVarianteEqualThis == null) || ((VariantiItem.IdVariante != null) && (VariantiItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VariantiItem.IdProgetto != null) && (VariantiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((VariantiItem.CodTipo != null) && (VariantiItem.CodTipo.Value == CodTipoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((VariantiItem.DataInserimento != null) && (VariantiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CodEnteEqualThis == null) || ((VariantiItem.CodEnte != null) && (VariantiItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((OperatoreEqualThis == null) || ((VariantiItem.Operatore != null) && (VariantiItem.Operatore.Value == OperatoreEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((VariantiItem.DataModifica != null) && (VariantiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VariantiItem.Descrizione != null) && (VariantiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((VariantiItem.Segnatura != null) && (VariantiItem.Segnatura.Value == SegnaturaEqualThis.Value))) &&
((SegnaturaAllegatiEqualThis == null) || ((VariantiItem.SegnaturaAllegati != null) && (VariantiItem.SegnaturaAllegati.Value == SegnaturaAllegatiEqualThis.Value))) && ((SegnaturaApprovazioneEqualThis == null) || ((VariantiItem.SegnaturaApprovazione != null) && (VariantiItem.SegnaturaApprovazione.Value == SegnaturaApprovazioneEqualThis.Value))) && ((ApprovataEqualThis == null) || ((VariantiItem.Approvata != null) && (VariantiItem.Approvata.Value == ApprovataEqualThis.Value))) &&
((DataApprovazioneEqualThis == null) || ((VariantiItem.DataApprovazione != null) && (VariantiItem.DataApprovazione.Value == DataApprovazioneEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((VariantiItem.Istruttore != null) && (VariantiItem.Istruttore.Value == IstruttoreEqualThis.Value))) && ((CuaaEntranteEqualThis == null) || ((VariantiItem.CuaaEntrante != null) && (VariantiItem.CuaaEntrante.Value == CuaaEntranteEqualThis.Value))) &&
((IdFascicoloEntranteEqualThis == null) || ((VariantiItem.IdFascicoloEntrante != null) && (VariantiItem.IdFascicoloEntrante.Value == IdFascicoloEntranteEqualThis.Value))) && ((CuaaUscenteEqualThis == null) || ((VariantiItem.CuaaUscente != null) && (VariantiItem.CuaaUscente.Value == CuaaUscenteEqualThis.Value))) && ((RagsocUscenteEqualThis == null) || ((VariantiItem.RagsocUscente != null) && (VariantiItem.RagsocUscente.Value == RagsocUscenteEqualThis.Value))) &&
((IdFascicoloUscenteEqualThis == null) || ((VariantiItem.IdFascicoloUscente != null) && (VariantiItem.IdFascicoloUscente.Value == IdFascicoloUscenteEqualThis.Value))) && ((AnnullataEqualThis == null) || ((VariantiItem.Annullata != null) && (VariantiItem.Annullata.Value == AnnullataEqualThis.Value))) && ((SegnaturaAnnullamentoEqualThis == null) || ((VariantiItem.SegnaturaAnnullamento != null) && (VariantiItem.SegnaturaAnnullamento.Value == SegnaturaAnnullamentoEqualThis.Value))) &&
((CfOperatoreAnnullamentoEqualThis == null) || ((VariantiItem.CfOperatoreAnnullamento != null) && (VariantiItem.CfOperatoreAnnullamento.Value == CfOperatoreAnnullamentoEqualThis.Value))) && ((DataAnnullamentoEqualThis == null) || ((VariantiItem.DataAnnullamento != null) && (VariantiItem.DataAnnullamento.Value == DataAnnullamentoEqualThis.Value))) && ((IdAttoApprovazioneEqualThis == null) || ((VariantiItem.IdAttoApprovazione != null) && (VariantiItem.IdAttoApprovazione.Value == IdAttoApprovazioneEqualThis.Value))) &&
((FirmaPredispostaEqualThis == null) || ((VariantiItem.FirmaPredisposta != null) && (VariantiItem.FirmaPredisposta.Value == FirmaPredispostaEqualThis.Value))) && ((FirmaPredispostaRupEqualThis == null) || ((VariantiItem.FirmaPredispostaRup != null) && (VariantiItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))))
                {
                    VariantiCollectionTemp.Add(VariantiItem);
                }
            }
            return VariantiCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VariantiCollection FiltroGenerale(NullTypes.BoolNT ApprovataEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT ProvinciaEqualThis,
NullTypes.StringNT CodTipoNotEqualThis, NullTypes.BoolNT SegnaturaApprovazioneIsNull, NullTypes.BoolNT SegnaturaAnnullamentoIsNull,
NullTypes.BoolNT CuaaUscenteIsNull, NullTypes.BoolNT IdAttoApprovazioneIsNull)
        {
            VariantiCollection VariantiCollectionTemp = new VariantiCollection();
            foreach (Varianti VariantiItem in this)
            {
                if (((ApprovataEqualThis == null) || ((VariantiItem.Approvata != null) && (VariantiItem.Approvata.Value == ApprovataEqualThis.Value))) && ((CodTipoEqualThis == null) || ((VariantiItem.CodTipo != null) && (VariantiItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((ProvinciaEqualThis == null) || ((VariantiItem.Provincia != null) && (VariantiItem.Provincia.Value == ProvinciaEqualThis.Value))) &&
((CodTipoNotEqualThis == null) || ((VariantiItem.CodTipo != null) && (VariantiItem.CodTipo.Value != CodTipoNotEqualThis.Value))) && ((SegnaturaApprovazioneIsNull == null) || ((VariantiItem.SegnaturaApprovazione == null) == SegnaturaApprovazioneIsNull.Value)) && ((SegnaturaAnnullamentoIsNull == null) || ((VariantiItem.SegnaturaAnnullamento == null) == SegnaturaAnnullamentoIsNull.Value)) &&
((CuaaUscenteIsNull == null) || ((VariantiItem.CuaaUscente == null) == CuaaUscenteIsNull.Value)) && ((IdAttoApprovazioneIsNull == null) || ((VariantiItem.IdAttoApprovazione == null) == IdAttoApprovazioneIsNull.Value)))
                {
                    VariantiCollectionTemp.Add(VariantiItem);
                }
            }
            return VariantiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VariantiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VariantiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Varianti VariantiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdVariante", VariantiObj.IdVariante);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", VariantiObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", VariantiObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", VariantiObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnte", VariantiObj.CodEnte);
            DbProvider.SetCmdParam(cmd, firstChar + "Operatore", VariantiObj.Operatore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", VariantiObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "Segnatura", VariantiObj.Segnatura);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaAllegati", VariantiObj.SegnaturaAllegati);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaApprovazione", VariantiObj.SegnaturaApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Approvata", VariantiObj.Approvata);
            DbProvider.SetCmdParam(cmd, firstChar + "Istruttore", VariantiObj.Istruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteIstruttore", VariantiObj.NoteIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "DataApprovazione", VariantiObj.DataApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", VariantiObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "Annullata", VariantiObj.Annullata);
            DbProvider.SetCmdParam(cmd, firstChar + "SegnaturaAnnullamento", VariantiObj.SegnaturaAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfOperatoreAnnullamento", VariantiObj.CfOperatoreAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataAnnullamento", VariantiObj.DataAnnullamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CuaaEntrante", VariantiObj.CuaaEntrante);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFascicoloEntrante", VariantiObj.IdFascicoloEntrante);
            DbProvider.SetCmdParam(cmd, firstChar + "CuaaUscente", VariantiObj.CuaaUscente);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFascicoloUscente", VariantiObj.IdFascicoloUscente);
            DbProvider.SetCmdParam(cmd, firstChar + "RagsocUscente", VariantiObj.RagsocUscente);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAttoApprovazione", VariantiObj.IdAttoApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaPredispostaRup", VariantiObj.FirmaPredispostaRup);
            DbProvider.SetCmdParam(cmd, firstChar + "FirmaPredisposta", VariantiObj.FirmaPredisposta);
        }
        //Insert
        private static int Insert(DbProvider db, Varianti VariantiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZVariantiInsert", new string[] {"IdProgetto", "CodTipo",
"DataInserimento", "CodEnte", "Operatore",
"DataModifica", "Segnatura", "SegnaturaAllegati",
"SegnaturaApprovazione", "Approvata", "Istruttore",
"NoteIstruttore",
"DataApprovazione",
"Descrizione", "Annullata",
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento",
"CuaaEntrante",
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente",
"RagsocUscente", "IdAttoApprovazione",
"FirmaPredispostaRup",
"FirmaPredisposta"}, new string[] {"int", "string",
"DateTime", "string", "string",
"DateTime", "string", "string",
"string", "bool", "string",
"string",
"DateTime",
"string", "bool",
"string", "string", "DateTime",
"string",
"int", "string", "int",
"string", "int",
"bool",
"bool"}, "");
                CompileIUCmd(false, insertCmd, VariantiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    VariantiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
                    VariantiObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
                }
                VariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VariantiObj.IsDirty = false;
                VariantiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Varianti VariantiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVariantiUpdate", new string[] {"IdVariante", "IdProgetto", "CodTipo",
"DataInserimento", "CodEnte", "Operatore",
"DataModifica", "Segnatura", "SegnaturaAllegati",
"SegnaturaApprovazione", "Approvata", "Istruttore",
"NoteIstruttore",
"DataApprovazione",
"Descrizione", "Annullata",
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento",
"CuaaEntrante",
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente",
"RagsocUscente", "IdAttoApprovazione",
"FirmaPredispostaRup",
"FirmaPredisposta"}, new string[] {"int", "int", "string",
"DateTime", "string", "string",
"DateTime", "string", "string",
"string", "bool", "string",
"string",
"DateTime",
"string", "bool",
"string", "string", "DateTime",
"string",
"int", "string", "int",
"string", "int",
"bool",
"bool"}, "");
                CompileIUCmd(true, updateCmd, VariantiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                VariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VariantiObj.IsDirty = false;
                VariantiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Varianti VariantiObj)
        {
            switch (VariantiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, VariantiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, VariantiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, VariantiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, VariantiCollection VariantiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZVariantiUpdate", new string[] {"IdVariante", "IdProgetto", "CodTipo",
"DataInserimento", "CodEnte", "Operatore",
"DataModifica", "Segnatura", "SegnaturaAllegati",
"SegnaturaApprovazione", "Approvata", "Istruttore",
"NoteIstruttore",
"DataApprovazione",
"Descrizione", "Annullata",
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento",
"CuaaEntrante",
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente",
"RagsocUscente", "IdAttoApprovazione",
"FirmaPredispostaRup",
"FirmaPredisposta"}, new string[] {"int", "int", "string",
"DateTime", "string", "string",
"DateTime", "string", "string",
"string", "bool", "string",
"string",
"DateTime",
"string", "bool",
"string", "string", "DateTime",
"string",
"int", "string", "int",
"string", "int",
"bool",
"bool"}, "");
                IDbCommand insertCmd = db.InitCmd("ZVariantiInsert", new string[] {"IdProgetto", "CodTipo",
"DataInserimento", "CodEnte", "Operatore",
"DataModifica", "Segnatura", "SegnaturaAllegati",
"SegnaturaApprovazione", "Approvata", "Istruttore",
"NoteIstruttore",
"DataApprovazione",
"Descrizione", "Annullata",
"SegnaturaAnnullamento", "CfOperatoreAnnullamento", "DataAnnullamento",
"CuaaEntrante",
"IdFascicoloEntrante", "CuaaUscente", "IdFascicoloUscente",
"RagsocUscente", "IdAttoApprovazione",
"FirmaPredispostaRup",
"FirmaPredisposta"}, new string[] {"int", "string",
"DateTime", "string", "string",
"DateTime", "string", "string",
"string", "bool", "string",
"string",
"DateTime",
"string", "bool",
"string", "string", "DateTime",
"string",
"int", "string", "int",
"string", "int",
"bool",
"bool"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZVariantiDelete", new string[] { "IdVariante" }, new string[] { "int" }, "");
                for (int i = 0; i < VariantiCollectionObj.Count; i++)
                {
                    switch (VariantiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, VariantiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    VariantiCollectionObj[i].IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
                                    VariantiCollectionObj[i].Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, VariantiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (VariantiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)VariantiCollectionObj[i].IdVariante);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < VariantiCollectionObj.Count; i++)
                {
                    if ((VariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VariantiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        VariantiCollectionObj[i].IsDirty = false;
                        VariantiCollectionObj[i].IsPersistent = true;
                    }
                    if ((VariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        VariantiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VariantiCollectionObj[i].IsDirty = false;
                        VariantiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Varianti VariantiObj)
        {
            int returnValue = 0;
            if (VariantiObj.IsPersistent)
            {
                returnValue = Delete(db, VariantiObj.IdVariante);
            }
            VariantiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            VariantiObj.IsDirty = false;
            VariantiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdVarianteValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVariantiDelete", new string[] { "IdVariante" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, VariantiCollection VariantiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZVariantiDelete", new string[] { "IdVariante" }, new string[] { "int" }, "");
                for (int i = 0; i < VariantiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVariante", VariantiCollectionObj[i].IdVariante);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < VariantiCollectionObj.Count; i++)
                {
                    if ((VariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VariantiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        VariantiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        VariantiCollectionObj[i].IsDirty = false;
                        VariantiCollectionObj[i].IsPersistent = false;
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
        public static Varianti GetById(DbProvider db, int IdVarianteValue)
        {
            Varianti VariantiObj = null;
            IDbCommand readCmd = db.InitCmd("ZVariantiGetById", new string[] { "IdVariante" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdVariante", (SiarLibrary.NullTypes.IntNT)IdVarianteValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                VariantiObj = GetFromDatareader(db);
                VariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VariantiObj.IsDirty = false;
                VariantiObj.IsPersistent = true;
            }
            db.Close();
            return VariantiObj;
        }

        //getFromDatareader
        public static Varianti GetFromDatareader(DbProvider db)
        {
            Varianti VariantiObj = new Varianti();
            VariantiObj.IdVariante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VARIANTE"]);
            VariantiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VariantiObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            VariantiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            VariantiObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
            VariantiObj.Operatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["OPERATORE"]);
            VariantiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            VariantiObj.Segnatura = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA"]);
            VariantiObj.SegnaturaAllegati = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ALLEGATI"]);
            VariantiObj.SegnaturaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_APPROVAZIONE"]);
            VariantiObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            VariantiObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            VariantiObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
            VariantiObj.TipoVariante = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_VARIANTE"]);
            VariantiObj.Nominativo = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO"]);
            VariantiObj.Profilo = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROFILO"]);
            VariantiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
            VariantiObj.DataApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_APPROVAZIONE"]);
            VariantiObj.Provincia = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA"]);
            VariantiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            VariantiObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
            VariantiObj.SegnaturaAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_ANNULLAMENTO"]);
            VariantiObj.CfOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_OPERATORE_ANNULLAMENTO"]);
            VariantiObj.DataAnnullamento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ANNULLAMENTO"]);
            VariantiObj.NominativoOperatoreAnnullamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_OPERATORE_ANNULLAMENTO"]);
            VariantiObj.NominativoIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOMINATIVO_ISTRUTTORE"]);
            VariantiObj.CuaaEntrante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_ENTRANTE"]);
            VariantiObj.IdFascicoloEntrante = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO_ENTRANTE"]);
            VariantiObj.CuaaUscente = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_USCENTE"]);
            VariantiObj.IdFascicoloUscente = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FASCICOLO_USCENTE"]);
            VariantiObj.RagsocUscente = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGSOC_USCENTE"]);
            VariantiObj.IdAttoApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO_APPROVAZIONE"]);
            VariantiObj.AwDocnumber = new SiarLibrary.NullTypes.StringNT(db.DataReader["AW_DOCNUMBER"]);
            VariantiObj.CodDefinizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DEFINIZIONE"]);
            VariantiObj.AwDocnumberNuovo = new SiarLibrary.NullTypes.IntNT(db.DataReader["AW_DOCNUMBER_NUOVO"]);
            VariantiObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
            VariantiObj.FirmaPredisposta = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA"]);
            VariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VariantiObj.IsDirty = false;
            VariantiObj.IsPersistent = true;
            return VariantiObj;
        }

        //Find Select

        public static VariantiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT OperatoreEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaEqualThis,
SiarLibrary.NullTypes.StringNT SegnaturaAllegatiEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaApprovazioneEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataApprovazioneEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, SiarLibrary.NullTypes.StringNT CuaaEntranteEqualThis,
SiarLibrary.NullTypes.IntNT IdFascicoloEntranteEqualThis, SiarLibrary.NullTypes.StringNT CuaaUscenteEqualThis, SiarLibrary.NullTypes.StringNT RagsocUscenteEqualThis,
SiarLibrary.NullTypes.IntNT IdFascicoloUscenteEqualThis, SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaAnnullamentoEqualThis,
SiarLibrary.NullTypes.StringNT CfOperatoreAnnullamentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataAnnullamentoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoApprovazioneEqualThis,
SiarLibrary.NullTypes.BoolNT FirmaPredispostaEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis)

        {

            VariantiCollection VariantiCollectionObj = new VariantiCollection();

            IDbCommand findCmd = db.InitCmd("Zvariantifindselect", new string[] {"IdVarianteequalthis", "IdProgettoequalthis", "CodTipoequalthis",
"DataInserimentoequalthis", "CodEnteequalthis", "Operatoreequalthis",
"DataModificaequalthis", "Descrizioneequalthis", "Segnaturaequalthis",
"SegnaturaAllegatiequalthis", "SegnaturaApprovazioneequalthis", "Approvataequalthis",
"DataApprovazioneequalthis", "Istruttoreequalthis", "CuaaEntranteequalthis",
"IdFascicoloEntranteequalthis", "CuaaUscenteequalthis", "RagsocUscenteequalthis",
"IdFascicoloUscenteequalthis", "Annullataequalthis", "SegnaturaAnnullamentoequalthis",
"CfOperatoreAnnullamentoequalthis", "DataAnnullamentoequalthis", "IdAttoApprovazioneequalthis",
"FirmaPredispostaequalthis", "FirmaPredispostaRupequalthis"}, new string[] {"int", "int", "string",
"DateTime", "string", "string",
"DateTime", "string", "string",
"string", "string", "bool",
"DateTime", "string", "string",
"int", "string", "string",
"int", "bool", "string",
"string", "DateTime", "int",
"bool", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Operatoreequalthis", OperatoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Segnaturaequalthis", SegnaturaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAllegatiequalthis", SegnaturaAllegatiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaApprovazioneequalthis", SegnaturaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataApprovazioneequalthis", DataApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CuaaEntranteequalthis", CuaaEntranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFascicoloEntranteequalthis", IdFascicoloEntranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CuaaUscenteequalthis", CuaaUscenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagsocUscenteequalthis", RagsocUscenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFascicoloUscenteequalthis", IdFascicoloUscenteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaAnnullamentoequalthis", SegnaturaAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfOperatoreAnnullamentoequalthis", CfOperatoreAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataAnnullamentoequalthis", DataAnnullamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoApprovazioneequalthis", IdAttoApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaequalthis", FirmaPredispostaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
            Varianti VariantiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VariantiObj = GetFromDatareader(db);
                VariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VariantiObj.IsDirty = false;
                VariantiObj.IsPersistent = true;
                VariantiCollectionObj.Add(VariantiObj);
            }
            db.Close();
            return VariantiCollectionObj;
        }

        //Find Find

        public static VariantiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdVarianteEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis)

        {

            VariantiCollection VariantiCollectionObj = new VariantiCollection();

            IDbCommand findCmd = db.InitCmd("Zvariantifindfind", new string[] { "IdVarianteequalthis", "IdProgettoequalthis", "CodTipoequalthis" }, new string[] { "int", "int", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVarianteequalthis", IdVarianteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            Varianti VariantiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VariantiObj = GetFromDatareader(db);
                VariantiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VariantiObj.IsDirty = false;
                VariantiObj.IsPersistent = true;
                VariantiCollectionObj.Add(VariantiObj);
            }
            db.Close();
            return VariantiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VariantiCollectionProvider:IVariantiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VariantiCollectionProvider : IVariantiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Varianti
        protected VariantiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VariantiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VariantiCollection(this);
        }

        //Costruttore 2: popola la collection
        public VariantiCollectionProvider(IntNT IdvarianteEqualThis, IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdvarianteEqualThis, IdprogettoEqualThis, CodtipoEqualThis);
        }

        //Costruttore3: ha in input variantiCollectionObj - non popola la collection
        public VariantiCollectionProvider(VariantiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VariantiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VariantiCollection(this);
        }

        //Get e Set
        public VariantiCollection CollectionObj
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
        public int SaveCollection(VariantiCollection collectionObj)
        {
            return VariantiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Varianti variantiObj)
        {
            return VariantiDAL.Save(_dbProviderObj, variantiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(VariantiCollection collectionObj)
        {
            return VariantiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Varianti variantiObj)
        {
            return VariantiDAL.Delete(_dbProviderObj, variantiObj);
        }

        //getById
        public Varianti GetById(IntNT IdVarianteValue)
        {
            Varianti VariantiTemp = VariantiDAL.GetById(_dbProviderObj, IdVarianteValue);
            if (VariantiTemp != null) VariantiTemp.Provider = this;
            return VariantiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public VariantiCollection Select(IntNT IdvarianteEqualThis, IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CodenteEqualThis, StringNT OperatoreEqualThis,
DatetimeNT DatamodificaEqualThis, StringNT DescrizioneEqualThis, StringNT SegnaturaEqualThis,
StringNT SegnaturaallegatiEqualThis, StringNT SegnaturaapprovazioneEqualThis, BoolNT ApprovataEqualThis,
DatetimeNT DataapprovazioneEqualThis, StringNT IstruttoreEqualThis, StringNT CuaaentranteEqualThis,
IntNT IdfascicoloentranteEqualThis, StringNT CuaauscenteEqualThis, StringNT RagsocuscenteEqualThis,
IntNT IdfascicolouscenteEqualThis, BoolNT AnnullataEqualThis, StringNT SegnaturaannullamentoEqualThis,
StringNT CfoperatoreannullamentoEqualThis, DatetimeNT DataannullamentoEqualThis, IntNT IdattoapprovazioneEqualThis,
BoolNT FirmapredispostaEqualThis, BoolNT FirmapredispostarupEqualThis)
        {
            VariantiCollection VariantiCollectionTemp = VariantiDAL.Select(_dbProviderObj, IdvarianteEqualThis, IdprogettoEqualThis, CodtipoEqualThis,
DatainserimentoEqualThis, CodenteEqualThis, OperatoreEqualThis,
DatamodificaEqualThis, DescrizioneEqualThis, SegnaturaEqualThis,
SegnaturaallegatiEqualThis, SegnaturaapprovazioneEqualThis, ApprovataEqualThis,
DataapprovazioneEqualThis, IstruttoreEqualThis, CuaaentranteEqualThis,
IdfascicoloentranteEqualThis, CuaauscenteEqualThis, RagsocuscenteEqualThis,
IdfascicolouscenteEqualThis, AnnullataEqualThis, SegnaturaannullamentoEqualThis,
CfoperatoreannullamentoEqualThis, DataannullamentoEqualThis, IdattoapprovazioneEqualThis,
FirmapredispostaEqualThis, FirmapredispostarupEqualThis);
            VariantiCollectionTemp.Provider = this;
            return VariantiCollectionTemp;
        }

        //Find: popola la collection
        public VariantiCollection Find(IntNT IdvarianteEqualThis, IntNT IdprogettoEqualThis, StringNT CodtipoEqualThis)
        {
            VariantiCollection VariantiCollectionTemp = VariantiDAL.Find(_dbProviderObj, IdvarianteEqualThis, IdprogettoEqualThis, CodtipoEqualThis);
            VariantiCollectionTemp.Provider = this;
            return VariantiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI>
  <ViewName>vVARIANTI</ViewName>
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
    <Find OrderBy="ORDER BY ID_VARIANTE DESC">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroGenerale>
      <APPROVATA>Equal</APPROVATA>
      <COD_TIPO>Equal</COD_TIPO>
      <PROVINCIA>Equal</PROVINCIA>
      <COD_TIPO>NotEqual</COD_TIPO>
      <SEGNATURA_APPROVAZIONE>IsNull</SEGNATURA_APPROVAZIONE>
      <SEGNATURA_ANNULLAMENTO>IsNull</SEGNATURA_ANNULLAMENTO>
      <CUAA_USCENTE>IsNull</CUAA_USCENTE>
      <ID_ATTO_APPROVAZIONE>IsNull</ID_ATTO_APPROVAZIONE>
    </FiltroGenerale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI>
*/
