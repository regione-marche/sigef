using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Errore
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IErroreProvider
    {
        int Save(Errore ErroreObj);
        int SaveCollection(ErroreCollection collectionObj);
        int Delete(Errore ErroreObj);
        int DeleteCollection(ErroreCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Errore
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Errore : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdErrore;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfModifica;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.DatetimeNT _DataRilevazione;
        private NullTypes.StringNT _ImpreseBeneficiari;
        private NullTypes.StringNT _SoggettoRilevazione;
        private NullTypes.BoolNT _Certificato;
        private NullTypes.IntNT _IdLottoCertificazione;
        private NullTypes.DatetimeNT _DataInizioCertificazione;
        private NullTypes.DecimalNT _SpesaAmmessaErrore;
        private NullTypes.DecimalNT _ContributoPubblicoErrore;
        private NullTypes.BoolNT _DaRecuperare;
        private NullTypes.BoolNT _Recuperato;
        private NullTypes.StringNT _AzioneCertificazione;
        private NullTypes.IntNT _IdLottoImpattato;
        private NullTypes.StringNT _Note;
        private NullTypes.DatetimeNT _DataFineCertificazione;
        private NullTypes.DecimalNT _ContributoAmmessoErrore;
        private NullTypes.DecimalNT _ContributoAmmessoErroreDaRevocare;
        private NullTypes.StringNT _NoteGiustificativi;
        private NullTypes.StringNT _IdAsse;
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _DescrizioneBando;
        private NullTypes.DatetimeNT _DataScadenzaBando;
        private NullTypes.StringNT _CodStatoProgetto;
        private NullTypes.StringNT _StatoProgetto;
        [NonSerialized] private IErroreProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IErroreProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Errore()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
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
        /// Corrisponde al campo:CF_INSERIMENTO
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfInserimento
        {
            get { return _CfInserimento; }
            set
            {
                if (CfInserimento != value)
                {
                    _CfInserimento = value;
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
        /// Corrisponde al campo:CF_MODIFICA
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfModifica
        {
            get { return _CfModifica; }
            set
            {
                if (CfModifica != value)
                {
                    _CfModifica = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_MODIFICA
        /// Tipo sul db:DATETIME
        /// Default:(getdate())
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
        /// Corrisponde al campo:DATA_RILEVAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRilevazione
        {
            get { return _DataRilevazione; }
            set
            {
                if (DataRilevazione != value)
                {
                    _DataRilevazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPRESE_BENEFICIARI
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT ImpreseBeneficiari
        {
            get { return _ImpreseBeneficiari; }
            set
            {
                if (ImpreseBeneficiari != value)
                {
                    _ImpreseBeneficiari = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SOGGETTO_RILEVAZIONE
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT SoggettoRilevazione
        {
            get { return _SoggettoRilevazione; }
            set
            {
                if (SoggettoRilevazione != value)
                {
                    _SoggettoRilevazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CERTIFICATO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Certificato
        {
            get { return _Certificato; }
            set
            {
                if (Certificato != value)
                {
                    _Certificato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_LOTTO_CERTIFICAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdLottoCertificazione
        {
            get { return _IdLottoCertificazione; }
            set
            {
                if (IdLottoCertificazione != value)
                {
                    _IdLottoCertificazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_INIZIO_CERTIFICAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataInizioCertificazione
        {
            get { return _DataInizioCertificazione; }
            set
            {
                if (DataInizioCertificazione != value)
                {
                    _DataInizioCertificazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SPESA_AMMESSA_ERRORE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT SpesaAmmessaErrore
        {
            get { return _SpesaAmmessaErrore; }
            set
            {
                if (SpesaAmmessaErrore != value)
                {
                    _SpesaAmmessaErrore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_PUBBLICO_ERRORE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoPubblicoErrore
        {
            get { return _ContributoPubblicoErrore; }
            set
            {
                if (ContributoPubblicoErrore != value)
                {
                    _ContributoPubblicoErrore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DA_RECUPERARE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT DaRecuperare
        {
            get { return _DaRecuperare; }
            set
            {
                if (DaRecuperare != value)
                {
                    _DaRecuperare = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RECUPERATO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT Recuperato
        {
            get { return _Recuperato; }
            set
            {
                if (Recuperato != value)
                {
                    _Recuperato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:AZIONE_CERTIFICAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT AzioneCertificazione
        {
            get { return _AzioneCertificazione; }
            set
            {
                if (AzioneCertificazione != value)
                {
                    _AzioneCertificazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_LOTTO_IMPATTATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdLottoImpattato
        {
            get { return _IdLottoImpattato; }
            set
            {
                if (IdLottoImpattato != value)
                {
                    _IdLottoImpattato = value;
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
        /// Corrisponde al campo:DATA_FINE_CERTIFICAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFineCertificazione
        {
            get { return _DataFineCertificazione; }
            set
            {
                if (DataFineCertificazione != value)
                {
                    _DataFineCertificazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO_ERRORE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAmmessoErrore
        {
            get { return _ContributoAmmessoErrore; }
            set
            {
                if (ContributoAmmessoErrore != value)
                {
                    _ContributoAmmessoErrore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO_ERRORE_DA_REVOCARE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ContributoAmmessoErroreDaRevocare
        {
            get { return _ContributoAmmessoErroreDaRevocare; }
            set
            {
                if (ContributoAmmessoErroreDaRevocare != value)
                {
                    _ContributoAmmessoErroreDaRevocare = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOTE_GIUSTIFICATIVI
        /// Tipo sul db:VARCHAR(-1)
        /// </summary>
        public NullTypes.StringNT NoteGiustificativi
        {
            get { return _NoteGiustificativi; }
            set
            {
                if (NoteGiustificativi != value)
                {
                    _NoteGiustificativi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_ASSE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT IdAsse
        {
            get { return _IdAsse; }
            set
            {
                if (IdAsse != value)
                {
                    _IdAsse = value;
                    SetDirtyFlag();
                }
            }
        }

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
        /// Corrisponde al campo:COD_STATO_PROGETTO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT CodStatoProgetto
        {
            get { return _CodStatoProgetto; }
            set
            {
                if (CodStatoProgetto != value)
                {
                    _CodStatoProgetto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STATO_PROGETTO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT StatoProgetto
        {
            get { return _StatoProgetto; }
            set
            {
                if (StatoProgetto != value)
                {
                    _StatoProgetto = value;
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
    /// Summary description for ErroreCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ErroreCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ErroreCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Errore)info.GetValue(i.ToString(), typeof(Errore)));
            }
        }

        //Costruttore
        public ErroreCollection()
        {
            this.ItemType = typeof(Errore);
        }

        //Costruttore con provider
        public ErroreCollection(IErroreProvider providerObj)
        {
            this.ItemType = typeof(Errore);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Errore this[int index]
        {
            get { return (Errore)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ErroreCollection GetChanges()
        {
            return (ErroreCollection)base.GetChanges();
        }

        [NonSerialized] private IErroreProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IErroreProvider Provider
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
        public int Add(Errore ErroreObj)
        {
            if (ErroreObj.Provider == null) ErroreObj.Provider = this.Provider;
            return base.Add(ErroreObj);
        }

        //AddCollection
        public void AddCollection(ErroreCollection ErroreCollectionObj)
        {
            foreach (Errore ErroreObj in ErroreCollectionObj)
                this.Add(ErroreObj);
        }

        //Insert
        public void Insert(int index, Errore ErroreObj)
        {
            if (ErroreObj.Provider == null) ErroreObj.Provider = this.Provider;
            base.Insert(index, ErroreObj);
        }

        //CollectionGetById
        public Errore CollectionGetById(NullTypes.IntNT IdErroreValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdErrore == IdErroreValue))
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
        public ErroreCollection SubSelect(NullTypes.IntNT IdErroreEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfModificaEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.DatetimeNT DataRilevazioneEqualThis, NullTypes.StringNT ImpreseBeneficiariEqualThis,
NullTypes.StringNT SoggettoRilevazioneEqualThis, NullTypes.BoolNT CertificatoEqualThis, NullTypes.IntNT IdLottoCertificazioneEqualThis,
NullTypes.DatetimeNT DataInizioCertificazioneEqualThis, NullTypes.DecimalNT SpesaAmmessaErroreEqualThis, NullTypes.DecimalNT ContributoPubblicoErroreEqualThis,
NullTypes.BoolNT DaRecuperareEqualThis, NullTypes.BoolNT RecuperatoEqualThis, NullTypes.StringNT AzioneCertificazioneEqualThis,
NullTypes.IntNT IdLottoImpattatoEqualThis, NullTypes.StringNT NoteEqualThis, NullTypes.DatetimeNT DataFineCertificazioneEqualThis,
NullTypes.DecimalNT ContributoAmmessoErroreEqualThis, NullTypes.DecimalNT ContributoAmmessoErroreDaRevocareEqualThis, NullTypes.StringNT NoteGiustificativiEqualThis)
        {
            ErroreCollection ErroreCollectionTemp = new ErroreCollection();
            foreach (Errore ErroreItem in this)
            {
                if (((IdErroreEqualThis == null) || ((ErroreItem.IdErrore != null) && (ErroreItem.IdErrore.Value == IdErroreEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((ErroreItem.IdProgetto != null) && (ErroreItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((ErroreItem.IdDomandaPagamento != null) && (ErroreItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((ErroreItem.CfInserimento != null) && (ErroreItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((ErroreItem.DataInserimento != null) && (ErroreItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfModificaEqualThis == null) || ((ErroreItem.CfModifica != null) && (ErroreItem.CfModifica.Value == CfModificaEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((ErroreItem.DataModifica != null) && (ErroreItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((DataRilevazioneEqualThis == null) || ((ErroreItem.DataRilevazione != null) && (ErroreItem.DataRilevazione.Value == DataRilevazioneEqualThis.Value))) && ((ImpreseBeneficiariEqualThis == null) || ((ErroreItem.ImpreseBeneficiari != null) && (ErroreItem.ImpreseBeneficiari.Value == ImpreseBeneficiariEqualThis.Value))) &&
((SoggettoRilevazioneEqualThis == null) || ((ErroreItem.SoggettoRilevazione != null) && (ErroreItem.SoggettoRilevazione.Value == SoggettoRilevazioneEqualThis.Value))) && ((CertificatoEqualThis == null) || ((ErroreItem.Certificato != null) && (ErroreItem.Certificato.Value == CertificatoEqualThis.Value))) && ((IdLottoCertificazioneEqualThis == null) || ((ErroreItem.IdLottoCertificazione != null) && (ErroreItem.IdLottoCertificazione.Value == IdLottoCertificazioneEqualThis.Value))) &&
((DataInizioCertificazioneEqualThis == null) || ((ErroreItem.DataInizioCertificazione != null) && (ErroreItem.DataInizioCertificazione.Value == DataInizioCertificazioneEqualThis.Value))) && ((SpesaAmmessaErroreEqualThis == null) || ((ErroreItem.SpesaAmmessaErrore != null) && (ErroreItem.SpesaAmmessaErrore.Value == SpesaAmmessaErroreEqualThis.Value))) && ((ContributoPubblicoErroreEqualThis == null) || ((ErroreItem.ContributoPubblicoErrore != null) && (ErroreItem.ContributoPubblicoErrore.Value == ContributoPubblicoErroreEqualThis.Value))) &&
((DaRecuperareEqualThis == null) || ((ErroreItem.DaRecuperare != null) && (ErroreItem.DaRecuperare.Value == DaRecuperareEqualThis.Value))) && ((RecuperatoEqualThis == null) || ((ErroreItem.Recuperato != null) && (ErroreItem.Recuperato.Value == RecuperatoEqualThis.Value))) && ((AzioneCertificazioneEqualThis == null) || ((ErroreItem.AzioneCertificazione != null) && (ErroreItem.AzioneCertificazione.Value == AzioneCertificazioneEqualThis.Value))) &&
((IdLottoImpattatoEqualThis == null) || ((ErroreItem.IdLottoImpattato != null) && (ErroreItem.IdLottoImpattato.Value == IdLottoImpattatoEqualThis.Value))) && ((NoteEqualThis == null) || ((ErroreItem.Note != null) && (ErroreItem.Note.Value == NoteEqualThis.Value))) && ((DataFineCertificazioneEqualThis == null) || ((ErroreItem.DataFineCertificazione != null) && (ErroreItem.DataFineCertificazione.Value == DataFineCertificazioneEqualThis.Value))) &&
((ContributoAmmessoErroreEqualThis == null) || ((ErroreItem.ContributoAmmessoErrore != null) && (ErroreItem.ContributoAmmessoErrore.Value == ContributoAmmessoErroreEqualThis.Value))) && ((ContributoAmmessoErroreDaRevocareEqualThis == null) || ((ErroreItem.ContributoAmmessoErroreDaRevocare != null) && (ErroreItem.ContributoAmmessoErroreDaRevocare.Value == ContributoAmmessoErroreDaRevocareEqualThis.Value))) && ((NoteGiustificativiEqualThis == null) || ((ErroreItem.NoteGiustificativi != null) && (ErroreItem.NoteGiustificativi.Value == NoteGiustificativiEqualThis.Value))))
                {
                    ErroreCollectionTemp.Add(ErroreItem);
                }
            }
            return ErroreCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ErroreDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ErroreDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Errore ErroreObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdErrore", ErroreObj.IdErrore);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", ErroreObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", ErroreObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", ErroreObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", ErroreObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", ErroreObj.CfModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", ErroreObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRilevazione", ErroreObj.DataRilevazione);
            DbProvider.SetCmdParam(cmd, firstChar + "ImpreseBeneficiari", ErroreObj.ImpreseBeneficiari);
            DbProvider.SetCmdParam(cmd, firstChar + "SoggettoRilevazione", ErroreObj.SoggettoRilevazione);
            DbProvider.SetCmdParam(cmd, firstChar + "Certificato", ErroreObj.Certificato);
            DbProvider.SetCmdParam(cmd, firstChar + "IdLottoCertificazione", ErroreObj.IdLottoCertificazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInizioCertificazione", ErroreObj.DataInizioCertificazione);
            DbProvider.SetCmdParam(cmd, firstChar + "SpesaAmmessaErrore", ErroreObj.SpesaAmmessaErrore);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoPubblicoErrore", ErroreObj.ContributoPubblicoErrore);
            DbProvider.SetCmdParam(cmd, firstChar + "DaRecuperare", ErroreObj.DaRecuperare);
            DbProvider.SetCmdParam(cmd, firstChar + "Recuperato", ErroreObj.Recuperato);
            DbProvider.SetCmdParam(cmd, firstChar + "AzioneCertificazione", ErroreObj.AzioneCertificazione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdLottoImpattato", ErroreObj.IdLottoImpattato);
            DbProvider.SetCmdParam(cmd, firstChar + "Note", ErroreObj.Note);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFineCertificazione", ErroreObj.DataFineCertificazione);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoAmmessoErrore", ErroreObj.ContributoAmmessoErrore);
            DbProvider.SetCmdParam(cmd, firstChar + "ContributoAmmessoErroreDaRevocare", ErroreObj.ContributoAmmessoErroreDaRevocare);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteGiustificativi", ErroreObj.NoteGiustificativi);
        }
        //Insert
        private static int Insert(DbProvider db, Errore ErroreObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZErroreInsert", new string[] {"IdProgetto", "IdDomandaPagamento",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "DataRilevazione", "ImpreseBeneficiari",
"SoggettoRilevazione", "Certificato", "IdLottoCertificazione",
"DataInizioCertificazione", "SpesaAmmessaErrore", "ContributoPubblicoErrore",
"DaRecuperare", "Recuperato", "AzioneCertificazione",
"IdLottoImpattato", "Note", "DataFineCertificazione",
"ContributoAmmessoErrore", "ContributoAmmessoErroreDaRevocare", "NoteGiustificativi",
}, new string[] {"int", "int",
"string", "DateTime", "string",
"DateTime", "DateTime", "string",
"string", "bool", "int",
"DateTime", "decimal", "decimal",
"bool", "bool", "string",
"int", "string", "DateTime",
"decimal", "decimal", "string",
}, "");
                CompileIUCmd(false, insertCmd, ErroreObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ErroreObj.IdErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE"]);
                    ErroreObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                }
                ErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroreObj.IsDirty = false;
                ErroreObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Errore ErroreObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZErroreUpdate", new string[] {"IdErrore", "IdProgetto", "IdDomandaPagamento",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "DataRilevazione", "ImpreseBeneficiari",
"SoggettoRilevazione", "Certificato", "IdLottoCertificazione",
"DataInizioCertificazione", "SpesaAmmessaErrore", "ContributoPubblicoErrore",
"DaRecuperare", "Recuperato", "AzioneCertificazione",
"IdLottoImpattato", "Note", "DataFineCertificazione",
"ContributoAmmessoErrore", "ContributoAmmessoErroreDaRevocare", "NoteGiustificativi",
}, new string[] {"int", "int", "int",
"string", "DateTime", "string",
"DateTime", "DateTime", "string",
"string", "bool", "int",
"DateTime", "decimal", "decimal",
"bool", "bool", "string",
"int", "string", "DateTime",
"decimal", "decimal", "string",
}, "");
                CompileIUCmd(true, updateCmd, ErroreObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    ErroreObj.DataModifica = d;
                }
                ErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroreObj.IsDirty = false;
                ErroreObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Errore ErroreObj)
        {
            switch (ErroreObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ErroreObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ErroreObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ErroreObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ErroreCollection ErroreCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZErroreUpdate", new string[] {"IdErrore", "IdProgetto", "IdDomandaPagamento",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "DataRilevazione", "ImpreseBeneficiari",
"SoggettoRilevazione", "Certificato", "IdLottoCertificazione",
"DataInizioCertificazione", "SpesaAmmessaErrore", "ContributoPubblicoErrore",
"DaRecuperare", "Recuperato", "AzioneCertificazione",
"IdLottoImpattato", "Note", "DataFineCertificazione",
"ContributoAmmessoErrore", "ContributoAmmessoErroreDaRevocare", "NoteGiustificativi",
}, new string[] {"int", "int", "int",
"string", "DateTime", "string",
"DateTime", "DateTime", "string",
"string", "bool", "int",
"DateTime", "decimal", "decimal",
"bool", "bool", "string",
"int", "string", "DateTime",
"decimal", "decimal", "string",
}, "");
                IDbCommand insertCmd = db.InitCmd("ZErroreInsert", new string[] {"IdProgetto", "IdDomandaPagamento",
"CfInserimento", "DataInserimento", "CfModifica",
"DataModifica", "DataRilevazione", "ImpreseBeneficiari",
"SoggettoRilevazione", "Certificato", "IdLottoCertificazione",
"DataInizioCertificazione", "SpesaAmmessaErrore", "ContributoPubblicoErrore",
"DaRecuperare", "Recuperato", "AzioneCertificazione",
"IdLottoImpattato", "Note", "DataFineCertificazione",
"ContributoAmmessoErrore", "ContributoAmmessoErroreDaRevocare", "NoteGiustificativi",
}, new string[] {"int", "int",
"string", "DateTime", "string",
"DateTime", "DateTime", "string",
"string", "bool", "int",
"DateTime", "decimal", "decimal",
"bool", "bool", "string",
"int", "string", "DateTime",
"decimal", "decimal", "string",
}, "");
                IDbCommand deleteCmd = db.InitCmd("ZErroreDelete", new string[] { "IdErrore" }, new string[] { "int" }, "");
                for (int i = 0; i < ErroreCollectionObj.Count; i++)
                {
                    switch (ErroreCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ErroreCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ErroreCollectionObj[i].IdErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE"]);
                                    ErroreCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ErroreCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    ErroreCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ErroreCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdErrore", (SiarLibrary.NullTypes.IntNT)ErroreCollectionObj[i].IdErrore);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ErroreCollectionObj.Count; i++)
                {
                    if ((ErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ErroreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ErroreCollectionObj[i].IsDirty = false;
                        ErroreCollectionObj[i].IsPersistent = true;
                    }
                    if ((ErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ErroreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ErroreCollectionObj[i].IsDirty = false;
                        ErroreCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Errore ErroreObj)
        {
            int returnValue = 0;
            if (ErroreObj.IsPersistent)
            {
                returnValue = Delete(db, ErroreObj.IdErrore);
            }
            ErroreObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ErroreObj.IsDirty = false;
            ErroreObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdErroreValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZErroreDelete", new string[] { "IdErrore" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdErrore", (SiarLibrary.NullTypes.IntNT)IdErroreValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ErroreCollection ErroreCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZErroreDelete", new string[] { "IdErrore" }, new string[] { "int" }, "");
                for (int i = 0; i < ErroreCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdErrore", ErroreCollectionObj[i].IdErrore);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ErroreCollectionObj.Count; i++)
                {
                    if ((ErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ErroreCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ErroreCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ErroreCollectionObj[i].IsDirty = false;
                        ErroreCollectionObj[i].IsPersistent = false;
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
        public static Errore GetById(DbProvider db, int IdErroreValue)
        {
            Errore ErroreObj = null;
            IDbCommand readCmd = db.InitCmd("ZErroreGetById", new string[] { "IdErrore" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdErrore", (SiarLibrary.NullTypes.IntNT)IdErroreValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ErroreObj = GetFromDatareader(db);
                ErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroreObj.IsDirty = false;
                ErroreObj.IsPersistent = true;
            }
            db.Close();
            return ErroreObj;
        }

        //getFromDatareader
        public static Errore GetFromDatareader(DbProvider db)
        {
            Errore ErroreObj = new Errore();
            ErroreObj.IdErrore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ERRORE"]);
            ErroreObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            ErroreObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            ErroreObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            ErroreObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            ErroreObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            ErroreObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            ErroreObj.DataRilevazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RILEVAZIONE"]);
            ErroreObj.ImpreseBeneficiari = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESE_BENEFICIARI"]);
            ErroreObj.SoggettoRilevazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SOGGETTO_RILEVAZIONE"]);
            ErroreObj.Certificato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CERTIFICATO"]);
            ErroreObj.IdLottoCertificazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_CERTIFICAZIONE"]);
            ErroreObj.DataInizioCertificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INIZIO_CERTIFICAZIONE"]);
            ErroreObj.SpesaAmmessaErrore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["SPESA_AMMESSA_ERRORE"]);
            ErroreObj.ContributoPubblicoErrore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_PUBBLICO_ERRORE"]);
            ErroreObj.DaRecuperare = new SiarLibrary.NullTypes.BoolNT(db.DataReader["DA_RECUPERARE"]);
            ErroreObj.Recuperato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERATO"]);
            ErroreObj.AzioneCertificazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["AZIONE_CERTIFICAZIONE"]);
            ErroreObj.IdLottoImpattato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_LOTTO_IMPATTATO"]);
            ErroreObj.Note = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE"]);
            ErroreObj.DataFineCertificazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_CERTIFICAZIONE"]);
            ErroreObj.ContributoAmmessoErrore = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_ERRORE"]);
            ErroreObj.ContributoAmmessoErroreDaRevocare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO_ERRORE_DA_REVOCARE"]);
            ErroreObj.NoteGiustificativi = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_GIUSTIFICATIVI"]);
            ErroreObj.IdAsse = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_ASSE"]);
            ErroreObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            ErroreObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
            ErroreObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
            ErroreObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
            ErroreObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
            ErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ErroreObj.IsDirty = false;
            ErroreObj.IsPersistent = true;
            return ErroreObj;
        }

        //Find Select

        public static ErroreCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdErroreEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRilevazioneEqualThis, SiarLibrary.NullTypes.StringNT ImpreseBeneficiariEqualThis,
SiarLibrary.NullTypes.StringNT SoggettoRilevazioneEqualThis, SiarLibrary.NullTypes.BoolNT CertificatoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoCertificazioneEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInizioCertificazioneEqualThis, SiarLibrary.NullTypes.DecimalNT SpesaAmmessaErroreEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoPubblicoErroreEqualThis,
SiarLibrary.NullTypes.BoolNT DaRecuperareEqualThis, SiarLibrary.NullTypes.BoolNT RecuperatoEqualThis, SiarLibrary.NullTypes.StringNT AzioneCertificazioneEqualThis,
SiarLibrary.NullTypes.IntNT IdLottoImpattatoEqualThis, SiarLibrary.NullTypes.StringNT NoteEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineCertificazioneEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoAmmessoErroreEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoAmmessoErroreDaRevocareEqualThis, SiarLibrary.NullTypes.StringNT NoteGiustificativiEqualThis)

        {

            ErroreCollection ErroreCollectionObj = new ErroreCollection();

            IDbCommand findCmd = db.InitCmd("Zerrorefindselect", new string[] {"IdErroreequalthis", "IdProgettoequalthis", "IdDomandaPagamentoequalthis",
"CfInserimentoequalthis", "DataInserimentoequalthis", "CfModificaequalthis",
"DataModificaequalthis", "DataRilevazioneequalthis", "ImpreseBeneficiariequalthis",
"SoggettoRilevazioneequalthis", "Certificatoequalthis", "IdLottoCertificazioneequalthis",
"DataInizioCertificazioneequalthis", "SpesaAmmessaErroreequalthis", "ContributoPubblicoErroreequalthis",
"DaRecuperareequalthis", "Recuperatoequalthis", "AzioneCertificazioneequalthis",
"IdLottoImpattatoequalthis", "Noteequalthis", "DataFineCertificazioneequalthis",
"ContributoAmmessoErroreequalthis", "ContributoAmmessoErroreDaRevocareequalthis", "NoteGiustificativiequalthis"}, new string[] {"int", "int", "int",
"string", "DateTime", "string",
"DateTime", "DateTime", "string",
"string", "bool", "int",
"DateTime", "decimal", "decimal",
"bool", "bool", "string",
"int", "string", "DateTime",
"decimal", "decimal", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRilevazioneequalthis", DataRilevazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImpreseBeneficiariequalthis", ImpreseBeneficiariEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SoggettoRilevazioneequalthis", SoggettoRilevazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Certificatoequalthis", CertificatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoCertificazioneequalthis", IdLottoCertificazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInizioCertificazioneequalthis", DataInizioCertificazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SpesaAmmessaErroreequalthis", SpesaAmmessaErroreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoPubblicoErroreequalthis", ContributoPubblicoErroreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DaRecuperareequalthis", DaRecuperareEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Recuperatoequalthis", RecuperatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AzioneCertificazioneequalthis", AzioneCertificazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoImpattatoequalthis", IdLottoImpattatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Noteequalthis", NoteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineCertificazioneequalthis", DataFineCertificazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoErroreequalthis", ContributoAmmessoErroreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoErroreDaRevocareequalthis", ContributoAmmessoErroreDaRevocareEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NoteGiustificativiequalthis", NoteGiustificativiEqualThis);
            Errore ErroreObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ErroreObj = GetFromDatareader(db);
                ErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroreObj.IsDirty = false;
                ErroreObj.IsPersistent = true;
                ErroreCollectionObj.Add(ErroreObj);
            }
            db.Close();
            return ErroreCollectionObj;
        }

        //Find Find

        public static ErroreCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdErroreEqualThis, SiarLibrary.NullTypes.StringNT IdAsseEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdLottoCertificazioneEqualThis)

        {

            ErroreCollection ErroreCollectionObj = new ErroreCollection();

            IDbCommand findCmd = db.InitCmd("Zerrorefindfind", new string[] {"IdErroreequalthis", "IdAsseequalthis", "IdBandoequalthis",
"IdProgettoequalthis", "IdDomandaPagamentoequalthis", "IdLottoCertificazioneequalthis"}, new string[] {"int", "string", "int",
"int", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdErroreequalthis", IdErroreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAsseequalthis", IdAsseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdLottoCertificazioneequalthis", IdLottoCertificazioneEqualThis);
            Errore ErroreObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ErroreObj = GetFromDatareader(db);
                ErroreObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ErroreObj.IsDirty = false;
                ErroreObj.IsPersistent = true;
                ErroreCollectionObj.Add(ErroreObj);
            }
            db.Close();
            return ErroreCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ErroreCollectionProvider:IErroreProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ErroreCollectionProvider : IErroreProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Errore
        protected ErroreCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ErroreCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ErroreCollection(this);
        }

        //Costruttore 2: popola la collection
        public ErroreCollectionProvider(IntNT IderroreEqualThis, StringNT IdasseEqualThis, IntNT IdbandoEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdlottocertificazioneEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IderroreEqualThis, IdasseEqualThis, IdbandoEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IdlottocertificazioneEqualThis);
        }

        //Costruttore3: ha in input erroreCollectionObj - non popola la collection
        public ErroreCollectionProvider(ErroreCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ErroreCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ErroreCollection(this);
        }

        //Get e Set
        public ErroreCollection CollectionObj
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
        public int SaveCollection(ErroreCollection collectionObj)
        {
            return ErroreDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Errore erroreObj)
        {
            return ErroreDAL.Save(_dbProviderObj, erroreObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ErroreCollection collectionObj)
        {
            return ErroreDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Errore erroreObj)
        {
            return ErroreDAL.Delete(_dbProviderObj, erroreObj);
        }

        //getById
        public Errore GetById(IntNT IdErroreValue)
        {
            Errore ErroreTemp = ErroreDAL.GetById(_dbProviderObj, IdErroreValue);
            if (ErroreTemp != null) ErroreTemp.Provider = this;
            return ErroreTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ErroreCollection Select(IntNT IderroreEqualThis, IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatainserimentoEqualThis, StringNT CfmodificaEqualThis,
DatetimeNT DatamodificaEqualThis, DatetimeNT DatarilevazioneEqualThis, StringNT ImpresebeneficiariEqualThis,
StringNT SoggettorilevazioneEqualThis, BoolNT CertificatoEqualThis, IntNT IdlottocertificazioneEqualThis,
DatetimeNT DatainiziocertificazioneEqualThis, DecimalNT SpesaammessaerroreEqualThis, DecimalNT ContributopubblicoerroreEqualThis,
BoolNT DarecuperareEqualThis, BoolNT RecuperatoEqualThis, StringNT AzionecertificazioneEqualThis,
IntNT IdlottoimpattatoEqualThis, StringNT NoteEqualThis, DatetimeNT DatafinecertificazioneEqualThis,
DecimalNT ContributoammessoerroreEqualThis, DecimalNT ContributoammessoerroredarevocareEqualThis, StringNT NotegiustificativiEqualThis)
        {
            ErroreCollection ErroreCollectionTemp = ErroreDAL.Select(_dbProviderObj, IderroreEqualThis, IdprogettoEqualThis, IddomandapagamentoEqualThis,
CfinserimentoEqualThis, DatainserimentoEqualThis, CfmodificaEqualThis,
DatamodificaEqualThis, DatarilevazioneEqualThis, ImpresebeneficiariEqualThis,
SoggettorilevazioneEqualThis, CertificatoEqualThis, IdlottocertificazioneEqualThis,
DatainiziocertificazioneEqualThis, SpesaammessaerroreEqualThis, ContributopubblicoerroreEqualThis,
DarecuperareEqualThis, RecuperatoEqualThis, AzionecertificazioneEqualThis,
IdlottoimpattatoEqualThis, NoteEqualThis, DatafinecertificazioneEqualThis,
ContributoammessoerroreEqualThis, ContributoammessoerroredarevocareEqualThis, NotegiustificativiEqualThis);
            ErroreCollectionTemp.Provider = this;
            return ErroreCollectionTemp;
        }

        //Find: popola la collection
        public ErroreCollection Find(IntNT IderroreEqualThis, StringNT IdasseEqualThis, IntNT IdbandoEqualThis,
IntNT IdprogettoEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdlottocertificazioneEqualThis)
        {
            ErroreCollection ErroreCollectionTemp = ErroreDAL.Find(_dbProviderObj, IderroreEqualThis, IdasseEqualThis, IdbandoEqualThis,
IdprogettoEqualThis, IddomandapagamentoEqualThis, IdlottocertificazioneEqualThis);
            ErroreCollectionTemp.Provider = this;
            return ErroreCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ERRORE>
  <ViewName>VERRORE</ViewName>
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
      <ID_ERRORE>Equal</ID_ERRORE>
      <ID_ASSE>Equal</ID_ASSE>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_LOTTO_CERTIFICAZIONE>Equal</ID_LOTTO_CERTIFICAZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ERRORE>
*/
