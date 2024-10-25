using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per DecretiXDomPagEsportazione
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IDecretiXDomPagEsportazioneProvider
    {
        int Save(DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj);
        int SaveCollection(DecretiXDomPagEsportazioneCollection collectionObj);
        int Delete(DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj);
        int DeleteCollection(DecretiXDomPagEsportazioneCollection collectionObj);
    }
    /// <summary>
    /// Summary description for DecretiXDomPagEsportazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class DecretiXDomPagEsportazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdDecretiXDomPagEsportazione;
        private NullTypes.IntNT _IdDomandaPagamento;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdDecreto;
        private NullTypes.DecimalNT _Importo;
        private NullTypes.DatetimeNT _DataInserimento;
        private NullTypes.DatetimeNT _DataModifica;
        private NullTypes.BoolNT _RecuperoCompensazione;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.IntNT _Numero;
        private NullTypes.DatetimeNT _Data;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.StringNT _Servizio;
        private NullTypes.StringNT _Registro;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _CodDefinizione;
        private NullTypes.StringNT _CodOrganoIstituzionale;
        private NullTypes.DatetimeNT _DataBur;
        private NullTypes.IntNT _NumeroBur;
        private NullTypes.StringNT _AwDocnumber;
        private NullTypes.IntNT _AwDocnumberNuovo;
        private NullTypes.StringNT _DefinizioneAtto;
        private NullTypes.StringNT _TipoAtto;
        private NullTypes.StringNT _OrganoIstituzionale;
        private NullTypes.StringNT _LinkEsterno;
        [NonSerialized] private IDecretiXDomPagEsportazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDecretiXDomPagEsportazioneProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public DecretiXDomPagEsportazione()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_DECRETI_X_DOM_PAG_ESPORTAZIONE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDecretiXDomPagEsportazione
        {
            get { return _IdDecretiXDomPagEsportazione; }
            set
            {
                if (IdDecretiXDomPagEsportazione != value)
                {
                    _IdDecretiXDomPagEsportazione = value;
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
        /// Corrisponde al campo:ID_DECRETO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdDecreto
        {
            get { return _IdDecreto; }
            set
            {
                if (IdDecreto != value)
                {
                    _IdDecreto = value;
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
        /// Corrisponde al campo:RECUPERO_COMPENSAZIONE
        /// Tipo sul db:BIT
        /// Default:((0))
        /// </summary>
        public NullTypes.BoolNT RecuperoCompensazione
        {
            get { return _RecuperoCompensazione; }
            set
            {
                if (RecuperoCompensazione != value)
                {
                    _RecuperoCompensazione = value;
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
        /// Corrisponde al campo:NUMERO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Numero
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
        /// Corrisponde al campo:DESCRIZIONE
        /// Tipo sul db:VARCHAR(3000)
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
        /// Corrisponde al campo:SERVIZIO
        /// Tipo sul db:VARCHAR(255)
        /// </summary>
        public NullTypes.StringNT Servizio
        {
            get { return _Servizio; }
            set
            {
                if (Servizio != value)
                {
                    _Servizio = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:REGISTRO
        /// Tipo sul db:VARCHAR(10)
        /// </summary>
        public NullTypes.StringNT Registro
        {
            get { return _Registro; }
            set
            {
                if (Registro != value)
                {
                    _Registro = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:CHAR(1)
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
        /// Corrisponde al campo:COD_ORGANO_ISTITUZIONALE
        /// Tipo sul db:CHAR(2)
        /// </summary>
        public NullTypes.StringNT CodOrganoIstituzionale
        {
            get { return _CodOrganoIstituzionale; }
            set
            {
                if (CodOrganoIstituzionale != value)
                {
                    _CodOrganoIstituzionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_BUR
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataBur
        {
            get { return _DataBur; }
            set
            {
                if (DataBur != value)
                {
                    _DataBur = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:NUMERO_BUR
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT NumeroBur
        {
            get { return _NumeroBur; }
            set
            {
                if (NumeroBur != value)
                {
                    _NumeroBur = value;
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
        /// Corrisponde al campo:DEFINIZIONE_ATTO
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT DefinizioneAtto
        {
            get { return _DefinizioneAtto; }
            set
            {
                if (DefinizioneAtto != value)
                {
                    _DefinizioneAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO_ATTO
        /// Tipo sul db:VARCHAR(80)
        /// </summary>
        public NullTypes.StringNT TipoAtto
        {
            get { return _TipoAtto; }
            set
            {
                if (TipoAtto != value)
                {
                    _TipoAtto = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ORGANO_ISTITUZIONALE
        /// Tipo sul db:VARCHAR(100)
        /// </summary>
        public NullTypes.StringNT OrganoIstituzionale
        {
            get { return _OrganoIstituzionale; }
            set
            {
                if (OrganoIstituzionale != value)
                {
                    _OrganoIstituzionale = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LINK_ESTERNO
        /// Tipo sul db:VARCHAR(3000)
        /// </summary>
        public NullTypes.StringNT LinkEsterno
        {
            get { return _LinkEsterno; }
            set
            {
                if (LinkEsterno != value)
                {
                    _LinkEsterno = value;
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
    /// Summary description for DecretiXDomPagEsportazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DecretiXDomPagEsportazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private DecretiXDomPagEsportazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((DecretiXDomPagEsportazione)info.GetValue(i.ToString(), typeof(DecretiXDomPagEsportazione)));
            }
        }

        //Costruttore
        public DecretiXDomPagEsportazioneCollection()
        {
            this.ItemType = typeof(DecretiXDomPagEsportazione);
        }

        //Costruttore con provider
        public DecretiXDomPagEsportazioneCollection(IDecretiXDomPagEsportazioneProvider providerObj)
        {
            this.ItemType = typeof(DecretiXDomPagEsportazione);
            this.Provider = providerObj;
        }

        //Get e Set
        public new DecretiXDomPagEsportazione this[int index]
        {
            get { return (DecretiXDomPagEsportazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new DecretiXDomPagEsportazioneCollection GetChanges()
        {
            return (DecretiXDomPagEsportazioneCollection)base.GetChanges();
        }

        [NonSerialized] private IDecretiXDomPagEsportazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IDecretiXDomPagEsportazioneProvider Provider
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
        public int Add(DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj)
        {
            if (DecretiXDomPagEsportazioneObj.Provider == null) DecretiXDomPagEsportazioneObj.Provider = this.Provider;
            return base.Add(DecretiXDomPagEsportazioneObj);
        }

        //AddCollection
        public void AddCollection(DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionObj)
        {
            foreach (DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj in DecretiXDomPagEsportazioneCollectionObj)
                this.Add(DecretiXDomPagEsportazioneObj);
        }

        //Insert
        public void Insert(int index, DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj)
        {
            if (DecretiXDomPagEsportazioneObj.Provider == null) DecretiXDomPagEsportazioneObj.Provider = this.Provider;
            base.Insert(index, DecretiXDomPagEsportazioneObj);
        }

        //CollectionGetById
        public DecretiXDomPagEsportazione CollectionGetById(NullTypes.IntNT IdDecretiXDomPagEsportazioneValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdDecretiXDomPagEsportazione == IdDecretiXDomPagEsportazioneValue))
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
        public DecretiXDomPagEsportazioneCollection SubSelect(NullTypes.IntNT IdDecretiXDomPagEsportazioneEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdProgettoEqualThis,
NullTypes.IntNT IdDecretoEqualThis, NullTypes.DecimalNT ImportoEqualThis, NullTypes.DatetimeNT DataInserimentoEqualThis,
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.BoolNT RecuperoCompensazioneEqualThis)
        {
            DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionTemp = new DecretiXDomPagEsportazioneCollection();
            foreach (DecretiXDomPagEsportazione DecretiXDomPagEsportazioneItem in this)
            {
                if (((IdDecretiXDomPagEsportazioneEqualThis == null) || ((DecretiXDomPagEsportazioneItem.IdDecretiXDomPagEsportazione != null) && (DecretiXDomPagEsportazioneItem.IdDecretiXDomPagEsportazione.Value == IdDecretiXDomPagEsportazioneEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((DecretiXDomPagEsportazioneItem.IdDomandaPagamento != null) && (DecretiXDomPagEsportazioneItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DecretiXDomPagEsportazioneItem.IdProgetto != null) && (DecretiXDomPagEsportazioneItem.IdProgetto.Value == IdProgettoEqualThis.Value))) &&
((IdDecretoEqualThis == null) || ((DecretiXDomPagEsportazioneItem.IdDecreto != null) && (DecretiXDomPagEsportazioneItem.IdDecreto.Value == IdDecretoEqualThis.Value))) && ((ImportoEqualThis == null) || ((DecretiXDomPagEsportazioneItem.Importo != null) && (DecretiXDomPagEsportazioneItem.Importo.Value == ImportoEqualThis.Value))) && ((DataInserimentoEqualThis == null) || ((DecretiXDomPagEsportazioneItem.DataInserimento != null) && (DecretiXDomPagEsportazioneItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) &&
((DataModificaEqualThis == null) || ((DecretiXDomPagEsportazioneItem.DataModifica != null) && (DecretiXDomPagEsportazioneItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((RecuperoCompensazioneEqualThis == null) || ((DecretiXDomPagEsportazioneItem.RecuperoCompensazione != null) && (DecretiXDomPagEsportazioneItem.RecuperoCompensazione.Value == RecuperoCompensazioneEqualThis.Value))))
                {
                    DecretiXDomPagEsportazioneCollectionTemp.Add(DecretiXDomPagEsportazioneItem);
                }
            }
            return DecretiXDomPagEsportazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for DecretiXDomPagEsportazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class DecretiXDomPagEsportazioneDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdDecretiXDomPagEsportazione", DecretiXDomPagEsportazioneObj.IdDecretiXDomPagEsportazione);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdDomandaPagamento", DecretiXDomPagEsportazioneObj.IdDomandaPagamento);
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", DecretiXDomPagEsportazioneObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdDecreto", DecretiXDomPagEsportazioneObj.IdDecreto);
            DbProvider.SetCmdParam(cmd, firstChar + "Importo", DecretiXDomPagEsportazioneObj.Importo);
            DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", DecretiXDomPagEsportazioneObj.DataInserimento);
            DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", DecretiXDomPagEsportazioneObj.DataModifica);
            DbProvider.SetCmdParam(cmd, firstChar + "RecuperoCompensazione", DecretiXDomPagEsportazioneObj.RecuperoCompensazione);
        }
        //Insert
        private static int Insert(DbProvider db, DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZDecretiXDomPagEsportazioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "RecuperoCompensazione",




}, new string[] {"int", "int",
"int", "decimal", "DateTime",
"DateTime", "bool",




}, "");
                CompileIUCmd(false, insertCmd, DecretiXDomPagEsportazioneObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    DecretiXDomPagEsportazioneObj.IdDecretiXDomPagEsportazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETI_X_DOM_PAG_ESPORTAZIONE"]);
                    DecretiXDomPagEsportazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                    DecretiXDomPagEsportazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                    DecretiXDomPagEsportazioneObj.RecuperoCompensazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERO_COMPENSAZIONE"]);
                }
                DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneObj.IsDirty = false;
                DecretiXDomPagEsportazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDecretiXDomPagEsportazioneUpdate", new string[] {"IdDecretiXDomPagEsportazione", "IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "RecuperoCompensazione",




}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "bool",




}, "");
                CompileIUCmd(true, updateCmd, DecretiXDomPagEsportazioneObj, db.CommandFirstChar);
                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                if (d != null)
                {
                    i = 1;
                    DecretiXDomPagEsportazioneObj.DataModifica = d;
                }
                DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneObj.IsDirty = false;
                DecretiXDomPagEsportazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj)
        {
            switch (DecretiXDomPagEsportazioneObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, DecretiXDomPagEsportazioneObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, DecretiXDomPagEsportazioneObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, DecretiXDomPagEsportazioneObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZDecretiXDomPagEsportazioneUpdate", new string[] {"IdDecretiXDomPagEsportazione", "IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "RecuperoCompensazione",




}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "bool",




}, "");
                IDbCommand insertCmd = db.InitCmd("ZDecretiXDomPagEsportazioneInsert", new string[] {"IdDomandaPagamento", "IdProgetto",
"IdDecreto", "Importo", "DataInserimento",
"DataModifica", "RecuperoCompensazione",




}, new string[] {"int", "int",
"int", "decimal", "DateTime",
"DateTime", "bool",




}, "");
                IDbCommand deleteCmd = db.InitCmd("ZDecretiXDomPagEsportazioneDelete", new string[] { "IdDecretiXDomPagEsportazione" }, new string[] { "int" }, "");
                for (int i = 0; i < DecretiXDomPagEsportazioneCollectionObj.Count; i++)
                {
                    switch (DecretiXDomPagEsportazioneCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, DecretiXDomPagEsportazioneCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    DecretiXDomPagEsportazioneCollectionObj[i].IdDecretiXDomPagEsportazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETI_X_DOM_PAG_ESPORTAZIONE"]);
                                    DecretiXDomPagEsportazioneCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
                                    DecretiXDomPagEsportazioneCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
                                    DecretiXDomPagEsportazioneCollectionObj[i].RecuperoCompensazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERO_COMPENSAZIONE"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, DecretiXDomPagEsportazioneCollectionObj[i], db.CommandFirstChar);
                                SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
                                if (d != null)
                                {
                                    returnValue++;
                                    DecretiXDomPagEsportazioneCollectionObj[i].DataModifica = d;
                                }
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (DecretiXDomPagEsportazioneCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDecretiXDomPagEsportazione", (SiarLibrary.NullTypes.IntNT)DecretiXDomPagEsportazioneCollectionObj[i].IdDecretiXDomPagEsportazione);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < DecretiXDomPagEsportazioneCollectionObj.Count; i++)
                {
                    if ((DecretiXDomPagEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DecretiXDomPagEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DecretiXDomPagEsportazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        DecretiXDomPagEsportazioneCollectionObj[i].IsDirty = false;
                        DecretiXDomPagEsportazioneCollectionObj[i].IsPersistent = true;
                    }
                    if ((DecretiXDomPagEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        DecretiXDomPagEsportazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DecretiXDomPagEsportazioneCollectionObj[i].IsDirty = false;
                        DecretiXDomPagEsportazioneCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj)
        {
            int returnValue = 0;
            if (DecretiXDomPagEsportazioneObj.IsPersistent)
            {
                returnValue = Delete(db, DecretiXDomPagEsportazioneObj.IdDecretiXDomPagEsportazione);
            }
            DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            DecretiXDomPagEsportazioneObj.IsDirty = false;
            DecretiXDomPagEsportazioneObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdDecretiXDomPagEsportazioneValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDecretiXDomPagEsportazioneDelete", new string[] { "IdDecretiXDomPagEsportazione" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDecretiXDomPagEsportazione", (SiarLibrary.NullTypes.IntNT)IdDecretiXDomPagEsportazioneValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZDecretiXDomPagEsportazioneDelete", new string[] { "IdDecretiXDomPagEsportazione" }, new string[] { "int" }, "");
                for (int i = 0; i < DecretiXDomPagEsportazioneCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdDecretiXDomPagEsportazione", DecretiXDomPagEsportazioneCollectionObj[i].IdDecretiXDomPagEsportazione);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < DecretiXDomPagEsportazioneCollectionObj.Count; i++)
                {
                    if ((DecretiXDomPagEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (DecretiXDomPagEsportazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        DecretiXDomPagEsportazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        DecretiXDomPagEsportazioneCollectionObj[i].IsDirty = false;
                        DecretiXDomPagEsportazioneCollectionObj[i].IsPersistent = false;
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
        public static DecretiXDomPagEsportazione GetById(DbProvider db, int IdDecretiXDomPagEsportazioneValue)
        {
            DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj = null;
            IDbCommand readCmd = db.InitCmd("ZDecretiXDomPagEsportazioneGetById", new string[] { "IdDecretiXDomPagEsportazione" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdDecretiXDomPagEsportazione", (SiarLibrary.NullTypes.IntNT)IdDecretiXDomPagEsportazioneValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                DecretiXDomPagEsportazioneObj = GetFromDatareader(db);
                DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneObj.IsDirty = false;
                DecretiXDomPagEsportazioneObj.IsPersistent = true;
            }
            db.Close();
            return DecretiXDomPagEsportazioneObj;
        }

        //getFromDatareader
        public static DecretiXDomPagEsportazione GetFromDatareader(DbProvider db)
        {
            DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj = new DecretiXDomPagEsportazione();
            DecretiXDomPagEsportazioneObj.IdDecretiXDomPagEsportazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETI_X_DOM_PAG_ESPORTAZIONE"]);
            DecretiXDomPagEsportazioneObj.IdDomandaPagamento = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DOMANDA_PAGAMENTO"]);
            DecretiXDomPagEsportazioneObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            DecretiXDomPagEsportazioneObj.IdDecreto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DECRETO"]);
            DecretiXDomPagEsportazioneObj.Importo = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO"]);
            DecretiXDomPagEsportazioneObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
            DecretiXDomPagEsportazioneObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
            DecretiXDomPagEsportazioneObj.RecuperoCompensazione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["RECUPERO_COMPENSAZIONE"]);
            DecretiXDomPagEsportazioneObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            DecretiXDomPagEsportazioneObj.Numero = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO"]);
            DecretiXDomPagEsportazioneObj.Data = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA"]);
            DecretiXDomPagEsportazioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            DecretiXDomPagEsportazioneObj.Servizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["SERVIZIO"]);
            DecretiXDomPagEsportazioneObj.Registro = new SiarLibrary.NullTypes.StringNT(db.DataReader["REGISTRO"]);
            DecretiXDomPagEsportazioneObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            DecretiXDomPagEsportazioneObj.CodDefinizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_DEFINIZIONE"]);
            DecretiXDomPagEsportazioneObj.CodOrganoIstituzionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ORGANO_ISTITUZIONALE"]);
            DecretiXDomPagEsportazioneObj.DataBur = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_BUR"]);
            DecretiXDomPagEsportazioneObj.NumeroBur = new SiarLibrary.NullTypes.IntNT(db.DataReader["NUMERO_BUR"]);
            DecretiXDomPagEsportazioneObj.AwDocnumber = new SiarLibrary.NullTypes.StringNT(db.DataReader["AW_DOCNUMBER"]);
            DecretiXDomPagEsportazioneObj.AwDocnumberNuovo = new SiarLibrary.NullTypes.IntNT(db.DataReader["AW_DOCNUMBER_NUOVO"]);
            DecretiXDomPagEsportazioneObj.DefinizioneAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["DEFINIZIONE_ATTO"]);
            DecretiXDomPagEsportazioneObj.TipoAtto = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_ATTO"]);
            DecretiXDomPagEsportazioneObj.OrganoIstituzionale = new SiarLibrary.NullTypes.StringNT(db.DataReader["ORGANO_ISTITUZIONALE"]);
            DecretiXDomPagEsportazioneObj.LinkEsterno = new SiarLibrary.NullTypes.StringNT(db.DataReader["LINK_ESTERNO"]);
            DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            DecretiXDomPagEsportazioneObj.IsDirty = false;
            DecretiXDomPagEsportazioneObj.IsPersistent = true;
            return DecretiXDomPagEsportazioneObj;
        }

        //Find Select

        public static DecretiXDomPagEsportazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdDecretiXDomPagEsportazioneEqualThis, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis,
SiarLibrary.NullTypes.IntNT IdDecretoEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis, SiarLibrary.NullTypes.BoolNT RecuperoCompensazioneEqualThis)

        {

            DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionObj = new DecretiXDomPagEsportazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zdecretixdompagesportazionefindselect", new string[] {"IdDecretiXDomPagEsportazioneequalthis", "IdDomandaPagamentoequalthis", "IdProgettoequalthis",
"IdDecretoequalthis", "Importoequalthis", "DataInserimentoequalthis",
"DataModificaequalthis", "RecuperoCompensazioneequalthis"}, new string[] {"int", "int", "int",
"int", "decimal", "DateTime",
"DateTime", "bool"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretiXDomPagEsportazioneequalthis", IdDecretiXDomPagEsportazioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Importoequalthis", ImportoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RecuperoCompensazioneequalthis", RecuperoCompensazioneEqualThis);
            DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DecretiXDomPagEsportazioneObj = GetFromDatareader(db);
                DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneObj.IsDirty = false;
                DecretiXDomPagEsportazioneObj.IsPersistent = true;
                DecretiXDomPagEsportazioneCollectionObj.Add(DecretiXDomPagEsportazioneObj);
            }
            db.Close();
            return DecretiXDomPagEsportazioneCollectionObj;
        }

        //Find Find

        public static DecretiXDomPagEsportazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdDomandaPagamentoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdDecretoEqualThis)

        {

            DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionObj = new DecretiXDomPagEsportazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zdecretixdompagesportazionefindfind", new string[] { "IdDomandaPagamentoequalthis", "IdProgettoequalthis", "IdDecretoequalthis" }, new string[] { "int", "int", "int" }, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDomandaPagamentoequalthis", IdDomandaPagamentoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdDecretoequalthis", IdDecretoEqualThis);
            DecretiXDomPagEsportazione DecretiXDomPagEsportazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                DecretiXDomPagEsportazioneObj = GetFromDatareader(db);
                DecretiXDomPagEsportazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                DecretiXDomPagEsportazioneObj.IsDirty = false;
                DecretiXDomPagEsportazioneObj.IsPersistent = true;
                DecretiXDomPagEsportazioneCollectionObj.Add(DecretiXDomPagEsportazioneObj);
            }
            db.Close();
            return DecretiXDomPagEsportazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for DecretiXDomPagEsportazioneCollectionProvider:IDecretiXDomPagEsportazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class DecretiXDomPagEsportazioneCollectionProvider : IDecretiXDomPagEsportazioneProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di DecretiXDomPagEsportazione
        protected DecretiXDomPagEsportazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public DecretiXDomPagEsportazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new DecretiXDomPagEsportazioneCollection(this);
        }

        //Costruttore 2: popola la collection
        public DecretiXDomPagEsportazioneCollectionProvider(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, IntNT IddecretoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IddomandapagamentoEqualThis, IdprogettoEqualThis, IddecretoEqualThis);
        }

        //Costruttore3: ha in input decretixdompagesportazioneCollectionObj - non popola la collection
        public DecretiXDomPagEsportazioneCollectionProvider(DecretiXDomPagEsportazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public DecretiXDomPagEsportazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new DecretiXDomPagEsportazioneCollection(this);
        }

        //Get e Set
        public DecretiXDomPagEsportazioneCollection CollectionObj
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
        public int SaveCollection(DecretiXDomPagEsportazioneCollection collectionObj)
        {
            return DecretiXDomPagEsportazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(DecretiXDomPagEsportazione decretixdompagesportazioneObj)
        {
            return DecretiXDomPagEsportazioneDAL.Save(_dbProviderObj, decretixdompagesportazioneObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(DecretiXDomPagEsportazioneCollection collectionObj)
        {
            return DecretiXDomPagEsportazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(DecretiXDomPagEsportazione decretixdompagesportazioneObj)
        {
            return DecretiXDomPagEsportazioneDAL.Delete(_dbProviderObj, decretixdompagesportazioneObj);
        }

        //getById
        public DecretiXDomPagEsportazione GetById(IntNT IdDecretiXDomPagEsportazioneValue)
        {
            DecretiXDomPagEsportazione DecretiXDomPagEsportazioneTemp = DecretiXDomPagEsportazioneDAL.GetById(_dbProviderObj, IdDecretiXDomPagEsportazioneValue);
            if (DecretiXDomPagEsportazioneTemp != null) DecretiXDomPagEsportazioneTemp.Provider = this;
            return DecretiXDomPagEsportazioneTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public DecretiXDomPagEsportazioneCollection Select(IntNT IddecretixdompagesportazioneEqualThis, IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis,
IntNT IddecretoEqualThis, DecimalNT ImportoEqualThis, DatetimeNT DatainserimentoEqualThis,
DatetimeNT DatamodificaEqualThis, BoolNT RecuperocompensazioneEqualThis)
        {
            DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionTemp = DecretiXDomPagEsportazioneDAL.Select(_dbProviderObj, IddecretixdompagesportazioneEqualThis, IddomandapagamentoEqualThis, IdprogettoEqualThis,
IddecretoEqualThis, ImportoEqualThis, DatainserimentoEqualThis,
DatamodificaEqualThis, RecuperocompensazioneEqualThis);
            DecretiXDomPagEsportazioneCollectionTemp.Provider = this;
            return DecretiXDomPagEsportazioneCollectionTemp;
        }

        //Find: popola la collection
        public DecretiXDomPagEsportazioneCollection Find(IntNT IddomandapagamentoEqualThis, IntNT IdprogettoEqualThis, IntNT IddecretoEqualThis)
        {
            DecretiXDomPagEsportazioneCollection DecretiXDomPagEsportazioneCollectionTemp = DecretiXDomPagEsportazioneDAL.Find(_dbProviderObj, IddomandapagamentoEqualThis, IdprogettoEqualThis, IddecretoEqualThis);
            DecretiXDomPagEsportazioneCollectionTemp.Provider = this;
            return DecretiXDomPagEsportazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<DECRETI_X_DOM_PAG_ESPORTAZIONE>
  <ViewName>vDECRETI_X_DOM_PAG_ESPORTAZIONE</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DECRETO>Equal</ID_DECRETO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DECRETI_X_DOM_PAG_ESPORTAZIONE>
*/
