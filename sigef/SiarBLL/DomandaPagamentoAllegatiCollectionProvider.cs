using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per DomandaPagamentoAllegati
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IDomandaPagamentoAllegatiProvider
    {
        int Save(DomandaPagamentoAllegati DomandaPagamentoAllegatiObj);
        int SaveCollection(DomandaPagamentoAllegatiCollection collectionObj);
        int Delete(DomandaPagamentoAllegati DomandaPagamentoAllegatiObj);
        int DeleteCollection(DomandaPagamentoAllegatiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for DomandaPagamentoAllegati
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DomandaPagamentoAllegati : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdAllegato;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.StringNT _CodTipoDocumento;
        private NullTypes.IntNT _IdFile;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _CodEnteEmettitore;
        private NullTypes.IntNT _IdComune;
        private NullTypes.StringNT _Numero;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.StringNT _CodEsito;
        private NullTypes.StringNT _NoteIstruttore;
        private NullTypes.StringNT _Esito;
        private NullTypes.BoolNT _EsitoPositivo;
        private NullTypes.StringNT _Formato;
        private NullTypes.StringNT _TipoAllegato;
        private NullTypes.StringNT _TipologiaDocumento;
        private NullTypes.StringNT _Ente;
        private NullTypes.IntNT _DimensioneFile;
        private NullTypes.BoolNT _InIntegrazione;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.StringNT _CfInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.StringNT _CfModifica;
        [NonSerialized] private IDomandaPagamentoAllegatiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaPagamentoAllegatiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public DomandaPagamentoAllegati()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_ALLEGATO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdAllegato
        {
            get { return _IdAllegato; }
            set
            {
                if (IdAllegato != value)
                {
                    _IdAllegato = value;
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
        /// Corrisponde al campo:COD_TIPO_DOCUMENTO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodTipoDocumento
        {
            get { return _CodTipoDocumento; }
            set
            {
                if (CodTipoDocumento != value)
                {
                    _CodTipoDocumento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_FILE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdFile
        {
            get { return _IdFile; }
            set
            {
                if (IdFile != value)
                {
                    _IdFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(255)
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
        /// Corrisponde al campo:COD_ENTE_EMETTITORE
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT CodEnteEmettitore
        {
            get { return _CodEnteEmettitore; }
            set
            {
                if (CodEnteEmettitore != value)
                {
                    _CodEnteEmettitore = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ID_COMUNE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdComune
        {
            get { return _IdComune; }
            set
            {
                if (IdComune != value)
                {
                    _IdComune = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:VARCHAR(20)
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
        /// Corrisponde al campo:COD_ESITO
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodEsito
        {
            get { return _CodEsito; }
            set
            {
                if (CodEsito != value)
                {
                    _CodEsito = value;
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
        /// Corrisponde al campo:ESITO_POSITIVO
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT EsitoPositivo
        {
            get { return _EsitoPositivo; }
            set
            {
                if (EsitoPositivo != value)
                {
                    _EsitoPositivo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:FORMATO
        /// Tipo sul db:CHAR(1)
        /// </summary>
        public NullTypes.StringNT Formato
        {
            get { return _Formato; }
            set
            {
                if (Formato != value)
                {
                    _Formato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_ALLEGATO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT TipoAllegato
        {
            get { return _TipoAllegato; }
            set
            {
                if (TipoAllegato != value)
                {
                    _TipoAllegato = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPOLOGIA_DOCUMENTO
        /// Tipo sul db:VARCHAR(250)
        /// </summary>
        public NullTypes.StringNT TipologiaDocumento
        {
            get { return _TipologiaDocumento; }
            set
            {
                if (TipologiaDocumento != value)
                {
                    _TipologiaDocumento = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ENTE
        /// Tipo sul db:VARCHAR(270)
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
        /// Corrisponde al campo:DIMENSIONE_FILE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT DimensioneFile
        {
            get { return _DimensioneFile; }
            set
            {
                if (DimensioneFile != value)
                {
                    _DimensioneFile = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IN_INTEGRAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
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
        /// Corrisponde al campo:CF_INSERIMENTO
        /// Tipo sul db:VARCHAR(50)
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
        /// Corrisponde al campo:CF_MODIFICA
        /// Tipo sul db:VARCHAR(50)
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
    /// Summary description for DomandaPagamentoAllegatiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaPagamentoAllegatiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private DomandaPagamentoAllegatiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DomandaPagamentoAllegati)info.GetValue(i.ToString(), typeof(DomandaPagamentoAllegati)));
            }
        }

        //Costruttore
        public DomandaPagamentoAllegatiCollection()
        {
            this.ItemType = typeof(DomandaPagamentoAllegati);
        }

        //Costruttore con provider
        public DomandaPagamentoAllegatiCollection(IDomandaPagamentoAllegatiProvider providerObj)
        {
            this.ItemType = typeof(DomandaPagamentoAllegati);
            this.Provider = providerObj;
        }

        //Get e Set
        public new DomandaPagamentoAllegati this[int index]
        {
            get { return (DomandaPagamentoAllegati)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DomandaPagamentoAllegatiCollection GetChanges()
        {
            return (DomandaPagamentoAllegatiCollection)base.GetChanges();
        }

        [NonSerialized] private IDomandaPagamentoAllegatiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDomandaPagamentoAllegatiProvider Provider
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
        public int Add(DomandaPagamentoAllegati DomandaPagamentoAllegatiObj)
        {
            if (DomandaPagamentoAllegatiObj.Provider == null) DomandaPagamentoAllegatiObj.Provider = this.Provider;
            return base.Add(DomandaPagamentoAllegatiObj);
        }

        //AddCollection
        public void AddCollection(DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionObj)
        {
            foreach (DomandaPagamentoAllegati DomandaPagamentoAllegatiObj in DomandaPagamentoAllegatiCollectionObj)
                this.Add(DomandaPagamentoAllegatiObj);
        }

        //Insert
        public void Insert(int index, DomandaPagamentoAllegati DomandaPagamentoAllegatiObj)
        {
            if (DomandaPagamentoAllegatiObj.Provider == null) DomandaPagamentoAllegatiObj.Provider = this.Provider;
            base.Insert(index, DomandaPagamentoAllegatiObj);
        }

        //CollectionGetById
        public DomandaPagamentoAllegati CollectionGetById(NullTypes.IntNT IdAllegatoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdAllegato == IdAllegatoValue))
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
        public DomandaPagamentoAllegatiCollection SubSelect(NullTypes.IntNT IdAllegatoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT DescrizioneEqualThis,
NullTypes.StringNT CodTipoDocumentoEqualThis, NullTypes.IntNT IdFileEqualThis, NullTypes.StringNT CodEnteEmettitoreEqualThis,
NullTypes.IntNT IdComuneEqualThis, NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataEqualThis,
NullTypes.StringNT CodEsitoEqualThis, NullTypes.BoolNT InIntegrazioneEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT CfModificaEqualThis)
        {
            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionTemp = new DomandaPagamentoAllegatiCollection();
            foreach (DomandaPagamentoAllegati DomandaPagamentoAllegatiItem in this)
            {
                if (((IdAllegatoEqualThis == null) || ((DomandaPagamentoAllegatiItem.IdAllegato != null) && (DomandaPagamentoAllegatiItem.IdAllegato.Value == IdAllegatoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DomandaPagamentoAllegatiItem.IdDomandaPagamento != null) && (DomandaPagamentoAllegatiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((DomandaPagamentoAllegatiItem.Descrizione != null) && (DomandaPagamentoAllegatiItem.Descrizione.Value == DescrizioneEqualThis.Value))) &&
((CodTipoDocumentoEqualThis == null) || ((DomandaPagamentoAllegatiItem.CodTipoDocumento != null) && (DomandaPagamentoAllegatiItem.CodTipoDocumento.Value == CodTipoDocumentoEqualThis.Value))) && ((IdFileEqualThis == null) || ((DomandaPagamentoAllegatiItem.IdFile != null) && (DomandaPagamentoAllegatiItem.IdFile.Value == IdFileEqualThis.Value))) && ((CodEnteEmettitoreEqualThis == null) || ((DomandaPagamentoAllegatiItem.CodEnteEmettitore != null) && (DomandaPagamentoAllegatiItem.CodEnteEmettitore.Value == CodEnteEmettitoreEqualThis.Value))) &&
((IdComuneEqualThis == null) || ((DomandaPagamentoAllegatiItem.IdComune != null) && (DomandaPagamentoAllegatiItem.IdComune.Value == IdComuneEqualThis.Value))) && ((NumeroEqualThis == null) || ((DomandaPagamentoAllegatiItem.Numero != null) && (DomandaPagamentoAllegatiItem.Numero.Value == NumeroEqualThis.Value))) && ((DataEqualThis == null) || ((DomandaPagamentoAllegatiItem.Data != null) && (DomandaPagamentoAllegatiItem.Data.Value == DataEqualThis.Value))) &&
((CodEsitoEqualThis == null) || ((DomandaPagamentoAllegatiItem.CodEsito != null) && (DomandaPagamentoAllegatiItem.CodEsito.Value == CodEsitoEqualThis.Value))) && ((InIntegrazioneEqualThis == null) || ((DomandaPagamentoAllegatiItem.InIntegrazione != null) && (DomandaPagamentoAllegatiItem.InIntegrazione.Value == InIntegrazioneEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((DomandaPagamentoAllegatiItem.DataInserimento != null) && (DomandaPagamentoAllegatiItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((CfInserimentoEqualThis == null) || ((DomandaPagamentoAllegatiItem.CfInserimento != null) && (DomandaPagamentoAllegatiItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((DomandaPagamentoAllegatiItem.DataModifica != null) && (DomandaPagamentoAllegatiItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((CfModificaEqualThis == null) || ((DomandaPagamentoAllegatiItem.CfModifica != null) && (DomandaPagamentoAllegatiItem.CfModifica.Value == CfModificaEqualThis.Value))))
                {
                    DomandaPagamentoAllegatiCollectionTemp.Add(DomandaPagamentoAllegatiItem);
                }
            }
            return DomandaPagamentoAllegatiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for DomandaPagamentoAllegatiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class DomandaPagamentoAllegatiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DomandaPagamentoAllegati DomandaPagamentoAllegatiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdAllegato", DomandaPagamentoAllegatiObj.IdAllegato);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DomandaPagamentoAllegatiObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipoDocumento", DomandaPagamentoAllegatiObj.CodTipoDocumento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdFile", DomandaPagamentoAllegatiObj.IdFile);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", DomandaPagamentoAllegatiObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEnteEmettitore", DomandaPagamentoAllegatiObj.CodEnteEmettitore);
            DbProvider.SetCmdParam(cmd, firstChar + "IdComune", DomandaPagamentoAllegatiObj.IdComune);
            DbProvider.SetCmdParam(cmd, firstChar + "Numero", DomandaPagamentoAllegatiObj.Numero);
            DbProvider.SetCmdParam(cmd, firstChar + "Data", DomandaPagamentoAllegatiObj.Data);
            DbProvider.SetCmdParam(cmd, firstChar + "CodEsito", DomandaPagamentoAllegatiObj.CodEsito);
            DbProvider.SetCmdParam(cmd, firstChar + "NoteIstruttore", DomandaPagamentoAllegatiObj.NoteIstruttore);
            DbProvider.SetCmdParam(cmd, firstChar + "InIntegrazione", DomandaPagamentoAllegatiObj.InIntegrazione);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", DomandaPagamentoAllegatiObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", DomandaPagamentoAllegatiObj.CfInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", DomandaPagamentoAllegatiObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", DomandaPagamentoAllegatiObj.CfModifica);
        }
        //Insert
        private static int Insert(DbProvider db, DomandaPagamentoAllegati DomandaPagamentoAllegatiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZDomandaPagamentoAllegatiInsert", new string[] {"IdDomandaPagamento", "CodTipoDocumento",
"IdFile", "Descrizione", "CodEnteEmettitore",
"IdComune", "Numero", "Data",
"CodEsito", "NoteIstruttore",


"InIntegrazione", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica"}, new string[] {"int", "string",
"int", "string", "string",
"int", "string", "DateTime",
"string", "string",


"bool", "DateTime", "string",
"DateTime", "string"}, "");
                CompileIUCmd(false, insertCmd, DomandaPagamentoAllegatiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    DomandaPagamentoAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
                    DomandaPagamentoAllegatiObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                    DomandaPagamentoAllegatiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                }
                DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoAllegatiObj.IsDirty = false;
                DomandaPagamentoAllegatiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, DomandaPagamentoAllegati DomandaPagamentoAllegatiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaPagamentoAllegatiUpdate", new string[] {"IdAllegato", "IdDomandaPagamento", "CodTipoDocumento",
"IdFile", "Descrizione", "CodEnteEmettitore",
"IdComune", "Numero", "Data",
"CodEsito", "NoteIstruttore",


"InIntegrazione", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica"}, new string[] {"int", "int", "string",
"int", "string", "string",
"int", "string", "DateTime",
"string", "string",


"bool", "DateTime", "string",
"DateTime", "string"}, "");
                CompileIUCmd(true, updateCmd, DomandaPagamentoAllegatiObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    DomandaPagamentoAllegatiObj.DataModifica = d;
                }
                DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoAllegatiObj.IsDirty = false;
                DomandaPagamentoAllegatiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, DomandaPagamentoAllegati DomandaPagamentoAllegatiObj)
        {
            switch (DomandaPagamentoAllegatiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DomandaPagamentoAllegatiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DomandaPagamentoAllegatiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DomandaPagamentoAllegatiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDomandaPagamentoAllegatiUpdate", new string[] {"IdAllegato", "IdDomandaPagamento", "CodTipoDocumento",
"IdFile", "Descrizione", "CodEnteEmettitore",
"IdComune", "Numero", "Data",
"CodEsito", "NoteIstruttore",


"InIntegrazione", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica"}, new string[] {"int", "int", "string",
"int", "string", "string",
"int", "string", "DateTime",
"string", "string",


"bool", "DateTime", "string",
"DateTime", "string"}, "");
                IDbCommand insertCmd = db.InitCmd("ZDomandaPagamentoAllegatiInsert", new string[] {"IdDomandaPagamento", "CodTipoDocumento",
"IdFile", "Descrizione", "CodEnteEmettitore",
"IdComune", "Numero", "Data",
"CodEsito", "NoteIstruttore",


"InIntegrazione", "DataInserimento", "CfInserimento",
"DataModifica", "CfModifica"}, new string[] {"int", "string",
"int", "string", "string",
"int", "string", "DateTime",
"string", "string",


"bool", "DateTime", "string",
"DateTime", "string"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoAllegatiDelete", new string[] { "IdAllegato" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaPagamentoAllegatiCollectionObj.Count; i++)
                {
                    switch (DomandaPagamentoAllegatiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, DomandaPagamentoAllegatiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DomandaPagamentoAllegatiCollectionObj[i].IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
                                    DomandaPagamentoAllegatiCollectionObj[i].InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
                                    DomandaPagamentoAllegatiCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, DomandaPagamentoAllegatiCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    DomandaPagamentoAllegatiCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (DomandaPagamentoAllegatiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)DomandaPagamentoAllegatiCollectionObj[i].IdAllegato);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DomandaPagamentoAllegatiCollectionObj.Count; i++)
                {
                    if ((DomandaPagamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaPagamentoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DomandaPagamentoAllegatiCollectionObj[i].IsDirty = false;
                        DomandaPagamentoAllegatiCollectionObj[i].IsPersistent = true;
                    }
                    if ((DomandaPagamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DomandaPagamentoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaPagamentoAllegatiCollectionObj[i].IsDirty = false;
                        DomandaPagamentoAllegatiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DomandaPagamentoAllegati DomandaPagamentoAllegatiObj)
        {
            int returnValue = 0;
            if (DomandaPagamentoAllegatiObj.IsPersistent)
            {
                returnValue = Delete(db, DomandaPagamentoAllegatiObj.IdAllegato);
            }
            DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DomandaPagamentoAllegatiObj.IsDirty = false;
            DomandaPagamentoAllegatiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdAllegatoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoAllegatiDelete", new string[] { "IdAllegato" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDomandaPagamentoAllegatiDelete", new string[] { "IdAllegato" }, new string[] { "int" }, "");
                for (int i = 0; i < DomandaPagamentoAllegatiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdAllegato", DomandaPagamentoAllegatiCollectionObj[i].IdAllegato);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DomandaPagamentoAllegatiCollectionObj.Count; i++)
                {
                    if ((DomandaPagamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DomandaPagamentoAllegatiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DomandaPagamentoAllegatiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DomandaPagamentoAllegatiCollectionObj[i].IsDirty = false;
                        DomandaPagamentoAllegatiCollectionObj[i].IsPersistent = false;
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
        public static DomandaPagamentoAllegati GetById(DbProvider db, int IdAllegatoValue)
        {
            DomandaPagamentoAllegati DomandaPagamentoAllegatiObj = null;
            IDbCommand readCmd = db.InitCmd("ZDomandaPagamentoAllegatiGetById", new string[] { "IdAllegato" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdAllegato", (SiarLibrary.NullTypes.IntNT)IdAllegatoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DomandaPagamentoAllegatiObj = GetFromDatareader(db);
                DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoAllegatiObj.IsDirty = false;
                DomandaPagamentoAllegatiObj.IsPersistent = true;
            }
            db.Close();
            return DomandaPagamentoAllegatiObj;
        }

        //getFromDatareader
        public static DomandaPagamentoAllegati GetFromDatareader(DbProvider db)
        {
            DomandaPagamentoAllegati DomandaPagamentoAllegatiObj = new DomandaPagamentoAllegati();
            DomandaPagamentoAllegatiObj.IdAllegato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ALLEGATO"]);
            DomandaPagamentoAllegatiObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            DomandaPagamentoAllegatiObj.CodTipoDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_DOCUMENTO"]);
            DomandaPagamentoAllegatiObj.IdFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_FILE"]);
            DomandaPagamentoAllegatiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            DomandaPagamentoAllegatiObj.CodEnteEmettitore = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE_EMETTITORE"]);
            DomandaPagamentoAllegatiObj.IdComune = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_COMUNE"]);
            DomandaPagamentoAllegatiObj.Numero = new SiarLibrary.NullTypes.StringNT(db.DataReader["NUMERO"]);
            DomandaPagamentoAllegatiObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            DomandaPagamentoAllegatiObj.CodEsito = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ESITO"]);
            DomandaPagamentoAllegatiObj.NoteIstruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["NOTE_ISTRUTTORE"]);
            DomandaPagamentoAllegatiObj.Esito = new SiarLibrary.NullTypes.StringNT(db.DataReader["ESITO"]);
            DomandaPagamentoAllegatiObj.EsitoPositivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ESITO_POSITIVO"]);
            DomandaPagamentoAllegatiObj.Formato = new SiarLibrary.NullTypes.StringNT(db.DataReader["FORMATO"]);
            DomandaPagamentoAllegatiObj.TipoAllegato = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ALLEGATO"]);
            DomandaPagamentoAllegatiObj.TipologiaDocumento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPOLOGIA_DOCUMENTO"]);
            DomandaPagamentoAllegatiObj.Ente = new SiarLibrary.NullTypes.StringNT(db.DataReader["ENTE"]);
            DomandaPagamentoAllegatiObj.DimensioneFile = new SiarLibrary.NullTypes.IntNT(db.DataReader["DIMENSIONE_FILE"]);
            DomandaPagamentoAllegatiObj.InIntegrazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["IN_INTEGRAZIONE"]);
            DomandaPagamentoAllegatiObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            DomandaPagamentoAllegatiObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
            DomandaPagamentoAllegatiObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            DomandaPagamentoAllegatiObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
            DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DomandaPagamentoAllegatiObj.IsDirty = false;
            DomandaPagamentoAllegatiObj.IsPersistent = true;
            return DomandaPagamentoAllegatiObj;
        }

        //Find Select

        public static DomandaPagamentoAllegatiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdAllegatoEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis,
SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis, SiarLibrary.NullTypes.IntNT IdFileEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEmettitoreEqualThis,
SiarLibrary.NullTypes.IntNT IdComuneEqualThis, SiarLibrary.NullTypes.StringNT NumeroEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEqualThis,
SiarLibrary.NullTypes.StringNT CodEsitoEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.StringNT CfModificaEqualThis)

        {

            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionObj = new DomandaPagamentoAllegatiCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandapagamentoallegatifindselect", new string[] {"IdAllegatoequalthis", "IdDomandaPagamentoequalthis", "Descrizioneequalthis",
"CodTipoDocumentoequalthis", "IdFileequalthis", "CodEnteEmettitoreequalthis",
"IdComuneequalthis", "Numeroequalthis", "Dataequalthis",
"CodEsitoequalthis", "InIntegrazioneequalthis", "DataInserimentoequalthis",
"CfInserimentoequalthis", "DataModificaequalthis", "CfModificaequalthis"}, new string[] {"int", "int", "string",
"string", "int", "string",
"int", "string", "DateTime",
"string", "bool", "DateTime",
"string", "DateTime", "string"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAllegatoequalthis", IdAllegatoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFileequalthis", IdFileEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEnteEmettitoreequalthis", CodEnteEmettitoreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdComuneequalthis", IdComuneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Numeroequalthis", NumeroEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Dataequalthis", DataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodEsitoequalthis", CodEsitoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
            DomandaPagamentoAllegati DomandaPagamentoAllegatiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaPagamentoAllegatiObj = GetFromDatareader(db);
                DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoAllegatiObj.IsDirty = false;
                DomandaPagamentoAllegatiObj.IsPersistent = true;
                DomandaPagamentoAllegatiCollectionObj.Add(DomandaPagamentoAllegatiObj);
            }
            db.Close();
            return DomandaPagamentoAllegatiCollectionObj;
        }

        //Find Find

        public static DomandaPagamentoAllegatiCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodTipoDocumentoEqualThis, SiarLibrary.NullTypes.StringNT FormatoEqualThis)

        {

            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionObj = new DomandaPagamentoAllegatiCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandapagamentoallegatifindfind", new string[] { "IdDomandaPagamentoequalthis", "CodTipoDocumentoequalthis", "Formatoequalthis" }, new string[] { "int", "string", "string" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoDocumentoequalthis", CodTipoDocumentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Formatoequalthis", FormatoEqualThis);
            DomandaPagamentoAllegati DomandaPagamentoAllegatiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaPagamentoAllegatiObj = GetFromDatareader(db);
                DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoAllegatiObj.IsDirty = false;
                DomandaPagamentoAllegatiObj.IsPersistent = true;
                DomandaPagamentoAllegatiCollectionObj.Add(DomandaPagamentoAllegatiObj);
            }
            db.Close();
            return DomandaPagamentoAllegatiCollectionObj;
        }

        //Find GetAllegatiDomandaInIntegrazione

        public static DomandaPagamentoAllegatiCollection GetAllegatiDomandaInIntegrazione(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.BoolNT InIntegrazioneEqualThis)

        {

            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionObj = new DomandaPagamentoAllegatiCollection();

            IDbCommand findCmd = db.InitCmd("Zdomandapagamentoallegatifindgetallegatidomandainintegrazione", new string[] { "IdDomandaPagamentoequalthis", "InIntegrazioneequalthis" }, new string[] { "int", "bool" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "InIntegrazioneequalthis", InIntegrazioneEqualThis);
            DomandaPagamentoAllegati DomandaPagamentoAllegatiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DomandaPagamentoAllegatiObj = GetFromDatareader(db);
                DomandaPagamentoAllegatiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DomandaPagamentoAllegatiObj.IsDirty = false;
                DomandaPagamentoAllegatiObj.IsPersistent = true;
                DomandaPagamentoAllegatiCollectionObj.Add(DomandaPagamentoAllegatiObj);
            }
            db.Close();
            return DomandaPagamentoAllegatiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for DomandaPagamentoAllegatiCollectionProvider:IDomandaPagamentoAllegatiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DomandaPagamentoAllegatiCollectionProvider : IDomandaPagamentoAllegatiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di DomandaPagamentoAllegati
        protected DomandaPagamentoAllegatiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public DomandaPagamentoAllegatiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new DomandaPagamentoAllegatiCollection(this);
        }

        //Costruttore 2: popola la collection
        public DomandaPagamentoAllegatiCollectionProvider(IntNT IddomandapagamentoEqualThis, StringNT CodtipodocumentoEqualThis, StringNT FormatoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IddomandapagamentoEqualThis, CodtipodocumentoEqualThis, FormatoEqualThis);
        }

        //Costruttore3: ha in input domandapagamentoallegatiCollectionObj - non popola la collection
        public DomandaPagamentoAllegatiCollectionProvider(DomandaPagamentoAllegatiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public DomandaPagamentoAllegatiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new DomandaPagamentoAllegatiCollection(this);
        }

        //Get e Set
        public DomandaPagamentoAllegatiCollection CollectionObj
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
        public int SaveCollection(DomandaPagamentoAllegatiCollection collectionObj)
        {
            return DomandaPagamentoAllegatiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(DomandaPagamentoAllegati domandapagamentoallegatiObj)
        {
            return DomandaPagamentoAllegatiDAL.Save(_dbProviderObj, domandapagamentoallegatiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(DomandaPagamentoAllegatiCollection collectionObj)
        {
            return DomandaPagamentoAllegatiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(DomandaPagamentoAllegati domandapagamentoallegatiObj)
        {
            return DomandaPagamentoAllegatiDAL.Delete(_dbProviderObj, domandapagamentoallegatiObj);
        }

        //getById
        public DomandaPagamentoAllegati GetById(IntNT IdAllegatoValue)
        {
            DomandaPagamentoAllegati DomandaPagamentoAllegatiTemp = DomandaPagamentoAllegatiDAL.GetById(_dbProviderObj, IdAllegatoValue);
            if (DomandaPagamentoAllegatiTemp != null) DomandaPagamentoAllegatiTemp.Provider = this;
            return DomandaPagamentoAllegatiTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public DomandaPagamentoAllegatiCollection Select(IntNT IdallegatoEqualThis, IntNT IddomandapagamentoEqualThis, StringNT DescrizioneEqualThis,
StringNT CodtipodocumentoEqualThis, IntNT IdfileEqualThis, StringNT CodenteemettitoreEqualThis,
IntNT IdcomuneEqualThis, StringNT NumeroEqualThis, DatetimeNT DataEqualThis,
StringNT CodesitoEqualThis, BoolNT InintegrazioneEqualThis, DatetimeNT DatainserimentoEqualThis,
StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis, StringNT CfmodificaEqualThis)
        {
            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionTemp = DomandaPagamentoAllegatiDAL.Select(_dbProviderObj, IdallegatoEqualThis, IddomandapagamentoEqualThis, DescrizioneEqualThis,
CodtipodocumentoEqualThis, IdfileEqualThis, CodenteemettitoreEqualThis,
IdcomuneEqualThis, NumeroEqualThis, DataEqualThis,
CodesitoEqualThis, InintegrazioneEqualThis, DatainserimentoEqualThis,
CfinserimentoEqualThis, DatamodificaEqualThis, CfmodificaEqualThis);
            DomandaPagamentoAllegatiCollectionTemp.Provider = this;
            return DomandaPagamentoAllegatiCollectionTemp;
        }

        //Find: popola la collection
        public DomandaPagamentoAllegatiCollection Find(IntNT IddomandapagamentoEqualThis, StringNT CodtipodocumentoEqualThis, StringNT FormatoEqualThis)
        {
            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionTemp = DomandaPagamentoAllegatiDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, CodtipodocumentoEqualThis, FormatoEqualThis);
            DomandaPagamentoAllegatiCollectionTemp.Provider = this;
            return DomandaPagamentoAllegatiCollectionTemp;
        }

        //GetAllegatiDomandaInIntegrazione: popola la collection
        public DomandaPagamentoAllegatiCollection GetAllegatiDomandaInIntegrazione(IntNT IddomandapagamentoEqualThis, BoolNT InintegrazioneEqualThis)
        {
            DomandaPagamentoAllegatiCollection DomandaPagamentoAllegatiCollectionTemp = DomandaPagamentoAllegatiDAL.GetAllegatiDomandaInIntegrazione(_dbProviderObj, IddomandapagamentoEqualThis, InintegrazioneEqualThis);
            DomandaPagamentoAllegatiCollectionTemp.Provider = this;
            return DomandaPagamentoAllegatiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_ALLEGATI>
  <ViewName>vDOMANDA_PAGAMENTO_ALLEGATI</ViewName>
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
    <Find OrderBy="ORDER BY ID_ALLEGATO, DATA_INSERIMENTO">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <COD_TIPO_DOCUMENTO>Equal</COD_TIPO_DOCUMENTO>
      <FORMATO>Equal</FORMATO>
    </Find>
    <GetAllegatiDomandaInIntegrazione OrderBy="ORDER BY ID_ALLEGATO, DATA_INSERIMENTO">
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <IN_INTEGRAZIONE>Equal</IN_INTEGRAZIONE>
    </GetAllegatiDomandaInIntegrazione>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_ALLEGATI>
*/
