using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Fidejussioni
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IFidejussioniProvider
    {
        int Save(Fidejussioni FidejussioniObj);
        int SaveCollection(FidejussioniCollection collectionObj);
        int Delete(Fidejussioni FidejussioniObj);
        int DeleteCollection(FidejussioniCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Fidejussioni
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Fidejussioni : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdFidejussione;
        private NullTypes.StringNT _Numero;
        private NullTypes.StringNT _Barcode;
        private NullTypes.DatetimeNT _DataSottoscrizione;
        private NullTypes.StringNT _LuogoSottoscrizione;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.DecimalNT _AmmontareRichiesto;
        private NullTypes.DatetimeNT _DataFineLavori;
        private NullTypes.DatetimeNT _DataScadenza;
        private NullTypes.BoolNT _ProrogaScadenza;
        private NullTypes.StringNT _PivaGarante;
        private NullTypes.StringNT _RagioneSocialeGarante;
        private NullTypes.StringNT _LocalitaGarante;
        private NullTypes.StringNT _NumeroRegistroImprese;
        private NullTypes.StringNT _CognomeRapplegale;
        private NullTypes.StringNT _NomeRapplegale;
        private NullTypes.StringNT _CfRapplegale;
        private NullTypes.DatetimeNT _DataNascitaRapplegale;
        private NullTypes.BoolNT _StampaEffettuata;
        private NullTypes.DatetimeNT _DataRichiestaValidita;
        private NullTypes.DatetimeNT _DataRicevimentoValidita;
        private NullTypes.StringNT _ProtocolloFaxValidita;
        private NullTypes.DatetimeNT _DataDecorrenzaGaranzia;
        private NullTypes.StringNT _CodiceAbiEnteGarante;
        private NullTypes.StringNT _CodiceCabEnteGarante;
        private NullTypes.StringNT _BarcodeConfermaValidita;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _UfficioApprovazione;
        private NullTypes.IntNT _NumDecretoApprovazione;
        private NullTypes.DatetimeNT _DataDecretoApprovazione;
        [NonSerialized] private IFidejussioniProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IFidejussioniProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Fidejussioni()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_FIDEJUSSIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFidejussione
        {
            get { return _IdFidejussione; }
            set
            {
                if (IdFidejussione != value)
                {
                    _IdFidejussione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:VARCHAR(25)
        /// </summary>
        public NullTypes.StringNT Numero
        {
            get { return _Numero; }
            set
            {
                if (Numero != value)
                {
                    _Numero = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:BARCODE
        /// Tipo sul db:VARCHAR(11)
        /// </summary>
        public NullTypes.StringNT Barcode
        {
            get { return _Barcode; }
            set
            {
                if (Barcode != value)
                {
                    _Barcode = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_SOTTOSCRIZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataSottoscrizione
        {
            get { return _DataSottoscrizione; }
            set
            {
                if (DataSottoscrizione != value)
                {
                    _DataSottoscrizione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LUOGO_SOTTOSCRIZIONE
        /// Tipo sul db:VARCHAR(128)
        /// </summary>
        public NullTypes.StringNT LuogoSottoscrizione
        {
            get { return _LuogoSottoscrizione; }
            set
            {
                if (LuogoSottoscrizione != value)
                {
                    _LuogoSottoscrizione = value;
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
        /// Corrisponde al campo:AMMONTARE_RICHIESTO
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT AmmontareRichiesto
        {
            get { return _AmmontareRichiesto; }
            set
            {
                if (AmmontareRichiesto != value)
                {
                    _AmmontareRichiesto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_FINE_LAVORI
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataFineLavori
        {
            get { return _DataFineLavori; }
            set
            {
                if (DataFineLavori != value)
                {
                    _DataFineLavori = value;
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
        /// Corrisponde al campo:PROROGA_SCADENZA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT ProrogaScadenza
        {
            get { return _ProrogaScadenza; }
            set
            {
                if (ProrogaScadenza != value)
                {
                    _ProrogaScadenza = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PIVA_GARANTE
        /// Tipo sul db:VARCHAR(11)
        /// </summary>
        public NullTypes.StringNT PivaGarante
        {
            get { return _PivaGarante; }
            set
            {
                if (PivaGarante != value)
                {
                    _PivaGarante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RAGIONE_SOCIALE_GARANTE
        /// Tipo sul db:VARCHAR(150)
        /// </summary>
        public NullTypes.StringNT RagioneSocialeGarante
        {
            get { return _RagioneSocialeGarante; }
            set
            {
                if (RagioneSocialeGarante != value)
                {
                    _RagioneSocialeGarante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LOCALITA_GARANTE
        /// Tipo sul db:VARCHAR(128)
        /// </summary>
        public NullTypes.StringNT LocalitaGarante
        {
            get { return _LocalitaGarante; }
            set
            {
                if (LocalitaGarante != value)
                {
                    _LocalitaGarante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_REGISTRO_IMPRESE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT NumeroRegistroImprese
        {
            get { return _NumeroRegistroImprese; }
            set
            {
                if (NumeroRegistroImprese != value)
                {
                    _NumeroRegistroImprese = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COGNOME_RAPPLEGALE
        /// Tipo sul db:VARCHAR(30)
        /// </summary>
        public NullTypes.StringNT CognomeRapplegale
        {
            get { return _CognomeRapplegale; }
            set
            {
                if (CognomeRapplegale != value)
                {
                    _CognomeRapplegale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NOME_RAPPLEGALE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT NomeRapplegale
        {
            get { return _NomeRapplegale; }
            set
            {
                if (NomeRapplegale != value)
                {
                    _NomeRapplegale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CF_RAPPLEGALE
        /// Tipo sul db:VARCHAR(16)
        /// </summary>
        public NullTypes.StringNT CfRapplegale
        {
            get { return _CfRapplegale; }
            set
            {
                if (CfRapplegale != value)
                {
                    _CfRapplegale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_NASCITA_RAPPLEGALE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataNascitaRapplegale
        {
            get { return _DataNascitaRapplegale; }
            set
            {
                if (DataNascitaRapplegale != value)
                {
                    _DataNascitaRapplegale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:STAMPA_EFFETTUATA
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT StampaEffettuata
        {
            get { return _StampaEffettuata; }
            set
            {
                if (StampaEffettuata != value)
                {
                    _StampaEffettuata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_RICHIESTA_VALIDITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRichiestaValidita
        {
            get { return _DataRichiestaValidita; }
            set
            {
                if (DataRichiestaValidita != value)
                {
                    _DataRichiestaValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_RICEVIMENTO_VALIDITA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataRicevimentoValidita
        {
            get { return _DataRicevimentoValidita; }
            set
            {
                if (DataRicevimentoValidita != value)
                {
                    _DataRicevimentoValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:PROTOCOLLO_FAX_VALIDITA
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT ProtocolloFaxValidita
        {
            get { return _ProtocolloFaxValidita; }
            set
            {
                if (ProtocolloFaxValidita != value)
                {
                    _ProtocolloFaxValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_DECORRENZA_GARANZIA
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataDecorrenzaGaranzia
        {
            get { return _DataDecorrenzaGaranzia; }
            set
            {
                if (DataDecorrenzaGaranzia != value)
                {
                    _DataDecorrenzaGaranzia = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_ABI_ENTE_GARANTE
        /// Tipo sul db:VARCHAR(5)
        /// </summary>
        public NullTypes.StringNT CodiceAbiEnteGarante
        {
            get { return _CodiceAbiEnteGarante; }
            set
            {
                if (CodiceAbiEnteGarante != value)
                {
                    _CodiceAbiEnteGarante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:CODICE_CAB_ENTE_GARANTE
        /// Tipo sul db:VARCHAR(5)
        /// </summary>
        public NullTypes.StringNT CodiceCabEnteGarante
        {
            get { return _CodiceCabEnteGarante; }
            set
            {
                if (CodiceCabEnteGarante != value)
                {
                    _CodiceCabEnteGarante = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:BARCODE_CONFERMA_VALIDITA
        /// Tipo sul db:VARCHAR(11)
        /// </summary>
        public NullTypes.StringNT BarcodeConfermaValidita
        {
            get { return _BarcodeConfermaValidita; }
            set
            {
                if (BarcodeConfermaValidita != value)
                {
                    _BarcodeConfermaValidita = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(3)
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
        /// Corrisponde al campo:UFFICIO_APPROVAZIONE
        /// Tipo sul db:VARCHAR(120)
        /// </summary>
        public NullTypes.StringNT UfficioApprovazione
        {
            get { return _UfficioApprovazione; }
            set
            {
                if (UfficioApprovazione != value)
                {
                    _UfficioApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUM_DECRETO_APPROVAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumDecretoApprovazione
        {
            get { return _NumDecretoApprovazione; }
            set
            {
                if (NumDecretoApprovazione != value)
                {
                    _NumDecretoApprovazione = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_DECRETO_APPROVAZIONE
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataDecretoApprovazione
        {
            get { return _DataDecretoApprovazione; }
            set
            {
                if (DataDecretoApprovazione != value)
                {
                    _DataDecretoApprovazione = value;
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
    /// Summary description for FidejussioniCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class FidejussioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private FidejussioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Fidejussioni)info.GetValue(i.ToString(), typeof(Fidejussioni)));
            }
        }

        //Costruttore
        public FidejussioniCollection()
        {
            this.ItemType = typeof(Fidejussioni);
        }

        //Costruttore con provider
        public FidejussioniCollection(IFidejussioniProvider providerObj)
        {
            this.ItemType = typeof(Fidejussioni);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Fidejussioni this[int index]
        {
            get { return (Fidejussioni)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new FidejussioniCollection GetChanges()
        {
            return (FidejussioniCollection)base.GetChanges();
        }

        [NonSerialized] private IFidejussioniProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IFidejussioniProvider Provider
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
        public int Add(Fidejussioni FidejussioniObj)
        {
            if (FidejussioniObj.Provider == null) FidejussioniObj.Provider = this.Provider;
            return base.Add(FidejussioniObj);
        }

        //AddCollection
        public void AddCollection(FidejussioniCollection FidejussioniCollectionObj)
        {
            foreach (Fidejussioni FidejussioniObj in FidejussioniCollectionObj)
                this.Add(FidejussioniObj);
        }

        //Insert
        public void Insert(int index, Fidejussioni FidejussioniObj)
        {
            if (FidejussioniObj.Provider == null) FidejussioniObj.Provider = this.Provider;
            base.Insert(index, FidejussioniObj);
        }

        //CollectionGetById
        public Fidejussioni CollectionGetById(NullTypes.IntNT IdFidejussioneValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdFidejussione == IdFidejussioneValue))
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
        public FidejussioniCollection SubSelect(NullTypes.IntNT IdFidejussioneEqualThis, NullTypes.StringNT NumeroEqualThis, NullTypes.StringNT BarcodeEqualThis,
NullTypes.DatetimeNT DataSottoscrizioneEqualThis, NullTypes.StringNT LuogoSottoscrizioneEqualThis, NullTypes.DecimalNT ImportoEqualThis,
NullTypes.DecimalNT AmmontareRichiestoEqualThis, NullTypes.DatetimeNT DataFineLavoriEqualThis, NullTypes.DatetimeNT DataScadenzaEqualThis,
NullTypes.BoolNT ProrogaScadenzaEqualThis, NullTypes.StringNT PivaGaranteEqualThis, NullTypes.StringNT RagioneSocialeGaranteEqualThis,
NullTypes.StringNT LocalitaGaranteEqualThis, NullTypes.StringNT NumeroRegistroImpreseEqualThis, NullTypes.StringNT CognomeRapplegaleEqualThis,
NullTypes.StringNT NomeRapplegaleEqualThis, NullTypes.StringNT CfRapplegaleEqualThis, NullTypes.DatetimeNT DataNascitaRapplegaleEqualThis,
NullTypes.BoolNT StampaEffettuataEqualThis, NullTypes.DatetimeNT DataRichiestaValiditaEqualThis, NullTypes.DatetimeNT DataRicevimentoValiditaEqualThis,
NullTypes.StringNT ProtocolloFaxValiditaEqualThis, NullTypes.DatetimeNT DataDecorrenzaGaranziaEqualThis, NullTypes.StringNT CodiceAbiEnteGaranteEqualThis,
NullTypes.StringNT CodiceCabEnteGaranteEqualThis, NullTypes.StringNT BarcodeConfermaValiditaEqualThis, NullTypes.StringNT CodTipoEqualThis,
NullTypes.StringNT UfficioApprovazioneEqualThis, NullTypes.IntNT NumDecretoApprovazioneEqualThis, NullTypes.DatetimeNT DataDecretoApprovazioneEqualThis)
        {
            FidejussioniCollection FidejussioniCollectionTemp = new FidejussioniCollection();
            foreach (Fidejussioni FidejussioniItem in this)
            {
                if (((IdFidejussioneEqualThis == null) || ((FidejussioniItem.IdFidejussione != null) && (FidejussioniItem.IdFidejussione.Value == IdFidejussioneEqualThis.Value))) && ((NumeroEqualThis == null) || ((FidejussioniItem.Numero != null) && (FidejussioniItem.Numero.Value == NumeroEqualThis.Value))) && ((BarcodeEqualThis == null) || ((FidejussioniItem.Barcode != null) && (FidejussioniItem.Barcode.Value == BarcodeEqualThis.Value))) &&
((DataSottoscrizioneEqualThis == null) || ((FidejussioniItem.DataSottoscrizione != null) && (FidejussioniItem.DataSottoscrizione.Value == DataSottoscrizioneEqualThis.Value))) && ((LuogoSottoscrizioneEqualThis == null) || ((FidejussioniItem.LuogoSottoscrizione != null) && (FidejussioniItem.LuogoSottoscrizione.Value == LuogoSottoscrizioneEqualThis.Value))) && ((ImportoEqualThis == null) || ((FidejussioniItem.Importo != null) && (FidejussioniItem.Importo.Value == ImportoEqualThis.Value))) &&
((AmmontareRichiestoEqualThis == null) || ((FidejussioniItem.AmmontareRichiesto != null) && (FidejussioniItem.AmmontareRichiesto.Value == AmmontareRichiestoEqualThis.Value))) && ((DataFineLavoriEqualThis == null) || ((FidejussioniItem.DataFineLavori != null) && (FidejussioniItem.DataFineLavori.Value == DataFineLavoriEqualThis.Value))) && ((DataScadenzaEqualThis == null) || ((FidejussioniItem.DataScadenza != null) && (FidejussioniItem.DataScadenza.Value == DataScadenzaEqualThis.Value))) &&
((ProrogaScadenzaEqualThis == null) || ((FidejussioniItem.ProrogaScadenza != null) && (FidejussioniItem.ProrogaScadenza.Value == ProrogaScadenzaEqualThis.Value))) && ((PivaGaranteEqualThis == null) || ((FidejussioniItem.PivaGarante != null) && (FidejussioniItem.PivaGarante.Value == PivaGaranteEqualThis.Value))) && ((RagioneSocialeGaranteEqualThis == null) || ((FidejussioniItem.RagioneSocialeGarante != null) && (FidejussioniItem.RagioneSocialeGarante.Value == RagioneSocialeGaranteEqualThis.Value))) &&
((LocalitaGaranteEqualThis == null) || ((FidejussioniItem.LocalitaGarante != null) && (FidejussioniItem.LocalitaGarante.Value == LocalitaGaranteEqualThis.Value))) && ((NumeroRegistroImpreseEqualThis == null) || ((FidejussioniItem.NumeroRegistroImprese != null) && (FidejussioniItem.NumeroRegistroImprese.Value == NumeroRegistroImpreseEqualThis.Value))) && ((CognomeRapplegaleEqualThis == null) || ((FidejussioniItem.CognomeRapplegale != null) && (FidejussioniItem.CognomeRapplegale.Value == CognomeRapplegaleEqualThis.Value))) &&
((NomeRapplegaleEqualThis == null) || ((FidejussioniItem.NomeRapplegale != null) && (FidejussioniItem.NomeRapplegale.Value == NomeRapplegaleEqualThis.Value))) && ((CfRapplegaleEqualThis == null) || ((FidejussioniItem.CfRapplegale != null) && (FidejussioniItem.CfRapplegale.Value == CfRapplegaleEqualThis.Value))) && ((DataNascitaRapplegaleEqualThis == null) || ((FidejussioniItem.DataNascitaRapplegale != null) && (FidejussioniItem.DataNascitaRapplegale.Value == DataNascitaRapplegaleEqualThis.Value))) &&
((StampaEffettuataEqualThis == null) || ((FidejussioniItem.StampaEffettuata != null) && (FidejussioniItem.StampaEffettuata.Value == StampaEffettuataEqualThis.Value))) && ((DataRichiestaValiditaEqualThis == null) || ((FidejussioniItem.DataRichiestaValidita != null) && (FidejussioniItem.DataRichiestaValidita.Value == DataRichiestaValiditaEqualThis.Value))) && ((DataRicevimentoValiditaEqualThis == null) || ((FidejussioniItem.DataRicevimentoValidita != null) && (FidejussioniItem.DataRicevimentoValidita.Value == DataRicevimentoValiditaEqualThis.Value))) &&
((ProtocolloFaxValiditaEqualThis == null) || ((FidejussioniItem.ProtocolloFaxValidita != null) && (FidejussioniItem.ProtocolloFaxValidita.Value == ProtocolloFaxValiditaEqualThis.Value))) && ((DataDecorrenzaGaranziaEqualThis == null) || ((FidejussioniItem.DataDecorrenzaGaranzia != null) && (FidejussioniItem.DataDecorrenzaGaranzia.Value == DataDecorrenzaGaranziaEqualThis.Value))) && ((CodiceAbiEnteGaranteEqualThis == null) || ((FidejussioniItem.CodiceAbiEnteGarante != null) && (FidejussioniItem.CodiceAbiEnteGarante.Value == CodiceAbiEnteGaranteEqualThis.Value))) &&
((CodiceCabEnteGaranteEqualThis == null) || ((FidejussioniItem.CodiceCabEnteGarante != null) && (FidejussioniItem.CodiceCabEnteGarante.Value == CodiceCabEnteGaranteEqualThis.Value))) && ((BarcodeConfermaValiditaEqualThis == null) || ((FidejussioniItem.BarcodeConfermaValidita != null) && (FidejussioniItem.BarcodeConfermaValidita.Value == BarcodeConfermaValiditaEqualThis.Value))) && ((CodTipoEqualThis == null) || ((FidejussioniItem.CodTipo != null) && (FidejussioniItem.CodTipo.Value == CodTipoEqualThis.Value))) &&
((UfficioApprovazioneEqualThis == null) || ((FidejussioniItem.UfficioApprovazione != null) && (FidejussioniItem.UfficioApprovazione.Value == UfficioApprovazioneEqualThis.Value))) && ((NumDecretoApprovazioneEqualThis == null) || ((FidejussioniItem.NumDecretoApprovazione != null) && (FidejussioniItem.NumDecretoApprovazione.Value == NumDecretoApprovazioneEqualThis.Value))) && ((DataDecretoApprovazioneEqualThis == null) || ((FidejussioniItem.DataDecretoApprovazione != null) && (FidejussioniItem.DataDecretoApprovazione.Value == DataDecretoApprovazioneEqualThis.Value))))
                {
                    FidejussioniCollectionTemp.Add(FidejussioniItem);
                }
            }
            return FidejussioniCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for FidejussioniDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class FidejussioniDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Fidejussioni FidejussioniObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdFidejussione", FidejussioniObj.IdFidejussione);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "Numero", FidejussioniObj.Numero);
            DbProvider.SetCmdParam(cmd, firstChar + "Barcode", FidejussioniObj.Barcode);
            DbProvider.SetCmdParam(cmd, firstChar + "DataSottoscrizione", FidejussioniObj.DataSottoscrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "LuogoSottoscrizione", FidejussioniObj.LuogoSottoscrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", FidejussioniObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "AmmontareRichiesto", FidejussioniObj.AmmontareRichiesto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataFineLavori", FidejussioniObj.DataFineLavori);
            DbProvider.SetCmdParam(cmd, firstChar + "DataScadenza", FidejussioniObj.DataScadenza);
            DbProvider.SetCmdParam(cmd, firstChar + "ProrogaScadenza", FidejussioniObj.ProrogaScadenza);
            DbProvider.SetCmdParam(cmd, firstChar + "PivaGarante", FidejussioniObj.PivaGarante);
            DbProvider.SetCmdParam(cmd, firstChar + "RagioneSocialeGarante", FidejussioniObj.RagioneSocialeGarante);
            DbProvider.SetCmdParam(cmd, firstChar + "LocalitaGarante", FidejussioniObj.LocalitaGarante);
            DbProvider.SetCmdParam(cmd, firstChar + "NumeroRegistroImprese", FidejussioniObj.NumeroRegistroImprese);
            DbProvider.SetCmdParam(cmd, firstChar + "CognomeRapplegale", FidejussioniObj.CognomeRapplegale);
            DbProvider.SetCmdParam(cmd, firstChar + "NomeRapplegale", FidejussioniObj.NomeRapplegale);
            DbProvider.SetCmdParam(cmd, firstChar + "CfRapplegale", FidejussioniObj.CfRapplegale);
            DbProvider.SetCmdParam(cmd, firstChar + "DataNascitaRapplegale", FidejussioniObj.DataNascitaRapplegale);
            DbProvider.SetCmdParam(cmd, firstChar + "StampaEffettuata", FidejussioniObj.StampaEffettuata);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRichiestaValidita", FidejussioniObj.DataRichiestaValidita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataRicevimentoValidita", FidejussioniObj.DataRicevimentoValidita);
            DbProvider.SetCmdParam(cmd, firstChar + "ProtocolloFaxValidita", FidejussioniObj.ProtocolloFaxValidita);
            DbProvider.SetCmdParam(cmd, firstChar + "DataDecorrenzaGaranzia", FidejussioniObj.DataDecorrenzaGaranzia);
            DbProvider.SetCmdParam(cmd, firstChar + "CodiceAbiEnteGarante", FidejussioniObj.CodiceAbiEnteGarante);
            DbProvider.SetCmdParam(cmd, firstChar + "CodiceCabEnteGarante", FidejussioniObj.CodiceCabEnteGarante);
            DbProvider.SetCmdParam(cmd, firstChar + "BarcodeConfermaValidita", FidejussioniObj.BarcodeConfermaValidita);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", FidejussioniObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "UfficioApprovazione", FidejussioniObj.UfficioApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "NumDecretoApprovazione", FidejussioniObj.NumDecretoApprovazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataDecretoApprovazione", FidejussioniObj.DataDecretoApprovazione);
        }
        //Insert
        private static int Insert(DbProvider db, Fidejussioni FidejussioniObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZFidejussioniInsert", new string[] {"Numero", "Barcode",
"DataSottoscrizione", "LuogoSottoscrizione", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"ProrogaScadenza", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "BarcodeConfermaValidita", "CodTipo",
"UfficioApprovazione", "NumDecretoApprovazione", "DataDecretoApprovazione"}, new string[] {"string", "string",
"DateTime", "string", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"string", "int", "DateTime"}, "");
                CompileIUCmd(false, insertCmd, FidejussioniObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    FidejussioniObj.IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
                    FidejussioniObj.ProrogaScadenza = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROROGA_SCADENZA"]);
                    FidejussioniObj.StampaEffettuata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPA_EFFETTUATA"]);
                }
                FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                FidejussioniObj.IsDirty = false;
                FidejussioniObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Fidejussioni FidejussioniObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZFidejussioniUpdate", new string[] {"IdFidejussione", "Numero", "Barcode",
"DataSottoscrizione", "LuogoSottoscrizione", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"ProrogaScadenza", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "BarcodeConfermaValidita", "CodTipo",
"UfficioApprovazione", "NumDecretoApprovazione", "DataDecretoApprovazione"}, new string[] {"int", "string", "string",
"DateTime", "string", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"string", "int", "DateTime"}, "");
                CompileIUCmd(true, updateCmd, FidejussioniObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                FidejussioniObj.IsDirty = false;
                FidejussioniObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Fidejussioni FidejussioniObj)
        {
            switch (FidejussioniObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, FidejussioniObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, FidejussioniObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, FidejussioniObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, FidejussioniCollection FidejussioniCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZFidejussioniUpdate", new string[] {"IdFidejussione", "Numero", "Barcode",
"DataSottoscrizione", "LuogoSottoscrizione", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"ProrogaScadenza", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "BarcodeConfermaValidita", "CodTipo",
"UfficioApprovazione", "NumDecretoApprovazione", "DataDecretoApprovazione"}, new string[] {"int", "string", "string",
"DateTime", "string", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"string", "int", "DateTime"}, "");
                IDbCommand insertCmd = db.InitCmd("ZFidejussioniInsert", new string[] {"Numero", "Barcode",
"DataSottoscrizione", "LuogoSottoscrizione", "Importo",
"AmmontareRichiesto", "DataFineLavori", "DataScadenza",
"ProrogaScadenza", "PivaGarante", "RagioneSocialeGarante",
"LocalitaGarante", "NumeroRegistroImprese", "CognomeRapplegale",
"NomeRapplegale", "CfRapplegale", "DataNascitaRapplegale",
"StampaEffettuata", "DataRichiestaValidita", "DataRicevimentoValidita",
"ProtocolloFaxValidita", "DataDecorrenzaGaranzia", "CodiceAbiEnteGarante",
"CodiceCabEnteGarante", "BarcodeConfermaValidita", "CodTipo",
"UfficioApprovazione", "NumDecretoApprovazione", "DataDecretoApprovazione"}, new string[] {"string", "string",
"DateTime", "string", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"string", "int", "DateTime"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZFidejussioniDelete", new string[] { "IdFidejussione" }, new string[] { "int" }, "");
                for (int i = 0; i < FidejussioniCollectionObj.Count; i++)
                {
                    switch (FidejussioniCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, FidejussioniCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    FidejussioniCollectionObj[i].IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
                                    FidejussioniCollectionObj[i].ProrogaScadenza = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROROGA_SCADENZA"]);
                                    FidejussioniCollectionObj[i].StampaEffettuata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPA_EFFETTUATA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, FidejussioniCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (FidejussioniCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdFidejussione", (SiarLibrary.NullTypes.IntNT)FidejussioniCollectionObj[i].IdFidejussione);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < FidejussioniCollectionObj.Count; i++)
                {
                    if ((FidejussioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FidejussioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        FidejussioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        FidejussioniCollectionObj[i].IsDirty = false;
                        FidejussioniCollectionObj[i].IsPersistent = true;
                    }
                    if ((FidejussioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        FidejussioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        FidejussioniCollectionObj[i].IsDirty = false;
                        FidejussioniCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Fidejussioni FidejussioniObj)
        {
            int returnValue = 0;
            if (FidejussioniObj.IsPersistent)
            {
                returnValue = Delete(db, FidejussioniObj.IdFidejussione);
            }
            FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            FidejussioniObj.IsDirty = false;
            FidejussioniObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdFidejussioneValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZFidejussioniDelete", new string[] { "IdFidejussione" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdFidejussione", (SiarLibrary.NullTypes.IntNT)IdFidejussioneValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, FidejussioniCollection FidejussioniCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZFidejussioniDelete", new string[] { "IdFidejussione" }, new string[] { "int" }, "");
                for (int i = 0; i < FidejussioniCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdFidejussione", FidejussioniCollectionObj[i].IdFidejussione);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < FidejussioniCollectionObj.Count; i++)
                {
                    if ((FidejussioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (FidejussioniCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        FidejussioniCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        FidejussioniCollectionObj[i].IsDirty = false;
                        FidejussioniCollectionObj[i].IsPersistent = false;
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
        public static Fidejussioni GetById(DbProvider db, int IdFidejussioneValue)
        {
            Fidejussioni FidejussioniObj = null;
            IDbCommand readCmd = db.InitCmd("ZFidejussioniGetById", new string[] { "IdFidejussione" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdFidejussione", (SiarLibrary.NullTypes.IntNT)IdFidejussioneValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                FidejussioniObj = GetFromDatareader(db);
                FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                FidejussioniObj.IsDirty = false;
                FidejussioniObj.IsPersistent = true;
            }
            db.Close();
            return FidejussioniObj;
        }

        //getFromDatareader
        public static Fidejussioni GetFromDatareader(DbProvider db)
        {
            Fidejussioni FidejussioniObj = new Fidejussioni();
            FidejussioniObj.IdFidejussione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FIDEJUSSIONE"]);
            FidejussioniObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
            FidejussioniObj.Barcode = new SiarLibrary.NullTypes.StringNT(db.DataReader["BARCODE"]);
            FidejussioniObj.DataSottoscrizione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SOTTOSCRIZIONE"]);
            FidejussioniObj.LuogoSottoscrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["LUOGO_SOTTOSCRIZIONE"]);
            FidejussioniObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            FidejussioniObj.AmmontareRichiesto = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["AMMONTARE_RICHIESTO"]);
            FidejussioniObj.DataFineLavori = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_FINE_LAVORI"]);
            FidejussioniObj.DataScadenza = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_SCADENZA"]);
            FidejussioniObj.ProrogaScadenza = new SiarLibrary.NullTypes.BoolNT(db.DataReader["PROROGA_SCADENZA"]);
            FidejussioniObj.PivaGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["PIVA_GARANTE"]);
            FidejussioniObj.RagioneSocialeGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE_GARANTE"]);
            FidejussioniObj.LocalitaGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["LOCALITA_GARANTE"]);
            FidejussioniObj.NumeroRegistroImprese = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO_REGISTRO_IMPRESE"]);
            FidejussioniObj.CognomeRapplegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["COGNOME_RAPPLEGALE"]);
            FidejussioniObj.NomeRapplegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOME_RAPPLEGALE"]);
            FidejussioniObj.CfRapplegale = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RAPPLEGALE"]);
            FidejussioniObj.DataNascitaRapplegale = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_NASCITA_RAPPLEGALE"]);
            FidejussioniObj.StampaEffettuata = new SiarLibrary.NullTypes.BoolNT(db.DataReader["STAMPA_EFFETTUATA"]);
            FidejussioniObj.DataRichiestaValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICHIESTA_VALIDITA"]);
            FidejussioniObj.DataRicevimentoValidita = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_RICEVIMENTO_VALIDITA"]);
            FidejussioniObj.ProtocolloFaxValidita = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROTOCOLLO_FAX_VALIDITA"]);
            FidejussioniObj.DataDecorrenzaGaranzia = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DECORRENZA_GARANZIA"]);
            FidejussioniObj.CodiceAbiEnteGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_ABI_ENTE_GARANTE"]);
            FidejussioniObj.CodiceCabEnteGarante = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE_CAB_ENTE_GARANTE"]);
            FidejussioniObj.BarcodeConfermaValidita = new SiarLibrary.NullTypes.StringNT(db.DataReader["BARCODE_CONFERMA_VALIDITA"]);
            FidejussioniObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            FidejussioniObj.UfficioApprovazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["UFFICIO_APPROVAZIONE"]);
            FidejussioniObj.NumDecretoApprovazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUM_DECRETO_APPROVAZIONE"]);
            FidejussioniObj.DataDecretoApprovazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DECRETO_APPROVAZIONE"]);
            FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            FidejussioniObj.IsDirty = false;
            FidejussioniObj.IsPersistent = true;
            return FidejussioniObj;
        }

        //Find Select

        public static FidejussioniCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdFidejussioneEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.StringNT BarcodeEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataSottoscrizioneEqualThis, SiarLibrary.NullTypes.StringNT LuogoSottoscrizioneEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis,
SiarLibrary.NullTypes.DecimalNT AmmontareRichiestoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataFineLavoriEqualThis, SiarLibrary.NullTypes.DatetimeNT DataScadenzaEqualThis,
SiarLibrary.NullTypes.BoolNT ProrogaScadenzaEqualThis, SiarLibrary.NullTypes.StringNT PivaGaranteEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeGaranteEqualThis,
SiarLibrary.NullTypes.StringNT LocalitaGaranteEqualThis, SiarLibrary.NullTypes.StringNT NumeroRegistroImpreseEqualThis, SiarLibrary.NullTypes.StringNT CognomeRapplegaleEqualThis,
SiarLibrary.NullTypes.StringNT NomeRapplegaleEqualThis, SiarLibrary.NullTypes.StringNT CfRapplegaleEqualThis, SiarLibrary.NullTypes.DatetimeNT DataNascitaRapplegaleEqualThis,
SiarLibrary.NullTypes.BoolNT StampaEffettuataEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRichiestaValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataRicevimentoValiditaEqualThis,
SiarLibrary.NullTypes.StringNT ProtocolloFaxValiditaEqualThis, SiarLibrary.NullTypes.DatetimeNT DataDecorrenzaGaranziaEqualThis, SiarLibrary.NullTypes.StringNT CodiceAbiEnteGaranteEqualThis,
SiarLibrary.NullTypes.StringNT CodiceCabEnteGaranteEqualThis, SiarLibrary.NullTypes.StringNT BarcodeConfermaValiditaEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis,
SiarLibrary.NullTypes.StringNT UfficioApprovazioneEqualThis, SiarLibrary.NullTypes.IntNT NumDecretoApprovazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataDecretoApprovazioneEqualThis)

        {

            FidejussioniCollection FidejussioniCollectionObj = new FidejussioniCollection();

            IDbCommand findCmd = db.InitCmd("Zfidejussionifindselect", new string[] {"IdFidejussioneequalthis", "Numeroequalthis", "Barcodeequalthis",
"DataSottoscrizioneequalthis", "LuogoSottoscrizioneequalthis", "Importoequalthis",
"AmmontareRichiestoequalthis", "DataFineLavoriequalthis", "DataScadenzaequalthis",
"ProrogaScadenzaequalthis", "PivaGaranteequalthis", "RagioneSocialeGaranteequalthis",
"LocalitaGaranteequalthis", "NumeroRegistroImpreseequalthis", "CognomeRapplegaleequalthis",
"NomeRapplegaleequalthis", "CfRapplegaleequalthis", "DataNascitaRapplegaleequalthis",
"StampaEffettuataequalthis", "DataRichiestaValiditaequalthis", "DataRicevimentoValiditaequalthis",
"ProtocolloFaxValiditaequalthis", "DataDecorrenzaGaranziaequalthis", "CodiceAbiEnteGaranteequalthis",
"CodiceCabEnteGaranteequalthis", "BarcodeConfermaValiditaequalthis", "CodTipoequalthis",
"UfficioApprovazioneequalthis", "NumDecretoApprovazioneequalthis", "DataDecretoApprovazioneequalthis"}, new string[] {"int", "string", "string",
"DateTime", "string", "decimal",
"decimal", "DateTime", "DateTime",
"bool", "string", "string",
"string", "string", "string",
"string", "string", "DateTime",
"bool", "DateTime", "DateTime",
"string", "DateTime", "string",
"string", "string", "string",
"string", "int", "DateTime"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFidejussioneequalthis", IdFidejussioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Barcodeequalthis", BarcodeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataSottoscrizioneequalthis", DataSottoscrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LuogoSottoscrizioneequalthis", LuogoSottoscrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "AmmontareRichiestoequalthis", AmmontareRichiestoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataFineLavoriequalthis", DataFineLavoriEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataScadenzaequalthis", DataScadenzaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProrogaScadenzaequalthis", ProrogaScadenzaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PivaGaranteequalthis", PivaGaranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RagioneSocialeGaranteequalthis", RagioneSocialeGaranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "LocalitaGaranteequalthis", LocalitaGaranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumeroRegistroImpreseequalthis", NumeroRegistroImpreseEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CognomeRapplegaleequalthis", CognomeRapplegaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NomeRapplegaleequalthis", NomeRapplegaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfRapplegaleequalthis", CfRapplegaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataNascitaRapplegaleequalthis", DataNascitaRapplegaleEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "StampaEffettuataequalthis", StampaEffettuataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRichiestaValiditaequalthis", DataRichiestaValiditaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataRicevimentoValiditaequalthis", DataRicevimentoValiditaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ProtocolloFaxValiditaequalthis", ProtocolloFaxValiditaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDecorrenzaGaranziaequalthis", DataDecorrenzaGaranziaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceAbiEnteGaranteequalthis", CodiceAbiEnteGaranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodiceCabEnteGaranteequalthis", CodiceCabEnteGaranteEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "BarcodeConfermaValiditaequalthis", BarcodeConfermaValiditaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "UfficioApprovazioneequalthis", UfficioApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "NumDecretoApprovazioneequalthis", NumDecretoApprovazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataDecretoApprovazioneequalthis", DataDecretoApprovazioneEqualThis);
            Fidejussioni FidejussioniObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                FidejussioniObj = GetFromDatareader(db);
                FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                FidejussioniObj.IsDirty = false;
                FidejussioniObj.IsPersistent = true;
                FidejussioniCollectionObj.Add(FidejussioniObj);
            }
            db.Close();
            return FidejussioniCollectionObj;
        }

        //Find Find

        public static FidejussioniCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.StringNT BarcodeEqualThis, SiarLibrary.NullTypes.StringNT PivaGaranteEqualThis)

        {

            FidejussioniCollection FidejussioniCollectionObj = new FidejussioniCollection();

            IDbCommand findCmd = db.InitCmd("Zfidejussionifindfind", new string[] { "Numeroequalthis", "Barcodeequalthis", "PivaGaranteequalthis" }, new string[] { "string", "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Barcodeequalthis", BarcodeEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "PivaGaranteequalthis", PivaGaranteEqualThis);
            Fidejussioni FidejussioniObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                FidejussioniObj = GetFromDatareader(db);
                FidejussioniObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                FidejussioniObj.IsDirty = false;
                FidejussioniObj.IsPersistent = true;
                FidejussioniCollectionObj.Add(FidejussioniObj);
            }
            db.Close();
            return FidejussioniCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for FidejussioniCollectionProvider:IFidejussioniProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class FidejussioniCollectionProvider : IFidejussioniProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Fidejussioni
        protected FidejussioniCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public FidejussioniCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new FidejussioniCollection(this);
        }

        //Costruttore 2: popola la collection
        public FidejussioniCollectionProvider(StringNT NumeroEqualThis, StringNT BarcodeEqualThis, StringNT PivagaranteEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(NumeroEqualThis, BarcodeEqualThis, PivagaranteEqualThis);
        }

        //Costruttore3: ha in input fidejussioniCollectionObj - non popola la collection
        public FidejussioniCollectionProvider(FidejussioniCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public FidejussioniCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new FidejussioniCollection(this);
        }

        //Get e Set
        public FidejussioniCollection CollectionObj
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
        public int SaveCollection(FidejussioniCollection collectionObj)
        {
            return FidejussioniDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Fidejussioni fidejussioniObj)
        {
            return FidejussioniDAL.Save(_dbProviderObj, fidejussioniObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(FidejussioniCollection collectionObj)
        {
            return FidejussioniDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Fidejussioni fidejussioniObj)
        {
            return FidejussioniDAL.Delete(_dbProviderObj, fidejussioniObj);
        }

        //getById
        public Fidejussioni GetById(IntNT IdFidejussioneValue)
        {
            Fidejussioni FidejussioniTemp = FidejussioniDAL.GetById(_dbProviderObj, IdFidejussioneValue);
            if (FidejussioniTemp != null) FidejussioniTemp.Provider = this;
            return FidejussioniTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public FidejussioniCollection Select(IntNT IdfidejussioneEqualThis, StringNT NumeroEqualThis, StringNT BarcodeEqualThis,
DatetimeNT DatasottoscrizioneEqualThis, StringNT LuogosottoscrizioneEqualThis, DecimalNT ImportoEqualThis,
DecimalNT AmmontarerichiestoEqualThis, DatetimeNT DatafinelavoriEqualThis, DatetimeNT DatascadenzaEqualThis,
BoolNT ProrogascadenzaEqualThis, StringNT PivagaranteEqualThis, StringNT RagionesocialegaranteEqualThis,
StringNT LocalitagaranteEqualThis, StringNT NumeroregistroimpreseEqualThis, StringNT CognomerapplegaleEqualThis,
StringNT NomerapplegaleEqualThis, StringNT CfrapplegaleEqualThis, DatetimeNT DatanascitarapplegaleEqualThis,
BoolNT StampaeffettuataEqualThis, DatetimeNT DatarichiestavaliditaEqualThis, DatetimeNT DataricevimentovaliditaEqualThis,
StringNT ProtocollofaxvaliditaEqualThis, DatetimeNT DatadecorrenzagaranziaEqualThis, StringNT CodiceabientegaranteEqualThis,
StringNT CodicecabentegaranteEqualThis, StringNT BarcodeconfermavaliditaEqualThis, StringNT CodtipoEqualThis,
StringNT UfficioapprovazioneEqualThis, IntNT NumdecretoapprovazioneEqualThis, DatetimeNT DatadecretoapprovazioneEqualThis)
        {
            FidejussioniCollection FidejussioniCollectionTemp = FidejussioniDAL.Select(_dbProviderObj, IdfidejussioneEqualThis, NumeroEqualThis, BarcodeEqualThis,
DatasottoscrizioneEqualThis, LuogosottoscrizioneEqualThis, ImportoEqualThis,
AmmontarerichiestoEqualThis, DatafinelavoriEqualThis, DatascadenzaEqualThis,
ProrogascadenzaEqualThis, PivagaranteEqualThis, RagionesocialegaranteEqualThis,
LocalitagaranteEqualThis, NumeroregistroimpreseEqualThis, CognomerapplegaleEqualThis,
NomerapplegaleEqualThis, CfrapplegaleEqualThis, DatanascitarapplegaleEqualThis,
StampaeffettuataEqualThis, DatarichiestavaliditaEqualThis, DataricevimentovaliditaEqualThis,
ProtocollofaxvaliditaEqualThis, DatadecorrenzagaranziaEqualThis, CodiceabientegaranteEqualThis,
CodicecabentegaranteEqualThis, BarcodeconfermavaliditaEqualThis, CodtipoEqualThis,
UfficioapprovazioneEqualThis, NumdecretoapprovazioneEqualThis, DatadecretoapprovazioneEqualThis);
            FidejussioniCollectionTemp.Provider = this;
            return FidejussioniCollectionTemp;
        }

        //Find: popola la collection
        public FidejussioniCollection Find(StringNT NumeroEqualThis, StringNT BarcodeEqualThis, StringNT PivagaranteEqualThis)
        {
            FidejussioniCollection FidejussioniCollectionTemp = FidejussioniDAL.Find(_dbProviderObj, NumeroEqualThis, BarcodeEqualThis, PivagaranteEqualThis);
            FidejussioniCollectionTemp.Provider = this;
            return FidejussioniCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<FIDEJUSSIONI>
  <ViewName>
  </ViewName>
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
      <NUMERO>Equal</NUMERO>
      <BARCODE>Equal</BARCODE>
      <PIVA_GARANTE>Equal</PIVA_GARANTE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</FIDEJUSSIONI>
*/
