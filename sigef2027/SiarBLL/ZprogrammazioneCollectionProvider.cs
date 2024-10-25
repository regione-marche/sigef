using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

    // interfaccia provider per Zprogrammazione
    // Interfaccia Autogenerata
    // Inserire eventuali operazioni aggiuntive
    public interface IZprogrammazioneProvider
    {
        int Save(Zprogrammazione ZprogrammazioneObj);
        int SaveCollection(ZprogrammazioneCollection collectionObj);
        int Delete(Zprogrammazione ZprogrammazioneObj);
        int DeleteCollection(ZprogrammazioneCollection collectionObj);
    }
    /// <summary>
    /// Summary description for Zprogrammazione
    /// Class Autogenerata
    /// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
    /// con delle partial class contenenti i metodi aggiunti, in questo modo 
    /// non verranno sovrascritti quando si rigenera la classe 
    /// </summary>

    [Serializable]
    [System.Xml.Serialization.XmlType(Namespace = "")]

    public partial class Zprogrammazione : BaseObject
    {

        //Definizione dei campi 'base'
        private NullTypes.IntNT _Id;
        private NullTypes.StringNT _CodTipo;
        private NullTypes.StringNT _Codice;
        private NullTypes.StringNT _Descrizione;
        private NullTypes.IntNT _IdPadre;
        private NullTypes.StringNT _CodPsr;
        private NullTypes.StringNT _Tipo;
        private NullTypes.IntNT _Livello;
        private NullTypes.BoolNT _AttivazioneBandi;
        private NullTypes.BoolNT _AttivazioneFa;
        private NullTypes.BoolNT _AttivazioneObMisura;
        private NullTypes.BoolNT _AttivazioneInvestimenti;
        private NullTypes.BoolNT _AttivazioneFf;
        private NullTypes.DecimalNT _ImportoDotazione;
        [NonSerialized]
        private IZprogrammazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZprogrammazioneProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }


        //Costruttore
        public Zprogrammazione()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //Get e Set dei campi 'base'
        /// <summary>
        /// Corrisponde al campo:ID
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Id
        {
            get { return _Id; }
            set
            {
                if (Id != value)
                {
                    _Id = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_TIPO
        /// Tipo sul db:VARCHAR(30)
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
        /// Corrisponde al campo:CODICE
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT Codice
        {
            get { return _Codice; }
            set
            {
                if (Codice != value)
                {
                    _Codice = value;
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
        /// Corrisponde al campo:ID_PADRE
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT IdPadre
        {
            get { return _IdPadre; }
            set
            {
                if (IdPadre != value)
                {
                    _IdPadre = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:COD_PSR
        /// Tipo sul db:VARCHAR(20)
        /// </summary>
        public NullTypes.StringNT CodPsr
        {
            get { return _CodPsr; }
            set
            {
                if (CodPsr != value)
                {
                    _CodPsr = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:TIPO
        /// Tipo sul db:VARCHAR(50)
        /// </summary>
        public NullTypes.StringNT Tipo
        {
            get { return _Tipo; }
            set
            {
                if (Tipo != value)
                {
                    _Tipo = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:LIVELLO
        /// Tipo sul db:INT
        /// </summary>
        public NullTypes.IntNT Livello
        {
            get { return _Livello; }
            set
            {
                if (Livello != value)
                {
                    _Livello = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVAZIONE_BANDI
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AttivazioneBandi
        {
            get { return _AttivazioneBandi; }
            set
            {
                if (AttivazioneBandi != value)
                {
                    _AttivazioneBandi = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVAZIONE_FA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AttivazioneFa
        {
            get { return _AttivazioneFa; }
            set
            {
                if (AttivazioneFa != value)
                {
                    _AttivazioneFa = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVAZIONE_OB_MISURA
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AttivazioneObMisura
        {
            get { return _AttivazioneObMisura; }
            set
            {
                if (AttivazioneObMisura != value)
                {
                    _AttivazioneObMisura = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVAZIONE_INVESTIMENTI
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AttivazioneInvestimenti
        {
            get { return _AttivazioneInvestimenti; }
            set
            {
                if (AttivazioneInvestimenti != value)
                {
                    _AttivazioneInvestimenti = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:ATTIVAZIONE_FF
        /// Tipo sul db:BIT
        /// </summary>
        public NullTypes.BoolNT AttivazioneFf
        {
            get { return _AttivazioneFf; }
            set
            {
                if (AttivazioneFf != value)
                {
                    _AttivazioneFf = value;
                    SetDirtyFlag();
                }
            }
        }

        /// <summary>
        /// Corrisponde al campo:IMPORTO_DOTAZIONE
        /// Tipo sul db:DECIMAL(18,2)
        /// </summary>
        public NullTypes.DecimalNT ImportoDotazione
        {
            get { return _ImportoDotazione; }
            set
            {
                if (ImportoDotazione != value)
                {
                    _ImportoDotazione = value;
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
    /// Summary description for ZprogrammazioneCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZprogrammazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
        private ZprogrammazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((Zprogrammazione)info.GetValue(i.ToString(), typeof(Zprogrammazione)));
            }
        }

        //Costruttore
        public ZprogrammazioneCollection()
        {
            this.ItemType = typeof(Zprogrammazione);
        }

        //Costruttore con provider
        public ZprogrammazioneCollection(IZprogrammazioneProvider providerObj)
        {
            this.ItemType = typeof(Zprogrammazione);
            this.Provider = providerObj;
        }

        //Get e Set
        public new Zprogrammazione this[int index]
        {
            get { return (Zprogrammazione)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new ZprogrammazioneCollection GetChanges()
        {
            return (ZprogrammazioneCollection)base.GetChanges();
        }

        [NonSerialized]
        private IZprogrammazioneProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IZprogrammazioneProvider Provider
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
        public int Add(Zprogrammazione ZprogrammazioneObj)
        {
            if (ZprogrammazioneObj.Provider == null) ZprogrammazioneObj.Provider = this.Provider;
            return base.Add(ZprogrammazioneObj);
        }

        //AddCollection
        public void AddCollection(ZprogrammazioneCollection ZprogrammazioneCollectionObj)
        {
            foreach (Zprogrammazione ZprogrammazioneObj in ZprogrammazioneCollectionObj)
                this.Add(ZprogrammazioneObj);
        }

        //Insert
        public void Insert(int index, Zprogrammazione ZprogrammazioneObj)
        {
            if (ZprogrammazioneObj.Provider == null) ZprogrammazioneObj.Provider = this.Provider;
            base.Insert(index, ZprogrammazioneObj);
        }

        //CollectionGetById
        public Zprogrammazione CollectionGetById(NullTypes.IntNT IdValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].Id == IdValue))
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
        public ZprogrammazioneCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT CodiceEqualThis,
NullTypes.StringNT DescrizioneEqualThis, NullTypes.IntNT IdPadreEqualThis, NullTypes.DecimalNT ImportoDotazioneEqualThis)
        {
            ZprogrammazioneCollection ZprogrammazioneCollectionTemp = new ZprogrammazioneCollection();
            foreach (Zprogrammazione ZprogrammazioneItem in this)
            {
                if (((IdEqualThis == null) || ((ZprogrammazioneItem.Id != null) && (ZprogrammazioneItem.Id.Value == IdEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ZprogrammazioneItem.CodTipo != null) && (ZprogrammazioneItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((CodiceEqualThis == null) || ((ZprogrammazioneItem.Codice != null) && (ZprogrammazioneItem.Codice.Value == CodiceEqualThis.Value))) &&
((DescrizioneEqualThis == null) || ((ZprogrammazioneItem.Descrizione != null) && (ZprogrammazioneItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((IdPadreEqualThis == null) || ((ZprogrammazioneItem.IdPadre != null) && (ZprogrammazioneItem.IdPadre.Value == IdPadreEqualThis.Value))) && ((ImportoDotazioneEqualThis == null) || ((ZprogrammazioneItem.ImportoDotazione != null) && (ZprogrammazioneItem.ImportoDotazione.Value == ImportoDotazioneEqualThis.Value))))
                {
                    ZprogrammazioneCollectionTemp.Add(ZprogrammazioneItem);
                }
            }
            return ZprogrammazioneCollectionTemp;
        }



    }
}

namespace SiarDAL
{

    /// <summary>
    /// Summary description for ZprogrammazioneDAL
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    internal class ZprogrammazioneDAL
    {

        //Operazioni

        //internal CompileIUCmd compila un command con i parametri per l'insert o l'update
        protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, Zprogrammazione ZprogrammazioneObj, string firstChar)
        {
            if (forUpdate)
            {
                // campi identity valorizzati solo per l'update
                DbProvider.SetCmdParam(cmd, firstChar + "Id", ZprogrammazioneObj.Id);
                // altri campi sempre valorizzati
            }
            DbProvider.SetCmdParam(cmd, firstChar + "CodTipo", ZprogrammazioneObj.CodTipo);
            DbProvider.SetCmdParam(cmd, firstChar + "Codice", ZprogrammazioneObj.Codice);
            DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", ZprogrammazioneObj.Descrizione);
            DbProvider.SetCmdParam(cmd, firstChar + "IdPadre", ZprogrammazioneObj.IdPadre);
            DbProvider.SetCmdParam(cmd, firstChar + "ImportoDotazione", ZprogrammazioneObj.ImportoDotazione);
        }
        //Insert
        private static int Insert(DbProvider db, Zprogrammazione ZprogrammazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand insertCmd = db.InitCmd("ZZprogrammazioneInsert", new string[] {"CodTipo", "Codice", 
"Descrizione", "IdPadre", 


"ImportoDotazione"}, new string[] {"string", "string", 
"string", "int", 


"decimal"}, "");
                CompileIUCmd(false, insertCmd, ZprogrammazioneObj, db.CommandFirstChar);
                db.InitDatareader(insertCmd);
                if (db.DataReader.Read())
                {
                    ZprogrammazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                }
                ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneObj.IsDirty = false;
                ZprogrammazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //update
        private static int Update(DbProvider db, Zprogrammazione ZprogrammazioneObj)
        {
            int i = 1;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZprogrammazioneUpdate", new string[] {"Id", "CodTipo", "Codice", 
"Descrizione", "IdPadre", 


"ImportoDotazione"}, new string[] {"int", "string", "string", 
"string", "int", 


"decimal"}, "");
                CompileIUCmd(true, updateCmd, ZprogrammazioneObj, db.CommandFirstChar);
                i = db.Execute(updateCmd);
                ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneObj.IsDirty = false;
                ZprogrammazioneObj.IsPersistent = true;
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        //Save
        public static int Save(DbProvider db, Zprogrammazione ZprogrammazioneObj)
        {
            switch (ZprogrammazioneObj.ObjectState)
            {
                case BaseObject.ObjectStateType.Added: return Insert(db, ZprogrammazioneObj);
                case BaseObject.ObjectStateType.Changed: return Update(db, ZprogrammazioneObj);
                case BaseObject.ObjectStateType.Deleted: return Delete(db, ZprogrammazioneObj);
                default: return 0;
            }
        }

        public static int SaveCollection(DbProvider db, ZprogrammazioneCollection ZprogrammazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand updateCmd = db.InitCmd("ZZprogrammazioneUpdate", new string[] {"Id", "CodTipo", "Codice", 
"Descrizione", "IdPadre", 


"ImportoDotazione"}, new string[] {"int", "string", "string", 
"string", "int", 


"decimal"}, "");
                IDbCommand insertCmd = db.InitCmd("ZZprogrammazioneInsert", new string[] {"CodTipo", "Codice", 
"Descrizione", "IdPadre", 


"ImportoDotazione"}, new string[] {"string", "string", 
"string", "int", 


"decimal"}, "");
                IDbCommand deleteCmd = db.InitCmd("ZZprogrammazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ZprogrammazioneCollectionObj.Count; i++)
                {
                    switch (ZprogrammazioneCollectionObj[i].ObjectState)
                    {
                        case BaseObject.ObjectStateType.Added:
                            {
                                CompileIUCmd(false, insertCmd, ZprogrammazioneCollectionObj[i], db.CommandFirstChar);
                                db.InitDatareader(insertCmd);
                                if (db.DataReader.Read())
                                {
                                    ZprogrammazioneCollectionObj[i].Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
                                }
                                db.DataReader.Close();
                                returnValue++;
                            }
                            break;
                        case BaseObject.ObjectStateType.Changed:
                            {
                                CompileIUCmd(true, updateCmd, ZprogrammazioneCollectionObj[i], db.CommandFirstChar);
                                returnValue = returnValue + db.Execute(updateCmd);
                            }
                            break;
                        case BaseObject.ObjectStateType.Deleted:
                            {
                                if (ZprogrammazioneCollectionObj[i].IsPersistent)
                                {
                                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)ZprogrammazioneCollectionObj[i].Id);
                                    returnValue = returnValue + db.Execute(deleteCmd);
                                }
                            }
                            break;
                    }
                }
                db.Commit();
                for (int i = 0; i < ZprogrammazioneCollectionObj.Count; i++)
                {
                    if ((ZprogrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZprogrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
                        ZprogrammazioneCollectionObj[i].IsDirty = false;
                        ZprogrammazioneCollectionObj[i].IsPersistent = true;
                    }
                    if ((ZprogrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
                    {
                        ZprogrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZprogrammazioneCollectionObj[i].IsDirty = false;
                        ZprogrammazioneCollectionObj[i].IsPersistent = false;
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
        public static int Delete(DbProvider db, Zprogrammazione ZprogrammazioneObj)
        {
            int returnValue = 0;
            if (ZprogrammazioneObj.IsPersistent)
            {
                returnValue = Delete(db, ZprogrammazioneObj.Id);
            }
            ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Deleted;
            ZprogrammazioneObj.IsDirty = false;
            ZprogrammazioneObj.IsPersistent = false;
            return returnValue;
        }

        //Delete
        private static int Delete(DbProvider db, int IdValue)
        {
            int i = 1;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZprogrammazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
                i = db.Execute(deleteCmd);
            }
            finally
            {
                db.Close();
            }
            return i;
        }

        public static int DeleteCollection(DbProvider db, ZprogrammazioneCollection ZprogrammazioneCollectionObj)
        {
            db.BeginTran();
            int returnValue = 0;
            try
            {
                IDbCommand deleteCmd = db.InitCmd("ZZprogrammazioneDelete", new string[] { "Id" }, new string[] { "int" }, "");
                for (int i = 0; i < ZprogrammazioneCollectionObj.Count; i++)
                {
                    DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "Id", ZprogrammazioneCollectionObj[i].Id);
                    returnValue = returnValue + db.Execute(deleteCmd);
                }
                db.Commit();
                for (int i = 0; i < ZprogrammazioneCollectionObj.Count; i++)
                {
                    if ((ZprogrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZprogrammazioneCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
                    {
                        ZprogrammazioneCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
                        ZprogrammazioneCollectionObj[i].IsDirty = false;
                        ZprogrammazioneCollectionObj[i].IsPersistent = false;
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
        public static Zprogrammazione GetById(DbProvider db, int IdValue)
        {
            Zprogrammazione ZprogrammazioneObj = null;
            IDbCommand readCmd = db.InitCmd("ZZprogrammazioneGetById", new string[] { "Id" }, new string[] { "int" }, "");
            DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "Id", (SiarLibrary.NullTypes.IntNT)IdValue);
            db.InitDatareader(readCmd);
            if (db.DataReader.Read())
            {
                ZprogrammazioneObj = GetFromDatareader(db);
                ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneObj.IsDirty = false;
                ZprogrammazioneObj.IsPersistent = true;
            }
            db.Close();
            return ZprogrammazioneObj;
        }

        //getFromDatareader
        public static Zprogrammazione GetFromDatareader(DbProvider db)
        {
            Zprogrammazione ZprogrammazioneObj = new Zprogrammazione();
            ZprogrammazioneObj.Id = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID"]);
            ZprogrammazioneObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
            ZprogrammazioneObj.Codice = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODICE"]);
            ZprogrammazioneObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
            ZprogrammazioneObj.IdPadre = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PADRE"]);
            ZprogrammazioneObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
            ZprogrammazioneObj.Tipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO"]);
            ZprogrammazioneObj.Livello = new SiarLibrary.NullTypes.IntNT(db.DataReader["LIVELLO"]);
            ZprogrammazioneObj.AttivazioneBandi = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_BANDI"]);
            ZprogrammazioneObj.AttivazioneFa = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FA"]);
            ZprogrammazioneObj.AttivazioneObMisura = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_OB_MISURA"]);
            ZprogrammazioneObj.AttivazioneInvestimenti = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_INVESTIMENTI"]);
            ZprogrammazioneObj.AttivazioneFf = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVAZIONE_FF"]);
            ZprogrammazioneObj.ImportoDotazione = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["IMPORTO_DOTAZIONE"]);
            ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
            ZprogrammazioneObj.IsDirty = false;
            ZprogrammazioneObj.IsPersistent = true;
            return ZprogrammazioneObj;
        }

        //Find Select

        public static ZprogrammazioneCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodiceEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.IntNT IdPadreEqualThis, SiarLibrary.NullTypes.DecimalNT ImportoDotazioneEqualThis)
        {

            ZprogrammazioneCollection ZprogrammazioneCollectionObj = new ZprogrammazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zzprogrammazionefindselect", new string[] {"Idequalthis", "CodTipoequalthis", "Codiceequalthis", 
"Descrizioneequalthis", "IdPadreequalthis", "ImportoDotazioneequalthis"}, new string[] {"int", "string", "string", 
"string", "int", "decimal"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Idequalthis", IdEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPadreequalthis", IdPadreEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ImportoDotazioneequalthis", ImportoDotazioneEqualThis);
            Zprogrammazione ZprogrammazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZprogrammazioneObj = GetFromDatareader(db);
                ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneObj.IsDirty = false;
                ZprogrammazioneObj.IsPersistent = true;
                ZprogrammazioneCollectionObj.Add(ZprogrammazioneObj);
            }
            db.Close();
            return ZprogrammazioneCollectionObj;
        }

        //Find Find

        public static ZprogrammazioneCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodiceEqualThis, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.IntNT LivelloEqualThis, SiarLibrary.NullTypes.IntNT IdPadreEqualThis)
        {

            ZprogrammazioneCollection ZprogrammazioneCollectionObj = new ZprogrammazioneCollection();

            IDbCommand findCmd = db.InitCmd("Zzprogrammazionefindfind", new string[] {"Codiceequalthis", "CodTipoequalthis", "CodPsrequalthis", 
"Descrizionelikethis", "Livelloequalthis", "IdPadreequalthis"}, new string[] {"string", "string", "string", 
"string", "int", "int"}, "");

            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Codiceequalthis", CodiceEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Livelloequalthis", LivelloEqualThis);
            DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdPadreequalthis", IdPadreEqualThis);
            Zprogrammazione ZprogrammazioneObj;
            db.InitDatareader(findCmd);
            while (db.DataReader.Read())
            {
                ZprogrammazioneObj = GetFromDatareader(db);
                ZprogrammazioneObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
                ZprogrammazioneObj.IsDirty = false;
                ZprogrammazioneObj.IsPersistent = true;
                ZprogrammazioneCollectionObj.Add(ZprogrammazioneObj);
            }
            db.Close();
            return ZprogrammazioneCollectionObj;
        }

    }
}


namespace SiarBLL
{

    /// <summary>
    /// Summary description for ZprogrammazioneCollectionProvider:IZprogrammazioneProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public partial class ZprogrammazioneCollectionProvider : IZprogrammazioneProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di Zprogrammazione
        protected ZprogrammazioneCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public ZprogrammazioneCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new ZprogrammazioneCollection(this);
        }

        //Costruttore 2: popola la collection
        public ZprogrammazioneCollectionProvider(StringNT CodiceEqualThis, StringNT CodtipoEqualThis, StringNT CodpsrEqualThis,
StringNT DescrizioneLikeThis, IntNT LivelloEqualThis, IntNT IdpadreEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(CodiceEqualThis, CodtipoEqualThis, CodpsrEqualThis,
DescrizioneLikeThis, LivelloEqualThis, IdpadreEqualThis);
        }

        //Costruttore3: ha in input zprogrammazioneCollectionObj - non popola la collection
        public ZprogrammazioneCollectionProvider(ZprogrammazioneCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public ZprogrammazioneCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new ZprogrammazioneCollection(this);
        }

        //Get e Set
        public ZprogrammazioneCollection CollectionObj
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
        public int SaveCollection(ZprogrammazioneCollection collectionObj)
        {
            return ZprogrammazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(Zprogrammazione zprogrammazioneObj)
        {
            return ZprogrammazioneDAL.Save(_dbProviderObj, zprogrammazioneObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(ZprogrammazioneCollection collectionObj)
        {
            return ZprogrammazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(Zprogrammazione zprogrammazioneObj)
        {
            return ZprogrammazioneDAL.Delete(_dbProviderObj, zprogrammazioneObj);
        }

        //getById
        public Zprogrammazione GetById(IntNT IdValue)
        {
            Zprogrammazione ZprogrammazioneTemp = ZprogrammazioneDAL.GetById(_dbProviderObj, IdValue);
            if (ZprogrammazioneTemp != null) ZprogrammazioneTemp.Provider = this;
            return ZprogrammazioneTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public ZprogrammazioneCollection Select(IntNT IdEqualThis, StringNT CodtipoEqualThis, StringNT CodiceEqualThis,
StringNT DescrizioneEqualThis, IntNT IdpadreEqualThis, DecimalNT ImportodotazioneEqualThis)
        {
            ZprogrammazioneCollection ZprogrammazioneCollectionTemp = ZprogrammazioneDAL.Select(_dbProviderObj, IdEqualThis, CodtipoEqualThis, CodiceEqualThis,
DescrizioneEqualThis, IdpadreEqualThis, ImportodotazioneEqualThis);
            ZprogrammazioneCollectionTemp.Provider = this;
            return ZprogrammazioneCollectionTemp;
        }

        //Find: popola la collection
        public ZprogrammazioneCollection Find(StringNT CodiceEqualThis, StringNT CodtipoEqualThis, StringNT CodpsrEqualThis,
StringNT DescrizioneLikeThis, IntNT LivelloEqualThis, IntNT IdpadreEqualThis)
        {
            ZprogrammazioneCollection ZprogrammazioneCollectionTemp = ZprogrammazioneDAL.Find(_dbProviderObj, CodiceEqualThis, CodtipoEqualThis, CodpsrEqualThis,
DescrizioneLikeThis, LivelloEqualThis, IdpadreEqualThis);
            ZprogrammazioneCollectionTemp.Provider = this;
            return ZprogrammazioneCollectionTemp;
        }


    }
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zPROGRAMMAZIONE>
  <ViewName>vzPROGRAMMAZIONE</ViewName>
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
    <Find OrderBy="ORDER BY LIVELLO, CODICE, DESCRIZIONE">
      <CODICE>Equal</CODICE>
      <COD_TIPO>Equal</COD_TIPO>
      <COD_PSR>Equal</COD_PSR>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <LIVELLO>Equal</LIVELLO>
      <ID_PADRE>Equal</ID_PADRE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zPROGRAMMAZIONE>
*/
