using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per CertspConti
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface ICertspContiProvider
    {
        int Save(CertspConti CertspContiObj);
        int SaveCollection(CertspContiCollection collectionObj);
        int Delete(CertspConti CertspContiObj);
        int DeleteCollection(CertspContiCollection collectionObj);
    }
    /// <summary>
    /// Summary description for CertspConti
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class CertspConti : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _IdConto;
        private NullTypes.IntNT _IdProgetto;
        private NullTypes.IntNT _IdAtto;
        private NullTypes.DatetimeNT _DataPresContab;
        private NullTypes.DatetimeNT _DataPresConti;
        private NullTypes.DecimalNT _TotRegistrate;
        private NullTypes.DecimalNT _TotSpesapubRegistrate;
        private NullTypes.DecimalNT _TotPagamentiRegistrate;
        private NullTypes.DecimalNT _TotRitirata;
        private NullTypes.DecimalNT _TotSpesapubRitirata;
        private NullTypes.DecimalNT _TotRecuperata;
        private NullTypes.DecimalNT _TotSpesapubRecuperata;
        private NullTypes.DecimalNT _TotDarecuperare;
        private NullTypes.DecimalNT _TotSpesapubDarecuperare;
        private NullTypes.DecimalNT _TotNonrecuperab;
        private NullTypes.DecimalNT _TotSpesapubNonrecuperab;
        private NullTypes.DecimalNT _RecuperatoArt71;
        private NullTypes.DecimalNT _RecuperatoArt71Pubblica;
        [NonSerialized]
        private ICertspContiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICertspContiProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public CertspConti()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID_CONTO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdConto
        {
            get { return _IdConto; }
            set
            {
                if (IdConto != value)
                {
                    _IdConto = value;
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
        /// Corrisponde al campo:DATA_PRES_CONTAB
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPresContab
        {
            get { return _DataPresContab; }
            set
            {
                if (DataPresContab != value)
                {
                    _DataPresContab = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:DATA_PRES_CONTI
        /// Tipo sul db:DATETIME
        /// </summary>
        public NullTypes.DatetimeNT DataPresConti
        {
            get { return _DataPresConti; }
            set
            {
                if (DataPresConti != value)
                {
                    _DataPresConti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_REGISTRATE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotRegistrate
        {
            get { return _TotRegistrate; }
            set
            {
                if (TotRegistrate != value)
                {
                    _TotRegistrate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_SPESAPUB_REGISTRATE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotSpesapubRegistrate
        {
            get { return _TotSpesapubRegistrate; }
            set
            {
                if (TotSpesapubRegistrate != value)
                {
                    _TotSpesapubRegistrate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_PAGAMENTI_REGISTRATE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotPagamentiRegistrate
        {
            get { return _TotPagamentiRegistrate; }
            set
            {
                if (TotPagamentiRegistrate != value)
                {
                    _TotPagamentiRegistrate = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_RITIRATA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotRitirata
        {
            get { return _TotRitirata; }
            set
            {
                if (TotRitirata != value)
                {
                    _TotRitirata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_SPESAPUB_RITIRATA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotSpesapubRitirata
        {
            get { return _TotSpesapubRitirata; }
            set
            {
                if (TotSpesapubRitirata != value)
                {
                    _TotSpesapubRitirata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_RECUPERATA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotRecuperata
        {
            get { return _TotRecuperata; }
            set
            {
                if (TotRecuperata != value)
                {
                    _TotRecuperata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_SPESAPUB_RECUPERATA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotSpesapubRecuperata
        {
            get { return _TotSpesapubRecuperata; }
            set
            {
                if (TotSpesapubRecuperata != value)
                {
                    _TotSpesapubRecuperata = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_DARECUPERARE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotDarecuperare
        {
            get { return _TotDarecuperare; }
            set
            {
                if (TotDarecuperare != value)
                {
                    _TotDarecuperare = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_SPESAPUB_DARECUPERARE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotSpesapubDarecuperare
        {
            get { return _TotSpesapubDarecuperare; }
            set
            {
                if (TotSpesapubDarecuperare != value)
                {
                    _TotSpesapubDarecuperare = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_NONRECUPERAB
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotNonrecuperab
        {
            get { return _TotNonrecuperab; }
            set
            {
                if (TotNonrecuperab != value)
                {
                    _TotNonrecuperab = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TOT_SPESAPUB_NONRECUPERAB
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT TotSpesapubNonrecuperab
        {
            get { return _TotSpesapubNonrecuperab; }
            set
            {
                if (TotSpesapubNonrecuperab != value)
                {
                    _TotSpesapubNonrecuperab = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RECUPERATO_ART71
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT RecuperatoArt71
        {
            get { return _RecuperatoArt71; }
            set
            {
                if (RecuperatoArt71 != value)
                {
                    _RecuperatoArt71 = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:RECUPERATO_ART71_PUBBLICA
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT RecuperatoArt71Pubblica
        {
            get { return _RecuperatoArt71Pubblica; }
            set
            {
                if (RecuperatoArt71Pubblica != value)
                {
                    _RecuperatoArt71Pubblica = value;
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
    /// Summary description for CertspContiCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CertspContiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private CertspContiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((CertspConti)info.GetValue(i.ToString(), typeof(CertspConti)));
            }
        }

        //Costruttore
        public CertspContiCollection()
        {
            this.ItemType = typeof(CertspConti);
        }

        //Costruttore con provider
        public CertspContiCollection(ICertspContiProvider providerObj)
        {
            this.ItemType = typeof(CertspConti);
            this.Provider = providerObj;
        }

        //Get e Set
        public new CertspConti this[int index]
        {
            get { return (CertspConti)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new CertspContiCollection GetChanges()
        {
            return (CertspContiCollection)base.GetChanges();
        }

        [NonSerialized]
        private ICertspContiProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICertspContiProvider Provider
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
        public int Add(CertspConti CertspContiObj)
        {
            if (CertspContiObj.Provider == null) CertspContiObj.Provider = this.Provider;
            return base.Add(CertspContiObj);
        }

        //AddCollection
        public void AddCollection(CertspContiCollection CertspContiCollectionObj)
        {
            foreach (CertspConti CertspContiObj in CertspContiCollectionObj)
                this.Add(CertspContiObj);
        }

        //Insert
        public void Insert(int index, CertspConti CertspContiObj)
        {
            if (CertspContiObj.Provider == null) CertspContiObj.Provider = this.Provider;
            base.Insert(index, CertspContiObj);
        }

        //CollectionGetById
        public CertspConti CollectionGetById(NullTypes.IntNT IdContoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdConto == IdContoValue))
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
        public CertspContiCollection SubSelect(NullTypes.IntNT IdContoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdAttoEqualThis,
NullTypes.DatetimeNT DataPresContabEqualThis, NullTypes.DatetimeNT DataPresContiEqualThis, NullTypes.DecimalNT TotRegistrateEqualThis,
NullTypes.DecimalNT TotSpesapubRegistrateEqualThis, NullTypes.DecimalNT TotPagamentiRegistrateEqualThis, NullTypes.DecimalNT TotRitirataEqualThis,
NullTypes.DecimalNT TotSpesapubRitirataEqualThis, NullTypes.DecimalNT TotRecuperataEqualThis, NullTypes.DecimalNT TotSpesapubRecuperataEqualThis,
NullTypes.DecimalNT TotDarecuperareEqualThis, NullTypes.DecimalNT TotSpesapubDarecuperareEqualThis, NullTypes.DecimalNT TotNonrecuperabEqualThis,
NullTypes.DecimalNT TotSpesapubNonrecuperabEqualThis, NullTypes.DecimalNT RecuperatoArt71EqualThis, NullTypes.DecimalNT RecuperatoArt71PubblicaEqualThis)
        {
            CertspContiCollection CertspContiCollectionTemp = new CertspContiCollection();
            foreach (CertspConti CertspContiItem in this)
            {
                if (((IdContoEqualThis == null) || ((CertspContiItem.IdConto != null) && (CertspContiItem.IdConto.Value == IdContoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((CertspContiItem.IdProgetto != null) && (CertspContiItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdAttoEqualThis == null) || ((CertspContiItem.IdAtto != null) && (CertspContiItem.IdAtto.Value == IdAttoEqualThis.Value))) &&
((DataPresContabEqualThis == null) || ((CertspContiItem.DataPresContab != null) && (CertspContiItem.DataPresContab.Value == DataPresContabEqualThis.Value))) && ((DataPresContiEqualThis == null) || ((CertspContiItem.DataPresConti != null) && (CertspContiItem.DataPresConti.Value == DataPresContiEqualThis.Value))) && ((TotRegistrateEqualThis == null) || ((CertspContiItem.TotRegistrate != null) && (CertspContiItem.TotRegistrate.Value == TotRegistrateEqualThis.Value))) &&
((TotSpesapubRegistrateEqualThis == null) || ((CertspContiItem.TotSpesapubRegistrate != null) && (CertspContiItem.TotSpesapubRegistrate.Value == TotSpesapubRegistrateEqualThis.Value))) && ((TotPagamentiRegistrateEqualThis == null) || ((CertspContiItem.TotPagamentiRegistrate != null) && (CertspContiItem.TotPagamentiRegistrate.Value == TotPagamentiRegistrateEqualThis.Value))) && ((TotRitirataEqualThis == null) || ((CertspContiItem.TotRitirata != null) && (CertspContiItem.TotRitirata.Value == TotRitirataEqualThis.Value))) &&
((TotSpesapubRitirataEqualThis == null) || ((CertspContiItem.TotSpesapubRitirata != null) && (CertspContiItem.TotSpesapubRitirata.Value == TotSpesapubRitirataEqualThis.Value))) && ((TotRecuperataEqualThis == null) || ((CertspContiItem.TotRecuperata != null) && (CertspContiItem.TotRecuperata.Value == TotRecuperataEqualThis.Value))) && ((TotSpesapubRecuperataEqualThis == null) || ((CertspContiItem.TotSpesapubRecuperata != null) && (CertspContiItem.TotSpesapubRecuperata.Value == TotSpesapubRecuperataEqualThis.Value))) &&
((TotDarecuperareEqualThis == null) || ((CertspContiItem.TotDarecuperare != null) && (CertspContiItem.TotDarecuperare.Value == TotDarecuperareEqualThis.Value))) && ((TotSpesapubDarecuperareEqualThis == null) || ((CertspContiItem.TotSpesapubDarecuperare != null) && (CertspContiItem.TotSpesapubDarecuperare.Value == TotSpesapubDarecuperareEqualThis.Value))) && ((TotNonrecuperabEqualThis == null) || ((CertspContiItem.TotNonrecuperab != null) && (CertspContiItem.TotNonrecuperab.Value == TotNonrecuperabEqualThis.Value))) &&
((TotSpesapubNonrecuperabEqualThis == null) || ((CertspContiItem.TotSpesapubNonrecuperab != null) && (CertspContiItem.TotSpesapubNonrecuperab.Value == TotSpesapubNonrecuperabEqualThis.Value))) && ((RecuperatoArt71EqualThis == null) || ((CertspContiItem.RecuperatoArt71 != null) && (CertspContiItem.RecuperatoArt71.Value == RecuperatoArt71EqualThis.Value))) && ((RecuperatoArt71PubblicaEqualThis == null) || ((CertspContiItem.RecuperatoArt71Pubblica != null) && (CertspContiItem.RecuperatoArt71Pubblica.Value == RecuperatoArt71PubblicaEqualThis.Value))))
                {
                    CertspContiCollectionTemp.Add(CertspContiItem);
                }
            }
            return CertspContiCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for CertspContiDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class CertspContiDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, CertspConti CertspContiObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "IdConto", CertspContiObj.IdConto);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "IdProgetto", CertspContiObj.IdProgetto);
            DbProvider.SetCmdParam(cmd, firstChar + "IdAtto", CertspContiObj.IdAtto);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPresContab", CertspContiObj.DataPresContab);
            DbProvider.SetCmdParam(cmd, firstChar + "DataPresConti", CertspContiObj.DataPresConti);
            DbProvider.SetCmdParam(cmd, firstChar + "TotRegistrate", CertspContiObj.TotRegistrate);
            DbProvider.SetCmdParam(cmd, firstChar + "TotSpesapubRegistrate", CertspContiObj.TotSpesapubRegistrate);
            DbProvider.SetCmdParam(cmd, firstChar + "TotPagamentiRegistrate", CertspContiObj.TotPagamentiRegistrate);
            DbProvider.SetCmdParam(cmd, firstChar + "TotRitirata", CertspContiObj.TotRitirata);
            DbProvider.SetCmdParam(cmd, firstChar + "TotSpesapubRitirata", CertspContiObj.TotSpesapubRitirata);
            DbProvider.SetCmdParam(cmd, firstChar + "TotRecuperata", CertspContiObj.TotRecuperata);
            DbProvider.SetCmdParam(cmd, firstChar + "TotSpesapubRecuperata", CertspContiObj.TotSpesapubRecuperata);
            DbProvider.SetCmdParam(cmd, firstChar + "TotDarecuperare", CertspContiObj.TotDarecuperare);
            DbProvider.SetCmdParam(cmd, firstChar + "TotSpesapubDarecuperare", CertspContiObj.TotSpesapubDarecuperare);
            DbProvider.SetCmdParam(cmd, firstChar + "TotNonrecuperab", CertspContiObj.TotNonrecuperab);
            DbProvider.SetCmdParam(cmd, firstChar + "TotSpesapubNonrecuperab", CertspContiObj.TotSpesapubNonrecuperab);
            DbProvider.SetCmdParam(cmd, firstChar + "RecuperatoArt71", CertspContiObj.RecuperatoArt71);
            DbProvider.SetCmdParam(cmd, firstChar + "RecuperatoArt71Pubblica", CertspContiObj.RecuperatoArt71Pubblica);
        }
        //Insert
        private static int Insert(DbProvider db, CertspConti CertspContiObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZCertspContiInsert", new string[] {"IdProgetto", "IdAtto", 
"DataPresContab", "DataPresConti", "TotRegistrate", 
"TotSpesapubRegistrate", "TotPagamentiRegistrate", "TotRitirata", 
"TotSpesapubRitirata", "TotRecuperata", "TotSpesapubRecuperata", 
"TotDarecuperare", "TotSpesapubDarecuperare", "TotNonrecuperab", 
"TotSpesapubNonrecuperab", "RecuperatoArt71", "RecuperatoArt71Pubblica"}, new string[] {"int", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                CompileIUCmd(false, insertCmd, CertspContiObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    CertspContiObj.IdConto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO"]);
                }
                CertspContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspContiObj.IsDirty = false;
                CertspContiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, CertspConti CertspContiObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZCertspContiUpdate", new string[] {"IdConto", "IdProgetto", "IdAtto", 
"DataPresContab", "DataPresConti", "TotRegistrate", 
"TotSpesapubRegistrate", "TotPagamentiRegistrate", "TotRitirata", 
"TotSpesapubRitirata", "TotRecuperata", "TotSpesapubRecuperata", 
"TotDarecuperare", "TotSpesapubDarecuperare", "TotNonrecuperab", 
"TotSpesapubNonrecuperab", "RecuperatoArt71", "RecuperatoArt71Pubblica"}, new string[] {"int", "int", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                CompileIUCmd(true, updateCmd, CertspContiObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                CertspContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspContiObj.IsDirty = false;
                CertspContiObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, CertspConti CertspContiObj)
        {
            switch (CertspContiObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, CertspContiObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, CertspContiObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, CertspContiObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, CertspContiCollection CertspContiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZCertspContiUpdate", new string[] {"IdConto", "IdProgetto", "IdAtto", 
"DataPresContab", "DataPresConti", "TotRegistrate", 
"TotSpesapubRegistrate", "TotPagamentiRegistrate", "TotRitirata", 
"TotSpesapubRitirata", "TotRecuperata", "TotSpesapubRecuperata", 
"TotDarecuperare", "TotSpesapubDarecuperare", "TotNonrecuperab", 
"TotSpesapubNonrecuperab", "RecuperatoArt71", "RecuperatoArt71Pubblica"}, new string[] {"int", "int", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                IDbCommand insertCmd = db.InitCmd("ZCertspContiInsert", new string[] {"IdProgetto", "IdAtto", 
"DataPresContab", "DataPresConti", "TotRegistrate", 
"TotSpesapubRegistrate", "TotPagamentiRegistrate", "TotRitirata", 
"TotSpesapubRitirata", "TotRecuperata", "TotSpesapubRecuperata", 
"TotDarecuperare", "TotSpesapubDarecuperare", "TotNonrecuperab", 
"TotSpesapubNonrecuperab", "RecuperatoArt71", "RecuperatoArt71Pubblica"}, new string[] {"int", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZCertspContiDelete", new string[] { "IdConto" }, new string[] { "int" }, "");
                for (int i = 0; i < CertspContiCollectionObj.Count; i++)
                {
                    switch (CertspContiCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, CertspContiCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    CertspContiCollectionObj[i].IdConto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, CertspContiCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (CertspContiCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdConto", (SiarLibrary.NullTypes.IntNT)CertspContiCollectionObj[i].IdConto);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < CertspContiCollectionObj.Count; i++)
                {
                    if ((CertspContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CertspContiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        CertspContiCollectionObj[i].IsDirty = false;
                        CertspContiCollectionObj[i].IsPersistent = true;
                    }
                    if ((CertspContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        CertspContiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CertspContiCollectionObj[i].IsDirty = false;
                        CertspContiCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, CertspConti CertspContiObj)
        {
            int returnValue = 0;
            if (CertspContiObj.IsPersistent)
            {
                returnValue = Delete(db, CertspContiObj.IdConto);
            }
            CertspContiObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            CertspContiObj.IsDirty = false;
            CertspContiObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdContoValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZCertspContiDelete", new string[] { "IdConto" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdConto", (SiarLibrary.NullTypes.IntNT)IdContoValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, CertspContiCollection CertspContiCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZCertspContiDelete", new string[] { "IdConto" }, new string[] { "int" }, "");
                for (int i = 0; i < CertspContiCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdConto", CertspContiCollectionObj[i].IdConto);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < CertspContiCollectionObj.Count; i++)
                {
                    if ((CertspContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (CertspContiCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        CertspContiCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        CertspContiCollectionObj[i].IsDirty = false;
                        CertspContiCollectionObj[i].IsPersistent = false;
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
        public static CertspConti GetById(DbProvider db, int IdContoValue)
        {
            CertspConti CertspContiObj = null;
            IDbCommand readCmd = db.InitCmd("ZCertspContiGetById", new string[] { "IdConto" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdConto", (SiarLibrary.NullTypes.IntNT)IdContoValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                CertspContiObj = GetFromDatareader(db);
                CertspContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspContiObj.IsDirty = false;
                CertspContiObj.IsPersistent = true;
            }
            db.Close();
            return CertspContiObj;
        }

        //getFromDatareader
        public static CertspConti GetFromDatareader(DbProvider db)
        {
            CertspConti CertspContiObj = new CertspConti();
            CertspContiObj.IdConto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_CONTO"]);
            CertspContiObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
            CertspContiObj.IdAtto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ATTO"]);
            CertspContiObj.DataPresContab = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRES_CONTAB"]);
            CertspContiObj.DataPresConti = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PRES_CONTI"]);
            CertspContiObj.TotRegistrate = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_REGISTRATE"]);
            CertspContiObj.TotSpesapubRegistrate = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_SPESAPUB_REGISTRATE"]);
            CertspContiObj.TotPagamentiRegistrate = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_PAGAMENTI_REGISTRATE"]);
            CertspContiObj.TotRitirata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_RITIRATA"]);
            CertspContiObj.TotSpesapubRitirata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_SPESAPUB_RITIRATA"]);
            CertspContiObj.TotRecuperata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_RECUPERATA"]);
            CertspContiObj.TotSpesapubRecuperata = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_SPESAPUB_RECUPERATA"]);
            CertspContiObj.TotDarecuperare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_DARECUPERARE"]);
            CertspContiObj.TotSpesapubDarecuperare = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_SPESAPUB_DARECUPERARE"]);
            CertspContiObj.TotNonrecuperab = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_NONRECUPERAB"]);
            CertspContiObj.TotSpesapubNonrecuperab = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["TOT_SPESAPUB_NONRECUPERAB"]);
            CertspContiObj.RecuperatoArt71 = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RECUPERATO_ART71"]);
            CertspContiObj.RecuperatoArt71Pubblica = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["RECUPERATO_ART71_PUBBLICA"]);
            CertspContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            CertspContiObj.IsDirty = false;
            CertspContiObj.IsPersistent = true;
            return CertspContiObj;
        }

        //Find Select

        public static CertspContiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdContoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdAttoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataPresContabEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPresContiEqualThis, SiarLibrary.NullTypes.DecimalNT TotRegistrateEqualThis,
SiarLibrary.NullTypes.DecimalNT TotSpesapubRegistrateEqualThis, SiarLibrary.NullTypes.DecimalNT TotPagamentiRegistrateEqualThis, SiarLibrary.NullTypes.DecimalNT TotRitirataEqualThis,
SiarLibrary.NullTypes.DecimalNT TotSpesapubRitirataEqualThis, SiarLibrary.NullTypes.DecimalNT TotRecuperataEqualThis, SiarLibrary.NullTypes.DecimalNT TotSpesapubRecuperataEqualThis,
SiarLibrary.NullTypes.DecimalNT TotDarecuperareEqualThis, SiarLibrary.NullTypes.DecimalNT TotSpesapubDarecuperareEqualThis, SiarLibrary.NullTypes.DecimalNT TotNonrecuperabEqualThis,
SiarLibrary.NullTypes.DecimalNT TotSpesapubNonrecuperabEqualThis, SiarLibrary.NullTypes.DecimalNT RecuperatoArt71EqualThis, SiarLibrary.NullTypes.DecimalNT RecuperatoArt71PubblicaEqualThis)
        {

            CertspContiCollection CertspContiCollectionObj = new CertspContiCollection();

            IDbCommand findCmd = db.InitCmd("Zcertspcontifindselect", new string[] {"IdContoequalthis", "IdProgettoequalthis", "IdAttoequalthis", 
"DataPresContabequalthis", "DataPresContiequalthis", "TotRegistrateequalthis", 
"TotSpesapubRegistrateequalthis", "TotPagamentiRegistrateequalthis", "TotRitirataequalthis", 
"TotSpesapubRitirataequalthis", "TotRecuperataequalthis", "TotSpesapubRecuperataequalthis", 
"TotDarecuperareequalthis", "TotSpesapubDarecuperareequalthis", "TotNonrecuperabequalthis", 
"TotSpesapubNonrecuperabequalthis", "RecuperatoArt71equalthis", "RecuperatoArt71Pubblicaequalthis"}, new string[] {"int", "int", "int", 
"DateTime", "DateTime", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal", 
"decimal", "decimal", "decimal"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdContoequalthis", IdContoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdAttoequalthis", IdAttoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPresContabequalthis", DataPresContabEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataPresContiequalthis", DataPresContiEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotRegistrateequalthis", TotRegistrateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotSpesapubRegistrateequalthis", TotSpesapubRegistrateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotPagamentiRegistrateequalthis", TotPagamentiRegistrateEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotRitirataequalthis", TotRitirataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotSpesapubRitirataequalthis", TotSpesapubRitirataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotRecuperataequalthis", TotRecuperataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotSpesapubRecuperataequalthis", TotSpesapubRecuperataEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotDarecuperareequalthis", TotDarecuperareEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotSpesapubDarecuperareequalthis", TotSpesapubDarecuperareEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotNonrecuperabequalthis", TotNonrecuperabEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "TotSpesapubNonrecuperabequalthis", TotSpesapubNonrecuperabEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RecuperatoArt71equalthis", RecuperatoArt71EqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "RecuperatoArt71Pubblicaequalthis", RecuperatoArt71PubblicaEqualThis);
            CertspConti CertspContiObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                CertspContiObj = GetFromDatareader(db);
                CertspContiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                CertspContiObj.IsDirty = false;
                CertspContiObj.IsPersistent = true;
                CertspContiCollectionObj.Add(CertspContiObj);
            }
            db.Close();
            return CertspContiCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for CertspContiCollectionProvider:ICertspContiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class CertspContiCollectionProvider : ICertspContiProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di CertspConti
        protected CertspContiCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public CertspContiCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new CertspContiCollection(this);
        }

        //Costruttore3: ha in input certspcontiCollectionObj - non popola la collection
        public CertspContiCollectionProvider(CertspContiCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public CertspContiCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new CertspContiCollection(this);
        }

        //Get e Set
        public CertspContiCollection CollectionObj
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
        public int SaveCollection(CertspContiCollection collectionObj)
        {
            return CertspContiDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(CertspConti certspcontiObj)
        {
            return CertspContiDAL.Save(_dbProviderObj, certspcontiObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(CertspContiCollection collectionObj)
        {
            return CertspContiDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(CertspConti certspcontiObj)
        {
            return CertspContiDAL.Delete(_dbProviderObj, certspcontiObj);
        }

        //getById
        public CertspConti GetById(IntNT IdContoValue)
        {
            CertspConti CertspContiTemp = CertspContiDAL.GetById(_dbProviderObj, IdContoValue);
            if (CertspContiTemp != null) CertspContiTemp.Provider = this;
            return CertspContiTemp;
        }

        //Select: popola la collection
        public CertspContiCollection Select(IntNT IdcontoEqualThis, IntNT IdprogettoEqualThis, IntNT IdattoEqualThis,
DatetimeNT DataprescontabEqualThis, DatetimeNT DataprescontiEqualThis, DecimalNT TotregistrateEqualThis,
DecimalNT TotspesapubregistrateEqualThis, DecimalNT TotpagamentiregistrateEqualThis, DecimalNT TotritirataEqualThis,
DecimalNT TotspesapubritirataEqualThis, DecimalNT TotrecuperataEqualThis, DecimalNT TotspesapubrecuperataEqualThis,
DecimalNT TotdarecuperareEqualThis, DecimalNT TotspesapubdarecuperareEqualThis, DecimalNT TotnonrecuperabEqualThis,
DecimalNT TotspesapubnonrecuperabEqualThis, DecimalNT Recuperatoart71EqualThis, DecimalNT Recuperatoart71pubblicaEqualThis)
        {
            CertspContiCollection CertspContiCollectionTemp = CertspContiDAL.Select(_dbProviderObj, IdcontoEqualThis, IdprogettoEqualThis, IdattoEqualThis,
DataprescontabEqualThis, DataprescontiEqualThis, TotregistrateEqualThis,
TotspesapubregistrateEqualThis, TotpagamentiregistrateEqualThis, TotritirataEqualThis,
TotspesapubritirataEqualThis, TotrecuperataEqualThis, TotspesapubrecuperataEqualThis,
TotdarecuperareEqualThis, TotspesapubdarecuperareEqualThis, TotnonrecuperabEqualThis,
TotspesapubnonrecuperabEqualThis, Recuperatoart71EqualThis, Recuperatoart71pubblicaEqualThis);
            CertspContiCollectionTemp.Provider = this;
            return CertspContiCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<CERTSP_CONTI>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</CERTSP_CONTI>
*/
