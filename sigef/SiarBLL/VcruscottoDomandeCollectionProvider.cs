using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoDomande
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class VcruscottoDomande : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdBando;
        private NullTypes.StringNT _DescrizioneBando;
        private NullTypes.StringNT _CodEnteBando;
        private NullTypes.StringNT _CodStatoProgetto;
        private NullTypes.DatetimeNT _DataScadenzaBando;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.StringNT _Stato;
        private NullTypes.IntNT _IdImpresa;
        private NullTypes.StringNT _Impresa;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.StringNT _SegnaturaDomandaPagamento;
        private NullTypes.StringNT _FaseDomandaPagamento;
        private NullTypes.BoolNT _Annullata;
        private NullTypes.BoolNT _Approvata;
        private NullTypes.BoolNT _SelezionataXRevisione;
        private NullTypes.BoolNT _ApprovataRevisione;
        private NullTypes.StringNT _SegnaturaSecondaApprovazione;
        private NullTypes.IntNT _IdUtenteRup;
        private NullTypes.StringNT _Rup;
        private NullTypes.IntNT _IdUtenteIstruttore;
        private NullTypes.StringNT _Istruttore;
        private NullTypes.DecimalNT _ImportoRichiesto;
        private NullTypes.DecimalNT _ContributoRichiesto;
        private NullTypes.DecimalNT _ImportoAmmesso;
        private NullTypes.DecimalNT _ContributoAmmesso;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.BoolNT _FirmaPredispostaRup;


        //Costruttore
        public VcruscottoDomande()
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
        /// Corrisponde al campo:COD_ENTE_BANDO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnteBando
        {
            get { return _CodEnteBando; }
            set
            {
                if (CodEnteBando != value)
                {
                    _CodEnteBando = value;
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
        /// Corrisponde al campo:SEGNATURA_DOMANDA_PAGAMENTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaDomandaPagamento
        {
            get { return _SegnaturaDomandaPagamento; }
            set
            {
                if (SegnaturaDomandaPagamento != value)
                {
                    _SegnaturaDomandaPagamento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FASE_DOMANDA_PAGAMENTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT FaseDomandaPagamento
        {
            get { return _FaseDomandaPagamento; }
            set
            {
                if (FaseDomandaPagamento != value)
                {
                    _FaseDomandaPagamento = value;
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
        /// Corrisponde al campo:SELEZIONATA_X_REVISIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT SelezionataXRevisione
        {
            get { return _SelezionataXRevisione; }
            set
            {
                if (SelezionataXRevisione != value)
                {
                    _SelezionataXRevisione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:APPROVATA_REVISIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT ApprovataRevisione
        {
            get { return _ApprovataRevisione; }
            set
            {
                if (ApprovataRevisione != value)
                {
                    _ApprovataRevisione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:SEGNATURA_SECONDA_APPROVAZIONE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT SegnaturaSecondaApprovazione
        {
            get { return _SegnaturaSecondaApprovazione; }
            set
            {
                if (SegnaturaSecondaApprovazione != value)
                {
                    _SegnaturaSecondaApprovazione = value;
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
        /// Tipo sul db:VARCHAR(511)
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
        /// Corrisponde al campo:IMPORTO_RICHIESTO
        /// Tipo sul db:DECIMAL(38,2)
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
        /// Corrisponde al campo:CONTRIBUTO_RICHIESTO
        /// Tipo sul db:DECIMAL(38,2)
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
        /// Corrisponde al campo:IMPORTO_AMMESSO
        /// Tipo sul db:DECIMAL(38,2)
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
        /// Corrisponde al campo:CONTRIBUTO_AMMESSO
        /// Tipo sul db:DECIMAL(38,2)
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
        /// Corrisponde al campo:IN_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT InIntegrazione
        {
            get { return _InIntegrazione; }
            set
            {
                if (InIntegrazione != value)
                {
                    _InIntegrazione = value;
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




    }
}

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for VcruscottoDomandeCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoDomandeCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private VcruscottoDomandeCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((VcruscottoDomande)info.GetValue(i.ToString(), typeof(VcruscottoDomande)));
            }
        }

        //Costruttore
        public VcruscottoDomandeCollection()
        {
            this.ItemType = typeof(VcruscottoDomande);
        }

        //Get e Set
        public new VcruscottoDomande this[int index]
        {
            get { return (VcruscottoDomande)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new VcruscottoDomandeCollection GetChanges()
        {
            return (VcruscottoDomandeCollection)base.GetChanges();
        }

        //Add
        public int Add(VcruscottoDomande VcruscottoDomandeObj)
        {
            return base.Add(VcruscottoDomandeObj);
        }

        //AddCollection
        public void AddCollection(VcruscottoDomandeCollection VcruscottoDomandeCollectionObj)
        {
            foreach (VcruscottoDomande VcruscottoDomandeObj in VcruscottoDomandeCollectionObj)
                this.Add(VcruscottoDomandeObj);
        }

        //Insert
        public void Insert(int index, VcruscottoDomande VcruscottoDomandeObj)
        {
            base.Insert(index, VcruscottoDomandeObj);
        }

        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public VcruscottoDomandeCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.StringNT CodEnteBandoEqualThis,
NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.DatetimeNT DataScadenzaBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.StringNT StatoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT ImpresaEqualThis,
NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT SegnaturaDomandaPagamentoEqualThis, NullTypes.StringNT FaseDomandaPagamentoEqualThis,
NullTypes.BoolNT AnnullataEqualThis, NullTypes.BoolNT ApprovataEqualThis, NullTypes.BoolNT SelezionataXRevisioneEqualThis,
NullTypes.BoolNT ApprovataRevisioneEqualThis, NullTypes.StringNT SegnaturaSecondaApprovazioneEqualThis, NullTypes.IntNT IdUtenteRupEqualThis,
NullTypes.StringNT RupEqualThis, NullTypes.IntNT IdUtenteIstruttoreEqualThis, NullTypes.StringNT IstruttoreEqualThis,
NullTypes.DecimalNT ImportoRichiestoEqualThis, NullTypes.DecimalNT ContributoRichiestoEqualThis, NullTypes.DecimalNT ImportoAmmessoEqualThis,
NullTypes.DecimalNT ContributoAmmessoEqualThis, NullTypes.BoolNT InIntegrazioneEqualThis, NullTypes.BoolNT FirmaPredispostaRupEqualThis)
        {
            VcruscottoDomandeCollection VcruscottoDomandeCollectionTemp = new VcruscottoDomandeCollection();
            foreach (VcruscottoDomande VcruscottoDomandeItem in this)
            {
                if (((IdBandoEqualThis == null) || ((VcruscottoDomandeItem.IdBando != null) && (VcruscottoDomandeItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VcruscottoDomandeItem.DescrizioneBando != null) && (VcruscottoDomandeItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((CodEnteBandoEqualThis == null) || ((VcruscottoDomandeItem.CodEnteBando != null) && (VcruscottoDomandeItem.CodEnteBando.Value == CodEnteBandoEqualThis.Value))) &&
((CodStatoProgettoEqualThis == null) || ((VcruscottoDomandeItem.CodStatoProgetto != null) && (VcruscottoDomandeItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((DataScadenzaBandoEqualThis == null) || ((VcruscottoDomandeItem.DataScadenzaBando != null) && (VcruscottoDomandeItem.DataScadenzaBando.Value == DataScadenzaBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VcruscottoDomandeItem.IdProgetto != null) && (VcruscottoDomandeItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((StatoEqualThis == null) || ((VcruscottoDomandeItem.Stato != null) && (VcruscottoDomandeItem.Stato.Value == StatoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((VcruscottoDomandeItem.IdImpresa != null) && (VcruscottoDomandeItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((ImpresaEqualThis == null) || ((VcruscottoDomandeItem.Impresa != null) && (VcruscottoDomandeItem.Impresa.Value == ImpresaEqualThis.Value))) &&
((IdDomandaPagamentoEqualThis == null) || ((VcruscottoDomandeItem.IdDomandaPagamento != null) && (VcruscottoDomandeItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((SegnaturaDomandaPagamentoEqualThis == null) || ((VcruscottoDomandeItem.SegnaturaDomandaPagamento != null) && (VcruscottoDomandeItem.SegnaturaDomandaPagamento.Value == SegnaturaDomandaPagamentoEqualThis.Value))) && ((FaseDomandaPagamentoEqualThis == null) || ((VcruscottoDomandeItem.FaseDomandaPagamento != null) && (VcruscottoDomandeItem.FaseDomandaPagamento.Value == FaseDomandaPagamentoEqualThis.Value))) &&
((AnnullataEqualThis == null) || ((VcruscottoDomandeItem.Annullata != null) && (VcruscottoDomandeItem.Annullata.Value == AnnullataEqualThis.Value))) && ((ApprovataEqualThis == null) || ((VcruscottoDomandeItem.Approvata != null) && (VcruscottoDomandeItem.Approvata.Value == ApprovataEqualThis.Value))) && ((SelezionataXRevisioneEqualThis == null) || ((VcruscottoDomandeItem.SelezionataXRevisione != null) && (VcruscottoDomandeItem.SelezionataXRevisione.Value == SelezionataXRevisioneEqualThis.Value))) &&
((ApprovataRevisioneEqualThis == null) || ((VcruscottoDomandeItem.ApprovataRevisione != null) && (VcruscottoDomandeItem.ApprovataRevisione.Value == ApprovataRevisioneEqualThis.Value))) && ((SegnaturaSecondaApprovazioneEqualThis == null) || ((VcruscottoDomandeItem.SegnaturaSecondaApprovazione != null) && (VcruscottoDomandeItem.SegnaturaSecondaApprovazione.Value == SegnaturaSecondaApprovazioneEqualThis.Value))) && ((IdUtenteRupEqualThis == null) || ((VcruscottoDomandeItem.IdUtenteRup != null) && (VcruscottoDomandeItem.IdUtenteRup.Value == IdUtenteRupEqualThis.Value))) &&
((RupEqualThis == null) || ((VcruscottoDomandeItem.Rup != null) && (VcruscottoDomandeItem.Rup.Value == RupEqualThis.Value))) && ((IdUtenteIstruttoreEqualThis == null) || ((VcruscottoDomandeItem.IdUtenteIstruttore != null) && (VcruscottoDomandeItem.IdUtenteIstruttore.Value == IdUtenteIstruttoreEqualThis.Value))) && ((IstruttoreEqualThis == null) || ((VcruscottoDomandeItem.Istruttore != null) && (VcruscottoDomandeItem.Istruttore.Value == IstruttoreEqualThis.Value))) &&
((ImportoRichiestoEqualThis == null) || ((VcruscottoDomandeItem.ImportoRichiesto != null) && (VcruscottoDomandeItem.ImportoRichiesto.Value == ImportoRichiestoEqualThis.Value))) && ((ContributoRichiestoEqualThis == null) || ((VcruscottoDomandeItem.ContributoRichiesto != null) && (VcruscottoDomandeItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && ((ImportoAmmessoEqualThis == null) || ((VcruscottoDomandeItem.ImportoAmmesso != null) && (VcruscottoDomandeItem.ImportoAmmesso.Value == ImportoAmmessoEqualThis.Value))) &&
((ContributoAmmessoEqualThis == null) || ((VcruscottoDomandeItem.ContributoAmmesso != null) && (VcruscottoDomandeItem.ContributoAmmesso.Value == ContributoAmmessoEqualThis.Value))) && ((InIntegrazioneEqualThis == null) || ((VcruscottoDomandeItem.InIntegrazione != null) && (VcruscottoDomandeItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && ((FirmaPredispostaRupEqualThis == null) || ((VcruscottoDomandeItem.FirmaPredispostaRup != null) && (VcruscottoDomandeItem.FirmaPredispostaRup.Value == FirmaPredispostaRupEqualThis.Value))))
                {
                    VcruscottoDomandeCollectionTemp.Add(VcruscottoDomandeItem);
                }
            }
            return VcruscottoDomandeCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for VcruscottoDomandeDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class VcruscottoDomandeDAL
    {

        //Operazioni

        //getFromDatareader
        public static VcruscottoDomande GetFromDatareader(DbProvider db)
        {
            VcruscottoDomande VcruscottoDomandeObj = new VcruscottoDomande();
            VcruscottoDomandeObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
            VcruscottoDomandeObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
            VcruscottoDomandeObj.CodEnteBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_BANDO"]);
            VcruscottoDomandeObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
            VcruscottoDomandeObj.DataScadenzaBando = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA_BANDO"]);
            VcruscottoDomandeObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            VcruscottoDomandeObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
            VcruscottoDomandeObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
            VcruscottoDomandeObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
            VcruscottoDomandeObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            VcruscottoDomandeObj.SegnaturaDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_DOMANDA_PAGAMENTO"]);
            VcruscottoDomandeObj.FaseDomandaPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE_DOMANDA_PAGAMENTO"]);
            VcruscottoDomandeObj.Annullata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ANNULLATA"]);
            VcruscottoDomandeObj.Approvata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA"]);
            VcruscottoDomandeObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
            VcruscottoDomandeObj.ApprovataRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["APPROVATA_REVISIONE"]);
            VcruscottoDomandeObj.SegnaturaSecondaApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_SECONDA_APPROVAZIONE"]);
            VcruscottoDomandeObj.IdUtenteRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_RUP"]);
            VcruscottoDomandeObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
            VcruscottoDomandeObj.IdUtenteIstruttore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_UTENTE_ISTRUTTORE"]);
            VcruscottoDomandeObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
            VcruscottoDomandeObj.ImportoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_RICHIESTO"]);
            VcruscottoDomandeObj.ContributoRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_RICHIESTO"]);
            VcruscottoDomandeObj.ImportoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_AMMESSO"]);
            VcruscottoDomandeObj.ContributoAmmesso = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO_AMMESSO"]);
            VcruscottoDomandeObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            VcruscottoDomandeObj.FirmaPredispostaRup = new SiarLibrary.NullTypes.BoolNT(db.DataReader["FIRMA_PREDISPOSTA_RUP"]);
            VcruscottoDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            VcruscottoDomandeObj.IsDirty = false;
            VcruscottoDomandeObj.IsPersistent = true;
            return VcruscottoDomandeObj;
        }

        //Find Select

        public static VcruscottoDomandeCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis,
SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT ImpresaEqualThis,
SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT FaseDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.BoolNT AnnullataEqualThis, SiarLibrary.NullTypes.BoolNT ApprovataEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis,
SiarLibrary.NullTypes.BoolNT ApprovataRevisioneEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaSecondaApprovazioneEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteRupEqualThis,
SiarLibrary.NullTypes.StringNT RupEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis,
SiarLibrary.NullTypes.DecimalNT ImportoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ContributoRichiestoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoAmmessoEqualThis,
SiarLibrary.NullTypes.DecimalNT ContributoAmmessoEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis)

        {

            VcruscottoDomandeCollection VcruscottoDomandeCollectionObj = new VcruscottoDomandeCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottodomandefindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "CodEnteBandoequalthis",
"CodStatoProgettoequalthis", "DataScadenzaBandoequalthis", "IdProgettoequalthis",
"Statoequalthis", "IdImpresaequalthis", "Impresaequalthis",
"IdDomandaPagamentoequalthis", "SegnaturaDomandaPagamentoequalthis", "FaseDomandaPagamentoequalthis",
"Annullataequalthis", "Approvataequalthis", "SelezionataXRevisioneequalthis",
"ApprovataRevisioneequalthis", "SegnaturaSecondaApprovazioneequalthis", "IdUtenteRupequalthis",
"Rupequalthis", "IdUtenteIstruttoreequalthis", "Istruttoreequalthis",
"ImportoRichiestoequalthis", "ContributoRichiestoequalthis", "ImportoAmmessoequalthis",
"ContributoAmmessoequalthis", "InIntegrazioneequalthis", "FirmaPredispostaRupequalthis"}, new string[] {"int", "string", "string",
"string", "DateTime", "int",
"string", "int", "string",
"int", "string", "string",
"bool", "bool", "bool",
"bool", "string", "int",
"string", "int", "string",
"decimal", "decimal", "decimal",
"decimal", "bool", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaBandoequalthis", DataScadenzaBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaDomandaPagamentoequalthis", SegnaturaDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FaseDomandaPagamentoequalthis", FaseDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Annullataequalthis", AnnullataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Approvataequalthis", ApprovataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ApprovataRevisioneequalthis", ApprovataRevisioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "SegnaturaSecondaApprovazioneequalthis", SegnaturaSecondaApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteRupequalthis", IdUtenteRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Rupequalthis", RupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteIstruttoreequalthis", IdUtenteIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoRichiestoequalthis", ImportoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoRichiestoequalthis", ContributoRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoAmmessoequalthis", ImportoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ContributoAmmessoequalthis", ContributoAmmessoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
            VcruscottoDomande VcruscottoDomandeObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoDomandeObj = GetFromDatareader(db);
                VcruscottoDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoDomandeObj.IsDirty = false;
                VcruscottoDomandeObj.IsPersistent = true;
                VcruscottoDomandeCollectionObj.Add(VcruscottoDomandeObj);
            }
            db.Close();
            return VcruscottoDomandeCollectionObj;
        }

        //Find FindDomande

        public static VcruscottoDomandeCollection FindDomande(DbProvider db, SiarLibrary.NullTypes.IntNT IdUtenteRupEqualThis, SiarLibrary.NullTypes.BoolNT FirmaPredispostaRupEqualThis, SiarLibrary.NullTypes.IntNT IdUtenteIstruttoreEqualThis,
SiarLibrary.NullTypes.StringNT CodEnteBandoEqualThis, SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis,
SiarLibrary.NullTypes.IntNT IdProgettoEqualThis)

        {

            VcruscottoDomandeCollection VcruscottoDomandeCollectionObj = new VcruscottoDomandeCollection();

            IDbCommand findCmd = db.InitCmd("Zvcruscottodomandefindfinddomande", new string[] {"IdUtenteRupequalthis", "FirmaPredispostaRupequalthis", "IdUtenteIstruttoreequalthis",
"CodEnteBandoequalthis", "CodStatoProgettoequalthis", "IdDomandaPagamentoequalthis",
"IdProgettoequalthis"}, new string[] {"int", "bool", "int",
"string", "string", "int",
"int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteRupequalthis", IdUtenteRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "FirmaPredispostaRupequalthis", FirmaPredispostaRupEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdUtenteIstruttoreequalthis", IdUtenteIstruttoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteBandoequalthis", CodEnteBandoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            VcruscottoDomande VcruscottoDomandeObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                VcruscottoDomandeObj = GetFromDatareader(db);
                VcruscottoDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                VcruscottoDomandeObj.IsDirty = false;
                VcruscottoDomandeObj.IsPersistent = true;
                VcruscottoDomandeCollectionObj.Add(VcruscottoDomandeObj);
            }
            db.Close();
            return VcruscottoDomandeCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for VcruscottoDomandeCollectionProvider:IVcruscottoDomandeProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class VcruscottoDomandeCollectionProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di VcruscottoDomande
        protected VcruscottoDomandeCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public VcruscottoDomandeCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new VcruscottoDomandeCollection();
        }

        //Costruttore 2: popola la collection
        public VcruscottoDomandeCollectionProvider(IntNT IdutenterupEqualThis, BoolNT FirmapredispostarupEqualThis, IntNT IdutenteistruttoreEqualThis,
StringNT CodentebandoEqualThis, StringNT CodstatoprogettoEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = FindDomande(IdutenterupEqualThis, FirmapredispostarupEqualThis, IdutenteistruttoreEqualThis,
CodentebandoEqualThis, CodstatoprogettoEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis);
        }

        //Costruttore3: ha in input vcruscottodomandeCollectionObj - non popola la collection
        public VcruscottoDomandeCollectionProvider(VcruscottoDomandeCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public VcruscottoDomandeCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new VcruscottoDomandeCollection();
        }

        //Get e Set
        public VcruscottoDomandeCollection CollectionObj
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
        public VcruscottoDomandeCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, StringNT CodentebandoEqualThis,
StringNT CodstatoprogettoEqualThis, DatetimeNT DatascadenzabandoEqualThis, IntNT IdprogettoEqualThis,
StringNT StatoEqualThis, IntNT IdimpresaEqualThis, StringNT ImpresaEqualThis,
IntNT IddomandapagamentoEqualThis, StringNT SegnaturadomandapagamentoEqualThis, StringNT FasedomandapagamentoEqualThis,
BoolNT AnnullataEqualThis, BoolNT ApprovataEqualThis, BoolNT SelezionataxrevisioneEqualThis,
BoolNT ApprovatarevisioneEqualThis, StringNT SegnaturasecondaapprovazioneEqualThis, IntNT IdutenterupEqualThis,
StringNT RupEqualThis, IntNT IdutenteistruttoreEqualThis, StringNT IstruttoreEqualThis,
DecimalNT ImportorichiestoEqualThis, DecimalNT ContributorichiestoEqualThis, DecimalNT ImportoammessoEqualThis,
DecimalNT ContributoammessoEqualThis, BoolNT InintegrazioneEqualThis, BoolNT FirmapredispostarupEqualThis)
        {
            VcruscottoDomandeCollection VcruscottoDomandeCollectionTemp = VcruscottoDomandeDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, CodentebandoEqualThis,
CodstatoprogettoEqualThis, DatascadenzabandoEqualThis, IdprogettoEqualThis,
StatoEqualThis, IdimpresaEqualThis, ImpresaEqualThis,
IddomandapagamentoEqualThis, SegnaturadomandapagamentoEqualThis, FasedomandapagamentoEqualThis,
AnnullataEqualThis, ApprovataEqualThis, SelezionataxrevisioneEqualThis,
ApprovatarevisioneEqualThis, SegnaturasecondaapprovazioneEqualThis, IdutenterupEqualThis,
RupEqualThis, IdutenteistruttoreEqualThis, IstruttoreEqualThis,
ImportorichiestoEqualThis, ContributorichiestoEqualThis, ImportoammessoEqualThis,
ContributoammessoEqualThis, InintegrazioneEqualThis, FirmapredispostarupEqualThis);
            return VcruscottoDomandeCollectionTemp;
        }

        //FindDomande: popola la collection
        public VcruscottoDomandeCollection FindDomande(IntNT IdutenterupEqualThis, BoolNT FirmapredispostarupEqualThis, IntNT IdutenteistruttoreEqualThis,
StringNT CodentebandoEqualThis, StringNT CodstatoprogettoEqualThis, IntNT IddomandapagamentoEqualThis,
IntNT IdprogettoEqualThis)
        {
            VcruscottoDomandeCollection VcruscottoDomandeCollectionTemp = VcruscottoDomandeDAL.FindDomande(_dbProviderObj, IdutenterupEqualThis, FirmapredispostarupEqualThis, IdutenteistruttoreEqualThis,
CodentebandoEqualThis, CodstatoprogettoEqualThis, IddomandapagamentoEqualThis,
IdprogettoEqualThis);
            return VcruscottoDomandeCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VCRUSCOTTO_DOMANDE>
  <ViewName>VCRUSCOTTO_DOMANDE</ViewName>
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
    <FindDomande OrderBy="ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC, ID_DOMANDA_PAGAMENTO ASC">
      <ID_UTENTE_RUP>Equal</ID_UTENTE_RUP>
      <FIRMA_PREDISPOSTA_RUP>Equal</FIRMA_PREDISPOSTA_RUP>
      <ID_UTENTE_ISTRUTTORE>Equal</ID_UTENTE_ISTRUTTORE>
      <COD_ENTE_BANDO>Equal</COD_ENTE_BANDO>
      <COD_STATO_PROGETTO>Equal</COD_STATO_PROGETTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </FindDomande>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VCRUSCOTTO_DOMANDE>
*/
